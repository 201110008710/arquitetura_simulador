using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    static class Execucao
    {
        private static bool ula = false;

        static public int getInstrucao()
        {
            execucao();
            return Convert.ToInt32(Decodificador.getInstrucao());
        }

        static public bool foiParaULA()
        {
            return ula;
        }

        static private void execucao()
        {
            int inst = Convert.ToInt32(Decodificador.getInstrucao());
            long operando1 = Decodificador.getOperando1();
            long operando2 = Decodificador.getOperando2();
            switch (inst)
            {
                case 0: //Soma
                    ula = true;
                    ULA.soma(operando1, operando2);
                    break;
                case 1: //Subtração
                    ula = true;
                    ULA.subtracao(operando1, operando2);
                    break;
                case 2: //Multiplicacao
                    ula = true;
                    ULA.multiplicacao(operando1, operando2);
                    break;
                case 3: //Divisao
                    ula = true;
                    ULA.divisao(operando1, operando2);
                    break;
                case 4: //And
                    ula = true;
                    ULA.and(operando1, operando2);
                    break;
                case 5: //Not
                    ula = true;
                    ULA.not(operando1);
                    break;
                case 6: //Or
                    ula = true;
                    ULA.or(operando1, operando2);
                    break;
                case 7: //Xor
                    ula = true;
                    ULA.xor(operando1, operando2);
                    break;
                case 8: //ShiftLeft
                    ula = true;
                    ULA.shiftLeft(operando1, Convert.ToInt32(operando2));
                    break;
                case 9: //ShiftRight
                    ula = true;
                    ULA.shiftRight(operando1, Convert.ToInt32(operando2));
                    break;
                case 10: //Incremento
                    ula = true;
                    ULA.incremento(operando1);
                    break;
                case 11: //Decremento
                    ula = true;
                    ULA.decremento(operando1);
                    break;
                case 12: //mov memória -> registrador
                    ula = false;
                    break;
                case 13: //mov registrador -> memória
                    ula = false;
                    break;
                case 14:
                    ula = false;
                    break;
            }

        }
    } 
}
