using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_do_Caixeiro_Viajante
{
    class Quadratico
    {
        #region Método Principal
        public string GerarMelhorCaminho(MatrizCidades matriz)
        {
            int quantidadeCidades = matriz.m.GetLength(0);

            int[] melhorCaminho = new int[quantidadeCidades]; //preenche a rota mais rapida
            bool[] cidadeVisitada = new bool[quantidadeCidades]; //sei se a cidade foi visitada ou nãp

            //Vamos começar da cidade 0 ou primeira cidade
            melhorCaminho[0] = 0;   //começamos da cidade 0 ou primeira cidade
            cidadeVisitada[0] = true; //cidade 0 foi visitada

            //gerar melhor caminho a partir da segunda posição
            int percorreMelhorCaminho = 1;

            while (!TodosVisitados(cidadeVisitada))// enquanto não visitar todos
            {
                int menorDistancia = int.MaxValue, guardaPosicaoMenor = -1;
                for (int proximaCidade = 1; proximaCidade < quantidadeCidades; proximaCidade++) //percorro todas as cidades
                {
                    if (!cidadeVisitada[proximaCidade]) //se a cidade foi visitada, não precisa contar ela
                    {
                        //Console.Write(" " + proximaCidade);
                        int cidadeAtual = melhorCaminho[percorreMelhorCaminho];
                        if (menorDistancia > matriz.m[proximaCidade, cidadeAtual])
                        {
                            guardaPosicaoMenor = proximaCidade;
                            menorDistancia = matriz.m[proximaCidade, cidadeAtual];
                        }
                    }
                }
                cidadeVisitada[guardaPosicaoMenor] = true;
                melhorCaminho[percorreMelhorCaminho] = guardaPosicaoMenor;
                percorreMelhorCaminho++;
            }
            return new Trajeto(ConverterVetor(melhorCaminho), calcularDistancia(melhorCaminho, matriz)).ToString();
        }
        #endregion

        #region Métodos Auxiliares
        private bool TodosVisitados(bool[] cidadesVisitadas)
        {
            for (int pos = 0; pos < cidadesVisitadas.Length; pos++)
                if (!cidadesVisitadas[pos])
                    return false;

            return true;
        }
        private string ConverterVetor(int[] valor)
        {
            StringBuilder aux = new StringBuilder();
            for (int pos = 0; pos < valor.Length; pos++)
            {
                aux.Append(valor[pos] + " ");
            }

            return aux.ToString();
        }
        private int calcularDistancia(int[] melhorCaminho, MatrizCidades matriz)
        {
            int valorTotal = 0;
            for (int pos = 0; pos < melhorCaminho.Length; pos++)
            {
                if (pos + 1 >= melhorCaminho.Length)
                    valorTotal += matriz.m[melhorCaminho[pos], 0];
                else
                    valorTotal += matriz.m[melhorCaminho[pos], melhorCaminho[pos + 1]];
            }
            return valorTotal;
        }
        #endregion
    }
}
