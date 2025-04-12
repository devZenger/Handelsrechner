using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handelsrechner.model
{
    internal class Zuschlangskalkulation : Angebot
    {
        public decimal HandlungskostenProzent { get; set; }
        public decimal HandlungskostenEUR { get; set; }
        public decimal Selbstkosten { get; set; }
        public decimal GewinnzuschlagProzent { get; set; }
        public decimal GewinnzuschlagEUR { get; set; }
        public decimal Barverkaufspreis { get; set; }
        public decimal KundenskontoProzent { get; set; }
        public decimal KundenskontoEUR { get; set; }
        public decimal VertreterprovisionProzent { get; set; }
        public decimal VertreterprovisionEUR { get; set; }
        public decimal Zielverkaufspreis { get; set; }
        public decimal KundenrabattProzent { get; set; }
        public decimal KundenrabattEUR { get; set; }
        public decimal Listenverkaufspreis { get; set; }
        public decimal UmsatzsteuerProzent { get; set; }
        public decimal UmsatzsteuerEUR { get; set; }
        public decimal ListenverkaufspreisBrutto { get; set; }


        // Eingabebogen["HandlungskostenProzent"] = "Handlungskosten in Prozent";
        public Zuschlangskalkulation()
        {   
            Eingabebogen.Add("HandlungskostenProzent", "Handlungskosten in Prozent");
            Eingabebogen.Add("GewinnzuschlagProzent", "Gewinnzuschlag in Prozent");
            Eingabebogen.Add("KundenskontoProzent", "Kundenskonto in Prozent");
            Eingabebogen.Add("VertreterprovisionProzent", "Vertreterprovision in Prozent");
            Eingabebogen.Add("KundenrabattProzent", "Kundenrabatt in Prozent");
            Eingabebogen.Add("UmsatzsteuerProzent", "Umsatzsteuer in Prozent");
            Eingabebogen.Remove("Angebotsname");

            Ausgabebogen.Add("HandlungskostenProzent", "Handlungskosten");
            Ausgabebogen.Add("HandlungskostenEUR", "Handlungskosten in Euro");
            Ausgabebogen.Add("Selbstkosten", "Selbstkosten");
            Ausgabebogen.Add("GewinnzuschlagProzent", "Gewinnzuschlang in Prozent");
            Ausgabebogen.Add("GewinnzuschlagEUR", "Gewinnzuschlag in Euro");
            Ausgabebogen.Add("Barverkaufspreis", "Barverkaufspreis");
            Ausgabebogen.Add("KundenskontoProzent", "Kundenskonto in Prozent");
            Ausgabebogen.Add("KundenskontoEUR", "Kundenskonto in Euro");
            Ausgabebogen.Add("VertreterprovisionProzent", "Vertreterprovision in Prozent");
            Ausgabebogen.Add("VertreterprovisionEUR", "Vertreterprovision in Euro");
            Ausgabebogen.Add("Zielverkaufspreis", "Zielverkaufspreis");
            Ausgabebogen.Add("KundenrabattProzent", "Kundenrabatt in Prozent");
            Ausgabebogen.Add("KundenrabattEUR", "Kundenrabatt in Euro");
            Ausgabebogen.Add("Listenverkaufspreis", "Listenverkaufspreis");
            Ausgabebogen.Add("UmsatzsteuerProzent", "Umsatzsteuer in Prozent");
            Ausgabebogen.Add("UmsatzsteuerEUR", "Umsatzsteuer in Euro");
            Ausgabebogen.Add("ListenverkaufspreisBrutto", "Listenverkaufspreis Brutto");
            Ausgabebogen.Remove("Angebotsname");
        }

        public void berechneKalkulation()
        {
            berechneAngebot();
            berechneSelbstkosten();
            berechneBarverkaufspreis();
            berechneZielverkaufspreis();
            berechneListenverkaufspreis();
            berechneListenverkaufspreisBrutto();
        }

        public void berechneSelbstkosten()
        {
            Selbstkosten = Bezugskosten * (100 + HandlungskostenProzent) / 100;
            HandlungskostenEUR = Selbstkosten - Bezugskosten;
        }
        public void berechneBarverkaufspreis()
        {
            Bareinkaufspreis = Selbstkosten * (100 + GewinnzuschlagProzent) / 100;
            GewinnzuschlagEUR = Bareinkaufspreis - Selbstkosten;
        }
        public void berechneZielverkaufspreis()
        {
            Zielverkaufspreis = Barverkaufspreis * (100 + KundenskontoProzent + VertreterprovisionProzent) / 100;
            VertreterprovisionEUR = Zielverkaufspreis * VertreterprovisionProzent / 100;
            KundenskontoEUR = Zielverkaufspreis - VertreterprovisionEUR;
        }
        public void berechneListenverkaufspreis()
        {
            Listenverkaufspreis = Zielverkaufspreis / (100 - KundenrabattProzent) * 100;
            KundenrabattEUR = Listenverkaufspreis - Zielverkaufspreis;
        }
        public void berechneListenverkaufspreisBrutto()
        {
            ListenverkaufspreisBrutto = Listenverkaufspreis * (100 + UmsatzsteuerProzent) / 100;
            UmsatzsteuerEUR = ListenverkaufspreisBrutto - Listenverkaufspreis;
        }

    }
}
