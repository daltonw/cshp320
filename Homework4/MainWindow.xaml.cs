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
using System.Text.RegularExpressions;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Enable submit command once zip code or postal code meets regex requirements
        private void SubmitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Regex.IsMatch(ZipCode.Text, "^[0-9]{5}(?:-[0-9]{4})?$|^(?!.*[DFIOQU])[A-VXY][0-9][A-Z][ ]?[0-9][A-Z][0-9]$");
        }

        // Display message when submit command has executed
        private void SubmitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Success! You have submitted a correctly " + "\n" + "formatted Zip Code or Postal Code.");          
        }

    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Submit = new RoutedUICommand
            (
            // Alternatively, pressing the enter key can also execute submit command, once it has been enabled.

                "Submit",
                "Submit",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Enter)
                }
            );
    }
}
