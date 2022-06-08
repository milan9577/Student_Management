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
    /// Interaction logic for Add_Course.xaml
    /// </summary>
    public partial class Add_Course : Window
    {
        public Add_Course()
        {
            InitializeComponent();

            //////////////////////////////////
            int count = 0;
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";       
            String Query = " SELECT * FROM `teacher`";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {             
                String  Teacher_Name = Convert.ToString(reader[1]);

                comboBox_Teacher_.Items.Insert(count, Teacher_Name);
                count++;
               // comboBox_Teacher_.Items.Add(Teacher_Name);
            }
            mycon.Close();
            
        
        ///////////////////////////////////
        //  Constraction End
    }

        private void Reg_Click_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                String Checking_ID = "";

                String ID = ID_box.Text;
                String Name = FName_Box.Text;
                String Department = "", Semester = "", C_Teacher = "";


                var Department_Temp = (ComboBoxItem)comboBox_dprtmnt.SelectedItem;
                Department = (String)Department_Temp.Content;

                var Semester_Temp = (ComboBoxItem)comboBox_semester.SelectedItem;
                Semester = (String)Semester_Temp.Content;

                C_Teacher = comboBox_Teacher_.Text;

                MessageBox.Show(ID + "\n" + Name + "\n" + Department + "\n" + Semester + "\n" + C_Teacher);

                //////////////////////////////////////////////////////////
                ////ID Checking/////////////
                ///////////////////////////////
                String Connections = "Server=127.0.0.1;User ID=root; DataBase=project";
                String Querys = " SELECT * FROM `course` WHERE ID = '" + ID + "'";


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
                    MessageBoxResult m = MessageBox.Show("Do you relly Insert?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (m)
                    {
                        //1st case
                        case MessageBoxResult.Yes:
                            /////Insert Data////


                            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                            String Query = "INSERT INTO `course`(`ID`, `Name`, `Department`, `Semester`, `C_Teacher`) VALUES ('" + ID + "','" + Name + "','" + Department + "','" + Semester + "','" + C_Teacher + "')";



                            MySqlConnection mycon = new MySqlConnection(Connection);
                            MySqlCommand myCom = new MySqlCommand(Query, mycon);
                            mycon.Open();
                            MySqlDataReader reader = myCom.ExecuteReader(); ;
                            mycon.Close();
                            MessageBoxResult result = MessageBox.Show("Data Inserted Successfully");


                            ///Insert Data Close///

                            break;

                        //2nd Case
                        case MessageBoxResult.No:
                            break;
                    }

                }

                //////////////////////////////////////////////////////////
            }catch(Exception ex)
            {
                MessageBox.Show("Problem:" + Convert.ToString(ex));
            }

        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            FName_Box.Text = "";
                  
            ///Department          
            comboBox_dprtmnt.SelectedIndex = -1;
            ///Semester
            comboBox_semester.SelectedIndex = -1;
            ///Course Teacher
            comboBox_Teacher_.SelectedIndex = -1;
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
