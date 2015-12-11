using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquitetura_simulador
{
    class Execucao
    {
        Decodificador dec;
        ULA ula;

        public Execucao()
        {
            this.dec = new Decodificador();
            this.ula = new ULA();
        }

        public void instrucao(int inst, long operando1, long operando2)
        {

            switch (inst)
            {
                case 0: //Soma
                    ula.soma(operando1, operando2);
                    break;
                case 1: //Subtração
                    ula.subtracao(operando1, operando2);
                    break;
                case 2: //Multiplicacao
                    ula.multiplicacao(operando1, operando2);
                    break;
                case 3: //Divisao
                    ula.divisao(operando1, operando2);
                    break;
                case 4: //And
                    ula.and(operando1, operando2);
                    break;
                case 5: //Not
                    ula.not(operando1);
                    break;
                case 6: //Or
                    ula.or(operando1, operando2);
                    break;
                case 7: //Xor
                    ula.xor(operando1, operando2);
                    break;
                case 8: //ShiftLeft
                    ula.shiftLeft(operando1, operando2);
                    break;
                case 9: //ShiftRight
                    ula.shiftRight(operando1, operando2);
                    break;
                case 10: //Incremento
                    ula.incremento(operando1);
                    break;
                case 11: //Decremento
                    ula.decremento(operando1);
                    break;
                case 12: //mov memória -> registrador
                    break;
                case 13: //mov registrador -> memória
                    break;
                case 14:
                    break;
            }

        }
    } 
}
