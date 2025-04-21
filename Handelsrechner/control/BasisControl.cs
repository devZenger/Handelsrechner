using System.Diagnostics.Tracing;

namespace Handelsrechner.Control
{
    abstract class BasisControl
    {
        protected abstract string Titel { get; set; }
        protected abstract List<string> MenuListe { get; }

        protected string Fehlermeldung = "Eingabe war nicht korrekt, bitte erneut versuchen.";

        protected string AuswahlFehlermeldung = $"Fehler: auswahl konnte nicht zugeordnet werden.";
        public abstract void Ausfuehren(string auswahl);
    }
}
