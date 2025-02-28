using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorokDonat_allatkert
{
	internal class Kameleon
	{
		private string nev;
		private int sebesseg;
		private int meret;

		public Kameleon(string nev, int sebesseg, int meret)
		{
			this.nev = nev;
			this.sebesseg = sebesseg;
			this.meret = meret;
		}

		public string Nev { get => nev; set => nev = value; }
		public int Sebesseg { get => sebesseg; set => sebesseg = value; }
		public int Meret { get => meret; set => meret = value; }
	}
}
