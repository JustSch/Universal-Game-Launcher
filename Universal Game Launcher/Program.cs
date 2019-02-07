using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var STEAM_DIRECTORY = "d:\\SteamLibrary\\steamapps";
            string[] fileArray = new string[6];
            try
            {
                string[] ACFFILES = System.IO.Directory.GetFiles(@STEAM_DIRECTORY, "*.acf");
                PrintValues(ACFFILES);
                ACFREAD(ACFFILES);


            }

            catch (Exception e)
            {
                Console.WriteLine("The Process Failed: {0}", e.ToString());
            }


        }


        public static void PrintValues(System.Collections.IEnumerable myList)
        {
            
            foreach (Object obj in myList)
            {
                Console.WriteLine("   {0} ", obj); 
            }
            Console.WriteLine();
            
        }

        public static void ACFREAD(String [] ACFFILES) 
        {
            int lineNum = 0;
            string lineString;

            System.IO.StreamReader file = new System.IO.StreamReader(ACFFILES[4]);

            file.ReadLine();
            file.ReadLine();
            while (lineNum < 3) {
                lineString = file.ReadLine();
                //Console.WriteLine(lineString);
                ACFPARSE(lineString);

                lineNum++;
            }

            file.Close();
            Console.Read();

        }

        public static void ACFPARSE(string ParseString)
        {
            var reg = new System.Text.RegularExpressions.Regex("\".*?\"");
            var matches = reg.Matches(ParseString);
            Console.WriteLine(matches.Count);
            foreach (var item in matches)
            {
                string ParsedString = item.ToString().TrimStart('\"').TrimEnd('\"');
                Console.WriteLine("Parsed String: " + ParsedString);
                
                
            }
        }

        public string[] StingArray()

    }
    
}
