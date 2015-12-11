using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class Memoria
    {
        private ArrayList dado;

        public Memoria()
        {
            this.dado = new ArrayList();
        }

        public long getDado(int posicao)
        {
            return Convert.ToInt64(dado[posicao]);
        }

        public void addDado(int posicao, long info)
        {
            dado.Insert(posicao, info);
        }
    }
}
