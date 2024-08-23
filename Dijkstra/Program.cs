using Lucene.Net.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int inicio = 0; //nodo de inicio
            int final = 0;  //nodo final
            int distancia = 0;  //distancia
            int n = 0;  //ciclo
            int cantNodos = 7;
            string dato = ""; //para pedir nodos de inicio y fin
            int actual = 0;
            int columna = 0; //para obtener la info de la tabla

            
            CGrafo miGrafo = new CGrafo(cantNodos);

            miGrafo.AdicionaArista(0, 1, 2);
            miGrafo.AdicionaArista(0, 3, 1);
            miGrafo.AdicionaArista(1, 3, 3);
            miGrafo.AdicionaArista(1, 4, 10);
            miGrafo.AdicionaArista(2, 0, 4);
            miGrafo.AdicionaArista(2, 5, 5);
            miGrafo.AdicionaArista(3, 2, 2);
            miGrafo.AdicionaArista(3, 4, 2);
            miGrafo.AdicionaArista(3, 5, 8);
            miGrafo.AdicionaArista(3, 6, 4);
            miGrafo.AdicionaArista(4, 6, 6);
            miGrafo.AdicionaArista(6, 5, 1);

            miGrafo.MuestraAdyacencia();

            Console.WriteLine("Dame el indice del nodo inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo final");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);

            //miGrafo.CalcularIndegree();

            //Creamos la tabla
            //0 - Visitado
            //1 - Distancia
            //2 - Previo/Padre

            int[,] tabla = new int[cantNodos, 3];

            //Inicializamos la tabla
            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }
            tabla[inicio, 1] = 0;

            MostrarTabla(tabla);

            // Inicio Dijkstra
            actual = inicio;

            do
            {
                //Marcar nodo como visitado
                tabla[actual,0] = 1;

                for(columna = 0; columna < cantNodos; columna++)
                {
                    // Buscamos a quien se dirige
                    if(miGrafo.ObtenAdyacencia(actual, columna) > 0)
                    { 
                        // Calculamos la distancia
                        distancia = miGrafo.ObtenAdyacencia(actual,columna) + tabla[actual,1];

                        // Colocamos las distancias
                        if(distancia < tabla[columna,1])
                        {
                            tabla[columna,1] = distancia;

                            // Colocamos la información de padre
                            tabla[columna,2] = actual;
                        }
                    }
                }

                //El nuevo nodo actual es el nodo con la menor distancia que no haya sido visitado

                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;

                for(int x = 0; x < cantNodos; x++)
                {
                    if (tabla[x,1] < distanciaMenor && tabla[x,0] == 0)
                    {
                        indiceMenor = x;
                        distanciaMenor = tabla[x,1];
                    }
                }

                actual = indiceMenor;
            } while(actual != -1);

            MostrarTabla(tabla);
            Console.ReadLine();

            //Obtenemos la ruta
            List<int> ruta = new List<int>();
            int nodo = final;

            while (nodo != inicio)
            {
                ruta.Add(nodo);
                nodo = tabla[nodo,2];
            }
            ruta.Add(inicio);

            ruta.Reverse();

            foreach (int posicion in ruta)
                MessageBox.Show(posicion+"->");

            Console.WriteLine();
        }

        public static void MostrarTabla(int[,] pTabla)
        {
            int n = 0;

            for(n = 0;n < pTabla.GetLength(0);n++)
            {
                Console.WriteLine("{0}-> {1}\t{2}\t{3}", n, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);
            }
            Console.WriteLine("- - - - - -");
            
        }
    }
}
