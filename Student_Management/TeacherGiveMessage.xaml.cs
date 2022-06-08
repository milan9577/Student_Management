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
    /// Interaction logic for TeacherGiveMessage.xaml
    /// </summary>
    public partial class TeacherGiveMessage : Window
    {
        public String Get_ID = "";
        public TeacherGiveMessage()
        {
            InitializeComponent();
        }

        private void M_T_S(object sender, RoutedEventArgs e)
        {
            String Message = Student_Message_Box.Text;
            String Semester = comboBox_semester.Text;
              MessageBoxResult m = MessageBox.Show("Do you Really modify Message Data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (m)
                {
                    //1st case
                    case MessageBoxResult.Yes:
                        /////Update Data////

                        String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
                        String Query = "UPDATE `message` SET `"+Semester+"`='"+Message+"' WHERE id='"+for_id.Text+"'";



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

        private void LOAD(object sender, RoutedEventArgs e)
        {
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            // String Query = "SELECT `"+ID+"`, `"+Password+"`  FROM `admin` WHERE ID='"+ID+"';";
            String Query = "SELECT DISTINCT course.Semester FROM course INNER JOIN teacher ON course.C_Teacher = teacher.Name WHERE teacher.ID='" + for_id.Text+"'";


            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);

            MySqlDataReader reader;
            mycon.Open();
            reader = myCom.ExecuteReader();
            while (reader.Read())
            {
                String  QQ = Convert.ToString(reader[0]);
                comboBox_semester.Items.Add(QQ);
                    
                //MessageBox.Show(QQ);

            }
            mycon.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
           
                /////////////////////
                TeacherActivity a = new TeacherActivity();
                a.for_id.Text = for_id.Text;
                a.for_name.Text = for_name.Text;
                a.Show();
                this.Close();       
            ////////////////////
        }
    }
}
