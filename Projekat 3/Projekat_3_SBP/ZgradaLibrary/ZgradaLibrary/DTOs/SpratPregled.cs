using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class SpratPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public ZgradaPregled? Zgrada { get; set; }
    public List<ProstorPregled>? Prostori { get; set; }

    public SpratPregled()
    {

    }

    public SpratPregled(int id, int rBroj, ZgradaPregled zgrada)
    {
        ID = id;
        RBroj = rBroj;
        Zgrada = zgrada;
        Prostori = new();
    }

    internal SpratPregled(Sprat? s)
    {
        if(s != null)
        {
            ID = s.ID;
            RBroj = s.RBroj;
            Zgrada = new(s.Zgrada);
            Prostori = new();

            foreach(Prostor p in s.Prostori)
            {
                Prostori.Add(new ProstorPregled(p));
            }
        }
    }
}
