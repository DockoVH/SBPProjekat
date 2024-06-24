using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekat2SBP.Entiteti;

public class Telefon
{
    public virtual int ID { get; set; }
    public virtual Osoba Osoba { get; set; }
    public virtual string BrojTelefona { get; set; }

    public Telefon()
    {
        
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(Telefon))
        {
            return false;
        }

        Telefon pomObj = (Telefon)obj;
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
