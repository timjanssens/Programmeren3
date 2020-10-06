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
            bestand.FileName = @"D:\Programmeren3\postcodes.csv";
            bestand.Lees();
            return bestand.Text;
        }
    }
}
