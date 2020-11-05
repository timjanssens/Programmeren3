using System;



namespace DotNetCore.Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TryOut.ReadPostcodesFromCSVFile());
            // zet stringvoorstelling postcodes om in een lijst
            // van postcode-objecten en toon de lijst in de console
           
            TryOut.ListPostcodes(TryOut.GetPostcodeList());
            
            Console.WriteLine(TryOut.SerializeObjectToCsv(TryOut.GetPostcodeList(), "|"));


            TryOut.SerializeCsvToXml();
            TryOut.ListPostcodes(TryOut.GetPostcodeListFromXml());

            TryOut.SerializeCsvToJson();
            TryOut.ListPostcodes(TryOut.GetPostcodeListFromJson());

            Console.ReadKey();
        }
    }
}
