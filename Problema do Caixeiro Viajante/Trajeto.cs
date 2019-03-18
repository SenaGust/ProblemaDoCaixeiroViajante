using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Trajeto
    {
        char[] caminho;
        int distancia;

        public Trajeto(char[] caminho, int distancia)
        {
            this.caminho = caminho;
            this.distancia = distancia;
        }

        public string ToString2()
        {
            //retorna assim "O caminho abc possui a distância 10."
            return "O caminho " + new string(caminho) + " possui a distância " + distancia + ".";
        }

        public override string ToString()
        {
            //retorna assim "O caminho a b c possui a distância 10."
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("O caminho ");
            for (int pos = 0; pos < caminho.Length; pos++)
            {
                stringBuilder.Append(caminho[pos] + " ");
            }
            stringBuilder.Append(" possui a distância " + distancia + ".");

            return stringBuilder.ToString();
        }
    }
}
