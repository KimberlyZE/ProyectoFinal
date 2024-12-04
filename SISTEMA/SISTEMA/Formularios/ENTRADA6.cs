using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SISTEMA.Form1;

namespace SISTEMA
{
    public partial class ENTRADA6 : Form
    {
        public ENTRADA6()
        {
            InitializeComponent();
        }
        private void REGISTRARHORA_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta del archivo
                string rutaArchivo = "EntradasySalidas.txt";

                // Verificar que el ID del usuario está disponible
                if (string.IsNullOrEmpty(SesionUsuario.IdUsuario))
                {
                    MessageBox.Show("No se puede registrar la hora porque no hay un usuario logueado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Datos a registrar
                string idUsuario = SesionUsuario.IdUsuario; // ID del usuario logueado
                string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string datosEntrada = $"Usuario: {idUsuario}, Entrada: {fechaHora}";

                // Verificar si el archivo existe, si no, crearlo
                if (!File.Exists(rutaArchivo))
                {
                    File.WriteAllText(rutaArchivo, "Registro de Entradas y Salidas\n");
                }

                // Agregar la entrada al archivo
                File.AppendAllText(rutaArchivo, datosEntrada + Environment.NewLine);

                // Confirmar al usuario
                MessageBox.Show("Hora registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la hora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();       // Cierra ENTRADA6
            Form form2 = new Form2(); // Crea una nueva instancia de Form2
            form2.Show();
            this.Hide();
        }

        private void ENTRADA6_Load(object sender, EventArgs e)
        {

        }
    }
}
