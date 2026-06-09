using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using TEST;

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
        while (string.IsNullOrWhiteSpace(nickname))
        {
            Console.WriteLine("Inserisci un nickname...");
            nickname = Console.ReadLine();
        }
        Console.WriteLine($"{Saluto()} Il tuo nickname è {nickname}.");
        Conferma();
        Utente utente = new Utente("", 0, "");
        Console.Write("Parlami un po' di te... ");
        Console.WriteLine("Come ti chiami?");
        string? inputNome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputNome) || !CharOnly(inputNome))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.");
            inputNome = Console.ReadLine();
        }
        utente.NomeUtente = inputNome;
        Console.WriteLine("Quanti anni hai?");
        string? inputEta = Console.ReadLine();
        int etaInt;
        while(!int.TryParse(inputEta, out etaInt))
        {
            Console.WriteLine("Errore! Devi inserire un numero intero per l'età.");
            inputEta = Console.ReadLine();
        }
        utente.EtaUtente = etaInt;
        Console.WriteLine("Da dove vieni?");
        string? inputCitta = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputCitta) || !CharOnly(inputCitta))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.");
            inputCitta = Console.ReadLine();
        }
        utente.CittaUtente = inputCitta;
        Console.WriteLine($"Bene, quindi ti chiami {utente.NomeUtente}, hai {utente.EtaUtente} anni e vieni da {utente.CittaUtente}.");







        /*Console.WriteLine("Abbiamo finito! Premi un tasto qualsiasi per uscire...");
        Console.ReadKey();*/



    }
    static public string Saluto()
    {
        if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 12)
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
        Console.WriteLine("Vuoi proseguire? Premi Y o N per rispondere.");
        ConsoleKeyInfo conferma = Console.ReadKey(true);
        if (conferma.Key == ConsoleKey.Y || conferma.Key == ConsoleKey.N)
        {
            switch (conferma.Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("Hai scelto di proseguire.");
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("Hai scelto di terminare.");
                    Environment.Exit(0);
                    break;
            }
        }
        else
        {
            while (conferma.Key != ConsoleKey.Y && conferma.Key != ConsoleKey.N)
            {
                Console.WriteLine("Errore! Premi Y o N.");
                conferma = Console.ReadKey(true);
                switch (conferma.Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Hai scelto di proseguire.");
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Hai scelto di terminare.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
    static bool CharOnly(string testo)
    {
        foreach (char c in testo)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }
    //static public void IndovinaNumero()
}
