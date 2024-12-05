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
    public partial class FormlistaDoble : Form
    {
        private Nodos inicial;
        private Nodos final;
        public FormlistaDoble()
        {
            InitializeComponent();
        }



        private void IngresarEnLista(int dato, int posicion)
        {
            Nodos nuevo = new Nodos();
            nuevo.Dato = dato;

            // Caso 1: La lista está vacía
            if (inicial == null)
            {
                inicial = nuevo;
                final = nuevo;
                nuevo.Sig = inicial;  // Cerrar el ciclp
                nuevo.prev = inicial; // El nodo apunta a si mismo
                return;
            }

            // Caso 2: Insertar al principio (posición 1)
            if (posicion == 1)
            {
                nuevo.Sig = inicial;
                nuevo.prev = final;
                inicial.prev = nuevo;
                final.Sig = nuevo;
                inicial = nuevo;
                return;
            }

            Nodos aux = inicial;
            int posActual = 1;

            // Recorrer la lista hasta la posición deseada (exclusiva) o llegar al final
            while(posActual < posicion - 1 && aux.Sig != inicial)
            {
                aux = aux.Sig;
                posActual++;
            }

            // Caso 3: Insertar al final de la lista
            if (aux == final || aux.Sig == inicial)
            {
                nuevo.Sig = inicial;   // Cerrar el ciclo
                nuevo.prev = final;
                final.Sig = nuevo;
                inicial.prev = nuevo;
                final = nuevo;
            }
            // Caso 4: Insertar en una posición intermedia
            else
            {
                nuevo.Sig = aux.Sig;
                nuevo.prev = aux;
                aux.Sig.prev = nuevo;
                aux.Sig = nuevo;
            }
        }


        private void MostrarLista()
        {
         
            listBox1.Items.Clear();

            if (inicial == null)
            {
                
                MessageBox.Show("La lista está vacía. No hay elementos para mostrar.", "Lista Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nodos actual = inicial;
            do
            {
                
                listBox1.Items.Add(actual.Dato);
                actual = actual.Sig;
            } while (actual != inicial);  
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int valor, posicion;

            // Intentar convertir los valores de los campos de texto en enteros
            if (int.TryParse(textBox2.Text, out valor) && int.TryParse(txtpos.Text, out posicion))
            {
                // Verificar si la posición es válida (mayor que 0)
                if (posicion > 0)
                {
                    IngresarEnLista(valor, posicion); // Llamar al método de inserción
                    MostrarLista(); // Actualizar la vista de la lista
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa una posición válida mayor que 0.", "Posición no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Mostrar mensaje si no se ingresaron valores válidos
                MessageBox.Show("Por favor, ingresa un dato numérico y una posición válida.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar los campos de texto para el próximo ingreso
            textBox2.Clear();
            txtpos.Clear();
            textBox2.Focus();

        }

        private void Ver()
        {
            listBox1.Items.Clear();
            if (inicial == null)
            {
                return; // Si la lista está vacía
            }

            Nodos actual = inicial;

            while (actual != null)
            {
                listBox1.Items.Add(actual.Dato);
                actual = actual.Sig;
            }
        }

        private void Insertar(int posicion, int Dato)
        {
            Nodos Nuevo = new Nodos();//instancia
            Nuevo.Dato = Dato;//asignar al nuevo nodo 
            Nuevo.Sig = null;// el siguinte es null
            Nuevo.prev = null;

            if (inicial == null && final == null)
            {
                inicial = Nuevo;
                final = Nuevo;
                return;
            }
            if (posicion == 0 || posicion == 1)
            {
                Nuevo.Sig = inicial;
                inicial.prev = Nuevo;
                inicial = Nuevo;
                return;
            }
            Nodos Aux = inicial;
            int pos = 1;

            while (pos < posicion - 1 && Aux.Sig != null)
            {
                Aux = Aux.Sig;
                pos++;
            }

            // Insertar en la posición intermedia
            if (Aux.Sig != null)
            {
                Nuevo.Sig = Aux.Sig;
                Aux.Sig.prev = Nuevo;
                Aux.Sig = Nuevo;
                Nuevo.prev = Aux;
            }
            // Insertar al final de la lista
            else
            {
                final.Sig = Nuevo;
                Nuevo.prev = final;
                final = Nuevo;
            }
        }



        private int Eliminar(int posicion)
        {
            // Verificar si la lista está vacía
            if (inicial == null || final == null)
            {
                MessageBox.Show("La lista está vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indicar que no se pudo eliminar porque la lista está vacía
            }

            Nodos Aux = inicial;
            Nodos prev = null;
            int Dato;

            // Si se va a eliminar el primer nodo
            if (posicion == 1)
            {
                Dato = Aux.Dato;

                if (inicial == final) // Si la lista tiene solo un elemento
                {
                    inicial = null;
                    final = null;
                }
                else // Si la lista tiene más de un elemento
                {
                    inicial = inicial.Sig;
                    inicial.prev = final;
                    final.Sig = inicial;
                }

                return Dato;
            }

            // Si no es el primer nodo, buscar la posición
            int pos = 1;
            do
            {
                prev = Aux;
                Aux = Aux.Sig;
                pos++;
            } while (pos < posicion && Aux != inicial); // Recorre hasta encontrar la posición o volver al inicio

            // Si se encontró la posición
            if (Aux != inicial)
            {
                Dato = Aux.Dato;

                // Si es el último nodo
                if (Aux == final)
                {
                    final = prev;
                    final.Sig = inicial;
                    inicial.prev = final;
                }
                else // Si es un nodo intermedio
                {
                    prev.Sig = Aux.Sig;
                    Aux.Sig.prev = prev;
                }

                return Dato;
            }
            else // Si no se encontró la posición
            {
                MessageBox.Show("No se encontró la posición especificada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }













        private void button3_Click(object sender, EventArgs e)
        {
            int posicion;

            if (int.TryParse(txtpos.Text, out posicion) && posicion > 0) 
            {
               
                int eliminado = Eliminar(posicion);

                if (eliminado != -1) 
                {
                    MessageBox.Show($"Dato eliminado: {eliminado}", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Ver(); 
                }
                else
                {
                    MessageBox.Show("No se encontró un dato en la posición especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una posición válida mayor a 0.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar y enfocar el campo de texto después de la operación
            txtpos.Text = "";
            txtpos.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inicial = null;
            final = null;
            listBox1.Items.Clear();
            MessageBox.Show("la lista se a vaciado correctamente");
        }



        private int contar()
        {
            if (inicial == null)
            {
                return 0; // Si la lista está vacía, devolvemos 0 sin necesidad de mostrar un MessageBox
            }

            int cont = 1; // Comenzamos el conteo desde 1 porque ya estamos en el primer nodo
            Nodos nodo = inicial.Sig; // Comenzamos desde el segundo nodo

            while (nodo != inicial)
            {
                cont++;
                nodo = nodo.Sig;
            }

            return cont;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad = contar(); // Guardamos el resultado de conta() en una variable

            if (cantidad > 0)
            {
                MessageBox.Show("Hay " + cantidad + " datos");
            }
            else
            {
                MessageBox.Show("La lista está vacía");
            }

            if (inicial == null)
            {
                MessageBox.Show("la lista esta vacia");
               

            }
            


        }
    }
}
