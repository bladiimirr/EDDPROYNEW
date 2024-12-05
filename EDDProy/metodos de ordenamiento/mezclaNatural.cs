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
    public partial class mezclaNatural : Form
    {

        private int[] arreglo;

        public mezclaNatural()
        {
            InitializeComponent();
        }


        // Método de Mezcla Natural (Natural Merge Sort)
        private void NaturalMergeSort(int[] arr)
        {
            int n = arr.Length;
            string pasos = "";

            // Iniciamos la fusión de bloques naturales
            int gap = 1;
            while (gap < n)
            {
                for (int i = 0; i < n - gap; i += gap * 2)
                {
                    int mid = Math.Min(i + gap, n);
                    int end = Math.Min(i + gap * 2, n);

                    // Realizamos la fusión
                    Merge(arr, i, mid, end);
                }

                // Guardamos los pasos para mostrar el proceso
                pasos += $"Paso   {gap}: " + string.Join(", ", arr) + "\n";

                // Doblamos el gap
                gap *= 2;
            }

            // Mostrar los pasos en el Label3
            label3.Text = pasos;
        }

        // Método para fusionar dos partes del arreglo
        private void Merge(int[] arr, int left, int mid, int right)
        {
            int[] leftArray = new int[mid - left];
            int[] rightArray = new int[right - mid];

            Array.Copy(arr, left, leftArray, 0, mid - left);
            Array.Copy(arr, mid, rightArray, 0, right - mid);

            int i = 0, j = 0, k = left;

            // Fusionamos las dos partes
            while (i < leftArray.Length && j < rightArray.Length)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k++] = leftArray[i++];
                }
                else
                {
                    arr[k++] = rightArray[j++];
                }
            }

            // Copiamos los elementos restantes
            while (i < leftArray.Length)
            {
                arr[k++] = leftArray[i++];
            }

            while (j < rightArray.Length)
            {
                arr[k++] = rightArray[j++];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;

            // Validar que el tamaño sea mayor que 0
            if (size <= 0)
            {
                MessageBox.Show("Por favor, selecciona un tamaño mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arreglo != null)
            {
                NaturalMergeSort(arreglo);

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
            // Limpiar los labels
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;

            // Restablecer el NumericUpDown a su valor predeterminado (1)
            numericUpDown1.Value = 0;

            // Limpiar el arreglo
            arreglo = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mezclaNatural_Load(object sender, EventArgs e)
        {

        }
    }
}
