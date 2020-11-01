using System;
using System.Collections.Generic;
using System.Text;

namespace PostcodeApp
{
    class App
    {
        private readonly Dal.IPostcode dal;

        public App(Dal.IPostcode postcodeDal)
        {
            this.dal = postcodeDal;
        }

        public void TryOut()
        {
            Console.WriteLine("De Postcode App");
            // de seperator staat standaard op ;
            // in het Postcode.csv bestand is dat |
            dal.Separator = ';';
            dal.ReadAll();
            Console.WriteLine(dal.Message);
            View.PostcodeConsole view = new View.PostcodeConsole(dal.Postcode);
            view.List();
            // serialize postcodes met een andere separator
            // naar ander bestand
            dal.ConnectionString = "Data/Postcode2";
            dal.Create(';');
            Console.WriteLine(dal.Message);
        }
    }
}
