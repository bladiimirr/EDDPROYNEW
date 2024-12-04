using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_Lineales
{
    public partial class FormCirculares : Form
    {
        public FormCirculares()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int valor, posicion;

           
            if (int.TryParse(txtdato.Text, out valor) && int.TryParse(txtposision.Text, out posicion))
            {
                // Llamar al método insertar con los valores validados
                Insertar(valor, posicion);
                Ver(); // Actualiza la vista
            }
            else
            {
                // Mostrar un mensaje más claro en caso de error
                MessageBox.Show("Por favor, ingresa un dato y una posición válidos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar los campos de texto para el próximo ingreso de datos
            txtdato.Clear();
            txtposision.Clear();
            txtdato.Focus(); // Enfocar en el primer campo para una experiencia más fluida
        }
    }
}
