using FluentNHibernate.Mapping;
using Projekat2SBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP;

public class AngazovanjeBasic
{
    public ZgradaBasic Zgrada;
    public ZaposleniBasic Upravnik;

    public AngazovanjeBasic()
    {
        Zgrada = new();
        Upravnik = new();
    }

    public AngazovanjeBasic(ZgradaBasic zgrada, ZaposleniBasic upravnik)
    {
        Zgrada = zgrada;
        Upravnik = upravnik;
    }
}

public class AngazovanjePregled
{
    public ZgradaPregled Zgrada { get; set; }
    public ZaposleniPregled Upravnik { get; set; }

    public AngazovanjePregled()
    {
        Zgrada = new();
        Upravnik = new();
    }

    public AngazovanjePregled(ZgradaPregled zgrada, ZaposleniPregled upravnik)
    {
        Zgrada = zgrada;
        Upravnik = upravnik;
    }
}

public class ImeStanaraBasic
{
    public int ID;
    public StanBasic Stan;
    public string Ime;

    public ImeStanaraBasic()
    {
        Stan = new();
        Ime = "";
    }

    public ImeStanaraBasic(int id, StanBasic stan, string ime)
    {
        ID = id;
        Stan = stan;
        Ime = ime;
    }
}

public class ImeStanaraPregled
{
    public int ID { get; set; }
    public StanPregled Stan { get; set; }
    public string Ime { get; set; }

    public ImeStanaraPregled()
    {
        Stan = new();
        Ime = "";
    }

    public ImeStanaraPregled(int id, StanPregled stan, string ime)
    {
        ID = id;
        Stan = stan;
        Ime = ime;
    }
}

public class LicencaBasic
{
    public int ID;
    public ZaposleniBasic Upravnik;
    public int BrLicence;
    public string Izdavac;
    public DateTime DatumSticanja;

    public LicencaBasic()
    {
        Upravnik = new();
        Izdavac = "";
    }

    public LicencaBasic(int id, ZaposleniBasic upravnik, int brLicence, string izdavac, DateTime datumSticanja)
    {
        ID = id;
        Upravnik = upravnik;
        BrLicence = brLicence;
        Izdavac = izdavac;
        DatumSticanja = datumSticanja;
    }
}

public class LicencaPregled
{
    public int ID { get; set; }
    public ZaposleniPregled Upravnik { get; set; }
    public int BrLicence { get; set; }
    public string Izdavac { get; set; }
    public DateTime DatumSticanja { get; set; }

    public LicencaPregled()
    {
        Upravnik = new();
        Izdavac = "";
    }

    public LicencaPregled(int id, ZaposleniPregled upravnik, int brLicence, string izdavac, DateTime datumSticanja)
    {
        ID = id;
        Upravnik = upravnik;
        BrLicence = brLicence;
        Izdavac = izdavac;
        DatumSticanja = datumSticanja;
    }
}

public class LiftBasic
{
    public int SerijskiBroj;
    public DateTime DatPoslServisa;
    public DateTime DatPoslKvara;
    public int UkVanUpotrebe;
    public string Proizvodjac;
    public string Tip;
    public ZgradaBasic Zgrada;

    public LiftBasic()
    {
        Proizvodjac = "";
        Tip = "";
        Zgrada = new();
    }

    public LiftBasic(int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, string tip, ZgradaBasic zgrada)
    {
        SerijskiBroj = serijskiBroj;
        DatPoslServisa = datPoslServisa;
        DatPoslKvara = datPoslKvara;
        UkVanUpotrebe = ukVanUpotrebe;
        Proizvodjac = proizvodjac;
        Tip = tip;
        Zgrada = zgrada;
    }

}

public class LiftPregled
{
    public int SerijskiBroj { get; set; }
    public DateTime DatPoslServisa { get; set; }
    public DateTime DatPoslKvara { get; set; }
    public int UkVanUpotrebe { get; set; }
    public string Tip { get; set; }
    public string Proizvodjac { get; set; }
    public ZgradaPregled Zgrada { get; set; }

    public LiftPregled()
    {
        Tip = "";
        Proizvodjac = "";
        Zgrada = new();
    }

    public LiftPregled(int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip)
    {
        SerijskiBroj = serijskiBroj;
        DatPoslServisa = datPoslServisa;
        DatPoslKvara = datPoslKvara;
        UkVanUpotrebe = ukVanUpotrebe;
        Proizvodjac = proizvodjac;
        Zgrada = zgrada;
        Tip = tip;
    }
}

public class LiftZaLjudeBasic : LiftBasic
{
    public int KapLjudi;

    public LiftZaLjudeBasic() : base()
    {

    }

    public LiftZaLjudeBasic(int kapLjudi, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, string tip, ZgradaBasic zgrada) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, tip, zgrada)
    {
        KapLjudi = kapLjudi;
    }
}

public class LiftZaLjudePregled : LiftPregled
{
    public int KapLjudi { get; set; }

    public LiftZaLjudePregled() : base()
    {

    }

    public LiftZaLjudePregled(int kapLjudi, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, zgrada, tip)
    {
        KapLjudi = kapLjudi;
    }
}

public class LiftTeretniBasic : LiftBasic
{
    public double Nosivost;

    public LiftTeretniBasic() : base()
    {

    }

    public LiftTeretniBasic(double nosivost, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, string tip, ZgradaBasic zgrada) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, tip, zgrada)
    {
        Nosivost = nosivost;
    }
}

public class LiftTeretniPregled : LiftPregled
{
    public double Nosivost { get; set; }

    public LiftTeretniPregled() : base()
    {

    }

    public LiftTeretniPregled(double nosivost, int serijskiBroj, DateTime datPoslServisa, DateTime datPoslKvara, int ukVanUpotrebe, string proizvodjac, ZgradaPregled zgrada, string tip) : base(serijskiBroj, datPoslServisa, datPoslKvara, ukVanUpotrebe, proizvodjac, zgrada, tip)
    {
        Nosivost = nosivost;
    }
}

public class LokalBasic : ProstorBasic
{
    public string ImeFirme;

    public LokalBasic() : base()
    {
        ImeFirme = "";
    }
    public LokalBasic(int id, string imeFirme, int rBroj, SpratBasic sprat, ZgradaBasic zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        ImeFirme = imeFirme;
    }
}

public class LokalPregled : ProstorPregled
{
    public string ImeFirme { get; set; }

    public LokalPregled() : base()
    {
        ImeFirme = "";
    }
    public LokalPregled(int id, string imeFirme, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        ImeFirme = imeFirme;
    }
}

public class ObrazovanjeBasic
{
    public int ID;
    public ZaposleniBasic Upravnik;
    public string Zvanje;
    public DateTime DatumSticanja;
    public string NazivInstitucije;

    public ObrazovanjeBasic()
    {
        Upravnik = new();
        Zvanje = "";
        NazivInstitucije = "";
    }

    public ObrazovanjeBasic(int id, ZaposleniBasic upravnik, string zvanje, DateTime datumSticanja, string nazivInstitucije)
    {
        ID = id;
        Upravnik = upravnik;
        Zvanje = zvanje;
        DatumSticanja = datumSticanja;
        NazivInstitucije = nazivInstitucije;
    }
}

public class ObrazovanjePregled
{
    public int ID { get; set; }
    public ZaposleniPregled Upravnik { get; set; }
    public string Zvanje { get; set; }
    public DateTime DatumSticanja { get; set; }
    public string NazivInstitucije { get; set; }

    public ObrazovanjePregled()
    {
        Upravnik = new();
        Zvanje = "";
        NazivInstitucije = "";
    }

    public ObrazovanjePregled(int id, ZaposleniPregled upravnik, string zvanje, DateTime datumSticanja, string nazivInstitucije)
    {
        ID = id;
        Upravnik = upravnik;
        Zvanje = zvanje;
        DatumSticanja = datumSticanja;
        NazivInstitucije = nazivInstitucije;
    }
}

public class OsobaBasic
{
    public string JMBG;
    public string Adresa;
    public string LIme;
    public string ImeRoditelja;
    public string Prezime;
    public string Tip;
    public IList<TelefonBasic> BrojeviTelefona;

    public OsobaBasic()
    {
        JMBG = "";
        Adresa = "";
        LIme = "";
        ImeRoditelja = "";
        Prezime = "";
        Tip = "";
        BrojeviTelefona = new List<TelefonBasic>();
    }

    public OsobaBasic(string jMBG, string adresa, string lIme, string imeRoditelja, string prezime, string tip)
    {
        JMBG = jMBG;
        Adresa = adresa;
        LIme = lIme;
        ImeRoditelja = imeRoditelja;
        Prezime = prezime;
        Tip = tip;
        BrojeviTelefona = new List<TelefonBasic>();
    }
}

public class OsobaPregled
{
    public string JMBG { get; set; }
    public string Adresa { get; set; }
    public string PunoIme { get; set; }
    public List<TelefonPregled> BrojeviTelefona { get; set; }

    public OsobaPregled()
    {
        JMBG = "";
        Adresa = "";
        PunoIme = "";
        BrojeviTelefona = new();
    }

    public OsobaPregled(string jMBG, string adresa, string punoIme, string brojTelefona)
    {
        JMBG = jMBG;
        Adresa = adresa;
        PunoIme = punoIme;
        BrojeviTelefona =
        [
            new TelefonPregled()
            {
                Osoba = new OsobaPregled()
                {
                    JMBG = jMBG,
                },
                BrojTelefona = brojTelefona
            },
        ];
    }
}

public class ParkingBasic : ProstorBasic
{
    public string RegVozila;

    public ParkingBasic() : base()
    {
        RegVozila = "";
    }

    public ParkingBasic(int id, string regVozila, int rBroj, SpratBasic sprat, ZgradaBasic zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        RegVozila = regVozila;
    }
}

public class ParkingPregled : ProstorPregled
{
    public string RegVozila { get; set; }

    public ParkingPregled() : base()
    {
        RegVozila = "";
    }

    public ParkingPregled(int id, string regVozila, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        RegVozila = regVozila;
    }
}

public class ProstorBasic
{
    public int ID;
    public int RBroj;
    public SpratBasic Sprat;
    public ZgradaBasic Zgrada;
    public string Tip;

    public ProstorBasic()
    {
        Sprat = new();
        Zgrada = new();
        Tip = "";
    }
    public ProstorBasic(int id, int rBroj, SpratBasic sprat, ZgradaBasic zgrada, string tip)
    {
        ID = id;
        RBroj = rBroj;
        Sprat = sprat;
        Zgrada = zgrada;
        Tip = tip;
    }
}

public class ProstorPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public SpratPregled Sprat { get; set; }
    public ZgradaPregled Zgrada { get; set; }
    public string Tip { get; set; }

    public ProstorPregled()
    {
        Sprat = new();
        Zgrada = new();
        Tip = "";
    }
    public ProstorPregled(int id, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip)
    {
        ID = id;
        RBroj = rBroj;
        Sprat = sprat;
        Zgrada = zgrada;
        Tip = tip;
    }
}

public class SkupstinaStanaraBasic
{
    public int ID;
    public ZgradaBasic Zgrada;
    public VlasnikBasic Vlasnik;
    public string Funkcija;

    public SkupstinaStanaraBasic()
    {
        Zgrada = new();
        Vlasnik = new();
        Funkcija = "";
    }

    public SkupstinaStanaraBasic(int id, ZgradaBasic zgrada, VlasnikBasic vlasnik, string funkcija)
    {
        ID = id;
        Zgrada = zgrada;
        Vlasnik = vlasnik;
        Funkcija = funkcija;
    }
}

public class SkupstinaStanaraPregled
{
    public int ID { get; set; }
    public ZgradaPregled Zgrada { get; set; }
    public VlasnikPregled Vlasnik { get; set; }
    public string Funkcija { get; set; }

    public SkupstinaStanaraPregled()
    {
        Zgrada = new();
        Vlasnik = new();
        Funkcija = "";
    }

    public SkupstinaStanaraPregled(int id, ZgradaPregled zgrada, VlasnikPregled vlasnik, string funkcija)
    {
        ID = id;
        Zgrada = zgrada;
        Vlasnik = vlasnik;
        Funkcija = funkcija;
    }
}

public class SpratBasic
{
    public int ID;
    public int RBroj;
    public ZgradaBasic Zgrada;
    public List<ProstorBasic> Prostori;

    public SpratBasic()
    {
        Zgrada = new();
        Prostori = new();
    }

    public SpratBasic(int id, int rBroj, ZgradaBasic zgrada)
    {
        ID = id;
        RBroj = rBroj;
        Zgrada = zgrada;
        Prostori = new();
    }
}

public class SpratPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public ZgradaPregled Zgrada { get; set; }
    public List<ProstorPregled> Prostori { get; set; }

    public SpratPregled()
    {
        Zgrada = new();
        Prostori = new();
    }

    public SpratPregled(int id, int rBroj, ZgradaPregled zgrada)
    {
        ID = id;
        RBroj = rBroj;
        Zgrada = zgrada;
        Prostori = new();
    }
}

public class StanBasic : ProstorBasic
{
    public VlasnikBasic Vlasnik;
    public IList<ImeStanaraBasic> Stanari;

    public StanBasic() :base()
    {
        Vlasnik = new();
        Stanari = new List<ImeStanaraBasic>();
    }
    public StanBasic(int id, VlasnikBasic vlasnik, int rBroj, SpratBasic sprat, ZgradaBasic zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        Vlasnik = vlasnik;
        Stanari = new List<ImeStanaraBasic>();
    }   
}

public class StanPregled : ProstorPregled
{
    public VlasnikPregled Vlasnik { get; set; }
    public List<ImeStanaraPregled> Stanari { get; set; }

    public StanPregled() : base()
    {
        Vlasnik = new();
        Stanari = new();
    }
    public StanPregled(int id, VlasnikPregled vlasnik, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        Vlasnik = vlasnik;
        Stanari = new();
    }
}

public class TelefonBasic
{
    public int ID;
    public OsobaBasic Osoba;
    public string BrojTelefona;

    public TelefonBasic()
    {
        Osoba = new();
        BrojTelefona = "";
    }
    public TelefonBasic(int id, OsobaBasic osoba, string brojTelefona)
    {
        ID = id;
        Osoba = osoba;
        BrojTelefona = brojTelefona;
    }
}

public class TelefonPregled
{
    public int ID { get; set; }
    public OsobaPregled Osoba { get; set; }
    public string BrojTelefona { get; set; }

    public TelefonPregled()
    {
        Osoba = new();
        BrojTelefona = "";
    }
    public TelefonPregled(int id, OsobaPregled osoba, string brojTelefona)
    {
        ID = id;
        Osoba = osoba;
        BrojTelefona = brojTelefona;
    }
}

public class UgovorBasic
{
    public int Sifra;
    public DateTime DatumPotpisivanja;
    public int PeriodVazenja;
    public ZgradaBasic Zgrada;

    public UgovorBasic()
    {
        Zgrada = new();
    }
    public UgovorBasic(int sifra, DateTime datumPotpisivanja, int periodVazenja, ZgradaBasic zgrada)
    {
        Sifra = sifra;
        DatumPotpisivanja = datumPotpisivanja;
        PeriodVazenja = periodVazenja;
        Zgrada = zgrada;
    }
}

public class UgovorPregled  
{
    public int Sifra { get; set; }
    public DateTime DatumPotpisivanja { get; set; }
    public int PeriodVazenja { get; set; }
    public ZgradaPregled Zgrada { get; set; }

    public UgovorPregled()
    {
        Zgrada = new();
    }
    public UgovorPregled(int sifra, DateTime datumPotpisivanja, int periodVazenja, ZgradaPregled zgrada)
    {
        Sifra = sifra;
        DatumPotpisivanja = datumPotpisivanja;
        PeriodVazenja = periodVazenja;
        Zgrada = zgrada;
    }
}

public class UlazBasic
{
    public int ID;
    public int RBroj;
    public char Kamera;
    public ZgradaBasic Zgrada;
    public string PocetakRadnogVremena;
    public string KrajRadnogVremena;

    public UlazBasic()
    {
        Zgrada = new();
        PocetakRadnogVremena = "";
        KrajRadnogVremena = "";
    }
    public UlazBasic(int id, int rBroj, char kamera, ZgradaBasic zgrada, string pocetakRadnogVremena, string krajRadnogVremena)
    {
        ID = id;
        RBroj = rBroj;
        Kamera = kamera;
        Zgrada = zgrada;
        PocetakRadnogVremena = pocetakRadnogVremena;
        KrajRadnogVremena = krajRadnogVremena;
    }
}

public class UlazPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public char Kamera { get; set; }
    public ZgradaPregled Zgrada { get; set; }
    public string PocetakRadnogVremena { get; set; }
    public string KrajRadnogVremena { get; set; }

    public UlazPregled()
    {
        Zgrada = new();
        PocetakRadnogVremena = "";
        KrajRadnogVremena = "";
    }
    public UlazPregled(int id, int rBroj, char kamera, ZgradaPregled zgrada, string pocetakRadnogVremena, string krajRadnogVremena)
    {
        ID = id;
        RBroj = rBroj;
        Kamera = kamera;
        Zgrada = zgrada;
        PocetakRadnogVremena = pocetakRadnogVremena;
        KrajRadnogVremena = krajRadnogVremena;
    }
}

public class VlasnikBasic : OsobaBasic
{
    public VlasnikBasic() : base()
    {

    }

    public VlasnikBasic(string jMBG, string adresa, string lIme, string imeRoditelja, string prezime, string tip) : base(jMBG, adresa, lIme, imeRoditelja, prezime, tip)
    {
        
    }
}

public class VlasnikPregled : OsobaPregled
{
    public VlasnikPregled() : base()
    {

    }

    public VlasnikPregled(string jMBG, string adresa, string punoIme, string brojTelefona) : base(jMBG, adresa, punoIme, brojTelefona)
    {

    }
}

public class ZaposleniBasic : OsobaBasic
{
    public DateTime DatumRodjenja;
    public string BrLicneKarte;
    public string MestoIzdLK;
    public string TipPosla;
    public IList<ObrazovanjeBasic> Obrazovanja;
    public IList<LicencaBasic> Licence;
    public IList<ZgradaBasic> UpravljaZgradama;

    public ZaposleniBasic() : base()
    {
        BrLicneKarte = "";
        MestoIzdLK = "";
        TipPosla = "";
        Obrazovanja = new List<ObrazovanjeBasic>();
        Licence = new List<LicencaBasic>();
        UpravljaZgradama = new List<ZgradaBasic>();
    }
    public ZaposleniBasic(DateTime datumRodjenja, string brLicneKarte, string mestoIzdLK, string tipPosla, string jMBG, string adresa, string lIme, string imeRoditelja, string prezime, string tip) : base(jMBG, adresa, lIme, imeRoditelja, prezime, tip)
    {
        DatumRodjenja = datumRodjenja;
        BrLicneKarte = brLicneKarte;
        MestoIzdLK = mestoIzdLK;
        TipPosla = tipPosla;
        Obrazovanja = new List<ObrazovanjeBasic>();
        Licence = new List<LicencaBasic>();
        UpravljaZgradama = new List<ZgradaBasic>();
    }
}

public class ZaposleniPregled : OsobaPregled
{
    public DateTime DatumRodjenja { get; set; }
    public string BrLicneKarte { get; set; }
    public string MestoIzdLK { get; set; }
    public string TipPosla { get; set; }
    public List<ObrazovanjePregled> Obrazovanja { get; set; }
    public List<LicencaPregled> Licence { get; set; }
    public List<ZgradaPregled> Zgrade { get; set; }

    public ZaposleniPregled() : base()
    {
        BrLicneKarte = "";
        MestoIzdLK = "";
        TipPosla = "";
        Obrazovanja = new();
        Licence = new();
        Zgrade = new();
    }
    public ZaposleniPregled(DateTime datumRodjenja, string brLicneKarte, string mestoIzdLK, string tipPosla, int obrazovanja, int licence, int brojZgrada, string jMBG, string adresa, string punoIme, string brojTelefona) : base(jMBG, adresa, punoIme, brojTelefona)
    {
        DatumRodjenja = datumRodjenja;
        BrLicneKarte = brLicneKarte;
        MestoIzdLK = mestoIzdLK;
        TipPosla = tipPosla;
        Obrazovanja = new();
        Licence = new();
        Zgrade = new();
    }
}

public class ZgradaBasic
{
    public int ID;
    public string Adresa;
    public IList<ZaposleniBasic> Upravnici;
    public IList<UgovorBasic> Ugovori;
    public IList<UlazBasic> Ulazi;
    public IList<LiftBasic> Liftovi;
    public IList<SpratBasic> Spratovi;
    public IList<ProstorBasic> Prostori;
    public IList<SkupstinaStanaraBasic> VlasniciStanova;

    public ZgradaBasic()
    {
        Adresa = "";
        Upravnici = new List<ZaposleniBasic>();
        Ugovori = new List<UgovorBasic>();
        Ulazi = new List<UlazBasic>();
        Liftovi = new List<LiftBasic>();
        Spratovi = new List<SpratBasic>();
        Prostori = new List<ProstorBasic>();
        VlasniciStanova = new List<SkupstinaStanaraBasic>();
    }

    public ZgradaBasic(int iD, string adresa) : this()
    {
        ID = iD;
        Adresa = adresa;
    }
}

public class ZgradaPregled
{
    public int ID { get; set; }
    public string Adresa { get; set; }
    public ZaposleniPregled Upravnik { get; set; }
    public int BrojUgovora { get; set; }
    public int BrojUlaza { get; set; }
    public int BrojLiftova { get; set; }
    public int BrojSpratova { get; set; }
    public int BrojProstora { get; set; }
    public int BrojVlasnikaStanova { get; set; }

    public ZgradaPregled()
    {
        Adresa = "";
        Upravnik = new();
    }

    public ZgradaPregled(int id,  string adresa, ZaposleniPregled upravnik, int brojUgovora, int brojUlaza, int brojLiftova, int brojSpratova, int brojProstora, int brojVlasnikaStanova)
    {
        ID = id;
        Adresa = adresa;
        Upravnik = upravnik;
        BrojUgovora = brojUgovora;
        BrojUlaza = brojUlaza;
        BrojLiftova = brojLiftova;
        BrojSpratova = brojSpratova;
        BrojProstora = brojProstora;
        BrojVlasnikaStanova = brojVlasnikaStanova;
    }
}