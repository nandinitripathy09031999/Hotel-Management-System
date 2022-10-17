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
using EntityLayer;
using BusinessLayer11;

namespace Login
{
    /// <summary>
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var c = new EntityLayer.Customers()
                {
                    cid = int.Parse(txtcid.Text),
                    cpassword = txtpwd.Text,
                };

                var bll = new Business();
                if (bll.CustomerCheck(c))
                {

                    MessageBox.Show("Login Successful");
                    CustomerHomeScreen chs = new CustomerHomeScreen();
                    chs.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerRehistration2 cr = new CustomerRehistration2();
            cr.ShowDialog();
        }
    }
}
