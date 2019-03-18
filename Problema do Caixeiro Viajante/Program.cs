using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//criar arquivo csv

namespace Problema_do_Caixeiro_Viajante
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrizDistanciaCidades;
            int tamanho = 4;
            matrizDistanciaCidades = new int[tamanho, tamanho];

            Preencher_Matriz(matrizDistanciaCidades);
            Imprimir_Matriz(matrizDistanciaCidades);

            //Fim
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        #region matriz
        static void Preencher_Matriz(int[,] mat)
        {
            for (int linha = 0; linha < mat.GetLength(0); linha++)
                for (int coluna = 0; coluna < mat.GetLength(1); coluna++)
                    if (linha == coluna)
                        mat[linha, coluna] = 0;
                    else
                        mat[linha, coluna] = linha + coluna + 1;
        }
        static void Imprimir_Matriz(int[,] matrizFrase)
        {
            //para testes
            for (int linha = 0; linha < matrizFrase.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matrizFrase.GetLength(1); coluna++)
                {
                    Console.Write(matrizFrase[linha, coluna]+ " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

    }
}
