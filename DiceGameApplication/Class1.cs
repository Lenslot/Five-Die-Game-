using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameApplication
{
    class MethodClass
    {
        public MethodClass()
        {
        }
     
        public string Result (int hum, int com,int diceHum,int diceCom,int sumhum,int sumcom,int [] human,int[] computer)
        {
             string result = "";
                    if (hum > com)
                    {
                         result = "You won";
                    }
                    if (hum == com && diceHum > diceCom)
                    {
                        result = "You won";
                    }
                    if (com > hum) 
                    {
                         result = "Computer won";
                    }
                    if (hum == 1 && com == 2)
                    {
                        if (diceHum > diceCom)
                        {
                            result = "You won";
                        }
                        else if (diceCom > diceHum)
                        {
                            result = "Computer won";
                        }
                    }
                    if ((hum == 1 && com == 2 && (diceCom == diceHum)) || (hum == 2 && com == 1) && (diceCom == diceHum))
                    {
                        for (int x = 0; x < human.Length; x++)
                        {
                            sumcom = sumcom + computer[x];
                            sumhum = sumhum + human[x];
                        }
                        if (sumhum > sumcom)
                        {
                            result = "You won";
                        }
                        else if (sumcom > sumhum)
                        {
                            result = "Computer won";

                        }
                        else if (sumcom == sumhum)
                        {
                            result = "It a tie";
                        }

                    }

                    if (hum == 2 && com == 1)
                    {
                        if (diceCom > diceHum)
                        {
                            result = "Computer won";
                        }
                        else if (diceHum > diceCom)
                        {
                            result = "You won";
                        }

                    }
                    if (com == hum && diceCom>diceHum)
                        {
                            result = "Computer won";
                        }
                    if (hum == com && diceHum==diceCom)
                    {
                        for (int x = 0; x<human.Length; x++)
                        {
                            sumcom = sumcom + computer[x];
                            sumhum = sumhum + human[x];
                        }
                        if (sumhum > sumcom)
                        {
                            result = "You won";
                        }
                        else if (sumcom > sumhum)
                        {
                            result = "Computer won";

                        }
                        else if (sumhum == sumcom)
                        {
                            result = "It a tie";
                        }

                    }
                    

            return result;
        }
 
        public string Method(int[] arrayNumbers)
        {

            int die1 = 0, die2 = 0, die3 = 0, die4 = 0, die5 = 0, die6 = 0;
            int count = 0, control = 0, diceValue = 0;

            for (int y = 0; y < arrayNumbers.Length; y++)
            {
                if (arrayNumbers[y] == 1)
                {
                    die1 = die1 + 1;
                    if (die1 >= 2)
                    {
                        count = die1;
                        control = control + 1;

                    }
                }
                if (arrayNumbers[y] == 2)
                {
                    die2 = die2 + 1;
                    if (die2 >= 2)
                    {
                        count = die2;
                        control = control + 1;
                    }
                }
                if (arrayNumbers[y] == 3)
                {
                    die3 = die3 + 1;
                    if (die3 >= 2)
                    {
                        count = die3;
                        control = control + 1;
                    }
                }
                if (arrayNumbers[y] == 4)
                {
                    die4 = die4 + 1;
                    if (die4 >= 2)
                    {
                        count = die4;
                        control = control + 1;
                    }
                }
                if (arrayNumbers[y] == 5)
                {
                    die5 = die5 + 1;
                    if (die5 >= 2)
                    {
                        count = die5;
                        control = control + 1;
                    }
                }
                if (arrayNumbers[y] == 6)
                {
                    die6 = die6 + 1;
                    if (die6 >= 2)
                    {
                        count = die6;
                        control = control + 1;

                    }
                }
            }
            if (die1 >= 3)
            {
                count = die1;
                diceValue = 1;
            }
            if (die2 >= 3)
            {
                count = die2;
                diceValue = 2;
            }
            if (die3 >= 3)
            {
                count = die3;
                diceValue = 3;
            }
            if (die4 >= 3)
            {
                count = die4;
                diceValue = 4;
            }
            if (die5 >= 3)
            {
                count = die5;
                diceValue = 5;
            }
            if (die6 >= 3)
            {
                count = die6;
                diceValue = 6;
            }

            if (control == 2 && count != 3)
            {
                count = 1;

            }
            if (die1 == 2) { diceValue = 1; }
            if (die2 == 2) { diceValue = 2; }
            if (die3 == 2) { diceValue = 3; }
            if (die4 == 2) { diceValue = 4; }
            if (die5 == 2) { diceValue = 5; }
            if (die6 == 2) { diceValue = 6; }

            return count.ToString() + " of " + diceValue.ToString();
        }

       
        public string DisplayScore(int num)
        {
            string output = "";

            if (num == 5)
            {
                output = "5 of a Kind";

            }
            if (num == 4)
            {
                output = "4 of a Kind";

            }
            if (num == 3)
            {
                output = "3 of a Kind";

            }

            if (num == 1)
            {
                output = "two pairs";

            }
            if (num == 2)
            {
                output = "pair";

            }
            if (num == 0)
            {
                output = "single";
            }
            return output;
        }
    
    }
    
}
