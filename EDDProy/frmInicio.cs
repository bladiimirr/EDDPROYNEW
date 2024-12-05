using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDDemo.Estructuras_Lineales;
using EDDemo.Estructuras_No_Lineales;
using EDDemo.metodos_de_ordenamiento;
using EDDemo.Recursividad;

namespace EDDemo
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPilas mPilas = new frmPilas();
            mPilas.MdiParent = this;
            mPilas.Show();
        }

        private void estructurasLinealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void arbolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArboles mArboles = new frmArboles();
            mArboles.MdiParent = this;
            mArboles.Show();
        }

        private void estructurasNoLibealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListas FormListas = new FormListas();
            FormListas.MdiParent = this;
            FormListas.Show();
        }

        private void colasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormColas FormColas = new FormColas();
            FormColas.MdiParent = this;
            FormColas.Show();
        }

        private void listasDoblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListasDobles FormListasDobles = new FormListasDobles();
            FormListasDobles.MdiParent = this;
            FormListasDobles.Show(); 
        }

        private void listasCircularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCirculares FormCirculares = new FormCirculares();
            FormCirculares.MdiParent = this;
            FormCirculares.Show();
        }

        private void circularesDoblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormlistaDoble FormCircularesDobles = new FormlistaDoble();
            FormCircularesDobles.MdiParent = this;
            FormCircularesDobles.Show();
        }

        private void busquedaBinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {



            busquedabin busquedabin = new busquedabin();
            busquedabin.MdiParent = this;
            busquedabin.Show();




        }

        private void factorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRecursividad FormRecursividad = new FormRecursividad();
            FormRecursividad.MdiParent = this;
            FormRecursividad.Show();

        }

        private void exponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exponencial exponencial = new exponencial();
            exponencial.MdiParent = this;
            exponencial.Show();
        }

        private void sumaArregloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arreglosum arreglosum = new arreglosum();
            arreglosum.MdiParent = this;
            arreglosum.Show();
        }

        private void secuenciaFibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fibonacci fibonacci = new fibonacci();
            fibonacci.MdiParent = this;
            fibonacci.Show();
        }

        private void torreDeHannoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hannoi hannoi = new hannoi();
            hannoi.MdiParent = this;
            hannoi.Show();

        }

        private void mezclaNaturalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void intercalaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            intercalacionmetodo intercalacionmetodo = new intercalacionmetodo();
            intercalacionmetodo.MdiParent = this;
            intercalacionmetodo.Show();
        }

        private void burbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            burbuja burbuja = new burbuja();
            burbuja.MdiParent = this;
            burbuja.Show();
        }

        private void quickSoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quicksort quicksort = new quicksort();
            quicksort.MdiParent = this;
            quicksort.Show();
        }

        private void shellSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shellsort shellsort = new shellsort();

        shellsort.MdiParent = this;
            shellsort.Show();
        }

        private void radixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radix radix = new radix();
            radix.MdiParent = this;
            radix.Show();
        }
    }
}
