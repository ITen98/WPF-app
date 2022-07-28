using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class Faktura
    {
        private string redniBrojRacuna;
        private string nazivIzdavaoca;
        private string adresaIzdavaoca;
        private string pibIzdavaoca;
        private string mestoIzdavanja;
        private string datumIzdavanja;
        private string imePrezimePrimaoca;
        private string adresaPrimaoca;
        private string pibPrimaoca;


        public string RedniBrojRacuna { get => redniBrojRacuna; set => redniBrojRacuna = value; }
        public string NazivIzdavaoca { get => nazivIzdavaoca; set => nazivIzdavaoca = value; }
        public string AdresaIzdavaoca { get => adresaIzdavaoca; set => adresaIzdavaoca = value; }
        public string PibIzdavaoca { get => pibIzdavaoca; set => pibIzdavaoca = value; }
        public string MestoIzdavanja { get => mestoIzdavanja; set => mestoIzdavanja = value; }
        public string DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
        public string ImePrezimePrimaoca { get => imePrezimePrimaoca; set => imePrezimePrimaoca = value; }
        public string AdresaPrimaoca { get => adresaPrimaoca; set => adresaPrimaoca = value; }
        public string PibPrimaoca { get => pibPrimaoca; set => pibPrimaoca = value; }


        public Faktura()
        {

        }

        public Faktura(string redniBrojRacuna, string nazivIzdavaoca, string adresaIzdavaoca, string pibIzdavaoca, string mestoIzdavanja, string datumIzdavanja, string imePrezimePrimaoca, string adresaPrimaoca, string pibPrimaoca)
        {
            RedniBrojRacuna = redniBrojRacuna;
            NazivIzdavaoca = nazivIzdavaoca;
            AdresaIzdavaoca = adresaIzdavaoca;
            PibIzdavaoca = pibIzdavaoca;
            MestoIzdavanja = mestoIzdavanja;
            DatumIzdavanja = datumIzdavanja;
            ImePrezimePrimaoca = imePrezimePrimaoca;
            AdresaPrimaoca = adresaPrimaoca;
            PibPrimaoca = pibPrimaoca;

        }
    }
}
