﻿namespace TMDbFormApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
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
            lblTitulo = new Label();
            lblTituloOriginal = new Label();
            lblPuntuacionMedia = new Label();
            lblFechaEstreno = new Label();
            lblSinopsis = new Label();
            txtTituloPelicula = new TextBox();
            btnBuscar = new Button();
            lblSimilares = new Label();
            listBoxSimilares = new ListBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(14, 58);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(43, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título: ";
            // 
            // lblTituloOriginal
            // 
            lblTituloOriginal.AutoSize = true;
            lblTituloOriginal.Location = new Point(14, 81);
            lblTituloOriginal.Margin = new Padding(4, 0, 4, 0);
            lblTituloOriginal.Name = "lblTituloOriginal";
            lblTituloOriginal.Size = new Size(88, 15);
            lblTituloOriginal.TabIndex = 1;
            lblTituloOriginal.Text = "Título original: ";
            // 
            // lblPuntuacionMedia
            // 
            lblPuntuacionMedia.AutoSize = true;
            lblPuntuacionMedia.Location = new Point(14, 104);
            lblPuntuacionMedia.Margin = new Padding(4, 0, 4, 0);
            lblPuntuacionMedia.Name = "lblPuntuacionMedia";
            lblPuntuacionMedia.Size = new Size(110, 15);
            lblPuntuacionMedia.TabIndex = 2;
            lblPuntuacionMedia.Text = "Puntuación media: ";
            // 
            // lblFechaEstreno
            // 
            lblFechaEstreno.AutoSize = true;
            lblFechaEstreno.Location = new Point(14, 127);
            lblFechaEstreno.Margin = new Padding(4, 0, 4, 0);
            lblFechaEstreno.Name = "lblFechaEstreno";
            lblFechaEstreno.Size = new Size(86, 15);
            lblFechaEstreno.TabIndex = 3;
            lblFechaEstreno.Text = "Fecha estreno: ";
            // 
            // lblSinopsis
            // 
            lblSinopsis.AutoSize = true;
            lblSinopsis.Location = new Point(14, 150);
            lblSinopsis.Margin = new Padding(4, 0, 4, 0);
            lblSinopsis.Name = "lblSinopsis";
            lblSinopsis.Size = new Size(56, 15);
            lblSinopsis.TabIndex = 4;
            lblSinopsis.Text = "Sinopsis: ";
            // 
            // txtTituloPelicula
            // 
            txtTituloPelicula.Location = new Point(14, 14);
            txtTituloPelicula.Margin = new Padding(4, 3, 4, 3);
            txtTituloPelicula.Name = "txtTituloPelicula";
            txtTituloPelicula.Size = new Size(233, 23);
            txtTituloPelicula.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(254, 12);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 27);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblSimilares
            // 
            lblSimilares.AutoSize = true;
            lblSimilares.Location = new Point(14, 172);
            lblSimilares.Name = "lblSimilares";
            lblSimilares.Size = new Size(108, 15);
            lblSimilares.TabIndex = 9;
            lblSimilares.Text = "Peliculas similares: ";
            // 
            // listBoxSimilares
            // 
            listBoxSimilares.FormattingEnabled = true;
            listBoxSimilares.ItemHeight = 15;
            listBoxSimilares.Location = new Point(14, 192);
            listBoxSimilares.Margin = new Padding(4, 3, 4, 3);
            listBoxSimilares.Name = "listBoxSimilares";
            listBoxSimilares.Size = new Size(328, 109);
            listBoxSimilares.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(254, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(88, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(354, 311);
            Controls.Add(lblSimilares);
            Controls.Add(pictureBox1);
            Controls.Add(listBoxSimilares);
            Controls.Add(btnBuscar);
            Controls.Add(txtTituloPelicula);
            Controls.Add(lblSinopsis);
            Controls.Add(lblFechaEstreno);
            Controls.Add(lblPuntuacionMedia);
            Controls.Add(lblTituloOriginal);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "TMDb Form API";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTituloOriginal;
        private System.Windows.Forms.Label lblPuntuacionMedia;
        private System.Windows.Forms.Label lblFechaEstreno;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.TextBox txtTituloPelicula;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox listBoxSimilares;
        private PictureBox pictureBox1;
        private Label lblSimilares;
    }
}
