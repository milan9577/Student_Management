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
    /// Interaction logic for DeangoMessage.xaml
    /// </summary>
    public partial class DeangoMessage : Window
    {
        public DeangoMessage()
        {
            InitializeComponent();

            String Admin_Message = "";
            String Teacher_Messages = "";
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
                Teacher_Messages = Convert.ToString(reader[15]);
              
            }
            mycon.Close();

            Admin_Message_Box.Text = Admin_Message;
            Teacher_Message_Box.Text = Teacher_Messages;

          
        }

       

        private void M_T_A(object sender, RoutedEventArgs e)
        {
            String Message = Admin_Message_Box.Text;
            ////////////////////////
            MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (m)
            {
                //1st case
                case MessageBoxResult.Yes:
                    /////Update Data////

                    String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                    String Query = "UPDATE `message` SET `Admin`='"+Message+"' WHERE id='dean'";



                    MySqlConnection mycon = new MySqlConnection(Connection);
                    MySqlCommand myCom = new MySqlCommand(Query, mycon);
                    mycon.Open();
                    MySqlDataReader reader = myCom.ExecuteReader(); ;
                    mycon.Close();
                    MessageBoxResult result = MessageBox.Show("Message updated Successfully");


                    ///Update Data Close///

                    break;

                //2nd Case
                case MessageBoxResult.No:
                    break;
            }
        }

        private void M_T_T(object sender, RoutedEventArgs e)
        {
            String Message = Teacher_Message_Box.Text;
            ////////////////////////
            MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (m)
            {
                //1st case
                case MessageBoxResult.Yes:
                    /////Update Data////

                    String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                    String Query = "UPDATE `message` SET `Teacher`='" + Message + "' WHERE id='dean'";



                    MySqlConnection mycon = new MySqlConnection(Connection);
                    MySqlCommand myCom = new MySqlCommand(Query, mycon);
                    mycon.Open();
                    MySqlDataReader reader = myCom.ExecuteReader(); ;
                    mycon.Close();
                    MessageBoxResult result = MessageBox.Show("Message updated Successfully");


                    ///Update Data Close///

                    break;

                //2nd Case
                case MessageBoxResult.No:
                    break;
            }
        }

        private void M_T_S(object sender, RoutedEventArgs e)
        {
            String Semester = comboBox_semester.Text;
            String Message = Student_Message_Box.Text;

            if (Semester == "ALL")
            {
                MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Update Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "UPDATE `message` SET `1_1`='"+Message+ "',`1_2`='" + Message + "',`1_3`='" + Message + "',`2_1`='" + Message + "',`2_2`='" + Message + "',`2_3`='" + Message + "',`3_1`='" + Message + "',`3_2`='" + Message + "',`3_3`='" + Message + "',`4_1`='" + Message + "',`4_2`='" + Message + "',`4_3`='" + Message + "' WHERE id='dean';";



                        MySqlConnection mycon = new MySqlConnection(Connection);
                        MySqlCommand myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        MySqlDataReader reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                        MessageBoxResult result = MessageBox.Show("Message updated Successfully");


                        ///Update Data Close///

                        break;

                    //2nd Case
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Update Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "UPDATE `message` SET `"+Semester+"`='"+Message+"' WHERE id='dean'";



                        MySqlConnection mycon = new MySqlConnection(Connection);
                        MySqlCommand myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        MySqlDataReader reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                        MessageBoxResult result = MessageBox.Show("Message updated Successfully");


                        ///Update Data Close///

                        break;

                    //2nd Case
                    case MessageBoxResult.No:
                        break;
                }
            }

        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            DeanProfile d = new DeanProfile();
            d.Show();
            this.Close();
        }
    }
}
