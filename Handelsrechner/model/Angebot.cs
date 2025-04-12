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
        public decimal Listeneinkaufspreis { get; set; }
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
            {"Listeneinkaufspreis", "Listeneinkaufspreis"},
            {"LieferrabattProzent", "Lieferrabatt in Prozent"},
            {"LieferskontoProzent", "Lieferskonto in Prozent" },
            {"Bezugskosten", "Bezugskosten"}
        };

        public Dictionary<string, string> Ausgabebogen { get; set; } = new Dictionary<string, string>()
        {
            {"Angebotsname", "Angebotsname"},
            {"Listeneinkaufspreis", "Listeneinkaufspreis"},
            {"LieferrabattProzent", "Lieferrabatt in Prozent"},
            {"LieferrabattEUR", "Lieferrabatt in Euro"},
            {"Zieleinkaufspreis", "Zieleinkaufspreis"},
            {"LieferskontoProzent", "Lieferskonto in Prozent"},
            {"LieferskontoEUR", "Lieferskonto in Euro"},
            {"Bareinkaufspreis", "Bareinkaufspreis"},
            {"Bezugskosten", "Bezugskosten"},
            {"Bezugspreis", "Bezugspreis"}
        };

        public void BerechneAngebot()
        {
            BerechneZieleinkaufspreis();
            BerechneBareinkaufspreis();
            BerechneBezugspreis();
        }

        protected void BerechneZieleinkaufspreis()
        {
            Zieleinkaufspreis = Listeneinkaufspreis * (100 - LieferrabattProzent) / 100;
            LieferrabattEUR = Listeneinkaufspreis - Zieleinkaufspreis;
        }
        protected void BerechneBareinkaufspreis()
        {
            Bareinkaufspreis = Zieleinkaufspreis * (100 - LieferskontoProzent) / 100;
            LieferskontoEUR = Zieleinkaufspreis - Bareinkaufspreis;
        }
        protected void BerechneBezugspreis()
        {
            Bezugspreis = Bareinkaufspreis + Bezugskosten;
        }


    }
}
