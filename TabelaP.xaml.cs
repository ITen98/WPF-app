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
    /// Interaction logic for TabelaP.xaml
    /// </summary>
    public partial class TabelaP : UserControl
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public TabelaP()
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
        private void Izmeni_MouseEnter(object sender, RoutedEventArgs e)
        {
            Izmeni.Background = MouseEnter2();
        }
        private void Izmeni_MouseLeave(object sender, RoutedEventArgs e)
        {
            Izmeni.Background = MouseLeave2();

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
                String query = "SELECT ID,ImePrezimeVlasnika as 'Ime i prezime vlasnika',NazivFirme as 'Naziv firme',AdresaFirme as 'Adresa firme',KontaktVlasnika as 'Kontakt Vlasnika',BrojTekucegRacuna as 'Broj tekućeg računa',ImePrezimeKlijenta as 'Ime i prezime klijenta',AdresaKlijenta as 'Adresa klijenta',DatumIzdavanja as 'Datum izdavanja',RokVazenja as 'Rok važenja',RokPlacanja as 'Rok plaćanja',RokIzvrsenja as 'Rok izvršenja',CenaBezPDV as 'Cena bez PDV',CenaSaPDV as 'Cena sa PDV',IznosKapare as 'Iznos kapare',NacinPlacanja as 'Način plaćanja' FROM Ponude";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                Tabela2.ItemsSource = ds.DefaultView;
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

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if (Tabela2.Items.Count > 0)
            {
                if (Tabela2.SelectedItem != null)
                {
                    int index = Tabela2.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela2.Items[index];

                    ID.Text = item.Row[0].ToString();
                    ImePrezimeVlasnika.Text = item.Row[1].ToString();
                    NazivFirme.Text = item.Row[2].ToString();
                    AdresaFirme.Text = item.Row[3].ToString();
                    KontaktVlasnika.Text = item.Row[4].ToString();
                    BrojTekucegRacuna.Text = item.Row[5].ToString();
                    ImePrezimeKlijenta.Text = item.Row[6].ToString();
                    AdresaKlijenta.Text = item.Row[7].ToString();
                    DatumIzdavanja.Text = item.Row[8].ToString();
                    RokVazenja.Text = item.Row[9].ToString();
                    RokPlacanja.Text = item.Row[10].ToString();
                    RokIzvrsenja.Text = item.Row[11].ToString();
                    CenaBezPDV.Text = item.Row[12].ToString();
                    CenaSaPDV.Text = item.Row[13].ToString();
                    IznosKapare.Text = item.Row[14].ToString();
                    NacinPlacanja.Text = item.Row[15].ToString();
                    IzmenaPonuda izm = new IzmenaPonuda(this);
                    izm.Owner = Window.GetWindow(this);
                    izm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Morate selektovati ponudu!");
                }
            }
            else
            {
                MessageBox.Show("Tabela ponuda je prazna!");
            }
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (Tabela2.Items.Count > 0)
            {

                if (Tabela2.SelectedItem != null)
                {

                    int index = Tabela2.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela2.Items[index];
                    ID.Text = item.Row[0].ToString();
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                    string messageBoxText = "Da li ste sigurni da želite izbrisati selektovanu ponudu?";
                    string caption = "Confirm";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                    if (result == MessageBoxResult.Yes)
                    {

                        try
                        {


                            String query = "DELETE FROM Ponude WHERE ID = " + ID.Text + "";
                            SQLiteCommand command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();

                            String query2 = "SELECT ID,ImePrezimeVlasnika as 'Ime i prezime vlasnika',NazivFirme as 'Naziv firme',AdresaFirme as 'Adresa firme',KontaktVlasnika as 'Kontakt Vlasnika',BrojTekucegRacuna as 'Broj tekućeg računa',ImePrezimeKlijenta as 'Ime i prezime klijenta',AdresaKlijenta as 'Adresa klijenta',DatumIzdavanja as 'Datum izdavanja',RokVazenja as 'Rok važenja',RokPlacanja as 'Rok plaćanja',RokIzvrsenja as 'Rok izvršenja',CenaBezPDV as 'Cena bez PDV',CenaSaPDV as 'Cena sa PDV',IznosKapare as 'Iznos kapare',NacinPlacanja as 'Način plaćanja' FROM Ponude";
                            SQLiteDataAdapter command2 = new SQLiteDataAdapter(query2, connection);
                            DataTable ds = new DataTable();

                            command2.Fill(ds);
                            Tabela2.ItemsSource = ds.DefaultView;



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
                    MessageBox.Show("Morate selektovati ponudu!");
                }

            }
            else
            {
                MessageBox.Show("Tabela ponuda je prazna!");
            }
        }

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            if (Tabela2.Items.Count > 0)
            {
                if (Tabela2.SelectedItem != null)
                {
                    int index = Tabela2.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela2.Items[index];

                    ID.Text = item.Row[0].ToString();
                    ImePrezimeVlasnika.Text = item.Row[1].ToString();
                    NazivFirme.Text = item.Row[2].ToString();
                    AdresaFirme.Text = item.Row[3].ToString();
                    KontaktVlasnika.Text = item.Row[4].ToString();
                    BrojTekucegRacuna.Text = item.Row[5].ToString();
                    ImePrezimeKlijenta.Text = item.Row[6].ToString();
                    AdresaKlijenta.Text = item.Row[7].ToString();
                    DatumIzdavanja.Text = item.Row[8].ToString();
                    RokVazenja.Text = item.Row[9].ToString();
                    RokPlacanja.Text = item.Row[10].ToString();
                    RokIzvrsenja.Text = item.Row[11].ToString();
                    CenaBezPDV.Text = item.Row[12].ToString();
                    CenaSaPDV.Text = item.Row[13].ToString();
                    IznosKapare.Text = item.Row[14].ToString();
                    NacinPlacanja.Text = item.Row[15].ToString();
                    PonudeStampanje izm = new PonudeStampanje(this);
                    izm.Owner = Window.GetWindow(this);
                    izm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Morate selektovati ponudu!");
                }
            }
            else
            {
                MessageBox.Show("Tabela ponuda je prazna!");
            }
        }

        public void SearchData(string valueToFind)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT ID,ImePrezimeVlasnika as 'Ime i prezime vlasnika',NazivFirme as 'Naziv firme',AdresaFirme as 'Adresa firme',KontaktVlasnika as 'Kontakt Vlasnika',BrojTekucegRacuna as 'Broj tekućeg računa firme',ImePrezimeKlijenta as 'Ime i prezime klijenta',AdresaKlijenta as 'Adresa klijenta',DatumIzdavanja as 'Datum izdavanja',RokVazenja as 'Rok važenja',RokPlacanja as 'Rok plaćanja',RokIzvrsenja as 'Rok izvršenja',CenaBezPDV as 'Cena bez PDV',CenaSaPDV as 'Cena sa PDV',IznosKapare as 'Iznos kapare',NacinPlacanja as 'Način plaćanja' FROM Ponude WHERE ImePrezimeKlijenta LIKE '%" + valueToFind + "%' OR AdresaKlijenta LIKE '%" + valueToFind + "%'" +
                    "OR DatumIzdavanja LIKE '%" + valueToFind + "%' OR ID LIKE '%" + valueToFind + "%'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Tabela2.ItemsSource = table.DefaultView;
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
                    String query = "SELECT ID,ImePrezimeVlasnika as 'Ime i prezime vlasnika',NazivFirme as 'Naziv firme',AdresaFirme as 'Adresa firme',KontaktVlasnika as 'Kontakt Vlasnika',BrojTekucegRacuna as 'Broj tekućeg računa',ImePrezimeKlijenta as 'Ime i prezime klijenta',AdresaKlijenta as 'Adresa klijenta',DatumIzdavanja as 'Datum izdavanja',RokVazenja as 'Rok važenja',RokPlacanja as 'Rok plaćanja',RokIzvrsenja as 'Rok izvršenja',CenaBezPDV as 'Cena bez PDV',CenaSaPDV as 'Cena sa PDV',IznosKapare as 'Iznos kapare',NacinPlacanja as 'Način plaćanja' FROM Ponude";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                    DataTable ds = new DataTable();

                    command.Fill(ds);
                    Tabela2.ItemsSource = ds.DefaultView;
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
    }
}
