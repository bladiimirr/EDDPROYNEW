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
    public partial class shellsort : Form
    {


        private int[] arreglo;
        public shellsort()
        {
            InitializeComponent();
        }
        private void ShellSort(int[] arr)
        {
            int n = arr.Length;
            int paso = n / 2;
            string pasos = "";

            while (paso > 0)
            {
                for (int i = paso; i < n; i++)
                {
                    int temp = arr[i];
                    int j = i;
                    while (j >= paso && arr[j - paso] > temp)
                    {
                        arr[j] = arr[j - paso];
                        j -= paso;
                    }
                    arr[j] = temp;
                }
                 
                // Guardamos el estado del arreglo en cada paso
                pasos += $"Paso con GAP {paso}: " + string.Join(", ", arr) + "\n";
                paso /= 2;
            }
   
            label3.Text = pasos;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            arreglo = new int[size];
            Random random = new Random();

            // Llenamos el arreglo con números aleatiroios
            for (int i = 0; i < size; i++)
            {
                arreglo[i] = random.Next(1, 101); // Valores entre 1 y 100
            }

            // Mostrar el arreglo
            label1.Text = "Arreglo original: " + string.Join(", ", arreglo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arreglo != null)
            {
                ShellSort(arreglo);

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
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;

            // Restablecer el NumericUpDown 
            numericUpDown1.Value = 0;

            // Limpiar el arreglo
            arreglo = null;
        }
    }
}
