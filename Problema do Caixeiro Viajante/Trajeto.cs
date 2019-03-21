using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Trajeto
    {
        #region Atributos
        char[] caminho;
        int distancia;
        #endregion

        #region Construtor
        public Trajeto(char[] caminho, int distancia)
        {
            this.caminho = caminho;
            this.distancia = distancia;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            //retorna assim "O caminho abc possui a distância 10."
            return "O caminho " + new string(caminho) + " possui a distância " + distancia + ".";
        }
        #endregion
    }
}
