using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal abstract class Lift
{
    public virtual int SerijskiBroj { get; set; }
    public virtual DateTime DatPoslServisa { get; set; }
    public virtual DateTime DatPoslKvara { get; set; }
    public virtual int UkVanUpotrebe { get; set; }
    public virtual string? Proizvodjac { get; set; }
    public virtual string? Tip { get; set; }
    public virtual int IDZgrade { get; set; }
    public virtual Zgrada? Zgrada { get; set; }

    protected Lift()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != GetType())
        {
            return false;
        }

        Lift? pomObj = (Lift)obj;
        if (SerijskiBroj == pomObj.SerijskiBroj)
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
