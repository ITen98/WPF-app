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
using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using Pilana123.Properties;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for TabelaK.xaml
    /// </summary>
    public partial class TabelaK : UserControl
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public TabelaK()
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

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (Tabela1.Items.Count > 0)
            {

                if (Tabela1.SelectedItem != null)
                {

                    int index = Tabela1.SelectedIndex;
                DataRowView item = (DataRowView)Tabela1.Items[index];
                ID.Text = item.Row[0].ToString();
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                    string messageBoxText = "Da li ste sigurni da želite izbrisati selektovanog klijenta?";
                    string caption = "Confirm";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                    if (result == MessageBoxResult.Yes)
                    {

                        try
                        {


                            String query = "DELETE FROM Klijenti WHERE ID = " + ID.Text + "";
                            SQLiteCommand command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();

                            String query2 = "SELECT ID,ImeKlijenta as 'Ime klijenta',PrezimeKlijenta as 'Prezime klijenta',AdresaKlijenta as 'Adresa klijenta',KontaktKlijenta as 'Kontakt klijenta',PIB as 'PIB klijenta',JMBG as 'JMBG klijenta' FROM Klijenti";
                            SQLiteDataAdapter command2 = new SQLiteDataAdapter(query2, connection);
                            DataTable ds = new DataTable();

                            command2.Fill(ds);
                            Tabela1.ItemsSource = ds.DefaultView;



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
                    MessageBox.Show("Morate selektovati klijenta!");
                }

            }
            else {
                MessageBox.Show("Tabela Klijenata je prazna!");
            }


        }

        private void UserControl_isVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT ID,ImeKlijenta as 'Ime klijenta',PrezimeKlijenta as 'Prezime klijenta',AdresaKlijenta as 'Adresa klijenta',KontaktKlijenta as 'Kontakt klijenta',PIB as 'PIB klijenta',JMBG as 'JMBG klijenta' FROM Klijenti";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                Tabela1.ItemsSource = ds.DefaultView;
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
            if (Tabela1.Items.Count > 0)
            {
                if (Tabela1.SelectedItem != null)
                {
                    int index = Tabela1.SelectedIndex;
                    DataRowView item = (DataRowView)Tabela1.Items[index];

                    ID.Text = item.Row[0].ToString();
                    ImeKlijenta.Text = item.Row[1].ToString();
                    PrezimeKlijenta.Text = item.Row[2].ToString();
                    AdresaKlijenta.Text = item.Row[3].ToString();
                    KontaktKlijenta.Text = item.Row[4].ToString();
                    PIB.Text = item.Row[5].ToString();
                    JMBG.Text = item.Row[6].ToString();
                    try
                    {
                        IzmenaKlijenta izmenaKlijenta = new IzmenaKlijenta(this);
                        izmenaKlijenta.Owner = Window.GetWindow(this);
                        izmenaKlijenta.ShowDialog();
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Morate selektovati klijenta!");
                }
                }else{
                MessageBox.Show("Tabela Klijenata je prazna!");
            }
            
        }

        public void SearchData(string valueToFind) {

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                String query = "SELECT ID,ImeKlijenta as 'Ime klijenta',PrezimeKlijenta as 'Prezime klijenta',AdresaKlijenta as 'Adresa klijenta',KontaktKlijenta as 'Kontakt klijenta',PIB as 'PIB klijenta',JMBG as 'JMBG klijenta' FROM Klijenti WHERE PrezimeKlijenta LIKE '%" + valueToFind + "%' OR ImeKlijenta LIKE '%" + valueToFind + "%' OR AdresaKlijenta LIKE '%" + valueToFind + "%' OR KontaktKlijenta LIKE '%" + valueToFind + "%' OR PIB LIKE '%" + valueToFind + "%' OR JMBG LIKE '%" + valueToFind + "%' OR ID LIKE '%" + valueToFind + "%' ";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Tabela1.ItemsSource = table.DefaultView;
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

                    String query = "SELECT ID,ImeKlijenta as 'Ime klijenta',PrezimeKlijenta as 'Prezime klijenta',AdresaKlijenta as 'Adresa klijenta',KontaktKlijenta as 'Kontakt klijenta',PIB as 'PIB klijenta',JMBG as 'JMBG klijenta' FROM Klijenti";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                    DataTable ds = new DataTable();

                    command.Fill(ds);
                    Tabela1.ItemsSource = ds.DefaultView;
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
            if (e.Key == Key.Delete)
            {
                Obrisi_Click(sender, e);
            }
        }
    }
}
