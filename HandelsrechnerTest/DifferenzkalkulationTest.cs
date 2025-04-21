using Handelsrechner.Model;

namespace HandelsrechnerTest
{
    public class DifferenzkalkulationTest
    {
        [Fact]
        public void DifferenzkalkulationBerechnung()
        {
            Differenzkalkulation dk = new Differenzkalkulation();
            dk.Listeneinkaufspreis = 1000m;
            dk.LieferrabattProzent = 20m;
            dk.LieferskontoProzent = 5m;
            dk.Bezugskosten = 25m;
            dk.HandlungskostenProzent = 40m;
            
            dk.KundenskontoProzent = 5m;
            dk.VertreterprovisionProzent = 5m;
            dk.KundenrabattProzent = 20m;
            dk.UmsatzsteuerProzent = 19m;
            dk.ListenverkaufspreisBrutto = 1_998.05m;

            dk.BerechneKalkulation();

            decimal sollLieferrabattEUR = 200m;
            decimal sollZieleinkaufspreis = 800m;

            decimal sollLieferskontoEUR = 40m;
            decimal sollBareinkaufspreis = 760m;

            decimal sollBezugspreis = 785m;

            decimal sollHandlungskostenEUR = 314m;
            decimal sollSelbstkosten = 1099m;

            decimal sollGewinnzuschlagEUR = 109.91m;
            decimal sollGewinnzuschlagProzent = 10m;
            decimal sollBarverkaufspreis = 1_208.91m;

            decimal sollZielverkaufspreis = 1_343.23m;

            decimal sollKundenskontoEUR = 67.16m;
            decimal sollVertreterprovisionEUR = 67.16m;

            decimal sollListenverkaufspreis = 1_679.03m;
            decimal sollKundenrabattEUR = 335.81m;

            decimal sollUmsatzsteuerEUR = 319.02m;
            decimal sollListenverkaufspreisBrutto = 1_998.05m;


            Assert.Equal(sollGewinnzuschlagEUR, dk.GewinnzuschlagEUR);

            decimal istGewinnzuschlagProzent = Math.Round(dk.GewinnzuschlagProzent, 2, MidpointRounding.ToEven);
            Assert.Equal(sollGewinnzuschlagProzent, istGewinnzuschlagProzent);

            Assert.Equal(sollLieferrabattEUR, dk.LieferrabattEUR);
            
            Assert.Equal(sollZieleinkaufspreis, dk.Zieleinkaufspreis);
            Assert.Equal(sollLieferskontoEUR, dk.LieferskontoEUR);

            Assert.Equal(sollBareinkaufspreis, dk.Bareinkaufspreis);

            Assert.Equal(sollBezugspreis, dk.Bezugspreis);

            Assert.Equal(sollHandlungskostenEUR, dk.HandlungskostenEUR);
 
            decimal istSelbstkosten = Math.Round(dk.Selbstkosten, 2, MidpointRounding.ToEven);
            Assert.Equal(sollSelbstkosten, istSelbstkosten);

            decimal istBarverkaufspreis = Math.Round(dk.Barverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBarverkaufspreis, istBarverkaufspreis);

            decimal istZielverkaufspreis = Math.Round(dk.Zielverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollZielverkaufspreis, istZielverkaufspreis);

            Assert.Equal(sollKundenskontoEUR, dk.KundenskontoEUR);
            Assert.Equal(sollVertreterprovisionEUR, dk.VertreterprovisionEUR);

            decimal istListenverkaufspreis = Math.Round(dk.Listenverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreis, istListenverkaufspreis);
            Assert.Equal(sollKundenrabattEUR, dk.KundenrabattEUR);

            Assert.Equal(sollUmsatzsteuerEUR, dk.UmsatzsteuerEUR);
            decimal istListenverkaufspreisBrutto = Math.Round(dk.ListenverkaufspreisBrutto, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreisBrutto, istListenverkaufspreisBrutto);
        }
    }
}
