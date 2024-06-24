using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.Entiteti;
internal class Stan : Prostor
{
    public virtual Vlasnik? Vlasnik { get; set; }

    public virtual IList<ImeStanara>? Stanari { get; set; }

    public Stan()
    {

    }
}
