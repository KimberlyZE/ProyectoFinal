namespace SISTEMA
{
    partial class COORDINACION4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COORDINACION4));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncerrar = new System.Windows.Forms.Button();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 461);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(411, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Selecciona tu opción correspondiente";
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.FlatAppearance.BorderSize = 0;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btncerrar.Location = new System.Drawing.Point(659, -2);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(45, 31);
            this.btncerrar.TabIndex = 28;
            this.btncerrar.Text = "X";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnRegistrarSalida.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnRegistrarSalida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnRegistrarSalida.Location = new System.Drawing.Point(414, 270);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(251, 63);
            this.btnRegistrarSalida.TabIndex = 30;
            this.btnRegistrarSalida.Text = "Evaluación y reporte general";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // btnRegistrarEntrada
            // 
            this.btnRegistrarEntrada.BackColor = System.Drawing.Color.White;
            this.btnRegistrarEntrada.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnRegistrarEntrada.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnRegistrarEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegistrarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEntrada.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(414, 164);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(251, 63);
            this.btnRegistrarEntrada.TabIndex = 29;
            this.btnRegistrarEntrada.Text = "Validar asistencia y horas extras";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = false;
            this.btnRegistrarEntrada.Click += new System.EventHandler(this.btnRegistrarEntrada_Click);
            // 
            // COORDINACION4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 421);
            this.Controls.Add(this.btnRegistrarSalida);
            this.Controls.Add(this.btnRegistrarEntrada);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "COORDINACION4";
            this.Text = "COORDINACION4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Button btnRegistrarEntrada;
    }
}