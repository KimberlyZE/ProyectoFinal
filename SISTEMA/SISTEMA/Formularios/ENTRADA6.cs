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
    public partial class ENTRADA6 : Form
    {
        public ENTRADA6()
        {
            InitializeComponent();
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
            Form2 form2 = new Form2(); // Crea una nueva instancia de Form2
            form2.Show();
        }

        private void ENTRADA6_Load(object sender, EventArgs e)
        {

        }

        private void REGISTRARHORA_Click(object sender, EventArgs e)
        {

        }
    }
}
