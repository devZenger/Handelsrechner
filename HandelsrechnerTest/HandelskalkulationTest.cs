using Handelsrechner.model;

namespace HandelsrechnerTest
{
    public class HandelskalkulationTest
    {
        [Fact]
        public void HandelskalkulationBerechnung()
        {
            Handelskalkulation hk = new Handelskalkulation();
            hk.Listeneinkaufspreis = 1000m;
            hk.LieferrabattProzent = 20m;
            hk.LieferskontoProzent = 5m;
            hk.Bezugskosten = 25m;
            hk.HandlungskostenProzent = 40m;
            hk.GewinnzuschlagProzent = 10m;
            hk.KundenskontoProzent = 5m;
            hk.VertreterprovisionProzent = 5m;
            hk.KundenrabattProzent = 20m;
            hk.UmsatzsteuerProzent = 19m;

            hk.BerechneKalkulation();

            decimal sollLieferrabattEUR = 200m;
            decimal sollZieleinkaufspreis = 800m;

            decimal sollLieferskontoEUR = 40m;
            decimal sollBareinkaufspreis = 760m;

            decimal sollBezugspreis = 785m;

            decimal sollHandlungskostenEUR = 314m;
            decimal sollSelbstkosten = 1099m;

            decimal sollGewinnzuschlagEUR = 109.9m;
            decimal sollBarverkaufspreis = 1_208.9m;

            decimal sollZielverkaufspreis = 1_343.22m;

            decimal sollKundenskontoEUR = 67.16m;
            decimal sollVertreterprovisionEUR = 67.16m;

            decimal sollListenverkaufspreis = 1_679.03m;
            decimal sollKundenrabattEUR = 335.81m;

            decimal sollUmsatzsteuerEUR = 319.02m;
            decimal sollListenverkaufspreisBrutto = 1_998.05m;

            Assert.Equal(sollLieferrabattEUR, hk.LieferrabattEUR);
            Assert.Equal(sollZieleinkaufspreis, hk.Zieleinkaufspreis);
            Assert.Equal(sollLieferskontoEUR, hk.LieferskontoEUR);
            Assert.Equal(sollBareinkaufspreis, hk.Bareinkaufspreis);
            Assert.Equal(sollBezugspreis, hk.Bezugspreis);

            Assert.Equal(sollHandlungskostenEUR, hk.HandlungskostenEUR);

            Assert.Equal(sollGewinnzuschlagEUR, hk.GewinnzuschlagEUR);
            decimal istSelbstkosten = Math.Round(hk.Selbstkosten, 2, MidpointRounding.ToEven);
            Assert.Equal(sollSelbstkosten, istSelbstkosten);

            decimal istBarverkaufspreis = Math.Round(hk.Barverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBarverkaufspreis, istBarverkaufspreis);

            decimal istZielverkaufspreis = Math.Round(hk.Zielverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollZielverkaufspreis, istZielverkaufspreis);

            Assert.Equal(sollKundenskontoEUR, hk.KundenskontoEUR);
            Assert.Equal(sollVertreterprovisionEUR, hk.VertreterprovisionEUR);

            decimal istListenverkaufspreis = Math.Round(hk.Listenverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreis, istListenverkaufspreis);
            Assert.Equal(sollKundenrabattEUR, hk.KundenrabattEUR);

            Assert.Equal(sollUmsatzsteuerEUR, hk.UmsatzsteuerEUR);
            decimal istListenverkaufspreisBrutto = Math.Round(hk.ListenverkaufspreisBrutto, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreisBrutto, istListenverkaufspreisBrutto);

        }
    }
}
