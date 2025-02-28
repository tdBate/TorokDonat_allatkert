namespace TorokDonat_allatkert
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			//Allat[] allatok = {g1, n1, k1, j1 };
			List<Allat> allatok = new List<Allat>();
			string[] allatNevek = { "Ponty", "Görög teknős", "Nyúl", "Kaméleon", "Jegesmedve" };

			int allatkertMaxMeret = rnd.Next(5,16);

			int allatkertMeret = 0;
			bool marade = true;
			while (marade)
			{
				string allatNev = allatNevek[rnd.Next(0, allatNevek.Length)];
				int meret= rnd.Next(1, 5);
				if (allatkertMeret + meret <= allatkertMaxMeret)
				{
					allatok.Add(new Allat(allatNev, rnd.Next(1, 10), meret));
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
			
        }
	}
}
