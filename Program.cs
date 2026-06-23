using Microsoft.VisualBasic;
using TEST;

internal class Program
{
    static void Main(string[] args)
    {
        Password();
        Console.WriteLine($"Hai effettuato l'accesso alle ore {DateTime.Now.ToShortTimeString()} del {DateTime.Now.ToShortDateString()}.");

        Console.WriteLine($"{Saluto()} Benvenuto nel programma!\nParlami un po' di te... Come ti chiami?");
        string? inputNome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputNome) || !CharOnly(inputNome))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.");
            inputNome = Console.ReadLine();
        }

        Console.WriteLine("Qual è la tua data di nascita? (Formato GG/MM/AAAA)");
        string? inputData = Console.ReadLine();
        DateTime dataNascita;
        while (!DateTime.TryParse(inputData, out dataNascita) || dataNascita.Year < 1900 || dataNascita > DateTime.Now)
        {
            if (dataNascita.Year == DateTime.Now.Year && dataNascita > DateTime.Now)
            {
                Console.WriteLine("Errore, non puoi essere nato nel futuro.");
            }
            else
            {
                Console.WriteLine("Errore! Inserisci una data valida in formato GG/MM/AAAA (dal 1900 a oggi).");
            }
            inputData = Console.ReadLine();
        }
        int etaUtente = DateTime.Now.Year - dataNascita.Year;
        if (DateTime.Now.Month < dataNascita.Month || (DateTime.Now.Month == dataNascita.Month && DateTime.Now.Day < dataNascita.Day))
        {
            etaUtente--;
        }
        Console.WriteLine($"Quindi hai {etaUtente} anni.");

        Console.WriteLine("Da dove vieni?");
        string? inputCitta = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(inputCitta) || !CharOnly(inputCitta))
        {
            Console.WriteLine("Errore! Devi usare solo lettere dell'alfabeto.\n(Se il nome della città contiene apostrofi, usare gli spazi al loro posto)");
            inputCitta = Console.ReadLine();
        }

        Utente utente = new Utente(inputNome, etaUtente, inputCitta);
        utente.Presentazione();
        utente.SceltaNickname();
        Console.WriteLine($"Da ora in poi sarai {utente.NicknameUtente}.\nVuoi proseguire?");
        Conferma();


        Console.ReadKey();
    }

    //creare hashtable per salvare dati utenti, in modo da poterli recuperare in futuro e magari creare un sistema di login più complesso

    //creare hashtable con colori e associarli a determinate parole, utente deve scegliere




    static private void Password()
    {
        Console.WriteLine("Inserisci la password:");
        string? password = null;
        password = Console.ReadLine();
        while (password != "1234")
        {
            Console.WriteLine("Password errata! Riprova.");
            password = Console.ReadLine();
        }
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
    //static public void IndovinaNumero() devo creare un gioco in cui l'utente deve indovinare un numero da 1 a 100
    //con un numero limitato di tentativi e con suggerimenti se il numero è troppo alto o troppo basso
}
