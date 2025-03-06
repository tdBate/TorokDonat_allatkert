using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorokDonat_allatkert
{
    internal class Nyul
    {
        private string nev;
        private int sebesseg;
        private int meret;
        private int pozicio;

        public Nyul(string nev, int sebesseg, int meret)
        {
            this.nev = nev;
            this.sebesseg = sebesseg;
            this.meret = meret;
            this.pozicio = 0;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Sebesseg { get => sebesseg; set => sebesseg = value; }
        public int Meret { get => meret; set => meret = value; }
        public int Pozicio { get => pozicio; set => pozicio = value; }

        public override string ToString()
        {
            return $"Név: {this.nev}, Sebesség: {this.sebesseg}, Méret:{this.Meret}";
        }
    }
}
