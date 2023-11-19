using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Foglalasok
{
    internal class Foglalas
    {
        int sorszam;
        string vendegnev;
        string szobanev;
        DateTime erkezes;
        DateTime tavozas;
        int letszam;

        public Foglalas(int sorszam, string vendegnev, string szobanev, DateTime erkezes, DateTime tavozas, int letszam)
        {
            this.Sorszam = sorszam;
            this.Vendegnev = vendegnev;
            this.Szobanev = szobanev;
            this.Erkezes = erkezes;
            this.Tavozas = tavozas;
            this.Letszam = letszam;
        }

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public string Vendegnev { get => vendegnev; set => vendegnev = value; }
        public string Szobanev { get => szobanev; set => szobanev = value; }
        public DateTime Erkezes { get => erkezes; set => erkezes = value; }
        public DateTime Tavozas { get => tavozas; set => tavozas = value; }
        public int Letszam { get => letszam; set => letszam = value; }
    }
}
