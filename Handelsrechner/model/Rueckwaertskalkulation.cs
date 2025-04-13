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

        }

        protected void BerechneListenverkaufspreis()
        {
            Listenverkaufspreis = ListenverkaufspreisBrutto / (100 + UmsatzsteuerProzent) * 100;
            UmsatzsteuerEUR = ListenverkaufspreisBrutto - Listenverkaufspreis;
        }

        protected void BerechneZielverkaufspreis()
        {
            Zielverkaufspreis = Listenverkaufspreis / (100 + KundenrabattProzent) * 100;
            KundenrabattEUR = Listenverkaufspreis - Zielverkaufspreis;
        }

        protected void BerechneBarverkaufspreis()
        {
            Barverkaufspreis = Zielverkaufspreis / (100 + KundenskontoProzent + VertreterprovisionProzent) * 100;
            KundenskontoEUR = Barverkaufspreis - Zielverkaufspreis;
            VertreterprovisionEUR = Barverkaufspreis * VertreterprovisionProzent / 100;
        }
    }
}
