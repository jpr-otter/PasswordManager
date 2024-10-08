using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    /// 


    // ! TODO: Encrypt-Algo hinzufügen
    //          Aufbau überlegen

    public partial class Manager : Page
    {
        private Credentials _credentials;
        public Manager(Credentials credentials)
        {
            InitializeComponent();
            _credentials = credentials;
            DataContext = this;
        }
        public Credentials Credentials => _credentials;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button clicked. Username: {_credentials.Username}");
            MessageBox.Show($"{_credentials.Username}");
        }

        private void AddPlatform_Button(object sender, RoutedEventArgs e)
        {

        }

        private void SaveChanges_Button(object sender, RoutedEventArgs e)
        {

        }

        private void AddField_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
