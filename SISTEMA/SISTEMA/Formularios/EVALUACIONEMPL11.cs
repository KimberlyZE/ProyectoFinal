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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void btnBuscarEval_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del empleado desde el TextBox
                string idEmpleado = idEvalua.Text.Trim();

                // Validar si el ID fue ingresado
                if (string.IsNullOrEmpty(idEmpleado))
                {
                    MessageBox.Show("Por favor, ingresa un ID de empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Leer el archivo empleados.txt
                string[] empleados = File.ReadAllLines("empleados.txt");

                // Variable para almacenar el nombre del empleado
                string nombreEmpleado = string.Empty;

                // Buscar el nombre del empleado por ID
                foreach (string linea in empleados)
                {
                    if (linea.Contains($"ID: {idEmpleado}"))
                    {
                        nombreEmpleado = empleados.SkipWhile(l => !l.Contains($"ID: {idEmpleado}"))
                                                   .FirstOrDefault(l => l.StartsWith("Nombre:"))?
                                                   .Replace("Nombre:", "").Trim();
                        break;
                    }
                }

                // Si no se encuentra el nombre, mostrar mensaje de error
                if (string.IsNullOrEmpty(nombreEmpleado))
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar el nombre encontrado al TextBox nombreEvalua
                nombreEvalua.Text = nombreEmpleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                string idEmpleado = idEvalua.Text.Trim();
                string nombreEmpleado = nombreEvalua.Text.Trim();
                DateTime desdeFecha = desdeEvalua.Value;
                DateTime hastaFecha = hastaEvalua.Value;
                decimal calificacion = califiEvalua.Value;
                string comentarios = comEvalua.Text.Trim();

                // Validar que los datos mínimos estén completos
                if (string.IsNullOrEmpty(idEmpleado) || string.IsNullOrEmpty(nombreEmpleado))
                {
                    MessageBox.Show("Por favor, completa todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el contenido del registro
                string contenido = $"ID Empleado: {idEmpleado}\n" +
                                   $"Nombre: {nombreEmpleado}\n" +
                                   $"Evaluación Desde: {desdeFecha.ToShortDateString()}\n" +
                                   $"Evaluación Hasta: {hastaFecha.ToShortDateString()}\n" +
                                   $"Calificación: {calificacion}\n" +
                                   $"Comentarios: {comentarios}\n" +
                                   $"----------------------------------------\n";

                // Ruta del archivo
                string rutaArchivo = "evaluaciones.txt";

                // Escribir el contenido al archivo (se agrega sin sobrescribir)
                File.AppendAllText(rutaArchivo, contenido);

                // Confirmar al usuario que la evaluación fue registrada
                MessageBox.Show("Evaluación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la evaluación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
