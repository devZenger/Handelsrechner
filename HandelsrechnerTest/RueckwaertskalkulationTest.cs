using Handelsrechner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandelsrechnerTest
{
    public class RueckwaertskalkulationTest
    {
        [Fact]
        public void RueckwaertskalkulationBerechnung()
        {
            Rueckwaertskalkulation rk = new Rueckwaertskalkulation();
            
            rk.LieferrabattProzent = 20m;
            rk.LieferskontoProzent = 5m;
            rk.Bezugskosten = 25m;
            rk.HandlungskostenProzent = 40m;
            rk.GewinnzuschlagProzent = 10m;
            rk.KundenskontoProzent = 5m;
            rk.VertreterprovisionProzent = 5m;
            rk.KundenrabattProzent = 20m;
            rk.UmsatzsteuerProzent = 19m;
            rk.ListenverkaufspreisBrutto = 1_998.05m;

            rk.BerechneKalkulation();

            decimal sollListeneinkaufspreis = 1000m;

            decimal sollLieferrabattEUR = 200m;
            decimal sollZieleinkaufspreis = 800m;

            decimal sollLieferskontoEUR = 40m;
            decimal sollBareinkaufspreis = 760m;

            decimal sollBezugspreis = 785m;

            decimal sollHandlungskostenEUR = 314m;
            decimal sollSelbstkosten = 1099.01m;

            decimal sollGewinnzuschlagEUR = 109.9m;
            decimal sollBarverkaufspreis = 1_208.91m;

            decimal sollZielverkaufspreis = 1_343.23m;

            decimal sollKundenskontoEUR = 67.16m;
            decimal sollVertreterprovisionEUR = 67.16m;

            decimal sollListenverkaufspreis = 1_679.03m;
            decimal sollKundenrabattEUR = 335.81m;

            decimal sollUmsatzsteuerEUR = 319.02m;
            decimal sollListenverkaufspreisBrutto = 1_998.05m;

            decimal istListeneinkaufspreis = Math.Round(rk.Listeneinkaufspreis, 2, MidpointRounding.ToEven);

            Assert.Equal(sollLieferrabattEUR, rk.LieferrabattEUR);

            decimal istZieleinkaufspreis = Math.Round(rk.Zieleinkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollZieleinkaufspreis, istZieleinkaufspreis);

            Assert.Equal(sollLieferskontoEUR, rk.LieferskontoEUR);

            decimal istBareinkaufspreis = Math.Round(rk.Bareinkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBareinkaufspreis, istBareinkaufspreis);

            decimal istBezugspreis = Math.Round(rk.Bezugspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBezugspreis, istBezugspreis);

            Assert.Equal(sollHandlungskostenEUR, rk.HandlungskostenEUR);

            Assert.Equal(sollGewinnzuschlagEUR, rk.GewinnzuschlagEUR);

            decimal istSelbstkosten = Math.Round(rk.Selbstkosten, 2, MidpointRounding.ToEven);
            Assert.Equal(sollSelbstkosten, istSelbstkosten);

            decimal istBarverkaufspreis = Math.Round(rk.Barverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBarverkaufspreis, istBarverkaufspreis);

            decimal istZielverkaufspreis = Math.Round(rk.Zielverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollZielverkaufspreis, istZielverkaufspreis);

            Assert.Equal(sollKundenskontoEUR, rk.KundenskontoEUR);
            Assert.Equal(sollVertreterprovisionEUR, rk.VertreterprovisionEUR);

            decimal istListenverkaufspreis = Math.Round(rk.Listenverkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreis, istListenverkaufspreis);
            Assert.Equal(sollKundenrabattEUR, rk.KundenrabattEUR);

            Assert.Equal(sollUmsatzsteuerEUR, rk.UmsatzsteuerEUR);
            decimal istListenverkaufspreisBrutto = Math.Round(rk.ListenverkaufspreisBrutto, 2, MidpointRounding.ToEven);
            Assert.Equal(sollListenverkaufspreisBrutto, istListenverkaufspreisBrutto);
        }
    }
}
