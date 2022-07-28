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
using System.Windows.Shapes;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for StampanjeOtpremnice.xaml
    /// </summary>
    public partial class StampanjeOtpremnice : Window
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");
        TabelaO tbl;

        public StampanjeOtpremnice(TabelaO tabela)
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
        private void Stampaj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Stampaj.Background = MouseEnter2();
        }
        private void Stampaj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Stampaj.Background = MouseLeave2();

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            RedniBrojRobe.Text = tbl.RedniBrojRobe.Text;
            DatumIzdavanja.Text = tbl.DatumIzdavanja.Text;
            NazivIzdavaoca.Text = tbl.NazivIzdavaoca.Text;
            AdresaIzdavaoca.Text = tbl.AdresaIzdavaoca.Text;
            PIBIzdavaoca.Text = tbl.PIBIzdavaoca.Text;
            ImePrezimePrimaoca.Text = tbl.ImePrezimePrimaoca.Text;
            AdresaPrimaoca.Text = tbl.AdresaPrimaoca.Text;
            PIBPrimaoca.Text = tbl.PIBPrimaoca.Text;

            try
            {
                connection.Open();
                String query = "Select VrstaRobe as 'Vrsta robe',KolicinaRobe as 'Količina robe',JedinicaMereRobe as 'Jedinica mere robe',CenaRobe as 'Cena robe' From TabelaOtpremnica Where RedniBrojRobe='" + RedniBrojRobe.Text + "';";
                SQLiteDataAdapter command = new SQLiteDataAdapter(query, connection);
                DataTable ds = new DataTable();

                command.Fill(ds);
                TabelaOtpremnica.ItemsSource = ds.DefaultView;
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

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {

                    printDialog.PrintVisual(Grid1, "StampanjeOtpremnice");
                }

            }

            finally
            {
                this.IsEnabled = true;
            }
            Povratak_Click(sender, e);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Povratak_Click(sender, e);
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\PilanaHelp.chm");
            }
        }


        private void Povratak_MouseEnter(object sender, RoutedEventArgs e)
        {
            Povratak.Background = MouseEnter2();
        }
        private void Povratak_MouseLeave(object sender, RoutedEventArgs e)
        {
            Povratak.Background = MouseLeave2();

        }

        private void Povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
