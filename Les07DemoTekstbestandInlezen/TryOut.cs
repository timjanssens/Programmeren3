using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace Les07DemoTekstbestandInlezen
{
    class TryOut
    {

        public static string ReadFromCSVFile()
        {

            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = @"Data\postcodes.csv";
            bestand.Lees();
            return bestand.Text;
        }

        public static string ReadPostcodesFromCSVFile()
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = @"Data\postcodes.csv";
            bestand.Lees();
            return bestand.Text;
        }

        public static List<Postcode> GetPostcodeList()
        {

            string[] postcodes = ReadPostcodesFromCSVFile().Split('\n');
            List<Postcode> list = new List<Postcode>();
            foreach (string s in postcodes)
            {
                if (s.Length > 0)
                {
                    list.Add(PostcodeCsvToObject(s));
                }
            }

            return list;
        }
        public static Postcode PostcodeCsvToObject(string line)
        {
            Postcode postcode = new Postcode();
            string[] values = line.Split('|');
            postcode.Code = values[0];
            postcode.Plaats = values[1];
            postcode.Provincie = values[2];
            postcode.Localite = values[3];
            postcode.Province = values[4];
            return postcode;
        }

        public static void ListPostcodes(List<Postcode> list)
        {
            foreach (Postcode postcode in list)
            {
                // One of the most versatile and useful additions to the C# language in version 6
                // is the null conditional operator ?.Post           
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    postcode?.Code,
                    postcode?.Plaats,
                    postcode?.Provincie,
                    postcode?.Localite,
                    postcode?.Province
                    );
            }
        }


        public static string SerializeObjectToCsv(List<Postcode> list, string separator)
        {
            string fileName = @"Data/Postcodes2.csv";
            string message;

            try
            {
                TextWriter writer = new StreamWriter(fileName);
                foreach (Postcode item in list)
                {
                    // One of the most versatile and useful additions to the C# language in version 6
                    // is the null conditional operator ?.           
                    writer.Write("{0}{5}{1}{5}{2}{5}{3}{5}{4}",
                        item?.Code,
                        item?.Plaats,
                        item?.Provincie,
                        item?.Localite,
                        item?.Province,
                        separator);
                }

                message = $"Het bestand met de naam {fileName} is gemaakt!";

            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                message = $"Kan het bestand met de naam {fileName} niet maken.\nFoutmelding {e.Message}.";
            }
            return message;
        }

        public static Postcode[] GetPostcodeArray()
        {
            string[] lines = TryOut.ReadFromCSVFile().Split('\n');
            Postcode[] postcodes = new Postcode[lines.Length];
            int i = 0;
            foreach (string s in lines)
            {
                if (s.Length > 0)
                {
                    postcodes[i++] = TryOut.PostcodeCsvToObject(s);
                }
            }
            return postcodes;
        }


        public static void SerializeCsvToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Postcode[]));
            Postcode postcode = new Postcode(); 
            TextWriter writer = new StreamWriter(@"Data/Postcode.xml");
            //De serializer werkt niet voor een generieke lijst en ook niet voor ArrayList
            Postcode[] postcodes = GetPostcodeArray();
            serializer.Serialize(writer, postcodes);
            writer.Close();
        }



        //En nu nog een methode om de postcodes om te zetten van XML formaat naar een List met Postcode objecten.
        public static List<Postcode> GetPostcodeListFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Postcode[]));
            Postcode postcode = new Postcode(); 
            StreamReader file = new System.IO.StreamReader(@"Data/Postcode.xml");
            Postcode[] postcodes = (Postcode[])serializer.Deserialize(file);
            file.Close();
            // array converteren naar List
            return new List<Postcode>(postcodes);
        }

    } 
}
