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
        Console.WriteLine($"{Saluto()} Benvenuto nel programma!\nParlami un po' di te... Come ti chiami?");
        string? inputNome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputNome) || !CharOnly(inputNome))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.");
            inputNome = Console.ReadLine();
        }
        Console.WriteLine("Quanti anni hai?");
        string? inputEta = Console.ReadLine();
        int etaInt;
        while(!int.TryParse(inputEta, out etaInt))
        {
            Console.WriteLine("Errore! Devi inserire un numero intero per l'età.");
            inputEta = Console.ReadLine();
        }
        Console.WriteLine("Da dove vieni?");
        string? inputCitta = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputCitta) || !CharOnly(inputCitta))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.");
            inputCitta = Console.ReadLine();
        }
        Utente utente = new Utente(inputNome, etaInt, inputCitta);
        utente.Presentazione();
        utente.SceltaNickname();
        Console.WriteLine($"Da ora in poi sarai {utente.NicknameUtente}.\nVuoi proseguire?");
        Conferma();

        Console.ReadKey();
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
        Console.WriteLine("Premi Y o N per rispondere.");
        ConsoleKeyInfo conferma = Console.ReadKey(true);
        if (conferma.Key == ConsoleKey.Y || conferma.Key == ConsoleKey.N)
        {
            switch (conferma.Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("Hai scelto di proseguire.");
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("Hai scelto di terminare. Il programma verrà chiuso.");
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
                        Console.WriteLine("Hai scelto di terminare. Il programma verrà chiuso.");
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
