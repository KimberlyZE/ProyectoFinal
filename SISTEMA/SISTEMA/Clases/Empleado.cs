using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SISTEMA.Clases
{
    public class Empleado
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Domicilio { get; set; }
        public string Puesto { get; set; }
        public string Area { get; set; }
        public string Turno { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string Salario { get; set; }
        public string Contraseña { get; set; }

        // Constructor
        public Empleado(string nuevoID, string nombre, string cedula, string correo, string sexo, string estado,
                        string celular, string domicilio, string puesto, string area, string turno,
                        DateTime horaEntrada, DateTime horaSalida, string salario, string contraseñaGenerada)
        {
            ID = nuevoID;
            Nombre = nombre;
            Cedula = cedula;
            Correo = correo;
            Sexo = sexo;
            Estado = estado;
            Celular = celular;
            Domicilio = domicilio;
            Puesto = puesto;
            Area = area;
            Turno = turno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            Salario = salario;
            Contraseña = contraseñaGenerada;
        }
    }
}
