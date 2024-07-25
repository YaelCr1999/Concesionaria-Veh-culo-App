namespace TrabajoFinal
{
    partial class FormListaElim
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
            this.dtg_Vehiculos_Elim = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Vehiculos_Elim)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_Vehiculos_Elim
            // 
            this.dtg_Vehiculos_Elim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Vehiculos_Elim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_Vehiculos_Elim.Location = new System.Drawing.Point(3, 22);
            this.dtg_Vehiculos_Elim.Name = "dtg_Vehiculos_Elim";
            this.dtg_Vehiculos_Elim.ReadOnly = true;
            this.dtg_Vehiculos_Elim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_Vehiculos_Elim.Size = new System.Drawing.Size(714, 219);
            this.dtg_Vehiculos_Elim.TabIndex = 0;
            this.dtg_Vehiculos_Elim.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Vehiculos_Elim_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehiculos eliminados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtg_Vehiculos_Elim);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 244);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registros Eliminados";
            // 
            // FormListaElim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(744, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormListaElim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListaElim";
            this.Load += new System.EventHandler(this.FormListaElim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Vehiculos_Elim)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_Vehiculos_Elim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}