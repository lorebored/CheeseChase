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
    public partial class formEnd : Form
    {
        string soldiE;
        string secondiE;
        public formEnd(int secondi, int soldi)
        {
            InitializeComponent();
            soldiE = soldi.ToString();
            secondiE = secondi.ToString();

            lblSoldi.Text = soldiE;
            lblSecondi.Text = secondiE;
        }

        private void s(object sender, EventArgs e)
        {

        }
    }
}
