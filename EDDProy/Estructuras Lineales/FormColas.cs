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
    public partial class FormColas : Form
    {
        private Nodos first;
        private Nodos last;
        public FormColas()
        {
            InitializeComponent();
        }

        private void FormColas_Load(object sender, EventArgs e)
        {

        }


        private void enqueue(int Dato)
        {
            Nodos Nuevo = new Nodos();//instancia
            Nuevo.Dato = Dato;//asignar al nuevo nodo 
            Nuevo.Sig = null;// el siguinte es null
            if (last == null)
            {
                last = Nuevo;
                first = Nuevo;
            }
            else
            {
                last.Sig = Nuevo;
                last = Nuevo;
            }

        }
       private int Dequeue()
        {
            if (first == null)
            {
                MessageBox.Show("Cola vasia");
                return -1;
            }
            else
            {
                Nodos Aux = first;
                first = Aux.Sig;
                int Dato = Aux.Dato;
                Aux = null;
                if (first == null)
                {
                    last = null;
                }
                return Dato;
            }
        }

       













        private void button1_Click(object sender, EventArgs e)
        {
            int valor;

            // Intentar convertir el texto ingresado a un entero
            if (int.TryParse(textBox1.Text, out valor))
            {
                enqueue(valor); // Encola el valor
                listBox1.Items.Add(valor); // Agrega el valor a la lista de impresión
            }
            else
            {
                // Mostrar mensaje de error si el valor ingresado no es un número
                MessageBox.Show("Por favor, ingrese un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar el campo de texto y devolver el foco
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int valor = Dequeue();
            if (valor != -1)
            {
                MessageBox.Show("se a eliminado el\n" + valor+"");
                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.RemoveAt(0);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            first = null;
            last = null;
            MessageBox.Show("se a vaciado la cola ");
            listBox1.Items.Clear();
        }







        public void buscar()
        {
            Nodos act = new Nodos();
            act = first;
            bool enc = false;
            int valor;
            int.TryParse(textBox1.Text, out valor);
            if (first != null)
            {
                while (act != null && enc != true)
                {
                    if (act.Dato == valor)
                    {
                        MessageBox.Show("El dato " + valor + " fue encontrado");
                        enc = true;
                    }
                    act = act.Sig;
                }
                if (!enc)
                {
                    MessageBox.Show("no se a encontrado");
                }
            }
            else
            {
                MessageBox.Show("la cola se encuentra vacia");
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            buscar();
            textBox1.Text = "";

            textBox1.Focus();
        }








        public int contar()
        {
            int cont = 0;
            Nodos nodo = first;
            while (nodo != null)
            {
                cont++;
                nodo = nodo.Sig;
            }
            return cont;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hay " + contar() + " datos");

        }
    }
}
