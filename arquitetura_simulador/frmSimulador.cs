using System;
using System.Collections;
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
        PC pc = new PC();
        Memoria memoria = new Memoria();
        Busca busca = new Busca();
        Decodificador decodificador = new Decodificador();
        Execucao execucao = new Execucao();
        ULA ula = new ULA();


        public frmSimulador()
        {
            InitializeComponent();
            controleImagens();
        }

        #region lerArquivo
        public void lerArquivo(String filename)
        {
            ArrayList linhas = new ArrayList();
            String line;
            bool erro = false;
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        linhas.Add(line);
                       // long line2 = Convert.ToInt64(line);
                       // Console.Out.WriteLine(line2);
                        if (line.Length != 32)
                        {
                            erro = true;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível ler o arquivo!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (erro == false)
            {
                foreach (String li in linhas)
                {
                    Console.WriteLine("Linha:" + li);
                }
            }
            else
            {
                MessageBox.Show("O arquivo deve possuir 32 caracteres por linha!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region controleImagens
        private void controleImagens()
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
        #endregion

        #region abrirArquivoAction
        private void abrirArquivoMenu_Click(object sender, EventArgs e)
        {
            String filename = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Selecione o arquivo de texto";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 filename = openFileDialog1.FileName;
            }
            Console.Out.WriteLine(filename);
            lerArquivo(filename);
        }
        #endregion


        private void btClock_Click(object sender, EventArgs e)
        {

        }
    }
}
