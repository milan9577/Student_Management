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
using MySql.Data.MySqlClient;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for DeanProfile.xaml
    /// </summary>
    public partial class DeanProfile : Window
    {
        public DeanProfile()
        {
            InitializeComponent();
            String Admin_Message = "";
            //////////////////////////////////////////////////
            ////////////Number of Teacher////////////////////
           string  Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
           String Query = "SELECT COUNT(*) FROM teacher;";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[0]);

            }
            mycon.Close();

            Number_Teacher.Text = "Number of Teacher\n" + Admin_Message;
            // MessageBox.Show(Admin_Message);
            /////////////////////////////////////////////////

            //////////////////////////////////////////////////
            ////////////Number of Teacher////////////////////
            Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            Query = "SELECT COUNT(*) FROM admin;";


            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);


            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[0]);

            }
            mycon.Close();

            Number_Admin.Text = "Number of Admin\n" + Admin_Message;
            // MessageBox.Show(Admin_Message);
            /////////////////////////////////////////////////

            //////////////////////////////////////////////////
            ////////////Number of Students in CSE Department////////////////////
            Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            Query = "SELECT COUNT(*) FROM students WHERE department='CSE';";


            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);


            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[0]);

            }
            mycon.Close();

            Number_CSE.Text = "Number of Students in CSE \n" + Admin_Message;
            // MessageBox.Show(Admin_Message);
            /////////////////////////////////////////////////


            //////////////////////////////////////////////////
            ////////////Number of Students in EEE Department////////////////////
            Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            Query = "SELECT COUNT(*) FROM students WHERE department='EEE';";


            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);


            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[0]);

            }
            mycon.Close();

            Number_EEE.Text = "Number of Students in EEE \n" + Admin_Message;
            // MessageBox.Show(Admin_Message);
            /////////////////////////////////////////////////


            //////////////////////////////////////////////////
            ////////////Number of Students in CSE Department////////////////////
            Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            Query = "SELECT COUNT(*) FROM students WHERE department='CIVIL';";


            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);


            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[0]);

            }
            mycon.Close();

            Number_CIVIL.Text = "Number of Students in CIVIL \n" + Admin_Message;
            // MessageBox.Show(Admin_Message);
            /////////////////////////////////////////////////
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
            StudentRegistration s = new StudentRegistration();
            s.Show();
            this.Close();
        }

        private void ViewAndSetting(object sender, RoutedEventArgs e)
        {
            StudentViewSetting s = new StudentViewSetting();
            s.Show();
            this.Close();
        }

        private void Add_Admin(object sender, RoutedEventArgs e)
        {
            Admin_Registration a = new Admin_Registration();

            a.for_id.Text = "dean";
            a.catch_Data = "1";
            a.Show();
            this.Close();
        }

        private void Admin_setting(object sender, RoutedEventArgs e)
        {
            AdminViewSetting a = new AdminViewSetting();
            a.Show();
            this.Close();
        }

        private void ViewAllAdmin(object sender, RoutedEventArgs e)
        {
            All_Admin a = new All_Admin();
            a.Show();
            this.Close();
        }

        private void View_All_Students(object sender, RoutedEventArgs e)
        {
            All_Students a = new All_Students();
            a.Show();
            this.Close();
        }

        private void Add_Teacher(object sender, RoutedEventArgs e)
        {
            TeacherRegistration t = new TeacherRegistration();
            t.Show();
            this.Close();
        }

        private void TeacherViewSetting(object sender, RoutedEventArgs e)
        {
            TeacherViewSetting t = new TeacherViewSetting();
            t.Show();
            this.Close();
        }

        private void View_All_Teacher(object sender, RoutedEventArgs e)
        {
            ALL_Teachers a = new ALL_Teachers();
            a.Show();
            this.Close();
        }

        private void Add_Subject(object sender, RoutedEventArgs e)
        {
            Add_Course a = new Add_Course();
            a.Show();
            this.Close();
        }

        private void CourseViewSetting(object sender, RoutedEventArgs e)
        {
            CourseViewSetting c = new CourseViewSetting();
            c.Show();
            this.Close();
        }

        private void View_All_Course(object sender, RoutedEventArgs e)
        {
            ALl_Course a = new ALl_Course();
            a.Show();
            this.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void Course_Teacher(object sender, RoutedEventArgs e)
        {
            Course_And_Teacher c = new Course_And_Teacher();
            c.Show();
            this.Close();
        }

        private void Give_Message(object sender, RoutedEventArgs e)
        {
            DeangoMessage d = new DeangoMessage();
            d.Show();
            this.Close();
        }

        private void Payment(object sender, RoutedEventArgs e)
        {
            Result_And_Amount r = new Result_And_Amount();
            r.Show();
            this.Close();
        }
    }
}
