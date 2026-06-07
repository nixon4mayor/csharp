using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    internal class Utente
    {
        private string nomeUtente;
        private string cognomeUtente;
        private string etautente;

        public Utente(string nomeUtente, string cognomeUtente, string etautente)
        {
            this.nomeUtente = nomeUtente;
            this.cognomeUtente = cognomeUtente;
            this.etautente = etautente;
        }
    }
}
