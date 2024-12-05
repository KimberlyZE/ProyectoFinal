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
            string idEmpleado = idpuestoasis.Text.Trim();
            string fechaDesde = fechainicioasis.Value.ToString("yyyy-MM-dd");
            string fechaHasta = fechafinalasis.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(idEmpleado))
            {
                MessageBox.Show("Por favor, ingresa un ID de empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leer el archivo empleados.txt
            string[] empleados = File.ReadAllLines("empleados.txt");
            string nombreEmpleado = string.Empty;
            string horaEntrada = string.Empty;
            string horaSalida = string.Empty;

            foreach (string linea in empleados)
            {
                if (linea.Contains($"ID: {idEmpleado}"))
                {
                    nombreEmpleado = empleados.SkipWhile(l => !l.Contains($"ID: {idEmpleado}"))
                                              .FirstOrDefault(l => l.StartsWith("Nombre:"))?
                                              .Replace("Nombre:", "").Trim();

                    horaEntrada = empleados.SkipWhile(l => !l.Contains($"ID: {idEmpleado}"))
                                            .FirstOrDefault(l => l.StartsWith("Hora Entrada:"))?
                                            .Replace("Hora Entrada:", "").Trim();

                    horaSalida = empleados.SkipWhile(l => !l.Contains($"ID: {idEmpleado}"))
                                           .FirstOrDefault(l => l.StartsWith("Hora Salida:"))?
                                           .Replace("Hora Salida:", "").Trim();
                    break;
                }
            }

            if (string.IsNullOrEmpty(nombreEmpleado))
            {
                MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asignar valores al formulario
            nombrepuestoasis.Text = nombreEmpleado;
            horaentradapuestoasis.Text = horaEntrada;
            horasalidapuestoasis.Text = horaSalida;

            // Leer el archivo EntradasSalidas.txt
            string[] entradasSalidas = File.ReadAllLines("EntradasySalidas.txt");

            // Imprime las líneas del archivo en la consola para depuración
            foreach (string linea in entradasSalidas)
            {
                Console.WriteLine(linea);
            }

            // Obtener el ID del empleado y las fechas seleccionadas
            string idEmpleadof = idpuestoasis.Text.Trim();
            DateTime desde = fechainicioasis.Value.Date;
            DateTime hasta = fechafinalasis.Value.Date;

            // Crear una lista para almacenar los registros filtrados
            var registros = new List<object>();

            // Iterar por cada línea del archivo
            foreach (string linea in entradasSalidas)
            {
                if (linea.Contains($"Usuario: {idEmpleado}"))
                {
                    string fechaHora = string.Empty;
                    string tipo = string.Empty;

                    // Extraer datos de Entrada o Salida
                    if (linea.Contains("Entrada:"))
                    {
                        fechaHora = linea.Substring(linea.IndexOf("Entrada:") + 8).Trim();
                        tipo = "Entrada";
                    }
                    else if (linea.Contains("Salida:"))
                    {
                        fechaHora = linea.Substring(linea.IndexOf("Salida:") + 7).Trim();
                        tipo = "Salida";
                    }

                    // Filtrar por rango de fechas
                    if (DateTime.TryParse(fechaHora, out DateTime fecha) && fecha.Date >= desde && fecha.Date <= hasta)
                    {
                        registros.Add(new
                        {
                            Tipo = tipo,
                            FechayHora = fechaHora
                        });
                    }
                }
            }

            // Asignar los datos al DataGridView
            dataGridView2.DataSource = registros.ToList();
        }

        private void idpuestoasis_TextChanged(object sender, EventArgs e)
        {

        }

        private void VALIDARASIS10_Load(object sender, EventArgs e)
        {

        }
    }
}
