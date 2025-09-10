namespace KauppaKanta;

using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {
        KauppaDP kauppaDB = new KauppaDP();

        while (true)
        {
            Console.WriteLine("Haluatko lisätä tuotteen? (L), hakea tuotteen (H) vai lopettaa (X)");
            string? vastaus = Console.ReadLine();
            switch (vastaus)
            {
                case "L":
                    Console.WriteLine("Anna tuotteen nimi:");
                    string? nimi = Console.ReadLine();
                    Console.WriteLine("Anna tuotteen hinta:");
                    double hinta = Convert.ToDouble(Console.ReadLine());
                    //Lisätään tuote tietokantaan
                    kauppaDB.LisaaTuote(nimi, hinta);
                    break;
                    
                case "H":
                //Haetaan tuotteet tietokannasta
                    Console.WriteLine("Anna haettavan tuotteen nimi:");
                    string? haettavanimi = Console.ReadLine();
                    string tuotteet = kauppaDB.HaeTuotteet(haettavanimi);
                    Console.WriteLine(tuotteet);
                    break;

                case "X":
                    return;


                default:
                    Console.WriteLine("Väärä syöte, anna L, H tai X.");
                    break;
            }
        }
    }
}
