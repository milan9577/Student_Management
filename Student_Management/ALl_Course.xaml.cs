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
///////
using System.Data;
using MySql.Data.MySqlClient;
namespace Student_Management
{
    /// <summary>
    /// Interaction logic for ALl_Course.xaml
    /// </summary>
    public partial class ALl_Course : Window
    {
        public ALl_Course()
        {
            InitializeComponent();

            //////////////////////////////////
            int count = 1;
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = " SELECT * FROM `teacher`";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String Teacher_Name = Convert.ToString(reader[1]);

                comboBox_teacher.Items.Insert(count, Teacher_Name);
                count++;
                // comboBox_Teacher_.Items.Add(Teacher_Name);
            }
            mycon.Close();


            ///////////////////////////////////
            //  Constraction End
        }

        private void Show_btn(object sender, RoutedEventArgs e)
        {
            String Department = "", Semester = "", C_T = "";

            Department = comboBox_dprtmnt.Text;
            Semester = comboBox_semester.Text;
            C_T = comboBox_teacher.Text;

            MessageBox.Show(Department + "\n" + Semester + "\n" + C_T);

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = "";
            if (Department == "ALL")
            {
                Department = "%";
            }

            if (Semester == "ALL")
            {
                Semester = "%";
            }
            if (C_T == "ALL")
            {
                C_T = "%";
            }


            //  MessageBox.Show(Department + "\n" + Semester + "\n" + Section + "\n" + Sex + "\n" + Religion);
            Query = "SELECT * FROM `course` WHERE Department LIKE '" + Department + "' AND Semester LIKE '" + Semester + "' AND C_Teacher LIKE '" + C_T + "'";

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
            if (for_where.Text == "teacher")
            {
                TeacherActivity t = new TeacherActivity();
                t.for_id.Text = for_id.Text;
                t.for_name.Text = for_name.Text;
                t.Show();
                this.Close();
            }
            else
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
}
