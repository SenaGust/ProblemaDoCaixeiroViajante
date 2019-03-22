using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Problema_do_Caixeiro_Viajante
{
    class Program
    {
        static void Main(string[] args)
        {
            //testeLorena();
            ProgramFinal();

            //Fim
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        static void testeLorena()
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
            caixeiro_forca_bruta.Escolher_caminhos(ref permutacao, matriz, melhorRota, out custo);
            stopwatchBruto.Stop();
            caixeiro_forca_bruta.Imprime_Melhor_Caminho(custo, melhorRota);
            caixeiro_forca_bruta.imprime_Tempo(stopwatchBruto);

        }
        static void ProgramFinal()
        {
            #region Criando Arquivo .CSV
            StreamWriter criandoArquivo = new StreamWriter("testeQuadratico.csv"); // se nao existe, cria
            criandoArquivo.WriteLine("Quantidade de Cidades; Tempo Força-Bruta; Tempo Quadratico;");
            criandoArquivo.Close();
            #endregion

            //n= 3,4, 5, 6, 7, 8, 9,10, 15, 20, 25, 30 
            Console.WriteLine("Começa" + 3);
            Inicializa(3);
            Console.WriteLine("Começa" + 4);
            Inicializa(4);
            Console.WriteLine("Começa" + 5);
            Inicializa(5);
            Console.WriteLine("Começa" + 6);
            Inicializa(6);
            Console.WriteLine("Começa" + 7);
            Inicializa(7);
            Console.WriteLine("Começa" + 8);
            Inicializa(8);
            Console.WriteLine("Começa" + 9);
            Inicializa(9);
            Console.WriteLine("Começa" + 10);
            Inicializa(10);
            Console.WriteLine("Começa" + 15);
            Inicializa(15);
            Console.WriteLine("Começa" + 20);
            Inicializa(20);
            Console.WriteLine("Começa" + 25);
            Inicializa(25);
            Console.WriteLine("Começa" + 30);
            Inicializa(30);
        }

        static void contabilizaTodosTempos(MatrizCidades matriz)
        {
            string nomeArquivo = "testeQuadratico.csv";
            StreamWriter escreverArquivo;
            Stopwatch watch;

            escreverArquivo = new StreamWriter(nomeArquivo, true); //se existe, continua a escrever

            #region Testando Quadratico
            Quadratico CaixeiroQuadratico = new Quadratico();

            //inicia contagem do tempo
            watch = Stopwatch.StartNew();
            CaixeiroQuadratico.GerarMelhorCaminho(matriz);
            watch.Stop();
            //finaliza contagem do tempo

            var tempoQuadratico = watch.ElapsedMilliseconds; //salva tempo
            Console.WriteLine("Termina Quadratico");
            #endregion

            #region Testando Força Bruta
            int[] permutacao; //vetor com um caminho possíveil
            Rota[] melhorRota; //contem a melhor rota de viagem
            int custo = 0, qtdeCidades = matriz.m.GetLength(0);
            
            Forca_bruta caixeiro_forca_bruta = new Forca_bruta(); //força bruta

            permutacao = new int[qtdeCidades];
            melhorRota = new Rota[qtdeCidades];
            
            //inicia contagem do tempo
            watch = Stopwatch.StartNew();
            caixeiro_forca_bruta.Escolher_caminhos(ref permutacao, matriz, melhorRota, out custo);
            //caixeiro_forca_bruta.Imprime_Melhor_Caminho(custo, melhorRota);
            watch.Stop();
            //finaliza contagem do tempo

            var tempoForcaBruta = watch.ElapsedMilliseconds; //salva tempo
            Console.WriteLine("Termina força bruta");
            #endregion

            escreverArquivo.WriteLine("{0};{1};{2}", matriz.m.GetLength(0), tempoForcaBruta, tempoQuadratico);
            escreverArquivo.Close();
        }
        static void Inicializa(int qtdeCidades)
        {
            MatrizCidades matriz = new MatrizCidades(qtdeCidades);
            matriz.Preencher();
            contabilizaTodosTempos(matriz);
        }
    }
}
