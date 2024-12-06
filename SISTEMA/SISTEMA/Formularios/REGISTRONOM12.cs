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
using Microsoft.Reporting.WinForms;
using SISTEMA.Clases;
using SISTEMA.Formularios;
using SISTEMA.DataSet;

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

        private void LimpiarCampos()
        {
            idNomi.Text = string.Empty;
            nombreNomi.Text = string.Empty;
            cedulaNomi.Text = string.Empty;
            puestoNomi.Text = string.Empty;
            areaNomi.Text = string.Empty;
            turnoNomi.Text = string.Empty;
            salarioNomi.Text = string.Empty;
            inssnomi.Text = string.Empty;
            salanetoNomi.Text = string.Empty;
            salarioBruto = 0;
        }

        private void guardarNomi_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los datos necesarios estén completos.
                if (string.IsNullOrWhiteSpace(nombreNomi.Text) ||
                    string.IsNullOrWhiteSpace(cedulaNomi.Text) ||
                    string.IsNullOrWhiteSpace(puestoNomi.Text) ||
                    string.IsNullOrWhiteSpace(areaNomi.Text) ||
                    string.IsNullOrWhiteSpace(turnoNomi.Text) ||
                    salarioBruto <= 0)
                {
                    MessageBox.Show("Por favor, completa todos los datos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Formato de los datos a guardar.
                string registro = $"ID: {idNomi.Text}\n" +
                                  $"Nombre: {nombreNomi.Text}\n" +
                                  $"Cédula: {cedulaNomi.Text}\n" +
                                  $"Puesto: {puestoNomi.Text}\n" +
                                  $"Área: {areaNomi.Text}\n" +
                                  $"Turno: {turnoNomi.Text}\n" +
                                  $"Salario Bruto: {salarioNomi.Text}\n" +
                                  $"INSS: {inssnomi.Text}\n" +
                                  $"Salario Neto: {salanetoNomi.Text}\n" +
                                  "--------------------------------------------------\n";

                // Guardar en el archivo "registros de nomina.txt".
                string archivo = "RegistrosdeNominas.txt";
                File.AppendAllText(archivo, registro);

                MessageBox.Show("Datos de nómina guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después de guardar.
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DsNomina miDataSet = new DsNomina();


            ReportDataSource dataSource = new ReportDataSource("DsDatos", miDataSet.Tables["NominaDT"]);
            FrmReporte frm = new FrmReporte();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SISTEMA.Reportes.RptNomina.rdlc";
            frm.reportViewer1.RefreshReport();
            frm.ShowDialog();

        }
        private void LlenarDataTableDesdeArchivo(string rutaArchivo, DataTable tabla)
        {
            // Lee las líneas del archivo
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                // Divide los valores según el separador (coma en este caso)
                string[] valores = linea.Split(',');

                // Agrega una nueva fila al DataTable
                tabla.Rows.Add(valores);
            }
        }
    }
    
}
