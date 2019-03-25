using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_Game_Launcher
{
    public partial class DisplayForm : Form
    {
        public int PlayNumber = -1;

        public DisplayForm()
        {
            
            InitializeComponent();

            //for (int i = 0; i < 125; i++)
            //{
            //    Button button = new Button();  //testing code to be removed
            //    button.Tag = i;
            //    button.Text = i.ToString();
            //    flowLayoutPanel1.Controls.Add(button);
            //}
        }

     

        public void addGames(List<KeyValuePair<string, string>> GameFiles)
        {
            int i = 0;
            foreach (KeyValuePair<string, string> game in GameFiles)
            {
                
                
                Button button = new Button(); 
                button.Tag = i;
                button.Text = $"{game.Key}";
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.AutoSize = true;                             //change depending on textsize?
                flowLayoutPanel1.Controls.Add(button);
                i++;
                button.Click += new EventHandler(Button_Click);
                

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            PlayNumber= (int)((Button)sender).Tag;
           
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }
    }
}
