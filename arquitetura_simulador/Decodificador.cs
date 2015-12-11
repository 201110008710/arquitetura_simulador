using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class Decodificador
    {
        private Busca bus = new Busca();

        public long getInstrucao()
        {
            return (bus.getPalavra() & 0x3C000) >> 14;
        }

        public long getOperando1()
        {
            return (bus.getPalavra() & 0xFFFC0000) >> 18;
        }

        public long getOperando2()
        {
            return (bus.getPalavra() & 0x3FFF);
        }
    }
}
