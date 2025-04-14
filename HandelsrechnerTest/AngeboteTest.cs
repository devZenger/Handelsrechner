using Handelsrechner.model;

namespace HandelsrechnerTest
{
    public class AngeboteTest
    {
        [Fact]
        public void AngebotBerechnung()
        {
            Angebot angebot = new Angebot();

            angebot.Listeneinkaufspreis = 1000;
            angebot.LieferrabattProzent = 20;
            angebot.LieferskontoProzent = 5;
            angebot.Bezugskosten = 25;

            angebot.BerechneAngebot();

            decimal sollLieferrabattEUR = 200;
            decimal sollZieleinkaufspreis = 800;
            decimal sollLieferskontoEUR = 40;
            decimal sollBareinkaufspreis = 760;
            decimal sollBezugspreis = 785;

            Assert.Equal(sollLieferrabattEUR, angebot.LieferrabattEUR);

            decimal istZieleinkaufspreis = Math.Round(angebot.Zieleinkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollZieleinkaufspreis, istZieleinkaufspreis);

            Assert.Equal(sollLieferskontoEUR, angebot.LieferskontoEUR);

            decimal istBareinkaufspreis = Math.Round(angebot.Bareinkaufspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBareinkaufspreis, istBareinkaufspreis);

            decimal istBezugspreis = Math.Round(angebot.Bezugspreis, 2, MidpointRounding.ToEven);
            Assert.Equal(sollBezugspreis, istBezugspreis);
        }
    }
}