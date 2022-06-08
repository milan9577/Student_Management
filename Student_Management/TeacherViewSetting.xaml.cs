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
    /// Interaction logic for TeacherViewSetting.xaml
    /// </summary>
    public partial class TeacherViewSetting : Window
    {
        public TeacherViewSetting()
        {
            InitializeComponent();
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
                String ID = ID_box.Text;
                String Name = FName_Box.Text;
                String Age = Age_box.Text;
                String Email = mail_box.Text;
                String Phone = Phn_Box.Text;
                String Location = Loc_box.Text;
                String Password = pass_box.Text;             
                String DOB = dob_box.Text;
                String Sex = "", Religion="", Department="",M_S="";



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
                Religion = (String)Religion_Temp.Content;


                var Department_Temp = (ComboBoxItem)comboBox_dprtmnt.SelectedItem;
                Department = (String)Department_Temp.Content;

              

                var M_S_Temp = (ComboBoxItem)comboBox_MS.SelectedItem;
                M_S = (String)M_S_Temp.Content;

                MessageBox.Show(ID + "\n" + Name + "\n" + Age + "\n" + Sex + "\n" + Department + "\n" + M_S + "\n" + Religion + "\n" + Email
               + "\n" + Phone + "\n" + DOB + "\n" + Location + "\n" + Password);


                if (Password.Length >= 5)
                {
                    ////////////////////////
                    MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (m)
                    {
                        //1st case
                        case MessageBoxResult.Yes:
                            /////Update Data////

                            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                            String Query = "UPDATE `teacher` SET `ID`='"+ID+ "',`Name`='"+Name+ "',`Age`='"+Age+ "',`Sex`='"+Sex+ "',`Religion`='"+Religion+ "',`Department`='"+Department+ "',`M_S`='"+M_S+ "',`Phone`='"+Phone+ "',`Email`='"+Email+ "',`DOB`='"+DOB+ "',`Location`='"+Location+ "',`Pass`='"+Password+ "' WHERE id='"+ID+"'";



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
                else
                {
                    MessageBoxResult result = MessageBox.Show("Password Should be 6 or More digit");
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
                        String Query = "DELETE FROM `teacher` WHERE id='" + ID + "'";



                        MySqlConnection mycon = new MySqlConnection(Connection);
                        MySqlCommand myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        MySqlDataReader reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                       


                        ///Delete Data Close///
                        ///
                          /////Delete Data////

                         Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                         Query = "DELETE FROM `message` WHERE id='" + ID + "'";



                        mycon = new MySqlConnection(Connection);
                        myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                        MessageBox.Show("ID Deleted Successfully");


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
            Age_box.Text = "";
            mail_box.Text = "";
            Phn_Box.Text = "";
            Loc_box.Text = "";
            pass_box.Text = "";
            dob_box.Text = "";

            ///Radio Button
            RB_Male.IsChecked = false;
            RB_Female.IsChecked = false;
            RB_Other.IsChecked = false;
            ///Religion
            comboBox_rl.SelectedIndex = -1;
            ///Department          
            comboBox_dprtmnt.SelectedIndex = -1;
            ///Religion           
            comboBox_MS.SelectedIndex = -1;
        }

        ///////
        ///Search Button/////
        ///////////
        private void search_btn(object sender, RoutedEventArgs e)
        {

            Name_box_s_.Text = "";

            String Given_ID = ID_box_s.Text;
            //  MessageBoxResult result = MessageBox.Show(""+Given_ID);
            String id = "", pass = "";
            String Name = "", Age = "", Sex = "", Department = "", Rel = "", Phn = "", Mail = "", DOB = "", Loc = "",M_S="";
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `teacher` WHERE ID = '" + Given_ID + "'";


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
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Name;                     
            Age_box.Text = Age;
            dob_box.Text = DOB;
            mail_box.Text = Mail;
            Phn_Box.Text = Phn;
            Loc_box.Text = Loc;
            pass_box.Text = pass;


            ///Radio Button
            if (Sex == "Male")
            {
                RB_Male.IsChecked = true;
            }
            else if (Sex == "Female")
            {
                RB_Female.IsChecked = true;
            }
            else if (Sex == "Other")
            {
                RB_Other.IsChecked = true;
            }
            else
            {
                RB_Male.IsChecked = false;
                RB_Female.IsChecked = false;
                RB_Other.IsChecked = false;
            }

            ///Religion
            if (Rel == "Hindu")
            {
                comboBox_rl.SelectedIndex = 0;
            }
            else if (Rel == "Muslim")
            {
                comboBox_rl.SelectedIndex = 1;
            }
            else if (Rel == "Buddhist")
            {
                comboBox_rl.SelectedIndex = 2;
            }
            else if (Rel == "Christian")
            {
                comboBox_rl.SelectedIndex = 3;
            }
            else
            {
                comboBox_rl.SelectedIndex = -1;
            }

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


            ///Merital Status
            if (M_S == "Merried")
            {
                comboBox_MS.SelectedIndex = 0;
            }
            else if (M_S == "Unmerried")
            {
                comboBox_MS.SelectedIndex = 1;
            }
          
            else
            {
                comboBox_MS.SelectedIndex = -1;
            }

            MessageBox.Show(id + "\n" + Name + "\n" + Age + "\n" + Sex + "\n" + Department + "\n" + M_S + "\n" + Rel + "\n" + Mail
               + "\n" + Phn + "\n" + DOB + "\n" + Loc + "\n" + pass);


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
            String Name = "", Age = "", Sex = "", Department = "", Rel = "", Phn = "", Mail = "", DOB = "", Loc = "", M_S = "";
            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = " SELECT * FROM `teacher` WHERE Name = '" + Given_Name + "'";


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
            }
            mycon.Close();

            ID_box.Text = id;
            FName_Box.Text = Name;
            Age_box.Text = Age;
            dob_box.Text = DOB;
            mail_box.Text = Mail;
            Phn_Box.Text = Phn;
            Loc_box.Text = Loc;
            pass_box.Text = pass;


            ///Radio Button
            if (Sex == "Male")
            {
                RB_Male.IsChecked = true;
            }
            else if (Sex == "Female")
            {
                RB_Female.IsChecked = true;
            }
            else if (Sex == "Other")
            {
                RB_Other.IsChecked = true;
            }
            else
            {
                RB_Male.IsChecked = false;
                RB_Female.IsChecked = false;
                RB_Other.IsChecked = false;
            }

            ///Religion
            if (Rel == "Hindu")
            {
                comboBox_rl.SelectedIndex = 0;
            }
            else if (Rel == "Muslim")
            {
                comboBox_rl.SelectedIndex = 1;
            }
            else if (Rel == "Buddhist")
            {
                comboBox_rl.SelectedIndex = 2;
            }
            else if (Rel == "Christian")
            {
                comboBox_rl.SelectedIndex = 3;
            }
            else
            {
                comboBox_rl.SelectedIndex = -1;
            }

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


            ///Merital Status
            if (M_S == "Merried")
            {
                comboBox_MS.SelectedIndex = 0;
            }
            else if (M_S == "Unmerried")
            {
                comboBox_MS.SelectedIndex = 1;
            }

            else
            {
                comboBox_MS.SelectedIndex = -1;
            }

            MessageBox.Show(id + "\n" + Name + "\n" + Age + "\n" + Sex + "\n" + Department + "\n" + M_S + "\n" + Rel + "\n" + Mail
               + "\n" + Phn + "\n" + DOB + "\n" + Loc + "\n" + pass);


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
