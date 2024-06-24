using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal class Sprat
{
    public virtual int ID { get; set; }
    public virtual int RBroj { get; set; }
    public virtual Zgrada? Zgrada { get; set; }
    public virtual IList<Prostor>? Prostori { get; set; }

    public Sprat()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(Sprat))
        {
            return false;
        }

        Sprat pomObj = (Sprat)obj;
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
