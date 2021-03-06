﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problema_do_Caixeiro_Viajante
{
    class Rota
    {
        public int cidade1, cidade2, custo;
    }

    class Forca_bruta
    {
        #region gera caminhos
        public void Escolher_caminhos(ref int[] permutacao,Cidades matrizDistancias, Rota[] melhorRota, out int melhorCusto)
        {
            int controle = -1;
            melhorCusto = int.MaxValue;

            for (int i = 0; i < melhorRota.Length; i++)
                melhorRota[i] = new Rota();

            /* Gera os caminhos possiveis e escolhe o melhor, chamando a funcao recursiva
             permuta */
            permuta(permutacao,matrizDistancias, melhorRota, ref melhorCusto, controle, 1);
        }
        #endregion

        #region Permutação
        void permuta(int[] permutacao, Cidades matrizDistancias, Rota[] melhorRota, ref int melhorCusto, int controle, int k)
        {
            int i;
            permutacao[k] = ++controle;
            if (controle == (melhorRota.Length - 1)) /* se gerou um caminho então verifica se ele é melhor */
                Melhor_caminho(matrizDistancias, melhorRota, ref melhorCusto, permutacao);
            else
                for (i = 1; i < melhorRota.Length; i++)
                    if (permutacao[i] == 0)
                        permuta(permutacao, matrizDistancias, melhorRota, ref melhorCusto, controle, i);
            controle--;
            permutacao[k] = 0;
        }
        #endregion

        #region melhor caminho
        public void Melhor_caminho(Cidades matriz, Rota[] melhorRota, ref int melhorCusto, int[] permutacao)
        {
            int j, k;                     /* contadores: auxiliam a montagem das rotas */
            int cid1, cid2;             /* cidades da melhor rota */
            int custo;                 /* custo total da melhor rota */
            int[] proxDaRota;        /* vetor que armazena a sequencia de cidades que estao
				                           em uma rota, tal que um indice indica uma cidade e
				                           o conteudo deste indice, a proxima cidade da rota */

            proxDaRota = new int[melhorRota.Length];
            /* monta uma rota com a permutacao */
            cid1 = 0;									/* a primeira cidade é a cidade 0 */
            cid2 = permutacao[1];
            custo = matriz.Matriz[cid1, cid2];
            proxDaRota[cid1] = cid2;

            for (j = 2; j < melhorRota.Length; j++)
            {
                cid1 = cid2;
                cid2 = permutacao[j];
                custo += matriz.Matriz[cid1, cid2];  /* calcula o custo parcial da rota */
                proxDaRota[cid1] = cid2;      /* armazena a rota fornecida pela permutacao */
            }

            proxDaRota[cid2] = 0;			/* completa o ciclo da viagem */
            custo += matriz.Matriz[cid2, 0];  /* custo total desta rota */

            if (custo < melhorCusto)	/* procura pelo melhor (menor) custo */
            {
                melhorCusto = custo;
                cid2 = 0;
                for (k = 0; k < melhorRota.Length; k++) /* guarda a melhor rota */
                {
                    cid1 = cid2;
                    cid2 = proxDaRota[cid1];
                    melhorRota[k].cidade1 = cid1;
                    melhorRota[k].cidade2 = cid2;
                    melhorRota[k].custo = matriz.Matriz[cid1, cid2];
                }
            }
        }
        #endregion

        #region Imprime melhor caminho
        public string Imprime_Melhor_Caminho(int custo, Rota[] melhorRota)
        {

            StringBuilder aux = new StringBuilder();
            for (int pos = 0; pos < melhorRota.Length; pos++)
            {
                aux.Append(melhorRota[pos].cidade1 + " ");
            }

            return new Trajeto(aux.ToString(), custo).ToString();
        }
        #endregion

        //#region Imprime Tempo
        //public void imprime_Tempo(Stopwatch tempo)
        //{
        //    Console.Write("TEMPO DE EXECUÇÂO (FORÇA BRUTA): ");
        //    Console.WriteLine("  "+tempo.Elapsed.Hours + " horas " + tempo.Elapsed.Minutes + " minutos " + tempo.Elapsed.Seconds + " segundos " + tempo.Elapsed.Milliseconds + " milisegundos");
        //}
        //#endregion
    }

}
