using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG8051_Week_11_Lec_1_Sec_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void GenerateEmail(object sender, RoutedEventArgs e)
        {
            string firstname = fname.Text;
            string lastname = lname.Text;
            string userage = age.Text;

            string email = $"{firstname[0]}{lastname}{2024 - Convert.ToInt32(userage)}@conestogac.on.ca";

            result.Text = email;

            


        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\namiq\Desktop\test\Sec11.txt";

            string answer = GenerateOutput(sender, e);
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(answer);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string GenerateOutput(object sender, RoutedEventArgs e)
        {
            string firstname = fname.Text;
            string lastname = lname.Text;
            string userage = age.Text;
            string gender = "";

            if ((bool)male.IsChecked)
            {
                gender = (string)male.Content;
            }

            else if ((bool)female.IsChecked)
            {
                gender = (string)female.Content;
            }
            else if ((bool)PNTS.IsChecked)
            {
                gender = (string)PNTS.Content;
            }




            string courses = "";

            if ((bool)_1.IsChecked)
            {
                courses = courses + " " + _1.Content;
            }

            if ((bool)_2.IsChecked)
            {
                courses = courses + " " + _2.Content;
            }

            if ((bool)_3.IsChecked)
            {
                courses = courses + " " + _3.Content;
            }

            string answer = $"First Name : {firstname} \n Last Name: {lastname} \n Age: {userage} \n Gender: {gender} \n Courses: {courses}";
            // MessageBox.Show(answer);


            return answer;

        }
    }
}
