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
    public partial class EditElement : Form
    {

        private bool mouseOverLabel5;

        private int animationTick = 0;

        private bool changed = false;

        public EditElement()
        {
            InitializeComponent();
        }

        private void EditElement_Load(object sender, EventArgs e)
        {
            MoveWindow movewindow = new MoveWindow(this, panel1);
            MoveWindow movewindow2 = new MoveWindow(this, label1);
            MoveWindow movewindow3 = new MoveWindow(this, panel4);

            Timer showingAnimation = new Timer();
            showingAnimation.Interval = 1;
            showingAnimation.Tick += new EventHandler(showingAnimationTick);
            showingAnimation.Start();
        }

        private void showingAnimationTick(object sender, EventArgs e)
        {
            if (animationTick == 0)
            {
                this.Opacity = 0;
            }

            if (animationTick <= 11)
            {
                this.Opacity += 0.2;
                animationTick += 2;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            mouseOverLabel5 = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            mouseOverLabel5 = false;
        }

        private void EditElement_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseOverLabel5 == false)
            {
                label5.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changed == true)
            {
                DialogResult result = MessageBox.Show("do you want to exit without saving changes?", "abort editing item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Close();
                }
                else if (result == DialogResult.No)
                {
                    //do nothing
                }
                else
                {
                    MessageBox.Show("an error accured!");
                }
            }
            else
            {
                Close();
            }
        }
    }
}
