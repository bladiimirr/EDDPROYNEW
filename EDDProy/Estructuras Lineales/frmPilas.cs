using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using EDDemo.Clases;

namespace EDDemo
{
   



    public partial class frmPilas : Form
    {
        private Nodos Top;
        public frmPilas()
        {
            InitializeComponent();
            Top = null; // la pila inicia estando vacia
        }




        private void Push(int Dato)
        {
            Nodos Nuevo = new Nodos();
            Nuevo.Dato = Dato;//asignar al nuevo nodo 
            Nuevo.Sig = null;// el siguinte es null

            //metodo if 
            if (Top == null)//si la pila esta vacia 
            {
                Top = Nuevo;//el nuevo nodo es el tope de la pila
            }
            else
            {
                Nodos Aux = Top;
                Top = Nuevo;
                Top.Sig = Aux;
            }
        }



        public class Nodos
        {
            public int Dato;//valor del nodo 
            public Nodos Sig;//apuntador 
            public Nodos prev;
        }


        public int Pop()
        {
            if (Top == null)
            {
                MessageBox.Show("LA PILA ESTA VACIA");
                return -1;
            }
            else
            {
                Nodos Aux = Top;
                int Dato = Aux.Dato;
                Top = Top.Sig;
                Dato = Aux.Dato;
                Aux = null;
                return Dato;
            }
        }


        private void btnPush_Click(object sender, EventArgs e)
        {
            int valor;
            if (int.TryParse(textBox1.Text, out valor))//asegura que el dato sea de tiop int 
            {
                Push(valor);
                listBox1.Items.Add(valor);
            }
            else
            {
                MessageBox.Show("se requiere ingresar un numero");
            }

            textBox1.Text = "";//blanquea el ingreso de los dATOS 
            textBox1.Focus();//para no volver a hacer clic eb la barra           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Top = null;
            MessageBox.Show("SE LIMPIO LA PILA");
            listBox1.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int contar()
        {
            int cont = 0;
            Nodos nodo = Top;
            while (nodo != null)
            {
                cont++;
                nodo = nodo.Sig;
            }
            return cont;
        }




        private void button4_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("EXISTEN " + contar() + " ELEMENTOS EN LA PILA");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor = Pop();
            if (valor != -1)
            {
                MessageBox.Show("SE HA ELIMINADO EL "+valor+ "\n CORRECTAMENTE DE LA PILA");
                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                }
            }
        }
        public void buscar()
        {
            Nodos x = new Nodos();
            x = Top;
            bool enc = false;
            int valor;
            int.TryParse(textBox1.Text, out valor);
            if (Top != null)
            {
                while (x != null && enc != true)
                {
                    if (x.Dato == valor)
                    {
                        MessageBox.Show(" El dato " + valor + " fue encontrado en la pila");
                        enc = true;
                    }
                    x = x.Sig;
                }
                if (!enc)
                {
                    MessageBox.Show("no se encontro en la pila");
                }
            }
            else
            {
                MessageBox.Show("la pila se encuentra vacia");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            buscar();
            listBox1.Text = "";

            listBox1.Focus();//evitar cliquear la barra de texto nuevamente
        }

    }
}
