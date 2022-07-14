using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator.NET
{
    public partial class Main : Form
    {
        List<Panel> squareImages = new List<Panel>();

        public Main()
        {
            InitializeComponent();

            //create timer for square images to be equal
            Timer squareImagesTimer = new Timer();
            squareImagesTimer.Interval = 100;
            squareImagesTimer.Tick += new EventHandler(squareImagesTimer_Tick);
            squareImagesTimer.Start();

            //add logo to square images list to change its size activelly
            squareImages.Add(logo1);
        }

        private void generatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generate();
        }


        private void generate()
        {
            
        }

        private void generateMultiple()
        {

        }

        private void generateMultiplePasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateMultiple();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void squareImagesTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < squareImages.Count; i++)
            {
                squareImages[i].Size = new Size(squareImages[i].Size.Width, squareImages[i].Size.Width);
            }
        }

        private void GeneratePassword_Click(object sender, EventArgs e)
        {
            generate();
        }
    }
}
