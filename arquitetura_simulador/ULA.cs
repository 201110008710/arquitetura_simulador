using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class ULA
    {
        private int[] flags;

        public ULA()
        {
            this.flags = new int[3];
            this.flags[0] = 0;
            this.flags[1] = 0;
            this.flags[2] = 0;
            this.flags[3] = 0;
        }

        public long soma(long operando1, long operando2)
        {
            long soma = operando1 + operando2;
            if (soma < -2147483647 || soma > 2147483647)
            {
                flags[4] = 1;
            }
            if (soma == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 1;
            return soma;
        }

        public long subtracao(long operando1, long operando2)
        {
            if ((operando1 - operando2) == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 1;
            return (operando1 - operando2);
        }

        public long multiplicacao(long operando1, long operando2)
        {
            if ((operando1 * operando2) == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 1;
            return (operando1 * operando2);
        }

        public long divisao(long operando1, long operando2)
        {
            if ((operando1 / operando2) == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 1;
            return (operando1 / operando2);
        }

        public long and(long operando1, long operando2)
        {
            return (operando1 & operando2);
        }

        public long not(long operando1)
        {
            return (~operando1);
        }

        public long or(long operando1, long operando2)
        {
            return (operando1 | operando2);
        }

        public long xor(long operando1, long operando2)
        {
            return (operando1 ^ operando2);
        }

        public long shiftLeft(long operando1, long operando2)
        {
            return (operando1 << operando2);
        }

        public long shiftRight(long operando1, long operando2)
        {
            return (operando1 >> operando2);
        }

        public long incremento(long operando1)
        {
            if ((operando1 + 1) == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 0;
            return (operando1 + 1);
        }

        public long decremento(long operando1)
        {
            if ((operando1 - 1) == 0)
            {
                flags[1] = 1;
                flags[2] = 0;
            }
            flags[2] = 0;
            return (operando1 - 1);
        }
    }
}
