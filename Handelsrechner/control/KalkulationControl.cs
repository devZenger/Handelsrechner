using Handelsrechner.Model;
using Handelsrechner.Service;
using Handelsrechner.View;

namespace Handelsrechner.Control
{
    internal class KalkulationControl : BasisControl
    {
        protected override string Titel { get; set; } = string.Empty;
        protected override List<string> MenuListe { get; } = new List<string> { "weitere Kalkulation durchführen", "zurück zum Hauptmenü" };
        public override void Ausfuehren(string auswahl)
        {
            Ausgabe ausgabe = new Ausgabe();
            string auswahlMenu = "1";

            while (true)
            {
                switch (auswahlMenu)
                {
                    case "1":
                        Kalkulation(auswahl);
                        auswahlMenu = "Optionen";
                        break;

                    case "Optionen":
                        auswahlMenu = ausgabe.MenuAuswahl(MenuListe);
                        break;

                    case "2":
                        return;

                    default:
                        ausgabe.Fehlermeldung(AuswahlFehlermeldung);
                        break;
                }
            }
        }
        protected void Kalkulation(string auswahl)
        {
            Eigenschaften eigenschaften = new Eigenschaften();
            ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();

            Ausgabe ausgabe = new Ausgabe();
            Titel = auswahl;
            ausgabe.Titel(Titel);

            KalkulationBasis? kalkulation = null;

            switch (auswahl)
            {
                case "Handelskalkulation":
                    kalkulation = new Handelskalkulation();
                    break;

                case "Differenzkalkulation":
                    kalkulation = new Differenzkalkulation();
                    break;

                case "Rückwärtskalkulation":
                    kalkulation = new Rueckwaertskalkulation();
                    break;

                default:
                    ausgabe.Fehlermeldung(AuswahlFehlermeldung);
                    break;
            }

            if (kalkulation != null)
            {
                foreach (var eingabe in kalkulation.Eingabebogen)
                {
                    bool richtig = false;
                    while (richtig == false)
                    {
                        string? eingabeString = ausgabe.Frage(eingabe.Value);

                        richtig = eigenschaften.VersuchSetzen(kalkulation, eingabe.Key, eingabeString);
                        if (richtig == false)
                        {
                            ausgabe.Fehlermeldung(Fehlermeldung);
                        }
                    }
                }

                kalkulation.BerechneKalkulation();

                var ausgabebogen = kalkulation.ErstelleAusgabebogen();

                List<string> tabelle = erzeugeTabelle.erstelleKalkulation(ausgabebogen);
                ausgabe.ZeigeTabelle(tabelle);
            }
            else
                ausgabe.Fehlermeldung("Kalkulation konnte nicht berechnet werden");
        }

    }
}

