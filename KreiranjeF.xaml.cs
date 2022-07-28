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
using System.Globalization;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for KreiranjeF.xaml
    /// </summary>
    public partial class KreiranjeF : UserControl
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");
        SqlDataHelper sql = new SqlDataHelper();
        public KreiranjeF()
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
        private void Kreiraj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Kreiraj.Background = MouseEnter2();
        }
        private void Kreiraj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Kreiraj.Background = MouseLeave2();

        }
        private void ResetFields()
        {
            RedniBrojRacuna.Text = "";
            NazivIzdavaoca.Text = "";
            AdresaIzdavaoca.Text = "";
            PIBIzdavaoca.Text = "";
            MestoIzdavanja.Text = "";
            DatumIzdavanja.SelectedDate = null;
            ImePrezime.Text = "";
            AdresaPrimaoca.Text = "";
            PIBPrimaoca.Text = "";
            VrstaDobaraUsluge.SelectedItem = null;
            VrstaDobaraUsluge.Text = "";
            KolicinaRobe.Text = "";
            VisinaAvansa.Text = "";
            IznosOsnovice.Text = "";
            IznosPDV.Text = "";
            Ukupno.Text = "";
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {

            Faktura faktura = new Faktura(RedniBrojRacuna.Text, NazivIzdavaoca.Text, AdresaIzdavaoca.Text, PIBIzdavaoca.Text, MestoIzdavanja.Text, DatumIzdavanja.Text, ImePrezime.Text, AdresaPrimaoca.Text, PIBPrimaoca.Text);
           
            if (TestFields() == 0) {
                if (Tabela5.Items.Count > 0)
                {        
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    try
                    {


                        String query = "INSERT INTO TabelaFaktura SELECT * FROM TabelaFaktura2";
                        SQLiteCommand command = new SQLiteCommand(query, connection);
                        command.ExecuteNonQuery();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                    if (sql.KreiranjeFakture(faktura) && sql.BrisanjeTabeleFaktura())
                    {
                        ResetFields();
                    }
                    else
                    {
                        MessageBox.Show("Greska pri dodavanju");

                    }

                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                    try
                    {

                        String query = "SELECT VrstaDobaraUsluge as 'Vrsta dobara-usluge',KolicinaRobe as 'Količina robe',VisinaAvansa as 'Visina avansa',IznosOsnovice as 'Iznos osnovice',IznosPDV as 'Iznos PDV',Ukupno FROM TabelaFaktura2";
                        SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                        DataTable ds = new DataTable();

                        command.Fill(ds);
                        Tabela5.ItemsSource = ds.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                    RedniBrojRacuna.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Tabela stavki je prazna!");
                }
            }


        }
        private void ResetFields2()
        {
            VrstaDobaraUsluge.SelectedItem = null;
            VrstaDobaraUsluge.Text = "";
            KolicinaRobe.Text = "";
            VisinaAvansa.Text = "";
            IznosOsnovice.Text = "";
            IznosPDV.Text = "";
            Ukupno.Text = "";
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (TestFields2() == 0) { 
            if (Tabela5.Items.Count == -1)
            {
                TabelaFaktura faktura2 = new TabelaFaktura(RedniBrojRacuna.Text, VrstaDobaraUsluge.Text, KolicinaRobe.Text, VisinaAvansa.Text, IznosOsnovice.Text, IznosPDV.Text, Ukupno.Text);
                


                if (sql.KreiranjeTabeleFaktura2(faktura2))
                {
                    ResetFields2();
                }
                else
                {
                    MessageBox.Show("Greska pri dodavanju");

                }

                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                    try
                {
                    String query = "SELECT VrstaDobaraUsluge as 'Vrsta dobara-usluge',KolicinaRobe as 'Količina robe',VisinaAvansa as 'Visina avansa',IznosOsnovice as 'Iznos osnovice',IznosPDV as 'Iznos PDV',Ukupno FROM TabelaFaktura2";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                    DataTable ds = new DataTable();

                    command.Fill(ds);
                    Tabela5.ItemsSource = ds.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    finally
                    {
                        connection.Close();
                    }
            }
            else
            {
                RedniBrojRacuna.IsEnabled = false;

                TabelaFaktura faktura2 = new TabelaFaktura(RedniBrojRacuna.Text, VrstaDobaraUsluge.Text, KolicinaRobe.Text, VisinaAvansa.Text, IznosOsnovice.Text, IznosPDV.Text, Ukupno.Text);
                

                if (sql.KreiranjeTabeleFaktura2(faktura2))
                {
                    ResetFields2();
                }
                else
                {
                    MessageBox.Show("Greska pri dodavanju");

                }
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                    try
                {
                    String query = "SELECT VrstaDobaraUsluge as 'Vrsta dobara-usluge',KolicinaRobe as 'Količina robe',VisinaAvansa as 'Visina avansa',IznosOsnovice as 'Iznos osnovice',IznosPDV as 'Iznos PDV',Ukupno FROM TabelaFaktura2";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                    DataTable ds = new DataTable();

                    command.Fill(ds);
                    Tabela5.ItemsSource = ds.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    finally
                    {
                        connection.Close();
                    }
            }

            }

        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            sql.BrisanjeTabeleFaktura();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT VrstaDobaraUsluge as 'Vrsta dobara-usluge',KolicinaRobe as 'Količina robe',VisinaAvansa as 'Visina avansa',IznosOsnovice as 'Iznos osnovice',IznosPDV as 'Iznos PDV',Ukupno FROM TabelaFaktura2";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                Tabela5.ItemsSource = ds.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            ResetFields();
            RedniBrojRacuna.IsEnabled = true;
            RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            MestoIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            MestoIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaDobaraUsluge.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaDobaraUsluge.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KolicinaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KolicinaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VisinaAvansa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VisinaAvansa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosOsnovice.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosOsnovice.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Ukupno.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Ukupno.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            ImePrezime.Items.Clear();
            AdresaPrimaoca.Items.Clear();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "Select ImeKlijenta,PrezimeKlijenta from Klijenti";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();
                command.Fill(ds);
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    if (!ImePrezime.Items.Contains(ds.Rows[i][0] + " " + ds.Rows[i][1]))
                    {
                        ImePrezime.Items.Add(ds.Rows[i][0] + " " + ds.Rows[i][1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void NazivIzdavaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            NazivIzdavaoca.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(NazivIzdavaoca.Text);
            NazivIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void AdresaIzdavaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            AdresaIzdavaoca.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(AdresaIzdavaoca.Text);
            AdresaIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void MestoIzdavanja_LostFocus(object sender, RoutedEventArgs e)
        {
            MestoIzdavanja.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(MestoIzdavanja.Text);
            MestoIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            MestoIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
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

        private void RedniBrojRacuna_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back
                || e.Key == Key.Left || e.Key == Key.Right || key >= 34 && key <= 43 || e.Key == Key.Space && FindAllChar(' ', RedniBrojRacuna.Text) <= 0 || e.Key == Key.OemQuestion && FindAllChar('/', RedniBrojRacuna.Text) <= 0 || e.Key == Key.Divide && FindAllChar('/', RedniBrojRacuna.Text) <= 0 || e.Key == Key.OemPeriod && FindAllChar('.', RedniBrojRacuna.Text) <= 0 ||
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

        private void AdresaIzdavaoca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Space && FindAllChar(' ', AdresaIzdavaoca.Text) < 4 || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuestion && FindAllChar('/', AdresaIzdavaoca.Text) <= 0 || e.Key == Key.Divide && FindAllChar('/', AdresaIzdavaoca.Text) <= 0 || e.Key == Key.OemComma && FindAllChar(',', AdresaIzdavaoca.Text) <= 0
                || e.Key == Key.Left || e.Key == Key.Right || key >= 34 && key <= 43 || e.Key == Key.OemQuotes && FindAllChar2("'", AdresaIzdavaoca.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', AdresaIzdavaoca.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", AdresaIzdavaoca.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', AdresaIzdavaoca.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', AdresaIzdavaoca.Text) <= 0 ||
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

        private void PIBIzdavaoca_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void MestoIzdavanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'", MestoIzdavanja.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', MestoIzdavanja.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", MestoIzdavanja.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', MestoIzdavanja.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', MestoIzdavanja.Text) <= 0 ||
             e.Key == Key.Space && FindAllChar(' ', MestoIzdavanja.Text) < 2 || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void DatumIzdavanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void ImePrezime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void AdresaPrimaoca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void PIBPrimaoca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void KolicinaRobe_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !( key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',', KolicinaRobe.Text) <= 0 ||
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

        private void VisinaAvansa_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',', VisinaAvansa.Text) < 1 ||
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

        private void IznosOsnovice_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',', IznosOsnovice.Text) < 1 ||
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

        private void IznosPDV_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private int TestFields2()
        {
            int neuspesno = 0;

            if (string.IsNullOrWhiteSpace(VrstaDobaraUsluge.Text))
            {
                VrstaDobaraUsluge.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                VrstaDobaraUsluge.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                VrstaDobaraUsluge.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                VrstaDobaraUsluge.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(KolicinaRobe.Text))
            {
                KolicinaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                KolicinaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                KolicinaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                KolicinaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(VisinaAvansa.Text))
            {
                VisinaAvansa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                VisinaAvansa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                VisinaAvansa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                VisinaAvansa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                VisinaAvansa.Text = string.Format("{0:#,##0.00}", double.Parse(VisinaAvansa.Text));
            }
            if (string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                IznosOsnovice.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                IznosOsnovice.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                IznosOsnovice.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                IznosOsnovice.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                IznosOsnovice.Text = string.Format("{0:#,##0.00}", double.Parse(IznosOsnovice.Text));
            }
            if (string.IsNullOrWhiteSpace(IznosPDV.Text))
            {
                IznosPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                IznosPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                IznosPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                IznosPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(Ukupno.Text))
            {
                Ukupno.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                Ukupno.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                Ukupno.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Ukupno.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                Ukupno.Text = string.Format("{0:#,##0.00}", double.Parse(Ukupno.Text));
            }
            if (string.IsNullOrWhiteSpace(RedniBrojRacuna.Text))
            {
                RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }

            return neuspesno;

        }
        private int TestFields()
        {
            int neuspesno = 0;
            if (string.IsNullOrWhiteSpace(RedniBrojRacuna.Text))
            {
                RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(NazivIzdavaoca.Text))
            {
                NazivIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                NazivIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                NazivIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                NazivIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(AdresaIzdavaoca.Text))
            {
                AdresaIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                AdresaIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                AdresaIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }

            if (string.IsNullOrWhiteSpace(MestoIzdavanja.Text))
            {
                MestoIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                MestoIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                MestoIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                MestoIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(DatumIzdavanja.Text))
            {
                DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(ImePrezime.Text) || !ImePrezime.Text.Contains(' '))
            {
                ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(AdresaPrimaoca.Text))
            {
                AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(PIBIzdavaoca.Text) || PIBIzdavaoca.Text.Length !=9)
            {
                PIBIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                PIBIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                PIBIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                PIBIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
 
            if (string.IsNullOrWhiteSpace(PIBPrimaoca.Text) || PIBPrimaoca.Text.Length !=9)
            {
                PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                if (!string.IsNullOrWhiteSpace(PIBPrimaoca.Text))
                {
                    string[] parts = ImePrezime.Text.Split(' ');
                    String query = "SELECT COUNT(1) FROM Klijenti WHERE PIB=@PIBPrimaoca and ImeKlijenta=@ImeKlijenta and PrezimeKlijenta=@PrezimeKlijenta";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    string imeklijenta = parts[0];
                    string prezimeklijenta = parts[1];

                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PIBPrimaoca", PIBPrimaoca.Text);
                    command.Parameters.AddWithValue("@ImeKlijenta", imeklijenta);
                    command.Parameters.AddWithValue("@PrezimeKlijenta", prezimeklijenta);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count <= 0)
                    {
                        PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("PIB broj se ne poklapa sa imenom i prezimenom klijenta!", "GREŠKA");
                        neuspesno += 1;
                    }
                }

            }
            catch
            {
                PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
            }
            finally
            {
                connection.Close();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {

                if (!string.IsNullOrWhiteSpace(ImePrezime.Text))
                {
                    string[] parts2 = ImePrezime.Text.Split(' ');
                    String query2 = "SELECT COUNT(1) FROM Klijenti WHERE ImeKlijenta=@ImeKlijenta and PrezimeKlijenta=@PrezimeKlijenta";
                    SQLiteCommand command2 = new SQLiteCommand(query2, connection);
                    string imeklijenta2 = parts2[0];
                    string prezimeklijenta2 = parts2[1];

                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@ImeKlijenta", imeklijenta2);
                    command2.Parameters.AddWithValue("@PrezimeKlijenta", prezimeklijenta2);
                    int count2 = Convert.ToInt32(command2.ExecuteScalar());


                    if (count2 <= 0)
                    {
                        ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Ime i prezime klijenta se ne poklapaju!", "GREŠKA");
                        neuspesno += 1;
                    }

                }
            }
            catch
            {
                ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
            }
            finally
            {
                connection.Close();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT COUNT(1) FROM Fakture WHERE RedniBrojRacuna=@RedniBrojRacuna";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@RedniBrojRacuna", RedniBrojRacuna.Text);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    MessageBox.Show("Faktura sa unetim rednim brojem računa već postoji!", "GREŠKA");
                    neuspesno += 1;
                }
            }
            catch
            {
                RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
            }
            finally
            {
                connection.Close();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {
                if (!string.IsNullOrWhiteSpace(AdresaPrimaoca.Text))
                {
                    string[] parts = ImePrezime.Text.Split(' ');
                    String query = "SELECT COUNT(1) FROM Klijenti WHERE AdresaKlijenta=@AdresaKlijenta and ImeKlijenta=@ImeKlijenta and PrezimeKlijenta=@PrezimeKlijenta";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    string imeklijenta = parts[0];
                    string prezimeklijenta = parts[1];

                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@AdresaKlijenta", AdresaPrimaoca.Text);
                    command.Parameters.AddWithValue("@ImeKlijenta", imeklijenta);
                    command.Parameters.AddWithValue("@PrezimeKlijenta", prezimeklijenta);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count <= 0)
                    {
                        AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Adresa se ne poklapa sa imenom i prezimenom klijenta!", "GREŠKA");
                        neuspesno += 1;
                    }
                }

            }
            catch
            {
                AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
            }
            finally
            {
                connection.Close();
            }

            return neuspesno;
        }


        private void IznosOsnovice_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IznosPDV.Text) && !string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                double iznos = Convert.ToDouble(IznosPDV.Text);
                double cena = Convert.ToDouble(IznosOsnovice.Text);
                double ukupno = cena + (cena * iznos * 0.01);
                Ukupno.Text = ukupno.ToString();
            }
            else
            {
                Ukupno.Text = "";
            }
        }

        private void IznosPDV_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IznosPDV.Text) && !string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                double iznos = Convert.ToDouble(IznosPDV.Text);
                double cena = Convert.ToDouble(IznosOsnovice.Text);
                double ukupno = cena + (cena * iznos * 0.01);
                Ukupno.Text = ukupno.ToString();
            }
            else
            {
                Ukupno.Text = "";
            }
        }

        private void IznosPDV_LostFocus(object sender, RoutedEventArgs e)
        {

            IznosPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            if (!string.IsNullOrWhiteSpace(IznosPDV.Text) && !string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                double iznos = Convert.ToDouble(IznosPDV.Text);
                double cena = Convert.ToDouble(IznosOsnovice.Text);
                double ukupno = cena + (cena * iznos * 0.01);
                Ukupno.Text = ukupno.ToString();
            }
            else
            {
                Ukupno.Text = "";
            }
        }

        private void IznosOsnovice_LostFocus(object sender, RoutedEventArgs e)
        {
            IznosOsnovice.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosOsnovice.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            if (!string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                IznosOsnovice.Text = string.Format("{0:#,##0.00}", double.Parse(IznosOsnovice.Text));
            }

            if (!string.IsNullOrWhiteSpace(IznosPDV.Text) && !string.IsNullOrWhiteSpace(IznosOsnovice.Text))
            {
                double iznos = Convert.ToDouble(IznosPDV.Text);
                double cena = Convert.ToDouble(IznosOsnovice.Text);
                double ukupno = cena + (cena * iznos * 0.01);
                Ukupno.Text = ukupno.ToString();
            }
            else
            {
                Ukupno.Text = "";
            }
        }

        private void Ukupno_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void ImePrezime_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ImePrezime.Text))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                try
                {
                    AdresaPrimaoca.Items.Clear();
                    string[] parts2 = ImePrezime.Text.Split(' ');
                    string imeklijenta2 = parts2[0];
                    string prezimeklijenta2 = parts2[1];

                    String query3 = "Select PIB from Klijenti where ImeKlijenta='" + imeklijenta2 + "' and PrezimeKlijenta='" + prezimeklijenta2 + "' and AdresaKlijenta='" + AdresaPrimaoca.Text + "'";
                    SQLiteCommand command3 = new SQLiteCommand(query3, connection);
                    SQLiteDataReader dr2 = command3.ExecuteReader();
                    while (dr2.Read())
                    {
                        PIBPrimaoca.Text = dr2.GetString(0);
                    }

                    String query2 = "Select AdresaKlijenta from Klijenti where ImeKlijenta='" + imeklijenta2 + "' and PrezimeKlijenta='" + prezimeklijenta2 + "'";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query2, connection);
                    DataTable ds = new DataTable();
                    command.Fill(ds);
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        if (!AdresaPrimaoca.Items.Contains(ds.Rows[i][0]))
                        {
                            AdresaPrimaoca.Items.Add(ds.Rows[i][0]);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Greška prilikom unosa!", "GREŠKA");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void AdresaPrimaoca_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ImePrezime.Text) && !string.IsNullOrWhiteSpace(AdresaPrimaoca.Text)) {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                string[] parts2 = ImePrezime.Text.Split(' ');
                string imeklijenta2 = parts2[0];
                string prezimeklijenta2 = parts2[1];

                String query3 = "Select PIB from Klijenti where ImeKlijenta='" + imeklijenta2 + "' and PrezimeKlijenta='" + prezimeklijenta2 + "' and AdresaKlijenta='" + AdresaPrimaoca.Text + "'";
                SQLiteCommand command3 = new SQLiteCommand(query3, connection);
                SQLiteDataReader dr2 = command3.ExecuteReader();
                while (dr2.Read())
                {
                    PIBPrimaoca.Text = dr2.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            }
        }

        private void VrstaDobaraUsluge_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void ImePrezime_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImePrezime.Text))
            {
                labelaime.Visibility = Visibility.Hidden;
            }
            else
            {
                labelaime.Visibility = Visibility.Visible;
            }
        }

        private void AdresaPrimaoca_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdresaPrimaoca.Text))
            {
                labelaadresa.Visibility = Visibility.Hidden;
            }
            else
            {
                labelaadresa.Visibility = Visibility.Visible;
            }
        }

        private void VrstaDobaraUsluge_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VrstaDobaraUsluge.Text))
            {
                labelavrstadobara.Visibility = Visibility.Hidden;
            }
            else
            {
                labelavrstadobara.Visibility = Visibility.Visible;
            }
        }

        private void NazivIzdavaoca_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back ||
             e.Key == Key.Space && FindAllChar(' ', NazivIzdavaoca.Text) < 3 || e.Key == Key.OemPeriod && FindAllChar('.', NazivIzdavaoca.Text) < 3 || e.Key == Key.OemQuotes && FindAllChar2("'", NazivIzdavaoca.Text) <= 2 || e.Key == Key.OemSemicolon && FindAllChar(';', NazivIzdavaoca.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", NazivIzdavaoca.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', NazivIzdavaoca.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', NazivIzdavaoca.Text) <= 0
             || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Subtract && FindAllChar('-', NazivIzdavaoca.Text) < 2 || key >= 34 && key <= 43 || key >= 74 && key <= 83);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }
        }

        private void ImePrezime_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void ImePrezime_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezime.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void AdresaPrimaoca_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void AdresaPrimaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void VrstaDobaraUsluge_GotFocus(object sender, RoutedEventArgs e)
        {
            labelavrstadobara.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void VrstaDobaraUsluge_LostFocus(object sender, RoutedEventArgs e)
        {
            labelavrstadobara.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaDobaraUsluge.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaDobaraUsluge.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void RedniBrojRacuna_LostFocus(object sender, RoutedEventArgs e)
        {
            RedniBrojRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RedniBrojRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void DatumIzdavanja_LostFocus(object sender, RoutedEventArgs e)
        {
            DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void PIBIzdavaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            PIBIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void PIBPrimaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void KolicinaRobe_LostFocus(object sender, RoutedEventArgs e)
        {
            KolicinaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KolicinaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void VisinaAvansa_LostFocus(object sender, RoutedEventArgs e)
        {
            VisinaAvansa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VisinaAvansa.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            if (!string.IsNullOrWhiteSpace(VisinaAvansa.Text))
            {
                VisinaAvansa.Text = string.Format("{0:#,##0.00}", double.Parse(VisinaAvansa.Text));
            }
        }

        private void Ukupno_LostFocus(object sender, RoutedEventArgs e)
        {
            Ukupno.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            Ukupno.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }
    }
}