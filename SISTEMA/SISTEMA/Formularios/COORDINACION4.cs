﻿using System;
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
    public partial class COORDINACION4 : Form
    {
        public COORDINACION4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            VALIDARASIS10 nuevoForm = new VALIDARASIS10();
            this.Hide();
            nuevoForm.Show();
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {

            Form11 nuevoForm = new Form11();
            this.Hide();
            nuevoForm.Show();
        }
    }
}
