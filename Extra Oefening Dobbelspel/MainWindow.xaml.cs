using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace Extra_Oefening_Dobbelspel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitSpel();
        }
        public int playerScore;
        public int computerScore;
        public bool rad1Check;
        public bool rad2Check;
        public bool rad3Check;
        public string titelSpel;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"{titelSpel}";
            LblTijd.Content = $"{DateTime.Now.ToLongDateString()}" + "  " + $"{ DateTime.Now.ToLongTimeString()}";
        }


        private void InitSpel()
        {
            Title = $"{titelSpel}";
            playerScore = 0;
            computerScore = 0;
            titelSpel = "Dobbelspel";
            BtnDobbelen.Content = "Dobbelen";
            BtnDobbelen.IsEnabled = false;
            TxtResultaat.Background = Brushes.Gray;
            TxtComputer.Clear();
            TxtPlayer.Clear();
            TxtResultaat.Clear();
            LblComputer.Content = "";
            LblPlayer.Content = "";
            ImgVuist.Visibility = Visibility.Hidden;
            ImgWijsVinger_Links.Visibility = Visibility.Hidden;
            ImgWijsVinger_Rechts.Visibility = Visibility.Hidden;
            LblGameType.Content = "";
        }

        private void DobbelenRnd()
        {
            Random rnd = new Random();
            int player;
            int computer;
            player = rnd.Next(1, 7);
            computer = rnd.Next(1, 7);

            if (player == computer)
            {
                TxtResultaat.Text = "Gelijk spel";
                TxtResultaat.Background = Brushes.Blue;
                ImgVuist.Visibility = Visibility.Visible;
                ImgWijsVinger_Rechts.Visibility = Visibility.Hidden;
                ImgWijsVinger_Links.Visibility = Visibility.Hidden;
            }
            else if (player < computer)
            {
                TxtResultaat.Text = "Computer wint";
                TxtResultaat.Background = Brushes.Red;
                ImgWijsVinger_Rechts.Visibility = Visibility.Visible;
                ImgWijsVinger_Links.Visibility = Visibility.Hidden;
                ImgVuist.Visibility = Visibility.Hidden;
                computerScore++;
            }
            else if (player > computer)
            {
                TxtResultaat.Text = "Player wint";
                TxtResultaat.Background = Brushes.Green;
                ImgWijsVinger_Links.Visibility = Visibility.Visible;
                ImgWijsVinger_Rechts.Visibility = Visibility.Hidden;
                ImgVuist.Visibility = Visibility.Hidden;
                playerScore++;
            }
            TxtPlayer.Text += $"{player}\n";
            TxtComputer.Text += $"{computer}\n";
            LblPlayer.Content = $"{playerScore} keer gewonnen";
            LblComputer.Content = $"{computerScore} keer gewonnen";
        }

        public void MessageEnd(string winnaar)
        {
            var selectOK = MessageBox.Show($"De winnaar is de {winnaar}", "DE WINNAAR", MessageBoxButton.OK);
            if (selectOK == MessageBoxResult.OK)
            {
                Rad1.IsChecked = false;
                Rad2.IsChecked = false;
                Rad2.IsChecked = false;
                BtnDobbelen.IsEnabled = false;
                LblGameType.Content = "";
                InitSpel();
            }
        }

        private void BtnDobbelen_Click(object sender, RoutedEventArgs e)
        {
            Button sndr = (Button)sender;
            switch (sndr.Content)
            {
                case "Dobbelen":
                    if (rad1Check)
                    {
                        DobbelenRnd();
                        if (playerScore == 5)
                        {
                            rad1Check = false;
                            TxtResultaat.Text = "Player wint";
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Player");
                        }
                        else if (computerScore == 5)
                        {
                            rad1Check = false;
                            TxtResultaat.Text = "Computer wint";
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Computer");
                        }
                    }   
                    if (rad2Check)
                    {
                        DobbelenRnd();
                        if (playerScore == 10)
                        {
                            rad2Check = false;
                            TxtResultaat.Text = "Player wint";
                            TxtResultaat.Background = Brushes.Green;
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Player");
                        }
                        else if (computerScore == 10)
                        {
                            rad2Check = false;
                            TxtResultaat.Text = "Computer wint";
                            TxtResultaat.Background = Brushes.Red;
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Computer");
                        }
                    }
                    if (rad3Check)
                    {
                        DobbelenRnd();
                        if (playerScore == 15)
                        {
                            rad3Check = false;
                            TxtResultaat.Text = "Player wint";
                            TxtResultaat.Background = Brushes.Green;
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Player");

                        }
                        else if (computerScore == 15)
                        {
                            rad3Check = false;
                            TxtResultaat.Text = "Computer wint";
                            TxtResultaat.Background = Brushes.Red;
                            BtnDobbelen.Content = "Eind spel";
                            MessageEnd("Computer");
                        }
                    }
                    break;
                case "Eind spel":
                    TxtResultaat.Text = "Het werkt";
                    TxtResultaat.Background = Brushes.Gray;
                    InitSpel();
                    break;
                default:
                    break;
                    
            }
        }

        
        
        public void Rad1_Checked(object sender, RoutedEventArgs e)
        {
            titelSpel = "Eerste van 5 wint";
            InitSpel();
            rad1Check = true;
            rad2Check = false;
            rad3Check = false;
            BtnDobbelen.IsEnabled = true;
            LblGameType.Content = "Eerste van 5 wint";
        }

        private void Rad2_Checked(object sender, RoutedEventArgs e)
        {
            titelSpel = "Eerste van 10 wint";
            InitSpel();
            rad1Check = false;
            rad2Check = true;
            rad3Check = false;
            BtnDobbelen.IsEnabled = true;
            LblGameType.Content = "Eerste van 10 wint";
        }

        private void Rad3_Checked(object sender, RoutedEventArgs e)
        {
            titelSpel = "Eerste van 15 wint";
            InitSpel();
            rad1Check = false;
            rad2Check = false;
            rad3Check = true;
            BtnDobbelen.IsEnabled = true;
            LblGameType.Content = "Eerste van 15 wint";
        }
    }
}
