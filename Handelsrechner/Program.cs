using Handelsrechner.control;

namespace Handelsrechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MainControl mainControl = new MainControl();
            mainControl.ausfuehren();

            Environment.Exit(0);
        }
    }
}
