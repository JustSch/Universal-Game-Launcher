﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Launcher
{
    public class SteamList
    {
        public static void FindSteamList()
        {
            var STEAM_DIRECTORY = "d:\\SteamLibrary\\steamapps";

            var SteamFiles = new List<KeyValuePair<string, string>>();
            int GAMENUM = 0;
            int LAUNCHNUM = 0;
            try
            {
                string[] ACFFILES = System.IO.Directory.GetFiles(@STEAM_DIRECTORY, "*.acf");
                //PrintValues(ACFFILES);
                foreach (string s in ACFFILES)
                {
                    string[] fileArray = new string[6];
                    fileArray = ACFREAD(ACFFILES, GAMENUM);
                    SteamFiles.Add(new KeyValuePair<string, string>(fileArray[5], fileArray[1]));
                    GAMENUM++;

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The Process Failed: {0}", e.ToString());
            }


            foreach (KeyValuePair<string, string> steam in SteamFiles)
            {
                Console.WriteLine($"{steam.Key}" + " " + LAUNCHNUM);
                LAUNCHNUM++;
            }


            Console.WriteLine("Please Choose The Number For The Game You Want To Play");
            if (int.TryParse(Console.ReadLine(), out int PlayNum))
            {
                Console.WriteLine("Now Launching:--------------------------------------" + SteamFiles[PlayNum].Key);

                Process.Start("steam://rungameid/" + Convert.ToString(SteamFiles[PlayNum].Value));
            }
            else
            {
                //Console.WriteLine("Bad Input");
                throw (new BadInputException("Please Make Sure to put a number 0 -" + SteamFiles.Count));
                

            }

            Console.Read();

        }


        private static void PrintValues(System.Collections.IEnumerable myList)
        {
            int num = 0;
            foreach (String obj in myList)
            {
                Console.WriteLine("   {0} ", obj + num);
                num++;
            }
            Console.WriteLine();

        }

        private static string[] ACFREAD(String[] ACFFILES, int GAMENUM)
        {
            int lineNum = 0;
            int oarrayNum = 0;

            string[] fileArray = new string[6];
            string[] parsedArray = new string[2];
            string lineString;

            System.IO.StreamReader file = new System.IO.StreamReader(ACFFILES[GAMENUM]);

            file.ReadLine();
            file.ReadLine();
            while (lineNum < 3)
            {
                lineString = file.ReadLine();
                //Console.WriteLine(lineString);
                int arrayNum = 0;
                parsedArray = ACFPARSE(lineString);
                while (arrayNum < 2)
                {
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

        private static string[] ACFPARSE(string ParseString)
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
