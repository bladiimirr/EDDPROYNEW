using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Recursividad
{
    public partial class exponencial : Form
    {
        public exponencial()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumero.Text, out double baseNum) && double.TryParse(textBox2.Text, out double exponente))
            {
                double resultado = CalcularExponente(baseNum, exponente); // Calcula el exponente
                lblResultado.Text = $"{baseNum} elevado a la potencia {exponente} es: {resultado}"; // Muestra el resultado
            }
            else
            {
                MessageBox.Show("ingresa un número válido para la base y el exponente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            txtNumero.Clear();
            textBox2.Clear();
            txtNumero.Focus();
        }
        private double CalcularExponente(double baseNum, double exponente)
        {
            return Math.Pow(baseNum, exponente);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exponencial_Load(object sender, EventArgs e)
        {

        }
    }
}
