using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Handelsrechner.model;

namespace Handelsrechner.service
{
    internal class ErzeugeTabelle
    {
        private string decimalToString(decimal wert)
        {
            decimal wert2stellen = Math.Round(wert, 2, MidpointRounding.AwayFromZero);
            string wertString = wert2stellen.ToString("0.00");
            return wertString;
        }
        public List<string> erstelleVergleich(List<Angebot> list)
        {
            List<string> tabelle = new List<string>();
            Dictionary<string, string> ausgabebogen = list[0].Ausgabebogen;

            int maxLengthNamen = 0;
            foreach (string values in ausgabebogen.Values) 
            {
                int length = values.Length;
                if (length > maxLengthNamen)
                    maxLengthNamen = length;
            }

            foreach (string values in ausgabebogen.Values)
            {
                tabelle.Add($"{values.PadLeft(maxLengthNamen)} |");
            }

            int maxLengthAngebote = 9;
            for (int i = 0; i < list.Count; i++)
            {
                int length = list[i].Angebotsname.Length;

                if (length > maxLengthAngebote)
                    maxLengthAngebote = length;

                decimal wert = list[i].Nettoeinkaufspreis;
                decimal wert2stellen = Math.Round(wert, 2, MidpointRounding.AwayFromZero);
                string wertString = wert2stellen.ToString("0.00");
                length = wertString.Length + 4;

                if (length > maxLengthAngebote)
                    maxLengthAngebote = length;
            }

            Eigenschaften setzeEigenschaften = new Eigenschaften();
            int j = 0;
            foreach (string ausgabe in ausgabebogen.Keys)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (ausgabe == "Angebotsname")
                    {
                        int length = list[i].Angebotsname.Length;
                        int left = (maxLengthAngebote - length) / 2 + length;
                        string angebotsname = list[i].Angebotsname.PadLeft(left);
                        angebotsname = angebotsname.PadRight(maxLengthAngebote);
                        tabelle[0] = $"{tabelle[0]} {angebotsname} |";
                    }
                    else
                    {
                        var wert = setzeEigenschaften.lese(list[i], ausgabe);
                        decimal wertDecimal = Convert.ToDecimal(wert);
                        decimal wert2stellen = Math.Round(wertDecimal, 2, MidpointRounding.AwayFromZero);
                        string wertString = wert2stellen.ToString("0.00");

                        if (ausgabe.IndexOf("Prozent") >= 0)
                        {
                            wertString = $"{wertString} %";
                        }
                        else
                        {
                            wertString = $"{wertString} EUR";
                        }
                        tabelle[j] = $"{tabelle[j]} {wertString.PadLeft(maxLengthAngebote)} |";
                    }
                }
                j++;
            }
            return tabelle;
        }

        public List<string> erstelleKalkulation(Zuschlangskalkulation kalkulation)
        {
            List<string> tabelle = new List<string>();
            var ausgabebogen = kalkulation.Ausgabebogen;

            int length = 0;
            int maxLengthNamen = 0;
            foreach (string values in ausgabebogen.Values)
            {
                length = values.Length;
                if (length > maxLengthNamen)
                    maxLengthNamen = length;
            }

            int maxLength = 10;
            decimal wert = kalkulation.Nettoeinkaufspreis;
            string wertString = decimalToString(wert);
            length = wertString.Length + 4;

            if (length > maxLength)
                maxLength = length;

            string leerzeichen = new string(' ', maxLengthNamen);
            

            tabelle.Add($"{leerzeichen} | ");

            string eingabe = "Eingabe";
            string ausgabe = "Ausgabe";
            length = eingabe.Length;
            int left = (maxLength - length) / 2 + length;

            eingabe = eingabe.PadLeft(left);
            ausgabe = ausgabe.PadLeft(left);
            eingabe = eingabe.PadRight(maxLength);
            ausgabe = ausgabe.PadRight(maxLength);

            tabelle[0] = $"{tabelle[0]} {eingabe}| {ausgabe}|";


            Eigenschaften eigenschaften = new Eigenschaften();
            string leerstellen = new string(' ', maxLength);
            bool prozent = false;
            int j = 1;
            foreach (var bogen in ausgabebogen)
            {
                
                Console.WriteLine($"j nach j++  {j}");
                var key = bogen.Key;
                var value = bogen.Value;

                wert = Convert.ToDecimal(eigenschaften.lese(kalkulation, key));
                wertString = decimalToString(wert);

                if (key.IndexOf("Prozent") > 0)
                {
                    wertString = $"{wertString} %";
                    tabelle.Add($"{value.PadRight(maxLengthNamen)} | {wertString.PadLeft(maxLength)} |");
                    prozent = true;
                    
                    continue;
                }

                if (prozent == false)
                {
                    wertString = $"{wertString} EUR";
                    tabelle.Add($"{value.PadRight(maxLengthNamen)} | {leerstellen} | {wertString.PadLeft(maxLength)} |");
                }
                else
                {
                    
                    wertString = $"{wertString} EUR";
                    tabelle[j] = $"{tabelle[j]} {wertString.PadLeft(maxLength)} |";
                    prozent= false;
                }
                j++;
                //Console.WriteLine(tabelle[j-1]);
               



            }

            return tabelle;


        }
    }
}
