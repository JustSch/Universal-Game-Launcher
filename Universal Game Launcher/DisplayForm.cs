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
        public DisplayForm()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                Button button = new Button();  //testing code to be removed
                button.Tag = i;
                button.Text = i.ToString();
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }
    }
}
