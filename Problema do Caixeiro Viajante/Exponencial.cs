using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problema_do_Caixeiro_Viajante
{
    class Exponencial
    {
        int somaTotal = int.MaxValue; //vai ser usada para auxiliar na descoberta do menor caminho

        public int Fatorial(int num) //número de permutações possíveis //recebe número de cidades
        {
            int total = 1;
            for (int pos = 2; pos <= num; pos++)
            {
                total *= pos;
            }
            return total;
        }

        public void Permutacoes(Cidades cidades, int tam, int[] vetResp)
        {
            int[] vet = new int[tam]; //cria vetor cujo tamanho é o número de cidades
            int aux = 0, fat = Fatorial(tam-1); //aciona a recursividade do número de permutações possíveis
            vetResp[0] = 0;
            for (int i = 0; i < tam; i++)//Preenche vetor com as cidades.
            {
                vet[i] = i;
            }

            for (int n = 0; n < fat; n++)//Total de permutações
            {
                for (int i = 1; i < tam - 1; i++)//Permutar e compor o caminho.
                {
                    Menor_Caminho(vet, cidades, vetResp); //aciona método do menor caminho

                    aux = vet[i]; //auxiliar recebe 1ª cidade
                    vet[i] = vet[i + 1];  //1ª cidade recebe 2ª cidade
                    vet[i + 1] = aux; //2ª cidade recebe auxiliar (1ª cidade)
                }
            }
        }

        public void Menor_Caminho(int[] vetCaminho, Cidades cidades, int[] vetResp)//Verifica menor caminho.
        {
            int aux_2 = 0;

            for (int i = 0; i < vetCaminho.Length - 1; i++)//Custo total do caminho.
            {
                aux_2 += cidades.Matriz[vetCaminho[i], vetCaminho[i + 1]]; 

                if (aux_2 > somaTotal)
                    i = vetCaminho.Length;
            }

            if (aux_2 < somaTotal)//Menor caminho calculado.
            {
                somaTotal = aux_2;

                for (int i = 0; i < vetCaminho.Length; i++)
                {
                    vetResp[i] = vetCaminho[i];
                }
            }

            

        }

        private int calcularDistancia(int[] melhorCaminho, Cidades matriz)
        {
            int valorTotal = 0;
            for (int pos = 0; pos < melhorCaminho.Length; pos++)
            {
                if (pos + 1 >= melhorCaminho.Length)
                    valorTotal += matriz.Matriz[melhorCaminho[pos], 0];
                else
                    valorTotal += matriz.Matriz[melhorCaminho[pos], melhorCaminho[pos + 1]];
            }
            return valorTotal;
        }

        public string imprimeResultados(int [] melhorRota, Cidades matriz)//Imprimir resultados no Main.
        {
            int custo = calcularDistancia(melhorRota, matriz);

            StringBuilder aux = new StringBuilder();
            for (int pos = 0; pos < melhorRota.Length; pos++)
            {
                aux.Append(melhorRota[pos] + " ");
            }

            return new Trajeto(aux.ToString(), custo).ToString();
        }
    }
}