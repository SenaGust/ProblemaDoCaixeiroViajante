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
        static int somaTotal = int.MaxValue; //vai ser usada para auxiliar na descoberta do menor caminho

        public int Fatorial(int fat) //número de permutações possíveis //recebe número de cidades
        {
            if (fat == 0)
                return 1;
            else
                return fat * Fatorial(fat - 1);
        }

        public void Permutacoes(MatrizCidades cidades, int tam, int[] vetResp)
        {
            int[] vet = new int[tam]; //cria vetor cujo tamanho é o número de cidades
            int aux = 0, fat = Fatorial(tam); //aciona a recursividade do número de permutações possíveis

            for (int i = 0; i < tam; i++)//Preenche vetor com as cidades.
            {
                vet[i] = i;
            }

            for (int n = 0; n < fat; n++)//Total de permutações
            {
                for (int i = 0; i < tam - 1; i++)//Permutar e compor o caminho.
                {
                    Menor_Caminho(vet, cidades, vetResp); //aciona método do menor caminho

                    aux = vet[i]; //auxiliar recebe 1ª cidade
                    vet[i] = vet[i + 1];  //1ª cidade recebe 2ª cidade
                    vet[i + 1] = aux; //2ª cidade recebe auxiliar (1ª cidade)
                }
            }
        }

        public void Menor_Caminho(int[] vetCaminho, MatrizCidades cidades, int[] vetResp)//Verifica menor caminho.
        {
            //int[,] aux = new int[cidades.GetLength(0), cidades.GetLength(1)];
            //for(int linha=0;linha<cidades.GetLength(0);linha++)
            //{
            //    for(int coluna=0;coluna<cidades.GetLength(1);coluna++)
            //    {
            //        aux[linha, coluna] = Convert.ToInt32(cidades[linha, coluna]);
            //    }
            //}

            int aux_2 = 0;

            for (int i = 0; i < vetCaminho.Length - 1; i++)//Custo total do caminho.
            {
                aux_2 += cidades.m[vetCaminho[i], vetCaminho[i + 1]]; 

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

         public void imprimeResultados(int tamanho, MatrizCidades cidades)//Imprimir resultados no Main.
            {
            int[] vetResp = new int[tamanho];
                Stopwatch relogio = new Stopwatch();//Objeto para diagnóstico de tempo.

                relogio.Start();//Começa acontar o tempo.
                Permutacoes(cidades, tamanho, vetResp);
                relogio.Stop();//Para de contar o tempo.

                Console.WriteLine("Total de combinações possíveis: " + Fatorial(tamanho));
                Console.WriteLine("Peso total do menor caminho: " + somaTotal);
                Console.Write("Menor caminho: ");
                for (int i = 0; i < vetResp.Length; i++)
                {
                    Console.Write(vetResp[i] + " ");
                }

                Console.WriteLine("\nTempo gasto: ");
                Console.WriteLine("Horas: " + relogio.Elapsed.Hours + ", minutos: " + relogio.Elapsed.Minutes + ", segundos: " + relogio.Elapsed.Seconds + ", milissegundos: " + relogio.Elapsed.Milliseconds);
            }
        


    }
}