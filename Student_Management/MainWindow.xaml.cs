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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Visibility = Visibility.Collapsed;
            button.Visibility = Visibility.Visible;
        }

        private void Login_Click_btn(object sender, RoutedEventArgs e)
        {
            String ID = ID_Box.Text;
            String Password = Pass_Box.Password;

            String id="", pass="";
            String fname="", lname="", age = "", sex = "", rel = "", m_s = "", mail = "", phn = "", dob = "", loc = "",skill="",Status="";


            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";      
            String Query =" SELECT * FROM `admin` WHERE ID = '"+ID+"'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id =Convert.ToString(reader[0]);
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
                Status = Convert.ToString(reader[13]);


                // Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4]);

            }

            
            mycon.Close();

             if(ID==id && Password == pass)
             {
                if (Status == "True")
                {

                    String YourName = "Hey " + fname + " " + lname;
                    String YourID = id;

                    After_Login a = new After_Login();

                    a.for_name.Text = YourName;
                    a.for_id.Text = YourID;

                    /////////////////
                    a.ID_fb = id;
                    a.yourname = YourName;
                    ///////////////////////


                    a.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Are not Verified by Dean Sir");
                }
             }
             else
             {
                 MessageBoxResult result = MessageBox.Show("ID or Password Not matched");
             }

            /*After_Login a = new After_Login();
            a.Show();
            this.Close();*/



        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            //String ID, Password;
           ID_Box.Text="";
           Pass_Box.Password="";

        }


        private void ID_Box_focus(object sender, RoutedEventArgs e)
        {
            ID_Box.Text = "";
        }


        private void Registration_btn_click(object sender, RoutedEventArgs e)
        {
            Admin_Registration a = new Admin_Registration();
            a.Show();
            this.Close();
        }

        private void Dean_go(object sender, RoutedEventArgs e)
        {
          //  DeanProfile d = new DeanProfile();
            Dean_Login d = new Dean_Login();
            d.Show();
            this.Close();

            

        }

        private void Student_go(object sender, RoutedEventArgs e)
        {
            Student_Login s = new Student_Login();
            s.Show();
            this.Close();
        }

        private void Teacher_Login(object sender, RoutedEventArgs e)
        {
            TeacherLogin t = new TeacherLogin();
            t.Show();
            this.Close();
        }
    }
}
