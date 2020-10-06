using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Les07DemoTekstbestandInlezen
{
    class TryOut
    {

        public static string ReadFromCSVFile()
        {

            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = @"d:\Programmeren3\postcodes.csv";
            bestand.Lees();
            return bestand.Text;
        }

        public static string ReadPostcodesFromCSVFile()
        {
            Helpers.Tekstbestand bestand = new Helpers.Tekstbestand();
            bestand.FileName = @"D:\Programmeren3\postcodes.csv";
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
            postcode.Locatie = values[3];
            //moet worden weggelaten, staat er reeds in als value[2]
           // postcode.Provincie = values[4];
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
                    postcode?.Locatie,
                    postcode?.Provincie
                    );
            }
        }


    }
}
