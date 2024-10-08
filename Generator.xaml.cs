using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for Generator.xaml
    /// </summary>
    /// 


    // ! TODO: 
    /*
     *   generate button deaktivieren wenn felder leer sind
     *  
     *   copy button ebenfalls deaktiveren wenn kein password generiert wurde
     *   
     *   manager weitermachen! nicht verzetteln, rudimentär lassen:
     *      password aus generator übernehmen
     *      platform zuordnen
     *      username zuordnen
     *      comments feld hinzufügen
     *      date stamp feld
     *      alle infos links in einer liste anzeigen
     *      einträge löschbar machen mit sicherheitsabfrage are you sure?
     *      comments editierbar
     *      username und password copytoclipbord
     *      Daten in Datei speichern
     *      bonus: masterpassword und daten verschlüsseln
     */




    public partial class Generator : Page
    {
        public Generator()
        {
            InitializeComponent();
        }

        private static string PlaceHolder => "Your Password will appear here";
        private static Random Random { get; } = new();

        private void GeneratePasswordClick(object sender, RoutedEventArgs e)
        {
            int amountUpperLetters = CheckForInteger(AmountUpperLettersTextBox, "The amount of upper case letters needs to be a number.", "Upper case letters set to zero");
            int amountLowerLetters = CheckForInteger(AmountLowerLettersTextBox, "The amount of lower case letters needs to be a number.", "Lower case letters set to zero");
            int amountNumbers = CheckForInteger(AmountNumbersTextBox, "The amount of numbers needs to be a number.", "Numbers set to zero");
            int amountSpecialCharacters = CheckForInteger(AmountSpecialCharactersTextBox, "The amount of special characters needs to be a number.", "Special characters set to zero");
            string generatedPassword = GeneratePassword(amountUpperLetters, amountLowerLetters, amountNumbers, amountSpecialCharacters); 
            
            GeneratedPasswordTextBox.Text = generatedPassword;
        }

        public static int CheckForInteger(TextBox textBoxName, string messageIfInvalid, string messageIfEmpty)
        {
            if (int.TryParse(textBoxName.Text, out int value))
            {
                return value;
            }
            else if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show(messageIfEmpty);
                return 0;
            }
            else
            {
                MessageBox.Show(messageIfInvalid);
                return 0;
            }
        }

        public static void FillList(List<char> password, string charSet, int charCount )
        {
            for (int i = 0; i < charCount; i++)
            {
                char randomChar = charSet[GenerateRandomNumber(charSet.Length)];
                int randomPosition = GenerateRandomNumber(password.Count + 1);
                password.Insert(randomPosition, randomChar);
            }
        }

        public static int GenerateRandomNumber(int range)
        {
            return Random.Next(0, range);
        }

        public static string GeneratePassword(int amountUpperLetters, int amountLowerLetters, int amountNumbers, int amountSpecialCharacters) 
        {
            List<char> password = [];

            string specialChars = "!@#$%^&*()[]{}+-=<>?/.,;:|'";
            string numbers = "1234567890";
            string alephbet = "abcdefghijklmnopqrstuvwxyz";
            string alephbetAllCaps = alephbet.ToUpper();

            FillList(password, alephbet, amountLowerLetters);
            FillList(password, alephbetAllCaps, amountUpperLetters);
            FillList(password, numbers, amountNumbers);
            FillList(password, specialChars, amountSpecialCharacters);
            
            string passwordString = new(password.ToArray());

            return passwordString;
        }

        private void CopyToClipBoardClick(object sender, RoutedEventArgs e)
        {
            string passwordToClipBoard = GeneratedPasswordTextBox.Text;

            if (passwordToClipBoard == PlaceHolder || string.IsNullOrEmpty(passwordToClipBoard))
            {
                MessageBox.Show("No password to copy.");
            }
            else
            {
                Clipboard.SetText(passwordToClipBoard);
                MessageBox.Show("Password copied to clipboard!");
            }
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            GeneratedPasswordTextBox.Text = PlaceHolder;
        }
    }
}
