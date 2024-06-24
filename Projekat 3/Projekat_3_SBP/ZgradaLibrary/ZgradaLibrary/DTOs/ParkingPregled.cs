using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class ParkingPregled : ProstorPregled
{
    public string? RegVozila { get; set; }

    public ParkingPregled() : base()
    {

    }

    public ParkingPregled(int id, string regVozila, int rBroj, SpratPregled sprat, ZgradaPregled zgrada, string tip) : base(id, rBroj, sprat, zgrada, tip)
    {
        RegVozila = regVozila;
    }

    internal ParkingPregled(Parking? p) : base(p)
    {
        if(p != null)
        {
            RegVozila = p.RegVozila;
        }
    }
}
