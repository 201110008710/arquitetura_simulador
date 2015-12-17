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
        private static long resultado;

        static public int[] getFlags()
        {
            return flags;
        }

        static public long getResultado()
        {
            return resultado;
        }

        static public void soma(long operando1, long operando2)
        {
            zerarFlags();
            long soma = operando1 + operando2;
            if (soma == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            else
            {
                flags[0] = 0;
                flags[1] = 1;
            }
            flags[2] = 0;
            if (soma < -16384 || soma > 16384)
            {
                flags[3] = 1;
            }
            resultado = soma;
        }

        static public void subtracao(long operando1, long operando2)
        {
            zerarFlags();
            long subtracao = operando1 - operando2;
            if (subtracao == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            else
            {
                flags[0] = 0;
                flags[1] = 1;
            }
            flags[2] = 0;
            if (subtracao < -16384 || subtracao > 16384)
            {
                flags[3] = 1;
            }
            resultado = subtracao;
        }

        static public void multiplicacao(long operando1, long operando2)
        {
            zerarFlags();
            long multiplicacao = operando1 * operando2;
            if (multiplicacao == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            else
            {
                flags[0] = 0;
                flags[1] = 1;
            }
            flags[2] = 0;
            if (multiplicacao < -16384 || multiplicacao > 16384)
            {
                flags[3] = 1;
            }
            resultado = multiplicacao;
        }

        static public void divisao(long operando1, long operando2)
        {
            zerarFlags();
            long divisao = 0;
            if (operando2 == 0)
            {
                flags[2] = 1;
                flags[1] = 1;
            }
            else
            {
                divisao = operando1 / operando2;
                if (divisao == 0)
                {
                    flags[0] = 1;
                    flags[1] = 0;
                }
                else
                {
                    flags[0] = 0;
                    flags[1] = 1;
                }
                if (divisao < -16384 || divisao > 16384)
                {
                    flags[3] = 1;
                }
            }
            resultado = divisao;
        }

        static public void and(long operando1, long operando2)
        {
            zerarFlags();
            resultado = (operando1 & operando2);
        }

        static public void not(long operando1)
        {
            zerarFlags();
            resultado = (~operando1);
        }

        static public void or(long operando1, long operando2)
        {
            zerarFlags();
            resultado = (operando1 | operando2);
        }

        static public void xor(long operando1, long operando2)
        {
            zerarFlags();
            resultado = (operando1 ^ operando2);
        }

        static public void shiftLeft(long operando1, int operando2)
        {
            zerarFlags();
            resultado = (operando1 << operando2);
        }

        static public void shiftRight(long operando1, int operando2)
        {
            zerarFlags();
            resultado = (operando1 >> operando2);
        }

        static public void incremento(long operando1)
        {
            zerarFlags();
            long incremento = operando1 + 1;
            if (incremento == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            else
            {
                flags[0] = 0;
                flags[1] = 1;
            }
            flags[2] = 0;
            if (incremento < -16384 || incremento > 16384)
            {
                flags[3] = 1;
            }
            resultado = incremento;
        }

        static public void decremento(long operando1)
        {
            zerarFlags();
            long decremento = operando1 - 1;
            if ((operando1 - 1) == 0)
            {
                flags[0] = 1;
                flags[1] = 0;
            }
            else
            {
                flags[0] = 0;
                flags[1] = 1;
            }
            flags[2] = 0;
            if (decremento < -16384 || decremento > 16384)
            {
                flags[3] = 1;
            }
            resultado = decremento;
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
