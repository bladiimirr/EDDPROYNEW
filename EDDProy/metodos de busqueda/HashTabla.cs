using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.metodos_de_busqueda
{
    internal class HashTabla
    {

        public const int TAMANIO = 100;
        public int[] claves { get; private set; }  // Hacer accesibles las claves
        public string[] valores { get; private set; }  // Hacer accesibles los valores

        public HashTabla()
        {
            claves = new int[TAMANIO];
            valores = new string[TAMANIO];
            for (int i = 0; i < TAMANIO; i++)
            {
                claves[i] = -1;
            }
        }


        // Propiedades públicas para acceder a los arreglos
        public int[] Claves
        {
            get { return claves; }
        }

        public string[] Valores
        {
            get { return valores; }
        }

        private int FuncionHash(int clave, int tamanioTabla)
        {
            return clave % tamanioTabla;
        }

        static int FuncionHashPolinomial(string clave, int tamanioTabla)
        {
            const int basePolinomial = 31;
            int hash = 0;

            for (int i = 0; i < clave.Length; i++)
            {
                hash = (hash * basePolinomial + clave[i]) % tamanioTabla;
            }

            return Math.Abs(hash);
        }

        public void Insertar(int clave, string valor)
        {
            int indice = FuncionHash(clave, TAMANIO);
            while (claves[indice] != -1)
            {
                indice = (indice + 1) % TAMANIO;
            }
            claves[indice] = clave;
            valores[indice] = valor;
        }

        public string Buscar(int clave)
        {
            int indice = FuncionHash(clave, TAMANIO);
            int inicio = indice;

            while (claves[indice] != -1)
            {
                if (claves[indice] == clave)
                {
                    return valores[indice];
                }
                indice = (indice + 1) % TAMANIO;

                if (indice == inicio)
                {
                    break;
                }
            }
            return null;
        }

        
    }
}



   
