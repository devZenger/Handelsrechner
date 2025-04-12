using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handelsrechner.view;
using Handelsrechner.model;
using Handelsrechner.service;

namespace Handelsrechner.control
{
    internal class HandelskalkulationControl : BasisControl
    {
        private string titel = "Handelskalkulation";

        public override void ausfuehren()
        {
            Eigenschaften eigenschaften = new Eigenschaften();

            ErzeugeTabelle erzeugeTabelle = new ErzeugeTabelle();

            var menuListe = new List<string> { "Zuschlagskalkulation", "Beenden" };

            string auswahl = "Optionen";

            Ausgabe ausgabe = new Ausgabe();

            ausgabe.titel(titel);

            while (true)
            {
                switch(auswahl)
                {
                    case "1":
                        Zuschlangskalkulation zuschlangskalkulation = new Zuschlangskalkulation();

                        foreach (var eingabe in zuschlangskalkulation.Eingabebogen)
                        {
                            bool richtig = false;
                            while (richtig == false)
                            {
                                string? eingabeString = ausgabe.frage(eingabe.Value);

                                richtig = eigenschaften.VersuchSetzen(zuschlangskalkulation, eingabe.Key, eingabeString);
                                if (richtig == false)
                                {
                                    ausgabe.fehlermeldung(Fehlermeldung);
                                }
                            }
                        }
                        zuschlangskalkulation.berechneKalkulation();

                        List<string> tabelle = erzeugeTabelle.erstelleKalkulation(zuschlangskalkulation);

                        ausgabe.zeigeTabelle(tabelle);

                        auswahl = "Optionen";
                        break;

                    case "Optionen":
                        auswahl = ausgabe.MenuAuswahl(menuListe);
                        break;

                    case "2":
                        break;

                    default:
                        auswahl = "Optionen";
                        break;
                }
            }
        }
    }
}
