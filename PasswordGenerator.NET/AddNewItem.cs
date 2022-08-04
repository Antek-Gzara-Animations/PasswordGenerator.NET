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
    public partial class AddNewItem : Form
    {
        public AddNewItem()
        {
            InitializeComponent();
        }

        private int animationTick = 0;

        private bool changed = false;

        public char character = '\0';

        private void AddNewItem_Load(object sender, EventArgs e)
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
            if(animationTick == 0)
            {
                this.Opacity = 0;
            }

            if(animationTick <= 11)
            {
                this.Opacity += 0.2;
                animationTick += 2;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changed == true)
            {
                DialogResult result = MessageBox.Show("do you want to exit without saving changes?", "abort adding new item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changed = true;
            characterDisplay.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(changed == true)
            {
                character = char.Parse(textBox1.Text);
            }
        }
    }
}
