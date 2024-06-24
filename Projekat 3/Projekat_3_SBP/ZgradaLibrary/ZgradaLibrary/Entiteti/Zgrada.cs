using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;

internal class Zgrada
{
    public virtual int ID { get; set; }
    public virtual string? Adresa { get; set; }

    public virtual IList<Zaposleni>? Upravnici { get; set; }
    public virtual IList<Ugovor>? Ugovori { get; set; }
    public virtual IList<Ulaz>? Ulazi { get; set; }
    public virtual IList<Lift>? Liftovi { get; set; }
    public virtual IList<Sprat>? Spratovi { get; set; }
    public virtual IList<Prostor>? Prostori { get; set; }
    public virtual IList<SkupstinaStanara>? VlasniciStanova { get; set; }

    public Zgrada()
    {

    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(Zgrada))
        {
            return false;
        }

        Zgrada pomObj = (Zgrada)obj;
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
