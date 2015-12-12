using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    static class ULA
    {
        // Flags [0 0 0 0] -> [Z NZ D0 O]
        private static int[] flags = { 0, 0, 0, 0 };

        static public int[] getFlags()
        {
            return flags;
        }

        static public long getResultado()
        {
            return;
        }

        static public long soma(long operando1, long operando2)
        {
            zerarFlags();
            long soma = operando1 + operando2;
            if (soma == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            flags[2] = 0;
            if (soma < -132768 || soma > 132768)
            {
                flags[3] = 1;
            }
            return soma;
        }

        static public long subtracao(long operando1, long operando2)
        {
            zerarFlags();
            long subtracao = operando1 - operando2;
            if (subtracao == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            flags[2] = 0;
            if (subtracao < -132768 || subtracao > 132768)
            {
                flags[3] = 1;
            }
            return subtracao;
        }

        static public long multiplicacao(long operando1, long operando2)
        {
            zerarFlags();
            long multiplicacao = operando1 * operando2;
            if (multiplicacao == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            flags[2] = 0;
            if (multiplicacao < -132768 || multiplicacao > 132768)
            {
                flags[3] = 1;
            }
            return multiplicacao;
        }

        static public long divisao(long operando1, long operando2)
        {
            zerarFlags();
            long divisao = 0;
            if (operando2 == 0)
            {
                flags[2] = 1;
            }
            else
            {
                divisao = operando1 / operando2;
                if (divisao == 0)
                {
                    flags[0] = 1;
                    flags[1] = 0;
                }
                if (divisao < -132768 || divisao > 132768)
                {
                    flags[3] = 1;
                }
            }
            return divisao;
        }

        static public long and(long operando1, long operando2)
        {
            zerarFlags();
            return (operando1 & operando2);
        }

        static public long not(long operando1)
        {
            zerarFlags();
            return (~operando1);
        }

        static public long or(long operando1, long operando2)
        {
            zerarFlags();
            return (operando1 | operando2);
        }

        static public long xor(long operando1, long operando2)
        {
            zerarFlags();
            return (operando1 ^ operando2);
        }

        static public long shiftLeft(long operando1, int operando2)
        {
            zerarFlags();
            return (operando1 << operando2);
        }

        static public long shiftRight(long operando1, int operando2)
        {
            zerarFlags();
            return (operando1 >> operando2);
        }

        static public long incremento(long operando1)
        {
            zerarFlags();
            long incremento = operando1 + 1;
            if (incremento == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            flags[2] = 0;
            if (incremento < -132768 || incremento > 132768)
            {
                flags[3] = 1;
            }
            return incremento;
        }

        static public long decremento(long operando1)
        {
            zerarFlags();
            long decremento = operando1 - 1;
            if ((operando1 - 1) == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            flags[2] = 0;
            if (decremento < -132768 || decremento > 132768)
            {
                flags[3] = 1;
            }
            return decremento;
        }

        static private void zerarFlags()
        {
            flags[0] = 0;
            flags[1] = 0;
            flags[2] = 0;
            flags[3] = 0;
        }
    }
}
