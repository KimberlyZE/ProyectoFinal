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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DIRECCION3 form3 = new DIRECCION3();
            form3.Show();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar eliminación
            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.No)
                return;

            // Obtener el ID del empleado para buscarlo en el archivo
            string idEmpleado = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(idEmpleado))
            {
                MessageBox.Show("No se encontró el ID del empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Eliminar el empleado del archivo
            try
            {
                string[] lineas = File.ReadAllLines("empleados.txt");
                List<string> nuevasLineas = new List<string>();
                bool empleadoEliminado = false;

                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].StartsWith($"ID: {idEmpleado}"))
                    {
                        // Saltar líneas del empleado actual
                        empleadoEliminado = true;
                        while (i < lineas.Length && !lineas[i].StartsWith("--------------------------------------------------"))
                            i++;
                    }
                    else
                    {
                        nuevasLineas.Add(lineas[i]);
                    }
                }

                if (empleadoEliminado)
                {
                    File.WriteAllLines("empleados.txt", nuevasLineas);
                    MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosDesdeArchivo("empleados.txt");
                }
                else
                {
                    MessageBox.Show("No se encontró al empleado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
