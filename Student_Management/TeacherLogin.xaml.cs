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
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : Window
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void ID_Box_focus(object sender, RoutedEventArgs e)
        {
            ID_Box.Text = "";
        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_Box.Text = "";
            Pass_Box.Password = "";
        }

        private void Login_Click_btn(object sender, RoutedEventArgs e)
        {
            String ID = ID_Box.Text;
            String Password = Pass_Box.Password;

            String id = "", pass = "";
            String Name = "";
            String  Age = "", Sex = "", Rel = "", Department = "", M_S = "", Mail = "", Phn = "", DOB = "", Loc = "";


        /////Data Retrive//////////
        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `teacher` WHERE ID = '" + ID + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToString(reader[0]);
                Name = Convert.ToString(reader[1]);
                Age = Convert.ToString(reader[2]);
                Sex = Convert.ToString(reader[3]);
                Rel = Convert.ToString(reader[4]);
                Department = Convert.ToString(reader[5]);
                M_S = Convert.ToString(reader[6]);
                Phn = Convert.ToString(reader[7]);
                Mail = Convert.ToString(reader[8]);
                DOB = Convert.ToString(reader[9]);
                Loc = Convert.ToString(reader[10]);
                pass = Convert.ToString(reader[11]);
                // Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4]);
            }


            mycon.Close();

            if (ID == id && Password == pass)
            {
                String YourName = "Hey " + Name;
                String YourID = id;            

                
                TeacherActivity a = new TeacherActivity();

                a.for_name.Text = YourName;
                a.for_id.Text = YourID;

                /////////////////////////////////
                a.Get_ID = YourID;
                a.Name = Name;
                a.Age = Age;
                a.Sex = Sex;
                a.Rel = Rel;
                a.Department = Department;
                a.M_S = M_S;
                a.phn = Phn;            
                a.Mail = Mail;
                a.DOB = DOB;
                a.Loc = Loc;
                a.Pass = Password;



                a.Show();
                this.Close();

               // MessageBox.Show(ID + "\n" + Name + "\n" + Password);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("ID or Password Not matched");
            }

        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
