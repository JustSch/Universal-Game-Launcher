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
            string input = "_____";
            PlatformForm pff = new PlatformForm();
            pff.ShowDialog();
            input = pff.platformString;

            //pff.Close();
            //Console.WriteLine("Do You Want To Play A Game From Steam or GOG?");
            //input = Console.ReadLine();
            Console.WriteLine(input);
           
            pff.Close();
            if (input.ToLower().Equals("steam"))
            {
                try
                {
                    SteamList.FindSteamList();
                }
                catch (BadInputException e)
                {
                    Console.WriteLine(e.GetType().Name+ ": "+ e.Message);
                    Console.Read();
                }
            }
            if (input.ToLower().Equals("gog"))
            {
                try
                {
                    GOGFiles.FindGOGList();
                }

                catch (BadInputException e)
                {
                    Console.WriteLine(e.GetType().Name+ ": " + e.Message);
                    Console.Read();
                }
            }
            else
            {
                Console.WriteLine("Bad Input");
            }
            
            
  
        }
    }
}
