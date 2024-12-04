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
    public partial class FormRecursividad : Form
    {
        public FormRecursividad()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int numero) && numero >= 0)
            {
                long resultado = CalcularFactorial(numero);
                lblResultado.Text = $"El factorial de {numero} es: {resultado}";
            }
            else
            {
                MessageBox.Show("Ingresa un valor entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar la entrada y devolver el foco
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private long CalcularFactorial(int n)
        {
            long factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
