using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZgradaLibrary.DTOs;

public class UlazPregled
{
    public int ID { get; set; }
    public int RBroj { get; set; }
    public char Kamera { get; set; }
    public ZgradaPregled? Zgrada { get; set; }
    public string? PocetakRadnogVremena { get; set; }
    public string? KrajRadnogVremena { get; set; }

    public UlazPregled()
    {

    }
    public UlazPregled(int id, int rBroj, char kamera, ZgradaPregled zgrada, string pocetakRadnogVremena, string krajRadnogVremena)
    {
        ID = id;
        RBroj = rBroj;
        Kamera = kamera;
        Zgrada = zgrada;
        PocetakRadnogVremena = pocetakRadnogVremena;
        KrajRadnogVremena = krajRadnogVremena;
    }

    internal UlazPregled(Ulaz? u)
    {
        if(u != null)
        {
            ID = u.ID;
            RBroj = u.RBroj;
            Kamera = u.Kamera;
            Zgrada = new(u.Zgrada);
            PocetakRadnogVremena = u.PocetakRadnogVremena;
            KrajRadnogVremena = u.KrajRadnogVremena;
        }
    }
}
