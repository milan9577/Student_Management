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
    /// Interaction logic for Admin_Registration.xaml
    /// </summary>
    public partial class Admin_Registration : Window
    {
        public String catch_Data = "";

        public Admin_Registration()
        {
            InitializeComponent();
        }

       

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            FName_Box.Text = "";
            LName_Box.Text="";
            Age_box.Text = ""; 
            mail_box.Text = "";
            Phn_Box.Text = "";
            Loc_box.Text = "";
            Skill_Box.Text = "";
            Pass_box.Password = "";
            CPass_box.Password = "";

            Merried.IsChecked = false;
            Unmerried.IsChecked = false;

            RB_Male.IsChecked = false;
            RB_Female.IsChecked = false;
            RB_Other.IsChecked = false;
            comboBox_rl.SelectedIndex = -1;
            //comboBox_status.SelectedIndex = -1;

        }

        private void Reg_Click_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                String Checking_ID = "";

                String ID = ID_box.Text;
                String FName = FName_Box.Text;
                String LName = LName_Box.Text;
                String Age = Age_box.Text;
                String Email = mail_box.Text;
                String Phone = Phn_Box.Text;
                String Location = Loc_box.Text;
                String Skill = Skill_Box.Text;
                String Password = Pass_box.Password;
                String Confirm_Password = CPass_box.Password;
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

                string DOB = cal_date.SelectedDate.Value.ToShortDateString();

                //Message box for surity of data
                MessageBoxResult results = MessageBox.Show(ID + "\n" + FName + "\n" + LName + "\n" + Age + "\n" + Sex + "\n" + Religion + "\n" + Merital_Status + "\n" + Email + "\n" + Phone
                    + "\n" + DOB + "\n" + Location + "\n" + Skill + "\n" + Password + "\n" + Confirm_Password);

                ////ID Checking/////////////
                ///////////////////////////////
                String Connections = "Server=127.0.0.1;User ID=root; DataBase=project";
                String Querys = " SELECT * FROM `admin` WHERE ID = '" + ID + "'";


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

                if (ID == Checking_ID)
                {
                    MessageBox.Show("This ID Already Exists");
                }
                else
                {

                    if (Password.Length >= 6)
                    {
                        if (Password == Confirm_Password)
                        {
                            //Message box for surity of insert
                            MessageBoxResult m = MessageBox.Show("Do you relly Insert?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            switch (m)
                            {
                                //1st case
                                case MessageBoxResult.Yes:
                                    /////Insert Data////


                                    String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                                    String Query = "";
                                    if (for_id.Text == "")
                                    {
                                        Query = "INSERT INTO `admin`(`ID`,`fname`, `lname`, `age`, `sex`, `Religion`, `m_s`, `mail`, `phn`, `dob`, `loc`, `skill`, `pass`, `status`) VALUES ('" + ID + "','" + FName + "','" + LName + "','" + Age + "','" + Sex + "','" + Religion + "','" + Merital_Status + "','" + Email + "','" + Phone + "','" + DOB + "','" + Location + "','" + Skill + "','" + Password + "','False')";
                                    }
                                    if (for_id.Text == "dean")
                                    {
                                        Query = "INSERT INTO `admin`(`ID`,`fname`, `lname`, `age`, `sex`, `Religion`, `m_s`, `mail`, `phn`, `dob`, `loc`, `skill`, `pass`, `status`) VALUES ('" + ID + "','" + FName + "','" + LName + "','" + Age + "','" + Sex + "','" + Religion + "','" + Merital_Status + "','" + Email + "','" + Phone + "','" + DOB + "','" + Location + "','" + Skill + "','" + Password + "','True')";
                                    }


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
                        else
                        {
                            MessageBoxResult result_ = MessageBox.Show("Password Not Matching");
                        }
                    }
                    else
                    {
                        MessageBoxResult result_ = MessageBox.Show("Password should be more than 5 digit");
                    }
                }


            }catch(Exception ex)
            {
                MessageBox.Show("Problem:" + Convert.ToString(ex));
            }


        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            if (for_id.Text == "dean")
            {
                DeanProfile m = new DeanProfile();
                m.Show();
                this.Close();
            }
            else
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
        }
    }
}
