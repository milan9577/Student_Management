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
    /// Interaction logic for StudentRegistration.xaml
    /// </summary>
    public partial class StudentRegistration : Window
    {

        public String ID_fb = "";
        public String yourname = "";

        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void Reg_Click_btn(object sender, RoutedEventArgs e)
        {
            try { 
            String Checking_ID = "";
            String ID = ID_box.Text;
            String FName = FName_Box.Text;
            String LName = LName_Box.Text;
            String Age = Age_box.Text;
            String Email = mail_box.Text;
            String Phone = Phn_Box.Text;
            String Location = Loc_box.Text;
            String Password = Pass_box.Password;
            String CGPA = cgpa_box.Text;
            String Sex = "";
           // String Department = "";
          //  String Semester = "";
           

            if (RB_Male.IsChecked == true)
            {
                Sex = "Male";
            }
            else if (RB_Female.IsChecked == true)
            {
                Sex = "Female";
            }
            else if (RB_Other.IsChecked == true)
            {
                Sex = "other";
            }
            var Religion_Temp = (ComboBoxItem)comboBox_rl.SelectedItem;
            String Religion = (String)Religion_Temp.Content;


            var Department_Temp = (ComboBoxItem)comboBox_dprtmnt.SelectedItem;
            String Department = (String)Department_Temp.Content;

            var Semester_Temp = (ComboBoxItem)comboBox_semester.SelectedItem;
            String Semester = (String)Semester_Temp.Content;

            var Section_Temp = (ComboBoxItem)comboBox_section.SelectedItem;
            String Section = (String)Section_Temp.Content;


            string DOB = cal_date.SelectedDate.Value.ToShortDateString();

            //Message box for surity of data
            MessageBoxResult results = MessageBox.Show(ID + "\n" + FName + "\n" + LName + "\n" + Age + "\n" + Sex + "\n" + Religion + "\n" + Department +"\n" + Semester
                + "\n" + Section + "\n" + Email + "\n" + Phone
                + "\n" + DOB + "\n" + Location +  "\n" + Password);


            //////////////////////////////////////////////////////////
            ////ID Checking/////////////
            ///////////////////////////////
            String Connections = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Querys = " SELECT * FROM `students` WHERE ID = '" + ID + "'";


            MySqlConnection mycons = new MySqlConnection(Connections);
            MySqlCommand myComs = new MySqlCommand(Querys, mycons);

            MySqlDataReader readers;
            mycons.Open();
            readers = myComs.ExecuteReader();
            while (readers.Read())
            {
                Checking_ID = Convert.ToString(readers[0]);

            }


            mycons.Close();


            ///////////////////////////////////////////////
            ////ID Checking End/////////////

            ///////////////////////////////////////////////////////////

            if (ID == Checking_ID)
            {
                MessageBox.Show("This ID Already Exists");
            }
            else
            {

                if (Password.Length >= 6)
                {
                    MessageBoxResult m = MessageBox.Show("Do you relly Insert?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (m)
                    {
                        //1st case
                        case MessageBoxResult.Yes:
                            /////Insert Data////


                            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                            String Query = "INSERT INTO `students`(`ID`, `fname`, `lname`, `age`, `sex`, `religion`, `Department`, `Semester`, `Section`, `cgpa`, `phn`, `mail`, `dob`, `location`, `password`) VALUES ('" + ID + "','" + FName + "','" + LName + "','" + Age + "','" + Sex + "','" + Religion + "','" + Department + "','" + Semester + "','" + Section + "','" + CGPA + "','" + Phone + "','" + Email + "','" + DOB + "','" + Location + "','" + Password + "')";



                            MySqlConnection mycon = new MySqlConnection(Connection);
                            MySqlCommand myCom = new MySqlCommand(Query, mycon);
                            mycon.Open();
                            MySqlDataReader reader = myCom.ExecuteReader(); ;
                            mycon.Close();
                            MessageBoxResult result = MessageBox.Show("Data Inserted Successfully");
                            ///Insert Data Close///


                            ////Insert Data in Result Table/////////
                             Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                             Query = "INSERT INTO `result`(`ID`, `S_N`, `"+Semester+"`) VALUES ('"+ID+"','"+FName+"','"+CGPA+"')";



                            mycon = new MySqlConnection(Connection);
                            myCom = new MySqlCommand(Query, mycon);
                            mycon.Open();
                            reader = myCom.ExecuteReader(); 
                            mycon.Close();
                           // MessageBox.Show("Data Inserted Successfully");
                            ///Insert data in Result Table Close/////



                            break;

                        //2nd Case
                        case MessageBoxResult.No:
                            break;
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Password Should be 6 or More digit");
                }
            }

                //////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem:" + Convert.ToString(ex));
            }
        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            FName_Box.Text = "";
            LName_Box.Text = "";
            Age_box.Text = "";
            mail_box.Text = "";
            Phn_Box.Text = "";
            Loc_box.Text = "";
            Pass_box.Password = "";
            cgpa_box.Text="";

            ///Radio Button
            RB_Male.IsChecked = false;
            RB_Female.IsChecked = false;
            RB_Other.IsChecked = false;
            ///Religion
            comboBox_rl.SelectedIndex = -1;
            ///Department          
            comboBox_dprtmnt.SelectedIndex = -1;
            ///Section           
            comboBox_section.SelectedIndex = -1;
            ///Semester
            comboBox_semester.SelectedIndex = -1;

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
                After_Login a = new After_Login();

                a.for_id.Text = for_id.Text;
                a.for_name.Text = for_name.Text;


                a.Show();
                this.Close();
            }
        }
    }
}
