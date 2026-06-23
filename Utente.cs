using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    internal class Utente
    {
        public string NomeUtente { get; init; }
        public int EtaUtente { get; init; }
        public string CittaUtente { get; init; }
        public string? NicknameUtente { get; private set; }

        public Utente(string nome, int eta, string citta)
        {
            NomeUtente = nome;
            EtaUtente = eta;
            CittaUtente = citta;
        }
        public string statusEta => EtaUtente >= 18 ? "maggiorenne" : "minorenne";







        public string SceltaNickname()
        {
        string? nickname = null;
        while (string.IsNullOrWhiteSpace(nickname))
        {
            Console.WriteLine($"Bene {NomeUtente}, inserisci un nickname...");
            nickname = Console.ReadLine();
        }
            this.NicknameUtente = nickname;
            return nickname;
        }


        public void Presentazione()
        {
            Console.Write($"Mi chiamo {NomeUtente} e vengo da {CittaUtente}, ho {EtaUtente} anni ed essendo {statusEta} ");
            if (EtaUtente >= 18)
            {
                Console.WriteLine("posso procedere.");
            }
            else
            {
                Console.WriteLine("non posso procedere.\nIl programma verrà terminato.");
                Environment.Exit(0);
            }

        }
    }
}
