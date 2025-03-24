using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABEYAT.src.combobox
{
    internal class Responsable
    {
        public int IDResponsable { get; set; }  // Propiedad para el ID de la marca
        public string Nombre { get; set; }  // Propiedad para el nombre de la marca


        public Responsable(int idResponsable, string nombre)
        {
            IDResponsable = idResponsable;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;  // Esto hará que el ComboBox muestre el nombre de la marca
        }
    }
}
