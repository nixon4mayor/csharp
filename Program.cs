using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci la password:");
        string? password = null;
        password = Console.ReadLine();
        while (password != "1234")
        {
            Console.WriteLine("Password errata! Riprova.");
            password = Console.ReadLine();
        }
        Console.WriteLine($"Hai effettuato l'accesso alle ore {DateTime.Now.ToShortTimeString()} del {DateTime.Now.ToShortDateString()}.");
        string? nickname = null;
        while (nickname == null)
        {
            Console.WriteLine("Inserisci il tuo nickname...");
            nickname = Console.ReadLine();
        }
        Console.WriteLine($"{Saluto()} Il tuo nickname è {nickname}.");
        Conferma();
        //Console.WriteLine("Andiamo avanti.");




    }
    static public string Saluto()
    {
        if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 12)
        {
            return "Buongiorno!";
        }
        else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 18)
        {
            return "Buon pomeriggio!";
        }
        else
        {
            return "Buonasera!";
        }
    }   
    static public void Conferma()
    {
        Console.WriteLine("Vuoi proseguire? Usa Y o N per rispondere.");
        string? conferma = Console.ReadLine();
        if (conferma == "y" || conferma == "n")
        {
            switch (conferma)
            {
                case "y":
                    Console.WriteLine("Hai scelto di proseguire.");
                    break;
                case "n":
                    Console.WriteLine("Hai scelto di terminare.");
                    Environment.Exit(0);
                    break;
            }
        }
        else if (conferma == null)
        {
            while (conferma == null)
            {
                Console.WriteLine("Errore! Devi usare Y o N");
                conferma = Console.ReadLine();
                switch (conferma)
                {
                    case "y":
                        Console.WriteLine("Hai scelto di proseguire.");
                        break;
                    case "n":
                        Console.WriteLine("Hai scelto di terminare.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
        else
        {
            while (conferma != "y" && conferma != "n")
            {
                Console.WriteLine("Errore! Devi usare Y o N.");
                conferma = Console.ReadLine();
                switch (conferma)
                {
                    case "y":
                        Console.WriteLine("Hai scelto di proseguire.");
                        break;
                    case "n":
                        Console.WriteLine("Hai scelto di terminare.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
