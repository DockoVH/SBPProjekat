using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP.Entiteti;

public abstract class Prostor
{
    public virtual int ID { get; set; }
    public virtual int RBroj { get; set; }
    public virtual Sprat Sprat { get; set; }
    public virtual Zgrada Zgrada { get; set; }  
    public virtual string Tip { get; set; }

    protected Prostor()
    {
        
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

        Prostor pomObj = (Prostor)obj;
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
