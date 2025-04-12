using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handelsrechner.service
{
    internal class Eigenschaften
    {
        public bool VersuchSetzen(object objekt, string eigenschaft, string wert)
        {
            try
            {
                var property = objekt.GetType().GetProperty(eigenschaft);
                if (property != null && property.CanWrite)
                {
                    object value = Convert.ChangeType(wert, property.PropertyType);
                    property.SetValue(objekt, value);
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public object lese (object objekt, string eigenschaft)
        {
            var property = objekt.GetType().GetProperty(eigenschaft);
            if (property != null)
            {
                return property.GetValue(objekt);
            }
            else
            {
                throw new Exception($"Eigenschaft {eigenschaft} nicht gefunden.");
            }
        }


    }
}
