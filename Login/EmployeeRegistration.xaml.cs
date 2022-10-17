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
    /// Interaction logic for EmployeeRegistration.xaml
    /// </summary>
    public partial class EmployeeRegistration : Window
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = new EntityLayer.Employees()
                {
                    ename = en.Text,
                    epassword = ep.Text,
                };

                var bll = new Business();
                bll.EmployeeAdd(emp);

                MessageBox.Show("Registration Successful");
                EmployeeLogin chs = new EmployeeLogin();
                chs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
