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

/////
using System.Data;
using MySql.Data.MySqlClient;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for Course_And_Teacher.xaml
    /// </summary>
    public partial class Course_And_Teacher : Window
    {
        public Course_And_Teacher()
        {
            InitializeComponent();
        }

        private void Show_btn(object sender, RoutedEventArgs e)
        {
            String Departmet = comboBox_dprtmnt.Text;
            String Semester = comboBox_semester.Text;

            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = "";

            Query = "SELECT course.ID, course.Name,course.C_Teacher FROM course WHERE course.Department='"+Departmet+"' AND course.Semester='"+Semester+"' ";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);
            mycon.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
            DataTable dt = new DataTable("course");
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            adp.Update(dt);
            mycon.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            if (for_id.Text == "")
            {
                DeanProfile d = new DeanProfile();
                d.Show();
                this.Close();
            }
            else
            {
                /////////////////////
                After_Login a = new After_Login();
                a.for_id.Text = for_id.Text;
                a.for_name.Text = for_name.Text;
                a.Show();
                this.Close();
                ////////////////////
            }
        }
    }
}
