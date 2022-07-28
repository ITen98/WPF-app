using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using Pilana123.Class;

namespace Pilana123.Class
{
    class SqlDataHelper
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=Baza/dbPilana.db;Version = 3;");

        public SqlDataHelper()
        {

        }

        public bool DodavanjeKlijenta(Klijent klijent)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO Klijenti (ImeKlijenta,PrezimeKlijenta,AdresaKlijenta,KontaktKlijenta,PIB,JMBG) VALUES('" + klijent.ImeKlijenta + "','" + klijent.PrezimeKlijenta + "','" + klijent.AdresaKlijenta + "','" + klijent.KontaktKlijenta + "','" + klijent.Pib + "','" + klijent.Jmbg + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool KreiranjeFakture(Faktura faktura)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO Fakture VALUES('" + faktura.RedniBrojRacuna + "','" + faktura.NazivIzdavaoca + "','" + faktura.AdresaIzdavaoca + "','" + faktura.PibIzdavaoca + "','" + faktura.MestoIzdavanja + "','" + faktura.DatumIzdavanja + "','" + faktura.ImePrezimePrimaoca + "','" + faktura.AdresaPrimaoca + "','" + faktura.PibPrimaoca + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool KreiranjePonude(Ponuda ponuda)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO Ponude (ImePrezimeVlasnika,NazivFirme,AdresaFirme,KontaktVlasnika,BrojTekucegRacuna,ImePrezimeKlijenta,AdresaKlijenta,DatumIzdavanja,RokVazenja,RokPlacanja,RokIzvrsenja,CenaBezPDV,CenaSaPDV,IznosKapare,NacinPlacanja) VALUES('" + ponuda.ImePrezimeVlasnika + "','" + ponuda.NazivFirme + "','" + ponuda.AdresaFirme + "','" + ponuda.KontaktVlasnika + "','" + ponuda.BrojTekucegRacuna + "','" + ponuda.ImePrezimeKlijenta + "','" + ponuda.AdresaKlijenta + "','" + ponuda.DatumIzdavanja + "','" + ponuda.RokVazenja + "','" + ponuda.RokPlacanja + "','" + ponuda.RokIzvrsenja + "','" + ponuda.CenaBezPDV + "','" + ponuda.CenaSaPDV + "','" + ponuda.IznosKapare + "','" + ponuda.NacinPlacanja + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool KreiranjeOtpremnice(Otpremnica otpremnica)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO Otpremnice VALUES('" + otpremnica.RedniBrojRobe + "','" + otpremnica.DatumIzdavanja + "','" + otpremnica.NazivIzdavaoca + "','" + otpremnica.AdresaIzdavaoca + "','" + otpremnica.PibIzdavaoca + "','" + otpremnica.ImePrezimePrimaoca + "','" + otpremnica.AdresaPrimaoca + "','" + otpremnica.PibPrimaoca + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool KreiranjeTabeleOtpremnica(TabelaOtpremnica otpremnica)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO TabelaOtpremnica (RedniBrojRobe,VrstaRobe,KolicinaRobe,JedinicaMereRobe,CenaRobe) VALUES('" + otpremnica.RedniBrojRobe + "','"+ otpremnica.VrstaRobe + "','" + otpremnica.KolicinaRobe + "','" + otpremnica.JedinicaMereRobe + "','" + otpremnica.CenaRobe + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool KreiranjeTabeleFaktura(TabelaFaktura faktura)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO TabelaFaktura (RedniBrojRacuna,VrstaDobaraUsluge,KolicinaRobe,VisinaAvansa,IznosOsnovice,IznosPDV,Ukupno) VALUES('" + faktura.RedniBrojRacuna + "','" + faktura.VrstaDobaraUsluge + "','" + faktura.KolicinaRobe + "','" + faktura.VisinaAvansa + "','" + faktura.IznosOsnovice + "','" + faktura.IznosPDV + "','" + faktura.Ukupno + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool KreiranjeTabeleFaktura2(TabelaFaktura faktura)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO TabelaFaktura2 (RedniBrojRacuna,VrstaDobaraUsluge,KolicinaRobe,VisinaAvansa,IznosOsnovice,IznosPDV,Ukupno) VALUES('" + faktura.RedniBrojRacuna + "','" + faktura.VrstaDobaraUsluge + "','" + faktura.KolicinaRobe + "','" + faktura.VisinaAvansa + "','" + faktura.IznosOsnovice + "','" + faktura.IznosPDV + "','" + faktura.Ukupno + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool BrisanjeTabeleFaktura()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "DELETE FROM TabelaFaktura2";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public bool BrisanjeTabeleOtpremnica()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "DELETE FROM TabelaOtpremnica2";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool KreiranjeTabeleOtpremnica2(TabelaOtpremnica otpremnica)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {


                String query = "INSERT INTO TabelaOtpremnica2 (RedniBrojRobe,VrstaRobe,KolicinaRobe,JedinicaMereRobe,CenaRobe) VALUES('" + otpremnica.RedniBrojRobe + "','" + otpremnica.VrstaRobe + "','" + otpremnica.KolicinaRobe + "','" + otpremnica.JedinicaMereRobe + "','" + otpremnica.CenaRobe + "')";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        
    }
    
}
