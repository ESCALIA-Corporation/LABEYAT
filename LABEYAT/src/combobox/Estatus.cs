using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABEYAT.src.combobox
{
    internal class Estatus
    {
        public int IDEstatus { get; set; }  // Propiedad para el ID de la marca
        public string Nombre { get; set; }  // Propiedad para el nombre de la marca


        public Estatus(int idEstatus, string nombre)
        {
            IDEstatus = idEstatus;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;  // Esto hará que el ComboBox muestre el nombre de la marca
        }
    }
}
