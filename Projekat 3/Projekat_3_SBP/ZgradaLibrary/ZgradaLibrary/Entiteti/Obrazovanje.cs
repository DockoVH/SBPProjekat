using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal class Obrazovanje
{
    public virtual int ID { get; set; }
    public virtual Zaposleni? Upravnik { get; set; }
    public virtual string? Zvanje { get; set; }
    public virtual DateTime DatumSticanja { get; set; }
    public virtual string? NazivInstitucije { get; set; }

    public Obrazovanje()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(Obrazovanje))
        {
            return false;
        }

        Obrazovanje pomObj = (Obrazovanje)obj;
        if (ID == pomObj.ID)
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
