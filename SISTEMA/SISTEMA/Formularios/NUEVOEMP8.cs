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
using System.Security.AccessControl;

namespace SISTEMA
{
    public partial class Form8 : Form
    {
        // Diccionario para almacenar usuarios, contraseñas y pantallas
        Dictionary<string, Tuple<string, string, Form>> usuariosRegistrados = new Dictionary<string, Tuple<string, string, Form>>();
        public Form8()
        {
            InitializeComponent();
            LeerArchivoYRegistrarEmpleados("empleados.txt");
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

        private string GenerarNuevoID(string rutaArchivo)
        {
            try
            {
                // Si el archivo no existe, el primer ID será "00001"
                if (!File.Exists(rutaArchivo))
                {
                    return "00001";
                }

                // Leer todas las líneas del archivo
                var lineas = File.ReadAllLines(rutaArchivo);

                // Filtrar las líneas que contienen "ID:"
                var ids = lineas
                    .Where(linea => linea.StartsWith("ID:"))
                    .Select(linea => linea.Substring(3).Trim()) // Extraer el número del ID
                    .Where(id => int.TryParse(id, out _))       // Filtrar IDs válidos
                    .Select(id => int.Parse(id))               // Convertir a entero
                    .ToList();

                // Si no hay IDs válidos, el primer ID será "00001"
                if (ids.Count == 0)
                {
                    return "00001";
                }

                // Obtener el máximo ID, incrementarlo y formatearlo a 5 dígitos
                int nuevoID = ids.Max() + 1;
                return nuevoID.ToString("D5");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar nuevo ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "00001"; // En caso de error, retornar el ID inicial
            }
        }


        private void ProcesarEmpleado(List<string> datosEmpleado)
        {
            try
            {
                string id = "";
                string nombre = "";
                string contraseña = "";

                foreach (string dato in datosEmpleado)
                {
                    if (dato.StartsWith("ID:")) id = dato.Substring(3).Trim();
                    else if (dato.StartsWith("Nombre:")) nombre = dato.Substring(7).Trim();
                    else if (dato.StartsWith("Contraseña:")) contraseña = dato.Substring(11).Trim();
                }

                if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(contraseña))
                {

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
            // Ruta del archivo de empleados
            string rutaArchivo = "empleados.txt";

            // Generar un nuevo ID
            string nuevoID = GenerarNuevoID(rutaArchivo);

            // Asignar el nuevo ID al campo correspondiente             


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
            GuardarEmpleadoEnArchivo(nuevoID, txtNombre.Text, txtCedula.Text, txtCorreo.Text, cmbSexo.SelectedItem.ToString(),
                cmbEstado.SelectedItem.ToString(), txtCelular.Text, txtDomicilio.Text, cmbPuesto.SelectedItem.ToString(),
                cmbArea.SelectedItem.ToString(), cmbTurno.SelectedItem.ToString(), datetimeHoraEntrada.Value, datetimeHoraSalida.Value, txtSalario.Text, contraseñaGenerada);

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

        private void MostrarDatosEnDataGridView()
        {
            try
            {
                string rutaArchivo = "empleados.txt";

                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("El archivo no existe.");
                    return;
                }

                // Lista para almacenar los datos de empleados
                List<List<string>> datosEmpleados = new List<List<string>>();

                string[] lineas = File.ReadAllLines(rutaArchivo);
                List<string> empleadoActual = new List<string>();

                foreach (string linea in lineas)
                {
                    if (linea.Trim() == "--------------------------------------------------")
                    {
                        if (empleadoActual.Count > 0)
                        {
                            datosEmpleados.Add(new List<string>(empleadoActual));
                            empleadoActual.Clear();
                        }
                    }
                    else
                    {
                        empleadoActual.Add(linea.Substring(linea.IndexOf(":") + 1).Trim());
                    }
                }

                // Agregar el último empleado, si existe
                if (empleadoActual.Count > 0)
                {
                    datosEmpleados.Add(new List<string>(empleadoActual));
                }

                // Mostrar datos en Form9
                Form9 form9 = new Form9();
                form9.CargarDatosEnDataGridView(datosEmpleados);
                form9.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar datos: {ex.Message}");
            }
        }
    }
}
