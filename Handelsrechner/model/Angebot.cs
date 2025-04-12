using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Handelsrechner.model
{
    internal class Angebot
    {
        public string? Angebotsname { get; set;}
        public decimal Nettoeinkaufspreis { get; set; }
        public decimal LieferrabattProzent { get; set; }
        public decimal LieferrabattEUR { get; set; }
        public decimal Zieleinkaufspreis { get; set; }
        public decimal LieferskontoProzent { get; set; }
        public decimal LieferskontoEUR { get; set; }
        public decimal Bareinkaufspreis { get; set; }
        public decimal Bezugskosten { get; set; }
        public decimal Bezugspreis { get; set; }

        public Dictionary<string, string> Eingabebogen { get; set; } = new Dictionary<string, string>()
        {
            {"Angebotsname", "Angebotsname"},
            {"Nettoeinkaufspreis", "Nettoeinkaufspreis"},
            {"LieferrabattProzent", "Lieferrabatt in Prozent"},
            {"LieferskontoProzent", "Lieferskonto in Prozent" },
            {"Bezugskosten", "Bezugskosten"}
        };

        public Dictionary<string, string> Ausgabebogen { get; set; } = new Dictionary<string, string>()
        {
            {"Angebotsname", "Angebotsname"},
            {"Nettoeinkaufspreis", "Nettoeinkaufspreis"},
            {"LieferrabattProzent", "Lieferrabatt in Prozent"},
            {"LieferrabattEUR", "Lieferrabatt in Euro"},
            {"Zieleinkaufspreis", "Zieleinkaufspreis"}
        };

        public void berechneAngebot()
        {
            berechneZieleinkaufspreis();
            berechneBareinkaufspreis();
            berechneBezugspreis();
        }

        protected void berechneZieleinkaufspreis()
        {
            Zieleinkaufspreis = Nettoeinkaufspreis * (100 - LieferrabattProzent) / 100;
            LieferrabattEUR = Nettoeinkaufspreis - Zieleinkaufspreis;
        }
        protected void berechneBareinkaufspreis()
        {
            Bareinkaufspreis = Zieleinkaufspreis * (100 - LieferskontoProzent) / 100;
            LieferskontoEUR = Bareinkaufspreis - Zieleinkaufspreis;
        }
        protected void berechneBezugspreis()
        {
            Bezugspreis = Bareinkaufspreis + Bezugskosten;
        }


    }
}
