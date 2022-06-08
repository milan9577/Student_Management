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
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for All_Admin.xaml
    /// </summary>
    public partial class All_Admin : Window
    {
        
        public All_Admin()
        {
            InitializeComponent();

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = " SELECT * FROM `admin`";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);
            mycon.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
            DataTable dt = new DataTable("admin");
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            adp.Update(dt);
            mycon.Close();
        }


        private void Load_Data_btn(object sender, RoutedEventArgs e)
        {
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = " SELECT * FROM `admin`";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);         
            mycon.Open();
      
                MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
                DataTable dt = new DataTable("admin");
                adp.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                adp.Update(dt);
            mycon.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            DeanProfile m = new DeanProfile();
            m.Show();
            this.Close();
        }
    }
}
