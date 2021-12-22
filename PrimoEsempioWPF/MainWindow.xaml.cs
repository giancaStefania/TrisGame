using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimoEsempioWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Partita p = new Partita(new Giocatore("Michele", true), new Giocatore("Antonio", false));
        public MainWindow()
        {
            
            InitializeComponent();
            Resources["scrittaGiocatore"] = "Turno di: Giocatore1";


        }
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
            
        }
        private void cambiaCella(object sender, RoutedEventArgs e)
        {
            Button t;
            t = sender as Button;
            //Controlla che il bottone che clicca non sia già stato riempito precedentemente
            if (t.Content == null)
            {
                //Logica turno giocatore 1
                if (p.Giocatore1.Turno)
                {
                    t.Content = "X";

                    if (p.mossaGiocatore(t.Name))
                    {
                        MessageBox.Show("Hai vinto Giocatore1!!!!!!!!");
                        MessageBox.Show("Clicca ok per iniziare una nuova partita!");
                        p.resetPartita();
                        resetGioco();
                    }
                    else
                    {
                        if (p.checkPareggio())
                        {
                            MessageBox.Show("Pareggio!! Clicca ok per una nuova partita!");
                            p.resetPartita();
                            resetGioco();
                        }
                        else
                        {
                            p.Giocatore1.Turno = false;
                            p.Giocatore2.Turno = true;
                            Resources["scrittaGiocatore"] = "Turno di: Giocatore2";
                        }
                    }


                }
                else
                {
                    //Logica turno Giocatore 2
                    if (p.Giocatore2.Turno)
                    {
                        t.Content = "O";
                        if (p.mossaGiocatore(t.Name))
                        {
                            MessageBox.Show("Hai vinto Giocatore2!!!!!!!!");
                            MessageBox.Show("Clicca ok per iniziare una nuova partita!");
                            p.resetPartita();
                            resetGioco();
                        }
                        else
                        {
                            if (p.checkPareggio())
                            {
                                MessageBox.Show("Pareggio!! Clicca ok per una nuova partita!");
                                p.resetPartita();
                                resetGioco();
                            }
                            else
                            {
                                p.Giocatore2.Turno = false;
                                p.Giocatore1.Turno = true;
                                Resources["scrittaGiocatore"] = "Turno di: Giocatore1";
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Non puoi cliccare la casella è già stata usata!");
            }

        }
        private void resetGioco()
        {
            A1.Content = null;
            A2.Content = null;
            A3.Content = null;
            B1.Content = null;
            B2.Content = null;
            B3.Content = null;
            C1.Content = null;
            C2.Content = null;
            C3.Content = null;
            Resources["scrittaGiocatore"] = "Turno di: Giocatore1";
        }
    }
}
