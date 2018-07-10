using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpeedReaction_07072018
{
    public partial class FormReaction : Form
    {
        int cardNr = 1;
        int myCardNr = 0;
        int totalClick = 10;
        int clickNr = -1;
        int reactTime_ms = 0;
        int waiting = 0;
        int minWaiting = 1;
        int maxWeiting = 3;
        Random random = new Random();

        Stopwatch watch = new Stopwatch();

        public FormReaction()
        {
            InitializeComponent();
            progressBar.Maximum = totalClick;
        }

        public void ShowCard(int nr)
        {
            //Random random = new Random();

            pictureBox1.Visible = nr == 1; //random.Next(1, 4) == 1;
            pictureBox2.Visible = nr == 2; //random.Next(1, 4) == 2;
            pictureBox3.Visible = nr == 3; //random.Next(1, 4) == 3;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //cardNr++;
            //if (cardNr > 3) cardNr = 1;

            //cardNr = cardNr % 3 + 1;
            //ShowCard(cardNr);
            if (clickNr < 0) return;
            if (waiting > 0)
            {
                waiting--;
                if (waiting == 0)
                {
                    myCardNr = random.Next(1, 4);
                    ShowCard(myCardNr);
                    watch.Restart();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clickNr = 0;
            reactTime_ms = 0;
            buttonStart.Enabled = false;
            NextClick();
        }

        private void NextClick()
        {
            clickNr++;
            waiting = random.Next(minWaiting * 1000 / timer.Interval, minWaiting * 1000 / timer.Interval + 1);
            ShowCard(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            watch.Stop();
            reactTime_ms += (int)watch.ElapsedMilliseconds;
            progressBar.Value = clickNr;
            if(clickNr >= totalClick)
            {
                ShowResult();
            } else
            {
                NextClick();
            }
        }

        private void ShowResult()
        {
            double sec = reactTime_ms / 1000.0 / totalClick;
            MessageBox.Show("average reaction time: " + sec.ToString("0.000") + "sec.", "Result");
            buttonStart.Enabled = true;
            clickNr = -1;
        }
    }
}
