﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class MatrizCidades
    {
        public int[,] m { get; set; }

        #region Contrutor
        public MatrizCidades(int quantidadeCidades)
        {
            m = new int[quantidadeCidades, quantidadeCidades];
        }
        #endregion

        #region Métodos
        public void Preencher()
        {
            int custo;
            Random randomizer = new Random(); //criar distâncias 

            for (int linha = 0; linha < m.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < m.GetLength(1); coluna++)
                {
                    custo = randomizer.Next(10) + 1;
                    if (linha < coluna)
                        m[linha, coluna] = custo;
                    else
                        if (linha == coluna)
                        m[linha, coluna] = 0;
                    else
                        m[linha, coluna] = m[coluna, linha];
                }
            }

        }
        public void Imprimir()
        {
            //para testes
            for (int linha = 0; linha < m.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < m.GetLength(1); coluna++)
                {
                    Console.Write(m[linha, coluna] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void ImprimirComTitulo()
        {
            //para testes
            Console.Write("\t");
            for (int pos = 0; pos < m.GetLength(0); pos++)
                Console.Write(pos + "\t");
            Console.WriteLine();

            for (int linha = 0; linha < m.GetLength(0); linha++)
            {
                Console.Write(linha + "\t");
                for (int coluna = 0; coluna < m.GetLength(1); coluna++)
                {
                    Console.Write(m[linha, coluna] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
