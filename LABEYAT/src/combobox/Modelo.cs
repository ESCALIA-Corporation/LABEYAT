using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABEYAT.src.combobox
{
    internal class Modelo
    {
        public int IDModelo { get; set; }  // Propiedad para el ID de la marca
        public string Nombre { get; set; }  // Propiedad para el nombre de la marca


        public Modelo(int idModelo, string nombre)
        {
            IDModelo = idModelo;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;  // Esto hará que el ComboBox muestre el nombre de la marca
        }
    }
}
