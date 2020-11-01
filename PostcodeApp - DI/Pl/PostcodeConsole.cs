using System;
using System.Collections.Generic;
using System.Text;

namespace PostcodeApp.View
{
    class PostcodeConsole
    {
        public Bll.Postcode Model { get; set; }

        public PostcodeConsole(Bll.Postcode postcode)
        {
            Model = postcode;
        }

        public void List(Bll.Postcode postcode)
        {
            Model = postcode;
        }

        public void List()
        {
            foreach (Bll.Postcode postcode in Model.List)
            {
                // One of the most versatile and useful additions to the C# language in version 6
                // is the null conditional operator ?.Post           
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    postcode?.Code,
                    postcode?.Plaats,
                    postcode?.Provincie,
                    postcode?.Localite,
                    postcode?.Province);
            }
        }
    }
}