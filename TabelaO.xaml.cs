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
using System.Data;
using System.Data.SQLite;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for TabelaO.xaml
    /// </summary>
    public partial class TabelaO : UserControl
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public TabelaO()
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
        private void Obrisi_MouseEnter(object sender, RoutedEventArgs e)
        {
            Obrisi.Background = MouseEnter2();
        }
        private void Obrisi_MouseLeave(object sender, RoutedEventArgs e)
        {
            Obrisi.Background = MouseLeave2();

        }
        private void Stampaj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Stampaj.Background = MouseEnter2();
        }
        private void Stampaj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Stampaj.Background = MouseLeave2();

        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT Otpremnice.RedniBrojRobe as 'Redni broj robe',Otpremnice.DatumIzdavanja as 'Datum izdavanja',Otpremnice.NazivIzdavaoca as 'Naziv izdavaoca',Otpremnice.AdresaIzdavaoca as 'Adresa izdavaoca',Otpremnice.PIBIzdavaoca as 'PIB izdavaoca',Otpremnice.ImePrezimePrimaoca as 'Ime prezime primaoca'," +
                    "Otpremnice.AdresaPrimaoca as 'Adresa primaoca',Otpremnice.PIBPrimaoca as 'PIB primaoca',TabelaOtpremnica.VrstaRobe as 'Vrsta robe',TabelaOtpremnica.KolicinaRobe as 'Količina robe',TabelaOtpremnica.JedinicaMereRobe as 'Jedinica mere robe',TabelaOtpremnica.CenaRobe as 'Cena robe'" +
                    " FROM Otpremnice inner join TabelaOtpremnica on Otpremnice.RedniBrojRobe=TabelaOtpremnica.RedniBrojRobe;";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                Tabela4.ItemsSource = ds.DefaultView;
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

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {

            if (Tabela4.Items.Count > 0)
            {

                if (Tabela4.SelectedItem != null)
                {

                    int index = Tabela4.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela4.Items[index];
                    RedniBrojRobe.Text = item.Row[0].ToString();
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                    string messageBoxText = "Da li ste sigurni da želite izbrisati selektovanu otpremnicu?";
                    string caption = "Confirm";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                    if (result == MessageBoxResult.Yes)
                    {

                        try
                        {


                            String query = "DELETE FROM Otpremnice WHERE RedniBrojRobe = '" + RedniBrojRobe.Text + "'";
                            SQLiteCommand command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();

                            String query2 = "DELETE FROM TabelaOtpremnica WHERE RedniBrojRobe = '" + RedniBrojRobe.Text + "'";
                            SQLiteCommand command2 = new SQLiteCommand(query2, connection);
                            command2.ExecuteNonQuery();

                            String query3 = "SELECT Otpremnice.RedniBrojRobe as 'Redni broj robe',Otpremnice.DatumIzdavanja as 'Datum izdavanja',Otpremnice.NazivIzdavaoca as 'Naziv izdavaoca',Otpremnice.AdresaIzdavaoca as 'Adresa izdavaoca',Otpremnice.PIBIzdavaoca as 'PIB izdavaoca',Otpremnice.ImePrezimePrimaoca as 'Ime prezime primaoca'," +
                        "Otpremnice.AdresaPrimaoca as 'Adresa primaoca',Otpremnice.PIBPrimaoca as 'PIB primaoca',TabelaOtpremnica.VrstaRobe as 'Vrsta robe',TabelaOtpremnica.KolicinaRobe as 'Količina robe',TabelaOtpremnica.JedinicaMereRobe as 'Jedinica mere robe',TabelaOtpremnica.CenaRobe as 'Cena robe'" +
                        " FROM Otpremnice inner join TabelaOtpremnica on Otpremnice.RedniBrojRobe=TabelaOtpremnica.RedniBrojRobe;";
                            SQLiteDataAdapter command3 = new SQLiteDataAdapter(query3, connection);
                            DataTable ds = new DataTable();

                            command3.Fill(ds);
                            Tabela4.ItemsSource = ds.DefaultView;



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
                else
                {
                    MessageBox.Show("Morate selektovati otpremnicu!");
                }

            }
            else
            {
                MessageBox.Show("Tabela otpremnica je prazna!");
            }

        }

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            if (Tabela4.Items.Count > 0)
            {
                if (Tabela4.SelectedItem != null)
                {
                    int index = Tabela4.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela4.Items[index];

                    RedniBrojRobe.Text = item.Row[0].ToString();
                    DatumIzdavanja.Text = item.Row[1].ToString();
                    NazivIzdavaoca.Text = item.Row[2].ToString();
                    AdresaIzdavaoca.Text = item.Row[3].ToString();
                    PIBIzdavaoca.Text = item.Row[4].ToString();
                    ImePrezimePrimaoca.Text = item.Row[5].ToString();
                    AdresaPrimaoca.Text = item.Row[6].ToString();
                    PIBPrimaoca.Text = item.Row[7].ToString();
                    StampanjeOtpremnice izm = new StampanjeOtpremnice(this);
                    izm.Owner = Window.GetWindow(this);
                    izm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Morate selektovati otpremnicu!");
                }
            }
            else
            {
                MessageBox.Show("Tabela otpremnica je prazna!");
            }
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PrintScreen)
            {
                Stampaj_Click(sender, e);
            }
        }

        private void UserControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {

                Obrisi_Click(sender, e);

            }
        }

        public void SearchData(string valueToFind)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT Otpremnice.RedniBrojRobe as 'Redni broj robe',Otpremnice.DatumIzdavanja as 'Datum izdavanja',Otpremnice.NazivIzdavaoca as 'Naziv izdavaoca',Otpremnice.AdresaIzdavaoca as 'Adresa izdavaoca',Otpremnice.PIBIzdavaoca as 'PIB izdavaoca',Otpremnice.ImePrezimePrimaoca as 'Ime prezime primaoca'," +
                        "Otpremnice.AdresaPrimaoca as 'Adresa primaoca',Otpremnice.PIBPrimaoca as 'PIB primaoca',TabelaOtpremnica.VrstaRobe as 'Vrsta robe',TabelaOtpremnica.KolicinaRobe as 'Količina robe',TabelaOtpremnica.JedinicaMereRobe as 'Jedinica mere robe',TabelaOtpremnica.CenaRobe as 'Cena robe'" +
                        " FROM Otpremnice inner join TabelaOtpremnica on Otpremnice.RedniBrojRobe=TabelaOtpremnica.RedniBrojRobe WHERE ImePrezimePrimaoca LIKE '%" + valueToFind + "%' OR AdresaPrimaoca LIKE '%" + valueToFind + "%' OR Otpremnice.RedniBrojRobe LIKE '%" + valueToFind + "%' OR DatumIzdavanja LIKE '%" + valueToFind + "%' OR PIBPrimaoca LIKE '%" + valueToFind + "%'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Tabela4.ItemsSource = table.DefaultView;
            }
            finally
            {
                connection.Close();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                try
                {
                    String query = "SELECT Otpremnice.RedniBrojRobe as 'Redni broj robe',Otpremnice.DatumIzdavanja as 'Datum izdavanja',Otpremnice.NazivIzdavaoca as 'Naziv izdavaoca',Otpremnice.AdresaIzdavaoca as 'Adresa izdavaoca',Otpremnice.PIBIzdavaoca as 'PIB izdavaoca',Otpremnice.ImePrezimePrimaoca as 'Ime prezime primaoca'," +
                    "Otpremnice.AdresaPrimaoca as 'Adresa primaoca',Otpremnice.PIBPrimaoca as 'PIB primaoca',TabelaOtpremnica.VrstaRobe as 'Vrsta robe',TabelaOtpremnica.KolicinaRobe as 'Količina robe',TabelaOtpremnica.JedinicaMereRobe as 'Jedinica mere robe',TabelaOtpremnica.CenaRobe as 'Cena robe'" +
                    " FROM Otpremnice inner join TabelaOtpremnica on Otpremnice.RedniBrojRobe=TabelaOtpremnica.RedniBrojRobe;";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                    DataTable ds = new DataTable();

                    command.Fill(ds);
                    Tabela4.ItemsSource = ds.DefaultView;
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
                SearchData(SearchBox.Text);
            }
        }
    }
}
