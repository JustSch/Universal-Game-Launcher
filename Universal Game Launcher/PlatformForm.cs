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
    public partial class PlatformForm : Form
    {
        public string platformString;

        public PlatformForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setPlatformString(string pfString)
        {
            platformString = pfString;
        }

        public string getValue()
        {
            return platformString;  
        }

        
      

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (radioButton1.Checked)
            {
                setPlatformString(radioButton1.Text);
            }

            if (radioButton2.Checked)
            {
                setPlatformString(radioButton2.Text);
                
            }

            this.Close();

        }

        
    }
}
