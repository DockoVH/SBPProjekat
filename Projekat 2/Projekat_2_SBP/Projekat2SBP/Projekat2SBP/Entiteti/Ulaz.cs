using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP.Entiteti;

public class Ulaz
{
    public virtual int ID { get; set; }
    public virtual int RBroj { get; set; }
    public virtual char Kamera { get; set; }
    public virtual string PocetakRadnogVremena { get; set; }
    public virtual string KrajRadnogVremena { get; set; }
    public virtual Zgrada Zgrada { get; set; }

    public Ulaz()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(Ulaz))
        {
            return false;
        }

        Ulaz pomObj = (Ulaz)obj;
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
