using BookApp.Bll;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BookApp.Dal
{
    class BookJson : IBook
    {
        public Bll.Book Book { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Book";
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
        public BookJson(Bll.Book book)
        {
            Book = book;
        }

        // een overload om de naam van het csv bestand in te stellen
        public BookJson(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool Create()
        {
            try
            {
                TextWriter writer = new StreamWriter(ConnectionString);
                // static method SerilizeObject van Newtonsoft.Json
                string bookString = Newtonsoft.Json.JsonConvert.SerializeObject(Book.List);
                writer.WriteLine(bookString);
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

                Book.List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bll.Book>>(bestand.Text);

                Message = $"Het bestand met de naam {ConnectionString} is met succes gedeserialiseerd.";
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


    }
}
