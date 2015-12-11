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
                case Convert.ToInt64("0000",2): //Soma
                    ula.soma(operando1, operando2);
                    break;
                case 0b0001: //Subtração
                    ula.subtracao(operando1, operando2);
                    break;
                case 0b0010: //Multiplicacao
                    ula.multiplicacao(operando1, operando2);
                    break;
                case 0b0100: //Divisao
                    ula.divisao(operando1, operando2);
                    break;
                case 0b0101: //And
                    ula.and(operando1, operando2);
                    break;
                case 0b0110: //Not
                    ula.not(operando1);
                    break;
                case 0b0111: //Or
                    ula.or(operando1, operando2);
                    break;
                case 0b1000: //Xor
                    ula.xor(operando1, operando2);
                    break;
                case 0b1001: //ShiftLeft
                    ula.shiftLeft(operando1, operando2);
                    break;
                case 0b1010: //ShiftRight
                    ula.shiftRight(operando1, operando2);
                    break;
                case 0b1011: //Incremento
                    ula.incremento(operando1);
                    break;
                case 0b1100: //Decremento
                    ula.decremento(operando1);
                    break;
                case 0b1101: //mov memória -> registrador
                    break;
                case 0b1110: //mov registrador -> memória
                    break;
                case 0b1111:
                    break;
            }

        }
    } 
}
