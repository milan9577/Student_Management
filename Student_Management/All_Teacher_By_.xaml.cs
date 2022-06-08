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
    /// Interaction logic for All_Teacher_By_.xaml
    /// </summary>
    public partial class All_Teacher_By_ : Window
    {
        public All_Teacher_By_()
        {
            InitializeComponent();
        }

        private void Show_btn(object sender, RoutedEventArgs e)
        {
            String Department = "", Semester = "", Section = "", Sex = "", Religion = "";


            var Religion_Temp = (ComboBoxItem)comboBox_rl.SelectedItem;
            Religion = (String)Religion_Temp.Content;


            var Department_Temp = (ComboBoxItem)comboBox_dprtmnt.SelectedItem;
            Department = (String)Department_Temp.Content;


            var Sex_temp = (ComboBoxItem)comboBox_Sex.SelectedItem;
            Sex = (String)Sex_temp.Content;

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = "";
            if (Department == "ALL")
            {
                Department = "%";
            }

            if (Sex == "ALL")
            {
                Sex = "%";
            }
            if (Religion == "ALL")
            {
                Religion = "%";
            }


            //  MessageBox.Show(Department + "\n" + Semester + "\n" + Section + "\n" + Sex + "\n" + Religion);
            Query = "SELECT  `ID`, `Name`, `Age`, `Sex`, `Religion`, `Department`, `M_S`, `Phone`, `Email`, `DOB`, `Location` FROM `teacher` WHERE Department LIKE '" + Department + "' AND sex LIKE '" + Sex + "' AND religion LIKE '" + Religion + "'";

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
            if (for_where.Text == "students")
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
            else
            {
                /////////////////////
                TeacherActivity a = new TeacherActivity();
                a.for_id.Text = for_id.Text;
                a.for_name.Text = for_name.Text;
                a.Show();
                this.Close();
                ////////////////////
            }
        }
    }
}
