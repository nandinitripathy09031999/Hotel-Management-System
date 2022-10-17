using BusinessLayer11;
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
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for EmployeeHomeScreen.xaml
    /// </summary>
    public partial class EmployeeHomeScreen : Window
    {
        public EmployeeHomeScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRoom addroom=new AddRoom();
            addroom.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteRoom deleteroom=new DeleteRoom();
            deleteroom.ShowDialog();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var avlr = new Business();
            var lstavlr = avlr.GetallRooms();
            if (lstavlr.Count > 0)
                dg1.ItemsSource = lstavlr;
            else
                MessageBox.Show("No rooms found");
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var allcus = new Business();
            var lstallcus = allcus.GetallCustomers();
            if (lstallcus.Count > 0)
                dg2.ItemsSource = lstallcus;
            else
                MessageBox.Show("No customers found");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CustomerCheckOut coc=new CustomerCheckOut();
            coc.ShowDialog();
        }

        
    }
}
