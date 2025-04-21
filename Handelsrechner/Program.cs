using Handelsrechner.Control;

namespace Handelsrechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainControl mainControl = new MainControl();
            mainControl.Ausfuehren();

            Environment.Exit(0);
        }
    }
}
