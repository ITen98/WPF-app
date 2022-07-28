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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pilana123.Class;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;
using MaterialDesignThemes.Wpf;
using System.Globalization;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for DodavanjeK.xaml
    /// </summary>
    public partial class DodavanjeK : UserControl
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public DodavanjeK()
        {
            InitializeComponent();
        }
        public Brush MouseEnter2()
        {
            SolidColorBrush green = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF2F9017");
            return green;
        }
        public Brush MouseLeave2()
        {
            SolidColorBrush normal = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF215913");
            return normal;
        }
        private void Dodaj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Dodaj.Background = MouseEnter2();
        }
        private void Dodaj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Dodaj.Background = MouseLeave2();

        }

        private void ResetFields() {
            Ime.Text = "";
            Prezime.Text = "";
            Adresa.Text = "";
            Kontakt.Text = "";
            PIB.Text = "";
            JMBG.Text = "";
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                if (TestFields() == 0)
                {
                    Klijent klijent = new Klijent(Ime.Text, Prezime.Text, Adresa.Text, Kontakt.Text, PIB.Text, JMBG.Text);
                    SqlDataHelper sql = new SqlDataHelper();

                    if (sql.DodavanjeKlijenta(klijent))
                    {
                        ResetFields();
                    }
                    else
                    {
                        MessageBox.Show("Greska pri dodavanju");

                    }
                }
            }
            finally
            {
                connection.Close();
            }
 
        }


        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ResetFields();
            Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void PIB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 ||
                              e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }
        }

        private void JMBG_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 ||
                              e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }
        }

        private void Ime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'",Ime.Text)<=0 || e.Key==Key.OemSemicolon && FindAllChar(';',Ime.Text)<=0 || e.Key==Key.OemPipe && FindAllChar2("\\",Ime.Text)<=0 || e.Key==Key.OemOpenBrackets && FindAllChar('[',Ime.Text)<=0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', Ime.Text) <= 0 ||
             e.Key == Key.Space && FindAllChar(' ', Ime.Text) < 1 || e.Key == Key.Left || e.Key == Key.Right);

        }

        private void Prezime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'", Prezime.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', Prezime.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", Prezime.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', Prezime.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', Prezime.Text) <= 0 ||
              e.Key == Key.Space && FindAllChar(' ', Prezime.Text) < 1 || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void Adresa_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Space && FindAllChar(' ', Adresa.Text) < 4 || e.Key == Key.Tab || e.Key == Key.Back || e.Key==Key.OemQuestion && FindAllChar('/',Adresa.Text)<=0 || e.Key==Key.Divide && FindAllChar ('/',Adresa.Text)<=0 || e.Key==Key.OemComma && FindAllChar(',',Adresa.Text)<=0
                || e.Key == Key.Left || e.Key == Key.Right || key >= 34 && key <= 43 || e.Key == Key.OemQuotes && FindAllChar2("'", Adresa.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', Adresa.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", Adresa.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', Adresa.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', Adresa.Text) <= 0 ||
                              key >= 74 && key <= 83);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }
        }
        

        private void Kontakt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            if (Kontakt.Text.Length - FindAllChar('+', Kontakt.Text) <= 13 ||
                      e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = !(key >= 34 && key <= 43 ||
                            key >= 74 && key <= 83 ||
                            e.Key == Key.OemPlus && FindAllChar('+', Kontakt.Text) < 1 ||
                            e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }

        }
        static int FindAllChar(Char target, String searched)
        {
            int startIndex = -1;
            int hitCount = 0;

            while (true)
            {
                startIndex = searched.IndexOf(
                    target, startIndex + 1,
                    searched.Length - startIndex - 1);

                if (startIndex < 0)
                    break;

                hitCount++;
            }

            return hitCount;
        }

        static int FindAllChar2(String target, String searched)
        {
            int startIndex = -1;
            int hitCount = 0;

            while (true)
            {
                startIndex = searched.IndexOf(
                    target, startIndex + 1,
                    searched.Length - startIndex - 1);

                if (startIndex < 0)
                    break;

                hitCount++;
            }

            return hitCount;
        }


        private int TestFields() 
        {

            int neuspesno = 0;
            if (string.IsNullOrWhiteSpace(Ime.Text))
            {
                Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(Prezime.Text))
                {
                    Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
                else
                {
                    Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                }
                if (string.IsNullOrWhiteSpace(Adresa.Text))
                {
                    Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
                else
                {
                    Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                }
                if (string.IsNullOrWhiteSpace(Kontakt.Text) || Kontakt.Text.Length < 12 || Kontakt.Text.Length > 15)
                {
                    Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
                else
                {
                    Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black"); ;
                }
                if (string.IsNullOrWhiteSpace(JMBG.Text) || JMBG.Text.Length != 13)
                {
                    JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
                else
                {
                    JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

                }
                if (string.IsNullOrWhiteSpace(PIB.Text) || PIB.Text.Length != 9)
                {
                    PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
                else
                {
                    PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

                }
;
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                try
                {
                    String query = "SELECT COUNT(1) FROM Klijenti WHERE PIB=@PIB";
                    SQLiteCommand command = new SQLiteCommand(query, connection);

                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PIB", PIB.Text);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    String query2 = "SELECT COUNT(1) FROM Klijenti WHERE JMBG=@JMBG";
                    SQLiteCommand command2 = new SQLiteCommand(query2, connection);

                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@JMBG", JMBG.Text);
                    int count2 = Convert.ToInt32(command2.ExecuteScalar());

                    if (count > 0)
                    {
                        PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Klijent sa unetim PIB već postoji!", "GREŠKA");
                    neuspesno += 1;

                }

                    if (count2 > 0)
                    {
                        JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Klijent sa unetim JMBG već postoji!", "GREŠKA");
                    neuspesno += 1;
                }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "GREŠKA");
                }
                finally
                {
                    connection.Close();
                }
            return neuspesno;

        }

        private void Kontakt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Kontakt.Text))
            {
                Kontakt.Text = string.Format("+381 ", Kontakt.Text);
            }
        }

        private void Kontakt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Kontakt.Text) || Kontakt.Text.Length < 5 || !Kontakt.Text.StartsWith("+381 "))
            {
                Kontakt.Text = string.Format("+381 ", Kontakt.Text);
            }
        }


        private void Ime_LostFocus(object sender, RoutedEventArgs e)
        {
            Ime.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(Ime.Text);
            Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void Prezime_LostFocus(object sender, RoutedEventArgs e)
        {
            Prezime.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(Prezime.Text);
            Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void Adresa_LostFocus(object sender, RoutedEventArgs e)
        {
            Adresa.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(Adresa.Text);
            Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void Kontakt_LostFocus(object sender, RoutedEventArgs e)
        {
            Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void PIB_LostFocus(object sender, RoutedEventArgs e)
        {
            PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void JMBG_LostFocus(object sender, RoutedEventArgs e)
        {
            JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }
    }
}
