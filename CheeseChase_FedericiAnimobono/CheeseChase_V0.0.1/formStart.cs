using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheeseChase_V0._0._1
{
    public partial class FormStart : Form
    {
        //le cose da fare sono marchiate con un comodo commento "da fare"

        public FormStart()
        {
            InitializeComponent();
            cbDifficolta.Items.Add("Facile");
            cbDifficolta.Items.Add("Media");
            cbDifficolta.Items.Add("Difficile");
        }

        //variabili lette in questa form ma da passare nella seconda (quella di gioco)
        string nome;
        int vite;

        private void btnStart_Click(object sender, EventArgs e)
        {
            //controllo che la txtbox abbia dentro un nome e che la difficolta sia stata scelta
            if (!String.IsNullOrEmpty(txtNome.Text) && cbDifficolta.Items.Contains(cbDifficolta.Text))
            {
                nome = txtNome.Text;
                //switch per levite (difficile = 1, media = 2, facile = 3)
                switch (cbDifficolta.Text) {
                    case "Facile":
                        vite = 3;
                        break;
                    case "Media":
                        vite = 2;
                        break;
                    case "Difficile":
                        vite = 1;
                        break;
                    default:
                        break;
                }

                //apro la form partita portando via nome e difficolta sotto forma di vite inserite dal menu start
                formPartita partita = new formPartita(nome, vite);
                //nascondo FormStart
                this.Hide();
                //quando formPartita si chiude, chiude anche FormStart
                partita.FormClosed += (s, args) => this.Close(); 
                //apro formPartita
                partita.Show(); 
            }
            else
            {
                MessageBox.Show("Inserisci nome e difficoltà");
            }
        }
    }
}
