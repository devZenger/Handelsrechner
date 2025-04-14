using Handelsrechner.service;

namespace Handelsrechner.model
{
    public abstract class KalkulationBasis : Angebot
    {
        protected abstract string Titel { get; }
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
        public KalkulationBasis()
        {
            Eingabebogen.Add("HandlungskostenProzent", "Handlungskosten in Prozent");
            Eingabebogen.Add("GewinnzuschlagProzent", "Gewinnzuschlag in Prozent");
            Eingabebogen.Add("KundenskontoProzent", "Kundenskonto in Prozent");
            Eingabebogen.Add("VertreterprovisionProzent", "Vertreterprovision in Prozent");
            Eingabebogen.Add("KundenrabattProzent", "Kundenrabatt in Prozent");
            Eingabebogen.Add("UmsatzsteuerProzent", "Umsatzsteuer in Prozent");
            Eingabebogen.Remove("Angebotsname");
        }

        public abstract void BerechneKalkulation();

        protected void BerechneHandlungskostenEUR()
        {
            if (HandlungskostenProzent > 0)
            {
                HandlungskostenEUR = Bezugspreis * HandlungskostenProzent / 100m;
                HandlungskostenEUR = Math.Round(HandlungskostenEUR, 2, MidpointRounding.ToEven);
            }
            else
            {
                HandlungskostenEUR = 0;
            }
        }
        protected void BerechneSelbstkosten()
        {
            if (Bezugspreis > 0)
                Selbstkosten = Bezugspreis + HandlungskostenEUR;
            else
                Selbstkosten = Barverkaufspreis / (100 + GewinnzuschlagProzent) * 100;
        }

        protected void BerechneGewinnzuschlagEUR()
        {
            if (GewinnzuschlagProzent > 0)
            {
                GewinnzuschlagEUR = Selbstkosten * GewinnzuschlagProzent / 100;
                GewinnzuschlagEUR = Math.Round(GewinnzuschlagEUR, 2, MidpointRounding.ToEven);
               
            }
            else
            {
                GewinnzuschlagEUR = 0;
            }
        }
        protected void BerechneBarverkaufspreis()
        {
            if (Selbstkosten > 0 && GewinnzuschlagProzent > 0)
                Barverkaufspreis = Selbstkosten + GewinnzuschlagEUR;
            else
                Barverkaufspreis = Zielverkaufspreis - KundenskontoEUR - VertreterprovisionEUR;

            Console.WriteLine($"Barverkaufspreis: {Barverkaufspreis.ToString()}");
        }
        protected void BerechneKundenskontoEUR()
        {
            if (KundenskontoProzent > 0)
            {
                KundenskontoEUR = Zielverkaufspreis * KundenskontoProzent / 100;
                KundenskontoEUR = Math.Round(KundenskontoEUR, 2, MidpointRounding.ToEven);
            }
            else
            {
                KundenskontoEUR = 0;
            }
        }
        protected void BerechneVertreterprovisionEUR()
        {
            if (VertreterprovisionProzent > 0)
            {
                VertreterprovisionEUR = Zielverkaufspreis * VertreterprovisionProzent / 100;
                VertreterprovisionEUR = Math.Round(VertreterprovisionEUR, 2, MidpointRounding.ToEven);
            }
            else
            {
                VertreterprovisionEUR = 0;
            }
        }
        protected void BerechneZielverkaufspreis()
        {
            Console.WriteLine($"Barverkaufspreis {Barverkaufspreis.ToString()}");

            if (Barverkaufspreis > 0)
                Zielverkaufspreis = Barverkaufspreis / (100 - KundenskontoProzent - VertreterprovisionProzent) * 100;
            else
                Zielverkaufspreis = Listenverkaufspreis / 100 * (100 - KundenrabattProzent);

            Console.WriteLine($"Zielverkaufspreis {Zielverkaufspreis.ToString()}");
        }
        protected void BerechneKundenrabattEUR()
        {
            if (KundenrabattProzent > 0)
            {
                KundenrabattEUR = Listenverkaufspreis * KundenrabattProzent / 100;
                KundenrabattEUR = Math.Round(KundenrabattEUR, 2, MidpointRounding.ToEven);
            }
            else
            {
                KundenrabattEUR = 0;
            }
        }
        protected void BerechneListenverkaufspreis()
        {
            if (Zielverkaufspreis > 0)
                Listenverkaufspreis = Zielverkaufspreis / (100 - KundenrabattProzent) * 100;
            else
                Listenverkaufspreis = ListenverkaufspreisBrutto / (100 + UmsatzsteuerProzent) * 100;

            Console.WriteLine($"Listenverkaufspreis {Listenverkaufspreis.ToString()}");
        }
        protected void BerechneUmsatzsteuerEUR()
        {
            if (UmsatzsteuerProzent > 0)
            {
                UmsatzsteuerEUR = Listenverkaufspreis * UmsatzsteuerProzent / 100;
                UmsatzsteuerEUR = Math.Round(UmsatzsteuerEUR, 2, MidpointRounding.ToEven);
            }
            else
            {
                UmsatzsteuerEUR = 0;
            }
        }
        protected void BerechneListenverkaufspreisBrutto()
        {
            ListenverkaufspreisBrutto = Listenverkaufspreis + UmsatzsteuerEUR;
        }

        public Dictionary<string, List<string>> ErstelleAusgabebogen()
        {
            Dictionary<string, List<string>> ausgabebogen = new Dictionary<string, List<string>>();

            ErzeugeTabelle eT = new ErzeugeTabelle();

            List<string> werte = new List<string>();
            ausgabebogen.Add($"{Titel}", new List<string> { "in Prozent", "in Euro" });
            ausgabebogen.Add("Listeneinkaufspreis", new List<string> { " ", $"{eT.decimalToString(Listeneinkaufspreis)}" });
            ausgabebogen.Add("Lieferrabatt", new List<string> { $"{eT.decimalToString(LieferrabattProzent)}", $"{eT.decimalToString(LieferrabattEUR)}" });
            ausgabebogen.Add("Zieleinkaufspreis", new List<string> { " ", $"{eT.decimalToString(Zieleinkaufspreis)}" });
            ausgabebogen.Add("Lieferskonto", new List<string> { $"{eT.decimalToString(LieferskontoProzent)}", $"{eT.decimalToString(LieferskontoEUR)}" });
            ausgabebogen.Add("Bareinkaufspreis", new List<string> { " ", $"{eT.decimalToString(Bareinkaufspreis)}" });
            ausgabebogen.Add("Bezugskosten", new List<string> { " ", $"{eT.decimalToString(Bezugskosten)}" });
            ausgabebogen.Add("Bezugspreis", new List<string> { " ", $"{eT.decimalToString(Bezugspreis)}" });
            ausgabebogen.Add("Handlungskosten", new List<string> { $"{eT.decimalToString(HandlungskostenProzent)}", $"{eT.decimalToString(HandlungskostenEUR)}" });
            ausgabebogen.Add("Selbstkosten", new List<string> { " ", $"{eT.decimalToString(Selbstkosten)}" });
            ausgabebogen.Add("Gewinnzuschlag", new List<string> { $"{eT.decimalToString(GewinnzuschlagProzent)}", $"{eT.decimalToString(GewinnzuschlagEUR)}" });
            ausgabebogen.Add("Barverkaufspreis", new List<string> { " ", $"{eT.decimalToString(Barverkaufspreis)}" });
            ausgabebogen.Add("Kundenskonto", new List<string> { $"{eT.decimalToString(KundenskontoProzent)}", $"{eT.decimalToString(KundenskontoEUR)}" });
            ausgabebogen.Add("Vertreterprovision", new List<string> { $"{eT.decimalToString(VertreterprovisionProzent)}", $"{eT.decimalToString(VertreterprovisionEUR)}" });
            ausgabebogen.Add("Zielverkaufspreis", new List<string> { " ", $"{eT.decimalToString(Zielverkaufspreis)}" });
            ausgabebogen.Add("Kundenrabatt", new List<string> { $"{eT.decimalToString(KundenrabattProzent)}", $"{eT.decimalToString(KundenrabattEUR)}" });
            ausgabebogen.Add("Listenverkaufspreis", new List<string> { " ", $"{eT.decimalToString(Listenverkaufspreis)}" });
            ausgabebogen.Add("Umsatzsteuer", new List<string> { $"{eT.decimalToString(UmsatzsteuerProzent)}", $"{eT.decimalToString(UmsatzsteuerEUR)}" });
            ausgabebogen.Add("Listenverkaufspreis Brutto", new List<string> { " ", $"{eT.decimalToString(ListenverkaufspreisBrutto)}" });

            return ausgabebogen;
        }
    }
}
