using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceGameApplication
{
    public partial class Form1 : Form
    {
        Image[] DiceImage;
        MethodClass obj = new MethodClass();
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams

        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x02000000;
                return param;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Five Die Game is a game played by rolling/tossing 5 die.\nThe winner is decided based on the following hierachy of Die values.Any higher combination beats a lower one.\nExampe:\n> 5 of a kind beats 4 of a kind\n> 4 a kind beats 3 of a kind\n>3 of kind beats a pair ect.\n> If the combinations are the same,the die values are counted and the one with the highest value wins","Game Rules",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Five Die Game\nDeveloped by Lenslot Hlengwa\nDate:24 August 2021", "Game Developement Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Declarations of computer variables 
        int countCom = 0, sumComputer = 0, computer, computerdice;
        int[] arrayComputer = new int[5];

        //Declaration of human variables
        int countHum=0, sumHuman=0, human=0, dicehuman=0;
        int[] arrayHuman = new int[5];
        
        private async void PlayButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if(countHum>0 || countCom > 0)
                {
                    await ReplayAsync();
                }
                else
                {
                    await HumanPlayAsync();
                }
             }
            
            catch (System.Exception x)
            {
                Console.Error.WriteLine(x.Message);
            }
        }

        private async Task HumanPlayAsync()
        {
            for (int x = 0; x < arrayHuman.Length; x++)
            {
                arrayHuman[x] = rand.Next(1, 7);
            }
            await Task.Delay(700);
            label1die.Image = DiceImage[arrayHuman[0]];
            label2die.Image = DiceImage[arrayHuman[1]];
            label3die.Image = DiceImage[arrayHuman[2]];
            label4die.Image = DiceImage[arrayHuman[3]];
            label5die.Image = DiceImage[arrayHuman[4]];

            string valuehuman = obj.Method(arrayHuman);
            human = Convert.ToInt32(valuehuman.Substring(0, 1));
            dicehuman = Convert.ToInt32(valuehuman.Substring(5));
            string humanscore = obj.DisplayScore(human);
            playerScore.Text = humanscore.ToString();


            await ComputerPlay();
        }

        private async Task ComputerPlay()
        {
            computerScore.Text = "Waiting for result";
            for (int y = 0; y < arrayComputer.Length; y++)
            {
                arrayComputer[y] = rand.Next(1, 7);
            }
            await Task.Delay(2000);
            label6die.Image = DiceImage[arrayComputer[0]];
            label7die.Image = DiceImage[arrayComputer[1]];
            label8die.Image = DiceImage[arrayComputer[2]];
            label9die.Image = DiceImage[arrayComputer[3]];
            label10die.Image = DiceImage[arrayComputer[4]];

            string computervalue = obj.Method(arrayComputer);
            computer = Convert.ToInt32(computervalue.Substring(0, 1));
            computerdice = Convert.ToInt32(computervalue.Substring(5));
            string computerscore = obj.DisplayScore(computer);
            computerScore.Text = computerscore.ToString();
            await GameResult();
        }

        private async Task GameResult()
        {
       
            await Task.Delay(1000);
            string gameresult = obj.Result(human, computer, dicehuman, computerdice, sumHuman, sumComputer, arrayHuman, arrayComputer);
            if (gameresult.Equals("You won"))
            {
                timer1.Start();
                userControl11.Show();
                userControl11.BackgroundImage = Properties.Resources.boardpicture;
                label4.Image = Properties.Resources.giphy;

                label4.Show();
                countHum++;
            }
            if (gameresult.Equals("Computer won"))
            {
                timer1.Start();
                userControl11.Show();
                userControl11.BackgroundImage = Properties.Resources.download;
                countCom++;
            }

            playerNoWin.Text = countHum.ToString();
            ComputerNoWin.Text = countCom.ToString();
            labelResult.Text = gameresult;
            PlayButton.Text = "Roll Again";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ResetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            countCom = 0;
            countHum=0;
            playerNoWin.Text = "";
            ComputerNoWin.Text = "";
            PlayButton.Text = "Roll Dice";
            
        }

        private void Reset()
        {
            label1die.Image = DiceImage[0];
            label2die.Image = DiceImage[0];
            label3die.Image = DiceImage[0];
            label4die.Image = DiceImage[0];
            label5die.Image = DiceImage[0];
            label6die.Image = DiceImage[0];
            label7die.Image = DiceImage[0];
            label8die.Image = DiceImage[0];
            label9die.Image = DiceImage[0];
            label10die.Image = DiceImage[0];

            labelResult.Text = "";
            playerScore.Text = "";
            computerScore.Text = "";
        }

        private async Task ReplayAsync()
        {
            Reset();
            await HumanPlayAsync();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            userControl11.Hide();
            label3.Hide();
            label4.Hide();
            label6.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiceImage = new Image[7];
            DiceImage[0] = Properties.Resources.blankdie;
            DiceImage[1] = Properties.Resources.bdie1;
            DiceImage[2] = Properties.Resources.bdie2;
            DiceImage[3] = Properties.Resources.bdie3;
            DiceImage[4] = Properties.Resources.bdie4;
            DiceImage[5] = Properties.Resources.bdie5;
            DiceImage[6] = Properties.Resources.bdie6;
            timer1.Start();
            label4.Hide();
        }
    }
}
