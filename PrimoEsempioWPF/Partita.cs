using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimoEsempioWPF
{
    class Partita
    {
        public Giocatore Giocatore1 { set; get; }
        public Giocatore Giocatore2 { set; get; }

        public int[,] Gioco { set; get; }
        public Partita(Giocatore giocatore1, Giocatore giocatore2)
        {
            Giocatore1 = giocatore1;
            Giocatore2 = giocatore2;
            Gioco = new int[3,3];

        }
        public bool mossaGiocatore(string cordinate)
        {
            switch (cordinate)
            {
                case "A1":
                    mossa(0, 0);
                    break;
                case "A2":
                    mossa(0, 1);
                    break;
                case "A3":
                    mossa(0, 2);
                    break;
                case "B1":
                    mossa(1, 0);
                    break;
                case "B2":
                    mossa(1, 1);
                    break;
                case "B3":
                    mossa(1, 2);
                    break;
                case "C1":
                    mossa(2, 0);
                    break;
                case "C2":
                    mossa(2, 1);
                    break;
                case "C3":
                    mossa(2, 2);
                    break;
                default:
                    break;
            }
            return checkVittoria();
        }
        public void mossa(int i,int y)
        {
            if (Giocatore1.Turno)
            {
                Gioco[i, y] = 1;
            }
            else
            {
                if (Giocatore2.Turno)
                {
                    Gioco[i, y] = 2;
                }
            }
        }
       public bool checkVittoria()
        {
            for(int i = 0; i<3; i++)
            {
                if (checkRiga(i) || checkColonna(i))
                    return true;
            }
            if (checkDiagonale())
                return true;
            return false;
        }
        public bool checkRiga(int riga)
        {
            if (((Gioco[riga, 0] == 1)&&(Gioco[riga, 1]==1) && (Gioco[riga, 2] == 1)) || ((Gioco[riga,0]==2) && (Gioco[riga,1] == 2) && (Gioco[riga,2] == 2)))
                return true;
            return false;
        }
        public bool checkColonna(int colonna)
        {
            if (((Gioco[0, colonna] == 1) && (Gioco[1, colonna] == 1) && (Gioco[2, colonna] == 1)) ||((Gioco[0, colonna] == 2) && (Gioco[1,colonna] == 2) && (Gioco[2, colonna]==2)))
                return true;
            return false;
        }
        public bool checkDiagonale()
        {

            if (((Gioco[0, 0] == 1) &&( Gioco[1, 1] == 1) && (Gioco[2, 2] == 1))||((Gioco[0,0]==2) && (Gioco[1, 1] ==2) && (Gioco[2, 2]==2)))
                return true;
            if (((Gioco[2, 0] == 1)&&(Gioco[1, 1]==1) && (Gioco[0, 2]==1)) || ((Gioco[2, 0] == 2) && (Gioco[0, 2]==2) && (Gioco[1,1]==2)))
                return true;
            return false;

        }
        public void resetPartita()
        {
            Giocatore1.Turno = true;
            Giocatore2.Turno = false;
            Gioco = new int[3, 3];
        }
        public bool checkPareggio()
        {
            if (!checkVittoria())
            {
                foreach(int i in Gioco)
                {
                    if (i == 0)
                        return false;
                }
                return true;
            }
            return false;

        }
    }
}
