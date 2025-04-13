using Handelsrechner.model;

namespace Handelsrechner.service
{
    internal class ErzeugeTabelle
    {
        public string decimalToString(decimal wert)
        {
            decimal wert2stellen = Math.Round(wert, 2, MidpointRounding.ToEven);
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

                decimal wert = list[i].Listeneinkaufspreis;
                decimal wert2stellen = Math.Round(wert, 2, MidpointRounding.ToEven);
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
                        decimal wert2stellen = Math.Round(wertDecimal, 2, MidpointRounding.ToEven);
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

        public List<string> erstelleKalkulation(Dictionary<string, List<string>> ausgabebogen)
        {
            List<string> tabelle = new List<string>();

            int maxLengthProzent = 0;
            int maxLengthEuro = 0;
            int maxLengthNamen = 0;
            foreach (var ausgabe in ausgabebogen)
            {
                int length = ausgabe.Key.Length;
                if (length > maxLengthNamen)
                    maxLengthNamen = length;

                length = ausgabe.Value[0].Length;
                if (length > maxLengthProzent)
                    maxLengthProzent = length + 2;

                length = ausgabe.Value[1].Length;
                if (length > maxLengthEuro)
                    maxLengthEuro = length + 4;
            }

            foreach (var ausgabe in ausgabebogen)
            {
                string name = ausgabe.Key.PadRight(maxLengthNamen);
                string wertProzent = ausgabe.Value[0].PadLeft(maxLengthProzent);
                string wertEuro = ausgabe.Value[1].PadLeft(maxLengthEuro);

                tabelle.Add($"{name} | {wertProzent} | {wertEuro} |");
            }
            return tabelle;
        }
    }
}
