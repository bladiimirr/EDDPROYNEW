using System;
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
    public partial class secuencial : Form
    {


        private int[] claves = { 100, 102, 103, 104 };
        private string[] valores = { "Valor 1", "Valor 2", "Valor 3", "Valor 4" };



        public secuencial()
        {
            InitializeComponent();
        }



        private string BuscarSecuencial(int[] claves, string[] valores, int claveBuscada)
        {
            for (int i = 0; i < claves.Length; i++)
            {
                if (claves[i] == claveBuscada)
                {
                    return valores[i]; // Devuelve el valor correspondiente a la clave
                }
            }
            return "Clave no encontrada"; // Si no se encuentra la clave
        }




        private void secuencial_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtClave.Text, out int claveBuscada)) // Intentamos convertir el texto a número
            {
                string resultado = BuscarSecuencial(claves, valores, claveBuscada); // Llamamos al método de búsqueda
                lblResultado.Text = resultado; // Mostramos el resultado en el Label
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una clave válida.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtClave.Clear(); // Limpiamos el TextBox de la clave
            lblResultado.Text = ""; // Limpiamos el Label del resultad
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
