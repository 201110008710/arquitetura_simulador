using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arquitetura_simulador
{
    public partial class frmSimulador : Form
    {
        String filename = null;
        ArrayList buffer = new ArrayList();
        int posicoes = 0;
        int atualizacao = 0;
        int clock = 0;
        int clockTotal = 0;


        public frmSimulador()
        {
            InitializeComponent();
            setarImagensInvisiveis();
            atualizarClockStatus();
        }

        #region simular
        private void simular(int i)
        {

            switch (i)
            {
                case 0:
                    if ()
                    {

                    }
                    clearTxtLabels();
                    setarImagensInvisiveis();
                    picPC.Visible = true;
                    txtPC.Text = PC.getEnderecoAndInc().ToString();
                    break;
                case 1:
                    setarImagensInvisiveis();
                    setarIconeMemoria(PC.getEndereco());
                    break;
                case 2:
                    setarImagensInvisiveis();
                    picBusca.Visible = true;
                    txtBusca.Text = string.Format("0x{0:X}", Convert.ToInt64(Busca.getPalavra(), 2));
                    break;
                case 3:
                    setarImagensInvisiveis();
                    picDecodInst.Visible = true;
                    picDecodOpe1.Visible = true;
                    picDecodOpe2.Visible = true;
                    txtDecodInst.Text = string.Format("0x{0:X}", Decodificador.getInstrucao());
                    txtDecodOp1.Text = string.Format("0x{0:X}", Decodificador.getOperando1());
                    txtDecodOp2.Text = string.Format("0x{0:X}", Decodificador.getOperando2());
                    break;
                case 4:
                    setarImagensInvisiveis();
                    picExec.Visible = true;
                    txtOperacao.Text = obterOperacao(Execucao.getInstrucao());
                    if (Execucao.foiParaULA())
                    {
                        picULAResultado.Visible = true;
                        picULAStatus.Visible = true;
                        txtULARes.Text = ULA.getResultado().ToString();
                        txtULAStatus.Text = String.Join("", ULA.getFlags().Select(p => p.ToString()).ToArray());
                        setarStatusULA();
                    }
                    break;
            }

        }
        #endregion

        #region setarIconeMemoria
        private void setarIconeMemoria(int pos)
        {
            switch (pos)
            {
                case 0:
                    picMemoria0.Visible = true;
                    break;
                case 1:
                    picMemoria1.Visible = true;
                    break;
                case 2:
                    picMemoria2.Visible = true;
                    break;
                case 3:
                    picMemoria3.Visible = true;
                    break;
            }
        }
        #endregion

        #region clearTxtLabels
        private void clearTxtLabels()
        {
            txtPC.Text = "";
            txtBusca.Text = "";
            txtDecodInst.Text = "";
            txtDecodOp1.Text = "";
            txtDecodOp2.Text = "";
            txtOperacao.Text = "";
            txtULARes.Text = "";
            txtULAStatus.Text = "";
        }
        #endregion

        #region setarStatusULA
        private void setarStatusULA()
        {
            if (ULA.getFlags()[0] == 1)
                cbZero.Checked = true;
            else
                cbZero.Checked = false;
            if (ULA.getFlags()[1] == 1)
                cbNZero.Checked = true;
            else
                cbNZero.Checked = false;
            if (ULA.getFlags()[2] == 1)
                cbNZero.Checked = true;
            else
                cbDiv.Checked = false;
            if (ULA.getFlags()[3] == 1)
                cbOverflow.Checked = true;
            else
                cbOverflow.Checked = false;
        }
        #endregion

        #region obterOperacao
        private string obterOperacao(long pos)
        {
            switch (pos)
            {
                case 0: //Soma
                    return "ADD";
                case 1: //Subtração
                    return "SUB";
                case 2: //Multiplicacao
                    return "MUL";
                case 3: //Divisao
                    return "DIV";
                case 4: //And
                    return "AND";
                case 5: //Not
                    return "NOT";
                case 6: //Or
                    return "OR";
                case 7: //Xor
                    return "XOR";
                case 8: //ShiftLeft
                    return "SHL";
                case 9: //ShiftRight
                    return "SHR";
                case 10: //Incremento
                    return "INC";
                case 11: //Decremento
                    return "DEC";
                case 12: //mov memória -> registrador
                    return null;
                case 13: //mov registrador -> memória
                    return null;
                case 14:
                    return null;
            }
            return null;
        }
        #endregion

        #region atualizarMemoria
        public void atualizarMemoria()
        {
            Memoria.clearMemory();
            int i = 0;
            for (i = 0; i < buffer.Count; i++)
                if (i > 3)
                {
                    break;
                }
                else
                {
                    Memoria.insertDado(i, buffer[i + 4 * atualizacao].ToString());
                }
            atualizacao++;
            setarMemoriaTxtLabels();
        }
        #endregion

        #region setarMemoriaTxtLabels
        public void setarMemoriaTxtLabels()
        {
            txtMemoria0.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(0), 2));
            txtMemoria1.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(1), 2));
            txtMemoria2.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(2), 2));
            txtMemoria3.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(3), 2));
        }
        #endregion

        #region lerArquivo
        public void lerArquivo(String filename)
        {

            String line;
            if (filename != null)
            {
                try
                {
                    using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Length == 32)
                            {
                                buffer.Add(line);
                            }
                            else
                            {
                                MessageBox.Show("O arquivo deve possuir 32 caracteres por linha!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                buffer.Clear();
                            }
                            posicoes++;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Não foi possível ler o arquivo!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (buffer.Count != 0)
                {
                    atualizarMemoria();
                    //txtMemoria0.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(0), 2));
                    //txtMemoria1.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(1), 2));
                    //txtMemoria2.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(2), 2));
                    //txtMemoria3.Text = string.Format("0x{0:X}", Convert.ToInt64(Memoria.getDado(3), 2));
                }
            }
            else
            {
                MessageBox.Show("A memória está vazia!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region setarImagensInvisiveis
        private void setarImagensInvisiveis()
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Selecione o arquivo de texto";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            lerArquivo(filename);
        }
        #endregion

        #region atualizarClockStatus
        private void atualizarClockStatus()
        {
            StatusClock.Text = "Clock: " + clockTotal;
        }
        #endregion

        private string parse(string palavra)
        {
            string valor = null;

            if (palavra.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                palavra = palavra.Substring(2);
                valor = Int64.Parse(palavra, NumberStyles.HexNumber).ToString();
            }
            if (palavra.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
            {
                palavra = palavra.Substring(2);
                valor = Convert.ToInt64(palavra, 2).ToString();
            }
            return valor;
        }

        private void btClock_Click(object sender, EventArgs e)
        {
            Console.Out.WriteLine(posicoes);
            if (Memoria.isNull() == false) 
            {
                simular(clock);
                clock++;
                if (clock == 5)
                {
                    clock = 0;
                }
                clockTotal++;
                atualizarClockStatus();
            }
            else
            {
                MessageBox.Show("A memória está vazia!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
