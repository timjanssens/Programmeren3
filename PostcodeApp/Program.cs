using System;

namespace PostcodeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TryOutCsv();
            TryOutXml();
            TryOutJson();
            Console.ReadLine();
        }

        static void TryOutCsv()
        {
            Console.WriteLine("De Postcode App CSV");
            Bll.Postcode postcode = new Bll.Postcode();
            Dal.PostcodeCsv postcodeCsv = new Dal.PostcodeCsv(postcode);
            // de seperator staat standaard op ;
            // in het Postcode.csv bestand is dat |
            postcodeCsv.Separator = ';';
            postcodeCsv.Postcode = postcode;
            postcodeCsv.ReadAll();
            Console.WriteLine(postcodeCsv.Message);
            View.PostcodeConsole view = new View.PostcodeConsole(postcode);
            view.List();
            // serialize postcodes met een andere separator
            // naar ander bestand
            postcodeCsv.ConnectionString = "Data/Postcode2";
            postcodeCsv.Create(';');
            Console.WriteLine(postcodeCsv.Message);
        }

        static void TryOutXml()
        {
            Console.WriteLine("De Postcode App XML");
            Bll.Postcode postcode = new Bll.Postcode();
            Dal.PostcodeXml postcodeXml = new Dal.PostcodeXml(postcode);
            postcodeXml.Postcode = postcode;
            postcodeXml.ReadAll();
            Console.WriteLine(postcodeXml.Message);
            View.PostcodeConsole view = new View.PostcodeConsole(postcode);
            view.List();
            // serialize naar ander bestand
            postcodeXml.ConnectionString = "Data/Postcode2";
            postcodeXml.Create();
            Console.WriteLine(postcodeXml.Message);
        }

        static void TryOutJson()
        {
            Console.WriteLine("De Postcode App Json");
            Bll.Postcode postcode = new Bll.Postcode();
            Dal.PostcodeJson postcodeJson = new Dal.PostcodeJson(postcode);
            postcodeJson.Postcode = postcode;
            postcodeJson.ReadAll();
            Console.WriteLine(postcodeJson.Message);
            View.PostcodeConsole view = new View.PostcodeConsole(postcode);
            view.List();
            // serialize naar ander bestand
            postcodeJson.ConnectionString = "Data/Postcode2";
            postcodeJson.Create();
            Console.WriteLine(postcodeJson.Message);
        }
    }
}