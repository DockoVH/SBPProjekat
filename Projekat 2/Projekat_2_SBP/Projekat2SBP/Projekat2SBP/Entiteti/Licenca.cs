using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP.Entiteti;

public class Licenca
{
    public virtual int ID { get; set; }
    public virtual Zaposleni Upravnik { get; set; }
    public virtual int BrLicence { get; set; }
    public virtual string Izdavac { get; set; }
    public virtual DateTime DatumSticanja { get; set; }

    public Licenca()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(Licenca))
        {
            return false;
        }

        Licenca pomObj = (Licenca)obj;
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
