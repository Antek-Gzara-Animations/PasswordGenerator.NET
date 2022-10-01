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
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        private int animationTick = 0;

        private void ResultForm_Load(object sender, EventArgs e)
        {
            MoveWindow movewindow = new MoveWindow(this, panel1);
            MoveWindow movewindow2 = new MoveWindow(this, label1);

            Timer showingAnimation = new Timer();
            showingAnimation.Interval = 1;
            showingAnimation.Tick += new EventHandler(showingAnimationTick);
            showingAnimation.Start();
        }

        public void showResult(List<string> data)
        {
            for(int i = 0; i < data.Count; i++)
            {
                string item = data[i];
                listBox1.Items.Add(item);
            }
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
            this.Close();
        }
    }
}
