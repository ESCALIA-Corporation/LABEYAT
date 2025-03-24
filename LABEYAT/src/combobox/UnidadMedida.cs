using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABEYAT.src.combobox
{
    internal class UnidadMedida
    {
        public int IDUMedida { get; set; }  // Propiedad para el ID de la marca
        public string Nombre { get; set; }  // Propiedad para el nombre de la marca


        public UnidadMedida(int iduMedida, string nombre)
        {
            IDUMedida = iduMedida;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;  // Esto hará que el ComboBox muestre el nombre de la marca
        }
    }
}
