using System;
using System.Windows.Forms;

namespace SpeedReaction_07072018
{
    public partial class FormReaction : Form
    {
        int cardNr = 1;

        public FormReaction()
        {
            InitializeComponent();
        }

        public void ShowCard(int nr)
        {
            Random random = new Random();

            pictureBox1.Visible = random.Next(1, 4) == 1;//nr == 1;
            pictureBox2.Visible = random.Next(1, 4) == 2; //nr == 2;
            pictureBox3.Visible = random.Next(1, 4) == 3; //nr == 3;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //cardNr++;
            //if (cardNr > 3) cardNr = 1;

            cardNr = cardNr % 3 + 1;
            ShowCard(cardNr);
        }
    }
}
