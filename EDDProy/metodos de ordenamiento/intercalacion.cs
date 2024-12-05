using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.metodos_de_ordenamiento
{
    public partial class intercalacionmetodo : Form
    {
        public intercalacionmetodo()
        {
            InitializeComponent();
        }


        private int[] GenerarArreglo(int cantidad)
        {
            Random random1 = new Random(); // Instancia diferente para el primer arreglo
            Random random2 = new Random(); // Instancia diferente para el segundo arreglo
            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                // Aseguramos que cada arreglo use un generador distinto de números aleatorios
                if (i % 2 == 0)
                {
                    arreglo[i] = random1.Next(1, 101); // Genera números entre 1 y 100
                }
                else
                {
                    arreglo[i] = random2.Next(1, 101); // Genera números entre 1 y 100
                }
            }

            return arreglo;
        }





        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad = (int)numericUpDown1.Value;  // Obtiene la cantidad seleccionada por el usuario

            // Generar los dos arreglos con la cantidad seleccionada
            arreglo1 = GenerarArreglo(cantidad);
            arreglo2 = GenerarArreglo(cantidad);

            // Mostrar los arreglos generados en los labels
            label1.Text = "Arreglo 1: " + string.Join(", ", arreglo1);
            label2.Text = "Arreglo 2: " + string.Join(", ", arreglo2);
        
   
            }

        public int[] IntercalarArreglos(int[] arreglo1, int[] arreglo2, out int pasos)
        {
            int i = 0, j = 0, k = 0;
            int[] resultado = new int[arreglo1.Length + arreglo2.Length];
            pasos = 0;  // Inicializar el contador de pasos

            while (i < arreglo1.Length && j < arreglo2.Length)
            {
                pasos++;  // Incrementa el contador de pasos
                if (arreglo1[i] < arreglo2[j])
                {
                    resultado[k++] = arreglo1[i++];
                }
                else
                {
                    resultado[k++] = arreglo2[j++];
                }
            }

            // Copiar los elementos restantes
            while (i < arreglo1.Length)
            {
                pasos++;  // Incrementa el contador de pasos
                resultado[k++] = arreglo1[i++];
            }
            while (j < arreglo2.Length)
            {
                pasos++;  // Incrementa el contador de pasos
                resultado[k++] = arreglo2[j++];
            }

            return resultado;
        }




        private int[] arreglo1, arreglo2;



        private void button1_Click(object sender, EventArgs e)
        {
            if (arreglo1 == null || arreglo2 == null) // Verificamos si los arreglos no han sido creados
            {
                MessageBox.Show("Por favor, presiona 'Crear' antes de ordenar.");
                return;
            }

            // Ordenar ambos arreglos
            Array.Sort(arreglo1);
            Array.Sort(arreglo2);

            // Mostrar los arreglos ordenados en los labels
            label1.Text = "Arreglo 1 ordenado: " + string.Join(", ", arreglo1);
            label2.Text = "Arreglo 2 ordenado: " + string.Join(", ", arreglo2);

            // Intercalar los arreglos y contar los pasos
            int[] arregloIntercalado = IntercalarArreglos(arreglo1, arreglo2, out int pasos);

            // Mostrar los pasos realizados
            label4.Text = "Pasos realizados: " + pasos;

            // Mostrar el arreglo intercalado
            label3.Text = "Arreglo Intercalado: " + string.Join(", ", arregloIntercalado);
        }

        private void intercalacionmetodo_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Limpiar el NumericUpDown
            numericUpDown1.Value = 0;

            // Limpiar los Labels donde se muestran los arreglos y el número de pasos
            label1.Text = "Arreglo 1: ";
            label2.Text = "Arreglo 2: ";
            label4.Text = "Pasos realizados: ";
            label3.Text = "Arreglo Intercalado: ";

            // Limpiar los arreglos
            arreglo1 = arreglo2 = null;

        }
    }
    }

