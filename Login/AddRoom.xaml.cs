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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ro = new EntityLayer.Rooms()
                {
                    rtype = rt.Text,
                };

                var bll = new Business();
                if(bll.RoomAdd(ro))

                    MessageBox.Show("Room successfully added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
