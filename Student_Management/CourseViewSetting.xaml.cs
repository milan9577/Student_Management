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
    /// Interaction logic for CourseViewSetting.xaml
    /// </summary>
    public partial class CourseViewSetting : Window
    {
        public CourseViewSetting()
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
                String Teacher_Name = Convert.ToString(reader[1]);

                comboBox_Teacher_.Items.Insert(count, Teacher_Name);
                count++;
                // comboBox_Teacher_.Items.Add(Teacher_Name);
            }
            mycon.Close();


            ///////////////////////////////////
            //  Constraction End
        }

        private void modify_btn(object sender, RoutedEventArgs e)
        {
            if (ID_box.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
            else
            {
                ////////////////////////
                String Given_ID = ID_box_s.Text;
                String ID = ID_box.Text;
                String Name = FName_Box.Text;
               
                String  Department = "", C_T = "", Semester="";

                Department = comboBox_dprtmnt.Text;
                Semester = comboBox_semester.Text;
                C_T = comboBox_Teacher_.Text;


             

                MessageBox.Show(ID + "\n" + Name + "\n" + Department+"\n" + Semester+ "\n" + C_T);


               
                    ////////////////////////
                   MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (m)
                    {
                        //1st case
                        case MessageBoxResult.Yes:
                            /////Update Data////

                            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                            String Query = "UPDATE `course` SET `ID`='"+ID+ "',`Name`='"+Name+ "',`Department`='"+Department+ "',`Semester`='"+Semester+ "',`C_Teacher`='"+C_T+ "' WHERE id='"+Given_ID+"'";



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
        }

        private void Delete_btn(object sender, RoutedEventArgs e)
        {
            String ID = ID_box.Text;
            if (ID == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
            else
            {
                MessageBoxResult m = MessageBox.Show("Do you Really delete Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Delete Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "DELETE FROM `course` WHERE id='" + ID + "'";



                        MySqlConnection mycon = new MySqlConnection(Connection);
                        MySqlCommand myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        MySqlDataReader reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                        MessageBoxResult result = MessageBox.Show("ID Deleted Successfully");


                        ///Delete Data Close///

                        break;

                    //2nd Case
                    case MessageBoxResult.No:
                        break;
                }

            }
        }

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            FName_Box.Text = "";
            comboBox_dprtmnt.SelectedIndex = -1;
            comboBox_Teacher_.SelectedIndex = -1;
            comboBox_semester.SelectedIndex = -1;
        }

        private void search_btn(object sender, RoutedEventArgs e)
        {
            Name_box_s.Text = "";
            String Given_ID = ID_box_s.Text;
            //  MessageBoxResult result = MessageBox.Show(""+Given_ID);

            String id = "";
            String Name = "", Department = "", Semester="",C_T="";
            /////Data Retrive//////////

            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `course` WHERE ID = '" + Given_ID + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToString(reader[0]);
                Name = Convert.ToString(reader[1]);
                Department = Convert.ToString(reader[2]);
                Semester = Convert.ToString(reader[3]);
                C_T = Convert.ToString(reader[4]);         
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Name;
           

            ///Department
            if (Department == "CSE")
            {
                comboBox_dprtmnt.SelectedIndex = 0;
            }
            else if (Department == "EEE")
            {
                comboBox_dprtmnt.SelectedIndex = 1;
            }
            else if (Department == "Civil")
            {
                comboBox_dprtmnt.SelectedIndex = 2;
            }
            else if (Department == "BBA")
            {
                comboBox_dprtmnt.SelectedIndex = 3;
            }
            else
            {
                comboBox_dprtmnt.SelectedIndex = -1;
            }


           
            ///Semester     
            for(int i = 0; i < 12; i++)
            {
                comboBox_semester.SelectedIndex = i;
                String val=comboBox_semester.Text;
                if (val == Semester)
                {
                    break;
                }
                else
                {
                    comboBox_semester.SelectedIndex = -1;
                }
            }

            ///Course Teacher
            for(int i = 0; i < 20; i++)
            {
                comboBox_Teacher_.SelectedIndex = i;
                String val = comboBox_Teacher_.Text;
                if (val == C_T)
                {
                    break;
                }
                else
                {
                    comboBox_Teacher_.SelectedIndex = -1;
                }
            }

            

            if (id == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
        }

        private void search_btn_Name(object sender, RoutedEventArgs e)
        {
            ID_box_s.Text = "";
            String Given_Name = Name_box_s.Text;
            //  MessageBoxResult result = MessageBox.Show(""+Given_ID);

            String id = "";
            String Name = "", Department = "", Semester = "", C_T = "";
            /////Data Retrive//////////

            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `course` WHERE Name = '" + Given_Name + "'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToString(reader[0]);
                Name = Convert.ToString(reader[1]);
                Department = Convert.ToString(reader[2]);
                Semester = Convert.ToString(reader[3]);
                C_T = Convert.ToString(reader[4]);
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Name;


            ///Department
            if (Department == "CSE")
            {
                comboBox_dprtmnt.SelectedIndex = 0;
            }
            else if (Department == "EEE")
            {
                comboBox_dprtmnt.SelectedIndex = 1;
            }
            else if (Department == "Civil")
            {
                comboBox_dprtmnt.SelectedIndex = 2;
            }
            else if (Department == "BBA")
            {
                comboBox_dprtmnt.SelectedIndex = 3;
            }
            else
            {
                comboBox_dprtmnt.SelectedIndex = -1;
            }



            ///Semester     
            for (int i = 0; i < 12; i++)
            {
                comboBox_semester.SelectedIndex = i;
                String val = comboBox_semester.Text;
                if (val == Semester)
                {
                    break;
                }
                else
                {
                    comboBox_semester.SelectedIndex = -1;
                }
            }

            ///Course Teacher
            for (int i = 0; i < 20; i++)
            {
                comboBox_Teacher_.SelectedIndex = i;
                String val = comboBox_Teacher_.Text;
                if (val == C_T)
                {
                    break;
                }
                else
                {
                    comboBox_Teacher_.SelectedIndex = -1;
                }
            }



            if (id == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
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
