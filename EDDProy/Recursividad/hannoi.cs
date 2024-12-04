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

namespace EDDemo.Recursividad
{
    public partial class hannoi : Form
    {
        private TorresHannoi hanoi;

        public hannoi()
        {
            InitializeComponent();
            hanoi = new TorresHannoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                int cantidadDiscos = (int)numericUpDown1.Value;

        
                int movimientos = hanoi.CalcularMovimientos(cantidadDiscos);

              
                label2.Text = $"Se realizaron {movimientos} movimientos ";

                hanoi.Movimientos = string.Empty; 

                // Resolver el problema de las Torres de Hanoi
                hanoi.ResolverHanoi(cantidadDiscos, "A", "C", "B");

                // Mostrar los movimientos resueltos en el Label
                label1.Text = hanoi.Movimientos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class TorresHannoi
    {
        public string Movimientos { get; set; }

        public TorresHannoi()
        {
            Movimientos = string.Empty;
        }

        // Método para calcular los movimientos necesarios para resolver el problema
        public int CalcularMovimientos(int n)
        {
            return (int)Math.Pow(2, n) - 1;
        }

        // Método para resolver el problema de las Torres de Hanoi y registrar los movimientos
        public void ResolverHanoi(int n, string torreInicial, string torreDestino, string torreAuxiliar)
        {
            if (n == 1)
            {
                Movimientos += $"Mover disco 1 de {torreInicial} a {torreDestino}\n";
                return;
            }

            ResolverHanoi(n - 1, torreInicial, torreAuxiliar, torreDestino); // Mover n-1 discos de torreInicial a torreAuxiliar
            Movimientos += $"Mover disco {n} de {torreInicial} a {torreDestino}\n"; // Mover el disco n a torreDestino
            ResolverHanoi(n - 1, torreAuxiliar, torreDestino, torreInicial); // Mover n-1 discos de torreAuxiliar a torreDestino
        }
    }


    }

