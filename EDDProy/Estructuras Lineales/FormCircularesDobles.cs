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

        private void button1_Click(object sender, EventArgs e)
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

    }
}
