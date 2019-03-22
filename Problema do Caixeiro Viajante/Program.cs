using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problema_do_Caixeiro_Viajante
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] permutacao; //vetor com um caminho possíveil
            Rota[] melhorRota; //contem a melhor rota de viagem
            int qtdeCidades = 10, custo = 0;
            MatrizCidades matriz = new MatrizCidades(qtdeCidades);
            matriz.Preencher(); //caixeiro.monta_matriz
            matriz.Imprimir();
            Forca_bruta caixeiro_forca_bruta = new Forca_bruta(); //força bruta

            permutacao = new int[qtdeCidades];
            melhorRota = new Rota[qtdeCidades];

            Stopwatch stopwatchBruto = new Stopwatch();
            stopwatchBruto.Start(); //inicia a contagem de tempo
            caixeiro_forca_bruta.Escolher_caminhos(ref permutacao, matriz, melhorRota,out custo);
            stopwatchBruto.Stop();
            caixeiro_forca_bruta.Imprime_Melhor_Caminho(custo, melhorRota);
            caixeiro_forca_bruta.imprime_Tempo(stopwatchBruto);

            //Fim
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
