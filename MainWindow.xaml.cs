using System.Runtime.CompilerServices;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Credentials _credentials;
        public MainWindow()
        {
            InitializeComponent();
            _credentials = new Credentials();
            DataContext = this;
        }  
        private void ButtonClickGenerator(object sender, RoutedEventArgs e)
        {
            Main.Content = new Generator();
        }

        private void ButtonClickManager(object sender, RoutedEventArgs e)
        {
            Main.Content = new Manager(_credentials);
        }
    }
}