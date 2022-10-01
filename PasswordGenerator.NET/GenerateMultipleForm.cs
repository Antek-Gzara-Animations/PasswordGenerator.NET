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
    public partial class GenerateMultipleForm : Form
    {
        public GenerateMultipleForm()
        {
            InitializeComponent();
        }

        private int animationTick = 0;

        public int number = 0;

        bool changed = false;

        private void GenerateMultipleForm_Load(object sender, EventArgs e)
        {
            MoveWindow movewindow = new MoveWindow(this, panel1);
            MoveWindow movewindow2 = new MoveWindow(this, label1);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (changed == true)
            {
                DialogResult result = MessageBox.Show("do you want to exit without saving changes?", "abort", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (changed == true)
            {
                number = int.Parse(numericUpDown1.Value.ToString());
                Close();
            }
            else
            {
                MessageBox.Show("enter number into input area or exit without saveing changes using X in upper right corner of your screen", "please enter number", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            changed = true;
        }
    }
}
