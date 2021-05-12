using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        //private ListSortDirection direction = ListSortDirection.Ascending;
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

        }

        private void uxListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                uxList.Items.SortDescriptions.Clear();
            }

            //add direction parameter to toggle between ascending and descending sort
            //if (direction == ListSortDirection.Ascending)
            //{
            //    direction = ListSortDirection.Descending;
            //}
            //else
            //{
            //    direction = ListSortDirection.Ascending;
            //}

            listViewSortCol = column;
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
            //uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, direction));
        }
    }

}
