using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class SkupstinaStanara
{
    public virtual int ID { get; set; }
    public virtual Zgrada Zgrada { get; set; }
    public virtual Vlasnik Vlasnik { get; set; }
    public virtual string Funkcija { get; set; }

    public SkupstinaStanara()
    {
        ID = new();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(SkupstinaStanara))
        {
            return false;
        }

        SkupstinaStanara pomObj = (SkupstinaStanara)obj;
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
