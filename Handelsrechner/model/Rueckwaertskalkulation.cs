namespace Handelsrechner.model
{
    public class Rueckwaertskalkulation : KalkulationBasis
    {
        protected override string Titel { get; } = "Rückwärtskalkulation";
        public Rueckwaertskalkulation()
        {
            Eingabebogen.Remove("Listeneinkaufspreis");
            Eingabebogen.Add("ListenverkaufspreisBrutto", "Brutto-Listenverkaufspreis");
            //Eingabebogen.Add("UmsatzsteuerProzent", "Umsatzsteuer in Prozent");
            //Eingabebogen.Add("KundenrabattProzent", "Kundenrabatt in Prozent");

        }

        public override void BerechneKalkulation()
        {
            BerechneListenverkaufspreis();
            BerechneUmsatzsteuerEUR();

            BerechneZielverkaufspreis();
            BerechneKundenrabattEUR();

            BerechneKundenskontoEUR();
            BerechneVertreterprovisionEUR();

            BerechneBarverkaufspreis();

            BerechneSelbstkosten();
            BerechneGewinnzuschlagEUR();

            BerechneBezugspreis();
            BerechneHandlungskostenEUR();

            BerechneBareinkaufspreis();

            BerechneZieleinkaufspreis();
            BerechneLieferskontoEUR();

            BerechneListeneinkaufspreis();
            BerechneLieferrabattEUR();

        }
        protected override void BerechneBezugspreis()
        {
            Bezugspreis = Selbstkosten / (100 + HandlungskostenProzent) * 100;
        }
        protected override void BerechneBareinkaufspreis()
        {
            Bareinkaufspreis = Bezugspreis - Bezugskosten;
        }
        protected override void BerechneZieleinkaufspreis()
        {
            Zieleinkaufspreis = Bareinkaufspreis / (100 - LieferskontoProzent) * 100;
        }
        protected void BerechneListeneinkaufspreis()
        {
            Listeneinkaufspreis = Zieleinkaufspreis / (100 - LieferrabattProzent) * 100;
        }

    }
}
