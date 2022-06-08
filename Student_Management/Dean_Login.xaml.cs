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

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for Dean_Login.xaml
    /// </summary>
    public partial class Dean_Login : Window
    {
        public Dean_Login()
        {
            InitializeComponent();
        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_Box.Text = "";
            Pass_Box.Password = "";
        }

        private void Login_Click_btn(object sender, RoutedEventArgs e)
        {
            String ID=  ID_Box.Text;
            String Password= Pass_Box.Password;
            if (ID == "Admin" && Password == "DEAN")
            {
               // MessageBoxResult result = MessageBox.Show("Dean Logined");
                 DeanProfile a = new DeanProfile();
                 a.Show();
                 this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("ID or Password Not matched");
            }
        }

        private void ID_Box_focus(object sender, RoutedEventArgs e)
        {
            ID_Box.Text = "";
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
