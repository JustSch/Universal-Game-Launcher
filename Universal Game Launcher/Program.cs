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
            pff.Text = "Game Platform Selection";
            pff.ShowDialog();
            input = pff.platformString;

            //pff.Close();
            //Console.WriteLine("Do You Want To Play A Game From Steam or GOG?");
            //input = Console.ReadLine();
            Console.WriteLine(input);
           
            //pff.Close();
            //DisplayForm df = new DisplayForm();
            //df.ShowDialog();


            if (input.ToLower().Equals("steam"))
            {
                try
                {
                    SteamList.FindSteamList();
                }
                catch (BadInputException e)
                {
                    //Console.WriteLine(e.GetType().Name+ ": "+ e.Message);//make these messageDialogs
                    System.Windows.Forms.MessageBox.Show(e.GetType().Name + ": " + e.Message,"Error:");
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
                    //Console.WriteLine(e.GetType().Name+ ": " + e.Message);
                    System.Windows.Forms.MessageBox.Show(e.GetType().Name + ": " + e.Message,"Error");
                    Console.Read();
                }
            }
            else
            {
                //Console.WriteLine("Bad Input");
                System.Windows.Forms.MessageBox.Show("Bad Input: Your Input Was Bad And You Should Feel Bad","Error:");
            }
            
            
  
        }
    }
}
