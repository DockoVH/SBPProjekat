using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ProstorPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public SpratPregled? Sprat { get; set; }
    public ZgradaPregled? Zgrada { get; set; }
    public string? Tip { get; set; }

    public ProstorPregled()
    {

    }
    public ProstorPregled(int id, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip)
    {
        ID = id;
        RBroj = rBroj;
        Sprat = sprat;
        Zgrada = zgrada;
        Tip = tip;
    }

    internal ProstorPregled(Prostor? p)
    {
        if(p != null)
        {
            ID = p.ID;
            RBroj = p.RBroj;
            Sprat = new(p.Sprat);
            Zgrada = new(p.Zgrada);
            Tip = p.Tip;
        }
    }
}
