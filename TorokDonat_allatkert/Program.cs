namespace TorokDonat_allatkert
{
	internal class Program
	{
		static void AllatkertRajz(int meret, int maxMeret)
		{
            Console.WriteLine("Állatkert rajza:");

            Console.Write(' ');
            Console.WriteLine(string.Concat(Enumerable.Repeat("-",maxMeret)));
			Console.Write("|");

			Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Concat(Enumerable.Repeat("■", meret)));
			Console.Write(string.Concat(Enumerable.Repeat(" ", maxMeret-meret)));
			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine("|");
			Console.Write(' ');
			Console.WriteLine(string.Concat(Enumerable.Repeat("-", maxMeret)));
		}

		static void Verseny(List<Allat> allatok)
		{
			Console.Clear();
			Console.CursorVisible = false;
			

			bool marade = true;
			int palyameret = 100;
			int nyertesIndex = 0;
			while (marade)
			{
				Console.SetCursorPosition(0, 0);
				for (int a = 0; a < allatok.Count; a++)
				{
					
					Console.Write(new string(' ', Console.WindowWidth));
					//Console.Write(allatok[a].Nev);
					Console.Write(allatok[a].Nev.PadRight(15,' '));

                    Console.WriteLine(String.Concat(Enumerable.Repeat(" ",allatok[a].Pozicio))+"O");

					Thread.Sleep(100);

					allatok[a].Pozicio += allatok[a].Sebesseg;
					if (allatok[a].Pozicio >= palyameret && marade)
					{
						nyertesIndex = a;
						marade = false;
					}
                }
			}

			Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nA nyertes: " + allatok[nyertesIndex].Nev);
			Console.ForegroundColor = ConsoleColor.White;

		}

		static void Main(string[] args)
		{
			Random rnd = new Random();

			//Allat[] allatok = {g1, n1, k1, j1 };
			List<Allat> allatok = new List<Allat>();
			string[] allatNevek = { "Ponty", "Görög teknős", "Nyúl", "Kaméleon", "Jegesmedve" };

			int allatkertMaxMeret = rnd.Next(5,16);

			int allatkertMeret = 0;
			bool marade = true;

			Dictionary<string, int> nevekCount =new Dictionary<string, int>();
            while (marade)
            {
                string tipus = allatNevek[rnd.Next(0,allatNevek.Length)];
                string nev = tipus;
                
                if (!nevekCount.ContainsKey(nev))
                    nevekCount[nev] = 1;
                else
                    nevekCount[nev]++;
                nev += " " + nevekCount[nev];

                int meret = rnd.Next(1, 4);
                if (allatkertMeret + meret <= allatkertMaxMeret)
                {
                    //Console.WriteLine(nev);
                    switch (tipus)
                    {
                        case "Görög teknős": allatok.Add(new GorogTeknos(nev, rnd.Next(1, 11), meret)); break;
                        case "Jegesmedve": allatok.Add(new Jegesmedve(nev, rnd.Next(1, 11), meret)); break;
                        case "Kaméleon": allatok.Add(new Kameleon(nev, rnd.Next(1, 11), meret)); break;
                        case "Nyúl": allatok.Add(new Nyul(nev, rnd.Next(1, 11), meret)); break;
                        case "Ponty": allatok.Add(new Ponty(nev, rnd.Next(1, 11), meret)); break;
                    }
                    allatkertMeret += meret;
                }
                else { marade = false; }
            }

            Console.WriteLine($"Állatkert mérete: {allatkertMaxMeret}");
			Console.WriteLine($"Állatkert telítettsége: {Math.Round((allatkertMeret/ Convert.ToDouble(allatkertMaxMeret)),4)*100}%");
			Console.WriteLine("Állatkert tartalma:");
            foreach (Allat allat in allatok)
			{
                Console.WriteLine("\t"+allat);
            }

			AllatkertRajz(allatkertMeret,allatkertMaxMeret);

            Console.Write("Szeretné versenyezteni az állatokat? [Y/N]: ");
			string valasz = Console.ReadLine().ToLower();

			if (valasz == "y")
			{
				Verseny(allatok);
			}
        }
	}
}
