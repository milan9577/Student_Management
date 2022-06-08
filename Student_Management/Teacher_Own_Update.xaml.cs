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
    /// Interaction logic for Teacher_Own_Update.xaml
    /// </summary>
    public partial class Teacher_Own_Update : Window
    {
        public String Get_ID = "";
        public String Name_ = "", Age = "", Sex = "", Rel = "", Department = "", M_S = "", Mail = "", phn = "", DOB = "", Loc = "", Pass = "";

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            TeacherActivity t = new TeacherActivity();
            t.for_id.Text = for_id.Text;
            t.for_name.Text = for_name.Text;
            t.Show();
            this.Close();
        }

        public Teacher_Own_Update()
        {
            InitializeComponent();
        }

        private void Update_Click_btn(object sender, RoutedEventArgs e)
        {
            Get_ID = tb.Text;
            Loc = tbx_loc.Text;
            Mail= tbx_mail.Text;
            Pass = tbx_oldpass.Text;
            phn= tbx_phn.Text;

            MessageBox.Show(Get_ID+"\n"+ Loc + "\n" + Mail + "\n" + phn + "\n" + Pass);
            if (Pass.Length >= 5)
            {
                ////////////////////////
                MessageBoxResult m = MessageBox.Show("Do you Really modify Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Update Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "UPDATE `teacher` SET `Phone`='"+phn+"',`Email`='"+Mail+"',`Location`='"+Loc+"',`Pass`='"+Pass+"' WHERE id='"+Get_ID+"'";



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

        private void Reset_btn(object sender, RoutedEventArgs e)
        {
            tbx_loc.Text = "";
            tbx_mail.Text = "";
            tbx_oldpass.Text = "";
            tbx_phn.Text = "";
        }
    }
}
