using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA.Clases
{
    internal class DatosNomi
    {
        // Propiedades de cada empleado
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Puesto { get; set; }
        public string Area { get; set; }
        public string Turno { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal INSS { get; set; }
        public decimal IR { get; set; }
        public decimal SalarioNeto { get; set; }
    }
}
