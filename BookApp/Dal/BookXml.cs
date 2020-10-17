using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BookApp.Dal
{
    class BookXml : IBook
    {
        public Bll.Book Book { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Book";

        public string ConnectionString
        {
            get { return connectionString + ".xml"; }
            set { connectionString = value; }
        }


        public BookXml(Bll.Book book)
        {
            Book = book;
        }
        /// <summary>
        /// Overload to give name to file
        /// </summary>
        /// <param name="connectionString"></param>
        public BookXml(string connectionString)
        {
           
            ConnectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       

        /// <summary>
        /// if there is an XML the list gets saved
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Bll.Book[]));
                TextWriter writer = new StreamWriter(ConnectionString);
                //serializer does not work with list => make an array
                Bll.Book[] booken = Book.List.ToArray();
                serializer.Serialize(writer, booken);
                writer.Close();

                Message = $"Bestand {ConnectionString} is met succes geserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Make errormessage
                Message = $"Bestand {ConnectionString} is niet geserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }

        }

        public bool ReadAll()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Bll.Book[]));
                StreamReader file = new StreamReader(ConnectionString);
                Bll.Book[] book = (Bll.Book[])serializer.Deserialize(file);
                file.Close();
                // Convert array to List
                Book.List = new List<Bll.Book>(book);
                Message = $"Bestand {ConnectionString} is met succes gedeserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Het bestand {ConnectionString} is niet gedeserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }
        }
    }
}
