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

        Console.WriteLine("Qual è il tuo anno di nascita?");
        string? inputAnno = Console.ReadLine();
        int annoInt;
        int etaUtente;
        while(!int.TryParse(inputAnno, out annoInt) || annoInt < 1900 || annoInt > DateTime.Now.Year - 1)
        {
            if (annoInt == DateTime.Now.Year)
            {
                Console.WriteLine("Errore, non puoi avere 0 anni.");
            }
            else
            {
                Console.WriteLine("Errore! Devi inserire un valore tra 1900 e l'anno corrente.");
            } 
            inputAnno = Console.ReadLine();
        }
        etaUtente = (DateTime.Now.Year - annoInt);
        Console.WriteLine($"Quindi hai {etaUtente} anni.. o forse ne hai ancora {etaUtente - 1}.."); //devo inserire verifica mm e gg x calcolare l'età esatta

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
