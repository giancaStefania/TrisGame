using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimoEsempioWPF
{
    class Giocatore
    {
        public string NomeGiocatore { set; get; }
        public bool Turno { set; get; }
        public Giocatore(string nomeGiocatore, bool turno)
        {
            NomeGiocatore = nomeGiocatore;
            Turno = turno;
        }
    }
}
