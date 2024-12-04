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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            CargarDatosDesdeArchivo("empleados.txt");
        }

        private void CargarDatosDesdeArchivo(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("El archivo de empleados no se encontró.");
                    return;
                }

                // Limpiar filas existentes en el DataGridView
                dataGridView1.Rows.Clear();

                // Leer el archivo y cargar los datos en el DataGridView
                string[] lineas = File.ReadAllLines(rutaArchivo);
                List<string> empleadoActual = new List<string>();

                foreach (string linea in lineas)
                {
                    if (linea.Trim() == "--------------------------------------------------")
                    {
                        if (empleadoActual.Count > 0)
                        {
                            // Agregar los datos al DataGridView
                            dataGridView1.Rows.Add(empleadoActual.ToArray());
                            empleadoActual.Clear();
                        }
                    }
                    else
                    {
                        // Extraer el contenido después de los dos puntos (":") y agregar a la lista temporal
                        empleadoActual.Add(linea.Substring(linea.IndexOf(":") + 1).Trim());
                    }
                }

                // Agregar el último empleado, si existe
                if (empleadoActual.Count > 0)
                {
                    dataGridView1.Rows.Add(empleadoActual.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }
        public void CargarDatosEnDataGridView(List<List<string>> datosEmpleados)
        {
            dataGridView1.Rows.Clear(); // Limpiar el DataGridView antes de cargar nuevos datos
            foreach (var empleado in datosEmpleados)
            {
                dataGridView1.Rows.Add(empleado.ToArray());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
