using Handelsrechner.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Handelsrechner.view

{
    internal class Ausgabe
    {
        private string Linie = "--------------------------------------------------";

        public void titel(string titel)
        {
            Console.WriteLine(Linie);
            Console.WriteLine($"\t{titel}");
            Console.WriteLine(Linie);
        }

        public string frage(string text)
        {
            Console.Write($"\tBitte {text} eingeben: ");
            string? eingabe = Console.ReadLine();
            return eingabe;
        }

        public void fehlermeldung(string text)
        {
            Console.WriteLine($"\t{text}");
        }

        public string MenuAuswahl(List<string> auswahl)
        {
            Console.WriteLine("\tBitte eine Auswahl treffen:");
            Console.WriteLine(Linie);
            for (int i = 0; i < auswahl.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {auswahl[i]}");
            }
            Console.WriteLine(Linie);
            string? eingabe = Console.ReadLine();
            return eingabe;
        }
        public void zeigeTabelle(List<string> tabelle)
        {
            Console.WriteLine(Linie);
            for (int i = 0; i < tabelle.Count; i++)
            {
                Console.WriteLine($"\t{tabelle[i]}");
            }
            Console.WriteLine(Linie);
        }




    }
}
