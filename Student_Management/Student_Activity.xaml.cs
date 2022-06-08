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
    /// Interaction logic for Student_Activity.xaml
    /// </summary>
    public partial class Student_Activity : Window
    {
       public String Blood_Donate = "", Blood_Group = "", Last_Donate = "";
        public Student_Activity()
        {
            InitializeComponent();

            String My_ID = for_id.Text;
         //   MessageBox.Show(My_ID);
           
        }

        private void Update_Click_btn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Do you Update Information?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (m)
            {
                //1st case
                case MessageBoxResult.Yes:
                    /////Update Data////

                    String ID = tb.Text;
                    String Phn = tbx_phn.Text;
                    String Mail = tbx_mail.Text;
                    String loc = tbx_loc.Text;

                    String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                    String Query = "UPDATE `students` SET `phn`= '"+Phn+"',`mail`= '"+Mail+"',`location`= '"+loc+"' WHERE ID = '"+ID+"'";



                    MySqlConnection mycon = new MySqlConnection(Connection);
                    MySqlCommand myCom = new MySqlCommand(Query, mycon);
                    mycon.Open();
                    MySqlDataReader reader = myCom.ExecuteReader(); ;
                    mycon.Close();
                    MessageBoxResult result = MessageBox.Show("Data Updated Successfully");


                    ///Update Data Close///

                    break;

                //2nd Case
                case MessageBoxResult.No:
                    break;
            }
           
        }

        private void Update_Password(object sender, RoutedEventArgs e)
        {
            String ID = tb.Text;
            String Password = tbx_oldpass.Text;
            String New_Password = tbx_new_pass.Text;
            String Retype_New_Password = tbx_new_rpass.Text;

            String Get_Password = "";

            MessageBoxResult m = MessageBox.Show("Do you Update Password?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (m)
            {
                //1st case
                case MessageBoxResult.Yes:
                    /////Update Password////


                    String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                    String Query = " SELECT * FROM `students` WHERE ID = '" + ID + "'";
                    MySqlConnection mycon = new MySqlConnection(Connection);
                    MySqlCommand myCom = new MySqlCommand(Query, mycon);

                    MySqlDataReader reader;
                    mycon.Open();
                    reader = myCom.ExecuteReader();
                    while (reader.Read())
                    {    
                               
                        Get_Password = Convert.ToString(reader[14]);
            
                    }
                    mycon.Close();

                    if (Get_Password == Password)
                    {
                        //MessageBoxResult result = MessageBox.Show("Old Password is correct" + Get_Password);
                         if (New_Password.Length >= 6)
                         {
                             if (New_Password == Retype_New_Password)
                             {
                                 String Connections = "Server=127.0.0.1;User ID=root; DataBase=project";
                                 String Querys = "UPDATE `students` SET `password`='"+New_Password+"' WHERE ID='"+ID+"';";



                                 MySqlConnection mycons = new MySqlConnection(Connections);
                                 MySqlCommand myComs = new MySqlCommand(Querys, mycons);
                                 mycons.Open();
                                 MySqlDataReader readerss = myComs.ExecuteReader(); 
                                 mycons.Close();
                                 MessageBoxResult result = MessageBox.Show("Password Updated Successfully");

                                 ///Update Password Close///
                             }
                             else
                             {
                                 MessageBoxResult result = MessageBox.Show("Password Not Matched ");
                             }
                         }
                         else
                         {
                             MessageBoxResult result = MessageBox.Show("Password Should be 6 digit or more");
                         }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Old Password is not correct"+Get_Password);
                    }
                   
                    ///Update Password Data Close///

                    break;

                //2nd Case
                case MessageBoxResult.No:
                    break;
            }

        }

        private void Course(object sender, RoutedEventArgs e)
        {
            String ID = tb.Text;
            StudentActivity_2 s = new StudentActivity_2();
            s.for_id.Text = for_id.Text;

           // s.Get_ID = for_id.Text;
            s.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            All_Teacher_By_ a = new All_Teacher_By_();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.for_where.Text = "students";
            a.Show();
            this.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Student_Login a = new Student_Login();
            a.Show();
            this.Close();
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            InfoToStudents i = new InfoToStudents();
            i.for_id.Text = tb.Text;            
            i.for_dep.Text = tb_department.Text;
            i.for_sem.Text = tb_semester.Text;


            i.Show();
            this.Close();
        }

        private void All_result(object sender, RoutedEventArgs e)
        {
            String ID = tb.Text;
            String Semester = tb_semester.Text;
          //  MessageBox.Show(ID + "\n" + Semester);
            Student_OWN_result s = new Student_OWN_result();

            s.for_id.Text = ID;
            s.for_sem.Text = Semester;
            s.for_dep.Text = tb_department.Text;

            s.Show();
            this.Close();
        }

        private void All_Students(object sender, RoutedEventArgs e)
        {
            All_Students_By a = new All_Students_By();

            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            a.for_where.Text = "students";

            a.Show();
            this.Close();
        }

        private void Blood_Donation(object sender, RoutedEventArgs e)
        {
            Student_Blood_Donation s = new Student_Blood_Donation();

            s.tb.Text = tb.Text;
            s.tb_fname.Text = tb_fname.Text;
            s.tb_lname.Text = tb_lname.Text;
            s.last_donate_box_.Text = Last_Donate;


            ///Blood Donate         
            if (Blood_Donate == "Yes")
            {
                s.comboBox_Blood_Donate.SelectedIndex = 0;
            }
            else if (Blood_Donate == "No")
            {
                s.comboBox_Blood_Donate.SelectedIndex = 1;
            }
            else if (Blood_Donate == "")
            {
                s.comboBox_Blood_Donate.SelectedIndex = 1;
            }
            else
            {
               // s.comboBox_rl.SelectedIndex = -1;
            }

   


            ///Blood Group
            if (Blood_Group == "A+")
            {
                s.comboBox_BloodGroup.SelectedIndex = 0;
            }
            else if (Blood_Group == "A-")
            {
                s.comboBox_BloodGroup.SelectedIndex = 1;
            }
            else if (Blood_Group == "B+")
            {
                s.comboBox_BloodGroup.SelectedIndex = 2;
            }
            else if (Blood_Group == "B-")
            {
                s.comboBox_BloodGroup.SelectedIndex = 3;
            }
            else if (Blood_Group == "AB+")
            {
                s.comboBox_BloodGroup.SelectedIndex = 4;
            }
            else if (Blood_Group == "AB-")
            {
                s.comboBox_BloodGroup.SelectedIndex = 5;
            }
            else if (Blood_Group == "O+")
            {
                s.comboBox_BloodGroup.SelectedIndex = 6;
            }
            else if (Blood_Group == "O-")
            {
                s.comboBox_BloodGroup.SelectedIndex = 7;
            }
            else
            {
                s.comboBox_BloodGroup.SelectedIndex = -1;
            }

            s.Show();
            this.Close();
        }
    }
}
