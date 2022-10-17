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
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = new EntityLayer.Employees()
                {
                    eid = int.Parse(eid1.Text),
                    epassword = epwd.Text,
                };

                var bll = new Business();
                if (bll.EmployeeCheck(emp))
                {

                    MessageBox.Show("Login Successful");
                    EmployeeHomeScreen chs = new EmployeeHomeScreen();
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
            EmployeeRegistration er = new EmployeeRegistration();
            er.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
