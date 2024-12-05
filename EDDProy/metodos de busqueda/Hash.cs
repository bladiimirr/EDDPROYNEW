using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.metodos_de_busqueda
{
    public partial class Hashform : Form
    {
        private HashTabla tablaHash;

        public Hashform()
        {

            tablaHash = new HashTabla();
            InitializeComponent();


        }

        private void ActualizarValores()
        {
            StringBuilder valoresTexto = new StringBuilder();

            // Recorremos todas las claves y valores
            for (int i = 0; i < HashTabla.TAMANIO; i++) 
            {
                if (tablaHash.claves[i] != -1) // Verificamos si la posiicion tiene datos
                {
                    // Agregar la clave y valor al StringBuilder
                    valoresTexto.AppendLine($"clave: {tablaHash.claves[i]}" + $" - Valor: {tablaHash.valores[i]}");
                }
            }

            lblValores.Text = valoresTexto.ToString();
        }

        private void Hash_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtClave.Text, out int clave) && !string.IsNullOrEmpty(txtValor.Text))
            {
                tablaHash.Insertar(clave, txtValor.Text); 
                MessageBox.Show("Dato insertado correctamente.");
                txtClave.Clear(); 
                txtValor.Clear(); 

             
                ActualizarValores();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una clave válida y un valor.");
            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtClave.Text, out int clave))
            {
                string resultado = tablaHash.Buscar(clave); // Buscar en la tabla hash
                lblResultado.Text = resultado != null ? $"Valor encontrado: {resultado}" : "Clave no encontrada.";
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una clave valida.");
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblValores_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtClave.Clear();
            txtValor.Clear();

            // Limpiar el Label que muestra los valores de la tabla hash
            lblValores.Text = string.Empty;
        }
    }
}