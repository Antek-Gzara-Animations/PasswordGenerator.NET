using System;
using System.Windows.Forms;


namespace PasswordGenerator.NET
{
    public partial class Form1 : Form
    {
        private Main main;

        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            MoveWindow moveWindow = new MoveWindow(this, upperPanel);
            MoveWindow moveWindow1 = new MoveWindow(this, label1);
            MoveWindow moveWindow2 = new MoveWindow(this, label2);
            MoveWindow moveWindow3 = new MoveWindow(this, label3);
              
            //create main form
            main = new Main();

            //load main window after a delay
            timer.Tick += new EventHandler(loadMain);
            timer.Interval = 3000;
            timer.Start();
        }

        private void loadMain(object sender, EventArgs e)
        {
            main.Show();
            this.Hide();
            timer.Stop();
        }
    }
}