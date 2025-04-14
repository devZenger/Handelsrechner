using System;

namespace Handelsrechner.model
{
    public class Differenzkalkulation : Handelskalkulation
    {

        protected override string Titel { get; } = "Differenzkalkulation";

        public Differenzkalkulation()
        {
            Eingabebogen.Add("ListenverkaufspreisBrutto", "Listenverkaufspreis Brutto");
            Eingabebogen.Remove("GewinnzuschlagProzent");
        }

        public override void BerechneKalkulation()
        {
            BerechneAngebot();

            BerechneHandlungskostenEUR();
            BerechneSelbstkosten();

            BerechneListenverkaufspreis();
            BerechneUmsatzsteuerEUR();

            BerechneZielverkaufspreis();
            BerechneKundenrabattEUR();
            
            BerechneKundenskontoEUR();
            BerechneVertreterprovisionEUR();
            BerechneBarverkaufspreis();

            BerechneGewinn();
        }

        protected void BerechneGewinn()
        {
            GewinnzuschlagEUR = Barverkaufspreis - Selbstkosten;
            GewinnzuschlagEUR = Math.Round(GewinnzuschlagEUR, 2, MidpointRounding.ToEven);

            GewinnzuschlagProzent = ((Barverkaufspreis / Selbstkosten) - 1) * 100;
        }
    }
}
