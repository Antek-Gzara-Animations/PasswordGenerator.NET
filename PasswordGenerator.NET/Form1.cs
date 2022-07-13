using System;
using System.Windows.Forms;


namespace PasswordGenerator.NET
{
    public partial class Form1 : Form
    {
        private Main main;

        Timer timer = new Timer();
        Timer timer2 = new Timer();

        private int timerTick = 1;

        public Form1()
        {
            InitializeComponent();
            MoveWindow moveWindow = new MoveWindow(this, upperPanel);
            MoveWindow moveWindow1 = new MoveWindow(this, label1);
            MoveWindow moveWindow2 = new MoveWindow(this, label2);
            MoveWindow moveWindow3 = new MoveWindow(this, label3);
              
            //create main form
            main = new Main();
            main.FormClosed += new FormClosedEventHandler(mainClosed);

            //load main window after a delay
            timer.Tick += new EventHandler(loadMain);
            timer.Interval = new Random().Next(2000, 6000);
            timer.Start();

            timer2.Tick += new EventHandler(Tick);
            timer2.Interval = 300;
            timer2.Start();
        }

        private void loadMain(object sender, EventArgs e)
        {
            timer.Stop();
            timer2.Stop();
            main.Show();
            this.Hide();
        }

        private void Tick(object sender, EventArgs e)
        {
            string output = "Loading ";
            timerTick ++;

            for(int i = 0; i < timerTick; i++)
            {
                output += ".";
            }

            if(timerTick > 3){ timerTick = 0; }

            label3.Text = output;
        }

        private void mainClosed(object sender, FormClosedEventArgs e) { Close(); }
    }
}