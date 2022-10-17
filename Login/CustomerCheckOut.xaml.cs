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
using BusinessLayer11;

namespace Login
{
    /// <summary>
    /// Interaction logic for CustomerCheckOut.xaml
    /// </summary>
    public partial class CustomerCheckOut : Window
    {
        public CustomerCheckOut()
        {
            InitializeComponent();
        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var rid = int.Parse(cusid.Text);

                var bll = new Business();
            if (bll.ReservationDelete(rid))
                MessageBox.Show("Successfully checked out");
            else
                MessageBox.Show("No reservations found!");

        }

        private void cusid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
