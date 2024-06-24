using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class Osoba
{
    public virtual string JMBG { get; set; }
    public virtual string Adresa { get; set; }
    public virtual string LIme { get; set; }
    public virtual string ImeRoditelja { get; set; }
    public virtual string Prezime { get; set; }
    public virtual string Tip { get; set; }
    public virtual IList<Telefon> BrojeviTelefona { get; set; }

    public Osoba()
    {
        BrojeviTelefona = new List<Telefon>();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        Osoba pomObj = (Osoba)obj;
        if (JMBG == pomObj.JMBG)
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
