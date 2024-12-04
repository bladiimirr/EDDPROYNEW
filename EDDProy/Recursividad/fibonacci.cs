using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Recursividad
{
    public partial class fibonacci : Form
    {
        public fibonacci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            
                int posicion = int.Parse(textBox1.Text);

              
                if (posicion < 0)
                {
                    MessageBox.Show("Por favor, introduce un valor positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Si la posición es negativa, sale del método sin calcular
                }

                // Calcular el número de Fibonacci usando recursividad
                int resultado = CalcularFibonacci(posicion);

                // Mostrar el resultado en el Label
                label3.Text = $"Fibonacci de {posicion} es: {resultado}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce un valor valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int CalcularFibonacci(int n)
        {
            if (n <= 0) return 0; 
            if (n == 1) return 1; 

            // Llamadas recursivas
            return CalcularFibonacci(n - 1) + CalcularFibonacci(n - 2);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
