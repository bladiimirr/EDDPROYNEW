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
    public partial class directam : Form
    {


        private int[] arreglo;
        public directam()
        {
            InitializeComponent();
        }

        private void MergeSort(int[] arr, int left, int right, ref string pasos)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Ordenamos la mitad izquierda
                MergeSort(arr, left, mid, ref pasos);

                // Ordenamos la mitad derecha
                MergeSort(arr, mid + 1, right, ref pasos);

                // Fusionamos las mitades
                Merge(arr, left, mid, right);

                // Guardamos el paso
                pasos += $"Paso entre {left}-{mid}-{right}: {string.Join(", ", arr)}\n";
            }
        }

        // Método para fusionar dos subarreglos
        private void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = arr[left + i];

            for (int i = 0; i < n2; i++)
                rightArray[i] = arr[mid + 1 + i];

            int iLeft = 0, iRight = 0, k = left;

            // Fusionamos los dos arreglos
            while (iLeft < n1 && iRight < n2)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                {
                    arr[k] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    arr[k] = rightArray[iRight];
                    iRight++;
                }
                k++;
            }

            // Copiamos los elementos restantes de cada subarreglo
            while (iLeft < n1)
            {
                arr[k] = leftArray[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                arr[k] = rightArray[iRight];
                iRight++;
                k++;
            }
        }

        // Evento para crear el arreglo
        private void btnCrear_Click(object sender, EventArgs e)
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void directam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;

           
            if (size <= 0)
            {
                MessageBox.Show("Por favor, selecciona un tamaño mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            arreglo = new int[size];
            Random random = new Random();

          
            for (int i = 0; i < size; i++)
            {
                arreglo[i] = random.Next(1, 101); 
            }

           
            label1.Text = "Arreglo original: " + string.Join(", ", arreglo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arreglo != null)
            {
                string pasos = "";
                MergeSort(arreglo, 0, arreglo.Length - 1, ref pasos);

               
                label2.Text = "Arreglo ordenado: " + string.Join(", ", arreglo);

                
                label3.Text = "Pasos de ordenamiento:\n" + pasos;
            }
            else
            {
                MessageBox.Show("Primero crea un arreglo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Limpiar los labels
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;

           
            numericUpDown1.Value = 0;

            // Limpiar el arreglo
            arreglo = null;
        }
    }
}
