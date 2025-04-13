namespace Handelsrechner.model
{
    public class Handelskalkulation : KalkulationBasis
    {
        protected override string Titel { get; } = "Handelskalkulation";

        public override void BerechneKalkulation()
        {
            BerechneAngebot();

            BerechneHandlungskostenEUR();
            BerechneSelbstkosten();

            BerechneGewinnzuschlagEUR();
            BerechneBarverkaufspreis();


            BerechneZielverkaufspreis();

            BerechneKundenskontoEUR();
            BerechneVertreterprovisionEUR();


            BerechneListenverkaufspreis();

            BerechneKundenrabattEUR();

            BerechneUmsatzsteuerEUR();
            BerechneListenverkaufspreisBrutto();
        }
    }
}
