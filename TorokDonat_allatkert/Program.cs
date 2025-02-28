namespace TorokDonat_allatkert
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Allat p1 = new Allat("Ponty",4,2);
			Allat g1 = new Allat("Görög teknős", 1, 3);
			Allat n1 = new Allat("Nyúl", 5, 2);
			Allat k1 = new Allat("Kaméleon", 2, 1);
			Allat j1 = new Allat("Jegesmedve",6,5);

			int allatkertMeret = rnd.Next(5,16);

		}
	}
}
