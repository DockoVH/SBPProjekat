using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class Zaposleni : Osoba
{
    public virtual DateTime DatumRodjenja { get; set; }
    public virtual string BrLicneKarte { get; set; }
    public virtual string MestoIzdLK { get; set; }
    public virtual string TipPosla { get; set; }
    public virtual IList<Obrazovanje> Obrazovanja { get; set; }
    public virtual IList<Licenca> Licence { get; set; }
    public virtual IList<Zgrada> UpravljaZgradama { get; set; }

    public Zaposleni()
    {
        Obrazovanja = new List<Obrazovanje>();
        Licence = new List<Licenca>();
        UpravljaZgradama = new List<Zgrada>();
    }
}
