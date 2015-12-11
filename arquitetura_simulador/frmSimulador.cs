using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arquitetura_simulador
{
    public partial class frmSimulador : Form
    {
        public frmSimulador()
        {
            InitializeComponent();
            controlePictures();
        }

        private void controlePictures()
        {
            picPC.Visible = false;
            picMemoria0.Visible = false;
            picMemoria1.Visible = false;
            picMemoria2.Visible = false;
            picMemoria3.Visible = false;
            picBusca.Visible = false;
            picDecodInst.Visible = false;
            picDecodOpe1.Visible = false;
            picDecodOpe2.Visible = false;
            picExec.Visible = false;
            picULAResultado.Visible = false;
            picULAStatus.Visible = false;
        }
    }
}
