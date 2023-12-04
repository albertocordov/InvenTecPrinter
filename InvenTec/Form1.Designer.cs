namespace InvenTec
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConsultarPorArea = new System.Windows.Forms.Button();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDeptos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridActivos = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pictureBoxEtiqueta = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConsultarIndividual = new System.Windows.Forms.Button();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblConectividad = new System.Windows.Forms.Label();
            this.btnConectividad = new System.Windows.Forms.Button();
            this.cmbImpresoraZebra = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultarPorArea);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbDeptos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.groupBox1.Location = new System.Drawing.Point(10, 221);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(304, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresión por área";
            // 
            // btnConsultarPorArea
            // 
            this.btnConsultarPorArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.btnConsultarPorArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarPorArea.ForeColor = System.Drawing.Color.White;
            this.btnConsultarPorArea.Location = new System.Drawing.Point(13, 121);
            this.btnConsultarPorArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConsultarPorArea.Name = "btnConsultarPorArea";
            this.btnConsultarPorArea.Size = new System.Drawing.Size(273, 31);
            this.btnConsultarPorArea.TabIndex = 4;
            this.btnConsultarPorArea.Text = "Consultar";
            this.btnConsultarPorArea.UseVisualStyleBackColor = false;
            this.btnConsultarPorArea.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(13, 92);
            this.cmbArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(273, 23);
            this.cmbArea.TabIndex = 3;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione área";
            // 
            // cmbDeptos
            // 
            this.cmbDeptos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeptos.FormattingEnabled = true;
            this.cmbDeptos.Location = new System.Drawing.Point(13, 43);
            this.cmbDeptos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDeptos.Name = "cmbDeptos";
            this.cmbDeptos.Size = new System.Drawing.Size(273, 23);
            this.cmbDeptos.TabIndex = 1;
            this.cmbDeptos.SelectedIndexChanged += new System.EventHandler(this.cmbDeptos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione departamento";
            // 
            // dataGridActivos
            // 
            this.dataGridActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridActivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridActivos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridActivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridActivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridActivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridActivos.ColumnHeadersHeight = 28;
            this.dataGridActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridActivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridActivos.EnableHeadersVisualStyles = false;
            this.dataGridActivos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridActivos.Location = new System.Drawing.Point(11, 408);
            this.dataGridActivos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridActivos.Name = "dataGridActivos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridActivos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridActivos.RowHeadersVisible = false;
            this.dataGridActivos.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridActivos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridActivos.RowTemplate.Height = 24;
            this.dataGridActivos.Size = new System.Drawing.Size(614, 118);
            this.dataGridActivos.TabIndex = 2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(11, 703);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(614, 38);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pictureBoxEtiqueta
            // 
            this.pictureBoxEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxEtiqueta.Location = new System.Drawing.Point(194, 556);
            this.pictureBoxEtiqueta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBoxEtiqueta.Name = "pictureBoxEtiqueta";
            this.pictureBoxEtiqueta.Size = new System.Drawing.Size(272, 141);
            this.pictureBoxEtiqueta.TabIndex = 4;
            this.pictureBoxEtiqueta.TabStop = false;
            this.pictureBoxEtiqueta.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.label3.Location = new System.Drawing.Point(251, 538);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vista previa de la etiqueta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 76);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(604, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(78, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 43);
            this.label5.TabIndex = 1;
            this.label5.Text = "InvenTec";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ingrese ID del activo";
            // 
            // btnConsultarIndividual
            // 
            this.btnConsultarIndividual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.btnConsultarIndividual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarIndividual.ForeColor = System.Drawing.Color.White;
            this.btnConsultarIndividual.Location = new System.Drawing.Point(13, 75);
            this.btnConsultarIndividual.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConsultarIndividual.Name = "btnConsultarIndividual";
            this.btnConsultarIndividual.Size = new System.Drawing.Size(264, 31);
            this.btnConsultarIndividual.TabIndex = 4;
            this.btnConsultarIndividual.Text = "Consultar";
            this.btnConsultarIndividual.UseVisualStyleBackColor = false;
            this.btnConsultarIndividual.Click += new System.EventHandler(this.btnConsultarIndividual_Click);
            // 
            // txtActivo
            // 
            this.txtActivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivo.Location = new System.Drawing.Point(13, 46);
            this.txtActivo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(264, 23);
            this.txtActivo.TabIndex = 5;
            this.txtActivo.TextChanged += new System.EventHandler(this.txtActivo_TextChanged);
            this.txtActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActivo_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtActivo);
            this.groupBox2.Controls.Add(this.btnConsultarIndividual);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.groupBox2.Location = new System.Drawing.Point(331, 221);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(294, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impresión individual";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblConectividad);
            this.groupBox3.Controls.Add(this.btnConectividad);
            this.groupBox3.Controls.Add(this.cmbImpresoraZebra);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.groupBox3.Location = new System.Drawing.Point(11, 86);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(614, 129);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conectividad";
            // 
            // lblConectividad
            // 
            this.lblConectividad.AutoSize = true;
            this.lblConectividad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConectividad.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConectividad.Location = new System.Drawing.Point(251, 46);
            this.lblConectividad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConectividad.Name = "lblConectividad";
            this.lblConectividad.Size = new System.Drawing.Size(93, 17);
            this.lblConectividad.TabIndex = 5;
            this.lblConectividad.Text = "No conectado";
            // 
            // btnConectividad
            // 
            this.btnConectividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.btnConectividad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectividad.ForeColor = System.Drawing.Color.White;
            this.btnConectividad.Location = new System.Drawing.Point(12, 81);
            this.btnConectividad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConectividad.Name = "btnConectividad";
            this.btnConectividad.Size = new System.Drawing.Size(598, 31);
            this.btnConectividad.TabIndex = 4;
            this.btnConectividad.Text = "Conectarse";
            this.btnConectividad.UseVisualStyleBackColor = false;
            this.btnConectividad.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmbImpresoraZebra
            // 
            this.cmbImpresoraZebra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImpresoraZebra.FormattingEnabled = true;
            this.cmbImpresoraZebra.Location = new System.Drawing.Point(13, 43);
            this.cmbImpresoraZebra.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbImpresoraZebra.Name = "cmbImpresoraZebra";
            this.cmbImpresoraZebra.Size = new System.Drawing.Size(234, 23);
            this.cmbImpresoraZebra.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(11, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Impresoras Zebra disponibles (USB)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 750);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxEtiqueta);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dataGridActivos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "InvenTec - Impresión de etiquetas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtiqueta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDeptos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarPorArea;
        private System.Windows.Forms.DataGridView dataGridActivos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PictureBox pictureBoxEtiqueta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConsultarIndividual;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConectividad;
        private System.Windows.Forms.ComboBox cmbImpresoraZebra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblConectividad;
    }
}

