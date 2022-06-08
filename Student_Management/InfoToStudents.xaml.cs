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
    /// Interaction logic for InfoToStudents.xaml
    /// </summary>
    public partial class InfoToStudents : Window
    {
     //   public String Get_ID = "", Department = "", Semester = "";

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            String ID = for_id.Text;


            String id = "", pass = "";
            String Fname = "", Lname = "", Age = "", Sex = "", Department = "", Semester = "", Section = "", CGPA = "", Rel = "", Phn = "", Mail = "", DOB = "", Loc = "";
            String Blood_Donate = "", Vaccinated = "", Blood_group = "", Last_Donate = "";

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `students` WHERE ID = '" + ID + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToString(reader[0]);
                Fname = Convert.ToString(reader[1]);
                Lname = Convert.ToString(reader[2]);
                Age = Convert.ToString(reader[3]);
                Sex = Convert.ToString(reader[4]);
                Rel = Convert.ToString(reader[5]);
                Department = Convert.ToString(reader[6]);
                Semester = Convert.ToString(reader[7]);
                Section = Convert.ToString(reader[8]);
                CGPA = Convert.ToString(reader[9]);
                Phn = Convert.ToString(reader[10]);
                Mail = Convert.ToString(reader[11]);
                DOB = Convert.ToString(reader[12]);
                Loc = Convert.ToString(reader[13]);
                pass = Convert.ToString(reader[14]);
                Blood_Donate = Convert.ToString(reader[15]);
                Vaccinated = Convert.ToString(reader[16]);
                Blood_group = Convert.ToString(reader[17]);
                Last_Donate = Convert.ToString(reader[18]);


                // Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4]);

            }


            mycon.Close();



            Student_Activity a = new Student_Activity();

            a.for_id.Text = id;
            //   a.for_name.Text = for_name.Text;

            a.tb.Text = id;
            a.tb_fname.Text = Fname;
            a.tb_lname.Text = Lname;
            a.tb_department.Text = Department;
            a.tb_semester.Text = Semester;
            a.tb_section.Text = Section;
            a.tb_cgpa.Text = CGPA;

            a.tb_age.Text = Age;
            a.tb_sex.Text = Sex;
            a.tb_rel.Text = Rel;

            a.tb_dob.Text = DOB;
            a.tbx_mail.Text = Mail;
            a.tbx_phn.Text = Phn;
            a.tbx_loc.Text = Loc;

            ///////////////////////////////
            a.Blood_Group = Blood_group;
            a.Blood_Donate = Blood_Donate;
            a.Last_Donate = Last_Donate;

            /////////////////////////////

            a.Show();
            this.Close();
        }

        public InfoToStudents()
        {
            InitializeComponent();
        }

        private void Update_Click_btn(object sender, RoutedEventArgs e)
        {
            String ID = for_id.Text;
            String Semester = for_sem.Text;

            String Student_Message = "";
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT  * FROM `message` WHERE id='dean'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                if (Semester == "1_1")
                {
                    Student_Message = Convert.ToString(reader[2]);
                    break;
                }
                if (Semester == "1_2")
                {
                    Student_Message = Convert.ToString(reader[3]);
                    break;
                }
                if (Semester == "1_3")
                {
                    Student_Message = Convert.ToString(reader[4]);
                    break;
                }
                if (Semester == "2_1")
                {
                    Student_Message = Convert.ToString(reader[5]);
                    break;
                }
                if (Semester == "2_2")
                {
                    Student_Message = Convert.ToString(reader[6]);
                    break;
                }
                if (Semester == "2_3")
                {
                    Student_Message = Convert.ToString(reader[7]);
                    break;
                }
                if (Semester == "3_1")
                {
                    Student_Message = Convert.ToString(reader[8]);
                    break;
                }
                if (Semester == "3_2")
                {
                    Student_Message = Convert.ToString(reader[9]);
                    break;
                }
                if (Semester == "3_3")
                {
                    Student_Message = Convert.ToString(reader[10]);
                    break;
                }
                if (Semester == "4_1")
                {
                    Student_Message = Convert.ToString(reader[11]);
                    break;
                }
                if (Semester == "4_2")
                {
                    Student_Message = Convert.ToString(reader[12]);
                    break;
                }
                if (Semester == "4_3")
                {
                    Student_Message = Convert.ToString(reader[13]);
                    break;
                }

            }
            mycon.Close();

            dean_msg.Text = Student_Message;


            //////////////////////////////////

            // String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "";

            /* Query = "SELECT T_N,3_2 FROM `message` WHERE  "+Semester+"  !=''";

              mycon = new MySqlConnection(Connection);
              myCom = new MySqlCommand(Query, mycon);
             mycon.Open();

             MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
             DataTable dt = new DataTable("admin");
             adp.Fill(dt);
             dataGrid.ItemsSource = dt.DefaultView;
             adp.Update(dt);
             mycon.Close();*/


            MessageBox.Show(ID);
             Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
             Query = "";

            Query = "SELECT DISTINCT course.C_Teacher FROM students INNER JOIN course ON students.Semester = course.Semester WHERE students.ID='" + ID + "'";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

          //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            String[] GetTeacher_Name = new String[10];
            int count = 1;
            while (reader.Read())
            {
                GetTeacher_Name[count] = Convert.ToString(reader[0]);
                count++;
              //  MessageBox.Show();
            }          
            mycon.Close();

            for(int i = 1; i <= GetTeacher_Name.Length; i++)
            {
                if (i == 1)
                {
                    t_1.Text = GetTeacher_Name[i];
                }
                if (i == 2)
                {
                    t_2.Text = GetTeacher_Name[i];
                }
                if (i == 3)
                {
                    t_3.Text = GetTeacher_Name[i];
                }
                if (i == 4)
                {
                    t_4.Text = GetTeacher_Name[i];
                }
                if (i == 5)
                {
                    t_5.Text = GetTeacher_Name[i];
                }
            }



            ///////////////////////
            ////Teacher Message///
            /////////////////////
            String Message_1 = t_1.Text;
            String Message_2 = t_2.Text;
            String Message_3 = t_3.Text;
            String Message_4 = t_4.Text;
            String Message_5 = t_5.Text;

            ///////////////////////1/////////////////////
            Query = "SELECT `"+Semester+"` FROM `message` WHERE T_N='"+Message_1+"';";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

         //   MessageBox.Show("My Semester is:" + Semester);
            //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
               String msg = Convert.ToString(reader[0]);

                t_1_m.Text = msg;
            }

            ///////////////////////2/////////////////////
            Query = "SELECT `" + Semester + "` FROM `message` WHERE T_N='" + Message_2 + "';";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

          //  MessageBox.Show("My Semester is:" + Semester);
            //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String msg = Convert.ToString(reader[0]);

                t_2_m.Text = msg;
            }
            mycon.Close();

            ///////////////////////3/////////////////////
            Query = "SELECT `" + Semester + "` FROM `message` WHERE T_N='" + Message_3 + "';";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

          //  MessageBox.Show("My Semester is:" + Semester);
            //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String msg = Convert.ToString(reader[0]);

                t_3_m.Text = msg;
            }
            mycon.Close();

            ///////////////////////4/////////////////////
            Query = "SELECT `" + Semester + "` FROM `message` WHERE T_N='" + Message_4 + "';";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

           // MessageBox.Show("My Semester is:" + Semester);
            //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String msg = Convert.ToString(reader[0]);

                t_4_m.Text = msg;
            }
            mycon.Close();

            ///////////////////////5/////////////////////
            Query = "SELECT `" + Semester + "` FROM `message` WHERE T_N='" + Message_5 + "';";
            mycon = new MySqlConnection(Connection);
            myCom = new MySqlCommand(Query, mycon);

         //   MessageBox.Show("My Semester is:" + Semester);
            //  reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String msg = Convert.ToString(reader[0]);

                t_5_m.Text = msg;
            }
            mycon.Close();
        }
    }
}
