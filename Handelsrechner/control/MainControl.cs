using Handelsrechner.View;

namespace Handelsrechner.Control
{
    internal class MainControl : BasisControl
    {
        protected override string Titel { get; set; } = "Handelsrechner";
        protected override List<string> MenuListe { get; } = new List<string> { "Handelskalkulation",
                                                                                "Rückwärtskalkulation",
                                                                                "Differenzkalulation",
                                                                                "Angebotsvergleich",
                                                                                "Beenden" };
        public override void Ausfuehren(string auswahl = "Optionen")
        {
            Ausgabe ausgabe = new Ausgabe();
            KalkulationControl kalkulationControl = new KalkulationControl();

            while (true)
            {
                switch (auswahl)
                {
                    case "Optionen":
                        ausgabe.Titel(Titel);
                        auswahl = ausgabe.MenuAuswahl(MenuListe);
                        break;

                    // Handelskalkulation
                    case "1":
                        kalkulationControl.Ausfuehren("Handelskalkulation");
                        auswahl = "Optionen";
                        break;

                    // Rückwärtskalkulation
                    case "2":
                        kalkulationControl.Ausfuehren("Rückwärtskalkulation");
                        auswahl = "Optionen";
                        break;

                    // Diffenenzkalkulation
                    case "3":
                        kalkulationControl.Ausfuehren("Differenzkalkulation");
                        auswahl = "Optionen";
                        break;

                    // Angebotsvergleich
                    case "4":
                        AngebotsvergleichControl angebotvergleichControl = new AngebotsvergleichControl();
                        angebotvergleichControl.Ausfuehren();
                        auswahl = "Optionen";
                        break;

                    // Programm beenden
                    case "5":
                        return;

                    default:
                        ausgabe.Fehlermeldung(AuswahlFehlermeldung);
                        auswahl = "Optionen";
                        break;
                }
            }
        }
    }
}
