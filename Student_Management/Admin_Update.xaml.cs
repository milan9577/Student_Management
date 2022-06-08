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
    /// Interaction logic for Admin_Update.xaml
    /// </summary>
    public partial class Admin_Update : Window
    {

        public String ID_fb = "";
        public String yourname = "";

        public Admin_Update()
        {
            InitializeComponent();
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ID_box.Text == "")
                {
                    MessageBoxResult result = MessageBox.Show("Invalid ID");
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
                    string DOB = Date_Box.Text;

                    String Sex = "", Merital_Status = "";

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


                    if (Merried.IsChecked == true)
                    {
                        Merital_Status = "Merried";
                    }
                    if (Unmerried.IsChecked == true)
                    {
                        Merital_Status = "Unmerried";
                    }

                    if (Password.Length >= 6)
                    {
                        //Message box for surity of data
                        MessageBoxResult results = MessageBox.Show(ID + "\n" + FName + "\n" + LName + "\n" + Age + "\n" + Sex + "\n" + Religion + "\n" + Merital_Status + "\n" + Email + "\n" + Phone
                            + "\n" + DOB + "\n" + Location + "\n" + Skill + "\n" + Password + "\n");


                        MessageBoxResult m = MessageBox.Show("Do you Update Information?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        switch (m)
                        {
                            //1st case
                            case MessageBoxResult.Yes:
                                /////Update Data////

                                String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                                String Query = "UPDATE `admin` SET `ID`='" + ID + "',`fname`='" + FName + "',`lname`='" + LName + "',`age`='" + Age + "',`sex`='" + Sex + "',`Religion`='" + Religion + "',`m_s`='" + Merital_Status + "',`mail`='" + Email + "',`phn`='" + Phone + "',`dob`='" + DOB + "',`loc`='" + Location + "',`skill`='" + Skill + "',`pass`='" + Password + "' WHERE id='" + ID + "'";



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
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Password Digit should be 5+");
                    }
                }
            }catch(Exception ex)
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
            FName_Box.Text = "";
            mail_box.Text = "";
            Phn_Box.Text = "";
            Loc_box.Text = "";
            Skill_Box.Text = "";
            pass_box.Text = "";
            Date_Box.Text = "";
            

            ////Check Box
            
             Merried.IsChecked = false;           
             Unmerried.IsChecked = false;          

            ///Radio Button
            RB_Male.IsChecked = false;    
            RB_Female.IsChecked = false;        
            RB_Other.IsChecked = false;

            //  Religion By Combo box
            comboBox_rl.SelectedIndex = -1;
            
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
           

            After_Login a = new After_Login();

            /////////////////////
            a.for_id.Text = for_id.Text;
            a.for_name.Text = for_name.Text;
            ////////////////////

            a.Show();
            this.Close();
        }
    }
}
