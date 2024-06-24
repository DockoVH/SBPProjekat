using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class Ugovor
{
    public virtual int Sifra { get; set; }
    public virtual DateTime DatumPotpisa { get; set; }
    public virtual int PeriodVazenja { get; set; }
    public virtual int IDZgrade { get; set; }
    public virtual Zgrada Zgrada { get; set; }

    public Ugovor()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(Ugovor))
        {
            return false;
        }

        Ugovor pomObj = (Ugovor)obj;
        if (Sifra == pomObj.Sifra)
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
