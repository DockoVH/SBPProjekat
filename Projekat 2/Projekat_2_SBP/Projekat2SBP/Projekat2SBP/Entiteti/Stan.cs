using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP.Entiteti;

public class Stan : Prostor
{
    public virtual Vlasnik Vlasnik { get; set; }

    public virtual IList<ImeStanara> Stanari { get; set; }

    public Stan()
    {
        Stanari = new List<ImeStanara>();
    }
}
