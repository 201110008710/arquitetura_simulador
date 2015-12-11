using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class Busca
    {
        private Memoria mem;
        private PC pc;

        public Busca()
        {
            this.mem = new Memoria();
            this.pc = new PC();
        }

        public long getPalavra()
        {
            return mem.getDado(pc.getEndereco());
        }
    }
}
