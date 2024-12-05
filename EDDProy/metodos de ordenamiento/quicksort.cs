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
    public partial class quicksort : Form
    {
        private int[] arreglo;
        public quicksort()
        {
            InitializeComponent();
        }


        private void QuickSort(int[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int pivot = Particionar(arreglo, izquierda, derecha);  // Obtiene el índice del pivot
                QuickSort(arreglo, izquierda, pivot - 1);  // Ordena la parte izquierda
                QuickSort(arreglo, pivot + 1, derecha);  // Ordena la parte derecha
            }
        }

        // Método Particionar
        private int Particionar(int[] arreglo, int izquierda, int derecha)
        {
            int pivot = arreglo[derecha];  // El último elemento se usa como pivot
            int i = izquierda - 1;  // Índice de la parte más pequeña del arreglo

            for (int j = izquierda; j < derecha; j++)
            {
                if (arreglo[j] <= pivot)  // Si el elemento es menor o igual al pivot
                {
                    i++;
                    // Intercambiamos los elementos
                    int temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            // Colocamos el pivot en su posición final
            int temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[derecha];
            arreglo[derecha] = temp2;

            return i + 1;  // Retorna el índice del pivot
        }

        // Método para generar el arreglo con números aleatorios
        private int[] GenerarArreglo(int cantidad)
        {
            Random random = new Random();
            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = random.Next(1, 101); // Genera números aleatorios entre 1 y 100
            }

            return arreglo;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            int cantidad = (int)numericUpDown1.Value;  // Obtiene la cantidad seleccionada en numericUpDown

            if (cantidad <= 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad mayor a 0.");
                return;
            }

            // Generar el arreglo con números aleatorios
            arreglo = GenerarArreglo(cantidad);

            // Mostrar el arreglo generado en label1
            label1.Text = "Arreglo: " + string.Join(", ", arreglo);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (arreglo == null || arreglo.Length == 0)
            {
                MessageBox.Show("Primero crea un arreglo.");
                return;
            }

            // Ordenar el arreglo usando el método QuickSort
            QuickSort(arreglo, 0, arreglo.Length - 1);

            // Mostrar el arreglo ordenado en label2
            label2.Text = "Arreglo Ordenado: " + string.Join(", ", arreglo);
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            arreglo = null;
            label1.Text = null;
            label2.Text = null;
            numericUpDown1.Value = 0;
        }
    }
}
