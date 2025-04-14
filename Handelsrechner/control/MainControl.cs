using Handelsrechner.view;

namespace Handelsrechner.control
{
    internal class MainControl : BasisControl
    {
        protected override string Titel { get; set; } = "Handelsrechner";
        protected override List<string> MenuListe { get; } = new List<string> { "Handelskalkulation",
                                                                                "Rückwärtskalkulation",
                                                                                "Differenzkalulation",
                                                                                "Angebotsvergleich",
                                                                                "Beenden" };
        public override void ausfuehren(string auswahl = "Optionen")
        {
            Ausgabe ausgabe = new Ausgabe();
            KalkulationControl kalkulationControl = new KalkulationControl();

            while (true)
            {
                switch (auswahl)
                {
                    case "Optionen":
                        ausgabe.titel(Titel);
                        auswahl = ausgabe.MenuAuswahl(MenuListe);
                        break;

                    // Handelskalkulation
                    case "1":
                        kalkulationControl.ausfuehren("Handelskalkulation");
                        auswahl = "Optionen";
                        break;

                    // Rückwärtskalkulation
                    case "2":
                        kalkulationControl.ausfuehren("Rückwärtskalkulation");
                        auswahl = "Optionen";
                        break;

                    // Diffenenzkalkulation
                    case "3":
                        kalkulationControl.ausfuehren("Differenzkalkulation");
                        auswahl = "Optionen";
                        break;

                    // Angebotsvergleich
                    case "4":
                        AngebotsvergleichControl angebotvergleichControl = new AngebotsvergleichControl();
                        angebotvergleichControl.ausfuehren();
                        auswahl = "Optionen";
                        break;

                    // Programm beenden
                    case "5":
                        return;

                    default:
                        ausgabe.fehlermeldung(AuswahlFehlermeldung);
                        auswahl = "Optionen";
                        break;
                }
            }
        }
    }
}
