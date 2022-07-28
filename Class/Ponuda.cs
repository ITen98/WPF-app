using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilana123.Class
{
    class Ponuda
    {
        private string imePrezimeVlasnika;
        private string nazivFirme;
        private string adresaFirme;
        private string kontaktVlasnika;
        private string brojTekucegRacuna;
        private string imePrezimeKlijenta;
        private string adresaKlijenta;
        private string datumIzdavanja;
        private string rokVazenja;
        private string rokPlacanja;
        private string rokIzvrsenja;
        private string cenaBezPDV;
        private string cenaSaPDV;
        private string iznosKapare;
        private string nacinPlacanja;


        public string ImePrezimeVlasnika { get => imePrezimeVlasnika; set => imePrezimeVlasnika = value; }
        public string NazivFirme { get => nazivFirme; set => nazivFirme = value; }
        public string AdresaFirme { get => adresaFirme; set => adresaFirme = value; }
        public string KontaktVlasnika { get => kontaktVlasnika; set => kontaktVlasnika = value; }
        public string BrojTekucegRacuna { get => brojTekucegRacuna; set => brojTekucegRacuna = value; }
        public string ImePrezimeKlijenta { get => imePrezimeKlijenta; set => imePrezimeKlijenta = value; }
        public string AdresaKlijenta { get => adresaKlijenta; set => adresaKlijenta = value; }
        public string DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
        public string RokVazenja { get => rokVazenja; set => rokVazenja = value; }
        public string RokPlacanja { get => rokPlacanja; set => rokPlacanja = value; }
        public string RokIzvrsenja { get => rokIzvrsenja; set => rokIzvrsenja = value; }
        public string CenaBezPDV { get => cenaBezPDV; set => cenaBezPDV = value; }
        public string CenaSaPDV { get => cenaSaPDV; set => cenaSaPDV = value; }
        public string IznosKapare { get => iznosKapare; set => iznosKapare = value; }
        public string NacinPlacanja { get => nacinPlacanja; set => nacinPlacanja = value; }


        public Ponuda()
        {

        }
        

        public Ponuda(string imePrezimeVlasnika, string nazivFirme, string adresaFirme, string kontaktVlasnika, string brojTekucegRacuna, string imePrezimeKlijenta, string adresaKlijenta, string datumIzdavanja, string rokVazenja, string rokPlacanja, string rokIzvrsenja, string cenaBezPDV, string cenaSaPDV, string iznosKapare, string nacinPlacanja)
        {
            ImePrezimeVlasnika = imePrezimeVlasnika;
            NazivFirme = nazivFirme;
            AdresaFirme = adresaFirme;
            KontaktVlasnika = kontaktVlasnika;
            BrojTekucegRacuna = brojTekucegRacuna;
            ImePrezimeKlijenta = imePrezimeKlijenta;
            AdresaKlijenta = adresaKlijenta;
            DatumIzdavanja = datumIzdavanja;
            RokVazenja = rokVazenja;
            RokPlacanja = rokPlacanja;
            RokIzvrsenja = rokIzvrsenja;
            CenaBezPDV = cenaBezPDV;
            CenaSaPDV = cenaSaPDV;
            IznosKapare = iznosKapare;
            NacinPlacanja = nacinPlacanja;
        }
    }
}
