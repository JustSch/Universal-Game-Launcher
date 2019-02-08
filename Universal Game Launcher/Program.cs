using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            ArrayList SteamFiles = new ArrayList();
            try
            {
                string[] ACFFILES = System.IO.Directory.GetFiles(@STEAM_DIRECTORY, "*.acf");
                PrintValues(ACFFILES);
                fileArray = ACFREAD(ACFFILES);
                SteamFiles.Add(fileArray[5]);
                SteamFiles.Add(fileArray[1]);
            }

            catch (Exception e)
            {
                Console.WriteLine("The Process Failed: {0}", e.ToString());
            }

            Console.WriteLine("Now Launching:--------------------------------------");
            foreach (string i in SteamFiles)
            {
                Console.WriteLine("{0}", i);
            }
            Console.Read();
            Process.Start("steam://rungameid/"+ Convert.ToString(SteamFiles[1]));

            
        }


        public static void PrintValues(System.Collections.IEnumerable myList)
        {
            int num = 0;
            foreach (String obj in myList)
            {
                Console.WriteLine("   {0} ", obj + num);
                num++;
            }
            Console.WriteLine();
            
        }

        public static string[] ACFREAD(String [] ACFFILES) 
        {
            int lineNum = 0;
            int oarrayNum = 0;
            
            string[] fileArray = new string[6];
            string[] parsedArray = new string[2];
            string lineString;

            System.IO.StreamReader file = new System.IO.StreamReader(ACFFILES[15]);

            file.ReadLine();
            file.ReadLine();
            while (lineNum < 3) {
                lineString = file.ReadLine();
                //Console.WriteLine(lineString);
                int arrayNum = 0;
                parsedArray = ACFPARSE(lineString);
                while (arrayNum < 2) {
                    fileArray[oarrayNum] = parsedArray[arrayNum];
                    arrayNum++;
                    oarrayNum++;
                }               

                lineNum++;
            }

            file.Close();
            //Console.Read();
            return fileArray;

        }

        public static string[] ACFPARSE(string ParseString)
        {
            var reg = new System.Text.RegularExpressions.Regex("\".*?\"");
            var matches = reg.Matches(ParseString);
            int ARPLACE = 0;
            string[] parsedArray = new string[2];
            foreach (var item in matches)
            {
                string ParsedString = item.ToString().TrimStart('\"').TrimEnd('\"');
                Console.WriteLine("Parsed String: " + ParsedString);
                parsedArray[ARPLACE] = ParsedString;
                ARPLACE++;
                
                
            }
           return parsedArray;
        }

        



    }

}
