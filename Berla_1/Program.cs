using System.IO;
using System.Threading.Channels;

namespace Berla_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's get started!");
            //Take each individual digit, square it, and then sum the squares to get a new number.
            //Repeat with the new number and eventually, you might get to a number whose squared sum is 1.

            int iHoldSum = 0;
            //string strSqrTotal = "7";
            //string strSqrTotal = "986543210";     //Perhaps the trailing 0 messed up parsing from the file.. Nope... Forgot to clear lList between iterations...
            //string strSqrTotal = "2";
            //string strSqrTotal = "3";
            List<int> lList = new List<int>();

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}berla_input_Test.txt");
            var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}berla_new_output.txt", false);  //Set to overwrite existing.

            while (!reader.EndOfStream)
            {                
                var lineFromFile = reader.ReadLine();
                Console.WriteLine("Line from file: " + lineFromFile);
                string strSqrs2Total = lineFromFile.ToString();     //ReadLine already returns as string, but extra clarity??
                iHoldSum = 0;
                lList.Clear();

                do
                {
                    lList.Add(iHoldSum);        //If you encounter a number that has been encountered previously..., you should do it over & over...
                    iHoldSum = 0;
                    foreach (char strLetter in strSqrs2Total)
                    {
                        int iTempNum = 0;
                        iTempNum = int.Parse(strLetter.ToString());
                        iTempNum *= iTempNum;
                        iHoldSum += iTempNum;

                        //iTempNum = int(Math.Pow(10, iTempNum));
                        //Console.WriteLine(strLetter);                    
                    }
                    Console.WriteLine(iHoldSum);
                    if (iHoldSum == 1)
                    {
                        break;
                    }
                    strSqrs2Total = iHoldSum.ToString();
                }
                while (!lList.Contains(iHoldSum));

                if (iHoldSum == 1)
                {
                    Console.WriteLine("Hammy times!!");
                    writer.WriteLine("happy");
                }
                else
                {
                    Console.WriteLine("Saddy times!!");
                    writer.WriteLine("sad");
                }
            }

            reader.Close();
            writer.Close();
            Console.ReadKey();

        }
    }
}

//Cross-check by hand.
//sum 7
//sum 49
//sum 16+81=97
//sum 81+49=130
//sum 1+9+0=10
//sum 1+0=1

