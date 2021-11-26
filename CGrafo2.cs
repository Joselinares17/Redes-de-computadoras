using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoIntegradorRDC {
    class CGrafo {
        private int[,] mAdyacencia;
        private int[] indegree;
        private int nodos;

        public CGrafo(int pNodos) {
            this.nodos = pNodos;
            // Instancia matriz de adyacencia
            mAdyacencia = new int[nodos, nodos];
            // Instancia del arreglo de indegree
            indegree = new int[nodos];
        }
        //nuevo
        public void AdicionarArista(int pNodoInicio, int pNodoFinal, int pPeso) {
            mAdyacencia[pNodoInicio, pNodoFinal] = pPeso;
        }
        public void MuestraAdyacencia() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int n = 0; n < nodos; n++) {
                Console.Write("\t{0}", n);    
            }
            Console.WriteLine();
            for (int n = 0; n < nodos; n++) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
                for (int m = 0; m < nodos; m++) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t{0}", mAdyacencia[n, m]);
                }
                Console.WriteLine();
            }
        }

        public int ObtenAdyacencia(int pFila, int pColumna) {
            return mAdyacencia[pFila, pColumna];
        }
    }
}
