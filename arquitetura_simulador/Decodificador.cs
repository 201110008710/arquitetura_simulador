using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    public static class Decodificador
    {

        public static long getInstrucao()
        {
            return (Convert.ToInt64(Busca.getPalavra(), 2) & 0xF0000000) >> 28;
        }

        public static long getOperando1()
        {
            return (Convert.ToInt64(Busca.getPalavra(), 2) & 0xFFFC000) >> 14;
        }

        public static long getOperando2()
        {
            return (Convert.ToInt64(Busca.getPalavra(), 2) & 0x3FFF);
        }
        
    }
}
