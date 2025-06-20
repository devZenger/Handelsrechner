﻿namespace Handelsrechner.View

{
    internal class Ausgabe
    {
        private string Linie { get; } = "\t---------------------------------------------------------";

        public void Titel(string titel)
        {
            Console.WriteLine(Linie);
            Console.WriteLine($"\t{titel}");
            Console.WriteLine(Linie);
        }
        public void Info(string text)
        {
            Console.WriteLine($"\t{text}\n");
        }

        public string Frage(string text)
        {
            Console.Write($"\tBitte {text} eingeben: ");
            string? eingabe = Console.ReadLine();
            if (eingabe == null)
                eingabe = "";
            return eingabe;
        }

        public void Fehlermeldung(string text)
        {
            Console.WriteLine($"\t{text}");
            Console.WriteLine(Linie);
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
            Console.Write("\tBitte Zahl eingeben: ");
            string? eingabe = Console.ReadLine();
            Console.WriteLine(Linie);
            if (eingabe == null)
                eingabe = "";
            return eingabe;
        }
        public void ZeigeTabelle(List<string> tabelle)
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
