using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    public static class Memoria
    {
        private static ArrayList dado = new ArrayList();

        public static String getDado(int posicao)
        {
            return dado[posicao].ToString();
        }

        public static void addDado(String info)
        {
            dado.Add(info);
        }

        public static void insertDado(int pos, String info)
        {
            dado.Insert(pos, info);
        }

        public static void clearMemory()
        {
            dado.Insert(0, "");
            dado.Insert(1, "");
            dado.Insert(2, "");
            dado.Insert(3, "");
        }
    }
}
