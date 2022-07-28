using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
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

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for PonudeStampanje.xaml
    /// </summary>
    public partial class PonudeStampanje : Window
    {
        TabelaP tbl;
        public PonudeStampanje(TabelaP tabela)
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
            ImePrezimeV.Text = tbl.ImePrezimeVlasnika.Text;
            NazivFirme.Text = tbl.NazivFirme.Text;
            KontaktVlasnika.Text = tbl.KontaktVlasnika.Text;
            BrojTekućegRacuna.Text = tbl.BrojTekucegRacuna.Text;
            ImePrezimeKlijenta.Text = tbl.ImePrezimeKlijenta.Text;
            AdresaKlijenta.Text = tbl.AdresaKlijenta.Text;
            AdresaFirme.Text = tbl.AdresaFirme.Text;
            DatumIzdavanja.Text = tbl.DatumIzdavanja.Text;
            RokVazenjaPonude.Text = tbl.RokVazenja.Text;
            RokPlacanja.Text = tbl.RokPlacanja.Text;
            RokIzvrsenja.Text = tbl.RokIzvrsenja.Text;
            CenaBezPDV.Text = tbl.CenaBezPDV.Text;
            CenaSaPDV.Text = tbl.CenaSaPDV.Text;
            IznosKapare.Text = tbl.IznosKapare.Text;
            NacinPlacanja.Text = tbl.NacinPlacanja.Text;
        }

        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            try {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true) {

                    printDialog.PrintVisual(Grid1, "StampanjePonude");
                }
                
            } 
            
            finally {
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
