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
    /// Interaction logic for After_Login.xaml
    /// </summary>
    public partial class After_Login : Window
    {


        public String ID_fb = "";
        public String yourname = "";
       


        public After_Login()
        {
            InitializeComponent();

            String Admin_Message = "";      
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `message` WHERE ID = 'dean'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Admin_Message = Convert.ToString(reader[14]);            

            }
            mycon.Close();

            dean_msg.Text = Admin_Message;

            //////////////////////////////////////////////////
            ////////////Number of Teacher////////////////////
             Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
             Query = "SELECT COUNT(*) FROM teacher;";


             mycon = new MySqlConnection(Connection);
             myCom = new MySqlCommand(Query, mycon);

            
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

        private void Update_Admin(object sender, RoutedEventArgs e)
        {
            String id_ = for_id.Text;          
            String fname = "", lname = "", age = "", sex = "", rel = "", m_s = "", mail = "", phn = "", dob = "", loc = "", skill = "", pass = "";

            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";

            String Query = " SELECT * FROM `admin` WHERE ID = '" + id_ + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id_ = Convert.ToString(reader[0]);
                fname = Convert.ToString(reader[1]);
                lname = Convert.ToString(reader[2]);
                age = Convert.ToString(reader[3]);
                sex = Convert.ToString(reader[4]);
                rel = Convert.ToString(reader[5]);
                m_s = Convert.ToString(reader[6]);
                mail = Convert.ToString(reader[7]);
                phn = Convert.ToString(reader[8]);
                dob = Convert.ToString(reader[9]);
                loc = Convert.ToString(reader[10]);
                skill = Convert.ToString(reader[11]);
                pass = Convert.ToString(reader[12]);
            }



            Admin_Update a = new Admin_Update();

            /////////////////////
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            ////////////////////

            a.ID_box.Text = id_;
            a.FName_Box.Text = fname;
            a.LName_Box.Text = lname;
            a.Age_box.Text = age;
            a.FName_Box.Text = fname;
            a.mail_box.Text = mail;
            a.Phn_Box.Text = phn;
            a.Loc_box.Text = loc;
            a.Skill_Box.Text = skill;
            a.pass_box.Text = pass;
            a.Date_Box.Text = dob;
            // a.FName_Box.Text = fname;
            // a.FName_Box.Text = fname;
            ///////////////////////////////

            ////Check Box
            if (m_s == "Merried")
            {
               a.Merried.IsChecked = true;
            }
            else
            {
                a.Unmerried.IsChecked = true;
            }


            ///Radio Button
            if (sex == "Male")
            {
                a.RB_Male.IsChecked = true;
            }
            else if (sex == "Female")
            {
                a.RB_Female.IsChecked = true;
            }
            else
            {
                a.RB_Other.IsChecked = true;
            }


            //  Religion By Combo box
            if (rel == "Hindu")
            {
                a.comboBox_rl.SelectedIndex = 0;
            }
            else if (rel == "Muslim")
            {
                a.comboBox_rl.SelectedIndex = 1;
            }
            else if (rel == "Buddhist")
            {
                a.comboBox_rl.SelectedIndex = 2;
            }
            else
            {
                a.comboBox_rl.SelectedIndex = 3;
            }

            //////////////////////////////
            a.ID_fb = ID_fb;
            a.yourname = yourname;

            ////////////////////////////



            a.Show();
            this.Close();
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(for_name.Text + "\n" + for_id.Text);
           
            StudentRegistration a = new StudentRegistration();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;

            a.Show();
            this.Close();
        }

        private void Message(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(for_id.Text);
        }

        private void ViewAndSetting(object sender, RoutedEventArgs e)
        {
           
            StudentViewSetting s = new StudentViewSetting();
            //////////////////////////////
            s.for_id.Text = for_id.Text;
            s.for_name.Text = for_name.Text;

            ////////////////////////////
            s.Show();
            this.Close();
        }

        private void View_All_Students(object sender, RoutedEventArgs e)
        {
            All_Students a = new All_Students();

            /////////////////////
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            ////////////////////

            a.Show();
            this.Close();
        }

        private void Add_Teacher(object sender, RoutedEventArgs e)
        {
            TeacherRegistration t = new TeacherRegistration();

            t.for_id.Text = for_id.Text;
            t.for_name.Text = for_name.Text;

            t.Show();
            this.Close();
        }

        private void TeacherViewSetting(object sender, RoutedEventArgs e)
        {
            TeacherViewSetting t = new TeacherViewSetting();
            t.for_id.Text = for_id.Text;
            t.for_name.Text = for_name.Text;
            t.Show();
            this.Close();
        }

        private void View_All_Teacher(object sender, RoutedEventArgs e)
        {
            ALL_Teachers a = new ALL_Teachers();
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.Show();
            this.Close();
        }

        private void Add_Subject(object sender, RoutedEventArgs e)
        {
            Add_Course a = new Add_Course();
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.Show();
            this.Close();
        }

        private void CourseViewSetting(object sender, RoutedEventArgs e)
        {
            CourseViewSetting c = new CourseViewSetting();
            c.for_id.Text = for_id.Text;
            c.for_name.Text = for_name.Text;
            c.Show();
            this.Close();
        }

        private void View_All_Course(object sender, RoutedEventArgs e)
        {
            ALl_Course a = new ALl_Course();
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.Show();
            this.Close();
        }

        private void Course_Teacher(object sender, RoutedEventArgs e)
        {
            Course_And_Teacher c = new Course_And_Teacher();

            c.for_id.Text = for_id.Text;
            c.for_name.Text = for_name.Text;

            c.Show();
            this.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Payment(object sender, RoutedEventArgs e)
        {
            Result_And_Amount r = new Result_And_Amount();
            r.for_id.Text = for_id.Text;
            r.for_name.Text = for_name.Text;

            r.Show();
            this.Close();
        }
    }
}
