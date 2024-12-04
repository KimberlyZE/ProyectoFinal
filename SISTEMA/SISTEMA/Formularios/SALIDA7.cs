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
using static SISTEMA.Form1;

namespace SISTEMA
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();       
            Form2 form2 = new Form2(); // Crea una nueva instancia de Form2
            form2.Show();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
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
                string datosEntrada = $"Usuario: {idUsuario}, Salida: {fechaHora}";

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
    }
}
