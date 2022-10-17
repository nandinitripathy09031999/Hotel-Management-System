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
    /// Interaction logic for CustomerHomeScreen.xaml
    /// </summary>
    public partial class CustomerHomeScreen : Window
    {
        public CustomerHomeScreen()
        {
            InitializeComponent();
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewReservation nr=new NewReservation();
            nr.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RoomsAndRates rar=new RoomsAndRates();
            rar.ShowDialog();
        }
    }
}
