using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorokDonat_allatkert
{
    internal class Ponty : Allat
    {
        private string nev;
        private int sebesseg;
        private int meret;
        private int pozicio;

        public Ponty(string nev, int sebesseg, int meret) : base(nev, sebesseg, meret)
        {
            this.nev = nev;
            this.sebesseg = sebesseg;
            this.meret = meret;
            this.pozicio = 0;
        }

        public override string ToString()
        {
            return $"Név: {this.nev}, Sebesség: {this.sebesseg}, Méret:{this.Meret}";
        }
    }
}
