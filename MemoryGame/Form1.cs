using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> ikone = new List<string>()
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };

        Label prva, druga;
        public Form1()
        {
            InitializeComponent();
            DodjelitiIkoneKvadratu();
        }

        private void label_Click(object sender, EventArgs e)
        {

            if (prva != null && druga != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;
            if (clickedLabel.ForeColor == Color.Black)
                return;

            if(prva==null)
            {
                prva = clickedLabel;
                prva.ForeColor = Color.Black;
                return;
            }
            druga = clickedLabel;
            druga.ForeColor = Color.Black;

            ProvjeriPobjednika();

            if(prva.Text==druga.Text)
            {
                prva = null;
                druga = null;
            }
            else
              timer1.Start();
        }

        private void ProvjeriPobjednika()
        {
            Label label;
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("Cestitamo, uparili ste sve slicice!");
            Close();           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            prva.ForeColor = prva.BackColor;
            druga.ForeColor = druga.BackColor;

            prva = null;
            druga = null;
        }

        private void DodjelitiIkoneKvadratu()
        {
            Label label;
            int randBroj;
            for(int i =0;i< tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                
                else
                    continue;

                randBroj = random.Next(ikone.Count);
                label.Text = ikone[randBroj];

                ikone.RemoveAt(randBroj);


            }
        }
    }
}
