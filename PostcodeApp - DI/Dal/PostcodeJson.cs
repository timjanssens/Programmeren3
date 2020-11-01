using System;
using System.Collections.Generic;
using System.IO;

namespace PostcodeApp.Dal
{
    class PostcodeJson : IPostcode
    {
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        public Bll.Postcode Postcode { get; set; }
        // Error message
        public string Message { get; set; }
        public char Separator { get; set; } = ';';
        private string connectionString = @"Data/Postcode";
        public string ConnectionString
        {
            get
            {
                return connectionString + ".json";
            }
            set
            {
                connectionString = value;
            }
        }
        public PostcodeJson(Bll.Postcode postcode)
        {
            Postcode = postcode;
        }

        // een overload om de naam van het csv bestand in te stellen
        public PostcodeJson(string connectionString)
        {
            ConnectionString = connectionString;
        }
        /// <summary>
        /// In het geval van JSON wordt heel de List gesaved
        /// </summary>
        public bool Create()
        {
            try
            {
                TextWriter writer = new StreamWriter(ConnectionString);
                // static method SerilizeObject van Newtonsoft.Json
                string postcodeString = Newtonsoft.Json.JsonConvert.SerializeObject(Postcode.List);
                writer.WriteLine(postcodeString);
                writer.Close();
                Message = $"Het bestand met de naam {ConnectionString} is met succes geserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Kan het bestand met de naam {ConnectionString} niet serialiseren.\nFoutmelding {e.Message}.";
                return false;
            }
        }

        public bool ReadAll()
        {
            try
            {
                Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
                bestand.FileName = ConnectionString;
                bestand.Lees();
                Postcode.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bll.Postcode>>(bestand.Text);
                Message = $"Het bestand met de naam {ConnectionString} is met succes geserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Kan het bestand met de naam {ConnectionString} niet deserialiseren.\nFoutmelding {e.Message}.";
                return false;
            }

        }

        public bool Create(char separator = ';')
        {
            Separator = separator;
            return Create();
        }
    }
}