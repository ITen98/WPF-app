using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GlavniMeni.xaml
    /// </summary>
    public partial class GlavniMeni : Window
    {
        public GlavniMeni()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow LogIn = new MainWindow();
            LogIn.Show();
            this.Close();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Verzija sofvera: v1.2" + "\n" + "Autor: Nemanja Janjatović", "About", MessageBoxButton.OK);
        }
        private void Help_Click(object sender, RoutedEventArgs e) {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\PilanaHelp.chm");
            
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
        private void Klijenti_MouseEnter(object sender, RoutedEventArgs e)
        {
            Klijenti.Background = MouseEnter2();
        }
        private void Klijenti_MouseLeave(object sender, RoutedEventArgs e)
        {
            Klijenti.Background = MouseLeave2();
        }
        private void DodavanjeKlijenata_MouseEnter(object sender, RoutedEventArgs e)
        {
            DodavanjeKlijenata.Background = MouseEnter2();
        }
        private void DodavanjeKlijenata_MouseLeave(object sender, RoutedEventArgs e)
        {
            DodavanjeKlijenata.Background = MouseLeave2();
        }
        private void TabelaKlijenata_MouseEnter(object sender, RoutedEventArgs e)
        {
            TabelaKlijenata.Background = MouseEnter2();
        }
        private void TabelaKlijenata_MouseLeave(object sender, RoutedEventArgs e)
        {
            TabelaKlijenata.Background = MouseLeave2();
        }
        private void TabelaPonuda_MouseEnter(object sender, RoutedEventArgs e)
        {
            TabelaPonuda.Background = MouseEnter2();
        }
        private void TabelaPonuda_MouseLeave(object sender, RoutedEventArgs e)
        {
            TabelaPonuda.Background = MouseLeave2();
        }
        private void TabelaFaktura_MouseEnter(object sender, RoutedEventArgs e)
        {
            TabelaFaktura.Background = MouseEnter2();
        }
        private void TabelaFaktura_MouseLeave(object sender, RoutedEventArgs e)
        {
            TabelaFaktura.Background = MouseLeave2();
        }
        private void TabelaOtpremnica_MouseEnter(object sender, RoutedEventArgs e)
        {
            TabelaOtpremnica.Background = MouseEnter2();
        }
        private void TabelaOtpremnica_MouseLeave(object sender, RoutedEventArgs e)
        {
            TabelaOtpremnica.Background = MouseLeave2();
        }
        private void KreiranjePonude_MouseEnter(object sender, RoutedEventArgs e)
        {
            KreiranjePonude.Background = MouseEnter2();
        }
        private void KreiranjePonude_MouseLeave(object sender, RoutedEventArgs e)
        {
            KreiranjePonude.Background = MouseLeave2();
        }
        private void KreiranjeFakture_MouseEnter(object sender, RoutedEventArgs e)
        {
            KreiranjeFakture.Background = MouseEnter2();
        }
        private void KreiranjeFakture_MouseLeave(object sender, RoutedEventArgs e)
        {
            KreiranjeFakture.Background = MouseLeave2();
        }
        private void KreiranjeOtpremnice_MouseEnter(object sender, RoutedEventArgs e)
        {
            KreiranjeOtpremnice.Background = MouseEnter2();
        }
        private void KreiranjeOtpremnice_MouseLeave(object sender, RoutedEventArgs e)
        {
            KreiranjeOtpremnice.Background = MouseLeave2();
        }
        private void Porudzbenice_MouseEnter(object sender, RoutedEventArgs e)
        {
            Porudzbenice.Background = MouseEnter2();
        }
        private void Porudzbenice_MouseLeave(object sender, RoutedEventArgs e)
        {
            Porudzbenice.Background = MouseLeave2();
        }
        private void Uizradi_MouseEnter(object sender, RoutedEventArgs e)
        {
            Uizradi.Background = MouseEnter2();
        }
        private void Uizradi_MouseLeave(object sender, RoutedEventArgs e)
        {
            Uizradi.Background = MouseLeave2();
        }
        private void Ponude_MouseEnter(object sender, RoutedEventArgs e)
        {
            Ponude.Background = MouseEnter2();
        }
        private void Ponude_MouseLeave(object sender, RoutedEventArgs e)
        {
            Ponude.Background = MouseLeave2();
        }
        private void Fakture_MouseEnter(object sender, RoutedEventArgs e)
        {
            Fakture.Background = MouseEnter2();
        }
        private void Fakture_MouseLeave(object sender, RoutedEventArgs e)
        {
            Fakture.Background = MouseLeave2();
        }
        private void Otpremnice_MouseEnter(object sender, RoutedEventArgs e)
        {
            Otpremnice.Background = MouseEnter2();
        }
        private void Otpremnice_MouseLeave(object sender, RoutedEventArgs e)
        {
            Otpremnice.Background = MouseLeave2();
        }
        private void Pomoc_MouseEnter(object sender, RoutedEventArgs e)
        {
            Pomoc.Background = MouseEnter2();
        }
        private void Pomoc_MouseLeave(object sender, RoutedEventArgs e)
        {
            Pomoc.Background = MouseLeave2();
        }
        private void About_MouseEnter(object sender, RoutedEventArgs e)
        {
            About.Background = MouseEnter2();
        }
        private void About_MouseLeave(object sender, RoutedEventArgs e)
        {
            About.Background = MouseLeave2();
        }
        private void Help_MouseEnter(object sender, RoutedEventArgs e)
        {
            Help.Background = MouseEnter2();
        }
        private void Help_MouseLeave(object sender, RoutedEventArgs e)
        {
            Help.Background = MouseLeave2();
        }
        private void Odjava_MouseEnter(object sender, RoutedEventArgs e)
        {
            Odjava.Background = MouseEnter2();
        }
        private void Odjava_MouseLeave(object sender, RoutedEventArgs e)
        {
            Odjava.Background = MouseLeave2();
        }

        private void DodavanjeKlijenata_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Visible;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Dodavanje klijenata";
            
        }
        private void TabelaKlijenata_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Visible;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Tabela klijenata";

        }
        private void KreiranjePonuda_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Visible;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Kreiranje ponude";
        }
        private void KreiranjeFaktura_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Visible;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Kreiranje fakture";
        }
        private void KreiranjeOtpremnica_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Visible;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Kreiranje otpremnice";
        }
        private void TabelaPonuda_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Visible;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Tabela ponuda";
        }
        private void TabelaFaktura_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Visible;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Tabela faktura";
        }
        private void TabelaOtpremnica_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Visible;
            this.Title = "Tabela otpremnica";
        }
        private void Uizradi_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeK.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Visible;
            TabelaK.Visibility = Visibility.Hidden;
            KreiranjeP.Visibility = Visibility.Hidden;
            TabelaP.Visibility = Visibility.Hidden;
            KreiranjeF.Visibility = Visibility.Hidden;
            TabelaF.Visibility = Visibility.Hidden;
            KreiranjeO.Visibility = Visibility.Hidden;
            TabelaO.Visibility = Visibility.Hidden;
            this.Title = "Početna";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Help_Click(sender, e);
            }
        }

 

        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            Home.Background = MouseEnter2();
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            Home.Background = MouseLeave2();
        }

    }
}
