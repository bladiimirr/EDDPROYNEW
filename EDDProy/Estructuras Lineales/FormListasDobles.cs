using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static EDDemo.frmPilas;

namespace EDDemo.Estructuras_Lineales
{
    public partial class FormListasDobles : Form
    {
        private Nodos inicial;
        private Nodos final;
        public FormListasDobles()
        {
            InitializeComponent();
        }




        private void button7_Click(object sender, EventArgs e)
        {
            int valor, x;

            if (int.TryParse(textBox2.Text, out valor) && int.TryParse(txtpos.Text, out x))
            {
                Insertar(x, valor); // Se cambia "incertar" a "Insertar" para corregir el error de ortografía
                Ver(); // Se cambia "ver()" a "Ver()" para seguir la convención de mayúsculas en métodos
            }
            else
            {
                MessageBox.Show("Se requiere ingresar un dato y una posición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar los campos y enfocar el primer campo para que el usuario continúe de manera fluida
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

        private void button3_Click(object sender, EventArgs e)
        {
            /*
                     
                  {
                      Me
  mpo para una ex(); 
              txtpos.Focus(); 
          }*/



            int posicion;

            
            if (int.TryParse(txtpos.Text, out posicion) && posicion > 0)
            {
                int eliminado = Eliminar(posicion); // Llamar al método Eliminar con la posición indicada
                if (eliminado != -1) // Verificar que el nodo fue eliminado correctamente
                {
                    MessageBox.Show($"Dato eliminado: {eliminado}", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Ver(); // 
                }
            }
            else
            {
                // 
                MessageBox.Show("Ingresa una posición válida mayor a 0.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar el campo de posición para permitir una nueva entrada
            txtpos.Clear();
            txtpos.Focus();


        }




        private int Eliminar(int posicion)
        {
            if (inicial == null)
            {
                MessageBox.Show("La lista está vacía.");
                return -1;
            }

            // Manejo especial para la eliminación del primer nodo
            if (posicion == 1)
            {
                int dato = inicial.Dato;
                inicial = inicial.Sig;

                // 
                if (inicial != null)
                {
                    inicial.prev = null;
                }
                else
                {
                    // Si la 
                    final = null;
                }

                return dato;
            }

            Nodos aux = inicial;
            int pos = 1;

            
            while (aux != null && pos < posicion)
            {
                aux = aux.Sig;
                pos++;
            }

            if (aux == null)
            {
                MessageBox.Show("No se encontró un nodo en esa posición.");
                return 0;
            }

            
            int eliminado = aux.Dato;

          
            if (aux.Sig == null)
            {
                final = aux.prev;
                final.Sig = null;
            }
           
            else
            {
                aux.prev.Sig = aux.Sig;
                aux.Sig.prev = aux.prev;
            }

           
            aux = null;

            return eliminado;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inicial = null;
            final = null;   
            listBox1.Items.Clear(); 
            MessageBox.Show("La lista ha sido vaciada exitosamente.", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad = contar(); 

            if (cantidad != 0)
            {
                MessageBox.Show($"Hay {cantidad} datos en la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La lista está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public int contar()
        {
            if (inicial == null)
            {
                MessageBox.Show("la lista esta vacia");
                return 0;
            }
            int cont = 0;
            Nodos nodo = inicial;
            while (nodo != null)
            {
                cont++;
                nodo = nodo.Sig;
            }
            return cont;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Limpiar la lista de impresion antes de mostrar los datos
            listBox1.Items.Clear();

            if (final == null)
            {
                MessageBox.Show("La lista está vacía, no hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Recorrer la lista desde el final hacia el principio
            Nodos actual = final;
            while (actual != null)
            {
                listBox1.Items.Add(actual.Dato);
                actual = actual.prev;
            }

            // Mensaje opcional para confirmar que los datos se han cargado
            MessageBox.Show("Datos cargados correctamente en orden inverso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verificar si la lista está vacía
            if (inicial == null)
            {
                MessageBox.Show("La lista está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!int.TryParse(textBox2.Text, out int valor))
            {
                MessageBox.Show("Por favor, ingresa un valor valido para buscar.", "Entrada Invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicializar nodo actual y bandera de encontrado
            Nodos actual = inicial;
            bool encontrado = false;

            // Recorrer la lista en busca del valor
            while (actual != null && !encontrado)
            {
                if (actual.Dato == valor)
                {
                    MessageBox.Show($"El nodo con el dato {valor} fue encontrado.", "Nodo Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    encontrado = true;
                }
                actual = actual.Sig;
            }

            // Si no se encontrel valor, mostrarm ensaje
            if (!encontrado)
            {
                MessageBox.Show($"El dato {valor} no fue encontrado en la lista.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
    


