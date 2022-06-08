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
    /// Interaction logic for Result_And_Amount.xaml
    /// </summary>
    public partial class Result_And_Amount : Window
    {
        public Result_And_Amount()
        {
            InitializeComponent();
        }


        private void modify_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                String ID = ID_box.Text;


                if (ID_box.Text == "")
                {
                    MessageBoxResult result = MessageBox.Show("Invalid ID");
                }
                else
                {
                    ////////////////////////
                    String _ID_ = ID_box.Text;
                    String FName = FName_Box.Text;
                    String LName = LName_Box.Text;
                    String CGPA = cgpa_box.Text;
                    String Semester = comboBox_semester.Text;
                    String Payment = comboBox_Payment.Text;





                    MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (m)
                    {
                        //1st case
                        case MessageBoxResult.Yes:
                            /////Update Data////

                            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                            String Query = "UPDATE `result` SET `" + Semester + "`='" + CGPA + "',`Payment`='" + Payment + "' WHERE id='" + _ID_ + "'";



                            MySqlConnection mycon = new MySqlConnection(Connection);
                            MySqlCommand myCom = new MySqlCommand(Query, mycon);
                            mycon.Open();
                            MySqlDataReader reader = myCom.ExecuteReader(); ;
                            mycon.Close();
                            MessageBoxResult result = MessageBox.Show("ID updated Successfully");


                            ///Update Data Close///

                            break;

                        //2nd Case
                        case MessageBoxResult.No:
                            break;
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Problem:" + Convert.ToString(ex));
            }
        }

        private void search_btn(object sender, RoutedEventArgs e)
        {
            Name_box_s_.Text = "";

            String Given_ID = ID_box_s.Text;
            //  MessageBoxResult result = MessageBox.Show(""+Given_ID);
            String id = "", pass = "";
            String Fname = "", Lname = "", Age = "", Sex = "", Department = "", Semester = "", Section = "", CGPA = "", Rel = "", Phn = "", Mail = "", DOB = "", Loc = "";
            String Payment = "";
            String Vaccinated = "", Blood_Donate = "", Blood_group = "", Last_Donate = "";
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `students` WHERE ID = '" + Given_ID + "'";


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
                Semester = Convert.ToString(reader[7]);
                CGPA = Convert.ToString(reader[9]);          
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Fname;
            LName_Box.Text = Lname;
            cgpa_box.Text = CGPA;
        
            ///Semester
            if (Semester == "1_1")
            {
                comboBox_semester.SelectedIndex = 0;
            }
            else if (Semester == "1_2")
            {
                comboBox_semester.SelectedIndex = 1;
            }
            else if (Semester == "1_3")
            {
                comboBox_semester.SelectedIndex = 2;
            }
            else if (Semester == "2_1")
            {
                comboBox_semester.SelectedIndex = 3;
            }
            else if (Semester == "2_2")
            {
                comboBox_semester.SelectedIndex = 4;
            }
            else if (Semester == "2_3")
            {
                comboBox_semester.SelectedIndex = 5;
            }
            else if (Semester == "3_1")
            {
                comboBox_semester.SelectedIndex = 6;
            }
            else if (Semester == "3_2")
            {
                comboBox_semester.SelectedIndex = 7;
            }
            else if (Semester == "3_3")
            {
                comboBox_semester.SelectedIndex = 8;
            }
            else if (Semester == "4_1")
            {
                comboBox_semester.SelectedIndex = 9;
            }
            else if (Semester == "4_2")
            {
                comboBox_semester.SelectedIndex = 10;
            }
            else if (Semester == "4_3")
            {
                comboBox_semester.SelectedIndex = 11;
            }
            else
            {
                comboBox_semester.SelectedIndex = -1;
            }

            ///////Payment Combobox 
             Query = "SELECT `Payment` FROM `result` WHERE id='"+Given_ID+"'";


             mycon = new MySqlConnection(Connection);
             myCom = new MySqlCommand(Query, mycon);

          
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                Payment = Convert.ToString(reader[0]);             
            }
            mycon.Close();

            if (Payment == "Paid")
            {
                comboBox_Payment.SelectedIndex = 0;
            }
            else if (Payment == "UnPaid")
            {
                comboBox_Payment.SelectedIndex = 1;
            }
            else if (Payment == "")
            {
                comboBox_Payment.SelectedIndex = 1;
            }
          //  MessageBox.Show(Payment);

            if (id == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
        }

        private void search_btn_Name(object sender, RoutedEventArgs e)
        {
            ID_box_s.Text = "";

            String Given_Name = Name_box_s_.Text;
            //  MessageBoxResult result = MessageBox.Show(""+Given_ID);
            String id = "", pass = "";
            String Fname = "", Lname = "", Age = "", Sex = "", Department = "", Semester = "", Section = "", CGPA = "", Rel = "", Phn = "", Mail = "", DOB = "", Loc = "";
            String Vaccinated = "", Blood_Donate = "", Blood_group = "", Last_Donate = "";
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `students` WHERE fname = '" + Given_Name + "'";


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
                Semester = Convert.ToString(reader[7]);
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Fname;
            LName_Box.Text = Lname;
            cgpa_box.Text = CGPA;

            ///Semester
            if (Semester == "1_1")
            {
                comboBox_semester.SelectedIndex = 0;
            }
            else if (Semester == "1_2")
            {
                comboBox_semester.SelectedIndex = 1;
            }
            else if (Semester == "1_3")
            {
                comboBox_semester.SelectedIndex = 2;
            }
            else if (Semester == "2_1")
            {
                comboBox_semester.SelectedIndex = 3;
            }
            else if (Semester == "2_2")
            {
                comboBox_semester.SelectedIndex = 4;
            }
            else if (Semester == "2_3")
            {
                comboBox_semester.SelectedIndex = 5;
            }
            else if (Semester == "3_1")
            {
                comboBox_semester.SelectedIndex = 6;
            }
            else if (Semester == "3_2")
            {
                comboBox_semester.SelectedIndex = 7;
            }
            else if (Semester == "3_3")
            {
                comboBox_semester.SelectedIndex = 8;
            }
            else if (Semester == "4_1")
            {
                comboBox_semester.SelectedIndex = 9;
            }
            else if (Semester == "4_2")
            {
                comboBox_semester.SelectedIndex = 10;
            }
            else if (Semester == "4_3")
            {
                comboBox_semester.SelectedIndex = 11;
            }
            else
            {
                comboBox_semester.SelectedIndex = -1;
            }
            if (id == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
        }

      

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            FName_Box.Text = "";
            LName_Box.Text = "";
            cgpa_box.Text = "";
          

          
            ///Semester
            comboBox_semester.SelectedIndex = -1;
            ///Payment
            comboBox_Payment.SelectedIndex = -1;
             
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
