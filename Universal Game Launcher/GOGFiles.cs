using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Launcher
{
    class GOGFiles
    {
        public static void FindGOGList()
        {

            string GOGGALAXY_DIRECTORY = "d:\\Program Files (x86)\\GOG Galaxy\\Games";

            var GOGList = new List<KeyValuePair<string, string>>();
            int LAUNCHNUM = 0;
            try
            {
                string[] GOGDIR = System.IO.Directory.GetDirectories(@GOGGALAXY_DIRECTORY);
                //Console.WriteLine("The Number of Game Directories: {0}.", GOGDIR.Length);

                foreach (string dir in GOGDIR)
                {
                    
                    string[] fils = Directory.GetFiles(@dir, "*.lnk");
                    

                    foreach (string s in fils)
                    {
                        //Console.WriteLine(s);
                        GOGList.Add(new KeyValuePair<string, string>(GOGName(s), s));

                    }
                    
                }

                foreach (KeyValuePair<string, string> gog in GOGList)
                {
                    Console.WriteLine(gog.Key + " "+ LAUNCHNUM);
                    LAUNCHNUM++;
                }

                int PlayNumb = 0; // make no answer 0?
                DisplayForm df = new DisplayForm();
                df.Text = "GOG Games";
                df.addGames(GOGList);
                df.ShowDialog();
                PlayNumb = df.PlayNumber;
                Console.WriteLine(PlayNumb);

                Console.WriteLine("Choose A Game To Play: ");
                if (PlayNumb < GOGList.Count)
                {
                    Console.WriteLine("Now Launching:--------------------------------------" + GOGList[PlayNumb].Key);

                    System.Diagnostics.Process.Start((GOGList[PlayNumb].Value));
                }
                else
                {
                 
                    throw (new BadInputException("Please Make Sure to put a number 0 - " + GOGList.Count));
                }



                Console.Read();
            }
            catch (Exception e)
            {
                //Console.WriteLine("The Process Failed: {0}", e.ToString());
                System.Windows.Forms.MessageBox.Show(e.GetType().Name + ": " + e.Message,"Error");
            }




            Console.Read();

        }
        public static void PrintValues(System.Collections.IEnumerable myList)
        {
            int num = 0;
            foreach (string obj in myList)
            {
                Console.WriteLine("   {0} ", obj + " " + num);
                num++;
            }
            Console.WriteLine();

        }
        public static string GOGName(string FileString)
        {
            string FileName = FileString.Substring(FileString.LastIndexOf('\\')).Substring(8);
            FileName = FileName.Substring(0, FileName.Length - 4);

            return FileName;
        }
    }
}
        
    

 

