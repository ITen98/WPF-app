using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class TabelaOtpremnica
    {
        private string redniBrojRobe;
        private string vrstaRobe;
        private string kolicinaRobe;
        private string jedinicaMereRobe;
        private string cenaRobe;


        public string RedniBrojRobe { get => redniBrojRobe; set => redniBrojRobe = value; }
        public string VrstaRobe { get => vrstaRobe; set => vrstaRobe = value; }
        public string KolicinaRobe { get => kolicinaRobe; set => kolicinaRobe = value; }
        public string JedinicaMereRobe { get => jedinicaMereRobe; set => jedinicaMereRobe = value; }
        public string CenaRobe { get => cenaRobe; set => cenaRobe = value; }

        public TabelaOtpremnica()
        {

        }

        public TabelaOtpremnica(string redniBrojRobe, string vrstaRobe, string kolicinaRobe, string jedinicaMereRobe, string cenaRobe)
        {
            RedniBrojRobe = redniBrojRobe;
            VrstaRobe = vrstaRobe;
            KolicinaRobe = kolicinaRobe;
            JedinicaMereRobe = jedinicaMereRobe;
            CenaRobe = cenaRobe;

        }
    }
}
