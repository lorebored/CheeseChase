using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CheeseChase_V0._0._1
{
    //enum che contiene tutti i possibili stati di un cliente
    public enum statoCliente
    {
        INVISIBIE, //quando non è visibile
        ATTIVO, //quando sta aspettando di ricevere il suo ordine
        ARRABBIATO, //quando sono passati 15 secondi dal suo arrivo
        FATTO //quando l'ordine è stato completato
    }

    public partial class formPartita : Form
    {
        //array per gli ingredienti del panino
        //4 sono gli ingredienti
        bool[] paninoPrep = new bool[4];
        //array che contiene la richiesta del cliente
        bool[] paninoReq = new bool[4];
        //didascalia:
        //pos 0: carne cotta
        //pos 1: formaggio
        //pos 2: pomodori
        //pos 3: insalata

        //g sta per gioco per indicare che sono diverse da quelle passate dal menu start
        int viteG; 
        string nomeG;
        //variabile che conta i secondi totali della partita
        int secondi = 0;
        //variabile che conta la presenza del cliente in secondi per misurare la sua arrabbiatura o meno
        int secondiCliente1;
        int secondiCliente2;
        //permette di condire con gli ingredienti solo se è true
        bool paninoAperto = false;
        //variabili abbastanza autoesplicatie
        int soldi = 0;
        const int VALORE_PANINI = 10; //un panino venduto vale 10 euro
        //variabile utile per il controllo pre servizio dei clienti
        bool paninoCompletato = false;
        //variabile per lo spostamento pulito della policecar (contiene la sua x)
        int timerPoliziaMacchina = 144;

        //array delle fette di carne 
        bool[] carne = new bool[3];

        //indica il cliente attivo, 0 = nessun cliente attivo
        int clienteAttivo = 0;  

        //entrambi i clienti partono come invisibii
        statoCliente statoCliente1 = statoCliente.INVISIBIE;
        statoCliente statoCliente2 = statoCliente.INVISIBIE;

        //variabile che contiene lo stato della serranda: true significa che è aperta 
        bool serrandaAperta = true;

        public formPartita(string nome, int vite)
        {
            InitializeComponent();
            //"importazione" variabili dalla form del menu di start
            viteG = vite;
            nomeG = nome;
            lblVite.Text = viteG.ToString();
            lblNome.Text = nomeG;

            //nascondo gli elementi che non servono all'inizio
            pbCarneCotta1.Hide();
            pbCarneCotta2.Hide();
            pbCarneCotta3.Hide();

            pbCarneCrudaGriglia1.Hide();
            pbCarneCrudaGriglia2.Hide();
            pbCarneCrudaGriglia3.Hide();

            pbPaninoCorrente.Hide();
            pbPaninoCorrenteSopra.Hide();

            //nascondo i clienti 
            pbCliente1.Hide();
            //contiene i secondi che aspetta il cliente 1, sopra a 15 si arrabbia e a 30 va via e perde una vita il giocatore
            secondiCliente1 = 0; 

            pbCliente2.Hide();
            secondiCliente2 = 0;

            //nascondi vignette clienti
            pbReq1.Hide();
            pbReq2.Hide();

            //avvia il timer che ticka ogni 1000ms
            scandisciSecondi.Enabled = true;
        }

        //mostra custom message box che sarebbero in realtà grafiche fatte da noi
        private void mostraCustomMbox(int cmb, int waitTime)
        {
            //cmb sta per custom messagebox, in base al numero se ne mostra una certa, waitTime sta per il tempo che sta "mbox" rimane attiva
            switch (cmb)
            {
                case 1:
                    pbCustomMessageBox.Image = global::CheeseChase_V0._0._1.Properties.Resources.MBIngredientiSbagliati;
                    pbCustomMessageBox.Show();
                    pbCustomMessageBox.Refresh(); // forza ridisegno
                    Application.DoEvents();       // forza la gestione degli eventi della UI
                    Thread.Sleep(waitTime);       // blocco il programma per far leggere il messaggio all'utente
                    pbCustomMessageBox.Hide();
                    break;
                case 2:
                    pbCustomMessageBox.Image = global::CheeseChase_V0._0._1.Properties.Resources.MBCarneFormaggio;
                    pbCustomMessageBox.Show();
                    pbCustomMessageBox.Refresh(); // forza ridisegno
                    Application.DoEvents();       // forza la gestione degli eventi della UI
                    Thread.Sleep(waitTime);       // blocco il programma per far leggere il messaggio all'utente
                    pbCustomMessageBox.Hide();
                    break;

                default:
                    break;
            }
        }

        //procedura per diminuire le vite CONTIENE IL CONTROLLO PER VEDERE SE LE VITE SONO FINITE
        private void diminuisciVite()
        {
            viteG--;
            lblVite.Text = viteG.ToString();
            if (viteG < 1)
                terminaPartita();
        }

        private void generaOrdine()
        {
            //genera un random per i casi del panino
            Random R = new Random();
            int random = R.Next(1, 4);

            //in base al numero generato scegliamo una combinazione di ingredienti
            //formaggio e carne cotta stanno su tutti

            switch (random)
            {
                case 1:
                    //panino formaggio e carne
                    paninoReq[0] = true;
                    paninoReq[1] = true;
                    paninoReq[2] = false;
                    paninoReq[3] = false;
                    //In base al cliente, mostro l'ordine generato
                    if (clienteAttivo == 1)
                    {
                        pbReq1.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqFC;
                        pbReq1.Show();
                    }
                    else
                    {
                        pbReq2.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqFC;
                        pbReq2.Show();
                    }
                    break;

                case 2:
                    //panino formaggio e carne e pomodori
                    paninoReq[0] = true;
                    paninoReq[1] = true;
                    paninoReq[2] = true;
                    paninoReq[3] = false;
                    //In base al cliente, mostro l'ordine generato
                    if (clienteAttivo == 1)
                    {
                        pbReq1.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqFCP;
                        pbReq1.Show();
                    }
                    else
                    {
                        pbReq2.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqFCP;
                        pbReq2.Show();
                    }
                    break;

                case 3:
                    //panino formaggio e carne e pomodori e insalata
                    paninoReq[0] = true;
                    paninoReq[1] = true;
                    paninoReq[2] = true;
                    paninoReq[3] = true;
                    //In base al cliente, mostro l'ordine generato
                    if (clienteAttivo == 1)
                    {
                        pbReq1.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqIFCP;
                        pbReq1.Show();
                    }
                    else
                    {
                        pbReq2.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqIFCP;
                        pbReq2.Show();
                    }
                    break;

                case 4:
                    //panino formaggio e carne e insalata
                    paninoReq[0] = true;
                    paninoReq[1] = true;
                    paninoReq[2] = false;
                    paninoReq[3] = true;
                    //In base al cliente, mostro l'ordine generato
                    if (clienteAttivo == 1)
                    {
                        pbReq1.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqIFC;
                        pbReq1.Show();
                    }
                    else
                    {
                        pbReq2.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoReqIFC;
                        pbReq2.Show();
                    }
                    break;

                default:
                    break;
            }           
        }

        private void terminaPartita()
        {
            scandisciSecondi.Stop();
            //apro la form end
            formEnd end = new formEnd(secondi, soldi);
            //nascondo FormPartita
            this.Hide();
            //quando formPartita si chiude, chiude anche FormEnd
            end.FormClosed += (s, args) => this.Close();
            //apro formEnd
            end.Show();
        }

        //timer che ticka ogni 1000ms
        private void scandisciSecondi_Tick(object sender, EventArgs e)
        {
            //controlla che la serranda sia aperta e che non ci sia la polizia
            if (serrandaAperta && !pbMacchinaPolizia.Visible)
            {
                //incrementa il contatore dei secondi
                secondi++; 
                //eventualmente fa arrivare un cliente
                if (secondi % 5 == 0)
                {
                    Random R = new Random(secondi);

                    //forse faccio apparire la polizia 
                    int numeroCasualePerGenerarePolizia = R.Next(1, 99999);
                    if (numeroCasualePerGenerarePolizia % 10 == 0)
                    {
                        arrivoPoliziaSmooth();                        
                    }

                    if (!pbMacchinaPolizia.Visible)
                    {
                        int numeroCasualePerGenerareCliente = R.Next(1, 99999);

                        //variabile aggiornata con l'enum solo se passa il controllo
                        clienteAttivo = 0;

                        //se è un numero pari e non c'è nessun cliente mostro il 1, altrimenti il 2
                        if (statoCliente1 == statoCliente.INVISIBIE && statoCliente2 == statoCliente.INVISIBIE)
                        {
                            if (numeroCasualePerGenerareCliente % 2 == 0)
                            {
                                statoCliente1 = statoCliente.ATTIVO;
                                clienteAttivo = 1;
                                pbCliente1.Show();
                                generaOrdine();
                            }
                            else
                            {
                                statoCliente2 = statoCliente.ATTIVO;
                                clienteAttivo = 2;
                                pbCliente2.Show();
                                generaOrdine();
                            }
                        }
                    }

                    if (statoCliente1 == statoCliente.ATTIVO || statoCliente1 == statoCliente.ARRABBIATO)
                    {
                        //aumenta i secondi e controlla se è arrabbiato o se ne va
                        secondiCliente1++;
                        if (secondiCliente1 == 3 && statoCliente1 == statoCliente.ATTIVO)
                        {
                            //braca si arrabbia
                            statoCliente1 = statoCliente.ARRABBIATO;
                            pbCliente1.Image = global::CheeseChase_V0._0._1.Properties.Resources.ClienteBracaArrabbiato;
                        }
                        if (secondiCliente1 == 7 && statoCliente1 == statoCliente.ARRABBIATO)
                        {
                            //braca si arrabbia tantissimo
                            pbCliente1.Image = global::CheeseChase_V0._0._1.Properties.Resources.ClienteBracaFurioso;
                        }
                        if (secondiCliente1 == 10)
                        {
                            clientiVannoVia();
                            diminuisciVite();
                        }

                    }

                    if (statoCliente2 == statoCliente.ATTIVO || statoCliente2 == statoCliente.ARRABBIATO)
                    {
                        //aumenta i secondi e controlla se è arrabbiato o se ne va
                        secondiCliente2++;
                        if (secondiCliente2 == 3)
                        {
                            statoCliente2 = statoCliente.ARRABBIATO;
                            pbCliente2.Image = global::CheeseChase_V0._0._1.Properties.Resources.Cliente2Arrabbiato;
                        }
                        if (secondiCliente2 == 10)
                        {
                            clientiVannoVia();
                            diminuisciVite();
                        }
                    }
                }
            }
        }

        /*Metodo asincrono che gestisce l'aggiunta di carne cruda sulla griglia al clic del giocatore.
          In base al numero di pezzi già presenti, mostra la carne cruda in una delle tre posizioni disponibili.
          Dopo aver posizionato la carne, attende 5 secondi per simulare il tempo di cottura.
          La parola chiave "async" consente di eseguire operazioni asincrone, come "await Task.Delay",
          senza bloccare il thread principale (UI thread). In questo modo l'interfaccia utente rimane fluida e reattiva
          durante l'attesa, permettendo ad esempio ai clienti di continuare ad arrivare o ad altri eventi di verificarsi. */
        private async void pbPilaCarneCruda_Click(object sender, EventArgs e)       
        {
            if (!carne[0])
            {
                //mostro la carne cruda sulla griglia
                pbCarneCrudaGriglia1.Show();    
                //aggiorno l'array
                carne[0] = true;
                //delay di 5 secondi prima di passare dalla carne cruda a cotta
                await Task.Delay(5000);
                //l'immagine della carne cruda viene tolta e si ha quella cotta
                pbCarneCrudaGriglia1.Hide();            
                pbCarneCotta1.Show();
            }
            else if (!carne[1])
            {
                pbCarneCrudaGriglia2.Show();
                carne[1] = true;
                await Task.Delay(5000);
                pbCarneCrudaGriglia2.Hide();
                pbCarneCotta2.Show();
            }
            else if (!carne[2])
            {
                pbCarneCrudaGriglia3.Show();
                carne[2] = true;
                await Task.Delay(5000);
                pbCarneCrudaGriglia3.Hide();
                pbCarneCotta3.Show();
            }
            
        }

        private void pbPilaPane_Click(object sender, EventArgs e)
        {
            //mostra il pane solo se non è gia mostrato
            if (!paninoAperto)
            {
                pbPaninoCorrente.Show();
                pbPaninoCorrenteSopra.Show();
                paninoAperto = true;
            }
        }

        private void pbCestino_Click(object sender, EventArgs e)
        {
            //il pane non c'è piu quindi la variabile per il controllo viene messa a false
            paninoAperto = false;
            //resetta l'array panino preparazione
            for (int i = 0; i < 4; i++)
            {
                paninoPrep[i] = false;
            }
            //nasconde il pane aperto
            pbPaninoCorrenteSopra.Hide();
            pbPaninoCorrente.Hide();
            //rimette l'immagine iniziale del pane
            pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.SottoPane;
            //reset variabile bool
            paninoCompletato = false;
        }

        //qua dentro c'è la dinamica del "servizio" dei panini tramite click sul panino pronto
        private void pbPaninoCorrente_Click(object sender, EventArgs e)
        {
            //controllo che il panino sia completo, ovvero se l'immagine corrisponde a uno dei 4 possibili panini completi
            if (paninoCompletato)
            {
                //controllo che il panino completo corrisponda alla richiesta del cliente, sennò mando una mbox (vero fino a prova contraria)
                bool controlloPaninoCorrispondente = true; 
                for (int i = 0; i < 4; i++) 
                {
                    //se trovo un ingrediente che non corrisponde vuoldire che il panino rpeparato è sbagliato e mando una mbox
                    if (paninoReq[i] != paninoPrep[i])
                    {
                        //se gli ingredienti non corrispondono, metto i controllo a falso ed esco dal for
                        controlloPaninoCorrispondente = false;
                        break;
                    }
                }

                //avviene il servizio, quindi non c'è piu nessun panino sul bancone (dato che viene venduto al cliente)
                paninoAperto = false;
                //resetta l'array panino preparazione e req
                for (int i = 0; i < 4; i++)
                {
                    paninoPrep[i] = false;
                    paninoReq[i] = false;
                }
                //nasconde il pane aperto
                pbPaninoCorrenteSopra.Hide();
                pbPaninoCorrente.Hide();
                //rimette l'immagine iniziale del pane
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.SottoPane;
                //nasconde il cliente attivo
                clientiVannoVia();
                //reset controllo
                paninoCompletato = false;

                if (controlloPaninoCorrispondente)
                {
                    //se il  panino è giusto riceve il pagamento
                    soldi += VALORE_PANINI;
                    //aggiorno label denaro
                    lblSoldi.Text = soldi.ToString();
                }
                else
                {
                    //se ilpanino è sbagliato tolgo 1 vita e lo indzo al giocatore con una mbox custom
                    mostraCustomMbox(1, 2000);
                    diminuisciVite();
                }
            }

        }
        private void clientiVannoVia()
        {
            //se ci sono clienti li nasconde 
            if (statoCliente1 == statoCliente.ATTIVO || statoCliente1 == statoCliente.ARRABBIATO)
            {
                //nascondo cliente ed ordine
                pbCliente1.Hide();
                pbReq1.Hide();
            }

            if (statoCliente2 == statoCliente.ATTIVO || statoCliente2 == statoCliente.ARRABBIATO)
            {
                //nascondo cliente ed ordine
                pbCliente2.Hide();
                pbReq2.Hide();
            }

            //resetta la dinamica dei clienti 
            statoCliente1 = statoCliente.INVISIBIE;
            statoCliente2 = statoCliente.INVISIBIE;
            secondiCliente1 = 0;
            secondiCliente2 = 0;

            //aggiorno variabile del cliente attivo a 0 visto che nessuno è attivo
            clienteAttivo = 0;

            //ritorniamo i clienti tranquilli (verbo coniato al sud)
            pbCliente2.Image = global::CheeseChase_V0._0._1.Properties.Resources.Cliente2Tranquillo;
            pbCliente1.Image = global::CheeseChase_V0._0._1.Properties.Resources.ClienteBracaTranquillo;
        }

        //Bottone che gestisce la serranda
        private void pbBottoneSerranda_Click(object sender, EventArgs e)
        {
            //se è aperta la chiudo e viceversa
            if (serrandaAperta)
            {
                //metto la pic della serranda chiusa
                this.BackgroundImage = Properties.Resources.gioco_serrandaChiusa;
                clientiVannoVia(); 
                //e se c'è la polizia la manda via (evasione fiscale)
                if (pbMacchinaPolizia.Visible)
                {
                    poliziaVaVia();
                }
            }
            else
            {
                //metto la pic della serranda aperta (apre la serranda)
                this.BackgroundImage = Properties.Resources.gioco_serrandaAperta;
            }
            //cambio lo stato della serranda
            serrandaAperta = !serrandaAperta;
        }


        //dentro tutte ste procedure dei click si aggiorna solo l'array e si chiama la funzione visualizza panino grafica
        //ovviamente il panino viene condito solo se è aperto (controllo iniziale)
        private void pbPilaPomodoro_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato)
            {
                paninoPrep[2] = true;
                visualizzaPaninoGrafica();
            }

        }
        private void pbPilaInsalata_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato)
            {
                paninoPrep[3] = true;
                visualizzaPaninoGrafica();
            }
        }
        private void pbPilaFormaggio_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato)
            {
                paninoPrep[1] = true;
                visualizzaPaninoGrafica();
            }
        }

        private void pbCarneCotta1_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato && !paninoPrep[0])
            {
                paninoPrep[0] = true;
                visualizzaPaninoGrafica();
                pbCarneCotta1.Hide();
                carne[0] = false;
            }

        }
        private void pbCarneCotta2_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato && !paninoPrep[0])
            {
                paninoPrep[0] = true;
                visualizzaPaninoGrafica();
                pbCarneCotta2.Hide();
                carne[1] = false;
            }


        }
        private void pbCarneCotta3_Click(object sender, EventArgs e)
        {
            if (paninoAperto && !paninoCompletato && !paninoPrep[0])
            {
                paninoPrep[0] = true;
                visualizzaPaninoGrafica();
                pbCarneCotta3.Hide();
                carne[2] = false;
              
            }

        }

        private void visualizzaPaninoGrafica()
        {
            bool carne = paninoPrep[0];
            bool formaggio = paninoPrep[1];
            bool pomodoro = paninoPrep[2];
            bool insalata = paninoPrep[3];

            if (carne && !formaggio && !pomodoro && !insalata)
            {
                // Solo carne
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoC;
            }
            else if (!carne && formaggio && !pomodoro && !insalata)
            {
                // Solo formaggio
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoF;
            }
            else if (!carne && !formaggio && pomodoro && !insalata)
            {
                // Solo pomodoro
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoP;
            }
            else if (!carne && !formaggio && !pomodoro && insalata)
            {
                // Solo insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoI;
            }
            else if (carne && formaggio && !pomodoro && !insalata)
            {
                // Carne + formaggio
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoFC;
            }
            else if (carne && !formaggio && pomodoro && !insalata)
            {
                // Carne + pomodoro
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoCP;
            }
            else if (carne && !formaggio && !pomodoro && insalata)
            {
                // Carne + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIC;
            }
            else if (!carne && formaggio && pomodoro && !insalata)
            {
                // Formaggio + pomodoro
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoFP;
            }
            else if (!carne && formaggio && !pomodoro && insalata)
            {
                // Formaggio + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIF;
            }
            else if (!carne && !formaggio && pomodoro && insalata)
            {
                // Pomodoro + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIP;
            }
            else if (carne && formaggio && pomodoro && !insalata)
            {
                // Carne + formaggio + pomodoro
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoFCP;
            }
            else if (carne && formaggio && !pomodoro && insalata)
            {
                // Carne + formaggio + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIFC;
            }
            else if (carne && !formaggio && pomodoro && insalata)
            {
                // Carne + pomodoro + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoICP;
            }
            else if (!carne && formaggio && pomodoro && insalata)
            {
                // Formaggio + pomodoro + insalata
               pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIFP;
            }
            else if (carne && formaggio && pomodoro && insalata)
            {
                // Carne + formaggio + pomodoro + insalata
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoIFCP;
            }
        }

        private void pbPaninoCorrenteSopra_Click(object sender, EventArgs e)
        {
            //trasferisco dall'array dentro delle bool locali per comodità e leggibilità del codice 
            bool carne = paninoPrep[0];
            bool formaggio = paninoPrep[1];
            bool pomodoro = paninoPrep[2];
            bool insalata = paninoPrep[3];

            //in base agli ingredienti faccio venire fuori il panino giusto
            if (carne && pomodoro && insalata && formaggio)
            {
                pbPaninoCorrenteSopra.Hide();
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoCompletoIFCP;
                paninoCompletato = true;
            } else if (carne && formaggio && !insalata && !pomodoro)
            {
                pbPaninoCorrenteSopra.Hide();
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoCompletoFC;
                paninoCompletato = true;
            }
            else if (carne && formaggio && !insalata && pomodoro)
            {
                pbPaninoCorrenteSopra.Hide();
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoCompletoFCP;
                paninoCompletato = true;
            }
            else if (carne && formaggio && insalata && !pomodoro)
            {
                pbPaninoCorrenteSopra.Hide();
                pbPaninoCorrente.Image = global::CheeseChase_V0._0._1.Properties.Resources.paninoCompletoIFC;
                paninoCompletato = true;
            }
            else
            {
                //Inserire minimo carne e formaggio
                mostraCustomMbox(2, 2000);
            }
        }

        private void timerPolizia_Tick(object sender, EventArgs e)
        {
            //controllo se la macchina della polizia ha ancora strada da percorrere (ovvero se sta alla posizione x < 760)
            if (timerPoliziaMacchina < 760)
            {
                //sposto la macchina della polizia verso destra 
                pbMacchinaPolizia.Location = new Point(timerPoliziaMacchina, 219);

                //avanzo di 10pixel ogni tick rendendo il movimento "smooth" (tra virgolette perchè nelle winform c'è davvero poco di smooth)
                timerPoliziaMacchina += 40;
            }
            else
            {
                //quando la macchina ha raggiunto o superato la posizione 760, scende lo sbirro dall'auto
                clientiVannoVia(); // I clienti presenti nella scena vengono rimossi o fanno le animazioni per andarsene

                //se la serranda è aperta e non ci sono clienti attivi
                if (serrandaAperta && clienteAttivo == 0)
                {
                    //se il poliziotto non è ancora visibile, lo mostriamo insieme alla barra
                    if (!pbPoliziotto.Visible)
                    {
                        pbPoliziotto.Show();              
                        pbPoliziaCounter.Show();
                        //porto la barra in primo piano rispetto agli altri elementi grafici
                        pbPoliziaCounter.BringToFront();  
                    }

                    //diminuisco progressivamente la barra del poliziotto
                    if (pbPoliziaCounter.Width > 0)
                    {
                        pbPoliziaCounter.Width -= 10; 
                    }
                    else
                    {
                        //se la barra è arrivata a 0 o meno, significa che il tempo è scaduto e il poliziotto te le suona
                        timerPolizia.Stop();
                        terminaPartita();
                    }
                }
            }
        }

        private void poliziaVaVia()
        {
            //nascondo le grafiche della polizia e resetto la progressbar
            pbMacchinaPolizia.Hide();
            pbPoliziaCounter.Hide();
            pbPoliziotto.Hide();
            pbPoliziaCounter.Width = 200;
            //stoppo il timer dedicato
            timerPolizia.Stop();
            //resetto il timer al suo valore iniziale
            timerPoliziaMacchina = 144;
            //ri metto la macchina dove stava
            pbMacchinaPolizia.Location = new Point(timerPoliziaMacchina, 219);
        }

        private void arrivoPoliziaSmooth()
        {
            clientiVannoVia();
            timerPolizia.Start();
            pbMacchinaPolizia.Show();
        }
    }
}          