using newproj;
using newproj.view;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace newproj
{
    public partial class Window1 : Window
    {
        private readonly Random random = new Random();

        private int score = 0;
        private int questionCount = 0;
        private int count = 0;
        public string UserName { get; }
        private int secondsElapsed;
        GameLogic newgame = new GameLogic();
        private DispatcherTimer timer;
        private int seconds;
        public Window1(string name)
        {
            InitializeComponent();
            Getnextquest();
            UserName = name;
            newgame = new GameLogic(UserName);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += Timer_Tick;
            seconds = 0;
            timer.Start();

            Loaded += Window1_Loaded;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            timerText.Text = seconds.ToString();
        }
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Getnextquest();
        }
        




        private void EndGame()
        {
            timer.Stop();
            string name = Name;
            Window2 hadash = new Window2(newgame.Getscore(), name,int.Parse(timerText.Text));
            hadash.Show();
            this.Close();
        }




        public void Getnextquest()
        {
            sign.Text = newgame.Wichsign();
            num1.Text = newgame.randomnum1().ToString();
            num2.Text = newgame.randomnum2().ToString();

        }



        private void cheking(object sender, RoutedEventArgs e)
        {
            try
            {
                if (count < 10)
                {

                    if (newgame.Checkanwer(int.Parse(num1.Text), int.Parse(num2.Text), sign.Text, int.Parse(Answer.Text)))
                    {
                        PlayCorrectSound();
                        double greenValue = progressBar.Maximum * 0.1;


                        progressBar.Foreground = Brushes.Green;
                        progressBar.Value = Math.Min(progressBar.Value + greenValue, progressBar.Maximum);
                        count++;
                        
                        
                    


                    }
                    else if(newgame.Checkanwer(int.Parse(num1.Text), int.Parse(num2.Text), sign.Text, int.Parse(Answer.Text)) == false)
                    {
                        PlayWrongSound();
                        double redValue = progressBar.Maximum * 0.1;

                        progressBar.Foreground = Brushes.Red;
                        progressBar.Value = Math.Min(progressBar.Value + redValue, progressBar.Maximum);
                        count++;
                       
                       

                    }
                    question.Text = count.ToString();
                    Answer.Text = "";

                    Getnextquest();



                }

                else
                {
                    EndGame();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");

            }
        }


        private void PlayCorrectSound()
        {
            try
            {
                MediaPlayer mediaPlayer = new MediaPlayer();

                mediaPlayer.Open(new Uri("C:\\Users\\niv\\Downloads\\x2mate.com - Correct Answer Sound Effect (128 kbps).mp3", UriKind.RelativeOrAbsolute));

                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing the sound: {ex.Message}");
            }
        }
        private void PlayWrongSound()
        {
            try
            {
                MediaPlayer mediaPlayer = new MediaPlayer();

                mediaPlayer.Open(new Uri("C:\\Users\\niv\\Downloads\\x2mate.com-WRONG ANSWER SOUND EFFECT (1).mp4", UriKind.RelativeOrAbsolute));

                // Play the audio
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing the sound: {ex.Message}");
            }
        }


    }
}

       
    
