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

            ArrayList GOGLIST = new ArrayList();
            try
            {
                string[] GOGDIR = System.IO.Directory.GetDirectories(@GOGGALAXY_DIRECTORY);
                Console.WriteLine("The Number of Game Directories: {0}.", GOGDIR.Length);

                foreach (String dir in GOGDIR)
                {
                    string[] fils = Directory.GetFiles(@dir, "*.lnk");
                    foreach (string s in fils)
                    {
                        GOGLIST.Add(s);
                    }
                    
                }

                PrintValues(GOGLIST);
            }
            catch (Exception e)
            {
                Console.WriteLine("The Process Failed: {0}", e.ToString());
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
    }
}
        
    

 

