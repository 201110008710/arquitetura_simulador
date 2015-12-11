using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class PC
    {
        private int endereco;

        public PC()
        {
            this.endereco = 0;
        }

        public int getEndereco()
        {
            return endereco++;
        }

        public void setEndereco(int end)
        {
            endereco = end;
        }
    }
}
