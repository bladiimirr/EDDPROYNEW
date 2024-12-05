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





        private int[] GenerarArreglo(int cantidad)
        {
            Random random = new Random();  // Instancia del generador de números 
            int[] arreglo = new int[cantidad];  // Crea un arreglo del tamaño indicado

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = random.Next(1, 101); // Genera números aleatorios entre 1 y 100
            }

            return arreglo;
        }







        private void Crear_Click(object sender, EventArgs e)
        {

            int cantidad = (int)numericUpDown1.Value;  // Obtiene la cantidad seleccionada por el usuario

            // Validación para evitar que el número de elementos sea 0 o negativo
            if (cantidad <= 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad mayor a 0.");
                return;
            }

            // Generar el arreglo con números aleatorios
            arreglo = GenerarArreglo(cantidad);

            // Mostrar el arreglo en Label2
            label2.Text = "Arreglo: " + string.Join(", ", arreglo);
        }


        private int[] Burbuja(int[] arreglo, out int pasos)
        {
            pasos = 0;
            int n = arreglo.Length;
            int[] arregloOrdenado = (int[])arreglo.Clone();  // Clona el arreglo para no modificar el original
            bool intercambiado;

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

                    // Muestra los pasos intermedios en el Panel1
                    panel1.Text += "\nPaso " + pasos + ": " + string.Join(", ", arregloOrdenado);
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

            // Ordenar el arreglo usando el método Burbuja
            int[] arregloOrdenado = Burbuja(arreglo, out int pasos);

            // Mostrar el arreglo ordenado en el Label3
            label3.Text = "Arreglo Ordenado: " + string.Join(", ", arregloOrdenado);

            // Mostrar el número de pasos realizados en el Panel1
            panel1.Text = "Pasos realizados: " + pasos;
        }
    }
    }
    

