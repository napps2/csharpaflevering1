using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPFGraded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int count;

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void selectedUser(object sender, SelectionChangedEventArgs s)
        {
            if (boxen.SelectedItem is User)
            {
                User p = boxen.SelectedItem as User;

                IDBox.DataContext = p;
                NameBox.DataContext = p;
                AgeBox.DataContext = p;
                ScoreBox.DataContext = p;
            }
        }
        private void numberOfItems_Updater()
        {
            numberOfItems.Text = count.ToString() + " elementer" + " Sidst åbnet: " + DateTime.Now.TimeOfDay;
        }

        private void chooseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            var userList = new List<User>();
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                var fileStream = dlg.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        User user = new User(line);
                        boxen.Items.Add(user);
                        count++;
                    }
                    
                }
            }
            numberOfItems_Updater();
            //Read the contents of the file into a stream





        }
    }
}

