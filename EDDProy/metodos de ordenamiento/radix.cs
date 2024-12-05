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
    public partial class radix : Form
    {

        private int[] arreglo;



        public radix()
        {
            InitializeComponent();
        }


        // Método RadixSort
        private void RadixSort(int[] arr)
        {
            int max = arr.Max();
            string pasos = "";

            // Realizamos el algoritmo de RadixSort
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(arr, exp);
                pasos += $"Paso con exp {exp}: " + string.Join(", ", arr) + "\n";
            }

            // Mostrar los pasos en el Label3
            label3.Text = pasos;
        }

        // Método para realizar el CountSort basado en el exponente
        private void CountSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            // Guardamos las ocurrencias de los dígitos
            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            // Calculamos las posiciones de los elementos en el output
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Construimos el arreglo de salida
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copiamos el arreglo ordenado al original
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            arreglo = new int[size];
            Random random = new Random();

            // Llenamos el arreglo con números aleatorios
            for (int i = 0; i < size; i++)
            {
                arreglo[i] = random.Next(1, 101); // Valores entre 1 y 100
            }

            // Mostrar el arreglo en el Label1
            label1.Text = "Arreglo original: " + string.Join(", ", arreglo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arreglo != null)
            {
                RadixSort(arreglo);

                // Mostrar el arreglo ordenado en el Label2
                label2.Text = "Arreglo ordenado: " + string.Join(", ", arreglo);
            }
            else
            {
                MessageBox.Show("Primero crea un arreglo.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
