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
    /// Interaction logic for KreiranjeO.xaml
    /// </summary>
    public partial class KreiranjeO : UserControl
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");
        SqlDataHelper sql = new SqlDataHelper();

        public KreiranjeO()
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
            RedniBrojRobe.Text = "";
            NazivIzdavaoca.Text = "";
            AdresaIzdavaoca.Text = "";
            PIBIzdavaoca.Text = "";
            DatumIzdavanja.SelectedDate = null;
            ImePrezimePrimaoca.Text = "";
            AdresaPrimaoca.Text = "";
            PIBPrimaoca.Text = "";
            VrstaRobe.SelectedItem = null;
            VrstaRobe.Text = "";
            KolicinaRobe.Text = "";
            JedinicaMereRobe.Text = "cm3";
            JedinicaMereRobe.Text = "";
            CenaRobe.Text = "";
        }
        private void ResetFields2()
        {
            VrstaRobe.SelectedItem = null;
            VrstaRobe.Text = "";
            KolicinaRobe.Text = "";
            JedinicaMereRobe.Text = "cm3";
            JedinicaMereRobe.Text = "";
            CenaRobe.Text = "";
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            if (TestFields() == 0)
            {
                if (Tabela6.Items.Count > 0)
                {
                    Otpremnica otpremnica = new Otpremnica(RedniBrojRobe.Text, DatumIzdavanja.Text, NazivIzdavaoca.Text, AdresaIzdavaoca.Text, PIBIzdavaoca.Text, ImePrezimePrimaoca.Text, AdresaPrimaoca.Text, PIBPrimaoca.Text);
                    

                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    try
                    {


                        String query = "INSERT INTO TabelaOtpremnica SELECT * FROM TabelaOtpremnica2";
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

                    if (sql.KreiranjeOtpremnice(otpremnica) && sql.BrisanjeTabeleOtpremnica())
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
                        String query = "SELECT VrstaRobe as 'Vrsta robe',KolicinaRobe as 'Količina robe',JedinicaMereRobe as 'Jedinica mere robe',CenaRobe as 'Cena robe' FROM TabelaOtpremnica2";
                        SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                        DataTable ds = new DataTable();

                        command.Fill(ds);
                        Tabela6.ItemsSource = ds.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    RedniBrojRobe.IsEnabled = true;
                }
                else
                {

                    MessageBox.Show("Tabela stavki je prazna");
                }

            }

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (TestFields2() == 0)
            {
                if (Tabela6.Items.Count == -1)
                {
                    TabelaOtpremnica otpremnica2 = new TabelaOtpremnica(RedniBrojRobe.Text, VrstaRobe.Text, KolicinaRobe.Text, JedinicaMereRobe.Text, CenaRobe.Text);
                    

                    if (sql.KreiranjeTabeleOtpremnica2(otpremnica2))
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
                        String query = "SELECT VrstaRobe as 'Vrsta robe',KolicinaRobe as 'Količina robe',JedinicaMereRobe as 'Jedinica mere robe',CenaRobe as 'Cena robe' FROM TabelaOtpremnica2";
                        SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                        DataTable ds = new DataTable();

                        command.Fill(ds);
                        Tabela6.ItemsSource = ds.DefaultView;
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

                    RedniBrojRobe.IsEnabled = false;

                    TabelaOtpremnica otpremnica2 = new TabelaOtpremnica(RedniBrojRobe.Text, VrstaRobe.Text, KolicinaRobe.Text, JedinicaMereRobe.Text, CenaRobe.Text);
                    

                    if (sql.KreiranjeTabeleOtpremnica2(otpremnica2))
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
                        String query = "SELECT VrstaRobe as 'Vrsta robe',KolicinaRobe as 'Količina robe',JedinicaMereRobe as 'Jedinica mere robe',CenaRobe as 'Cena robe' FROM TabelaOtpremnica2";
                        SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                        DataTable ds = new DataTable();

                        command.Fill(ds);
                        Tabela6.ItemsSource = ds.DefaultView;
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
            sql.BrisanjeTabeleOtpremnica();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT VrstaRobe as 'Vrsta robe',KolicinaRobe as 'Količina robe',JedinicaMereRobe as 'Jedinica mere robe',CenaRobe as 'Cena robe' FROM TabelaOtpremnica2";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                Tabela6.ItemsSource = ds.DefaultView;
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
            RedniBrojRobe.IsEnabled = true;
            RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBIzdavaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBIzdavaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            PIBPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KolicinaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KolicinaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JedinicaMereRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JedinicaMereRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            ImePrezimePrimaoca.Items.Clear();
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
                    if (!ImePrezimePrimaoca.Items.Contains(ds.Rows[i][0] + " " + ds.Rows[i][1]))
                    {
                        ImePrezimePrimaoca.Items.Add(ds.Rows[i][0] + " " + ds.Rows[i][1]);
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

        private void RedniBrojRobe_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back
                || e.Key == Key.Left || e.Key == Key.Right || key >= 34 && key <= 43 || e.Key == Key.Space && FindAllChar(' ', RedniBrojRobe.Text) <= 0 || e.Key == Key.OemQuestion && FindAllChar('/', RedniBrojRobe.Text) <= 0 || e.Key == Key.Divide && FindAllChar('/', RedniBrojRobe.Text) <= 0 || e.Key == Key.OemPeriod && FindAllChar('.', RedniBrojRobe.Text) <= 0 ||
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

        private void DatumIzdavanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
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

        private void ImePrezimePrimaoca_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void CenaRobe_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',', CenaRobe.Text) < 1 ||
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
            if (string.IsNullOrWhiteSpace(VrstaRobe.Text))
            {
                VrstaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                VrstaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelavrstarobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                VrstaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                VrstaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                labelavrstarobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(KolicinaRobe.Text) || (decimal.Parse(KolicinaRobe.Text) <= 0))
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
            if (string.IsNullOrWhiteSpace(JedinicaMereRobe.Text))
            {
                JedinicaMereRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                JedinicaMereRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelajedinicamere.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                JedinicaMereRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                JedinicaMereRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                labelajedinicamere.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(CenaRobe.Text) || (decimal.Parse(CenaRobe.Text) <= 0))
            {
                CenaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                CenaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                CenaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaRobe.Text = string.Format("{0:#,##0.00}", double.Parse(CenaRobe.Text));
            }
            if (string.IsNullOrWhiteSpace(RedniBrojRobe.Text))
            {
                RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }

            return neuspesno;
        }

            private int TestFields()
        {
            int neuspesno = 0;
            if (string.IsNullOrWhiteSpace(RedniBrojRobe.Text))
            {
                RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
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
            if (string.IsNullOrWhiteSpace(PIBIzdavaoca.Text))
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
            if (string.IsNullOrWhiteSpace(ImePrezimePrimaoca.Text))
            {
                ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(AdresaPrimaoca.Text))
            {
                AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                AdresaPrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                AdresaPrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(PIBPrimaoca.Text))
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
                    string[] parts = ImePrezimePrimaoca.Text.Split(' ');
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
            finally {
                connection.Close();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {

                if (!string.IsNullOrWhiteSpace(ImePrezimePrimaoca.Text))
                {
                    string[] parts2 = ImePrezimePrimaoca.Text.Split(' ');
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
                        ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Ime i prezime klijenta se ne poklapaju!", "GREŠKA");
                        neuspesno += 1;
                    }

                }
            }
            catch
            {
                ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
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
                String query = "SELECT COUNT(1) FROM Otpremnice WHERE RedniBrojRobe=@RedniBrojRobe";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@RedniBrojRobe", RedniBrojRobe.Text);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    MessageBox.Show("Otpremnica sa unetim rednim brojem robe već postoji!", "GREŠKA");
                    neuspesno += 1;
                }
            }
            catch
            {
                RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
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
                    string[] parts = ImePrezimePrimaoca.Text.Split(' ');
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

        private void ImePrezimePrimaoca_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ImePrezimePrimaoca.Text))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                try
                {
                    AdresaPrimaoca.Items.Clear();
                    string[] parts2 = ImePrezimePrimaoca.Text.Split(' ');
                    string imeklijenta2 = parts2[0];
                    string prezimeklijenta2 = parts2[1];

                    String query3 = "Select PIB from Klijenti where ImeKlijenta='" + imeklijenta2 + "' and PrezimeKlijenta='" + prezimeklijenta2 + "' and AdresaKlijenta='"+AdresaPrimaoca.Text+"'";
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void AdresaPrimaoca_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ImePrezimePrimaoca.Text) && !string.IsNullOrWhiteSpace(AdresaPrimaoca.Text))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                try
                {
                    string[] parts2 = ImePrezimePrimaoca.Text.Split(' ');
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

        private void VrstaRobe_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void JedinicaMereRobe_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void ImePrezimePrimaoca_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImePrezimePrimaoca.Text))
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

        private void VrstaRobe_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VrstaRobe.Text))
            {
                labelavrstarobe.Visibility = Visibility.Hidden;
            }
            else
            {
                labelavrstarobe.Visibility = Visibility.Visible;
            }
        }

        private void JedinicaMereRobe_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JedinicaMereRobe.Text))
            {
                labelajedinicamere.Visibility = Visibility.Hidden;
            }
            else
            {
                labelajedinicamere.Visibility = Visibility.Visible;
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

        private void ImePrezimePrimaoca_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void ImePrezimePrimaoca_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimePrimaoca.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimePrimaoca.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
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

        private void VrstaRobe_GotFocus(object sender, RoutedEventArgs e)
        {
            labelavrstarobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void VrstaRobe_LostFocus(object sender, RoutedEventArgs e)
        {
            labelavrstarobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            VrstaRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void JedinicaMereRobe_GotFocus(object sender, RoutedEventArgs e)
        {
            labelajedinicamere.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void JedinicaMereRobe_LostFocus(object sender, RoutedEventArgs e)
        {
            labelajedinicamere.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JedinicaMereRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JedinicaMereRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void RedniBrojRobe_LostFocus(object sender, RoutedEventArgs e)
        {
            RedniBrojRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RedniBrojRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
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

        private void CenaRobe_LostFocus(object sender, RoutedEventArgs e)
        {
            JedinicaMereRobe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            JedinicaMereRobe.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            if (!string.IsNullOrWhiteSpace(CenaRobe.Text))
            {
                CenaRobe.Text = string.Format("{0:#,##0.00}", double.Parse(CenaRobe.Text));
            }
        }
    }
}

