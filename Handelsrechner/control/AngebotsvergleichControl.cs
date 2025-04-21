using Handelsrechner.Model;
using Handelsrechner.Service;
using Handelsrechner.View;

namespace Handelsrechner.Control
{
    internal class AngebotsvergleichControl : BasisControl
    {
        protected override string Titel { get; set; } = "Angebotsvergleich";
        protected string Info { get; } = "Angaben ohne Währungszeichen eingeben";
        protected override List<string> MenuListe { get; } = new List<string> { "Angebot hinzufügen", "Angebot berechnen", "zurück zum Hauptmenü" };
        protected List<string> MenuListeMehrere { get; } = new List<string> { "Angebot hinzufügen", "Angebote berechnen und vergleichen", "zurück zum Hauptmenü" };
        public override void Ausfuehren(string auswahl = "1")
        {
            List<Angebot> angebotsliste = new List<Angebot>();
            Eigenschaften eigenschaften = new Eigenschaften();

            Ausgabe ausgabe = new Ausgabe();

            ausgabe.Titel(Titel);

            while (true)
            {
                switch (auswahl)
                {
                    case "1": // Angebot eingeben
                        angebotsliste.Add(new Angebot());
                        int i = angebotsliste.Count - 1;

                        ausgabe.Info(Info);

                        foreach (var eingabe in angebotsliste[i].Eingabebogen)
                        {
                            bool richtig = false;
                            while (richtig == false)
                            {
                                string? eingabeString = ausgabe.Frage(eingabe.Value);

                                richtig = eigenschaften.VersuchSetzen(angebotsliste[i], eingabe.Key, eingabeString);
                                if (richtig == false)
                                {
                                    ausgabe.Fehlermeldung(Fehlermeldung);
                                }
                            }
                        }
                        auswahl = "Optionen";
                        break;

                    case "Optionen":
                        if (angebotsliste.Count == 1)
                            auswahl = ausgabe.MenuAuswahl(MenuListe);
                        else
                            auswahl = ausgabe.MenuAuswahl(MenuListeMehrere);
                        break;

                    case "2": //Angebote berechnen
                        for (int j = 0; j < angebotsliste.Count; j++)
                        {
                            angebotsliste[j].BerechneAngebot();
                        }
                        ausgabe.Titel(Titel);
                        ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();
                        var tabelle = erzeugeTabelle.erstelleVergleich(angebotsliste);
                        ausgabe.ZeigeTabelle(tabelle);

                        int angebot = 0;
                        if (angebotsliste.Count > 1)
                        {
                            var preis = angebotsliste[0].Bezugspreis;
                            for (int j = 1; j < angebotsliste.Count; j++)
                            {
                                if (preis > angebotsliste[j].Bezugspreis)
                                    preis = angebotsliste[j].Bezugspreis;
                                angebot = j;
                            }
                            ausgabe.Info($"Der günstigste Preis ist {preis} Euro vom {angebotsliste[angebot].Angebotsname}");
                        }
                        auswahl = "Optionen";
                        break;

                    case "3":
                        return;
                 
                    default:
                        ausgabe.Fehlermeldung(Fehlermeldung);
                        auswahl = "Optionen";
                        break;
                }
            }
        }
    }
}
