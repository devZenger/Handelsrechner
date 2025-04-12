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

            var menuListe = new List<string>{ "Angebot hinzufügen", "Angebote berechnen", "Beenden" };

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
                            ausgabe.info($"Der günstigste Preis ist {preis} von {angebotsliste[angebot].Angebotsname}");
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
