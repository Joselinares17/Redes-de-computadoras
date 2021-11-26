using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TrabajoIntegradorRDC {
    class Prueba {

        static void Main(string[] args) {

            int inicio = 0, ultimo = 0, distancia = 0, n = 0;
            // cambiar cantNodos por la complejidad q desee entre 8 y 12.
            int cantNodos = 12;
            String dato = "";
            int actual = 0, columna = 0;

            // Se crea el Grafo
            CGrafo miGrafo = new CGrafo(cantNodos);

            // AdicionarArista(Fila, Columna, Peso);
            /*
            // tabla de adyacencia complejidad baja
            miGrafo.AdicionarArista(0, 1, 5);
            miGrafo.AdicionarArista(0, 2, 6);
            miGrafo.AdicionarArista(0, 4, 2);
            miGrafo.AdicionarArista(1, 0, 5);
            miGrafo.AdicionarArista(1, 3, 4);
            miGrafo.AdicionarArista(1, 4, 2);
            miGrafo.AdicionarArista(2, 0, 6);
            miGrafo.AdicionarArista(2, 3, 6);
            miGrafo.AdicionarArista(2, 5, 3);
            miGrafo.AdicionarArista(3, 1, 4);
            miGrafo.AdicionarArista(3, 2, 6);
            miGrafo.AdicionarArista(3, 7, 7);
            miGrafo.AdicionarArista(4, 0, 2);
            miGrafo.AdicionarArista(4, 1, 2);
            miGrafo.AdicionarArista(4, 6, 1);
            miGrafo.AdicionarArista(5, 2, 3);
            miGrafo.AdicionarArista(5, 6, 8);
            miGrafo.AdicionarArista(5, 7, 10);
            miGrafo.AdicionarArista(6, 4, 1);
            miGrafo.AdicionarArista(6, 5, 8);
            miGrafo.AdicionarArista(6, 7, 9);
            miGrafo.AdicionarArista(7, 3, 7);
            miGrafo.AdicionarArista(7, 5, 10);
            miGrafo.AdicionarArista(7, 6, 9);
            */

            // Tabla de adyacencia complejidad alta
            miGrafo.AdicionarArista(0, 1, 9);
            miGrafo.AdicionarArista(0, 2, 4);
            miGrafo.AdicionarArista(0, 4, 7);
            miGrafo.AdicionarArista(1, 0, 9);
            miGrafo.AdicionarArista(1, 5, 8);
            miGrafo.AdicionarArista(1, 7, 1);
            miGrafo.AdicionarArista(2, 0, 4);
            miGrafo.AdicionarArista(2, 3, 5);
            miGrafo.AdicionarArista(2, 5, 2);
            miGrafo.AdicionarArista(3, 2, 5);
            miGrafo.AdicionarArista(3, 6, 1);
            miGrafo.AdicionarArista(3, 8, 8);
            miGrafo.AdicionarArista(4, 0, 7);
            miGrafo.AdicionarArista(4, 9, 4);
            miGrafo.AdicionarArista(4, 11, 4);
            miGrafo.AdicionarArista(5, 1, 8);
            miGrafo.AdicionarArista(5, 2, 2);
            miGrafo.AdicionarArista(5, 10, 3);
            miGrafo.AdicionarArista(6, 3, 1);
            miGrafo.AdicionarArista(6, 7, 5);
            miGrafo.AdicionarArista(6, 9, 2);
            miGrafo.AdicionarArista(7, 1, 1);
            miGrafo.AdicionarArista(7, 6, 5);
            miGrafo.AdicionarArista(7, 10, 2);
            miGrafo.AdicionarArista(8, 3, 8);
            miGrafo.AdicionarArista(8, 9, 2);
            miGrafo.AdicionarArista(8, 11, 4);
            miGrafo.AdicionarArista(9, 4, 4);
            miGrafo.AdicionarArista(9, 6, 2);
            miGrafo.AdicionarArista(9, 8, 2);
            miGrafo.AdicionarArista(10, 5, 3);
            miGrafo.AdicionarArista(10, 7, 2);
            miGrafo.AdicionarArista(10, 11, 6);
            miGrafo.AdicionarArista(11, 4, 4);
            miGrafo.AdicionarArista(11, 8, 4);
            miGrafo.AdicionarArista(11, 10, 6);
            

            miGrafo.MuestraAdyacencia();

            Console.WriteLine("Dame el indice del nodo inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo final");
            dato = Console.ReadLine();
            ultimo = Convert.ToInt32(dato);

            //Crea la tabla
            // 0 - Visitado
            // 1 - Distancia
            // 2 - Previo

            int[,] tabla = new int[cantNodos, 3];

            // Inicializamos la tabla
            for (n = 0; n < cantNodos; n++) {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }
            tabla[inicio, 1] = 0;

            MostrarTabla(tabla);

            //algoritmo Dijkstra
            actual = inicio;

            do {
                // Marcar nodo como visitado
                tabla[actual, 0] = 1;

                for (columna = 0; columna < cantNodos; columna++) {
                    //Busca a quien se dirige
                    if (miGrafo.ObtenAdyacencia(actual, columna) != 0) {
                        //calcula la distancia
                        distancia = miGrafo.ObtenAdyacencia(actual, columna) + tabla[actual, 1];

                        if (distancia < tabla[columna, 1]) {
                            tabla[columna, 1] = distancia;
                            // Coloca la informacion de padre
                            tabla[columna, 2] = actual;
                        }
                    }
                }

                // El nuevo actual es el nodo con la menor distancia q no ha sido visitado

                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;

                for (int x = 0; x < cantNodos; x++) {
                    if (tabla[x , 1] < distanciaMenor && tabla[x, 0] == 0) {
                        indiceMenor = x;
                        distanciaMenor = tabla[x, 1];
                    }
                }

                actual = indiceMenor;

            } while (actual != -1);

            MostrarTabla(tabla);

            // obtener la ruta

            List<int> ruta = new List<int>();
            int nodo = ultimo;

            while (nodo != inicio) {
                ruta.Add(nodo);
                nodo = tabla[nodo, 2];
            }
            ruta.Add(inicio);

            ruta.Reverse();

            foreach (int posicion in ruta) {
                Console.Write("{0}->", posicion);
            }
            Console.WriteLine();

            timeTest();
        }

        public static void timeTest() {
            Stopwatch time = new Stopwatch();
            time.Start();
            int operacion = 10 / 4;
            time.Stop();
            Console.WriteLine("Tiempo: " + time.Elapsed.TotalMilliseconds + "ms.");
            Console.WriteLine("Precision: " + (1.0 / Stopwatch.Frequency).ToString("E"));
            if (Stopwatch.IsHighResolution) {
                Console.WriteLine("Alta precision");
            } else {
                Console.WriteLine("Baja precision");
            }
        }
        public static void MostrarTabla(int[,] pTabla) {// la tabla se muestra
            for (int n = 0; n < pTabla.GetLength(0); n++) {
                Console.WriteLine("{0}-> {1}\t{2}\t{3}", n, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);
            }
            Console.WriteLine("-------");
        }
    }
}
