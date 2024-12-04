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

namespace EDDemo.Recursividad
{
    public partial class arreglosum : Form
    {
        public arreglosum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el tamaño del arreglo desde el NumericUpDown
                int tamaño = (int)numericUpDown1.Value;

                if (tamaño <= 0)
                {
                    MessageBox.Show("El arreglo debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int[] arreglo = SumarArreglos.GenerarArreglo(tamaño);
                int suma = SumarArreglos.Calcular(arreglo);
                string valores = string.Join(" ", arreglo.Select(num => $"[{num}]"));
                // Mostrar los números generados
                label2.Text = valores;
                // Mostrar el resultado de la suma 
                label4.Text = suma.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
              public static class SumarArreglos
        {
            private static Random random = new Random();

            // Generar un arreglo de números aleatorios usando recursividad
            public static int[] GenerarArreglo(int tamaño, int min = 0, int max = 100, int[] arreglo = null, int index = 0)
            {
                if (arreglo == null)
                {
                    arreglo = new int[tamaño]; 
                }

                if (index >= tamaño)
                {
                    return arreglo; 
                }

                arreglo[index] = random.Next(min, max);
                return GenerarArreglo(tamaño, min, max, arreglo, index + 1); 
            }

           
            public static int Calcular(int[] arreglo, int index = 0)
            {
                if (index >= arreglo.Length)
                {
                    return 0; 
                }

                return arreglo[index] + Calcular(arreglo, index + 1); 
            }
        }
    }


    }