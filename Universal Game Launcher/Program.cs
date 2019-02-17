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
            Console.WriteLine("Do You Want To Play A Game From Steam or GOG?");
            input = Console.ReadLine();
            if (input.ToLower().Equals("steam"))
            {
                SteamList.FindSteamList();
            }
            if (input.ToLower().Equals("gog"))
            {
                GOGFiles.FindGOGList();
            }
            else
            {
                throw new BadInputException();
            }
            
            
  
        }
    }
}
