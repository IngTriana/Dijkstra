using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class CGrafo
    {
        int[,] mAdyacencia;
        int[] indegree;
        int nodos;

        public CGrafo(int pNodos)
        {
            nodos = pNodos;

            // Instanciamos matriz de adyacencia
            mAdyacencia = new int[nodos,nodos];

            // Instanciamos arreglo de indegree
            indegree = new int[nodos];
        }

        public void AdicionaArista(int pNodoInicio, int pNodoFinal)
        {
            mAdyacencia[pNodoInicio,pNodoFinal] = 1;
        }

        public void MuestraAdyacencia()
        {
            int n = 0;
            int m = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;

            for(n = 0; n < nodos; n++) 
                Console.Write("\t{0}", n);

            Console.WriteLine();

            for(n = 0; n < nodos;n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
            }

        }   
    }
