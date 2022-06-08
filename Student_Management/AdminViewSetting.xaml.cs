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
    /// Interaction logic for AdminViewSetting.xaml
    /// </summary>
    public partial class AdminViewSetting : Window
    {
        public AdminViewSetting()
        {
            InitializeComponent();
        }

        private void modify_btn(object sender, RoutedEventArgs e)
        {
            String Deleted_ID = ID_box.Text;
            if (Deleted_ID == "")
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                String ID = ID_box.Text;
                String FName = FName_Box.Text;
                String LName = LName_Box.Text;
                String Age = Age_box.Text;
                String Email = mail_box.Text;
                String Phone = Phn_Box.Text;
                String Location = Loc_box.Text;
                String Skill = Skill_Box.Text;
                String Password = pass_box.Text;
                String DOB = dob_box.Text;
                String Sex = "", Merital_Status = "",Status="",Religion="";

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

                ////Combo box
                var Religion_Temp = (ComboBoxItem)comboBox_rl.SelectedItem;
                Religion = (String)Religion_Temp.Content;

                var Status_Temp = (ComboBoxItem)comboBox_status.SelectedItem;
                Status = (String)Status_Temp.Content;

                ////Combo box


                if (Merried.IsChecked == true)
                {
                    Merital_Status = "Merried";
                }
                if (Unmerried.IsChecked == true)
                {
                    Merital_Status = "Unmerried";
                }


                ////Start Developing

                if (Password.Length >= 6)
                {

                    MessageBox.Show(ID + "\n" + FName + "\n" + LName + "\n" + Age + "\n" + Sex + "\n" + Religion + "\n" + Merital_Status + "\n" + Email + "\n" + Phone
                + "\n" + DOB + "\n" + Location + "\n" + Skill + "\n" + Password + "\n" + Status);
                    //Message box for surity of insert
                    MessageBoxResult m = MessageBox.Show("Do you relly Update data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        switch (m)
                        {
                            //1st case
                            case MessageBoxResult.Yes:
                                /////Insert Data////


                                String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                              

                                String Query = "UPDATE `admin` SET `ID`='"+ID+ "',`fname`='"+FName+ "',`lname`='"+LName+ "',`age`='"+Age+ "',`sex`='"+Sex+ "',`Religion`='"+Religion+ "',`m_s`='"+Merital_Status+ "',`mail`='"+Email+ "',`phn`='"+Phone+ "',`dob`='"+DOB+ "',`loc`='"+Location+ "',`skill`='"+Skill+ "',`pass`='"+Password+ "',`status`='"+Status+ "' WHERE id='"+ID+"'";
                               


                                MySqlConnection mycon = new MySqlConnection(Connection);
                                MySqlCommand myCom = new MySqlCommand(Query, mycon);
                                mycon.Open();
                                MySqlDataReader reader = myCom.ExecuteReader(); ;
                                mycon.Close();
                                MessageBoxResult result = MessageBox.Show("ID Updated Successfully");


                                ///Insert Data Close///

                                break;

                            //2nd Case
                            case MessageBoxResult.No:
                                break;
                        }
                }
                else
                {
                    MessageBoxResult result_ = MessageBox.Show("Password should be more than 5 digit");
                }
            }
       }


        private void Delete_btn(object sender, RoutedEventArgs e)
        {
            String Deleted_ID = ID_box.Text;
            if (Deleted_ID == "")
            {
                MessageBox.Show("Invalid ID");
            }
            else
            {
                MessageBoxResult m = MessageBox.Show("Do you Really delete Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Update Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "DELETE FROM `admin` WHERE id='" + Deleted_ID + "'";



                        MySqlConnection mycon = new MySqlConnection(Connection);
                        MySqlCommand myCom = new MySqlCommand(Query, mycon);
                        mycon.Open();
                        MySqlDataReader reader = myCom.ExecuteReader(); ;
                        mycon.Close();
                        MessageBoxResult result = MessageBox.Show("ID Deleted Successfully");


                        ///Update Data Close///

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
            LName_Box.Text = "";
            Age_box.Text = "";
            mail_box.Text = "";
            Phn_Box.Text = "";
            dob_box.Text = "";
            Loc_box.Text = "";
            Skill_Box.Text = "";
            pass_box.Text = "";

            Merried.IsChecked = false;
            Unmerried.IsChecked = false;

            RB_Male.IsChecked = false;
            RB_Female.IsChecked = false;
            RB_Other.IsChecked = false;
            comboBox_rl.SelectedIndex = -1;
            comboBox_status.SelectedIndex = -1;
        }

        private void search_btn(object sender, RoutedEventArgs e)
        {
            if (ID_box_s.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Invalid ID");
            }
            else
            {
                String ID = ID_box_s.Text;
                String id = "", pass = "";
                String fname = "", lname = "", age = "", sex = "", rel = "", m_s = "", mail = "", phn = "", dob = "", loc = "", skill = "", Status = "";

                /////Data Retrive//////////
                String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";

                String Query = " SELECT * FROM `admin` WHERE ID = '" + ID + "'";


                MySqlConnection mycon = new MySqlConnection(Connection);
                MySqlCommand myCom = new MySqlCommand(Query, mycon);

                MySqlDataReader reader;
                mycon.Open();
                reader = myCom.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToString(reader[0]);
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

                /////String Set/////////
                ID_box.Text = id;
                FName_Box.Text = fname;
                LName_Box.Text = lname;
                Age_box.Text = age;
                mail_box.Text = mail;
                Phn_Box.Text = phn;
                dob_box.Text = dob;
                Loc_box.Text = loc;
                Skill_Box.Text = skill;
                pass_box.Text = pass;

                ////Check Box
                if (m_s == "Merried")
                {
                    Merried.IsChecked = true;
                }
                else if (m_s == "Unmerried")
                {
                    Unmerried.IsChecked = true;
                }
                else {
                    Merried.IsChecked = false;
                    Unmerried.IsChecked = false;
                }


                ///Radio Button
                if (sex == "Male")
                {
                    RB_Male.IsChecked = true;
                }
                else if (sex == "Female")
                {
                    RB_Female.IsChecked = true;
                }
                else if (sex == "Other")
                {
                    RB_Other.IsChecked = true;
                }
                else {
                    RB_Male.IsChecked = false;
                    RB_Female.IsChecked = false;
                    RB_Other.IsChecked = false;
                }


                //  Religion By Combo box
                if (rel == "Hindu")
                {
                    comboBox_rl.SelectedIndex = 0;
                }
                else if (rel == "Muslim")
                {
                    comboBox_rl.SelectedIndex = 1;
                }
                else if (rel == "Buddhist")
                {
                    comboBox_rl.SelectedIndex = 2;
                }
                else if (rel == "Christian")
                {
                    comboBox_rl.SelectedIndex = 3;
                }
                else
                {
                    comboBox_rl.SelectedIndex = -1;
                }

                ///Status Combo box
                if (Status == "True")
                {
                    comboBox_status.SelectedIndex = 0;
                }
                else if (Status == "False")
                {
                    comboBox_status.SelectedIndex = 1;
                }
                else
                {
                    comboBox_status.SelectedIndex = -1;
                }
                //////////////////////////////


                //////////////////
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
