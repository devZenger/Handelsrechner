namespace Handelsrechner.model
{
    public class Angebot
    {
        public string? Angebotsname { get; set; }
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
            BerechneLieferrabattEUR();
            BerechneZieleinkaufspreis();
            BerechneLieferskontoEUR();
            BerechneBareinkaufspreis();
            BerechneBezugspreis();
        }

        protected void BerechneLieferrabattEUR()
        {
            if (LieferrabattProzent > 0)
            {
                LieferrabattEUR = Listeneinkaufspreis * LieferrabattProzent / 100;
                LieferrabattEUR = Math.Round(LieferrabattEUR, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                LieferrabattEUR = 0;
            }
        }
        protected void BerechneZieleinkaufspreis()
        {
            Zieleinkaufspreis = Listeneinkaufspreis - LieferrabattEUR;
        }
        protected void BerechneLieferskontoEUR()
        {
            if (LieferrabattProzent > 0)
            {
                LieferskontoEUR = Zieleinkaufspreis * LieferskontoProzent / 100;
                LieferskontoEUR = Math.Round(LieferskontoEUR, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                LieferskontoEUR = 0;
            }
        }
        protected void BerechneBareinkaufspreis()
        {
            Bareinkaufspreis = Zieleinkaufspreis - LieferskontoEUR;
        }
        protected void BerechneBezugspreis()
        {
            Bezugspreis = Bareinkaufspreis + Bezugskosten;
        }
    }
}
