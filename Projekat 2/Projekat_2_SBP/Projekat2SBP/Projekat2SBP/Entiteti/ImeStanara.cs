using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class ImeStanara
{
    public virtual int ID { get; set; }
    public virtual string Ime { get; set; }
    public virtual Stan Stan { get; set; }
    public virtual Sprat Sprat { get; set; }
    public virtual Zgrada Zgrada { get; set; }

    public ImeStanara()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(ImeStanara))
        {
            return false;
        }

        ImeStanara pomObj = (ImeStanara)obj;
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
