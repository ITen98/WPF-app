using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class Otpremnica
    {
        private string redniBrojRobe;
        private string datumIzdavanja;
        private string nazivIzdavaoca;
        private string adresaIzdavaoca;
        private string pibIzdavaoca;
        private string imePrezimePrimaoca;
        private string adresaPrimaoca;
        private string pibPrimaoca;


        public string RedniBrojRobe { get => redniBrojRobe; set => redniBrojRobe = value; }
        public string DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
        public string NazivIzdavaoca { get => nazivIzdavaoca; set => nazivIzdavaoca = value; }
        public string AdresaIzdavaoca { get => adresaIzdavaoca; set => adresaIzdavaoca = value; }
        public string PibIzdavaoca { get => pibIzdavaoca; set => pibIzdavaoca = value; }
        public string ImePrezimePrimaoca { get => imePrezimePrimaoca; set => imePrezimePrimaoca = value; }
        public string AdresaPrimaoca { get => adresaPrimaoca; set => adresaPrimaoca = value; }
        public string PibPrimaoca { get => pibPrimaoca; set => pibPrimaoca = value; }


        public Otpremnica()
        {

        }

        public Otpremnica(string redniBrojRobe, string datumIzdavanja, string nazivIzdavaoca, string adresaIzdavaoca, string pibIzdavaoca, string imePrezimePrimaoca, string adresaPrimaoca, string pibPrimaoca)
        {
            RedniBrojRobe = redniBrojRobe;
            DatumIzdavanja = datumIzdavanja;
            NazivIzdavaoca = nazivIzdavaoca;
            AdresaIzdavaoca = adresaIzdavaoca;
            PibIzdavaoca = pibIzdavaoca;
            ImePrezimePrimaoca = imePrezimePrimaoca;
            AdresaPrimaoca = adresaPrimaoca;
            PibPrimaoca = pibPrimaoca;

        }
    }
}
