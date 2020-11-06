using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helpers

{
    class Tekstbestand
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string melding;

        public string Melding
        {
            get { return melding; }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                this.fileName = value;
            }
        }

        public bool Lees()
        {
            // we gaan ervan uit dat er iets misloopt
            bool result = false;
            try
            {
                // Creëer een instantie van de StreamReader klasse om 
                // een bestand in te lezen. 
                // Het using statement sluit ook de StreamReader. 
                using (StreamReader sr = new StreamReader(this.fileName))
                {
                    // Lees tot het einde van het bestand
                    this.text = sr.ReadToEnd();
                    this.melding = String.Format(
                        "Het bestand met de naam {0} is ingelezen.Het bevat {1} karakters en {2} woorden en {3} regels.",
                        this.fileName, this.text.Length, this.text.Split(' ').Length, this.text.Split('\n').Length);
                    result = true;
                }
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                this.melding = $"Kan het bestand met de naam {this.fileName} niet inlezen.\nFoutmelding {e.Message}.";
            }
            return result;
        }
    }
}
