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

        public static void addDado(int posicao, String info)
        {
            dado.Insert(posicao, info);
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
            dado.Insert(0, null);
            dado.Insert(1, null);
            dado.Insert(2, null);
            dado.Insert(3, null);
        }

        public static Boolean isNull()
        {
            if (dado.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
