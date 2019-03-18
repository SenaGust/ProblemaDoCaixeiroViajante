using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Quadratico
    {
        #region Atributos
        int[,] matrizDistancias;
        #endregion

        #region Construtor
        public Quadratico(int[,] matrizDistancias)
        {
            this.matrizDistancias = matrizDistancias; //acha que isso é necessário?
        }
        #endregion
    }
}
