using System.Reflection;

using Handelsrechner.model;
using Handelsrechner.view;
using Handelsrechner.service;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Handelsrechner.control
{
    internal class AngebotvergleichControl : BasisControl
    {
        private string titel = "Angebotvergleich";
        public override void ausfuehren()
        {
            List<Angebot> angebotsliste = new List<Angebot>();

            Eigenschaften eigenschaften = new Eigenschaften();

            var menuListe = new List<string>{ "Angebot hinzufügen", "Angebote vergleichen", "Beenden" };

            string auswahl = "1";
            // string fehlermeldung = "Eingabe war nicht korrekt, bitte erneut versuchen.";

            Ausgabe ausgabe = new Ausgabe();

            ausgabe.titel(titel);

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
                                if ( richtig == false)
                                {
                                    ausgabe.fehlermeldung(Fehlermeldung);
                                }
                            }
                        }
                        auswahl = "Optionen";
                        break;

                    case "Optionen":
                        auswahl = ausgabe.MenuAuswahl(menuListe);
                        break;

                    case "2": //Angebote vergleichen
                        for (int j = 0; j < angebotsliste.Count; j++)
                        {
                            angebotsliste[j].berechneAngebot();
                        }
                        ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();
                        var tabelle = erzeugeTabelle.erstelleVergleich(angebotsliste);
                        ausgabe.zeigeTabelle(tabelle);
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
