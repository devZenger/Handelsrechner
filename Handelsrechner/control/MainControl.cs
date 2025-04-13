using Handelsrechner.view;

namespace Handelsrechner.control
{
    internal class MainControl : BasisControl
    {

        protected override string Titel { get; } = "Handelsrechner";
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
                ausgabe.titel(Titel);

                switch (auswahl)
                {
                    case "Optionen":
                        auswahl = ausgabe.MenuAuswahl(MenuListe);
                        break;

                    // Handelskalkulation
                    case "1":
                        kalkulationControl.ausfuehren("Handelskalkulation");
                        break;

                    // Rückwärtskalkulation
                    case "2":
                        kalkulationControl.ausfuehren("Rückwärtskalkulation");
                        break;

                    // Diffenenzkalkulation
                    case "3":
                        kalkulationControl.ausfuehren("Differenzkalkulation");
                        break;

                    // Angebotsvergleich
                    case "4":
                        AngebotsvergleichControl angebotvergleichControl = new AngebotsvergleichControl();
                        angebotvergleichControl.ausfuehren();
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
