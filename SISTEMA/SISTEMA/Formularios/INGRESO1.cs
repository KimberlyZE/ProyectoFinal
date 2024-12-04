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

    public partial class Form1 : Form
    {
        // Diccionario para almacenar usuarios registrados
        private Dictionary<string, Tuple<string, string, Form>> usuariosRegistrados = new Dictionary<string, Tuple<string, string, Form>>();

        public Form1()
        {
            InitializeComponent();
            LeerArchivoYRegistrarEmpleados("empleados.txt");

            usuariosRegistrados.Add("a", new Tuple<string, string, Form>("a", "a", new DIRECCION3()));
            usuariosRegistrados.Add("b", new Tuple<string, string, Form>("b", "b", new CONTADURIA5()));
            usuariosRegistrados.Add("c", new Tuple<string, string, Form>("c", "c", new COORDINACION4()));
        }

        private void LeerArchivoYRegistrarEmpleados(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("El archivo de empleados no se encontró.");
                    return;
                }

                string[] lineas = File.ReadAllLines(rutaArchivo);
                List<string> empleadoActual = new List<string>();
                foreach (string linea in lineas)
                {
                    if (linea.Trim() == "--------------------------------------------------")
                    {
                        ProcesarEmpleado(empleadoActual);
                        empleadoActual.Clear();
                    }
                    else
                    {
                        empleadoActual.Add(linea);
                    }
                }

                // Procesar el último empleado si el archivo no termina con "--------------------------------------------------"
                if (empleadoActual.Count > 0)
                {
                    ProcesarEmpleado(empleadoActual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
            }
        }

        private void ProcesarEmpleado(List<string> datosEmpleado)
        {
            try
            {
                string id = "";
                string nombre = "";
                string contraseña = "";
                Form pantalla = new Form2(); // Aquí puedes definir una pantalla predeterminada

                foreach (string dato in datosEmpleado)
                {
                    if (dato.StartsWith("ID:")) id = dato.Substring(3).Trim();
                    else if (dato.StartsWith("Nombre:")) nombre = dato.Substring(7).Trim();
                    else if (dato.StartsWith("Contraseña:")) contraseña = dato.Substring(11).Trim();
                }

                if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(contraseña))
                {
                    RegistrarEmpleado(id.ToLower(), contraseña, pantalla);
                }
                else
                {
                    MessageBox.Show("Datos del empleado incompletos, no se registrará.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar empleado: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }
        // Método para registrar un empleado dinámicamente
        private void RegistrarEmpleado(string idUsuario, string contraseñaGenerada, Form pantalla)
        {
            if (!usuariosRegistrados.ContainsKey(idUsuario))
            {
                usuariosRegistrados.Add(idUsuario, new Tuple<string, string, Form>(idUsuario, contraseñaGenerada, pantalla));
            }
            else
            {
                MessageBox.Show($"El ID de usuario {idUsuario} ya está registrado.");
            }
        }

        public static class SesionUsuario
        {
            public static string IdUsuario { get; set; }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim().ToLower();  // ID del usuario ingresado
            string contrasenaIngresada = txtContraseña.Text;  // Contraseña ingresada

            // Verificar si el usuario está registrado
            if (usuariosRegistrados.TryGetValue(usuarioIngresado, out var datosUsuario))
            {
                // Comprobar si la contraseña es correcta
                if (datosUsuario.Item2 == contrasenaIngresada)
                {
                    SesionUsuario.IdUsuario = usuarioIngresado;
                    // Mostrar el formulario correspondiente al usuario
                    datosUsuario.Item3.Show();
                    // Ocultar el formulario de inicio de sesión
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El usuario no está registrado.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btningreso_Click(object sender, EventArgs e)
        {

        }



        private void btnlogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
