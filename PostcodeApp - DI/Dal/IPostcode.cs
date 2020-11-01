using System;
using System.Collections.Generic;
using System.Text;

namespace PostcodeApp.Dal
{
    public interface IPostcode
    {
        // Property signatures:
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        Bll.Postcode Postcode { get; set; }
        // Error message
        string Message { get; set; }
        string ConnectionString { get; set; }
        public char Separator { get; set; }

        // method signatures
        bool Create();
        bool Create(char separator);
        bool ReadAll();
    }
}
