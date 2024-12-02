using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA
{
    public partial class Form1 : Form
    {
        // Diccionario para almacenar usuarios, contraseñas y pantallas
        Dictionary<string, Tuple<string, string, Form>> usuariosRegistrados = new Dictionary<string, Tuple<string, string, Form>>();

        public Form1()
        {
            InitializeComponent();
            // Registro de usuarios con su nombre, contraseña y pantalla correspondiente
            usuariosRegistrados.Add("direccion", new Tuple<string, string, Form>("direccion", "contraseñaDireccion", new DIRECCION3()));
            usuariosRegistrados.Add("contaduria", new Tuple<string, string, Form>("contaduria", "contraseñaContaduria", new CONTADURIA5()));
            usuariosRegistrados.Add("coordinacion", new Tuple<string, string, Form>("coordinacion", "contraseñaCoordinacion", new COORDINACION4()));

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
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }
        // Método para registrar un empleado dinámicamente
        private void RegistrarEmpleado(string idUsuario, string contraseñaGenerada, Form pantalla)
        {
            // Verificar si el usuario ya existe
            if (!usuariosRegistrados.ContainsKey(idUsuario))
            {
                // Agregar al diccionario
                usuariosRegistrados.Add(idUsuario, new Tuple<string, string, Form>(idUsuario, contraseñaGenerada, pantalla));
                MessageBox.Show("Empleado registrado correctamente.");
            }
            else
            {
                MessageBox.Show("El ID de usuario ya está registrado.");
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {

            string usuarioIngresado = txtUsuario.Text.ToLower();  // El ID de usuario ingresado
            string contrasenaIngresada = txtContraseña.Text;  // La contraseña ingresada

            // Verificar si el usuario está registrado
            if (usuariosRegistrados.ContainsKey(usuarioIngresado))
            {
                // Obtener el valor del diccionario: (ID, contraseña, formulario)
                var usuario = usuariosRegistrados[usuarioIngresado];

                // Verificar la contraseña
                if (usuario.Item2 == contrasenaIngresada)  // Comparar las contraseñas
                {
                    // Obtener el formulario correspondiente
                    Form pantalla = usuario.Item3;
                    // Mostrar el formulario
                    pantalla.Show();
                    // Ocultar el formulario de inicio de sesión
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.");
                }
            }
            else
            {
                MessageBox.Show("El usuario no está registrado.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
