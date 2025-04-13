using Handelsrechner.model;
using Handelsrechner.service;
using Handelsrechner.view;

namespace Handelsrechner.control
{
    internal class AngebotsvergleichControl : BasisControl
    {
        protected override string Titel { get; } = "Angebotvergleich";
        protected override List<string> MenuListe { get; } = new List<string> { "Angebot hinzufügen", "Angebote berechnen", "Beenden" };
        public override void ausfuehren(string auswahl = "1")
        {
            List<Angebot> angebotsliste = new List<Angebot>();
            Eigenschaften eigenschaften = new Eigenschaften();

            Ausgabe ausgabe = new Ausgabe();

            ausgabe.titel(Titel);

            while (true)
            {
                switch (auswahl)
                {
                    case "1":
                        angebotsliste.Add(new Angebot());
                        int i = angebotsliste.Count - 1;

                        foreach (var eingabe in angebotsliste[i].Eingabebogen)
                        {
                            bool richtig = false;
                            while (richtig == false)
                            {
                                string? eingabeString = ausgabe.frage(eingabe.Value);

                                richtig = eigenschaften.VersuchSetzen(angebotsliste[i], eingabe.Key, eingabeString);
                                if (richtig == false)
                                {
                                    ausgabe.fehlermeldung(Fehlermeldung);
                                }
                            }
                        }
                        auswahl = "Optionen";
                        break;

                    case "Optionen":
                        auswahl = ausgabe.MenuAuswahl(MenuListe);
                        break;

                    case "2": //Angebote berechnen
                        for (int j = 0; j < angebotsliste.Count; j++)
                        {
                            angebotsliste[j].BerechneAngebot();
                        }
                        ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();
                        var tabelle = erzeugeTabelle.erstelleVergleich(angebotsliste);
                        ausgabe.zeigeTabelle(tabelle);

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
                            ausgabe.info($"Der günstigste Preis ist {preis} vom Angebot: {angebotsliste[angebot].Angebotsname}");
                        }


                        auswahl = "Optionen";
                        break;

                    case "3":
                        Console.WriteLine("beenden");
                        break;

                    default:
                        ausgabe.fehlermeldung(Fehlermeldung);
                        auswahl = "Optionen";
                        break;

                }
            }

        }
    }
}
