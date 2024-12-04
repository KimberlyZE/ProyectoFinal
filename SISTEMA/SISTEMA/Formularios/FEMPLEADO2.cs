using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SISTEMA.Form1;

namespace SISTEMA
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            string idUsuarioActual = SesionUsuario.IdUsuario;

            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            ENTRADA6 entradaForm = new ENTRADA6();
            this.Hide();
            entradaForm.Show(); // Muestra el formulario
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            Form7 salidaForm = new Form7();
            this.Hide();
            salidaForm.Show(); // Muestra el formulario
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
