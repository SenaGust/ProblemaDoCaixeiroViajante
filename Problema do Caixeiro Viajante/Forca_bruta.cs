using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Forca_bruta
    {
        #region Atributos
        Trajeto[] todosTrajetos;
        int[,] matrizDistancias;
        #endregion

        #region Construtor
        public Forca_bruta(int[,] matrizDistancias)
        {
            this.matrizDistancias = matrizDistancias; //acha que isso é necessário?
            todosTrajetos = new Trajeto[Fatorial(matrizDistancias.GetLength(0))]; //fatorial do total de linhas/colunas (que é a quantidade total de cidades)
        }
        #endregion

        #region Métodos
        public void RetornaMenorDistancia()
        {
            PermutarCidades();
            DescobreTrajetoMenorDistancia();
        }

        private void PermutarCidades()
        {

        }

        private void DescobreTrajetoMenorDistancia()
        {

        }
        #endregion

        #region Métodos Auxiliares
        private int Fatorial(int numero)
        {
            int total = 1;
            for (int pos = 2; pos <= numero; pos++)
            {
                total *= total;
            }
            return total;
        }
        #endregion
    }
    
}
