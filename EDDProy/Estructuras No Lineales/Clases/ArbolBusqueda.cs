using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_No_Lineales
{
    public class ArbolBusqueda
    {
        NodoBinario Raiz;
        public String strArbol;
        public String strRecorrido;

        public ArbolBusqueda()
        {
            Raiz = null;
            strArbol = "";
            strRecorrido = "";
        }


        public Boolean EstaVacio()
        {
            if (Raiz == null)
                return true;
            else
                return false;
        }
        public NodoBinario RegresaRaiz()
        {
            return Raiz;
        }

        public void InsertaNodo(int Dato, ref NodoBinario Nodo)
        {
            if (Nodo == null)
            {
                Nodo = new NodoBinario(Dato);
                // CAMBIO 2

                if (Raiz == null)
                    Raiz = Nodo;
            }
            else if (Dato < Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Izq);
            else if (Dato > Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Der);

        }

        public void Podar(ref NodoBinario nodo)
        {
            if (nodo == null)
                return;
            Podar(ref nodo.Izq);
            Podar(ref nodo.Der);
            nodo = null;
            Raiz = null;

        }
        public void EliminarSucesor(int a, ref NodoBinario nodo)
        {
            // Si el nodo es null, no hay nada que hacer
            if (nodo == null)
                return;

            // Si el valor a es menor, buscamos en el subárbol izquierdo
            if (a < nodo.Dato)
                EliminarSucesor(a, ref nodo.Izq);

            // Si el valor a es mayor, buscamos en el subárbol derecho
            else if (a > nodo.Dato)
                EliminarSucesor(a, ref nodo.Der);

            // Si el valor a es igual al nodo actual entonces
            else
            {
                // Caso 1: El nodo tiene dos hijos
                if (nodo.Izq != null && nodo.Der != null)
                {
                    // Encontrar el sucesor (el más pequeño en el subárbol derecho)
                    NodoBinario sucesor = BuscaMenor(nodo.Der);
                    nodo.Dato = sucesor.Dato;  // Reemplazamos el dato por el del sucesor
                    EliminarSucesor(sucesor.Dato, ref nodo.Der);  // Eliminamos el sucesor del subafbol derecho
                }
                else
                {
                    // Caso 2: El nodo tiene 1 o ninguno hijo
                    NodoBinario temp = nodo;
                    nodo = (nodo.Izq != null) ? nodo.Izq : nodo.Der;  // Reemplazamos el nodo por su hijo si existe
                    temp = null;  // Eliminamos la referencia al nodo original
                }
            }
        }

        // METODO PARA ENCONTRAR EL NODO MAS PEQUEÑO EN UN SUBARBOL
        public NodoBinario BuscaMenor(NodoBinario nodo)
        {
            while (nodo.Izq != null)
            {
                nodo = nodo.Izq;  // Recorremos hacia la izquierda
            }
            return nodo;  // Retornamos el nodo mas pequeño
        }


        // METODO PARA ENCONTRAR EL NODO MAYOR 
        public NodoBinario Mayor(NodoBinario nodo)
        {
            if (nodo == null)
                return null;
            else if (nodo.Der == null)
                return nodo;
            else
                return Mayor(nodo.Der);
        }




        public void EliminarPred(int x, ref NodoBinario nodo)
        {




            if (nodo == null)
                return;

            if (x < nodo.Dato)
                EliminarPred(x, ref nodo.Izq);
            else if (x > nodo.Dato)
                EliminarPred(x, ref nodo.Der);
            else // Encontró el nodo a eliminar
            {
                // Caso 1: El nodo tiene dos hijos
                if (nodo.Izq != null && nodo.Der != null)
                {
                    NodoBinario mayor = Mayor(nodo.Izq);
                    nodo.Dato = mayor.Dato;
                    EliminarPred(mayor.Dato, ref nodo.Izq);
                }
                // Caso 2: El nodo tiene un solo hijo o ninguno
                else
                {
                    // Detecta si el nodo a eliminar es la raíz
                    if (nodo == Raiz)
                    {
                        if (nodo.Izq != null)
                            Raiz = nodo.Izq;
                        else if (nodo.Der != null)
                            Raiz = nodo.Der;
                        else
                            Raiz = null;
                    }

                    // Elimina el nodo y actualiza la referencia
                    NodoBinario temp = nodo;
                    if (nodo.Izq == null)
                        nodo = nodo.Der;
                    else if (nodo.Der == null)
                        nodo = nodo.Izq;

                    temp = null;
                }
            }
        }




        public bool lleno(NodoBinario nodo)
        {

            if (nodo == null)
                return true;

            // Si el nodo es una hoja también se considera lleno
            if (nodo.Izq == null && nodo.Der == null)
                return true;

            // Si el nodo tiene ambos hijos se revisa que ambos subarboles tambien sean llenos
            if (nodo.Izq != null && nodo.Der != null)
                return lleno(nodo.Izq) && lleno(nodo.Der);


            return false;
        }

        public void MuestraArbolAcostado(int nivel, NodoBinario nodo)
        {
            if (nodo == null)
                return;
            MuestraArbolAcostado(nivel + 1, nodo.Der);
            for (int i = 0; i < nivel; i++)
            {
                strArbol = strArbol + "      ";
            }
            strArbol = strArbol + nodo.Dato.ToString() + "\r\n";
            MuestraArbolAcostado(nivel + 1, nodo.Izq);
        }

        public String ToDot(NodoBinario nodo)
        {
            StringBuilder b = new StringBuilder();
            if (nodo.Izq != null)
            {
                b.AppendFormat("{0}->{1} [side=L] {2} ", nodo.Dato.ToString(), nodo.Izq.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Izq));
            }

            if (nodo.Der != null)
            {
                b.AppendFormat("{0}->{1} [side=R] {2} ", nodo.Dato.ToString(), nodo.Der.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Der));
            }
            return b.ToString();
        }




        public bool EsCompleto(NodoBinario raiz)
        {
            if (raiz == null)
                return true;  // Un árbol vacío es considerado completo

            // Contamos el número total de nodos
            int totalNodos = ContarNodos(raiz);

            // Usamos una cola para el recorrido en amplitud
            Queue<NodoBinario> cola = new Queue<NodoBinario>();
            cola.Enqueue(raiz);

            int indice = 0;  // Usamos un índice para verificar la posición de los nodos

            while (cola.Count > 0)
            {
                NodoBinario nodo = cola.Dequeue();

                // Si el índice del nodo es mayor o igual al número total de nodos, significa que
                // el árbol no es completo 
                if (nodo != null)
                {
                    if (indice >= totalNodos)
                        return false;

                    // Encolamos los hijos del nodo
                    cola.Enqueue(nodo.Izq);
                    cola.Enqueue(nodo.Der);
                }

                indice++;  // Aumentamos el índice del nodo actual
            }

            return true;  // Si hemos recorrido todos los nodos correctamente, el árbol es completo
        }

        // Función auxiliar para contar el número de nodos en el árbol
        private int ContarNodos(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;

            // Recursivamente contamos los nodos en el árbol
            return 1 + ContarNodos(nodo.Izq) + ContarNodos(nodo.Der);
        }





        public int hojas(NodoBinario nodo)
        {

            if (nodo == null)
                return 0;

            // Si el nodo es una hoja no tiene hijos 
            if (nodo.Izq == null && nodo.Der == null)
                return 1;

            // Sumar las hojas 
            return hojas(nodo.Izq) + hojas(nodo.Der);
        }



        public int numNodos(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;

            return 1 + numNodos(nodo.Izq) + numNodos(nodo.Der);
        }


        public int altura(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;

            // calcula la altura de los subarboles izquierdo y derecho
            int alturaIzquierda = altura(nodo.Izq);
            int alturaDerecha = altura(nodo.Der);
            return 1 + Math.Max(alturaIzquierda, alturaDerecha);
        }



      



            // Obtener la altura del árbol (número de niveles)
            private int ObtenerAltura(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;
            int alturaIzq = ObtenerAltura(nodo.Izq);
            int alturaDer = ObtenerAltura(nodo.Der);
            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        // Mostrar los nodos de un nivel específico
        private void MostrarNivel(NodoBinario nodo, int nivel)
        {
            if (nodo == null)
                return;

            if (nivel == 0)
            {
                // Imprimir el dato del nodo
                Console.Write(nodo.Dato + " ");
            }
            else
            {
                // Recursivamente mostrar los nodos de los niveles inferiores
                MostrarNivel(nodo.Izq, nivel - 1);
                MostrarNivel(nodo.Der, nivel - 1);
            }
        }
    




    public bool EsLleno(NodoBinario nodo)
        {
            // Si el nodo es null, se considera que el árbol es lleno
            if (nodo == null)
                return true;

            // Si el nodo es una hoja (no tiene hijos), también se considera lleno
            if (nodo.Izq == null && nodo.Der == null)
                return true;

            // Si el nodo tiene ambos hijos, revisamos que ambos subárboles también sean llenos
            if (nodo.Izq != null && nodo.Der != null)
                return EsLleno(nodo.Izq) && EsLleno(nodo.Der);

            // En cualquier otro caso, el árbol no es lleno
            return false;
        }




        public void PreOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            strRecorrido = strRecorrido + nodo.Dato + ", ";
            PreOrden(nodo.Izq);
            PreOrden(nodo.Der);
            
            return;
        }

        public void InOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            InOrden(nodo.Izq);
            strRecorrido = strRecorrido + nodo.Dato + ", ";
            InOrden(nodo.Der);

            return;
        }
        public void PostOrden(NodoBinario nodo )
        {
            if (nodo == null)
                return;

            PostOrden(nodo.Izq);
            PostOrden(nodo.Der);
            strRecorrido = strRecorrido + nodo.Dato + ", ";

            return;
         }
        public bool Buscar(int valor, NodoBinario nodo)
        {
            if (nodo == null)
                return false;

            if (nodo.Dato == valor)
                return true;

            if (valor < nodo.Dato)
                return Buscar(valor, nodo.Izq);

            else
                return Buscar(valor, nodo.Der);

        }
        public void Muestra(int nivel, NodoBinario nodo)
        {
            if (nodo == null)
                return;
            Muestra(nivel + 1, nodo.Der);
            for (int i = 0; i < nivel; i++)
            {
                strArbol = strArbol + "     ";
            }
            strArbol = strArbol + nodo.Dato.ToString() + "\r\n";
            Muestra(nivel + 1, nodo.Izq);
        }


    }
}
