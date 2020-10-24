using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Helpers
{
    class Tekstbestand
    {
        //Properties
        public string Text { get; set; }
        public string Melding { get; set; }
        public string FileName { get; set; }

        public bool Lees()
        {
            //assume that it goes wrong
            bool result = false;

            try
            {
                //create an instance from the StreamReader class to read the file
                //The using statement also closes the StreamReader
                using (StreamReader sr = new StreamReader(this.FileName))
                {
                    this.Text = sr.ReadToEnd();
                    this.Melding = string.Format($"Het bestand met de naam {this.FileName} is ingelezen. Het bevat {this.Text.Length} karakters en {this.Text.Split(';')} woorden en {this.Text.Split('\n').Length} regels.");
                 
                    result = true;
                }
            }
            catch (Exception e)
            {
                this.Melding = $"Kan het bestand met de naam {this.FileName} niet inlezen. \nFoutmelding: {e.Message}.";
            }

            return result;

        }

    }
}
