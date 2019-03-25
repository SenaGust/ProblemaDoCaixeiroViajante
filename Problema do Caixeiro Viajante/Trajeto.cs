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
        string caminho;
        int distancia;
        #endregion

        #region Construtor
        public Trajeto(string caminho, int distancia)
        {
            this.caminho = caminho;
            this.distancia = distancia;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            //retorna assim "O caminho abc possui a distância 10."
            return "Melhor caminho: " + caminho + " possui a distância " + distancia + ".";
        }
        #endregion
    }
}
