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
            
            ArrayList SteamFiles = new ArrayList();
            int GAMENUM = 0;
            int LAUNCHNUM = 0;
            try
            {
                string[] ACFFILES = System.IO.Directory.GetFiles(@STEAM_DIRECTORY, "*.acf");
                //PrintValues(ACFFILES);
                foreach (string s in ACFFILES)
                {
                    string[] fileArray = new string[6];
                    fileArray = ACFREAD(ACFFILES,GAMENUM);
                    SteamFiles.Add(fileArray[5]);
                    SteamFiles.Add(fileArray[1]);
                    GAMENUM++;
                  
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The Process Failed: {0}", e.ToString());
            }

            
            foreach (string i in SteamFiles)
            {
                Console.WriteLine("{0}", i + " " + LAUNCHNUM);
                LAUNCHNUM++;
            }
            

            Console.WriteLine("Please Choose The Number For The Game You Want To Play");
            if (int.TryParse(Console.ReadLine(), out int PlayNum))
            {
                Console.WriteLine("Now Launching:--------------------------------------" + SteamFiles[PlayNum]);

                Process.Start("steam://rungameid/"+ Convert.ToString(SteamFiles[PlayNum + 1 ]));
            }
            else
            {
                Console.WriteLine("Bad Input");
            }
            
            Console.Read();

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

        public static string[] ACFREAD(String [] ACFFILES,int GAMENUM) 
        {
            int lineNum = 0;
            int oarrayNum = 0;
            
            string[] fileArray = new string[6];
            string[] parsedArray = new string[2];
            string lineString;

            System.IO.StreamReader file = new System.IO.StreamReader(ACFFILES[GAMENUM]);

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
                //Console.WriteLine("Parsed String: " + ParsedString);
                parsedArray[ARPLACE] = ParsedString;
                ARPLACE++;

            }
           return parsedArray;
        }

    }

}
