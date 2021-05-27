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

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MarkType[] results = new MarkType[9];

        private bool player1Turn;

        private bool gameEnded;

        public MainWindow()
        {
            InitializeComponent();

            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.IsEnabled = false;
            });
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            gameEnded = false;

            for (var i = 0; i < results.Length; i++)
                results[i] = MarkType.Free;

            player1Turn = true;

            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.IsEnabled = true;
            });

            uxTurn.Text = "X's start";
        }
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (results[index] != MarkType.Free)
                return;

            if (player1Turn)
            {
                results[index] = MarkType.Cross;
                button.Content = "X";
                player1Turn = false;
                uxTurn.Text = "O's turn";
            }
            else
            {
                results[index] = MarkType.Nought;
                button.Content = "O";
                player1Turn = true;
                uxTurn.Text = "X's turn";
            }

            CheckForWinner();

            if (gameEnded)
            {
                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.IsEnabled = false;

                });

                if (!results.Any(result => result == MarkType.Free))
                    uxTurn.Text = "Tied game";
                else if (player1Turn)
                    uxTurn.Text = "O is a winner!";
                else
                    uxTurn.Text = "X is a winner!";
            }
        }

        private void CheckForWinner()
        {
            // Check for horizontal wins
            if (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
                gameEnded = true;
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
                gameEnded = true;
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
                gameEnded = true;

            // Check for vertical wins
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
                gameEnded = true;
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
                gameEnded = true;
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
                gameEnded = true;

            // Check for diagonal wins
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
                gameEnded = true;
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
                gameEnded = true;


            // Check for tied game
            if (!results.Any(result => result == MarkType.Free))
            {
                gameEnded = true;
            }

        }
    }
}
