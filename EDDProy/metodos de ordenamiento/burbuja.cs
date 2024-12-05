using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.metodos_de_ordenamiento
{
    public partial class burbuja : Form
    {
        public burbuja()
        {
            InitializeComponent();
        }
        private int[] arreglo;

        private int[] OrdenarConBurbuja(int[] arreglo, out List<string> pasos)
        {
            pasos = new List<string>();  // Lista para almacenar los pasos de la ordenación
            int n = arreglo.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arreglo[j] > arreglo[j + 1])
                    {
                        // Intercambiamos
                        int temp = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = temp;

                        // Agregar el estado actual del arreglo a los pasos
                        pasos.Add($"Paso {pasos.Count + 1}: {string.Join(", ", arreglo)}");
                    }
                }
            }

            return arreglo;
        }

        private int[] GenerarArreglo(int cantidad)
        {
            Random random = new Random();
            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = random.Next(1, 101);
            }

            return arreglo;
        }








        private void Crear_Click(object sender, EventArgs e)
        {

            int cantidad = (int)numericUpDown1.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad mayor a 0.");
                return;
            }

            arreglo = GenerarArreglo(cantidad);
            label2.Text = "Arreglo: " + string.Join(", ", arreglo);
        }


        private int[] Burbuja(int[] arreglo, out int pasos)
        {
            pasos = 0;
            int n = arreglo.Length;
            int[] arregloOrdenado = (int[])arreglo.Clone();  // Clona el arreglo para no modificar el original
            bool intercambiado;

            // Limpiar el texto de label3 antes de comenzar
            label3.Text = "Pasos de la ordenación:\n";

            for (int i = 0; i < n - 1; i++)
            {
                intercambiado = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    pasos++;  // Incrementa el contador de pasos

                    // Si el elemento actual es mayor que el siguiente, intercambiarlos
                    if (arregloOrdenado[j] > arregloOrdenado[j + 1])
                    {
                        int temp = arregloOrdenado[j];
                        arregloOrdenado[j] = arregloOrdenado[j + 1];
                        arregloOrdenado[j + 1] = temp;
                        intercambiado = true;
                    }

                    // Mostrar el paso intermedio en label3
                    label3.Text += "Paso " + pasos + ": " + string.Join(", ", arregloOrdenado) + "\n";
                }

                // Si no hubo intercambios, el arreglo ya está ordenado
                if (!intercambiado)
                {
                    break;
                }
            }

            return arregloOrdenado;
        }














        private void Ordenar_Click(object sender, EventArgs e)
        {
            if (arreglo == null || arreglo.Length == 0)
            {
                MessageBox.Show("Primero crea un arreglo.");
                return;
            }

            // Mostrar el arreglo original en el Label3
            label3.Text = "Arreglo Original: " + string.Join(", ", arreglo);

            // Ordenar el arreglo usando el método OrdenarConBurbuja
            List<string> pasos;
            int[] arregloOrdenado = OrdenarConBurbuja(arreglo, out pasos);

            // Mostrar el arreglo ordenado en el Label3
            label1.Text = "Arreglo Ordenado: " + string.Join(", ", arregloOrdenado);

            // Mostrar los pasos realizados en el Panel1
            label3.Text = "Pasos realizados:\n" + string.Join("\n", pasos);
        }

        private void burbuja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpiar los resultados de los labels y el panel
            label2.Text = "";
            label3.Text = "";
            label1.Text = "";

            // Reiniciar el arreglo
            arreglo = null;
        }
    }
    }
    

