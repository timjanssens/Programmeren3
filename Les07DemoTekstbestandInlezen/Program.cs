using System;

namespace Les07DemoTekstbestandInlezen
{
    class Program
    {
        static void Main(string[] args)
        {
            string tekst = TryOut.ReadFromCSVFile();

            Console.WriteLine(tekst);


            Console.WriteLine(TryOut.ReadPostcodesFromCSVFile());
            // zet stringvoorstelling postcodes om in een lijst
            // van postcode-objecten en toon de lijst in de console
            TryOut.ListPostcodes(TryOut.GetPostcodeList());


            Console.WriteLine(TryOut.SerializeObjectToCsv(TryOut.GetPostcodeList(), "|"));


            TryOut.SerializeCsvToXml();
            TryOut.ListPostcodes(TryOut.GetPostcodeListFromXml());

            Console.ReadKey();
        }
    }

}
