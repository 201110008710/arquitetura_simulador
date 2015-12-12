using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    public static class PC
    {
        private static int endereco = -1;

        public static int getEndereco()
        {
            return endereco;
        }

        public static int getEnderecoAndInc()
        {
            if (endereco == 3)
            {
                endereco = -1;
            }
            endereco++;
            return endereco;
        }

        public static void setEndereco(int end)
        {
            endereco = end;
        }
    }
}
