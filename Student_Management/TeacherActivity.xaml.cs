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


namespace Student_Management
{
    /// <summary>
    /// Interaction logic for TeacherActivity.xaml
    /// </summary>
   

    public partial class TeacherActivity : Window
    {
        public String Get_ID = "";
        public String Name="", Age = "", Sex = "", Rel = "", Department = "", M_S = "", Mail = "", phn = "", DOB = "", Loc = "", Pass = "";

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            TeacherLogin t = new TeacherLogin();
            t.Show();
            this.Close();
        }

        private void Give_Message(object sender, RoutedEventArgs e)
        {
            TeacherGiveMessage t = new TeacherGiveMessage();

            t.for_id.Text = for_id.Text;
            t.for_name.Text = for_name.Text;
                   
            t.Get_ID = for_id.Text;
            t.Show();
            this.Close();
        }

        public TeacherActivity()
        {
            InitializeComponent();

            String Teacher_Message = "";
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
                Teacher_Message = Convert.ToString(reader[15]);

            }
            mycon.Close();

            dean_msg.Text = Teacher_Message;

        }


        private void All_Clourse(object sender, RoutedEventArgs e)
        {
            ALl_Course a = new ALl_Course();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.for_where.Text = "teacher";


            a.Show();
            this.Close();
        }

        private void Shw_All_Std(object sender, RoutedEventArgs e)
        {
            All_Students_By a = new All_Students_By();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;

            a.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            All_Teacher_By_ a = new All_Teacher_By_();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;

            a.Show();
            this.Close();
        }

      
        private void Show_btn(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(Get_ID+"\n"+Name + "\n"+ Age + "\n" + Sex + "\n" + Rel + "\n" + Department + "\n" + M_S + "\n" + phn + "\n" + Mail + "\n" + DOB + "\n" + Loc+"\n"+Pass);

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = "SELECT teacher.Name, course.Name,course.Semester FROM course INNER JOIN teacher ON course.C_Teacher = teacher.Name WHERE teacher.ID='"+for_id.Text+"'";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);
            mycon.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
            DataTable dt = new DataTable("teacher");
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            adp.Update(dt);
            mycon.Close();
        }


        ///Teacher Own Update
        private void Update_Teacher_Own(object sender, RoutedEventArgs e)
        {
            String id_ = for_id.Text;
            String name = "", age = "", sex = "", dep="",rel = "", m_s = "", mail = "", phn = "", dob = "", loc = "", pass = "";

            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";

            String Query = " SELECT * FROM `teacher` WHERE ID = '" + id_ + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id_ = Convert.ToString(reader[0]);
                Name = Convert.ToString(reader[1]);               
                age = Convert.ToString(reader[2]);
                sex = Convert.ToString(reader[3]);
                rel = Convert.ToString(reader[4]);
                dep = Convert.ToString(reader[5]);
                m_s = Convert.ToString(reader[6]);
                phn = Convert.ToString(reader[7]);
                mail = Convert.ToString(reader[8]);             
                dob = Convert.ToString(reader[9]);
                loc = Convert.ToString(reader[10]);              
                pass = Convert.ToString(reader[11]);
            }

            //////////////////////////////////////////////////////////////////////

            Teacher_Own_Update t = new Teacher_Own_Update();

            //////////
            t.for_id.Text = for_id.Text;
            t.for_name.Text = for_name.Text;
            /////////

            t.tb.Text = id_;
            t.tb_fname.Text = Name;
            t.tb_age.Text = Age;
            t.tb_department.Text = dep;
            t.tb_m_s.Text = m_s;
            t.tb_rel.Text = rel;
            t.tb_sex.Text = sex;
            t.tb_dob.Text = dob;

            t.tbx_phn.Text = phn;
            t.tbx_mail.Text = mail;
            t.tbx_loc.Text = loc;
            t.tbx_oldpass.Text = pass;

            MessageBox.Show("Password:" + pass);


            t.Show();          
            this.Close();
        }
    }
}
