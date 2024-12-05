using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EDDemo.frmPilas;

namespace EDDemo.Estructuras_Lineales
{
    public partial class FormCirculares : Form
    {

        private Nodos inicial;
        private Nodos final;
        Nodos prev = null;


        public FormCirculares()
        {

            InitializeComponent();
        }



        private void Insertar(int dato, int posicion)
        {
            Nodos nuevo = new Nodos
            {
                Dato = dato,
                Sig = null
            };

            // Caso de lista vacía
            if (inicial == null && final == null)
            {
                inicial = nuevo;
                final = nuevo;
                nuevo.Sig = inicial; // Mantener el ciclo cerrado
                return;
            }

            // Caso: Insertar al inicio (posición 1)
            if (posicion <= 1)
            {
                // Si hay más de un nodo, insertar al inicio correctamente
                nuevo.Sig = inicial;
                inicial = nuevo;
                final.Sig = inicial; // Mantener el ciclo cerrado
                return;
            }

            int posActual = 1;
            Nodos aux = inicial;
            Nodos prev = null;

            // Recorrer la lista hasta encontrar la posición
            while (posActual < posicion && aux != final)
            {
                prev = aux;
                aux = aux.Sig;
                posActual++;
            }

            // Caso: Insertar en una posición intermedia
            if (aux != final)
            {
                nuevo.Sig = aux;
                prev.Sig = nuevo;
            }
            // Caso: Insertar al final
            else
            {
                nuevo.Sig = inicial;
                final.Sig = nuevo;
                final = nuevo;
            }
        }










        /*
            

             // Caso: Insertar en una posición intermedia
             if (aux != final)
             {
                 nuevo.Sig = aux;
                 prev.Sig = nuevo;
             }
             // Caso: Insertar al final
             else
             {
                 nuevo.Sig = inicial;
                 final.Sig = nuevo;
                 final = nuevo;
             }
         }*/

        private void actualizarLista()
        {
            listBox11.Items.Clear();

            // Validar si la lista está vacía
            if (inicial == null)
            {
                MessageBox.Show("La lista está vacía. No hay elementos para mostrar.", "Lista Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nodos actual = inicial;
            int indice = 1; // Para mostrar la posición del elemento (opcional)

            // Recorrer la lista circular
            do
            {
                listBox11.Items.Add($"Posición {indice}: {actual.Dato}");
                actual = actual.Sig;
                indice++;
            } while (actual != inicial);

            MessageBox.Show("Lista desplegada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int Eliminar(int posicion)
        {
            // Validar si la lista está vacía
            if (inicial == null)
            {
                MessageBox.Show("La lista está vacía. No hay elementos para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            Nodos actual = inicial;
            Nodos anterior = null;
            int dato;

            // Caso: Eliminar el primer nodo
            if (posicion == 1)
            {
                dato = actual.Dato;

                // Si solo hay un nodo en la lista
                if (inicial == final)
                {
                    inicial = null;
                    final = null;
                }
                else
                {
                    inicial = inicial.Sig; // Actualizar el inicio
                    final.Sig = inicial;    // Mantener el ciclo cerrado
                }

                MessageBox.Show($"Nodo con el dato {dato} eliminado de la posición {posicion}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dato;
            }

            int posActual = 1;

            // Recorrer la lista hasta la posición deseada
            do
            {
                anterior = actual;
                actual = actual.Sig;
                posActual++;
            } while (posActual < posicion && actual != inicial);

            // Verificar si se encontró el nodo en la posición indicada
            if (actual != inicial)
            {
                dato = actual.Dato;

                // Caso: Eliminar el último nodo
                if (actual == final)
                {
                    final = anterior;
                    final.Sig = inicial; // Mantener el ciclo cerrado
                }
                // Caso: Eliminar un nodo intermedio
                else
                {
                    anterior.Sig = actual.Sig;
                }

                MessageBox.Show($"Nodo con el dato {dato} eliminado de la posición {posicion}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dato;
            }
            else
            {
                MessageBox.Show($"No se encontró un nodo en la posición {posicion}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }




        private void button7_Click(object sender, EventArgs e)
        {
           int valor, posicion;

           
            if (int.TryParse(txtdato.Text, out valor) && int.TryParse(txtposision.Text, out posicion))
            {
                // Llamar al netodo insertar con los valores validados
                Insertar(valor, posicion);
                actualizarLista(); // Actualiza la vista
            }
            else
            {
                // Mostrar un mensaje más claro en caso de error
                MessageBox.Show("Por favor, ingresa un dato y una posición vclidae.", "Entrada invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar los campos de texto para el próximo ingreso de datos
            txtdato.Clear();
            txtposision.Clear();
            txtdato.Focus();





        }

        private int eliminar(int posicion)
        {

           
            if (inicial  == null && final == null)
            {
                MessageBox.Show("La lista esta vacia");
                return -1;
            }
            Nodos Aux = inicial;
            Nodos prev = null;
            int Dato;
            if (posicion == 1)
            {
                Dato = Aux.Dato;

                if (inicial == final)
                {
                    inicial = null;
                    final = null;

                }
                else
                {
                    inicial = inicial.Sig;
                    inicial.prev = final;
                    final.Sig = inicial;

                }
                return Dato;
            }
            int pos = 1;
            do
            {
                prev = Aux;
                Aux = Aux.Sig;
                pos++;
            } while (pos < posicion && Aux != inicial);
            if (Aux != inicial)
            {
                Dato = Aux.Dato;

                if (Aux == final)
                {
                    final= prev;
                    final.Sig = inicial;
                    inicial.prev = final;
                }
                else
                {
                    prev.Sig = Aux.Sig;
                    Aux.Sig.prev = prev;
                }

                return Dato;
            }
            else
            {
                MessageBox.Show("No se encontró la posición");
                return -1;
            }

        }






        private void button3_Click(object sender, EventArgs e)
        {
            int posicion;
            if (int.TryParse(txtposision.Text, out posicion) && posicion > 0) // Validar entrada y posición positiva
            {
                int datoEliminado = eliminar(posicion);
                if (datoEliminado != -1) // Verificar si se eliminó un dato
                {
                    MessageBox.Show("Dato eliminado: " + datoEliminado);
                    actualizarLista(); // Actualiza la lista visual
                }
                else
                {
                    MessageBox.Show("No se encontró un dato en la posición especificada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una posición válida mayor a 0.");
            }

            // Limpiar y enfocar el campo de texto
            txtposision.Text = "";
            txtposision.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                inicial = null;
                final = null;
                listBox11.Items.Clear();
                MessageBox.Show("la lista sea vaciado");
            
        }

        private int Contar()
        {
            // Verificar si la lista está vacía
            if (inicial == null)
            {
                MessageBox.Show("La lista está vacía.");
                return 0;
            }

            // Variable para contar los nodos
            int contador = 1; // Ya contamos el primer nodo (inicio)
            Nodos nodoActual = inicial.Sig;

            // Recorrer la lista circular comenzando desde el segundo nodo
            while (nodoActual != inicial)
            {
                contador++;
                nodoActual = nodoActual.Sig;
            }

            return contador;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (Contar() != 0)
            {
                Contar();
                MessageBox.Show("hay " + Contar() + " datos en la lista");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



        public void Buscar()
        {
            // Verificar si la lista está vacía
            if (inicial == null)
            {
                MessageBox.Show("La lista se encuentra vacía.");
                return;
            }

            // Intentar obtener el valor desde el TextBox
            if (!int.TryParse(txtdato.Text, out int valor))
            {
                MessageBox.Show("Por favor, ingresa un valor numerico valido.");
                return;
            }

            // Recorrer la lista circular buscndo e kvalor
            Nodos actual = inicial;
            do
            {
                if (actual.Dato == valor)
                {
                    MessageBox.Show("Dato encontrado");
                    return; // Salir al encontrar el valor
                }
                actual = actual.Sig;
            } while (actual != inicial);

            // Si no seencontro el valor
            MessageBox.Show("Dato no encontrado");
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Buscar();
            txtdato.Text = "";
            txtposision.Text = "";
            txtdato.Focus();
        }
    }
}
