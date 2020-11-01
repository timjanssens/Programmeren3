using System;
using System.Collections.Generic;
using System.IO;

namespace PostcodeApp.Dal
{
    class PostcodeCsv : IPostcode
    {
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        public Bll.Postcode Postcode { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Postcode";
        public string ConnectionString
        {
            get
            {
                return connectionString + ".csv";
            }
            set
            {
                connectionString = value;
            }
        }

        public char Separator { get; set; } = ';';

        public PostcodeCsv(Bll.Postcode postcode)
        {
            Postcode = postcode;
        }

        public bool ReadAll()
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = ConnectionString;
            if (bestand.Lees())
            {
                string[] postcodes = bestand.Text.Split('\n');
                try
                {
                    List<Bll.Postcode> list = new List<Bll.Postcode>();
                    foreach (string s in postcodes)
                    {
                        if (s.Length > 0)
                        {
                            list.Add(ToObject(s));
                        }
                    }
                    Postcode.List = list;
                    Message = $"Het bestand {ConnectionString} is gedesialiseerd!";
                    return true;
                }
                catch (Exception e)
                {
                    // Melding aan de gebruiker dat iets verkeerd gelopen is.
                    // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                    Message = $"Bestand {ConnectionString} is niet gedeserialiseerd.\nFoutmelding {e.Message}.";
                    return false;
                }
            }
            else
            {
                Message = $"Bestand {ConnectionString} is niet gedeserialiseerd.\nFoutmelding {bestand.Melding}.";
                return false;
            }
        }

        private Bll.Postcode ToObject(string line)
        {
            Bll.Postcode postcode = new Bll.Postcode();
            string[] values = line.Split(Separator);
            postcode.Code = values[0];
            postcode.Plaats = values[1];
            postcode.Provincie = values[2];
            postcode.Localite = values[3];
            postcode.Province = values[4];
            return postcode;
        }

        /// <summary>
        /// De Create van CRUD
        /// In het geval van een CSV bestand wordt de hele List gecreëerd.
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            try
            {
                TextWriter writer = new StreamWriter(ConnectionString);
                foreach (Bll.Postcode item in Postcode.List)
                {
                    // One of the most versatile and useful additions to the C# language in version 6
                    // is the null conditional operator ?.Post           
                    writer.WriteLine("{0}{5}{1}{5}{2}{5}{3}{5}{4}",
                        item?.Code,
                        item?.Plaats,
                        item?.Provincie,
                        item?.Localite,
                        item?.Province,
                        Separator);
                }
                writer.Close();
                Message = $"Het bestand met de naam {ConnectionString} is gemaakt!";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Bestand met naam {ConnectionString} niet gemaakt.\nFoutmelding {e.Message}.";
                return false;
            }
        }

        // Een overload om tegelijkertijd de separator in te stellen
        public bool Create(char separator = ';')
        {
            Separator = separator;
            return Create();
        }
    }
}
