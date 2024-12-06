namespace SISTEMA
{
    partial class Form11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarEval = new System.Windows.Forms.Button();
            this.idEvalua = new System.Windows.Forms.TextBox();
            this.nombreEvalua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hastaEvalua = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comEvalua = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.califiEvalua = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.desdeEvalua = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardarEvaluacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.califiEvalua)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-11, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(712, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Location = new System.Drawing.Point(611, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 31);
            this.button2.TabIndex = 24;
            this.button2.Text = "<--";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.FlatAppearance.BorderSize = 0;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btncerrar.Location = new System.Drawing.Point(656, -1);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(45, 31);
            this.btncerrar.TabIndex = 23;
            this.btncerrar.Text = "X";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarEval);
            this.groupBox1.Controls.Add(this.idEvalua);
            this.groupBox1.Controls.Add(this.nombreEvalua);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(34, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 77);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del empleado";
            // 
            // btnBuscarEval
            // 
            this.btnBuscarEval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnBuscarEval.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnBuscarEval.FlatAppearance.BorderSize = 0;
            this.btnBuscarEval.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscarEval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEval.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEval.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEval.Location = new System.Drawing.Point(182, 26);
            this.btnBuscarEval.Name = "btnBuscarEval";
            this.btnBuscarEval.Size = new System.Drawing.Size(60, 34);
            this.btnBuscarEval.TabIndex = 29;
            this.btnBuscarEval.Text = "Buscar";
            this.btnBuscarEval.UseVisualStyleBackColor = false;
            this.btnBuscarEval.Click += new System.EventHandler(this.btnBuscarEval_Click);
            // 
            // idEvalua
            // 
            this.idEvalua.Location = new System.Drawing.Point(47, 32);
            this.idEvalua.Name = "idEvalua";
            this.idEvalua.Size = new System.Drawing.Size(100, 22);
            this.idEvalua.TabIndex = 5;
            // 
            // nombreEvalua
            // 
            this.nombreEvalua.Enabled = false;
            this.nombreEvalua.Location = new System.Drawing.Point(322, 29);
            this.nombreEvalua.Name = "nombreEvalua";
            this.nombreEvalua.Size = new System.Drawing.Size(281, 22);
            this.nombreEvalua.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(257, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hastaEvalua);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comEvalua);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.califiEvalua);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.desdeEvalua);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Location = new System.Drawing.Point(34, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 158);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evaluación de desempeño";
            // 
            // hastaEvalua
            // 
            this.hastaEvalua.Location = new System.Drawing.Point(362, 31);
            this.hastaEvalua.Name = "hastaEvalua";
            this.hastaEvalua.Size = new System.Drawing.Size(187, 22);
            this.hastaEvalua.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(298, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Desde:";
            // 
            // comEvalua
            // 
            this.comEvalua.Location = new System.Drawing.Point(165, 112);
            this.comEvalua.Name = "comEvalua";
            this.comEvalua.Size = new System.Drawing.Size(438, 22);
            this.comEvalua.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(18, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Comentarios:";
            // 
            // califiEvalua
            // 
            this.califiEvalua.Location = new System.Drawing.Point(165, 72);
            this.califiEvalua.Name = "califiEvalua";
            this.califiEvalua.Size = new System.Drawing.Size(120, 22);
            this.califiEvalua.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Calificación (1-10):";
            // 
            // desdeEvalua
            // 
            this.desdeEvalua.Location = new System.Drawing.Point(84, 31);
            this.desdeEvalua.Name = "desdeEvalua";
            this.desdeEvalua.Size = new System.Drawing.Size(187, 22);
            this.desdeEvalua.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(18, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desde:";
            // 
            // btnGuardarEvaluacion
            // 
            this.btnGuardarEvaluacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(214)))));
            this.btnGuardarEvaluacion.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnGuardarEvaluacion.FlatAppearance.BorderSize = 0;
            this.btnGuardarEvaluacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnGuardarEvaluacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEvaluacion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEvaluacion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEvaluacion.Location = new System.Drawing.Point(271, 368);
            this.btnGuardarEvaluacion.Name = "btnGuardarEvaluacion";
            this.btnGuardarEvaluacion.Size = new System.Drawing.Size(155, 34);
            this.btnGuardarEvaluacion.TabIndex = 27;
            this.btnGuardarEvaluacion.Text = "Guardar evaluación";
            this.btnGuardarEvaluacion.UseVisualStyleBackColor = false;
            this.btnGuardarEvaluacion.Click += new System.EventHandler(this.btnGuardarEvaluacion_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 420);
            this.Controls.Add(this.btnGuardarEvaluacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form11";
            this.Text = "EVALUACIONEMPL11";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.califiEvalua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nombreEvalua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox comEvalua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown califiEvalua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker desdeEvalua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hastaEvalua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardarEvaluacion;
        private System.Windows.Forms.TextBox idEvalua;
        private System.Windows.Forms.Button btnBuscarEval;
    }
}