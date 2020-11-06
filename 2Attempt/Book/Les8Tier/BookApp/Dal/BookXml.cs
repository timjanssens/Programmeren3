using BookApp.Bll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BookApp.Dal
{
    public class BookXml : IBook
    {
        // Een Book BLL object om de opgehaalde waarden
        // in op te slagen
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

            this.ConnectionString = connectionString;
        }


        /// <summary>
        /// make an XML from the list
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

                XmlRootAttribute xRoot = new XmlRootAttribute();

                if (this.ConnectionString == @"Data/Book.xml")
                {
                    xRoot.ElementName = "Books";
                }
                else
                {
                    xRoot.ElementName = "ArrayOfBook";
                }
                xRoot.IsNullable = true;
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]), xRoot);
                StreamReader file = new StreamReader(ConnectionString);
                Bll.Book[] books = (Bll.Book[])serializer.Deserialize(file);
                file.Close();
                Book.List = new List<Bll.Book>(books);
                Message = $"Bestand {ConnectionString} is met succes gedeserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Het bestand {ConnectionString} s niet gedeserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }
        }


    }
}
