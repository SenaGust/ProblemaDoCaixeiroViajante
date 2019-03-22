using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantidadeCidades = 4;
            int[,] matrizDistanciaCidades = new int[quantidadeCidades, quantidadeCidades];

            Preencher_Matriz(matrizDistanciaCidades);
            Imprimir_Matriz(matrizDistanciaCidades);

            //Fim
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        #region Métodos para a Matriz
        static void Preencher_Matriz(int[,] matriz)
        {
            int custo;
            Random randomizer = new Random(); //criar distâncias 

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    custo = randomizer.Next(10) + 1;
                    if (linha < coluna)
                        matriz[linha, coluna] = custo;
                    else
                        if (linha == coluna)
                        matriz[linha, coluna] = 0;
                    else
                        matriz[linha, coluna] = matriz[coluna, linha];
                }
            }
            
        }
        #endregion

        #region Métodos usados para teste
        static void Imprimir_Matriz(int[,] matrizFrase)
        {
            //para testes
            for (int linha = 0; linha < matrizFrase.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matrizFrase.GetLength(1); coluna++)
                {
                    Console.Write(matrizFrase[linha, coluna] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
