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
            int qtdeCidades = 4;
            MatrizCidades matriz = new MatrizCidades(qtdeCidades);
            matriz.Preencher();
            matriz.Imprimir();

            //Fim
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
