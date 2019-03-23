using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Cidades
    {
        public int[,] Matriz { get; set; }

        #region Contrutor
        public Cidades(int quantidadeCidades)
        {
            Matriz = new int[quantidadeCidades, quantidadeCidades];
        }
        #endregion

        #region Métodos
        public void Preencher()
        {
            int custo;
            Random randomizer = new Random(); //criar distâncias 

            for (int linha = 0; linha < Matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    custo = randomizer.Next(10) + 1;
                    if (linha < coluna)
                        Matriz[linha, coluna] = custo;
                    else
                        if (linha == coluna)
                        Matriz[linha, coluna] = 0;
                    else
                        Matriz[linha, coluna] = Matriz[coluna, linha];
                }
            }

        }
        public void Imprimir()
        {
            //para testes
            for (int linha = 0; linha < Matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    Console.Write(Matriz[linha, coluna] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void ImprimirComTitulo()
        {
            //para testes
            Console.Write("\t");
            for (int pos = 0; pos < Matriz.GetLength(0); pos++)
                Console.Write(pos + "\t");
            Console.WriteLine();

            for (int linha = 0; linha < Matriz.GetLength(0); linha++)
            {
                Console.Write(linha + "\t");
                for (int coluna = 0; coluna < Matriz.GetLength(1); coluna++)
                {
                    Console.Write(Matriz[linha, coluna] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
