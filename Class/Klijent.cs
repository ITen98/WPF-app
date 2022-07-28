using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class Klijent
    {
        private string imeKlijenta;
        private string prezimeKlijenta;
        private string adresaKlijenta;
        private string kontaktKlijenta;
        private string pib;
        private string jmbg;


        public string ImeKlijenta { get => imeKlijenta; set => imeKlijenta = value; }
        public string PrezimeKlijenta { get => prezimeKlijenta; set => prezimeKlijenta = value; }
        public string AdresaKlijenta { get => adresaKlijenta; set => adresaKlijenta = value; }
        public string KontaktKlijenta { get => kontaktKlijenta; set => kontaktKlijenta = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Pib { get => pib; set => pib = value; }

        public Klijent()
        {

        }

        public Klijent(string imeKlijenta, string prezimeKlijenta, string adresaKlijenta, string kontaktKlijenta, string pib, string jmbg)
        {
            ImeKlijenta = imeKlijenta;
            PrezimeKlijenta = prezimeKlijenta;
            AdresaKlijenta = adresaKlijenta;
            KontaktKlijenta = kontaktKlijenta;
            Pib = pib;
            Jmbg = jmbg;

        }


    }
}
