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
    public partial class binaria : Form
    {

        private int[] claves = { 100, 200, 300, 400 };
        private string[] valores = { "Valor 1", "Valor 2", "Valor 3", "Valor 4" };
        public binaria()
        {
            InitializeComponent();
        }


        private string BuscarBinaria(int[] claves, string[] valores, int claveBuscada)
        {
            int izquierda = 0;
            int derecha = claves.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;

                if (claves[medio] == claveBuscada)
                {
                    return valores[medio]; 
                }
                else if (claves[medio] < claveBuscada)
                {
                    izquierda = medio + 1; 
                }
                else
                {
                    derecha = medio - 1; // Buscamos en la mitad izquierda
                }
            }
            return "Clave no encontrada"; // Si no se encuentra la clave
        }



        private void binaria_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtClave.Text, out int claveBuscada)) // Intentamos convertir el texto a número
            {
                string resultado = BuscarBinaria(claves, valores, claveBuscada); // Llamamos al método de búsqueda
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
            lblResultado.Text = ""; // Limpiamos el Label del resultado
        }
    }
}
