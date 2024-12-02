using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SISTEMA
{
    public partial class Form8 : Form
    {
        // Diccionario para almacenar usuarios, contraseñas y pantallas
        Dictionary<string, Tuple<string, string, Form>> usuariosRegistrados = new Dictionary<string, Tuple<string, string, Form>>();
        public Form8()
        {
            InitializeComponent();
        }

        private string GenerarContraseña()
        {
            var random = new Random();
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] contraseña = new char[8]; // Por ejemplo, una contraseña de 8 caracteres

            for (int i = 0; i < 8; i++)
            {
                contraseña[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(contraseña);
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GuardarEmpleadoEnArchivo(string idUsuario, string nombre, string cedula, string correo, string sexo, string estado,
                                     string celular, string domicilio, string puesto, string area, string turno,
                                     DateTime horaEntrada, DateTime horaSalida, string salario, string contraseñaGenerada)
        {
            // Ruta del archivo de texto donde se almacenarán los registros
            string archivo = "empleados.txt";

            // Crear el archivo si no existe, o abrirlo en modo append (agregar al final del archivo)
            using (StreamWriter writer = new StreamWriter(archivo, true))
            {
                writer.WriteLine($"ID: {idUsuario}");
                writer.WriteLine($"Nombre: {nombre}");
                writer.WriteLine($"Cédula: {cedula}");
                writer.WriteLine($"Correo: {correo}");
                writer.WriteLine($"Sexo: {sexo}");
                writer.WriteLine($"Estado: {estado}");
                writer.WriteLine($"Celular: {celular}");
                writer.WriteLine($"Domicilio: {domicilio}");
                writer.WriteLine($"Puesto: {puesto}");
                writer.WriteLine($"Área: {area}");
                writer.WriteLine($"Turno: {turno}");
                writer.WriteLine($"Hora Entrada: {horaEntrada.ToString("HH:mm")}");
                writer.WriteLine($"Hora Salida: {horaSalida.ToString("HH:mm")}");
                writer.WriteLine($"Salario: {salario}");
                writer.WriteLine($"Contraseña: {contraseñaGenerada}");
                writer.WriteLine("--------------------------------------------------");
            }

            // Verificar si el usuario ya está registrado en el diccionario
            if (usuariosRegistrados.ContainsKey(idUsuario))
            {
                MessageBox.Show("El usuario con este ID ya está registrado.");
                return;
            }

            // Registrar el empleado en el diccionario de usuarios
            usuariosRegistrados.Add(idUsuario, new Tuple<string, string, Form>("empleado", contraseñaGenerada, new Form2()));
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtCelular.Text) ||
                string.IsNullOrEmpty(txtDomicilio.Text) || string.IsNullOrEmpty(txtSalario.Text) ||
                cmbSexo.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1 || cmbPuesto.SelectedIndex == -1 ||
                cmbArea.SelectedIndex == -1 || cmbTurno.SelectedIndex == -1 || datetimeHoraEntrada.Value == null || datetimeHoraSalida.Value == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Generar una contraseña aleatoria
            string contraseñaGenerada = GenerarContraseña();

            // Guardar los datos del empleado en un archivo de texto
            GuardarEmpleadoEnArchivo(txtID.Text, txtNombre.Text, txtCedula.Text, txtCorreo.Text, cmbSexo.SelectedItem.ToString(),
                cmbEstado.SelectedItem.ToString(), txtCelular.Text, txtDomicilio.Text, cmbPuesto.SelectedItem.ToString(),
                cmbArea.SelectedItem.ToString(), cmbTurno.SelectedItem.ToString(), datetimeHoraEntrada.Value, datetimeHoraSalida.Value, txtSalario.Text, contraseñaGenerada);

            // Registrar al empleado en el diccionario con su ID y contraseña
            Form pantallaEmpleado = new Form2();  // Este es un formulario de ejemplo para el empleado
            usuariosRegistrados.Add(txtID.Text.ToLower(), new Tuple<string, string, Form>(txtID.Text.ToLower(), contraseñaGenerada, pantallaEmpleado));

            // Confirmar que el registro fue exitoso
            MessageBox.Show("Empleado registrado con éxito.");
        }

            private void txtSalario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
                MessageBox.Show("Solo se permiten letras y espacios en el nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            
            if (txtCedula.Text.Length < 13)
            {
                // Permitir solo números en los primeros 13 caracteres
                e.Handled = !char.IsDigit(e.KeyChar);
            }
            else if (txtCedula.Text.Length == 13)
            {
                // Permitir solo una letra en el 14º carácter
                e.Handled = !char.IsLetter(e.KeyChar);
            }
            else
            {
                // No permitir más de 14 caracteres
                e.Handled = true;
            }
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Validar longitud máxima de 8 caracteres
            if (txtCelular.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo caracteres alfabéticos, números, @, . y espacio
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_')
            {
                e.Handled = true; // Bloquear cualquier carácter no permitido
            }

            
            if (e.KeyChar == '@' && txtCorreo.Text.Contains("@"))
            {
                e.Handled = true; 
            }

            
            if (e.KeyChar == '.' && !txtCorreo.Text.Contains("@"))
            {
                e.Handled = true; 
            }
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite todo para la direccion
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; 
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();       
            DIRECCION3 form3 = new DIRECCION3(); 
            form3.Show();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
