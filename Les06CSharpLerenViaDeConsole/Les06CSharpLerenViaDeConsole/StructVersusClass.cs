using System;
using System.Collections.Generic;
using System.Text;

namespace Les06CSharpLerenViaDeConsole
{
    class StructVersusClass
    {

        public static void TabelMetGetallen()
        {
            int number = 1;

            for (int row = 0; row < 10; row++)
            {

                for (int column = 0; column < 10; column++)
                {
                    Console.Write(string.Format("{0,5}", number++));
                }

                Console.WriteLine();
            }
        }


    }
}
