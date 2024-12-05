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
        private decimal salarioBruto; // Definir la variable salarioBruto a nivel de clase

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
            try
            {
                // Verificar que salarioBruto tenga un valor válido antes de calcular.
                if (salarioBruto <= 0)
                {
                    MessageBox.Show("El salario bruto debe ser mayor a cero para realizar el cálculo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cálculo del INSS.
                decimal inss = salarioBruto * 0.07m;

                // Cálculo del IR basado en tramos.
                decimal ir = 0;
                if (salarioBruto > 100000)
                {
                    decimal exceso = salarioBruto - 100000;
                    if (exceso <= 200000)
                        ir = exceso * 0.15m;
                    else if (exceso <= 300000)
                        ir = exceso * 0.20m;
                    else if (exceso <= 500000)
                        ir = exceso * 0.25m;
                    else
                        ir = exceso * 0.30m;
                }

                // Salario Neto.
                decimal salarioNeto = salarioBruto - inss - ir;

                // Mostrar resultados en los controles de la UI.
                inssnomi.Text = inss.ToString("C");
                salanetoNomi.Text = salarioNeto.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el salario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarNomi_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID ingresado
                string idEmpleado = idNomi.Text.Trim();

                if (string.IsNullOrEmpty(idEmpleado))
                {
                    MessageBox.Show("Por favor, ingresa un ID de empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Leer el archivo completo
                string[] empleados = File.ReadAllLines("empleados.txt");
                bool encontrado = false;

                // Variables para guardar datos del empleado
                string nombreEmpleado = string.Empty;
                string cedula = string.Empty;
                string puesto = string.Empty;
                string area = string.Empty;
                string turno = string.Empty;

                // Procesar línea por línea
                for (int i = 0; i < empleados.Length; i++)
                {
                    // Buscar el ID
                    if (empleados[i].StartsWith($"ID: {idEmpleado}"))
                    {
                        encontrado = true;

                        // Leer los siguientes datos
                        Dictionary<string, string> datos = new Dictionary<string, string>();
                        for (int j = i + 1; j < empleados.Length; j++)
                        {
                            if (empleados[j].StartsWith("--------------------------------------------------"))
                                break;

                            string[] partes = empleados[j].Split(new char[] { ':' }, 2);
                            if (partes.Length == 2)
                            {
                                string clave = partes[0].Trim();
                                string valor = partes[1].Trim();
                                datos[clave] = valor;
                            }
                        }

                        // Asignar datos si existen
                        datos.TryGetValue("Nombre", out nombreEmpleado);
                        datos.TryGetValue("Cédula", out cedula);
                        datos.TryGetValue("Puesto", out puesto);
                        datos.TryGetValue("Área", out area);
                        datos.TryGetValue("Turno", out turno);

                        if (datos.TryGetValue("Salario", out string salarioTexto))
                        {
                            salarioTexto = salarioTexto.Replace(",", "");
                            if (!decimal.TryParse(salarioTexto, out salarioBruto))
                            {
                                MessageBox.Show("Error al convertir el salario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar datos en controles
                nombreNomi.Text = nombreEmpleado;
                cedulaNomi.Text = cedula;
                puestoNomi.Text = puesto;
                areaNomi.Text = area;
                turnoNomi.Text = turno;
                salarioNomi.Text = salarioBruto.ToString("C");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CONTADURIA5 form = new CONTADURIA5();
            form.Show();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
    
}
