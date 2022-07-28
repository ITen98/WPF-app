using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pilana123.Properties;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for IzmenaKlijenta.xaml
    /// </summary>
    public partial class IzmenaKlijenta : Window
    {


        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");
        TabelaK tbl;
        public IzmenaKlijenta(TabelaK tabela)
        {
            InitializeComponent();
            this.tbl = tabela;
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
        private void Sacuvaj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Sacuvaj.Background = MouseEnter2();
        }
        private void Sacuvaj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Sacuvaj.Background = MouseLeave2();

        }
        private void Povratak_MouseEnter(object sender, RoutedEventArgs e)
        {
            Povratak.Background = MouseEnter2();
        }
        private void Povratak_MouseLeave(object sender, RoutedEventArgs e)
        {
            Povratak.Background = MouseLeave2();

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Ime.Text = tbl.ImeKlijenta.Text;
            Prezime.Text = tbl.PrezimeKlijenta.Text;
            Adresa.Text = tbl.AdresaKlijenta.Text;
            Kontakt.Text = tbl.KontaktKlijenta.Text;
            PIB.Text = tbl.PIB.Text;
            JMBG.Text = tbl.JMBG.Text;
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

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {

            if (TestFields() == 0)
            {

                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                try
                {


                    String query = "UPDATE Klijenti SET ImeKlijenta='" + Ime.Text + "',PrezimeKlijenta='" + Prezime.Text + "',AdresaKlijenta='" + Adresa.Text + "',KontaktKlijenta='" + Kontakt.Text + "',PIB='" + PIB.Text + "',JMBG='"+JMBG.Text+"' WHERE ID=" + tbl.ID.Text + ";";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        Povratak_Click(sender, e);
                    }


                }
                catch
                {

                }
                finally
                {
                    connection.Close();
                }
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                try
                {


                    String query = "UPDATE Klijenti SET PIB='" + PIB.Text + "' WHERE ID=" + tbl.ID.Text + ";";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();



                }
                catch
                {
                    System.Windows.MessageBox.Show("Klijent sa unetim PIB već postoji! Proverite podatke.");
                    PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                    PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                }
                finally
                {
                    connection.Close();
                }

                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                try
                {


                    String query = "UPDATE Klijenti SET JMBG='" + JMBG.Text + "' WHERE ID=" + tbl.ID.Text + ";";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();


                }
                catch
                {
                    System.Windows.MessageBox.Show("Klijent sa unetim JMBG već postoji! Proverite podatke.");
                    JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                    JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\PilanaHelp.chm");
            }
        }

        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Povratak_Click(sender, e);
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


        private int TestFields()
        {

            int neuspesno = 0;
            if (string.IsNullOrWhiteSpace(Ime.Text))
            {
                Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                Ime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Ime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(Prezime.Text))
            {
                Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                Prezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Prezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(Adresa.Text))
            {
                Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                Adresa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Adresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(Kontakt.Text) || Kontakt.Text.Length < 12 || Kontakt.Text.Length > 15)
            {
                Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                Kontakt.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Kontakt.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black"); ;
            }
            if (string.IsNullOrWhiteSpace(JMBG.Text) || JMBG.Text.Length != 13)
            {
                JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                JMBG.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                JMBG.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            }
            if (string.IsNullOrWhiteSpace(PIB.Text) || PIB.Text.Length != 9)
            {
                PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff9f9f");
                neuspesno += 1;
            }
            else
            {
                PIB.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                PIB.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            }




            return neuspesno;
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

        private void Ime_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'", Ime.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', Ime.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", Ime.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', Ime.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', Ime.Text) <= 0 ||
             e.Key == Key.Space && FindAllChar(' ', Ime.Text) < 1 || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void Prezime_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'", Prezime.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', Prezime.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", Prezime.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', Prezime.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', Prezime.Text) <= 0 ||
              e.Key == Key.Space && FindAllChar(' ', Prezime.Text) < 1 || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void Adresa_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Space && FindAllChar(' ', Adresa.Text) < 4 || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuestion && FindAllChar('/', Adresa.Text) <= 0 || e.Key == Key.Divide && FindAllChar('/', Adresa.Text) <= 0 || e.Key == Key.OemComma && FindAllChar(',', Adresa.Text) <= 0
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

        private void Kontakt_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void Kontakt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Kontakt.Text) || Kontakt.Text.Length<5 || !Kontakt.Text.StartsWith("+381 "))
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

        private void Povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT ID,ImeKlijenta as 'Ime klijenta',PrezimeKlijenta as 'Prezime klijenta',AdresaKlijenta as 'Adresa klijenta',KontaktKlijenta as 'Kontakt klijenta',PIB as 'PIB klijenta',JMBG as 'JMBG klijenta' FROM Klijenti";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                tbl.Tabela1.ItemsSource = ds.DefaultView;
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }
        }

        private void PIB_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void JMBG_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        
    }
}
