using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    internal class Utente
    {
        private string nomeUtente;
        private int etautente;
        private string cittaUtente;

        public Utente(string nomeUtente, int etautente, string cittaUtente)
        {
            this.nomeUtente = nomeUtente;
            this.etautente = etautente;
            this.cittaUtente = cittaUtente;
        }
        public string NomeUtente
        {
            get { return nomeUtente; }
            set { nomeUtente = value; }
        }
        public int EtaUtente
        {
            get { return etautente; }
            set { etautente = value; }
        }
        public string CittaUtente
        {
            get { return cittaUtente; }
            set { cittaUtente = value; }
        }
    }
}
