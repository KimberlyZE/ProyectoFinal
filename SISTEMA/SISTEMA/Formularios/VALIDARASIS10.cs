using SISTEMA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace SISTEMA
{
    public partial class VALIDARASIS10 : Form
    {
        public VALIDARASIS10()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private string GetEmpleadoById(string id)
        {
            string[] empleados = File.ReadAllLines("empleados.txt");  // Leer todas las líneas del archivo
            foreach (var linea in empleados)
            {
                string[] datosEmpleado = linea.Split(';'); // Suponiendo que los datos están separados por punto y coma
                if (datosEmpleado[0] == id) // Comparar el ID con el ID del empleado
                {
                    return datosEmpleado[1]; // Suponiendo que el nombre está en la segunda posición
                }
            }
            return null;  // Si no se encuentra el empleado
        }

        private List<Asistencia> GetAsistenciasByEmpleadoId(string empleadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Asistencia> asistencias = new List<Asistencia>();
            string[] entradasYSalidas = File.ReadAllLines("EntradasySalidas.txt");  // Leer todas las líneas del archivo de asistencias

            foreach (var linea in entradasYSalidas)
            {
                string[] datosAsistencia = linea.Split(';');
                string idEmpleado = datosAsistencia[0];  // Suponiendo que el ID del empleado está en la primera posición
                DateTime fecha = DateTime.Parse(datosAsistencia[1]);  // Fecha de la asistencia
                DateTime horaEntrada = DateTime.Parse(datosAsistencia[2]);  // Hora de entrada
                DateTime horaSalida = DateTime.Parse(datosAsistencia[3]);  // Hora de salida

                if (idEmpleado == empleadoId && fecha >= fechaInicio && fecha <= fechaFin)
                {
                    asistencias.Add(new Asistencia
                    {
                        Fecha = fecha,
                        HoraEntrada = horaEntrada,
                        HoraSalida = horaSalida
                    });
                }
            }
            return asistencias;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los controles
            string id = idpuestoasis.Text; // ID del empleado
            DateTime fechaInicio = fechainicioasis.Value; // Fecha de inicio
            DateTime fechaFin = fechafinalasis.Value; // Fecha de fin

            // Verifica que el campo ID esté completo
            if (!string.IsNullOrEmpty(id))
            {
                // Limpiar el DataGridView antes de agregar nuevos resultados
                dataGridView2.Rows.Clear();

                // Leer el archivo de empleados para obtener el nombre y las horas de entrada y salida
                string[] empleados = File.ReadAllLines("empleados.txt");

                // Buscar el empleado por ID
                string nombreEmpleado = "";
                string horaEntrada = "";
                string horaSalida = "";

                foreach (string empleado in empleados)
                {
                    // Suponiendo que los empleados están en formato: "id,nombre,horaEntrada, horaSalida"
                    string[] datosEmpleado = empleado.Split(',');

                    if (datosEmpleado[0] == id)
                    {
                        nombreEmpleado = datosEmpleado[1];
                        horaEntrada = datosEmpleado[2];
                        horaSalida = datosEmpleado[3];
                        break; // Encontrado, no es necesario seguir buscando
                    }
                }

                // Si no se encontró el empleado
                if (string.IsNullOrEmpty(nombreEmpleado))
                {
                    MessageBox.Show("Empleado no encontrado.");
                    return;
                }

                // Leer el archivo de asistencia para obtener las entradas y salidas por fecha
                string[] entradasSalidas = File.ReadAllLines("EntradasySalidas.txt");

                // Filtrar las asistencias por el rango de fechas
                foreach (string entradaSalida in entradasSalidas)
                {
                    // Suponiendo que el formato del archivo es: "id,fecha,entrada, salida"
                    string[] datosEntradaSalida = entradaSalida.Split(',');

                    string idEmpleado = datosEntradaSalida[0];
                    DateTime fechaEntrada = DateTime.Parse(datosEntradaSalida[1]);
                    string entrada = datosEntradaSalida[2];
                    string salida = datosEntradaSalida[3];

                    // Verificar si el ID del empleado coincide y si la fecha está dentro del rango
                    if (idEmpleado == id && fechaEntrada >= fechaInicio && fechaEntrada <= fechaFin)
                    {
                        // Agregar los datos al DataGridView
                        dataGridView2.Rows.Add(fechaEntrada.ToShortDateString(), entrada, salida);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete el campo ID antes de buscar.");
            }
        }

        private void idpuestoasis_TextChanged(object sender, EventArgs e)
        {

        }

        private void VALIDARASIS10_Load(object sender, EventArgs e)
        {

        }
    }
}
