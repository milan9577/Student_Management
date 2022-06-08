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
using System.Data;
using MySql.Data.MySqlClient;

namespace Student_Management
{
    /// <summary>
    /// Interaction logic for All_Students.xaml
    /// </summary>
    public partial class All_Students : Window
    {
        public All_Students()
        {
            InitializeComponent();


            /////Data Retrive//////////
          /*  String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = " SELECT * FROM `students`";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);
            mycon.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
            DataTable dt = new DataTable("admin");
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            adp.Update(dt);
            mycon.Close();*/
        }

        private void Show_btn(object sender, RoutedEventArgs e)
        {
            String Department = "", Semester = "", Section = "",Sex="", Religion = "";
            var Religion_Temp = (ComboBoxItem)comboBox_rl.SelectedItem;
            Religion = (String)Religion_Temp.Content;


            var Department_Temp = (ComboBoxItem)comboBox_dprtmnt.SelectedItem;
            Department = (String)Department_Temp.Content;

            var Semester_Temp = (ComboBoxItem)comboBox_semester.SelectedItem;
            Semester = (String)Semester_Temp.Content;

            var Section_Temp = (ComboBoxItem)comboBox_section.SelectedItem;
            Section = (String)Section_Temp.Content;

            var Sex_temp = (ComboBoxItem)comboBox_Sex.SelectedItem;
            Sex = (String)Sex_temp.Content;

            String Blood_Group = comboBox_BloodGroup.Text;
            String Blood_Donate = comboBox_Blood_Donate.Text;
            String Vaccinated = comboBox_Vaccinated.Text;

            /////Data Retrive//////////
            String Connection = "Server=127.0.0.1;User ID=root; DataBase=project";
            String Query = "";
            if (Department == "ALL")
            {
                Department = "%";
            }
            if (Semester == "ALL")
            {
                Semester = "%";
            }
             if (Section == "ALL")
            {
                Section = "%";
            }
             if (Sex == "ALL")
            {
                Sex = "%";
            }
             if (Religion == "ALL")
            {
                Religion = "%";
            }
            if (Blood_Group == "ALL")
            {
                Blood_Group = "%";
            }
            if (Blood_Donate == "ALL")
            {
                Blood_Donate = "%";
            }
            if (Vaccinated == "ALL")
            {
                Vaccinated = "%";
            }


            //  MessageBox.Show(Department + "\n" + Semester + "\n" + Section + "\n" + Sex + "\n" + Religion);
            Query = "SELECT * FROM `students` WHERE Department LIKE '"+Department+"' AND Semester LIKE '"+Semester+"' AND Section LIKE '"+Section+"' AND sex LIKE '"+Sex+"' AND religion LIKE '"+Religion+ "'AND Vaccinated LIKE '" + Vaccinated + "'AND Blood_Donate LIKE '" + Blood_Donate + "'AND Blood_Group LIKE '" + Blood_Group + "'";

            MySqlConnection mycon = new MySqlConnection(Connection);
            MySqlCommand myCom = new MySqlCommand(Query, mycon);
            mycon.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(myCom);
            DataTable dt = new DataTable("admin");
            adp.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            adp.Update(dt);
            mycon.Close();

            //  MessageBox.Show(Department + "\n" + Semester + "\n" + Section + "\n" + Sex + "\n" + Religion);


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
