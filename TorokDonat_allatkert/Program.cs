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
				string allatNev = allatNevek[rnd.Next(0, allatNevek.Length)];

				try {
					nevekCount.Add(allatNev, 1);
				} catch { nevekCount[allatNev] += 1; }

				allatNev += " " + nevekCount[allatNev];

				int meret= rnd.Next(1, 4);
				if (allatkertMeret + meret <= allatkertMaxMeret)
				{
					allatok.Add(new Allat(allatNev, rnd.Next(1, 11), meret));
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
			Verseny(allatok);
        }
	}
}
