using Handelsrechner.model;
using Handelsrechner.service;
using Handelsrechner.view;

namespace Handelsrechner.control
{
    internal class KalkulationControl : BasisControl
    {
        protected override string Titel { get; } = "Handelskalkulation";
        protected override List<string> MenuListe { get; } = new List<string> { "Handelskalkulation", "Beenden" };

        public override void ausfuehren(string auswahl)
        {
            Eigenschaften eigenschaften = new Eigenschaften();
            ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();


            Ausgabe ausgabe = new Ausgabe();

            ausgabe.titel(Titel);

            KalkulationBasis? kalkulation = null;

            switch (auswahl)
            {
                case "Handelskalkulation":
                    kalkulation = new Handelskalkulation();
                    break;

                case "Differenzkalkulation":
                    kalkulation = new Differenzkalkulation();
                    break;

                default:
                    ausgabe.fehlermeldung(AuswahlFehlermeldung);
                    break;
            }

            if (kalkulation != null)
            {
                foreach (var eingabe in kalkulation.Eingabebogen)
                {
                    bool richtig = false;
                    while (richtig == false)
                    {
                        string? eingabeString = ausgabe.frage(eingabe.Value);

                        richtig = eigenschaften.VersuchSetzen(kalkulation, eingabe.Key, eingabeString);
                        if (richtig == false)
                        {
                            ausgabe.fehlermeldung(Fehlermeldung);
                        }
                    }
                }

                kalkulation.BerechneKalkulation();

                var ausgabebogen = kalkulation.ErstelleAusgabebogen();

                List<string> tabelle = erzeugeTabelle.erstelleKalkulation(ausgabebogen);
                ausgabe.zeigeTabelle(tabelle);
            }
            else
                ausgabe.fehlermeldung("Kalkulation konnte nicht berechne werden");


        }

    }
}
