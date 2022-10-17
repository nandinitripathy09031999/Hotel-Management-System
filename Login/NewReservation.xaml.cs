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
    /// Interaction logic for NewReservation.xaml
    /// </summary>
    public partial class NewReservation : Window
    {
        public NewReservation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = new EntityLayer.Reservation()
            {
                rcid = int.Parse(cus_id.Text),
                rdays= int.Parse(dur.Text),
                roomno=int.Parse(rt.Text),
            };
            var bll = new Business();
            if (bll.ReserveRoom(res)!=0)
                MessageBox.Show("Room reservation successful!");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
