using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handelsrechner.control
{    
    abstract class BasisControl
    {
        protected string Fehlermeldung = "Eingabe war nicht korrekt, bitte erneut versuchen.";
        public abstract void ausfuehren();
    }
}
