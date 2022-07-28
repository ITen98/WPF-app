using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SQLite;

namespace Pilana123
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
        private void Izlaz_MouseEnter(object sender, RoutedEventArgs e)
        {
            Izlaz.Background = MouseEnter2();
        }
        private void Izlaz_MouseLeave(object sender, RoutedEventArgs e)
        {
            Izlaz.Background = MouseLeave2();
        }

        private void Uloguj_MouseEnter(object sender, RoutedEventArgs e)
        {
            Uloguj.Background = MouseEnter2();
        }
        private void Uloguj_MouseLeave(object sender, RoutedEventArgs e)
        {
            Uloguj.Background = MouseLeave2();

        }
        private int TestFields()
        {
            int greske = 0;
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {

                String query = "SELECT COUNT(1) FROM Login WHERE username=@username and password=@password";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@username", UserName.Text);
                command.Parameters.AddWithValue("@password", Password.Password);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count <= 0)
                {
                    String query2 = "SELECT COUNT(1) FROM Login WHERE username=@username";
                    SQLiteCommand command2 = new SQLiteCommand(query2, connection);

                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@username", UserName.Text);
                    int count2 = Convert.ToInt32(command2.ExecuteScalar());
                    if(count2 <= 0)
                    {
                        UserName.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    }
                    else
                    {
                        UserName.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                    }
                    String query3 = "SELECT COUNT(1) FROM Login WHERE password=@password";
                    SQLiteCommand command3 = new SQLiteCommand(query3, connection);

                    command3.CommandType = CommandType.Text;
                    command3.Parameters.AddWithValue("@password", Password.Password);
                    int count3 = Convert.ToInt32(command3.ExecuteScalar());
                    if (count3 <= 0)
                    {
                        Password.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                        Password2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff8f8f");
                    }
                    else
                    {
                        Password.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                        Password2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                    }


                    greske += 1;
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
            return greske;
        }

        private void Uloguj_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked == true)
            {
                Password.Password = Password2.Text;
            }
            else {
                Password2.Text = Password.Password;
            }
            if (TestFields() == 0)
            {
                    GlavniMeni glavniMeni = new GlavniMeni();
                    glavniMeni.Show();
                    this.Close();
                
            }
            
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Izlaz_Click(sender, e);
            }
        }
        private void Window_PreviewKeyDown2(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {

                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\PilanaHelp.chm");

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked == true)
            {
                Password2.Text = Password.Password;
                Password2.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Hidden;
                CheckBox.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                CheckBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
            }
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked == false)
            {
                Password.Password = Password2.Text;
                Password2.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Visible;
                CheckBox.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                CheckBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
        }
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {          
                Password2.Text = Password.Password;               
        }
        private void Password2_TextChanged(object sender, RoutedEventArgs e)
        {
            Password.Password=Password2.Text;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void PackIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            Minimized.Background = MouseEnter2();
        }

        private void Minimized_MouseLeave(object sender, MouseEventArgs e)
        {
            Minimized.Background = MouseLeave2();
        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            KorIme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            Lozinka.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            Lozinka.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            KorIme.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
        }
    }
}
