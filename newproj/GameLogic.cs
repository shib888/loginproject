using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Threading;

namespace newproj.view
{
    internal class GameLogic
    {       
        private readonly Random random = new Random();
        private int num1;
        private int num2;
        private int score;
        private string sign;
        private int answer;
        string Name;
        private int QuestionCount = 0;



        public GameLogic()
        {
        }      
        public int randomnum1()
        {
            int rnd1 = random.Next(0, 31);
            
            num1 = rnd1;
            return num1; 
            
        }
      



        public int randomnum2()
        {
            int rnd2 = random.Next(0, 31);

            num2 = rnd2;
            return num2;

        }
        public GameLogic(string userName)
        {
            Name = userName;
        }






        public string Wichsign()
        {
            int kind = random.Next(1, 4);
            switch (kind)
            {
                case 1:
                    sign = "+";
                    break;
                case 2:
                    sign = "-";
                    break;
                case 3:
                    sign = "*";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return sign;

        }
        

     
            
      


        public bool Checkanwer(int num1, int num2, string op,int newanswer)
        {
            bool flag = false;
            try
            {
                int correctAnswer = 0; 

                if (op == "+")
                {
                    correctAnswer = num1 + num2;
                }
                else if (op == "-")
                {
                    correctAnswer = num1 - num2;
                }
                else if (op == "*")
                {
                    correctAnswer = num1 * num2;
                }

             

                if (correctAnswer == newanswer)
                {
                    MessageBox.Show("Correct. Good job " + Name);
                   
                    this.score += 10;
                    flag= true;
                }
                else 
                {
                    MessageBox.Show("Incorrect");

                    
              

                }

            }
            catch
            {
                MessageBox.Show("Enter a valid number");
            }
            return flag;
        }


        public int Getscore()
        {
            return this.score;
        }

    }
}
