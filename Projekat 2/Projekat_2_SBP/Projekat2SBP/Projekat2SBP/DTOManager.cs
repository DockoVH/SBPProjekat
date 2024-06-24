using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using NHibernate.Util;
using Projekat2SBP.Entiteti;
using Projekat2SBP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP;

public class DTOManager
{
    #region ImeStanar
    public static void obrisiStanara(int idStanara)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            ImeStanara stanar = s.Load<ImeStanara>(idStanara);

            s.Delete(stanar);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja stanara:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajStanara(StanPregled stan, string imeStanara)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Stan stanPom = s.Load<Stan>(stan.ID);

            stanPom.Stanari.Add(new ImeStanara()
            {
                Stan = stanPom,
                Sprat = stanPom.Sprat,
                Zgrada = stanPom.Zgrada,
                Ime = imeStanara
            });

            s.Save(stanPom);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja stanara:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ImeStanaraBasic> sviStanari(StanBasic stan)
    {
        ISession s = DataLayer.GetSession();
        List<ImeStanaraBasic> stanari = new List<ImeStanaraBasic>();

        try
        {
            Stan pom = s.Load<Stan>(stan.ID);

            foreach (var stanar in pom.Stanari)
            {
                stanari.Add(new ImeStanaraBasic()
                {
                    Ime = stanar.Ime,
                    Stan = stan
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih stanara:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }

        return stanari;
    }
    #endregion ImeStanara

    #region Licenca
    public static void obrisiLicencu(int brojLicence)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Licenca lic = s.Load<Licenca>(brojLicence);

            s.Delete(lic);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja licence:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajLicencu(LicencaBasic licenca)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Licenca l = new Licenca()
            {
                BrLicence = licenca.BrLicence,
                Izdavac = licenca.Izdavac,
                DatumSticanja = licenca.DatumSticanja,
                Upravnik = s.Load<Zaposleni>(licenca.Upravnik.JMBG)
            };

            s.Save(l);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja licence:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static List<LicencaBasic> sveLicence(string JMBGUpravnika)
    {
        ISession s = DataLayer.GetSession();
        List<LicencaBasic> licence = new List<LicencaBasic>();

        try
        {

            IEnumerable<Licenca> licencePom = from li in s.Query<Licenca>()
                                                 where li.Upravnik.JMBG == JMBGUpravnika
                                                 select li;

            foreach (Licenca li in licencePom)
            {
                licence.Add(new LicencaBasic()
                {
                    Upravnik = new ZaposleniBasic()
                    {
                        JMBG = JMBGUpravnika
                    },
                    BrLicence = li.BrLicence,
                    Izdavac = li.Izdavac,
                    DatumSticanja = li.DatumSticanja
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih licenci:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }

        return licence;
    }
    #endregion Licenca

    #region Lift
    public static List<LiftPregled> sviLiftoviUZgradi(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();
        List<LiftPregled> liftovi = new();

        try
        {
            IEnumerable<Lift> liftoviPom = from lift in s.Query<Lift>()
                                           where lift.IDZgrade == IDZgrade
                                           select lift;

            foreach (var lift in liftoviPom)
            {
                if(lift.Tip == "Teretni")
                {
                    liftovi.Add(new LiftTeretniPregled()
                    {
                        SerijskiBroj = lift.SerijskiBroj,
                        DatPoslServisa = lift.DatPoslServisa,
                        DatPoslKvara = lift.DatPoslKvara,
                        Proizvodjac = lift.Proizvodjac,
                        Tip = lift.Tip,
                        UkVanUpotrebe = lift.UkVanUpotrebe,
                        Nosivost = ((LiftTeretni)lift).Nosivost,
                        Zgrada = new ZgradaPregled()
                        {
                            ID = IDZgrade
                        }
                    });
                }
                else
                {
                    liftovi.Add(new LiftZaLjudePregled()
                    {
                        SerijskiBroj = lift.SerijskiBroj,
                        DatPoslServisa = lift.DatPoslServisa,
                        DatPoslKvara = lift.DatPoslKvara,
                        Proizvodjac = lift.Proizvodjac,
                        Tip = lift.Tip,
                        UkVanUpotrebe = lift.UkVanUpotrebe,
                        KapLjudi = ((LiftZaLjude)lift).KapLjudi,
                        Zgrada = new ZgradaPregled()
                        {
                            ID = IDZgrade
                        }
                    });
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih liftova u zgradi:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
        return liftovi;
    }
    public static void obrisiLift(int SerijskiBrojLifta)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Lift lift = s.Load<Lift>(SerijskiBrojLifta);

            s.Delete(lift);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja lifta:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }
    public static void dodajLift(LiftBasic lift, LiftTip tipLifta)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Lift novi;
            switch (tipLifta)
            {
                case LiftTip.Teretni:
                    novi = new LiftTeretni();
                    ((LiftTeretni)novi).Nosivost = ((LiftTeretniBasic)lift).Nosivost;
                    break;
                case LiftTip.ZaLjude:
                    novi = new LiftZaLjude();
                    ((LiftZaLjude)novi).KapLjudi = ((LiftZaLjudeBasic)lift).KapLjudi;
                    break;
                default:
                    novi = null;
                    break;
            }

            novi.DatPoslServisa = lift.DatPoslServisa;
            novi.DatPoslKvara = lift.DatPoslKvara;
            novi.Proizvodjac = lift.Proizvodjac;
            novi.Tip = lift.Tip;
            novi.UkVanUpotrebe = lift.UkVanUpotrebe;
            novi.Zgrada = s.Load<Zgrada>(lift.Zgrada.ID);

            s.Save(novi);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja lifta:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static LiftBasic vratiLift(int SerijskiBroj)
    {
        ISession s = DataLayer.GetSession();
        LiftBasic lift = null;

        try
        {
            Lift l = s.Load<Lift>(SerijskiBroj);

            if(l.Tip == "Teretni")
            {
                lift = new LiftTeretniBasic()
                {
                    Nosivost = ((LiftTeretni)l).Nosivost
                };
            }
            else
            {
                lift = new LiftZaLjudeBasic()
                {
                    KapLjudi = ((LiftZaLjude)l).KapLjudi
                };
            }

            lift.DatPoslServisa = l.DatPoslServisa;
            lift.DatPoslKvara = l.DatPoslKvara;
            lift.Proizvodjac = l.Proizvodjac;
            lift.Tip = l.Tip;
            lift.UkVanUpotrebe = l.UkVanUpotrebe;
            lift.Zgrada = new ZgradaBasic()
            {
                ID = l.Zgrada.ID
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja lifta:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
        return lift;
    }
    #endregion Lift

    #region Prostor
    public static List<ProstorPregled> sviProstoriUZgradi(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();
        List<ProstorPregled> prostori = new();

        try
        {
            IEnumerable<Prostor> prostoriPom = from prostor in s.Query<Prostor>()
                                               where prostor.Zgrada.ID == IDZgrade
                                               select prostor;

            foreach(var prostor in prostoriPom)
            {
                ProstorPregled pr;

                if(String.Compare(prostor.Tip, "stan",true) == 0)
                {
                    pr = new StanPregled()
                    {
                        Tip = prostor.Tip,
                        Vlasnik = new VlasnikPregled()
                        {
                            JMBG = ((Stan)prostor).Vlasnik.JMBG
                        }
                    };
                }
                else if(String.Compare(prostor.Tip, "lokal", true) == 0)
                {
                    pr = new LokalPregled()
                    {
                        Tip = prostor.Tip,
                        ImeFirme = ((Lokal)prostor).ImeFirme
                    };
                }
                else
                {
                    pr = new ParkingPregled()
                    {
                        Tip = prostor.Tip,
                        RegVozila = ((Parking)prostor).RegVozila
                    };
                }


                pr.RBroj = prostor.RBroj;
                pr.Sprat = new SpratPregled()
                {
                    RBroj = prostor.Sprat.RBroj,
                    Zgrada = new ZgradaPregled()
                    {
                        ID = IDZgrade
                    }
                };
                pr.Zgrada = new ZgradaPregled()
                {
                    ID = IDZgrade
                };

                prostori.Add(pr);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih prostora u zgradi:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }

        return prostori;
    }

    public static ProstorBasic vratiProstor(int IDProstora)
    {
        ISession s = DataLayer.GetSession();
        ProstorBasic prostor;

        try
        {
            Prostor p = s.Load<Prostor>(IDProstora);

            if(String.Compare(p.Tip, "stan", true) == 0)
            {
                prostor = new StanBasic()
                {
                    Tip = p.Tip,
                    Vlasnik = new()
                    {
                        JMBG = ((Stan)p).Vlasnik.JMBG
                    }
                };
            }
            else if(String.Compare(p.Tip, "lokal", true) == 0)
            {
                prostor = new LokalBasic()
                {
                    Tip = p.Tip,
                    ImeFirme = ((Lokal)p).ImeFirme
                };
            }
            else
            {
                prostor = new ParkingBasic()
                {
                    Tip = p.Tip,
                    RegVozila = ((Parking)p).RegVozila
                };
            }

            prostor.RBroj = p.RBroj;
            prostor.Sprat = new SpratBasic()
            {
                ID = p.Sprat.ID,
                RBroj = p.Sprat.RBroj,
                Zgrada = new ZgradaBasic()
                {
                    ID = p.Zgrada.ID
                }
            };
            prostor.Zgrada = new ZgradaBasic()
            {
                ID = p.Zgrada.ID
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja prostora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }

        return null;
    }
    public static void obrisiProstor(ProstorPregled prostor)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Prostor p = s.Load<Prostor>(prostor.ID);

            s.Delete(p);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja prostora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajProstor(ProstorBasic prostor, ProstorTip tipProstora)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Prostor p;
            
            if(tipProstora == ProstorTip.Stan)
            {
                p = new Stan()
                {
                    Vlasnik = s.Load<Vlasnik>(((StanBasic)prostor).Vlasnik.JMBG)
                };
            }
            else if(tipProstora == ProstorTip.Lokal)
            {
                p = new Lokal()
                {
                    ImeFirme = ((LokalBasic)prostor).ImeFirme
                };
            }
            else
            {
                p = new Parking()
                {
                    RegVozila = ((ParkingBasic)prostor).RegVozila
                };
            }

            p.RBroj = prostor.RBroj;
            p.Sprat = s.Load<Sprat>(prostor.Sprat.ID);
            p.Zgrada = s.Load<Zgrada>(prostor.Zgrada.ID);
            p.Tip = prostor.Tip;

            s.Save(p);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja novog prostora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void izmeniProstor(ProstorBasic prostor, ProstorTip tipProstora)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Prostor p = s.Load<Prostor>(prostor.ID);

            p.RBroj = prostor.RBroj;
            p.Zgrada = s.Load<Zgrada>(prostor.Zgrada.ID);
            p.Sprat = s.Load<Sprat>(prostor.Sprat.ID);

            if(tipProstora == ProstorTip.Stan)
            {
                ((Stan)p).Vlasnik = s.Load<Vlasnik>(((StanBasic)prostor).Vlasnik.JMBG);
                ((Stan)p).Stanari.Clear();

                foreach(var stanar in ((StanBasic)prostor).Stanari)
                {
                    ((Stan)p).Stanari.Add(s.Load<ImeStanara>(stanar.ID));
                }
            }
            else if(tipProstora == ProstorTip.Lokal)
            {
                ((Lokal)p).ImeFirme = ((LokalBasic)prostor).ImeFirme;
            }
            else
            {
                ((Parking)p).RegVozila = ((ParkingBasic)prostor).RegVozila;
            }

            s.SaveOrUpdate(p);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom izmene prostora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Prostor

    #region Obrazovanje
    public static void obrisiObrazovanje(int idObrazovanja)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Obrazovanje o = s.Load<Obrazovanje>(idObrazovanja);
            Zaposleni upravnik = s.Load<Zaposleni>(o.Upravnik.JMBG);

            if(o != null)
            {
                upravnik.Obrazovanja.Remove(o);
            }

            s.Update(upravnik);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja obrazovanja:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajObrazovanje(ObrazovanjePregled obrazovanje)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zaposleni upravnik = s.Load<Zaposleni>(obrazovanje.Upravnik.JMBG);

            Obrazovanje o = new Obrazovanje()
            {
                NazivInstitucije = obrazovanje.NazivInstitucije,
                Zvanje = obrazovanje.Zvanje,
                DatumSticanja = obrazovanje.DatumSticanja,
                Upravnik = upravnik
            };

            upravnik.Obrazovanja.Add(o);

            s.Update(upravnik);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja obrazovanja:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ObrazovanjePregled> svaObrazovanja(string JMBGUpravnika)
    {
        ISession s = DataLayer.GetSession();
        List<ObrazovanjePregled> obrazovanja = new List<ObrazovanjePregled>();

        try
        {
            Zaposleni upravnik = s.Load<Zaposleni>(JMBGUpravnika);

            foreach (Obrazovanje o in upravnik.Obrazovanja)
            {
                obrazovanja.Add(new ObrazovanjePregled()
                {
                    Upravnik = new ZaposleniPregled()
                    {
                        JMBG = o.Upravnik.JMBG
                    },
                    Zvanje = o.Zvanje,
                    DatumSticanja = o.DatumSticanja,
                    NazivInstitucije = o.NazivInstitucije
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih obrazovanja:\n{ex.FormatExceptionMessage()}");
        }
        finally
        {
            s.Close();
        }

        return obrazovanja;
    }
    #endregion Obrazovanje
    #region Osoba
    #region Vlasnik
    public static VlasnikBasic vratiVlasnika(string JMBGVlasnika)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Vlasnik v = s.Load<Vlasnik>(JMBGVlasnika);

            VlasnikBasic vlasnik = new VlasnikBasic()
            {
                JMBG = JMBGVlasnika,
                Adresa = v.Adresa,
                LIme = v.LIme,
                ImeRoditelja = v.ImeRoditelja,
                Prezime = v.Prezime,
                Tip = v.Tip
            };

            foreach (var telefon in v.BrojeviTelefona)
            {
                vlasnik.BrojeviTelefona.Add(new TelefonBasic()
                {
                    Osoba = vlasnik,
                    BrojTelefona = telefon.BrojTelefona
                });
            }

            return vlasnik;
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja vlasnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            s.Close();
        }
    }

    public static void izmeniVlasnika(VlasnikBasic vlasnik)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Vlasnik v = s.Load<Vlasnik>(vlasnik.JMBG);

            v.Adresa = vlasnik.Adresa;
            v.LIme = vlasnik.LIme;
            v.ImeRoditelja = vlasnik.ImeRoditelja;
            v.Prezime = vlasnik.Prezime;
            
            v.BrojeviTelefona.Clear();

            foreach(var broj in vlasnik.BrojeviTelefona)
            {
                v.BrojeviTelefona.Add(new Telefon()
                {
                    Osoba = v,
                    BrojTelefona = broj.BrojTelefona
                });
            }

            s.SaveOrUpdate(v);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom izmene vlasnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<SkupstinaStanaraPregled> sviVlasniciPregled(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<SkupstinaStanara> celaSkupstina = from skupstina in s.Query<SkupstinaStanara>()
                                                          where skupstina.Zgrada.ID == IDZgrade
                                                          select skupstina;

            List<SkupstinaStanaraPregled> sviVlasnici = new();

            foreach(var vlasnik in celaSkupstina)
            {
                VlasnikBasic v = new VlasnikBasic()
                {
                    JMBG = vlasnik.Vlasnik.JMBG,
                    Adresa = vlasnik.Vlasnik.Adresa,
                    LIme = vlasnik.Vlasnik.LIme,
                    ImeRoditelja = vlasnik.Vlasnik.ImeRoditelja,
                    Prezime = vlasnik.Vlasnik.Prezime,
                    Tip = vlasnik.Vlasnik.Tip
                };

                foreach(var tel in vlasnik.Vlasnik.BrojeviTelefona)
                {
                    v.BrojeviTelefona.Add(new TelefonBasic()
                    {
                        Osoba = v,
                        BrojTelefona = tel.BrojTelefona
                    });
                }

                sviVlasnici.Add(new SkupstinaStanaraPregled()
                {
                    Funkcija = vlasnik.Funkcija,
                    Vlasnik = new VlasnikPregled()
                    {
                        JMBG = v.JMBG
                    },
                    Zgrada = new ZgradaPregled()
                    {
                        ID = IDZgrade
                    }
                });
            }

            return sviVlasnici;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja pregleda svih vlasnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<SkupstinaStanaraPregled>();
        }
        finally
        {
            s.Close();
        }
    }
    public static List<SkupstinaStanaraBasic> sviVlasnici(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<SkupstinaStanara> skupstina = from v in s.Query<SkupstinaStanara>()
                                                      where v.Zgrada.ID == IDZgrade
                                                      select v;

            List<SkupstinaStanaraBasic> vlasnici = new();

            foreach (var sk in skupstina)
            {
                VlasnikBasic v = new VlasnikBasic()
                {
                    JMBG = sk.Vlasnik.JMBG,
                    Adresa = sk.Vlasnik.Adresa,
                    LIme = sk.Vlasnik.LIme,
                    ImeRoditelja = sk.Vlasnik.ImeRoditelja,
                    Prezime = sk.Vlasnik.Prezime,
                    Tip = sk.Vlasnik.Tip
                };

                foreach (var tel in sk.Vlasnik.BrojeviTelefona)
                {
                    v.BrojeviTelefona.Add(new TelefonBasic()
                    {
                        Osoba = v,
                        BrojTelefona = tel.BrojTelefona
                    });
                }

                vlasnici.Add(new SkupstinaStanaraBasic()
                {
                    Funkcija = sk.Funkcija,
                    Vlasnik = v,
                    Zgrada = new ZgradaBasic()
                    {
                        ID = IDZgrade
                    }
                });
            }

            return vlasnici;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih vlasnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<SkupstinaStanaraBasic>();    
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Vlasik
    #region Zaposleni
    public static ZaposleniBasic vratiZaposlenog(string JMBGZaposlenog)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zaposleni z = s.Load<Zaposleni>(JMBGZaposlenog);

            ZaposleniBasic zaposleni = new()
            {
                JMBG = z.JMBG,
                Adresa = z.Adresa,
                LIme = z.LIme,
                ImeRoditelja = z.ImeRoditelja,
                Prezime = z.Prezime,
                Tip = z.Tip,
                BrLicneKarte = z.BrLicneKarte,
                DatumRodjenja = z.DatumRodjenja,
                MestoIzdLK = z.MestoIzdLK,
                TipPosla = z.TipPosla
            };

            foreach(var broj in z.BrojeviTelefona)
            {
                zaposleni.BrojeviTelefona.Add(new TelefonBasic()
                {
                    Osoba = zaposleni,
                    BrojTelefona = broj.BrojTelefona
                });
            }
            foreach (var obrazovanje in z.Obrazovanja)
            {
                zaposleni.Obrazovanja.Add(new ObrazovanjeBasic()
                {
                    Upravnik = zaposleni,
                    NazivInstitucije = obrazovanje.NazivInstitucije,
                    DatumSticanja = obrazovanje.DatumSticanja,
                    Zvanje = obrazovanje.Zvanje
                });
            }
            foreach (var licenca in z.Licence)
            {
                zaposleni.Licence.Add(new LicencaBasic()
                {
                    Upravnik = zaposleni,
                    BrLicence = licenca.BrLicence,
                    DatumSticanja = licenca.DatumSticanja,
                    Izdavac = licenca.Izdavac
                });
            }
            foreach (var zgrada in z.UpravljaZgradama)
            {
                zaposleni.UpravljaZgradama.Add(new ZgradaBasic()
                {
                    ID = zgrada.ID
                });
            }

            return zaposleni;
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja zaposlenog:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new ZaposleniBasic();
        }
        finally
        {
            s.Close();
        }
    }

    public static void obrisiZaposlenog(string JMBGZaposlenog)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zaposleni z = s.Load<Zaposleni>(JMBGZaposlenog);

            s.Delete(z);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja zaposlenog:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajZaposlenog(ZaposleniBasic zaposleni)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zaposleni z = new Zaposleni()
            {
                JMBG = zaposleni.JMBG,
                Adresa = zaposleni.Adresa,
                LIme = zaposleni.LIme,
                ImeRoditelja = zaposleni.ImeRoditelja,
                Prezime = zaposleni.Prezime,
                Tip =  zaposleni.Tip,
                DatumRodjenja = zaposleni.DatumRodjenja,
                BrLicneKarte = zaposleni.BrLicneKarte,
                MestoIzdLK = zaposleni.MestoIzdLK,
                TipPosla = zaposleni.TipPosla
            };

            foreach (var broj in zaposleni.BrojeviTelefona)
            {
                z.BrojeviTelefona.Add(new Telefon()
                {
                    Osoba = z,
                    BrojTelefona = broj.BrojTelefona
                });
            }
            foreach (var obrazovanje in zaposleni.Obrazovanja)
            {
                z.Obrazovanja.Add(new Obrazovanje()
                {
                    Upravnik = z,
                    NazivInstitucije = obrazovanje.NazivInstitucije,
                    DatumSticanja = obrazovanje.DatumSticanja,
                    Zvanje = obrazovanje.Zvanje
                });
            }
            foreach (var licenca in zaposleni.Licence)
            {
                z.Licence.Add(new Licenca()
                {
                    Upravnik = z,
                    BrLicence = licenca.BrLicence,
                    DatumSticanja = licenca.DatumSticanja,
                    Izdavac = licenca.Izdavac
                });
            }
            foreach (var zgrada in zaposleni.UpravljaZgradama)
            {
                zaposleni.UpravljaZgradama.Add(new ZgradaBasic()
                {
                    ID = zgrada.ID
                });
            }

            s.Save(z);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja zaposlenog:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void izmeniZaposlenog(ZaposleniBasic zaposleni)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zaposleni z = s.Load<Zaposleni>(zaposleni.JMBG);

            z.JMBG = zaposleni.JMBG;
            z.Adresa = zaposleni.Adresa;
            z.LIme = zaposleni.LIme;
            z.ImeRoditelja = zaposleni.ImeRoditelja;
            z.Prezime = zaposleni.Prezime;
            z.Tip = zaposleni.Tip;
            z.DatumRodjenja = zaposleni.DatumRodjenja;
            z.BrLicneKarte = zaposleni.BrLicneKarte;
            z.MestoIzdLK = zaposleni.MestoIzdLK;
            z.TipPosla = zaposleni.TipPosla;

            foreach (var broj in zaposleni.BrojeviTelefona)
            {
                z.BrojeviTelefona.Add(new Telefon()
                {
                    Osoba = z,
                    BrojTelefona = broj.BrojTelefona
                });
            }
            foreach (var obrazovanje in zaposleni.Obrazovanja)
            {
                z.Obrazovanja.Add(new Obrazovanje()
                {
                    Upravnik = z,
                    NazivInstitucije = obrazovanje.NazivInstitucije,
                    DatumSticanja = obrazovanje.DatumSticanja,
                    Zvanje = obrazovanje.Zvanje
                });
            }
            foreach (var licenca in zaposleni.Licence)
            {
                z.Licence.Add(new Licenca()
                {
                    Upravnik = z,
                    BrLicence = licenca.BrLicence,
                    DatumSticanja = licenca.DatumSticanja,
                    Izdavac = licenca.Izdavac
                });
            }
            foreach (var zgrada in zaposleni.UpravljaZgradama)
            {
                zaposleni.UpravljaZgradama.Add(new ZgradaBasic()
                {
                    ID = zgrada.ID
                });
            }

            s.SaveOrUpdate(z);
            s.Flush();
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom izmene zaposlenog:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ZaposleniPregled> sviZaposleni()
    {
        ISession s = DataLayer.GetSession();

        try
        {
            List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();

            IEnumerable<Zaposleni> zaposleniPom = from z in s.Query<Zaposleni>()
                                                  select z;

            foreach (var z in zaposleniPom)
            {
                ZaposleniPregled pom = new()
                {
                    JMBG = z.JMBG,
                    Adresa = z.Adresa,
                    PunoIme = $"{z.LIme} ({z.ImeRoditelja}) {z.Prezime}",
                    DatumRodjenja = z.DatumRodjenja,
                    BrLicneKarte = z.BrLicneKarte,
                    MestoIzdLK = z.MestoIzdLK,
                    TipPosla = z.TipPosla
                };
                foreach (var broj in sviTelefoni(z.JMBG))
                {
                    pom.BrojeviTelefona.Add(new TelefonPregled()
                    {
                        Osoba = pom,
                        BrojTelefona = broj.BrojTelefona
                    });
                }
                foreach (var obrazovanje in svaObrazovanja(z.JMBG))
                {
                    pom.Obrazovanja.Add(new ObrazovanjePregled()
                    {
                        Upravnik = pom,
                        NazivInstitucije = obrazovanje.NazivInstitucije,
                        DatumSticanja = obrazovanje.DatumSticanja,
                        Zvanje = obrazovanje.Zvanje
                    });
                }
                foreach (var licenca in sveLicence(z.JMBG))
                {
                    pom.Licence.Add(new LicencaPregled()
                    {
                        Upravnik = pom,
                        BrLicence = licenca.BrLicence,
                        DatumSticanja = licenca.DatumSticanja,
                        Izdavac = licenca.Izdavac
                    });
                }
                foreach (var zgrada in sveZgradeUpravnika(z.JMBG))
                {
                    pom.Zgrade.Add(new ZgradaPregled()
                    {
                        ID = zgrada.ID
                    });
                }

                zaposleni.Add(pom);
            }

            return zaposleni;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih zaposlenih:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<ZaposleniPregled>();
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Zaposleni
    #region Upravnik
    public static List<ZaposleniBasic> sviUpravniciZgrade(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<Angazovanje> angazovanja = from a in s.Query<Angazovanje>()
                                                   where a.Zgrada.ID == IDZgrade
                                                   select a;

            List<ZaposleniBasic> upravnici = new();

            foreach(var a in angazovanja)
            {
                ZaposleniBasic pom = new()
                {
                    JMBG = a.Upravnik.JMBG,
                    Adresa = a.Upravnik.Adresa,
                    LIme = a.Upravnik.LIme,
                    ImeRoditelja = a.Upravnik.ImeRoditelja,
                    Prezime = a.Upravnik.Prezime,
                    DatumRodjenja = a.Upravnik.DatumRodjenja,
                    BrLicneKarte = a.Upravnik.BrLicneKarte,
                    MestoIzdLK = a.Upravnik.MestoIzdLK,
                    TipPosla = a.Upravnik.TipPosla
                };

                foreach (var broj in a.Upravnik.BrojeviTelefona)
                {
                    pom.BrojeviTelefona.Add(new TelefonBasic()
                    {
                        Osoba = pom,
                        BrojTelefona = broj.BrojTelefona
                    });
                }
                foreach (var obrazovanje in a.Upravnik.Obrazovanja)
                {
                    pom.Obrazovanja.Add(new ObrazovanjeBasic()
                    {
                        Upravnik = pom,
                        NazivInstitucije = obrazovanje.NazivInstitucije,
                        DatumSticanja = obrazovanje.DatumSticanja,
                        Zvanje = obrazovanje.Zvanje
                    });
                }
                foreach (var licenca in a.Upravnik.Licence)
                {
                    pom.Licence.Add(new LicencaBasic()
                    {
                        Upravnik = pom,
                        BrLicence = licenca.BrLicence,
                        DatumSticanja = licenca.DatumSticanja,
                        Izdavac = licenca.Izdavac
                    });
                }
                foreach (var zgrada in a.Upravnik.UpravljaZgradama)
                {
                    pom.UpravljaZgradama.Add(new ZgradaBasic()
                    {
                        ID = zgrada.ID
                    });
                }

                upravnici.Add(pom);
            }

            return upravnici;
        }
        catch(Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih upravnika zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<ZaposleniBasic>();
        }
        finally
        {
            s.Close();
        }
    }
    
    public static List<ZaposleniPregled> sviUpravniciZgradePregled(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<Angazovanje> angazovanja = from a in s.Query<Angazovanje>()
                                                   where a.Zgrada.ID == IDZgrade
                                                   select a;

            List<ZaposleniPregled> upravnici = new();

            foreach (var a in angazovanja)
            {
                ZaposleniPregled pom = new()
                {
                    JMBG = a.Upravnik.JMBG,
                    Adresa = a.Upravnik.Adresa,
                    PunoIme = $"{a.Upravnik.LIme} ({a.Upravnik.ImeRoditelja}) {a.Upravnik.Prezime}",
                    DatumRodjenja = a.Upravnik.DatumRodjenja,
                    BrLicneKarte = a.Upravnik.BrLicneKarte,
                    MestoIzdLK = a.Upravnik.MestoIzdLK,
                    TipPosla = a.Upravnik.TipPosla
                };

                foreach (var broj in a.Upravnik.BrojeviTelefona)
                {
                    pom.BrojeviTelefona.Add(new TelefonPregled()
                    {
                        Osoba = pom,
                        BrojTelefona = broj.BrojTelefona
                    });
                }
                foreach (var obrazovanje in a.Upravnik.Obrazovanja)
                {
                    pom.Obrazovanja.Add(new ObrazovanjePregled()
                    {
                        Upravnik = pom,
                        NazivInstitucije = obrazovanje.NazivInstitucije,
                        DatumSticanja = obrazovanje.DatumSticanja,
                        Zvanje = obrazovanje.Zvanje
                    });
                }
                foreach (var licenca in a.Upravnik.Licence)
                {
                    pom.Licence.Add(new LicencaPregled()
                    {
                        Upravnik = pom,
                        BrLicence = licenca.BrLicence,
                        DatumSticanja = licenca.DatumSticanja,
                        Izdavac = licenca.Izdavac
                    });
                }
                foreach (var zgrada in a.Upravnik.UpravljaZgradama)
                {
                    pom.Zgrade.Add(new ZgradaPregled()
                    {
                        ID = zgrada.ID
                    });
                }

                upravnici.Add(pom);
            }

            return upravnici;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja pregleda svih upravnika zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<ZaposleniPregled>();
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ZaposleniPregled> sviUpravniciPregled()
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<Angazovanje> angazovanja = from a in s.Query<Angazovanje>()
                                                   select a;

            List<ZaposleniPregled> upravnici = new();

            foreach (var a in angazovanja)
            {
                ZaposleniPregled pom = new()
                {
                    JMBG = a.Upravnik.JMBG,
                    Adresa = a.Upravnik.Adresa,
                    PunoIme = $"{a.Upravnik.LIme} ({a.Upravnik.ImeRoditelja}) {a.Upravnik.Prezime}",
                    DatumRodjenja = a.Upravnik.DatumRodjenja,
                    BrLicneKarte = a.Upravnik.BrLicneKarte,
                    MestoIzdLK = a.Upravnik.MestoIzdLK,
                    TipPosla = a.Upravnik.TipPosla
                };

                foreach (var broj in a.Upravnik.BrojeviTelefona)
                {
                    pom.BrojeviTelefona.Add(new TelefonPregled()
                    {
                        Osoba = pom,
                        BrojTelefona = broj.BrojTelefona
                    });
                }
                foreach (var obrazovanje in a.Upravnik.Obrazovanja)
                {
                    pom.Obrazovanja.Add(new ObrazovanjePregled()
                    {
                        Upravnik = pom,
                        NazivInstitucije = obrazovanje.NazivInstitucije,
                        DatumSticanja = obrazovanje.DatumSticanja,
                        Zvanje = obrazovanje.Zvanje
                    });
                }
                foreach (var licenca in a.Upravnik.Licence)
                {
                    pom.Licence.Add(new LicencaPregled()
                    {
                        Upravnik = pom,
                        BrLicence = licenca.BrLicence,
                        DatumSticanja = licenca.DatumSticanja,
                        Izdavac = licenca.Izdavac
                    });
                }
                foreach (var zgrada in a.Upravnik.UpravljaZgradama)
                {
                    pom.Zgrade.Add(new ZgradaPregled()
                    {
                        ID = zgrada.ID
                    });
                }

                upravnici.Add(pom);
            }

            return upravnici;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih upravnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<ZaposleniPregled>();
        }
        finally
        {
            s.Close();
        }
    }

    #endregion
    #endregion Osoba
    #region Sprat
    public static void obrisiSprat(SpratBasic sprat)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Sprat sp = new Sprat()
            {
                RBroj = sprat.RBroj,
                Zgrada = s.Load<Zgrada>(sprat.Zgrada.ID)
            };

            Sprat spr = s.Load<Sprat>(sp);

            s.Delete(spr);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja sprata:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajSprat(SpratBasic sprat)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Sprat sp = new Sprat()
            {
                RBroj = sprat.RBroj,
                Zgrada = s.Load<Zgrada>(sprat.Zgrada.ID)
            };

            s.Save(sp);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja novog sprata:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<SpratPregled> sviSpratovi(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<Sprat> spratoviPom = from sp in s.Query<Sprat>()
                                                      where sp.Zgrada.ID == IDZgrade
                                                      select sp;

            List<SpratPregled> spratovi = new List<SpratPregled>();
            
            foreach (Sprat sp in spratoviPom)
            {
                spratovi.Add(new SpratPregled()
                {
                    RBroj = sp.RBroj,
                    Zgrada = new ZgradaPregled()
                    {
                        ID = sp.Zgrada.ID
                    }
                });
            }

            return spratovi;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih spratova u zgradi:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<SpratPregled>();
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Sprat
    #region Telefon
    public static void obrisiTelefon(string JMBGOsobe, string broj)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Telefon t = new Telefon()
            {
                Osoba = s.Load<Osoba>(JMBGOsobe),
                BrojTelefona = broj
            };

            Telefon tel = s.Load<Telefon>(t);

            s.Delete(tel);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja broja telefona:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajTelefon(string JMBGOsobe, string broj)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Telefon t = new Telefon()
            {
                Osoba = s.Load<Osoba>(JMBGOsobe),
                BrojTelefona = broj
            };

            s.Save(t);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja novog broja telefona:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<TelefonPregled> sviTelefoni(string JMBGOsobe)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            List<TelefonPregled> telefoni = new List<TelefonPregled>();

            IEnumerable<Telefon> telefoniPom = from t in s.Query<Telefon>()
                                                      where t.Osoba.JMBG == JMBGOsobe
                                                      select t;

            foreach (Telefon t in telefoniPom)
            {
                telefoni.Add(new TelefonPregled()
                {
                    Osoba = new OsobaPregled()
                    {
                        JMBG = t.Osoba.JMBG
                    },
                    BrojTelefona = t.BrojTelefona
                });
            }

            return telefoni;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih telefona osobe:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<TelefonPregled>();
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Telefon
    #region Ugovor
    public static void obrisiUgovor(int SifraUgovora)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Ugovor u = s.Load<Ugovor>(SifraUgovora);

            s.Delete(u);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja ugovora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static UgovorBasic vratiUgovor(int sifraUgovora)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Ugovor u = s.Load<Ugovor>(sifraUgovora);

            UgovorBasic ugovor = new UgovorBasic()
            {
                Zgrada = new ZgradaBasic()
                { 
                    ID = u.Zgrada.ID
                },
                DatumPotpisivanja = u.DatumPotpisa,
                PeriodVazenja = u.PeriodVazenja,
                Sifra = u.Sifra
            };

            return ugovor;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja ugovora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajUgovor(UgovorBasic ugovor)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Ugovor u = new Ugovor()
            {
                Sifra = ugovor.Sifra,
                DatumPotpisa = ugovor.DatumPotpisivanja,
                PeriodVazenja = ugovor.PeriodVazenja,
                Zgrada = s.Load<Zgrada>(ugovor.Zgrada.ID)
            };

            s.Save(u);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja ugovora:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<UgovorPregled> sviUgovori(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();
        List<UgovorPregled> ugovori = new List<UgovorPregled>();

        try
        {

            IEnumerable<Ugovor> ugovoriPom = from u in s.Query<Ugovor>()
                                                      where u.Zgrada.ID == IDZgrade
                                                      select u;

            foreach (Ugovor u in ugovoriPom)
            {
                ugovori.Add(new UgovorPregled()
                {
                    Sifra = u.Sifra,
                    DatumPotpisivanja = u.DatumPotpisa,
                    PeriodVazenja = u.PeriodVazenja,
                    Zgrada = new ZgradaPregled()
                    {
                        ID = u.Zgrada.ID
                    }
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih ugovora zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }

        return ugovori;
    }
    #endregion Ugovor
    #region Ulaz
    public static UlazBasic vratiUlaz(int idUlaza)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Ulaz u = s.Load<Ulaz>(idUlaza);

            UlazBasic ulaz = new UlazBasic()
            {
                ID = u.ID,
                RBroj = u.RBroj,
                Zgrada = new ZgradaBasic()
                {
                    ID = u.Zgrada.ID
                },
                Kamera = u.Kamera,
                PocetakRadnogVremena = u.PocetakRadnogVremena,
                KrajRadnogVremena = u.KrajRadnogVremena
            };

            return ulaz;

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja ulaza:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            s.Close();
        }
    }
    public static void obrisiUlaz(int idUlaza)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Ulaz ulaz = s.Load<Ulaz>(idUlaza);
            Zgrada zgrada = s.Load<Zgrada>(ulaz.Zgrada.ID);

            zgrada.Ulazi.Remove(ulaz);

            s.Update(zgrada);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja ulaza:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static void dodajUlaz(UlazBasic ulaz)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada zgrada = s.Load<Zgrada>(ulaz.Zgrada.ID);

            Ulaz u = new Ulaz()
            {
                Zgrada = zgrada,
                Kamera = ulaz.Kamera,
                PocetakRadnogVremena = ulaz.PocetakRadnogVremena,
                KrajRadnogVremena = ulaz.KrajRadnogVremena,
                RBroj = ulaz.RBroj
            };

            zgrada.Ulazi.Add(u);

            s.Update(zgrada);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja novog ulaza:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<UlazPregled> sviUlazi(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            IEnumerable<Ulaz> ulaziPom = from ulaz in s.Query<Ulaz>()
                                         where ulaz.Zgrada.ID == IDZgrade
                                         select ulaz;


            List<UlazPregled> ulazi = new List<UlazPregled>();

            foreach (Ulaz u in ulaziPom)
            {
                ulazi.Add(new UlazPregled()
                {
                    ID = u.ID,
                    RBroj = u.RBroj,
                    Zgrada = new ZgradaPregled()
                    {
                        ID = u.Zgrada.ID
                    },
                    Kamera = u.Kamera,
                    PocetakRadnogVremena = u.PocetakRadnogVremena,
                    KrajRadnogVremena = u.KrajRadnogVremena
                });
            }

            return ulazi;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih ulaza:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<UlazPregled>();
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Ulaz
    #region Zgrada
    public static ZgradaBasic vratiZgradu(int idZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada z = s.Load<Zgrada>(idZgrade);

            ZgradaBasic zgrada = new()
            {
                ID = z.ID,
                Adresa = z.Adresa
            };

            foreach(var ulaz in z.Ulazi)
            {
                zgrada.Ulazi.Add(new UlazBasic()
                {
                    ID = ulaz.ID,
                    RBroj = ulaz.RBroj,
                    Kamera = ulaz.Kamera,
                    PocetakRadnogVremena = ulaz.PocetakRadnogVremena,
                    KrajRadnogVremena = ulaz.KrajRadnogVremena,
                    Zgrada = zgrada
                });
            }
            foreach (var upravnik in z.Upravnici)
            {
                zgrada.Upravnici.Add(new ZaposleniBasic()
                {
                    JMBG = upravnik.JMBG
                });
            }
            foreach (var lift in z.Liftovi)
            {
                LiftBasic novi = (String.Compare(lift.Tip, "Teretni", true) == 0) ? new LiftTeretniBasic() : new LiftZaLjudeBasic();
                novi.Tip = lift.Tip;

                if(String.Compare(novi.Tip, "Teretni", true) == 0)
                {
                    ((LiftTeretniBasic)novi).Nosivost = ((LiftTeretni)lift).Nosivost;
                }
                else
                {
                    ((LiftZaLjudeBasic)novi).KapLjudi = ((LiftZaLjude)lift).KapLjudi;
                }

                novi.SerijskiBroj = lift.SerijskiBroj;
                novi.DatPoslKvara = lift.DatPoslKvara;
                novi.DatPoslServisa = lift.DatPoslServisa;
                novi.Proizvodjac = lift.Proizvodjac;
                novi.UkVanUpotrebe = lift.UkVanUpotrebe;
                novi.Zgrada = new ZgradaBasic()
                {
                    ID = idZgrade
                };

                zgrada.Liftovi.Add(novi);
            }
            foreach (var sprat in z.Spratovi)
            {
                zgrada.Spratovi.Add(new SpratBasic()
                {
                    ID = sprat.ID,
                    RBroj = sprat.RBroj,
                    Zgrada = new ZgradaBasic()
                    {
                        ID = idZgrade
                    }
                });
            }
            foreach (var prostor in z.Prostori)
            {
                ProstorBasic p;
                
                if(String.Compare(prostor.Tip, "stan", true) == 0)
                {
                    p = new StanBasic()
                    {
                        Vlasnik = new VlasnikBasic()
                        {
                            JMBG = ((Stan)prostor).Vlasnik.JMBG
                        }
                    };
                }
                else if (String.Compare(prostor.Tip, "lokal", true) == 0)
                {
                    p = new LokalBasic()
                    {
                        ImeFirme = ((Lokal)prostor).ImeFirme
                    };
                }
                else
                {
                    p = new ParkingBasic()
                    {
                        RegVozila = ((Parking)prostor).RegVozila
                    };
                }

                p.ID = prostor.ID;
                p.Tip = prostor.Tip;
                p.RBroj = prostor.RBroj;
                p.Sprat = new SpratBasic()
                {
                    RBroj = prostor.Sprat.RBroj,
                    Zgrada = new ZgradaBasic()
                    {
                        ID = idZgrade
                    }
                };
                p.Zgrada = new ZgradaBasic()
                {
                    ID = idZgrade
                };

                zgrada.Prostori.Add(p);
            }
            foreach (var ugovor in z.Ugovori)
            {
                zgrada.Ugovori.Add(new UgovorBasic()
                {
                    Sifra = ugovor.Sifra,
                    DatumPotpisivanja = ugovor.DatumPotpisa,
                    PeriodVazenja = ugovor.PeriodVazenja,
                    Zgrada = new ZgradaBasic()
                    {
                        ID = idZgrade
                    }
                });
            }
            foreach (var vlasnik in z.VlasniciStanova)
            {
                VlasnikBasic v = new VlasnikBasic()
                {
                    JMBG = vlasnik.Vlasnik.JMBG,
                    Adresa = vlasnik.Vlasnik.Adresa,
                    LIme = vlasnik.Vlasnik.LIme,
                    ImeRoditelja = vlasnik.Vlasnik.ImeRoditelja,
                    Prezime = vlasnik.Vlasnik.Prezime,
                    Tip = vlasnik.Vlasnik.Tip
                };

                foreach(var broj in vlasnik.Vlasnik.BrojeviTelefona)
                {
                    v.BrojeviTelefona.Add(new TelefonBasic()
                    {
                        ID = broj.ID,
                        Osoba = v,
                        BrojTelefona = broj.BrojTelefona
                    });
                }

                zgrada.VlasniciStanova.Add(new SkupstinaStanaraBasic()
                {
                    ID = vlasnik.ID,
                    Vlasnik = v,
                    Zgrada = zgrada,
                    Funkcija = vlasnik.Funkcija
                });
            }

            return zgrada;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            s.Close();
        }
    }

    public static ZgradaPregled vratiZgraduPregled(int idZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada z = s.Load<Zgrada>(idZgrade);

            ZaposleniBasic upravnik = vratiZaposlenog(z.Upravnici.First().JMBG);

            ZgradaPregled zgrada = new()
            {
                ID = z.ID,
                Adresa = z.Adresa,
                Upravnik = new ZaposleniPregled()
                {
                    JMBG = upravnik.JMBG,
                    PunoIme = $"{upravnik.LIme} ({upravnik.ImeRoditelja}) {upravnik.Prezime}"
                },
                BrojLiftova = z.Liftovi.Count,
                BrojProstora = z.Prostori.Count,
                BrojSpratova = z.Spratovi.Count,
                BrojUgovora = z.Ugovori.Count,
                BrojUlaza = z.Ulazi.Count,
                BrojVlasnikaStanova =z.VlasniciStanova.Count
            };

            return zgrada;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja pregleda zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }

        return new ZgradaPregled();
    }

    public static void obrisiZgradu(int IDZgrade)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada z = s.Load<Zgrada>(IDZgrade);

            s.Delete(z);
            s.Flush();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom brisanja zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static int dodajZgradu(ZgradaBasic zgrada)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada z = new Zgrada()
            {
                Adresa = zgrada.Adresa
            };

            foreach (var ulaz in zgrada.Ulazi)
            {
                z.Ulazi.Add(new Ulaz()
                {
                    ID = ulaz.ID,
                    RBroj = ulaz.RBroj,
                    Kamera = ulaz.Kamera,
                    PocetakRadnogVremena = ulaz.PocetakRadnogVremena,
                    KrajRadnogVremena = ulaz.KrajRadnogVremena,
                    Zgrada = z
                });
            }
            foreach (var upravnik in zgrada.Upravnici)
            {
                z.Upravnici.Add(s.Load<Zaposleni>(upravnik.JMBG));
            }
            foreach (var lift in zgrada.Liftovi)
            {
                Lift novi = (String.Compare(lift.Tip, "Teretni", true) == 0) ? new LiftTeretni() : new LiftZaLjude();
                novi.Tip = lift.Tip;

                if (String.Compare(novi.Tip, "Teretni", true) == 0)
                {
                    ((LiftTeretni)novi).Nosivost = ((LiftTeretniBasic)lift).Nosivost;
                }
                else
                {
                    ((LiftZaLjude)novi).KapLjudi = ((LiftZaLjudeBasic)lift).KapLjudi;
                }

                novi.SerijskiBroj = lift.SerijskiBroj;
                novi.DatPoslKvara = lift.DatPoslKvara;
                novi.DatPoslServisa = lift.DatPoslServisa;
                novi.Proizvodjac = lift.Proizvodjac;
                novi.UkVanUpotrebe = lift.UkVanUpotrebe;
                novi.Zgrada = z;

                z.Liftovi.Add(novi);
            }
            foreach (var sprat in z.Spratovi)
            {
                z.Spratovi.Add(new Sprat()
                {
                    ID = sprat.ID,
                    RBroj = sprat.RBroj,
                    Zgrada = z
                });
            }
            foreach (var prostor in zgrada.Prostori)
            {
                Prostor p;

                if (String.Compare(prostor.Tip, "stan", true) == 0)
                {
                    p = new Stan()
                    {
                        Vlasnik = new Vlasnik()
                        {
                            JMBG = ((StanBasic)prostor).Vlasnik.JMBG
                        }
                    };
                }
                else if (String.Compare(prostor.Tip, "lokal", true) == 0)
                {
                    p = new Lokal()
                    {
                        ImeFirme = ((LokalBasic)prostor).ImeFirme
                    };
                }
                else
                {
                    p = new Parking()
                    {
                        RegVozila = ((ParkingBasic)prostor).RegVozila
                    };
                }

                p.ID = prostor.ID;
                p.Tip = prostor.Tip;
                p.RBroj = prostor.RBroj;
                p.Sprat = new Sprat()
                {
                    RBroj = prostor.Sprat.RBroj,
                    Zgrada = z
                };
                p.Zgrada = z;

                z.Prostori.Add(p);
            }
            foreach (var ugovor in zgrada.Ugovori)
            {
                z.Ugovori.Add(new Ugovor()
                {
                    Sifra = ugovor.Sifra,
                    DatumPotpisa = ugovor.DatumPotpisivanja,
                    PeriodVazenja = ugovor.PeriodVazenja,
                    Zgrada = z
                });
            }
            foreach (var vlasnik in zgrada.VlasniciStanova)
            {
                Vlasnik v = new Vlasnik()
                {
                    JMBG = vlasnik.Vlasnik.JMBG,
                    Adresa = vlasnik.Vlasnik.Adresa,
                    LIme = vlasnik.Vlasnik.LIme,
                    ImeRoditelja = vlasnik.Vlasnik.ImeRoditelja,
                    Prezime = vlasnik.Vlasnik.Prezime,
                    Tip = vlasnik.Vlasnik.Tip
                };

                foreach (var broj in vlasnik.Vlasnik.BrojeviTelefona)
                {
                    v.BrojeviTelefona.Add(new Telefon()
                    {
                        ID = broj.ID,
                        Osoba = v,
                        BrojTelefona = broj.BrojTelefona
                    });
                }

                z.VlasniciStanova.Add(new SkupstinaStanara()
                {
                    ID = vlasnik.ID,
                    Vlasnik = v,
                    Zgrada = z,
                    Funkcija = vlasnik.Funkcija
                });
            }

            var id = s.Save(z);
            s.Flush();

            return Int32.Parse(id.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom dodavanja nove zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ZgradaPregled> sveZgrade()
    {
        ISession s = DataLayer.GetSession();

        try
        {
            List<ZgradaPregled> zgrade = new List<ZgradaPregled>();

            IEnumerable<Zgrada> zgradePom = s.Query<Zgrada>().ToList();

            foreach (Zgrada z in zgradePom)
            {
                zgrade.Add(new ZgradaPregled()
                {
                    ID = z.ID,
                    Adresa = z.Adresa,
                    Upravnik = new ZaposleniPregled()
                    {
                        JMBG = z.Upravnici.First().JMBG
                    },
                    BrojUgovora = z.Ugovori.Count,
                    BrojLiftova = z.Liftovi.Count,
                    BrojProstora = z.Prostori.Count,
                    BrojSpratova = z.Spratovi.Count,
                    BrojUlaza = z.Ulazi.Count,
                    BrojVlasnikaStanova = z.VlasniciStanova.Count
                });
            }

            return zgrade;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom vraćanja svih zgrada:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            s.Close();
        }
    }

    public static void izmeniZgradu(ZgradaBasic zgrada)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            Zgrada z = s.Load<Zgrada>(zgrada.ID);

            foreach (var ulaz in zgrada.Ulazi)
            {
                z.Ulazi.Add(s.Load<Ulaz>(ulaz.ID));
            }
            foreach (var upravnik in zgrada.Upravnici)
            {
                z.Upravnici.Add(s.Load<Zaposleni>(upravnik.JMBG));
            }
            foreach (var lift in zgrada.Liftovi)
            {
                Lift novi = (String.Compare(lift.Tip, "Teretni", true) == 0) ? new LiftTeretni() : new LiftZaLjude();
                novi.Tip = lift.Tip;

                if (String.Compare(novi.Tip, "Teretni", true) == 0)
                {
                    ((LiftTeretni)novi).Nosivost = ((LiftTeretniBasic)lift).Nosivost;
                }
                else
                {
                    ((LiftZaLjude)novi).KapLjudi = ((LiftZaLjudeBasic)lift).KapLjudi;
                }

                novi.SerijskiBroj = lift.SerijskiBroj;
                novi.DatPoslKvara = lift.DatPoslKvara;
                novi.DatPoslServisa = lift.DatPoslServisa;
                novi.Proizvodjac = lift.Proizvodjac;
                novi.UkVanUpotrebe = lift.UkVanUpotrebe;
                novi.Zgrada = z;

                z.Liftovi.Add(novi);
            }
            foreach (var sprat in z.Spratovi)
            {
                z.Spratovi.Add(s.Load<Sprat>(sprat.ID));
            }
            foreach (var prostor in zgrada.Prostori)
            {
                Prostor p;

                if (String.Compare(prostor.Tip, "stan", true) == 0)
                {
                    p = new Stan()
                    {
                        Vlasnik = new Vlasnik()
                        {
                            JMBG = ((StanBasic)prostor).Vlasnik.JMBG
                        }
                    };
                }
                else if (String.Compare(prostor.Tip, "lokal", true) == 0)
                {
                    p = new Lokal()
                    {
                        ImeFirme = ((LokalBasic)prostor).ImeFirme
                    };
                }
                else
                {
                    p = new Parking()
                    {
                        RegVozila = ((ParkingBasic)prostor).RegVozila
                    };
                }

                p.ID = prostor.ID;
                p.Tip = prostor.Tip;
                p.RBroj = prostor.RBroj;
                p.Sprat = new Sprat()
                {
                    RBroj = prostor.Sprat.RBroj,
                    Zgrada = z
                };
                p.Zgrada = z;

                z.Prostori.Add(p);
            }
            foreach (var ugovor in zgrada.Ugovori)
            {
                z.Ugovori.Add(new Ugovor()
                {
                    Sifra = ugovor.Sifra,
                    DatumPotpisa = ugovor.DatumPotpisivanja,
                    PeriodVazenja = ugovor.PeriodVazenja,
                    Zgrada = z
                });
            }
            foreach (var vlasnik in zgrada.VlasniciStanova)
            {
                Vlasnik v = new Vlasnik()
                {
                    JMBG = vlasnik.Vlasnik.JMBG,
                    Adresa = vlasnik.Vlasnik.Adresa,
                    LIme = vlasnik.Vlasnik.LIme,
                    ImeRoditelja = vlasnik.Vlasnik.ImeRoditelja,
                    Prezime = vlasnik.Vlasnik.Prezime,
                    Tip = vlasnik.Vlasnik.Tip
                };

                foreach (var broj in vlasnik.Vlasnik.BrojeviTelefona)
                {
                    v.BrojeviTelefona.Add(new Telefon()
                    {
                        ID = broj.ID,
                        Osoba = v,
                        BrojTelefona = broj.BrojTelefona
                    });
                }

                z.VlasniciStanova.Add(new SkupstinaStanara()
                {
                    ID = vlasnik.ID,
                    Vlasnik = v,
                    Zgrada = z,
                    Funkcija = vlasnik.Funkcija
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom izmene zgrade:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            s.Close();
        }
    }

    public static List<ZgradaBasic> sveZgradeUpravnika(string JMBGUpravnika)
    {
        ISession s = DataLayer.GetSession();

        try
        {
            List<ZgradaBasic> zgrade = new();

            Zaposleni upravik = s.Load<Zaposleni>(JMBGUpravnika);

            foreach (var zgrada in upravik.UpravljaZgradama)
            {
                zgrade.Add(new ZgradaBasic()
                {
                    ID = zgrada.ID
                });
            }

            return zgrade;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška prilikom pribavljanja svih zgrada upravnika:\n{ex.FormatExceptionMessage()}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<ZgradaBasic>();
        }
        finally
        {
            s.Close();
        }
    }
    #endregion Zgrada
}