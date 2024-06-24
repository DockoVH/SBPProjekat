using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal class Angazovanje
{
    public virtual Zgrada? Zgrada { get; set; }
    public virtual Zaposleni? Upravnik { get; set; }

    public Angazovanje()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(Angazovanje))
        {
            return false;
        }

        Angazovanje pomObj = (Angazovanje)obj;
        if (Zgrada?.ID == pomObj?.Zgrada?.ID && Upravnik?.JMBG == pomObj?.Upravnik?.JMBG)
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
