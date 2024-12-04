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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDDemo.Recursividad
{
    public partial class busquedabin : Form
    {

        private int[] valoresinc; // Almacena los números generados
      //  private BusquedaBin busquedaBin;
        public busquedabin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la cantidad de números desde el NumericUpDown
                int cantidad = (int)numericUpDown1.Value;

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad de números debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una instancia de Random para generar números aleatorios
                Random random = new Random();
                int[] numeros = new int[cantidad];

                // Generar los números aleatorios entre 1 y 100
                for (int i = 0; i < cantidad; i++)
                {
                    numeros[i] = random.Next(1, 201);
                }

                // Ordenar los números generados
                Array.Sort(numeros);

                // Mostrar los números ordenados en el Label
                label1.Text = string.Join(", ", numeros);

                // Guardar los números generados en una variable global para su uso posterior
                valoresinc = numeros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que hay números generados
                if (valoresinc == null || valoresinc.Length == 0)
                {
                    MessageBox.Show("Primero genere la lista de números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el número a buscar desde la TextBox
                if (!int.TryParse(textBox1.Text, out int numero))
                {
                    MessageBox.Show("Por favor, ingrese un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                


              

                // Realizar la búsqueda binaria
                int posicion = busquedabin.Buscar(valoresinc, numero, 0, valoresinc.Length - 1 );

                

                // Mostrar los resultados
                if (posicion != -1)
                {
                    MessageBox.Show("Número encontrado en posición: " + posicion + " (como arreglo)");
                }
                else
                {
                    MessageBox.Show("Número no encontrado.");
                }

               
             
             
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public static int Buscar(int[] arreglo, int numero, int inicio, int fin)
        {
            

            // Caso base: el rango de búsqueda es inválido
            if (inicio > fin)
            {
                return -1; // No encontrado
            }

            // Calcular el punto medio
            int medio = (inicio + fin) / 2;

            // Si el número está en el medio
            if (arreglo[medio] == numero)
            {
                return medio; // Retornar la posición
            }

            // Si el número buscado es menor, buscar en la mitad izquierda
            if (numero < arreglo[medio])
            {
                return Buscar(arreglo, numero, inicio, medio - 1);
            }

          
            return Buscar(arreglo, numero, medio + 1, fin);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
