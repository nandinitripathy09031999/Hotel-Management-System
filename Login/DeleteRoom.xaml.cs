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
    /// Interaction logic for DeleteRoom.xaml
    /// </summary>
    public partial class DeleteRoom : Window
    {
        public DeleteRoom()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ro = new EntityLayer.Rooms()
                {
                    rno = int.Parse(roomno.Text),
                };

                var bll = new Business();
                if (bll.RoomDelete(ro))

                    MessageBox.Show("Room successfully deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
