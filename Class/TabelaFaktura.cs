using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class TabelaFaktura
    {
        private string redniBrojRacuna;
        private string vrstaDobaraUsluge;
        private string kolicinaRobe;
        private string visinaAvansa;
        private string iznosOsnovice;
        private string iznosPDV;
        private string ukupno;


        public string RedniBrojRacuna { get => redniBrojRacuna; set => redniBrojRacuna = value; }
        public string VrstaDobaraUsluge { get => vrstaDobaraUsluge; set => vrstaDobaraUsluge = value; }
        public string KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public string VisinaAvansa { get => visinaAvansa; set => visinaAvansa = value; }
        public string IznosOsnovice { get => iznosOsnovice; set => iznosOsnovice = value; }
        public string IznosPDV { get => iznosPDV; set => iznosPDV = value; }
        public string Ukupno { get => ukupno; set => ukupno = value; }

        public TabelaFaktura()
        {

        }

        public TabelaFaktura(string redniBrojRacuna, string vrstaDobaraUsluge, string kolicinaRobe, string visinaAvansa, string iznosOsnovice, string iznosPDV, string ukupno)
        {
            RedniBrojRacuna = redniBrojRacuna;
            VrstaDobaraUsluge = vrstaDobaraUsluge;
            KolicinaRobe = kolicinaRobe;
            VisinaAvansa = visinaAvansa;
            IznosOsnovice = iznosOsnovice;
            IznosPDV = iznosPDV;
            Ukupno = ukupno;

        }
    }
}
