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
    /// Interaction logic for CustomerRehistration2.xaml
    /// </summary>
    public partial class CustomerRehistration2 : Window
    {
        public CustomerRehistration2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new EntityLayer.Customers()
                {
                    cname = cn.Text,
                    cpassword = cp.Text,
                };

                var bll = new Business();
                bll.CustomerAdd(c);

                    MessageBox.Show("Registration Successful");
                    CustomerLogin chs = new CustomerLogin();
                    chs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
