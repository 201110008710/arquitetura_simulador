using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    public static class Busca
    {
        public static String getPalavra()
        {
            return Memoria.getDado(PC.getEndereco());
        }
    }
}
