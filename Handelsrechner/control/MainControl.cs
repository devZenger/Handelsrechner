using Handelsrechner.view;

namespace Handelsrechner.control
{
    internal class MainControl : BasisControl
    {
        
        private string titel = "Handelsrechner";
        private List<string> menuListe = new List<string> { "Handelskalkulation", "Angebotvergleich", "Beenden" };
        
        public override void ausfuehren()
        {
            Ausgabe ausgabe = new Ausgabe();

            string auswahl = "Optionen";

            while (true)
            {
                ausgabe.titel(titel);

                switch (auswahl)
                {
                    case "1":
                        HandelskalkulationControl handelskalkulationControl = new HandelskalkulationControl();
                        handelskalkulationControl.ausfuehren();
                        break;

                    case "2":
                        AngebotvergleichControl angebotvergleichControl = new AngebotvergleichControl();
                        angebotvergleichControl.ausfuehren();
                        break;

                    case "Optionen":
                        auswahl = ausgabe.MenuAuswahl(menuListe);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

            }

            //AngebotvergleichControl angebotvergleichControl = new AngebotvergleichControl();
            //angebotvergleichControl.ausfuehren();
        }
    }
}
