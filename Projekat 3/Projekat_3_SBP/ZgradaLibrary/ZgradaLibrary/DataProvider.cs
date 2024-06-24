using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using ZgradaLibrary.Entiteti;

namespace ZgradaLibrary;

public static class DataProvider
{
    #region Angazovanje

    public static Result<List<AngazovanjePregled>, ErrorMessage> VratiSvaAngazovanja()
    {
        List<AngazovanjePregled> angazovanja = new();

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();
            
            if(!(session?.IsConnected ?? false))
            {
                return "Nemogućе otvoriti sesiju.".ToError(403);
            }

            IEnumerable<Angazovanje> svaAngazovanja = from a in session.Query<Angazovanje>()
                                                      select a;

            foreach (Angazovanje a in svaAngazovanja)
            {
                angazovanja.Add(new AngazovanjePregled(a));
            }
        }
        catch (Exception)
        { 
            return "Nemogućе vratiti sva angažovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return angazovanja;
    }

    public static Result<List<AngazovanjePregled>, ErrorMessage> VratiSvaAngazovanjaZgrade(int idZgrade)
    {
        List<AngazovanjePregled> angazovanja = new();

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemogućе otvoriti sesiju.".ToError(403);
            }

            IEnumerable<Angazovanje> svaAngazovanja = from a in session.Query<Angazovanje>()
                                                      where a.Zgrada!.ID == idZgrade
                                                      select a;

            foreach (Angazovanje a in svaAngazovanja)
            {
                angazovanja.Add(new AngazovanjePregled(a));
            }
        }
        catch (Exception)
        {
            return "Nemogućе vratiti sva angažovanja zgrade.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return angazovanja;
    }

    public static Result<AngazovanjePregled, ErrorMessage> VratiAngazovanje(int idZgrade, string jmbgUpravnika)
    {
        ISession? session = null;

        AngazovanjePregled angazovanje = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemogućе otvoriti sesiju.".ToError(403);
            }

            Angazovanje pom = (from a in session.Query<Angazovanje>()
                              where a.Zgrada!.ID == idZgrade && a.Upravnik!.JMBG == jmbgUpravnika
                              select a).FirstOrDefault()!;

            if(pom == null)
            {
                return "Ne postoji dato angažovanje".ToError(404);
            }

            angazovanje = new AngazovanjePregled(pom);
        }
        catch (Exception)
        {
            return "Nemogućе vratiti angažovanje.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return angazovanje;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajAngazovanje(string jmbgUpravnika, int idZgrade)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if(!(session?.IsConnected ?? false))
            {
                return "Nemogućе otvoriti sesiju.".ToError(403);
            }

            Zaposleni upravnik = await session.GetAsync<Zaposleni>(jmbgUpravnika);
            if(upravnik == null || String.Compare(upravnik.TipPosla, "Upravnik", true) != 0)
            {
                return "Ne postoji upravnik sa datim JMBG-om.".ToError(404);
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(idZgrade);
            if(zgrada == null)
            {
                return "Ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if(zgrada.Upravnici == null)
            {
                zgrada.Upravnici = new List<Zaposleni>();
            }
            zgrada.Upravnici.Add(upravnik);

            if(upravnik.UpravljaZgradama == null)
            {
                upravnik.UpravljaZgradama = new List<Zgrada>();
            }
            upravnik.UpravljaZgradama.Add(zgrada);

            await session.SaveOrUpdateAsync(zgrada);
            await session.SaveOrUpdateAsync(upravnik);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodavanje novog angažovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiAngazovanje(string jmbgUpravnika, int idZgrade)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemogućе otvoriti sesiju.".ToError(403);
            }

            Zaposleni upravnik = await session.GetAsync<Zaposleni>(jmbgUpravnika);
            if (upravnik == null || String.Compare(upravnik.TipPosla, "Upravnik", true) != 0)
            {
                return "Ne postoji upravnik sa datim JMBG-om.".ToError(404);
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(idZgrade);
            if (zgrada == null)
            {
                return "Ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if (zgrada.Upravnici != null)
            {
                zgrada.Upravnici.Remove(upravnik);
            }

            if (upravnik.UpravljaZgradama != null)
            {
                upravnik.UpravljaZgradama.Remove(zgrada);
            }

            await session.SaveOrUpdateAsync(zgrada);
            await session.SaveOrUpdateAsync(upravnik);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodavanje novog angažovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Angazovanje

    #region Osoba

    public static Result<List<OsobaPregled>, ErrorMessage> VratiSveOsobe()
    {
        List<OsobaPregled> osobe = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if(!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Osoba> sveOsobe = from o in session.Query<Osoba>()
                                          select o;

            foreach (Osoba o in sveOsobe)
            {
                osobe.Add(new OsobaPregled(o));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve osobe.".ToError(400);
        }

        return osobe;
    }

    #region Zaposleni

    public static Result<List<ZaposleniPregled>, ErrorMessage> VratiSveZaposlene()
    {
        List<ZaposleniPregled> zaposleni = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Zaposleni> sviZaposleni = from z in session.Query<Zaposleni>()
                                                  select z;

            foreach (Zaposleni z in sviZaposleni)
            {
                zaposleni.Add(new ZaposleniPregled(z));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve zaposlene.".ToError(400);
        }

        return zaposleni;
    }

    public async static Task<Result<string, ErrorMessage>> DodajZaposlenog(ZaposleniPregled z)
    {
        ISession? session = null;

        string jmbg = default!;

        try
        {
            session = DataLayer.GetSession();

            if(!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            string[]? pom = z.PunoIme?.Split(' ');

            Zaposleni zaposleni = new()
            {
                JMBG = z.JMBG,
                Adresa = z.Adresa,
                LIme = pom![0],
                ImeRoditelja = pom[1].Substring(1, pom[1].Length - 2),
                Prezime = pom[1],
                Tip = "Zaposleni",
                BrojeviTelefona = new List<Telefon>(),
                DatumRodjenja = z.DatumRodjenja,
                BrLicneKarte = z.BrLicneKarte,
                MestoIzdLK = z.MestoIzdLK,
                TipPosla = z.TipPosla
            };

            if(z.BrojeviTelefona != null)
            {
                foreach (TelefonPregled t in z.BrojeviTelefona)
                {
                    zaposleni.BrojeviTelefona.Add(new Telefon()
                    {
                        BrojTelefona = t.BrojTelefona,
                        Osoba = await session.LoadAsync<Osoba>(t.Osoba?.JMBG)
                    });
                }
            }

            if (z.Obrazovanja != null)
            {
                if (zaposleni.Obrazovanja == null)
                {
                    zaposleni.Obrazovanja = new List<Obrazovanje>();
                }

                foreach (ObrazovanjePregled o in z.Obrazovanja)
                {

                    zaposleni.Obrazovanja.Add(new Obrazovanje()
                    {
                        DatumSticanja = o.DatumSticanja,
                        NazivInstitucije = o.NazivInstitucije,
                        Zvanje = o.Zvanje,
                        Upravnik = await session.LoadAsync<Zaposleni>(o.Upravnik?.JMBG)
                    });
                }
            }

            if (z.Licence != null)
            {
                if (zaposleni.Licence == null)
                {
                    zaposleni.Licence = new List<Licenca>();
                }

                foreach (LicencaPregled l in z.Licence)
                {

                    zaposleni.Licence.Add(new Licenca()
                    {
                        DatumSticanja = l.DatumSticanja,
                        BrLicence = l.BrLicence,
                        Izdavac = l.Izdavac,
                        Upravnik = await session.LoadAsync<Zaposleni>(l.Upravnik?.JMBG)
                    });
                }
            }

            if (z.Zgrade != null)
            {
                if (zaposleni.UpravljaZgradama == null)
                {
                    zaposleni.UpravljaZgradama = new List<Zgrada>();
                }

                foreach (ZgradaPregled zg in z.Zgrade)
                {

                    zaposleni.UpravljaZgradama.Add(await session.LoadAsync<Zgrada>(zg.ID));
                }
            }

            jmbg = (string)await session.SaveAsync(zaposleni);
            await session.FlushAsync();
        }
        catch(Exception)
        {
            return "Nemoguće dodati zaposlenog.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return jmbg;
    }

    public async static Task<Result<bool, ErrorMessage>> AzurirajZaposlenog(ZaposleniPregled z)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            string[]? pom = z.PunoIme?.Split(' ');

            Zaposleni zaposleni = await session.LoadAsync<Zaposleni>(z.JMBG);

            zaposleni.JMBG = z.JMBG;
            zaposleni.Adresa = z.Adresa;
            zaposleni.LIme = pom![0];
            zaposleni.ImeRoditelja = pom[1].Substring(1, pom[1].Length - 2);
            zaposleni.Prezime = pom[1];
            if(zaposleni.BrojeviTelefona != null)
            {
                zaposleni.BrojeviTelefona.Clear();
            }
            zaposleni.DatumRodjenja = z.DatumRodjenja;
            zaposleni.BrLicneKarte = z.BrLicneKarte;
            zaposleni.MestoIzdLK = z.MestoIzdLK;
            zaposleni.TipPosla = z.TipPosla;

            if (z.BrojeviTelefona != null)
            {
                if(zaposleni.BrojeviTelefona == null)
                {
                    zaposleni.BrojeviTelefona = new List<Telefon>();
                }

                foreach (TelefonPregled t in z.BrojeviTelefona)
                {
                    zaposleni.BrojeviTelefona.Add(new Telefon()
                    {
                        BrojTelefona = t.BrojTelefona,
                        Osoba = await session.LoadAsync<Osoba>(t.Osoba?.JMBG)
                    });
                }
            }

            if (z.Obrazovanja != null)
            {
                if (zaposleni.Obrazovanja == null)
                {
                    zaposleni.Obrazovanja = new List<Obrazovanje>();
                }

                foreach (ObrazovanjePregled o in z.Obrazovanja)
                {
                    zaposleni.Obrazovanja.Add(new Obrazovanje()
                    {
                        DatumSticanja = o.DatumSticanja,
                        NazivInstitucije = o.NazivInstitucije,
                        Zvanje = o.Zvanje,
                        Upravnik = await session.LoadAsync<Zaposleni>(o.Upravnik?.JMBG)
                    });
                }
            }

            if (z.Licence != null)
            {
                if (zaposleni.Licence == null)
                {
                    zaposleni.Licence = new List<Licenca>();
                }

                foreach (LicencaPregled l in z.Licence)
                {
                    zaposleni.Licence.Add(new Licenca()
                    {
                        DatumSticanja = l.DatumSticanja,
                        BrLicence = l.BrLicence,
                        Izdavac = l.Izdavac,
                        Upravnik = await session.LoadAsync<Zaposleni>(l.Upravnik?.JMBG)
                    });
                }
            }

            if (z.Zgrade != null)
            {
                if (zaposleni.UpravljaZgradama == null)
                {
                    zaposleni.UpravljaZgradama = new List<Zgrada>();
                }

                foreach (ZgradaPregled zg in z.Zgrade)
                {
                    zaposleni.UpravljaZgradama.Add(await session.LoadAsync<Zgrada>(zg.ID));
                }
            }

            await session.SaveOrUpdateAsync(zaposleni);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati zaposlenog.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public async static Task<Result<ZaposleniPregled, ErrorMessage>> VratiZaposlenog(string jmbgZaposlenog)
    {
        ISession? session = null;

        ZaposleniPregled zaposleni = default!;

        try
        {
            session = DataLayer.GetSession();

            if(!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zaposleni z = await session.LoadAsync<Zaposleni>(jmbgZaposlenog);
            zaposleni = new ZaposleniPregled(z);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti zaposlenog.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zaposleni;
    }

    public async static Task<Result<bool, ErrorMessage>> ObrisiZaposlenog(string jmbgZaposlenog)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if(!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zaposleni z = await session.LoadAsync<Zaposleni>(jmbgZaposlenog);

            z.UpravljaZgradama?.Clear();

            await session.DeleteAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati zaposlenog.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #region Upravnik

    public static Result<List<ZaposleniPregled>, ErrorMessage> VratiSveUpravnike()
    {
        List<ZaposleniPregled> upravnici = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Zaposleni> sviUpravnici = from z in session.Query<Zaposleni>()
                                                  where String.Compare(z.TipPosla, "Upravnik", true) == 0
                                                  select z;

            foreach (Zaposleni z in sviUpravnici)
            {
                upravnici.Add(new ZaposleniPregled(z));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve upravnike.".ToError(400);
        }

        return upravnici;
    }

    public static Result<List<ZaposleniPregled>, ErrorMessage> VratiSveUpravnikeZgrade(int idZgrade)
    {
        List<ZaposleniPregled> upravnici = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Zaposleni> sviUpravnici = from a in session.Query<Angazovanje>()
                                                  where a.Zgrada!.ID == idZgrade
                                                  select a.Upravnik;

            foreach (Zaposleni z in sviUpravnici)
            {
                upravnici.Add(new ZaposleniPregled(z));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve upravnike zgrade.".ToError(400);
        }

        return upravnici;
    }

    #endregion Upravnik

    #endregion Zaposleni

    #region Vlasnik

    public static Result<List<VlasnikPregled>, ErrorMessage> VratiSveVlasnikeStanova()
    {
        List<VlasnikPregled> vlasnici = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Vlasnik> sviVlasnici = from v in session.Query<Vlasnik>()
                                                  select v;

            foreach (Vlasnik v in sviVlasnici)
            {
                vlasnici.Add(new VlasnikPregled(v));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve vlasnike stanova.".ToError(400);
        }

        return vlasnici;
    }

    public static Result<List<VlasnikPregled>, ErrorMessage> VratiSveVlasnikeStanovaUZgradi(int idZgrade)
    {
        List<VlasnikPregled> vlasnici = new();

        try
        {
            ISession? session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<SkupstinaStanara> sviVlasnici = from z in session.Query<Zgrada>()
                                                        where z.ID == idZgrade
                                                        from v in z.VlasniciStanova!
                                                        select v;

            foreach (SkupstinaStanara s in sviVlasnici)
            {
                vlasnici.Add(new VlasnikPregled(s.Vlasnik));
            }

            session.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve vlasnike stanova u zgradi.".ToError(400);
        }

        return vlasnici;
    }

    #endregion Vlasnik

    #endregion Osoba

    #region Prostor

    public static Result<List<ProstorPregled>, ErrorMessage> VratiSveProstore()
    {
        ISession? session = null;

        List<ProstorPregled> prostori = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Prostor> sviProstori = from p in session.Query<Prostor>()
                                               select p;

            foreach (Prostor p in sviProstori)
            {
                if (String.Compare(p.Tip, "Lokal", true) == 0)
                {
                    prostori.Add(new LokalPregled((Lokal)p));
                }
                else if(String.Compare(p.Tip, "Parking", true) == 0)
                {
                    prostori.Add(new ParkingPregled((Parking)p));
                }
                else
                {
                    prostori.Add(new StanPregled((Stan)p));
                }
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve prostore.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return prostori;
    }

    public static Result<List<ProstorPregled>, ErrorMessage> VratiSveProstoreZgrade(int idZgrade)
    {
        ISession? session = null;

        List<ProstorPregled> prostori = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Prostor> sviProstori = from p in session.Query<Prostor>()
                                               where p.Zgrada!.ID == idZgrade
                                               select p;

            foreach (Prostor p in sviProstori)
            {
                if (String.Compare(p.Tip, "Lokal", true) == 0)
                {
                    prostori.Add(new LokalPregled((Lokal)p));
                }
                else if (String.Compare(p.Tip, "Parking", true) == 0)
                {
                    prostori.Add(new ParkingPregled((Parking)p));
                }
                else
                {
                    prostori.Add(new StanPregled((Stan)p));
                }
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve osobe.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return prostori;
    }

    public static async Task<Result<ProstorPregled, ErrorMessage>> VratiProstor(int idProstora)
    {
        ISession? session = null;

        ProstorPregled prostor = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Prostor pom = await session.GetAsync<Prostor>(idProstora);

            if(pom == null)
            {
                return "Ne postoji prostor sa datim ID-em".ToError(404);
            }

            if(String.Compare(pom.Tip, "Lokal", true) == 0)
            {
                prostor = new LokalPregled((Lokal)pom);
            }
            else if(String.Compare(pom.Tip, "Parking", true) == 0)
            {
                prostor = new ParkingPregled((Parking)pom);
            }
            else
            {
                prostor = new StanPregled((Stan)pom);
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve osobe.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return prostor;
    }

    public static async Task<Result<int, ErrorMessage>> DodajProstor(ProstorPregled prostor)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(prostor.Zgrada!.ID);
            if(zgrada == null)
            {
                return "Nemoguće dodati prostor, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            Prostor p;

            if (String.Compare(prostor.Tip, "Lokal", true) == 0)
            {
                p = new Lokal()
                {
                    ImeFirme = ((LokalPregled)prostor).ImeFirme,
                    RBroj = prostor.RBroj,
                    Tip = prostor.Tip,
                    Zgrada = zgrada,
                    Sprat = await session.LoadAsync<Sprat>(prostor.Sprat!.ID)
                };
            }
            else if (String.Compare(prostor.Tip, "Parking", true) == 0)
            {
                p = new Parking()
                {
                    RegVozila = ((ParkingPregled)prostor).RegVozila,
                    RBroj = prostor.RBroj,
                    Tip = prostor.Tip,
                    Zgrada = zgrada,
                    Sprat = await session.LoadAsync<Sprat>(prostor.Sprat!.ID)
                };
            }
            else
            {
                p = new Stan()
                {
                    Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)prostor).Vlasnik!.JMBG),
                    RBroj = prostor.RBroj,
                    Tip = prostor.Tip,
                    Zgrada = zgrada,
                    Sprat = await session.LoadAsync<Sprat>(prostor.Sprat!.ID),
                    Stanari = new List<ImeStanara>()
                };

                if(((StanPregled)prostor).Stanari != null)
                {
                    foreach (ImeStanaraPregled stanar in ((StanPregled)prostor).Stanari!)
                    {
                        ((Stan)p).Stanari!.Add(new ImeStanara()
                        {
                            ID = stanar.ID,
                            Ime = stanar.Ime,
                            Sprat = await session.LoadAsync<Sprat>(stanar.Stan!.Sprat!.ID),
                            Stan = await session.LoadAsync<Stan>(stanar.Stan.ID),
                            Zgrada = zgrada
                        });
                    }
                }
            }

            if(zgrada.Prostori == null)
            {
                zgrada.Prostori = new List<Prostor>();
            }
            zgrada.Prostori.Add(p);

            id = (int)await session.SaveAsync(zgrada);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati prostor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajProstor(ProstorPregled prostor)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Prostor p = await session.GetAsync<Prostor>(prostor.ID);

            if(p == null)
            {
                return "Ne postoji prostor sa datim ID-em.".ToError(404);
            }

            p.RBroj = prostor.RBroj;
            p.Zgrada = await session.LoadAsync<Zgrada>(prostor.Zgrada!.ID);
            p.Sprat = await session.LoadAsync<Sprat>(prostor.Sprat!.ID);
            p.Tip = prostor.Tip;

            if (String.Compare(prostor.Tip, "Lokal", true) == 0)
            {
                ((Lokal)p).ImeFirme = ((LokalPregled)prostor).ImeFirme;
            }
            else if (String.Compare(prostor.Tip, "Parking", true) == 0)
            {
                ((Parking)p).RegVozila = ((ParkingPregled)prostor).RegVozila;
            }
            else
            {
                ((Stan)p).Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)prostor).Vlasnik!.JMBG);
                if(((Stan)p).Stanari != null)
                {
                    ((Stan)p).Stanari!.Clear();
                }
                else
                {
                    ((Stan)p).Stanari = new List<ImeStanara>();
                }

                if (((StanPregled)prostor).Stanari != null)
                {
                    foreach (ImeStanaraPregled stanar in ((StanPregled)prostor).Stanari!)
                    {
                        ((Stan)p).Stanari!.Add(new ImeStanara()
                        {
                            ID = stanar.ID,
                            Ime = stanar.Ime,
                            Sprat = await session.LoadAsync<Sprat>(stanar.Stan!.Sprat!.ID),
                            Stan = await session.LoadAsync<Stan>(stanar.Stan.ID),
                            Zgrada = await session.LoadAsync<Zgrada>(stanar.Stan.Zgrada!.ID)
                        });
                    }
                }
            }

            await session.SaveOrUpdateAsync(p);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće izmeniti prostor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiProstor(int idProstora)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Prostor p = await session.GetAsync<Prostor>(idProstora);

            if (p == null)
            {
                return "Ne postoji prostor sa datim ID-em.".ToError(404);
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(p.Zgrada!.ID);
            if(zgrada == null)
            {
                return "Nemoguće brisanje prostora, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if(zgrada.Prostori != null)
            {
                zgrada.Prostori.Remove(p);
            }

            await session.SaveOrUpdateAsync(zgrada);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje prostora.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #region Lokal

    public static Result<List<LokalPregled>, ErrorMessage> VratiSveLokale()
    {
        ISession? session = null;

        List<LokalPregled> lokali = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lokal> sviLokali = from l in session.Query<Lokal>()
                                               select l;

            foreach (Lokal l in sviLokali)
            {
                lokali.Add(new LokalPregled(l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve lokale.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return lokali;
    }

    public static Result<List<LokalPregled>, ErrorMessage> VratiSveLokaleUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<LokalPregled> lokali = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lokal> sviLokali = from l in session.Query<Lokal>()
                                           where l.Zgrada!.ID == idZgrade
                                           select l;

            foreach (Lokal l in sviLokali)
            {
                lokali.Add(new LokalPregled(l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve lokale u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return lokali;
    }

    #endregion Lokal

    #region Parking

    public static Result<List<ParkingPregled>, ErrorMessage> VratiSveParkinge()
    {
        ISession? session = null;

        List<ParkingPregled> parkinzi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Parking> sviParkinzi = from p in session.Query<Parking>()
                                           select p;

            foreach (Parking p in sviParkinzi)
            {
                parkinzi.Add(new ParkingPregled(p));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve parkinge.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return parkinzi;
    }

    public static Result<List<ParkingPregled>, ErrorMessage> VratiSveParkingeUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<ParkingPregled> parkinzi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Parking> sviParkinzi = from p in session.Query<Parking>()
                                               where p.Zgrada!.ID == idZgrade
                                               select p;

            foreach (Parking p in sviParkinzi)
            {
                parkinzi.Add(new ParkingPregled(p));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve parkinge u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return parkinzi;
    }

    #endregion Parking

    #region Stan

    public static Result<List<StanPregled>, ErrorMessage> VratiSveStanove()
    {
        ISession? session = null;

        List<StanPregled> stanovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Stan> sviStanovi = from s in session.Query<Stan>()
                                           select s;

            foreach (Stan s in sviStanovi)
            {
                stanovi.Add(new StanPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanove.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanovi;
    }

    public static Result<List<StanPregled>, ErrorMessage> VratiSveStanoveUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<StanPregled> stanovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Stan> sviStanovi = from s in session.Query<Stan>()
                                           where s.Zgrada!.ID == idZgrade
                                           select s;

            foreach (Stan s in sviStanovi)
            {
                stanovi.Add(new StanPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanove u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanovi;
    }

    #endregion Stan

    #endregion Prostor

    #region Lift

    public static Result<List<LiftPregled>, ErrorMessage> VratiSveLiftove()
    {
        ISession? session = null;

        List<LiftPregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                               select l;

            foreach (Lift l in sviLiftovi)
            {
                if(String.Compare(l.Tip, "Teretni", true) == 0)
                {
                    liftovi.Add(new LiftTeretniPregled((LiftTeretni)l));
                }
                else
                {
                    liftovi.Add(new LiftZaLjudePregled((LiftZaLjude)l));
                }
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve liftove.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    public static Result<List<LiftPregled>, ErrorMessage> VratiSveLiftoveUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<LiftPregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                           where l.Zgrada!.ID == idZgrade
                                           select l;

            foreach (Lift l in sviLiftovi)
            {
                if (String.Compare(l.Tip, "Teretni", true) == 0)
                {
                    liftovi.Add(new LiftTeretniPregled((LiftTeretni)l));
                }
                else
                {
                    liftovi.Add(new LiftZaLjudePregled((LiftZaLjude)l));
                }
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve liftove u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    public static async Task<Result<LiftPregled, ErrorMessage>> VratiLift(int serijskiBrojLifta)
    {
        ISession? session = null;

        LiftPregled lift = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Lift l = await session.GetAsync<Lift>(serijskiBrojLifta);

            if(l == null)
            {
                return "Ne postoji lift sa datim serijskim brojem.".ToError(404);
            }

            if (String.Compare(l.Tip, "Teretni", true) == 0)
            {
                lift = new LiftTeretniPregled((LiftTeretni)l);
            }
            else
            {
                lift = new LiftZaLjudePregled((LiftZaLjude)l);
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve liftove.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return lift;
    }

    public static async Task<Result<int, ErrorMessage>> DodajLift(LiftPregled noviLift)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Lift l;

            if(String.Compare(noviLift.Tip, "Teretni", true) == 0)
            {
                l = new LiftTeretni()
                {
                    DatPoslKvara = noviLift.DatPoslKvara,
                    DatPoslServisa = noviLift.DatPoslServisa,
                    Nosivost = ((LiftTeretniPregled)noviLift).Nosivost,
                    Proizvodjac = noviLift.Proizvodjac,
                    Tip = noviLift.Tip,
                    UkVanUpotrebe = noviLift.UkVanUpotrebe,
                    Zgrada = await session.LoadAsync<Zgrada>(noviLift.Zgrada!.ID)
                };
            }
            else
            {
                l = new LiftZaLjude()
                {
                    DatPoslKvara = noviLift.DatPoslKvara,
                    DatPoslServisa = noviLift.DatPoslServisa,
                    KapLjudi = ((LiftZaLjudePregled)noviLift).KapLjudi,
                    Proizvodjac = noviLift.Proizvodjac,
                    Tip = noviLift.Tip,
                    UkVanUpotrebe = noviLift.UkVanUpotrebe,
                    Zgrada = await session.LoadAsync<Zgrada>(noviLift.Zgrada!.ID)
                };
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(l.Zgrada!.ID);
            if(zgrada == null)
            {
                return "Nemoguće dodati novi lift, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if(zgrada.Liftovi == null)
            {
                zgrada.Liftovi = new List<Lift>();
            }
            zgrada.Liftovi.Add(l);

            id = (int)await session.SaveAsync(zgrada);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novi lift.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajLift(LiftPregled lift)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Lift l = await session.GetAsync<Lift>(lift.SerijskiBroj);

            if(l == null)
            {
                return "Ne postoji lift sa datim serijskim brojem".ToError(404);
            }

            if (String.Compare(lift.Tip, "Teretni", true) == 0)
            {
                l.DatPoslKvara = lift.DatPoslKvara;
                l.DatPoslServisa = lift.DatPoslServisa;
                ((LiftTeretni)l).Nosivost = ((LiftTeretniPregled)lift).Nosivost;
                l.Proizvodjac = lift.Proizvodjac;
                l.Tip = lift.Tip;
                l.UkVanUpotrebe = lift.UkVanUpotrebe;
                l.Zgrada = await session.LoadAsync<Zgrada>(lift.Zgrada!.ID);
            }
            else
            {
                l.DatPoslKvara = lift.DatPoslKvara;
                l.DatPoslServisa = lift.DatPoslServisa;
                ((LiftZaLjude)l).KapLjudi = ((LiftZaLjudePregled)lift).KapLjudi;
                l.Proizvodjac = lift.Proizvodjac;
                l.Tip = lift.Tip;
                l.UkVanUpotrebe = lift.UkVanUpotrebe;
                l.Zgrada = await session.LoadAsync<Zgrada>(lift.Zgrada!.ID);
            }

            await session.SaveOrUpdateAsync(l);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati lift.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiLift(int serijskiBrojLifta)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Lift l = await session.GetAsync<Lift>(serijskiBrojLifta);

            if (l == null)
            {
                return "Ne postoji lift sa datim serijskim brojem".ToError(404);
            }

            Zgrada zgrada = await session.GetAsync<Zgrada>(l.Zgrada!.ID);
            if (zgrada == null)
            {
                return "Nemoguće brisanje lifta, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if(zgrada.Liftovi != null)
            {
                zgrada.Liftovi.Remove(l);
            }

            await session.SaveOrUpdateAsync(zgrada);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje lifta.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #region LiftTeretni

    public static Result<List<LiftTeretniPregled>, ErrorMessage> VratiSveTeretneLiftove()
    {
        ISession? session = null;

        List<LiftTeretniPregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                           where String.Compare(l.Tip, "Teretni", true) == 0
                                           select l;

            foreach (Lift l in sviLiftovi)
            {
                liftovi.Add(new LiftTeretniPregled((LiftTeretni)l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve teretne liftove.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    public static Result<List<LiftTeretniPregled>, ErrorMessage> VratiSveTeretneLiftoveUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<LiftTeretniPregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                           where String.Compare(l.Tip, "Teretni", true) == 0 && l.Zgrada!.ID == idZgrade
                                           select l;

            foreach (Lift l in sviLiftovi)
            {
                liftovi.Add(new LiftTeretniPregled((LiftTeretni)l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve teretne liftove u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    #endregion LiftTeretni

    #region LiftZaLjude

    public static Result<List<LiftZaLjudePregled>, ErrorMessage> VratiSveLiftoveZaLjude()
    {
        ISession? session = null;

        List<LiftZaLjudePregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                           where String.Compare(l.Tip, "Za Ljude", true) == 0
                                           select l;

            foreach (Lift l in sviLiftovi)
            {
                liftovi.Add(new LiftZaLjudePregled((LiftZaLjude)l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve liftove za ljude.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    public static Result<List<LiftZaLjudePregled>, ErrorMessage> VratiSveLiftoveZaLjudeUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<LiftZaLjudePregled> liftovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Lift> sviLiftovi = from l in session.Query<Lift>()
                                           where String.Compare(l.Tip, "Za ljude", true) == 0 && l.Zgrada!.ID == idZgrade
                                           select l;

            foreach (Lift l in sviLiftovi)
            {
                liftovi.Add(new LiftZaLjudePregled((LiftZaLjude)l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve liftove za ljude u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return liftovi;
    }

    #endregion LiftZaLjude

    #endregion Lift

    #region ImeStanara

    public static Result<List<ImeStanaraPregled>, ErrorMessage> VratiSveStanare()
    {
        ISession? session = null;

        List<ImeStanaraPregled> stanari = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<ImeStanara> sviStanari = from i in session.Query<ImeStanara>()
                                                 select i;

            foreach (ImeStanara stanar in sviStanari)
            {
                stanari.Add(new ImeStanaraPregled(stanar));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanare.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanari;
    }

    public static Result<List<ImeStanaraPregled>, ErrorMessage> VratiSveStanareUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<ImeStanaraPregled> stanari = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<ImeStanara> sviStanari = from i in session.Query<ImeStanara>()
                                                 where i.Zgrada!.ID == idZgrade
                                                 select i;

            foreach (ImeStanara stanar in sviStanari)
            {
                stanari.Add(new ImeStanaraPregled(stanar));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanare u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanari;
    }

    public static Result<List<ImeStanaraPregled>, ErrorMessage> VratiSveStanareStana(int idStana)
    {
        ISession? session = null;

        List<ImeStanaraPregled> stanari = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<ImeStanara> sviStanari = from i in session.Query<ImeStanara>()
                                                 where i.Stan!.ID == idStana
                                                 select i;

            foreach (ImeStanara stanar in sviStanari)
            {
                stanari.Add(new ImeStanaraPregled(stanar));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanare stana.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanari;
    }

    public static async Task<Result<ImeStanaraPregled, ErrorMessage>> VratiStanara(int idStanara)
    {
        ISession? session = null;

        ImeStanaraPregled stanar = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            ImeStanara pom = await session.GetAsync<ImeStanara>(idStanara);

            if(pom == null)
            {
                return "Ne postoji stanar sa datim ID-em.".ToError(404);
            }

            stanar = new ImeStanaraPregled(pom);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return stanar;
    }

    public static async Task<Result<int, ErrorMessage>> DodajStanara(ImeStanaraPregled stanar)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            ImeStanara s = new ImeStanara()
            {
                Ime = stanar.Ime,
                Stan = await session.LoadAsync<Stan>(stanar.Stan!.ID),
                Sprat = await session.LoadAsync<Sprat>(stanar.Stan!.Sprat!.ID),
                Zgrada = await session.LoadAsync<Zgrada>(stanar.Stan!.Zgrada!.ID),
            };

            id = (int)await session.SaveAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novog stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajStanara(ImeStanaraPregled stanar)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            ImeStanara s = await session.GetAsync<ImeStanara>(stanar.ID);

            if (s == null)
            {
                return "Ne postoji stanar sa datim ID-em.".ToError(404);
            }

            s.Ime = stanar.Ime;
            s.Stan = await session.LoadAsync<Stan>(stanar.Stan!.ID);
            s.Sprat = await session.LoadAsync<Sprat>(stanar.Stan!.Sprat!.ID);
            s.Zgrada = await session.LoadAsync<Zgrada>(stanar.Stan!.Zgrada!.ID);

            await session.SaveOrUpdateAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažuriranje stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiStanara(int idStanara)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            ImeStanara s = await session.LoadAsync<ImeStanara>(idStanara);

            await session.DeleteAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novog stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion ImeStanara

    #region Licenca

    public static Result<List<LicencaPregled>, ErrorMessage> VratiSveLicence()
    {
        ISession? session = null;

        List<LicencaPregled> licence = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Licenca> sveLicence = from l in session.Query<Licenca>()
                                              select l;

            foreach(Licenca l in sveLicence)
            {
                licence.Add(new LicencaPregled(l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje svih licenci.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return licence;
    }

    public static Result<List<LicencaPregled>, ErrorMessage> VratiSveLicenceUpravnika(string jmbgUpravnika)
    {
        ISession? session = null;

        List<LicencaPregled> licence = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Licenca> sveLicence = from l in session.Query<Licenca>()
                                              where String.Compare(l.Upravnik!.JMBG, jmbgUpravnika, true) == 0
                                              select l;

            foreach (Licenca l in sveLicence)
            {
                licence.Add(new LicencaPregled(l));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje svih licenci upravnika.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return licence;
    }

    public static async Task<Result<LicencaPregled, ErrorMessage>> VratiLicencu(int idLicence)
    {
        ISession? session = null;

        LicencaPregled licenca = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Licenca l = await session.GetAsync<Licenca>(idLicence);

            if(l == null)
            {
                return "Ne postoji licenca sa datim ID-em".ToError(404);
            }

            licenca = new LicencaPregled(l);
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje licence.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return licenca;
    }

    public static async Task<Result<int, ErrorMessage>> DodajLicencu(LicencaPregled licenca)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Licenca l = new Licenca()
            {
                BrLicence = licenca.BrLicence,
                DatumSticanja = licenca.DatumSticanja,
                Izdavac = licenca.Izdavac,
                Upravnik = await session.LoadAsync<Zaposleni>(licenca.Upravnik!.JMBG)
            };

            id = (int)await session.SaveAsync(l);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodavanje nove licence.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajLicencu(LicencaPregled licenca)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Licenca l = await session.GetAsync<Licenca>(licenca.ID);

            if(l == null)
            {
                return "Ne postoji licenca sa datim ID-em".ToError(404);
            }

            l.BrLicence = licenca.BrLicence;
            l.DatumSticanja = licenca.DatumSticanja;
            l.Izdavac = licenca.Izdavac;
            l.Upravnik = await session.LoadAsync<Zaposleni>(licenca.Upravnik!.JMBG);

            await session.SaveOrUpdateAsync(l);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažuriranje licence.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiLicencu(int idlicence)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Licenca l = await session.GetAsync<Licenca>(idlicence);

            if(l == null)
            {
                return "Ne postoji licenca sa datim ID-em".ToError(404);
            }

            await session.DeleteAsync(l);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje licence.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Licenca

    #region Obrazovanje

    public static Result<List<ObrazovanjePregled>, ErrorMessage> VratiSvaObrazovanja()
    {
        ISession? session = null;

        List<ObrazovanjePregled> obrazovanja = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Obrazovanje> svaObrazovanja = from o in session.Query<Obrazovanje>()
                                                      select o;

            foreach (Obrazovanje o in svaObrazovanja)
            {
                obrazovanja.Add(new ObrazovanjePregled(o));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje svih obrazovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return obrazovanja;
    }

    public static Result<List<ObrazovanjePregled>, ErrorMessage> VratiSvaObrazovanjaUpravnika(string jmbgUpravnika)
    {
        ISession? session = null;

        List<ObrazovanjePregled> obrazovanja = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Obrazovanje> svaObrazovanja = from o in session.Query<Obrazovanje>()
                                                      where String.Compare(o.Upravnik!.JMBG, jmbgUpravnika, true) == 0
                                                      select o;

            foreach (Obrazovanje o in svaObrazovanja)
            {
                obrazovanja.Add(new ObrazovanjePregled(o));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje svih obrazovanja upravnika.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return obrazovanja;
    }

    public static async Task<Result<ObrazovanjePregled, ErrorMessage>> VratiObrazovanje(int idObrazovanja)
    {
        ISession? session = null;

        ObrazovanjePregled obrazovanje = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Obrazovanje o = await session.GetAsync<Obrazovanje>(idObrazovanja);

            if (o == null)
            {
                return "Ne postoji obrazovanje sa datim ID-em".ToError(404);
            }

            obrazovanje = new ObrazovanjePregled(o);
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje obrazovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return obrazovanje;
    }

    public static async Task<Result<int, ErrorMessage>> DodajObrazovanje(ObrazovanjePregled obrazovanje)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zaposleni upravnik = await session.GetAsync<Zaposleni>(obrazovanje.Upravnik!.JMBG);

            if(upravnik == null)
            {
                return "Nemoguće dodavanje novog obrazovanja, ne postoji upravnik sa datim ID-em.".ToError(404);
            }

            Obrazovanje o = new Obrazovanje()
            {
                Upravnik = upravnik,
                DatumSticanja = obrazovanje.DatumSticanja,
                NazivInstitucije = obrazovanje.NazivInstitucije,
                Zvanje = obrazovanje.Zvanje
            };

            if(upravnik.Obrazovanja == null)
            {
                upravnik.Obrazovanja = new List<Obrazovanje>();
            }
            upravnik.Obrazovanja.Add(o);

            id = (int)await session.SaveAsync(upravnik);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodavanje novog obrazovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajObrazovanje(ObrazovanjePregled obrazovanje)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Obrazovanje o = await session.GetAsync<Obrazovanje>(obrazovanje.ID);

            if (o == null)
            {
                return "Ne postoji obrazovanje sa datim ID-em".ToError(404);
            }

            o.DatumSticanja = obrazovanje.DatumSticanja;
            o.NazivInstitucije = obrazovanje.NazivInstitucije;
            o.Zvanje = obrazovanje.Zvanje;
            o.Upravnik = await session.LoadAsync<Zaposleni>(obrazovanje.Upravnik!.JMBG);

            await session.SaveOrUpdateAsync(o);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažuriranje obrazovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiObrazovanje(int idObrazovanja)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Obrazovanje o = await session.GetAsync<Obrazovanje>(idObrazovanja);

            if (o == null)
            {
                return "Ne postoji obrazovanje sa datim ID-em".ToError(404);
            }

            await session.DeleteAsync(o);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje obrazovanja.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Obrazovanje

    #region SkupstinaStanara

    public static Result<List<SkupstinaStanaraPregled>, ErrorMessage> VratiSveClanoveSkupstineStanara()
    {
        ISession? session = null;

        List<SkupstinaStanaraPregled> skupstina = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<SkupstinaStanara> pom = from s in session.Query<SkupstinaStanara>()
                                                select s;

            foreach (SkupstinaStanara s in pom)
            {
                skupstina.Add(new SkupstinaStanaraPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve članove skupštine stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return skupstina;
    }

    public static Result<List<SkupstinaStanaraPregled>, ErrorMessage> VratiSveClanoveSkupstineStanaraUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<SkupstinaStanaraPregled> skupstina = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<SkupstinaStanara> pom = from s in session.Query<SkupstinaStanara>()
                                                where s.Zgrada!.ID == idZgrade
                                                select s;

            foreach (SkupstinaStanara s in pom)
            {
                skupstina.Add(new SkupstinaStanaraPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve članove skupštine stanara u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return skupstina;
    }

    public static async Task<Result<SkupstinaStanaraPregled, ErrorMessage>> VratiClanaSkupstine(int id)
    {
        ISession? session = null;

        SkupstinaStanaraPregled clan = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            SkupstinaStanara s = await session.GetAsync<SkupstinaStanara>(id);

            if(s == null)
            {
                return "Ne postoji član skupštine stanara sa datim ID-em".ToError(404);
            }

            clan = new SkupstinaStanaraPregled(s);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti člana skupštine stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return clan;
    }

    public static async Task<Result<int, ErrorMessage>> DodajClanaSkupstineStanara(SkupstinaStanaraPregled clan)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(clan.Zgrada!.ID);

            if(z == null)
            {
                return "Nemoguće dodati novog člana skupštine stanara, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            SkupstinaStanara s = new SkupstinaStanara()
            {
                Vlasnik = await session.LoadAsync<Vlasnik>(clan.Vlasnik!.JMBG),
                Zgrada = z,
                Funkcija = clan.Funkcija
            };

            if(z.VlasniciStanova == null)
            {
                z.VlasniciStanova = new List<SkupstinaStanara>();
            }
            z.VlasniciStanova.Add(s);

            id = (int)await session.SaveAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novog člana skupštine stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool,ErrorMessage>> AzurirajClanaSkupstineStanara(SkupstinaStanaraPregled clan)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            SkupstinaStanara s = await session.GetAsync<SkupstinaStanara>(clan.ID);

            if (s == null)
            {
                return "Ne postoji član skupštine stanara sa datim ID-em.".ToError(404);
            }

            s.Vlasnik = await session.LoadAsync<Vlasnik>(clan.Vlasnik!.JMBG);
            s.Zgrada = await session.LoadAsync<Zgrada>(clan.Zgrada!.ID);
            s.Funkcija = clan.Funkcija;

            await session.SaveOrUpdateAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažuriranje člana skupštine stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiClanaSkupstineStanara(int id)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            SkupstinaStanara s = await session.GetAsync<SkupstinaStanara>(id);

            if(s == null)
            {
                return "Ne postoji član skupštine stanara sa datim ID-em.".ToError(404);
            }

            Zgrada z = await session.GetAsync<Zgrada>(s.Zgrada!.ID);

            if (z == null)
            {
                return "Nemoguće brisanje člana skupštine stanara, ne postoji zgrada sa datim ID-em.".ToError(400);
            }

            z.VlasniciStanova!.Remove(s);

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje člana skupštine stanara.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion SkupstinaStanara

    #region Sprat

    public static Result<List<SpratPregled>, ErrorMessage> VratiSveSpratove()
    {
        ISession? session = null;

        List<SpratPregled> spratovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Sprat> sviSpratovi = from s in session.Query<Sprat>()
                                             select s;

            foreach (Sprat s in sviSpratovi)
            {
                spratovi.Add(new SpratPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve spratove.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return spratovi;
    }

    public static Result<List<SpratPregled>, ErrorMessage> VratiSveSpratoveUZgradi(int idZgrade)
    {
        ISession? session = null;

        List<SpratPregled> spratovi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Sprat> sviSpratovi = from s in session.Query<Sprat>()
                                             where s.Zgrada!.ID == idZgrade
                                             select s;

            foreach (Sprat s in sviSpratovi)
            {
                spratovi.Add(new SpratPregled(s));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve spratove u zgradi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return spratovi;
    }

    public static async Task<Result<SpratPregled, ErrorMessage>> VratiSprat(int idSprata)
    {
        ISession? session = null;

        SpratPregled sprat = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Sprat s = await session.GetAsync<Sprat>(idSprata);

            if (s == null)
            {
                return "Ne postoji sprat sa datim ID-em.".ToError(404);
            }

            sprat = new SpratPregled(s);
        }
        catch (Exception)
        {
            return "Nemoguće vraćanje sprata.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return sprat;
    }

    public static async Task<Result<int, ErrorMessage>> DodajSprat(SpratPregled novi)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(novi.Zgrada!.ID);

            if(z == null)
            {
                return "Nemoguće dodati novi sprat, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            Sprat s = new Sprat()
            {
                Prostori = new List<Prostor>(),
                RBroj = novi.RBroj,
                Zgrada = z
            };

            if(novi.Prostori != null)
            {
                foreach(ProstorPregled p in novi.Prostori)
                {
                    Prostor pr;

                    if(String.Compare(p.Tip, "Lokal", true) == 0)
                    {
                        pr = new Lokal()
                        {
                            ImeFirme = ((LokalPregled)p).ImeFirme
                        };
                    }
                    else if(String.Compare(p.Tip, "Parking", true) == 0)
                    {
                        pr = new Parking()
                        {
                            RegVozila = ((ParkingPregled)p).RegVozila
                        };
                    }
                    else
                    {
                        pr = new Stan()
                        {
                            Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)p).Vlasnik!.JMBG),
                            Stanari = new List<ImeStanara>()
                        };

                        if(((StanPregled)p).Stanari != null)
                        {
                            foreach (ImeStanaraPregled stanar in ((StanPregled)p).Stanari!)
                            {
                                Stan pom = await session.LoadAsync<Stan>(stanar.Stan!.ID);

                                ((Stan)pr).Stanari!.Add(new ImeStanara()
                                {
                                    Ime = stanar.Ime,
                                    Sprat = pom.Sprat,
                                    Stan = pom,
                                    Zgrada = pom.Zgrada
                                });
                            }
                        }
                    }

                    pr.Tip = p.Tip;
                    pr.RBroj = p.RBroj;
                    pr.Zgrada = await session.LoadAsync<Zgrada>(p.Zgrada!.ID);
                    pr.Sprat = await session.LoadAsync<Sprat>(p.Sprat!.ID);

                    s.Prostori.Add(pr);
                }
            }

            if(z.Spratovi == null)
            {
                z.Spratovi = new List<Sprat>();
            }
            z.Spratovi.Add(s);

            id = (int)await session.SaveAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novi sprat.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajSprat(SpratPregled sprat)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(sprat.Zgrada!.ID);

            if (z == null)
            {
                return "Nemoguće ažurirati sprat, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            Sprat s = await session.GetAsync<Sprat>(sprat.ID);

            if(s == null)
            {
                return "Ne postoji sprat sa datim ID-em".ToError(404);
            }

            s.RBroj = sprat.RBroj;
            s.Zgrada = z;
            if(s.Prostori == null)
            {
                s.Prostori = new List<Prostor>();
            }
            else
            {
                s.Prostori.Clear();
            }

            if (sprat.Prostori != null)
            {
                foreach (ProstorPregled p in sprat.Prostori)
                {
                    Prostor pr;

                    if (String.Compare(p.Tip, "Lokal", true) == 0)
                    {
                        pr = new Lokal()
                        {
                            ImeFirme = ((LokalPregled)p).ImeFirme
                        };
                    }
                    else if (String.Compare(p.Tip, "Parking", true) == 0)
                    {
                        pr = new Parking()
                        {
                            RegVozila = ((ParkingPregled)p).RegVozila
                        };
                    }
                    else
                    {
                        pr = new Stan()
                        {
                            Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)p).Vlasnik!.JMBG),
                            Stanari = new List<ImeStanara>()
                        };

                        if (((StanPregled)p).Stanari != null)
                        {
                            foreach (ImeStanaraPregled stanar in ((StanPregled)p).Stanari!)
                            {
                                Stan pom = await session.LoadAsync<Stan>(stanar.Stan!.ID);

                                ((Stan)pr).Stanari!.Add(new ImeStanara()
                                {
                                    Ime = stanar.Ime,
                                    Sprat = s,
                                    Stan = pom,
                                    Zgrada = z
                                });
                            }
                        }
                    }

                    pr.Tip = p.Tip;
                    pr.RBroj = p.RBroj;
                    pr.Zgrada = z;
                    pr.Sprat = s;

                    s.Prostori.Add(pr);
                }
            }

            await session.SaveOrUpdateAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati sprat.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiSprat(int idSprata)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Sprat s = await session.GetAsync<Sprat>(idSprata);

            if (s == null)
            {
                return "Ne postoji sprat sa datim serijskim brojem".ToError(404);
            }

            await session.DeleteAsync(s);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće brisanje sprata.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Sprat

    #region Telefon

    public static Result<List<TelefonPregled>, ErrorMessage> VratiSveTelefoneOsobe(string jmbgOsobe)
    {
        ISession? session = null;

        List<TelefonPregled> brojevi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Telefon> sviBrojevi = from t in session.Query<Telefon>()
                                              where String.Compare(t.Osoba!.JMBG, jmbgOsobe, true) == 0
                                              select t;
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve brojeve telefona osobe.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return brojevi;
    }

    public static async Task<Result<TelefonPregled, ErrorMessage>> VratiTelefonOsobe(int idTelefona)
    {
        ISession? session = null;

        TelefonPregled broj = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Telefon t = await session.GetAsync<Telefon>(idTelefona);

            if(t == null)
            {
                return "Ne postoji telefon sa datim ID-em".ToError(404);
            }

            broj = new TelefonPregled(t);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti broj telefona osobe.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return broj;
    }

    public static async Task<Result<int, ErrorMessage>> DodajTelefonOsobi(TelefonPregled novi)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Osoba o = await session.GetAsync<Osoba>(novi.Osoba!.JMBG);

            if(o == null)
            {
                return "Nmoguće dodati novi broj telefona osobi, ne postoji osoba sa datim JMBG-om".ToError(404);
            }

            Telefon t = new Telefon()
            {
                Osoba = o,
                BrojTelefona = novi.BrojTelefona
            };

            if(o.BrojeviTelefona == null)
            {
                o.BrojeviTelefona = new List<Telefon>();
            }
            o.BrojeviTelefona.Add(t);

            id = (int)await session.SaveAsync(o);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novi broj telefona osobi.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajTelefonOsobe(TelefonPregled tel)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Telefon t = await session.GetAsync<Telefon>(tel.ID);

            if(t == null)
            {
                return "Ne postoji broj telefona sa datim ID-em".ToError(404);
            }

            t.BrojTelefona = tel.BrojTelefona;
            t.Osoba = await session.LoadAsync<Osoba>(tel.Osoba!.JMBG);

            await session.SaveOrUpdateAsync(t);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati telefon osobe.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiTelefonOsobe(int idTelefona)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Telefon t = await session.GetAsync<Telefon>(idTelefona);

            if(t == null)
            {
                return "Ne postoji telefon sa datim ID-em".ToError(404);
            }

            Osoba o = await session.GetAsync<Osoba>(t.Osoba!.JMBG);

            if(o == null)
            {
                return "Nemoguće obrisati broj telefona, ne postoji osoba sa datim JMBG-om.".ToError(404);
            }

            if(o.BrojeviTelefona != null)
            {
                o.BrojeviTelefona.Remove(t);
            }

            await session.SaveOrUpdateAsync(o);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati broj telefona.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Telefon

    #region Ugovor

    public static Result<List<UgovorPregled>, ErrorMessage> VratiSveUgovore()
    {
        ISession? session = null;

        List<UgovorPregled> ugovori = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Ugovor> sviUgovori = from u in session.Query<Ugovor>()
                                             select u;

            foreach (Ugovor u in sviUgovori)
            {
                ugovori.Add(new UgovorPregled(u));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve ugovore.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return ugovori;
    }
    public static Result<List<UgovorPregled>, ErrorMessage> VratiSveUgovoreZgrade(int idZgrade)
    {
        ISession? session = null;

        List<UgovorPregled> ugovori = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Ugovor> sviUgovori = from u in session.Query<Ugovor>()
                                             where u.Zgrada!.ID == idZgrade
                                             select u;

            foreach (Ugovor u in sviUgovori)
            {
                ugovori.Add(new UgovorPregled(u));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve ugovore zgrade.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return ugovori;
    }

    public static async Task<Result<UgovorPregled, ErrorMessage>> VratiUgovor(int sifraUgovora)
    {
        ISession? session = null;

        UgovorPregled ugovor = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ugovor u = await session.GetAsync<Ugovor>(sifraUgovora);

            if (u == null)
            {
                return "Ne postoji ugovor sa datim ID-em".ToError(404);
            }

            ugovor = new UgovorPregled(u);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti ugovor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return ugovor;
    }

    public static async Task<Result<int, ErrorMessage>> DodajUgovor(UgovorPregled novi)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(novi.Zgrada!.ID);

            if (z == null)
            {
                return "Nmoguće dodati novi ugovor, ne postoji zgrada sa datim ID-em".ToError(404);
            }

            Ugovor u = new Ugovor()
            {
                Zgrada = z,
                DatumPotpisa = novi.DatumPotpisivanja,
                PeriodVazenja = novi.PeriodVazenja,
                Sifra = novi.Sifra
            };

            if(z.Ugovori == null)
            {
                z.Ugovori = new List<Ugovor>();
            }
            z.Ugovori.Add(u);

            id = (int)await session.SaveAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novi ugovor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajUgovor(UgovorPregled ugovor)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ugovor u = await session.GetAsync<Ugovor>(ugovor.Sifra);

            if (u == null)
            {
                return "Ne postoji ugovor sa datom šifrom.".ToError(404);
            }

            u.Sifra = ugovor.Sifra;
            u.PeriodVazenja = ugovor.PeriodVazenja;
            u.DatumPotpisa = ugovor.DatumPotpisivanja;
            u.Zgrada = await session.LoadAsync<Zgrada>(ugovor.Zgrada!.ID);

            await session.SaveOrUpdateAsync(u);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati ugovor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiUgovor(int sifraUgovora)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ugovor u = await session.GetAsync<Ugovor>(sifraUgovora);

            if (u == null)
            {
                return "Ne postoji ugovor sa datom šifrom".ToError(404);
            }

            Zgrada z = await session.GetAsync<Zgrada>(u.Zgrada!.ID);

            if (z == null)
            {
                return "Nemoguće obrisati ugovor, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if (z.Ugovori != null)
            {
                z.Ugovori.Remove(u);
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati ugovor.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Ugovor

    #region Ulaz
    public static Result<List<UlazPregled>, ErrorMessage> VratiSveUlazeZgrade(int idZgrade)
    {
        ISession? session = null;

        List<UlazPregled> ulazi = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Ulaz> sviUlazi = from u in session.Query<Ulaz>()
                                             where u.Zgrada!.ID == idZgrade
                                             select u;

            foreach (Ulaz u in sviUlazi)
            {
                ulazi.Add(new UlazPregled(u));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve ulaze zgrade.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return ulazi;
    }

    public static async Task<Result<UlazPregled, ErrorMessage>> VratiUlaz(int idUlaza)
    {
        ISession? session = null;

        UlazPregled ulaz = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ulaz u = await session.GetAsync<Ulaz>(idUlaza);

            if (u == null)
            {
                return "Ne postoji ulaz sa datim ID-em".ToError(404);
            }

            ulaz = new UlazPregled(u);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti ulaz.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return ulaz;
    }

    public static async Task<Result<int, ErrorMessage>> DodajUlaz(UlazPregled novi)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(novi.Zgrada!.ID);

            if (z == null)
            {
                return "Nmoguće dodati novi ulaz, ne postoji zgrada sa datim ID-em".ToError(404);
            }

            Ulaz u = new Ulaz()
            {
                Zgrada = z,
                Kamera = novi.Kamera,
                KrajRadnogVremena = novi.KrajRadnogVremena,
                PocetakRadnogVremena = novi.PocetakRadnogVremena,
                RBroj = novi.RBroj
            };

            if (z.Ulazi == null)
            {
                z.Ulazi = new List<Ulaz>();
            }
            z.Ulazi.Add(u);

            id = (int)await session.SaveAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novi ulaz.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajUlaz(UlazPregled ulaz)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ulaz u = await session.GetAsync<Ulaz>(ulaz.ID);

            if (u == null)
            {
                return "Ne postoji ulaz sa datom šifrom.".ToError(404);
            }

            u.RBroj = ulaz.RBroj;
            u.Kamera = ulaz.Kamera;
            u.PocetakRadnogVremena = ulaz.PocetakRadnogVremena;
            u.KrajRadnogVremena = ulaz.KrajRadnogVremena;
            u.Zgrada = await session.LoadAsync<Zgrada>(ulaz.Zgrada!.ID);

            await session.SaveOrUpdateAsync(u);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati ulaz.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiUlaz(int idUlaza)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Ulaz u = await session.GetAsync<Ulaz>(idUlaza);

            if (u == null)
            {
                return "Ne postoji ulaz sa datom šifrom".ToError(404);
            }

            Zgrada z = await session.GetAsync<Zgrada>(u.Zgrada!.ID);

            if (z == null)
            {
                return "Nemoguće obrisati ulaz, ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            if (z.Ulazi != null)
            {
                z.Ulazi.Remove(u);
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati ulaz.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Ulaz

    #region Zgrada

    public static Result<List<ZgradaPregled>, ErrorMessage> VratiSveZgrade()
    {
        ISession? session = null;

        List<ZgradaPregled> zgrade = new();

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            IEnumerable<Zgrada> sveZgrade = from z in session.Query<Zgrada>()
                                             select z;

            foreach (Zgrada z in sveZgrade)
            {
                zgrade.Add(new ZgradaPregled(z));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve zgrade.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zgrade;
    }

    public static async Task<Result<ZgradaPregled, ErrorMessage>> VratiZgradu(int idZgrade)
    {
        ISession? session = null;

        ZgradaPregled zgrada = default!;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(idZgrade);

            if (z == null)
            {
                return "Ne postoji zgrada sa datim ID-em".ToError(404);
            }

            zgrada = new ZgradaPregled(z);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti zgradu.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zgrada;
    }

    public static async Task<Result<int, ErrorMessage>> DodajZgradu(ZgradaPregled nova)
    {
        ISession? session = null;

        int id = default;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = new Zgrada()
            {
                Adresa = nova.Adresa,
                Liftovi = new List<Lift>(),
                Upravnici = new List<Zaposleni>(),
                Prostori = new List<Prostor>(),
                Spratovi = new List<Sprat>(),
                Ugovori = new List<Ugovor>(),
                Ulazi = new List<Ulaz>(),
                VlasniciStanova = new List<SkupstinaStanara>()
            };

            if(nova.Liftovi != null)
            {
                foreach (LiftPregled l in nova.Liftovi)
                {
                    Lift pom;
                    if (String.Compare(l.Tip, "Teretni", true) == 0)
                    {
                        pom = new LiftTeretni()
                        {
                            Nosivost = ((LiftTeretniPregled)l).Nosivost
                        };
                    }
                    else
                    {
                        pom = new LiftZaLjude()
                        {
                            KapLjudi = ((LiftZaLjudePregled)l).KapLjudi
                        };
                    }

                    pom.Proizvodjac = l.Proizvodjac;
                    pom.DatPoslKvara = l.DatPoslKvara;
                    pom.DatPoslServisa = l.DatPoslServisa;
                    pom.UkVanUpotrebe = l.UkVanUpotrebe;
                    pom.Zgrada = z;
                    pom.Tip = l.Tip;

                    z.Liftovi.Add(pom);
                }
            }
            if (nova.Upravnici != null)
            {
                foreach (ZaposleniPregled upravnik in nova.Upravnici)
                {
                    z.Upravnici.Add(new Zaposleni()
                    {
                        JMBG = upravnik.JMBG
                    });
                }
            }
            if (nova.Prostori != null)
            {
                foreach (ProstorPregled p in nova.Prostori)
                {
                    Prostor pom;

                    if(String.Compare(p.Tip, "Lokal", true) == 0)
                    {
                        pom = new Lokal()
                        {
                            Tip = p.Tip,
                            ImeFirme = ((LokalPregled)p).ImeFirme
                        };
                    }
                    else if(String.Compare(p.Tip, "Parking", true) == 0)
                    {
                        pom = new Parking()
                        {
                            Tip = p.Tip,
                            RegVozila = ((ParkingPregled)p).RegVozila
                        };
                    }
                    else
                    {
                        pom = new Stan()
                        {
                            Tip = p.Tip,
                            Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)p).Vlasnik!.JMBG)
                        };
                    }

                    z.Prostori.Add(pom);
                }
            }
            if (nova.Spratovi != null)
            {
                foreach (SpratPregled s in nova.Spratovi)
                {
                    z.Spratovi.Add(new Sprat()
                    {
                        RBroj = s.RBroj,
                        Zgrada = z
                    });
                }
            }
            if (nova.Ugovori != null)
            {
                foreach (UgovorPregled u in nova.Ugovori)
                {
                    z.Ugovori.Add(new Ugovor()
                    {
                        Zgrada = z,
                        DatumPotpisa = u.DatumPotpisivanja,
                        PeriodVazenja = u.PeriodVazenja
                    });
                }
            }
            if (nova.Ulazi != null)
            {
                foreach(UlazPregled u in nova.Ulazi)
                {
                    z.Ulazi.Add(new Ulaz()
                    {
                        Kamera = u.Kamera,
                        KrajRadnogVremena = u.KrajRadnogVremena,
                        PocetakRadnogVremena = u.PocetakRadnogVremena,
                        RBroj = u.RBroj,
                        Zgrada = z
                    });
                }
            }
            if (nova.VlasniciStanova != null)
            {
                foreach(SkupstinaStanaraPregled s in nova.VlasniciStanova)
                {
                    z.VlasniciStanova.Add(new SkupstinaStanara()
                    {
                        Zgrada = z,
                        Vlasnik = await session.LoadAsync<Vlasnik>(s.Vlasnik!.JMBG),
                        Funkcija = s.Funkcija
                    });
                }
            }

            id = (int)await session.SaveAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati novu zgradu.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return id;
    }

    public static async Task<Result<bool, ErrorMessage>> AzurirajZgradu(ZgradaPregled zgrada)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(zgrada.ID);

            if(z == null)
            {
                return "Ne postoji zgrada sa datim ID-em".ToError(404);
            }

            z.Adresa = zgrada.Adresa;

            if (z.Liftovi == null)
            {
                z.Liftovi = new List<Lift>();
            }
            else
            {
                z.Liftovi.Clear();
            }

            if (z.Upravnici == null)
            {
                z.Upravnici = new List<Zaposleni>();
            }
            else
            {
                z.Upravnici.Clear();
            }

            if (z.Prostori == null)
            {
                z.Prostori = new List<Prostor>();
            }
            else
            {
                z.Prostori.Clear();
            }

            if (z.Spratovi == null)
            {
                z.Spratovi = new List<Sprat>();
            }
            else
            {
                z.Spratovi.Clear();
            }

            if (z.Ugovori == null)
            {
                z.Ugovori = new List<Ugovor>();
            }
            else
            {
                z.Ugovori.Clear();
            }

            if (z.Ulazi == null)
            {
                z.Ulazi = new List<Ulaz>();
            }
            else
            {
                z.Ulazi.Clear();
            }

            if (z.VlasniciStanova == null)
            {
                z.VlasniciStanova = new List<SkupstinaStanara>();
            }
            else
            {
                z.VlasniciStanova.Clear();
            }

            if (zgrada.Liftovi != null)
            {
                foreach (LiftPregled l in zgrada.Liftovi)
                {
                    Lift pom;
                    if (String.Compare(l.Tip, "Teretni", true) == 0)
                    {
                        pom = new LiftTeretni()
                        {
                            Nosivost = ((LiftTeretniPregled)l).Nosivost
                        };
                    }
                    else
                    {
                        pom = new LiftZaLjude()
                        {
                            KapLjudi = ((LiftZaLjudePregled)l).KapLjudi
                        };
                    }

                    pom.Proizvodjac = l.Proizvodjac;
                    pom.DatPoslKvara = l.DatPoslKvara;
                    pom.DatPoslServisa = l.DatPoslServisa;
                    pom.UkVanUpotrebe = l.UkVanUpotrebe;
                    pom.Zgrada = z;
                    pom.Tip = l.Tip;

                    z.Liftovi.Add(pom);
                }
            }
            if (zgrada.Upravnici != null)
            {
                foreach (ZaposleniPregled upravnik in zgrada.Upravnici)
                {
                    z.Upravnici.Add(new Zaposleni()
                    {
                        JMBG = upravnik.JMBG
                    });
                }
            }
            if (zgrada.Prostori != null)
            {
                foreach (ProstorPregled p in zgrada.Prostori)
                {
                    Prostor pom;

                    if (String.Compare(p.Tip, "Lokal", true) == 0)
                    {
                        pom = new Lokal()
                        {
                            Tip = p.Tip,
                            ImeFirme = ((LokalPregled)p).ImeFirme
                        };
                    }
                    else if (String.Compare(p.Tip, "Parking", true) == 0)
                    {
                        pom = new Parking()
                        {
                            Tip = p.Tip,
                            RegVozila = ((ParkingPregled)p).RegVozila
                        };
                    }
                    else
                    {
                        pom = new Stan()
                        {
                            Tip = p.Tip,
                            Vlasnik = await session.LoadAsync<Vlasnik>(((StanPregled)p).Vlasnik!.JMBG)
                        };
                    }

                    z.Prostori.Add(pom);
                }
            }
            if (zgrada.Spratovi != null)
            {
                foreach (SpratPregled s in zgrada.Spratovi)
                {
                    z.Spratovi.Add(new Sprat()
                    {
                        RBroj = s.RBroj,
                        Zgrada = z
                    });
                }
            }
            if (zgrada.Ugovori != null)
            {
                foreach (UgovorPregled u in zgrada.Ugovori)
                {
                    z.Ugovori.Add(new Ugovor()
                    {
                        Zgrada = z,
                        DatumPotpisa = u.DatumPotpisivanja,
                        PeriodVazenja = u.PeriodVazenja
                    });
                }
            }
            if (zgrada.Ulazi != null)
            {
                foreach (UlazPregled u in zgrada.Ulazi)
                {
                    z.Ulazi.Add(new Ulaz()
                    {
                        Kamera = u.Kamera,
                        KrajRadnogVremena = u.KrajRadnogVremena,
                        PocetakRadnogVremena = u.PocetakRadnogVremena,
                        RBroj = u.RBroj,
                        Zgrada = z
                    });
                }
            }
            if (zgrada.VlasniciStanova != null)
            {
                foreach (SkupstinaStanaraPregled s in zgrada.VlasniciStanova)
                {
                    z.VlasniciStanova.Add(new SkupstinaStanara()
                    {
                        Zgrada = z,
                        Vlasnik = await session.LoadAsync<Vlasnik>(s.Vlasnik!.JMBG),
                        Funkcija = s.Funkcija
                    });
                }
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati zgradu.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiZgradu(int idZgrade)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (!(session?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju".ToError(403);
            }

            Zgrada z = await session.GetAsync<Zgrada>(idZgrade);

            if (z == null)
            {
                return "Ne postoji zgrada sa datim ID-em.".ToError(404);
            }

            await session.DeleteAsync(z);
            await session.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati zgradu.".ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return true;
    }

    #endregion Zgrada
}