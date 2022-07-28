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
using System.Data.Sql;
using System.Data.SQLite;
using System.Globalization;
using System.Data.SqlClient;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for KreiranjeP.xaml
    /// </summary>
    public partial class KreiranjeP : UserControl
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");
        SqlDataHelper sql = new SqlDataHelper();

        public KreiranjeP()
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
            ImePrezimeV.Text = "";
            NazivFirme.Text = "";
            AdresaFirme.Text = "";
            KontaktVlasnika.Text = "";
            BrojTekućegRacuna.Text = "";
            ImePrezimeKlijenta.Text = "";
            AdresaKlijenta.Text = "";
            DatumIzdavanja.SelectedDate = null;
            RokVazenjaPonude.SelectedDate = null;
            RokPlacanja.SelectedDate = null;
            RokIzvrsenja.SelectedDate = null;
            CenaBezPDV.Text = "";
            CenaSaPDV.Text = "";
            IznosKapare.Text = "";
            NacinPlacanja.Text = "";
            NacinPlacanja.SelectedItem = null;

        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
                if(TestFields()==0){
                    Ponuda ponuda = new Ponuda(ImePrezimeV.Text,NazivFirme.Text,AdresaFirme.Text,KontaktVlasnika.Text,BrojTekućegRacuna.Text,ImePrezimeKlijenta.Text,AdresaKlijenta.Text,DatumIzdavanja.Text,RokVazenjaPonude.Text,RokPlacanja.Text,RokIzvrsenja.Text,CenaBezPDV.Text,CenaSaPDV.Text,IznosKapare.Text,NacinPlacanja.Text );
                    

                    if (sql.KreiranjePonude(ponuda))
                    {
                        ResetFields();
                    }
                    else
                    {
                        MessageBox.Show("Greska pri dodavanju");
                    
                    }
                }
            
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ResetFields();
            ImePrezimeV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KontaktVlasnika.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KontaktVlasnika.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokVazenjaPonude.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokVazenjaPonude.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokIzvrsenja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokIzvrsenja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaBezPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaBezPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaSaPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaSaPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosKapare.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosKapare.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NacinPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NacinPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            ImePrezimeKlijenta.Items.Clear();
            AdresaKlijenta.Items.Clear();
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
                    if (!ImePrezimeKlijenta.Items.Contains(ds.Rows[i][0] + " " + ds.Rows[i][1]))
                    {
                        ImePrezimeKlijenta.Items.Add(ds.Rows[i][0] + " " + ds.Rows[i][1]);
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

        private void ImePrezimeV_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuotes && FindAllChar2("'", ImePrezimeV.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', ImePrezimeV.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", ImePrezimeV.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', ImePrezimeV.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', ImePrezimeV.Text) <= 0 ||
             e.Key == Key.Space && FindAllChar(' ', ImePrezimeV.Text) < 3 || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void AdresaFirme_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Space && FindAllChar(' ', AdresaFirme.Text) < 4 || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.OemQuestion && FindAllChar('/', AdresaFirme.Text) <= 0 || e.Key == Key.Divide && FindAllChar('/', AdresaFirme.Text) <= 0 || e.Key == Key.OemComma && FindAllChar(',', AdresaFirme.Text) <= 0
                || e.Key == Key.Left || e.Key == Key.Right || key >= 34 && key <= 43 || e.Key == Key.OemQuotes && FindAllChar2("'", AdresaFirme.Text) <= 0 || e.Key == Key.OemSemicolon && FindAllChar(';', AdresaFirme.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", AdresaFirme.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', AdresaFirme.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', AdresaFirme.Text) <= 0 ||
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

        private void KontaktVlasnika_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            if (KontaktVlasnika.Text.Length - FindAllChar('+', KontaktVlasnika.Text) <= 13 ||
                      e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = !(key >= 34 && key <= 43 ||
                            key >= 74 && key <= 83 ||
                            e.Key == Key.OemPlus && FindAllChar('+', KontaktVlasnika.Text) < 1 ||
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

        private void AdresaKlijenta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void BrojTekućegRacuna_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            if (BrojTekućegRacuna.Text.Length - FindAllChar('-', BrojTekućegRacuna.Text) < 18 ||
                      e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = !(key >= 34 && key <= 43 ||
                            key >= 74 && key <= 83 ||
                            e.Key == Key.Subtract && FindAllChar('-', BrojTekućegRacuna.Text) < 2 ||
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

        
        private bool TestRacun()
        {
            try
            {
                //Prve 3 cifre su obavezne, a ostalo moze da se automatski popuni sa nulama
                string temp = BrojTekućegRacuna.Text;
                int t;
                //c dobija broj crtica
                int c = FindAllChar('-', temp);
                if (c > 0)
                {
                    for (uint i = 0; i < c; i++)
                    {
                        //
                        t = temp.IndexOf('-');
                        temp = temp.Remove(t, 1);
                    }
                }
                //Gledamo razliku izmedju naseg stringa i ocekivanog stringa sa 18 karaktera
                int a = 18 - temp.Length;
                if (temp.Length > 2)
                {
                    //Sve sto nedostaje zamenjuje se sa nulama
                    for (uint i = 0; i < a; i++)
                    {
                        temp = temp.Insert(temp.Length, "0");
                    }
                    //Na kraju se na poziciji 3 i 17 stavljaju crtice
                    temp = temp.Insert(3, "-");
                    temp = temp.Insert(17, "-");
                }
                else
                {
                    return false;
                }
                //Zamenjujemo temp u racunTextBox ukoliko je nepravilno unesen racun, u suprotnom vracamo isti string
                BrojTekućegRacuna.Text = temp;
                return true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        private void CenaBezPDV_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',', CenaBezPDV.Text) <= 0 ||
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
        private int TestFields()
        {

            int neuspesno = 0;
            if (string.IsNullOrWhiteSpace(ImePrezimeV.Text))
            {
                ImePrezimeV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezimeV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                ImePrezimeV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                ImePrezimeV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(NazivFirme.Text))
            {
                NazivFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                NazivFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                NazivFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                NazivFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(AdresaFirme.Text))
            {
                AdresaFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                AdresaFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                AdresaFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(KontaktVlasnika.Text) || KontaktVlasnika.Text.Length < 12 || KontaktVlasnika.Text.Length > 15)
            {
                KontaktVlasnika.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                KontaktVlasnika.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                KontaktVlasnika.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                KontaktVlasnika.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black"); ;
            }
            if (string.IsNullOrWhiteSpace(BrojTekućegRacuna.Text) || TestRacun() == false)
            {
                BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (TestRacun() == false)
            {
                BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(ImePrezimeKlijenta.Text))
            {
                ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(CenaSaPDV.Text) || (decimal.Parse(CenaSaPDV.Text) <= 0))
            {
                CenaSaPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                CenaSaPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                CenaSaPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaSaPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaSaPDV.Text = string.Format("{0:#,##0.00}", double.Parse(CenaSaPDV.Text));
            }
            if (string.IsNullOrWhiteSpace(CenaBezPDV.Text) || (decimal.Parse(CenaBezPDV.Text) <= 0))
            {
                CenaBezPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                CenaBezPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                CenaBezPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaBezPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CenaBezPDV.Text = string.Format("{0:#,##0.00}", double.Parse(CenaBezPDV.Text));
            }
            if (string.IsNullOrWhiteSpace(IznosKapare.Text) || (decimal.Parse(IznosKapare.Text) <= 0))
            {
                IznosKapare.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                IznosKapare.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                IznosKapare.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                IznosKapare.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                IznosKapare.Text = string.Format("{0:#,##0.00}", double.Parse(IznosKapare.Text));
            }
            if (string.IsNullOrWhiteSpace(NacinPlacanja.Text))
            {
                NacinPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                NacinPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                NacinPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                NacinPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
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
            if (string.IsNullOrWhiteSpace(RokVazenjaPonude.Text))
            {
                RokVazenjaPonude.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RokVazenjaPonude.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RokVazenjaPonude.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RokVazenjaPonude.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(RokPlacanja.Text))
            {
                RokPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RokPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RokPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RokPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(RokIzvrsenja.Text))
            {
                RokIzvrsenja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                RokIzvrsenja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                RokIzvrsenja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                RokIzvrsenja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            if (string.IsNullOrWhiteSpace(AdresaKlijenta.Text))
            {
                AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                neuspesno += 1;
            }
            else
            {
                AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {
                if (!string.IsNullOrWhiteSpace(AdresaKlijenta.Text)) { 
                string[] parts = ImePrezimeKlijenta.Text.Split(' ');
                String query = "SELECT COUNT(1) FROM Klijenti WHERE AdresaKlijenta=@AdresaKlijenta and ImeKlijenta=@ImeKlijenta and PrezimeKlijenta=@PrezimeKlijenta";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                string imeklijenta = parts[0];
                string prezimeklijenta = parts[1];

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@AdresaKlijenta", AdresaKlijenta.Text);
                command.Parameters.AddWithValue("@ImeKlijenta", imeklijenta);
                command.Parameters.AddWithValue("@PrezimeKlijenta", prezimeklijenta);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count <= 0)
                {
                    AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    MessageBox.Show("Adresa se ne poklapa sa imenom i prezimenom klijenta!", "GREŠKA");
                    neuspesno += 1;
                }
            }

            }
            catch
            {
                AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
            }
            finally
            {
                connection.Close();
            }

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
                {

                if (!string.IsNullOrWhiteSpace(ImePrezimeKlijenta.Text))
                {
                    string[] parts2 = ImePrezimeKlijenta.Text.Split(' ');
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
                        ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        MessageBox.Show("Klijent sa unetim imenom i prezimenom ne postoji!", "GREŠKA");
                        neuspesno += 1;
                    }

                }    
                }
                catch
                {
                    MessageBox.Show("Greška prilikom unosa imena i prezimena klijenta!");
                    ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                }
            finally
            {
                connection.Close();
            }


            return neuspesno;
        }


        private void IznosKapare_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                              key >= 74 && key <= 83 || e.Key == Key.OemComma && FindAllChar(',',IznosKapare.Text)<1 ||
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

        private void DatumIzdavanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void RokVazenjaPonude_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void RokPlacanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void RokIzvrsenja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }


        private void ImePrezimeKlijenta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void KontaktVlasnika_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KontaktVlasnika.Text))
            {
                KontaktVlasnika.Text = string.Format("+381 ", KontaktVlasnika.Text);
            }
        }

        private void KontaktVlasnika_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KontaktVlasnika.Text) || KontaktVlasnika.Text.Length < 5 || !KontaktVlasnika.Text.StartsWith("+381 "))
            {
                KontaktVlasnika.Text = string.Format("+381 ", KontaktVlasnika.Text);
            }
        }

        private void ImePrezimeV_LostFocus(object sender, RoutedEventArgs e)
        {
            ImePrezimeV.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(ImePrezimeV.Text);
            ImePrezimeV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void NazivFirme_LostFocus(object sender, RoutedEventArgs e)
        {
            NazivFirme.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(NazivFirme.Text);
            NazivFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NazivFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void AdresaFirme_LostFocus(object sender, RoutedEventArgs e)
        {
            AdresaFirme.Text = new CultureInfo("en-US").TextInfo.ToTitleCase(AdresaFirme.Text);
            AdresaFirme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaFirme.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }


        private void CenaBezPDV_LostFocus(object sender, RoutedEventArgs e)
        {
            CenaBezPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaBezPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            if (!string.IsNullOrWhiteSpace(CenaBezPDV.Text))
            {
                double iznos = 0.06;
                double cena = Convert.ToDouble(CenaBezPDV.Text);
                double cenaSaPdv = cena + cena * iznos;
                CenaSaPDV.Text = cenaSaPdv.ToString();
                CenaSaPDV.Text = string.Format("{0:#,##0.00}", double.Parse(CenaSaPDV.Text));
                CenaBezPDV.Text = string.Format("{0:#,##0.00}", double.Parse(CenaBezPDV.Text));
            }
            else
            {
                CenaSaPDV.Text = "";
            }
        }

        private void CenaSaPDV_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void ImePrezimeKlijenta_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ImePrezimeKlijenta.Text))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                try
                {
                    AdresaKlijenta.Items.Clear();
                    string[] parts2 = ImePrezimeKlijenta.Text.Split(' ');
                    string imeklijenta2 = parts2[0];
                    string prezimeklijenta2 = parts2[1];
                    String query2 = "Select AdresaKlijenta from Klijenti where ImeKlijenta='" + imeklijenta2 + "' and PrezimeKlijenta='" + prezimeklijenta2 + "'";
                    SQLiteDataAdapter command = new SQLiteDataAdapter(query2, connection);
                    DataTable ds = new DataTable();
                    command.Fill(ds);
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        if (!AdresaKlijenta.Items.Contains(ds.Rows[i][0]))
                        {
                            AdresaKlijenta.Items.Add(ds.Rows[i][0]);
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

        private void NacinPlacanja_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right);
        }

        private void NacinPlacanja_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NacinPlacanja.Text))
            {
                labelaplacanje.Visibility = Visibility.Hidden;
            }
            else
            {
                labelaplacanje.Visibility = Visibility.Visible;
            }
        }

        private void AdresaKlijenta_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdresaKlijenta.Text))
            {
                labelaadresa.Visibility = Visibility.Hidden;
            }
            else
            {
                labelaadresa.Visibility = Visibility.Visible;
            }
        }

        private void ImePrezimeKlijenta_LayoutUpdated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImePrezimeKlijenta.Text))
            {
                labelaime.Visibility = Visibility.Hidden;
            }
            else
            {
                labelaime.Visibility = Visibility.Visible;
            }
        }

        private void NazivFirme_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char key = (char)e.Key;
            e.Handled = !(e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Tab || e.Key == Key.Back ||
             e.Key == Key.Space && FindAllChar(' ', NazivFirme.Text) < 3 || e.Key == Key.OemPeriod && FindAllChar('.', NazivFirme.Text) < 3 || e.Key == Key.OemQuotes && FindAllChar2("'", NazivFirme.Text) <= 2 || e.Key == Key.OemSemicolon && FindAllChar(';', NazivFirme.Text) <= 0 || e.Key == Key.OemPipe && FindAllChar2("\\", NazivFirme.Text) <= 0 || e.Key == Key.OemOpenBrackets && FindAllChar('[', NazivFirme.Text) <= 0 || e.Key == Key.OemCloseBrackets && FindAllChar(']', NazivFirme.Text) <= 0
             || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Subtract && FindAllChar('-', NazivFirme.Text) < 2 || key >= 34 && key <= 43 || key >= 74 && key <= 83);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                int keyNumber = (int)e.Key;

                if (keyNumber >= 34 || keyNumber <= 43)
                {
                    e.Handled = true;
                }
            }
        }

        private void BrojTekućegRacuna_LostFocus(object sender, RoutedEventArgs e)
        {
            TestRacun();
            BrojTekućegRacuna.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            BrojTekućegRacuna.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void IznosKapare_LostFocus(object sender, RoutedEventArgs e)
        {
            IznosKapare.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            IznosKapare.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            if (!string.IsNullOrWhiteSpace(CenaBezPDV.Text))
            {
                IznosKapare.Text = string.Format("{0:#,##0.00}", double.Parse(IznosKapare.Text));
            }
        }

        private void NacinPlacanja_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaplacanje.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void NacinPlacanja_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaplacanje.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NacinPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            NacinPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void ImePrezimeKlijenta_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void ImePrezimeKlijenta_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            ImePrezimeKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void AdresaKlijenta_GotFocus(object sender, RoutedEventArgs e)
        {
            labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
            AdresaKlijenta.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            AdresaKlijenta.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void AdresaKlijenta_LostFocus(object sender, RoutedEventArgs e)
        {
            labelaadresa.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void DatumIzdavanja_LostFocus(object sender, RoutedEventArgs e)
        {
            DatumIzdavanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            DatumIzdavanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void KontaktVlasnika_LostFocus(object sender, RoutedEventArgs e)
        {
            KontaktVlasnika.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            KontaktVlasnika.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void RokPlacanja_LostFocus(object sender, RoutedEventArgs e)
        {
            RokPlacanja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokPlacanja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void RokIzvrsenja_LostFocus(object sender, RoutedEventArgs e)
        {
            RokIzvrsenja.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokIzvrsenja.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void RokVazenjaPonude_LostFocus(object sender, RoutedEventArgs e)
        {
            RokVazenjaPonude.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            RokVazenjaPonude.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void CenaSaPDV_LostFocus(object sender, RoutedEventArgs e)
        {
            CenaSaPDV.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            CenaSaPDV.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }
    }
}
