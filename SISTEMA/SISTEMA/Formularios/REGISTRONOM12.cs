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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void buscarNomi_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID ingresado
                string idEmpleado = idNomi.Text.Trim();

                // Validar si el ID fue ingresado
                if (string.IsNullOrEmpty(idEmpleado))
                {
                    MessageBox.Show("Por favor, ingresa un ID de empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Leer todo el archivo de empleados.txt
                string[] empleados = File.ReadAllLines("empleados.txt");

                // Variables para almacenar los datos del empleado
                string nombreEmpleado = string.Empty;
                string cedula = string.Empty;
                string puesto = string.Empty;
                string area = string.Empty;
                string turno = string.Empty;
                decimal salarioBruto = 0;

                // Bandera para verificar si el empleado fue encontrado
                bool encontrado = false;

                // Iterar por cada línea en el archivo
                for (int i = 0; i < empleados.Length; i++)
                {
                    // Mostrar en consola los valores que estamos leyendo para depurar
                    Console.WriteLine($"Leyendo línea {i + 1}: {empleados[i]}");

                    // Verificar si la línea contiene el ID del empleado
                    if (empleados[i].Contains($"ID: {idEmpleado}"))
                    {
                        encontrado = true;
                        Console.WriteLine($"Empleado encontrado con ID: {idEmpleado}");

                        // Leer los datos del empleado en las siguientes líneas
                        nombreEmpleado = empleados[i + 1].Replace("Nombre:", "").Trim();
                        cedula = empleados[i + 2].Replace("Cédula:", "").Trim();
                        puesto = empleados[i + 9].Replace("Puesto:", "").Trim();
                        area = empleados[i + 10].Replace("Área:", "").Trim();
                        turno = empleados[i + 8].Replace("Turno:", "").Trim();

                        // Limpiar y convertir el salario
                        string salarioTexto = empleados[i + 11].Replace("Salario:", "").Trim();
                        salarioTexto = salarioTexto.Replace(",", ""); // Eliminar comas si las hay
                        Console.WriteLine($"Salario encontrado: {salarioTexto}");

                        // Intentar convertir el salario
                        if (!decimal.TryParse(salarioTexto, out salarioBruto))
                        {
                            MessageBox.Show($"El salario para el empleado con ID {idEmpleado} no tiene el formato correcto.",
                                            "Error de Formato",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }

                        break;  // Salir del ciclo después de encontrar al empleado
                    }
                }

                // Si no se encontró el empleado, mostrar mensaje
                if (!encontrado)
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar los datos a los controles del formulario
                nombreNomi.Text = nombreEmpleado;
                cedulaNomi.Text = cedula;
                puestoNomi.Text = puesto;
                areaNomi.Text = area;
                salarioNomi.Text = salarioBruto.ToString("C"); // Formato de moneda
                turnoNomi.Text = turno;

                // Mostrar los datos encontrados en consola (opcional, solo para depuración)
                Console.WriteLine($"Nombre: {nombreEmpleado}, Cédula: {cedula}, Puesto: {puesto}, Área: {area}, Turno: {turno}, Salario: {salarioBruto:C}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
