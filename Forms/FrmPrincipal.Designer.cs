namespace GestorBiblioteca.Forms
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtAño = new TextBox();
            chkDisponible = new CheckBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            dgvLibros = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            tabPage2 = new TabPage();
            dgvPrestamos = new DataGridView();
            btnRegistrarDevolucion = new Button();
            btnRegistrarPrestamo = new Button();
            dtpFechaPrestamo = new DateTimePicker();
            txtIdLibroPrestamo = new TextBox();
            txtIdUsuarioPrestamo = new TextBox();
            txtIdPrestamo = new TextBox();
            lblIdPrestamo = new Label();
            lblIdUsuarioPrestamo = new Label();
            lblIdLibroPrestamo = new Label();
            lblFechaPrestamo = new Label();
            label7 = new Label();
            label6 = new Label();
            dgvUsuarios = new DataGridView();
            btnEditarUsuario = new Button();
            btnEliminarUsuario = new Button();
            btnAgregarUsuario = new Button();
            chkActivoUsuario = new CheckBox();
            txtIdUsuario = new TextBox();
            txtCorreoUsuario = new TextBox();
            txtNombreUsuario = new TextBox();
            lblCorreoUsuario = new Label();
            lblNombreUsuario = new Label();
            lblIdUsuario = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 88);
            label2.Name = "label2";
            label2.Size = new Size(21, 17);
            label2.TabIndex = 2;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(153, 88);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 3;
            label3.Text = "Titulo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(342, 88);
            label4.Name = "label4";
            label4.Size = new Size(43, 17);
            label4.TabIndex = 4;
            label4.Text = "Autor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(543, 88);
            label5.Name = "label5";
            label5.Size = new Size(33, 17);
            label5.TabIndex = 5;
            label5.Text = "Año";
            // 
            // txtID
            // 
            txtID.Location = new Point(29, 108);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 6;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(153, 108);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(161, 23);
            txtTitulo.TabIndex = 7;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(342, 108);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(163, 23);
            txtAutor.TabIndex = 8;
            // 
            // txtAño
            // 
            txtAño.Location = new Point(543, 109);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(100, 23);
            txtAño.TabIndex = 9;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Location = new Point(29, 156);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(82, 19);
            chkDisponible.TabIndex = 10;
            chkDisponible.Text = "Disponible";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(192, 255, 192);
            btnAgregar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(29, 194);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 27);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.LightSkyBlue;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(153, 194);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 27);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightCoral;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(281, 194);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 27);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.BackgroundColor = SystemColors.ControlDarkDark;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(29, 272);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.Size = new Size(744, 413);
            dgvLibros.TabIndex = 14;
            dgvLibros.CellClick += dgvLibros_CellClick;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1631, 853);
            tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Silver;
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dgvLibros);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtID);
            tabPage1.Controls.Add(txtTitulo);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtAño);
            tabPage1.Controls.Add(chkDisponible);
            tabPage1.Controls.Add(txtAutor);
            tabPage1.Controls.Add(btnAgregar);
            tabPage1.Controls.Add(btnEditar);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1623, 825);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Libros y Graficas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SteelBlue;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 16);
            label1.Name = "label1";
            label1.Size = new Size(240, 37);
            label1.TabIndex = 15;
            label1.Text = "Gestion de Libros";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Silver;
            tabPage2.Controls.Add(dgvPrestamos);
            tabPage2.Controls.Add(btnRegistrarDevolucion);
            tabPage2.Controls.Add(btnRegistrarPrestamo);
            tabPage2.Controls.Add(dtpFechaPrestamo);
            tabPage2.Controls.Add(txtIdLibroPrestamo);
            tabPage2.Controls.Add(txtIdUsuarioPrestamo);
            tabPage2.Controls.Add(txtIdPrestamo);
            tabPage2.Controls.Add(lblIdPrestamo);
            tabPage2.Controls.Add(lblIdUsuarioPrestamo);
            tabPage2.Controls.Add(lblIdLibroPrestamo);
            tabPage2.Controls.Add(lblFechaPrestamo);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(dgvUsuarios);
            tabPage2.Controls.Add(btnEditarUsuario);
            tabPage2.Controls.Add(btnEliminarUsuario);
            tabPage2.Controls.Add(btnAgregarUsuario);
            tabPage2.Controls.Add(chkActivoUsuario);
            tabPage2.Controls.Add(txtIdUsuario);
            tabPage2.Controls.Add(txtCorreoUsuario);
            tabPage2.Controls.Add(txtNombreUsuario);
            tabPage2.Controls.Add(lblCorreoUsuario);
            tabPage2.Controls.Add(lblNombreUsuario);
            tabPage2.Controls.Add(lblIdUsuario);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1623, 825);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Usuarios y Prestamos";
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.BackgroundColor = SystemColors.ControlDarkDark;
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(854, 280);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.Size = new Size(716, 471);
            dgvPrestamos.TabIndex = 23;
            dgvPrestamos.CellClick += dgvPrestamos_CellClick;
            dgvPrestamos.CellContentClick += dgvPrestamos_CellContentClick;
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.BackColor = Color.LightCoral;
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarDevolucion.Location = new Point(1068, 158);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(126, 27);
            btnRegistrarDevolucion.TabIndex = 22;
            btnRegistrarDevolucion.Text = "Registrar Devolucion";
            btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = Color.FromArgb(192, 255, 192);
            btnRegistrarPrestamo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarPrestamo.Location = new Point(854, 158);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(135, 27);
            btnRegistrarPrestamo.TabIndex = 21;
            btnRegistrarPrestamo.Text = "Registrar Prestamo";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += btnRegistrarPrestamo_Click;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(1250, 97);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(200, 23);
            dtpFechaPrestamo.TabIndex = 20;
            // 
            // txtIdLibroPrestamo
            // 
            txtIdLibroPrestamo.Location = new Point(1115, 100);
            txtIdLibroPrestamo.Name = "txtIdLibroPrestamo";
            txtIdLibroPrestamo.Size = new Size(100, 23);
            txtIdLibroPrestamo.TabIndex = 19;
            // 
            // txtIdUsuarioPrestamo
            // 
            txtIdUsuarioPrestamo.Location = new Point(985, 100);
            txtIdUsuarioPrestamo.Name = "txtIdUsuarioPrestamo";
            txtIdUsuarioPrestamo.Size = new Size(100, 23);
            txtIdUsuarioPrestamo.TabIndex = 18;
            // 
            // txtIdPrestamo
            // 
            txtIdPrestamo.Location = new Point(854, 100);
            txtIdPrestamo.Name = "txtIdPrestamo";
            txtIdPrestamo.Size = new Size(100, 23);
            txtIdPrestamo.TabIndex = 17;
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdPrestamo.Location = new Point(854, 80);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.Size = new Size(83, 17);
            lblIdPrestamo.TabIndex = 16;
            lblIdPrestamo.Text = "ID Prestamo";
            // 
            // lblIdUsuarioPrestamo
            // 
            lblIdUsuarioPrestamo.AutoSize = true;
            lblIdUsuarioPrestamo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdUsuarioPrestamo.Location = new Point(985, 80);
            lblIdUsuarioPrestamo.Name = "lblIdUsuarioPrestamo";
            lblIdUsuarioPrestamo.Size = new Size(71, 17);
            lblIdUsuarioPrestamo.TabIndex = 15;
            lblIdUsuarioPrestamo.Text = "ID Usuario";
            // 
            // lblIdLibroPrestamo
            // 
            lblIdLibroPrestamo.AutoSize = true;
            lblIdLibroPrestamo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdLibroPrestamo.Location = new Point(1115, 80);
            lblIdLibroPrestamo.Name = "lblIdLibroPrestamo";
            lblIdLibroPrestamo.Size = new Size(55, 17);
            lblIdLibroPrestamo.TabIndex = 14;
            lblIdLibroPrestamo.Text = "ID Libro";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaPrestamo.Location = new Point(1250, 82);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(91, 15);
            lblFechaPrestamo.TabIndex = 13;
            lblFechaPrestamo.Text = "Fecha Prestamo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.SteelBlue;
            label7.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(854, 16);
            label7.Name = "label7";
            label7.Size = new Size(277, 37);
            label7.TabIndex = 12;
            label7.Text = "Prestamos de Libros";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.SteelBlue;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 16);
            label6.Name = "label6";
            label6.Size = new Size(233, 37);
            label6.TabIndex = 11;
            label6.Text = "Gestion Usuarios";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.BackgroundColor = SystemColors.ControlDarkDark;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(30, 280);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(710, 471);
            dgvUsuarios.TabIndex = 10;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.BackColor = Color.LightSkyBlue;
            btnEditarUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarUsuario.Location = new Point(160, 210);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(75, 27);
            btnEditarUsuario.TabIndex = 9;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = false;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.BackColor = Color.LightCoral;
            btnEliminarUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarUsuario.Location = new Point(287, 210);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(75, 27);
            btnEliminarUsuario.TabIndex = 8;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = false;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.FromArgb(192, 255, 192);
            btnAgregarUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.Location = new Point(30, 210);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(75, 27);
            btnAgregarUsuario.TabIndex = 7;
            btnAgregarUsuario.Text = "Agregar";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // chkActivoUsuario
            // 
            chkActivoUsuario.AutoSize = true;
            chkActivoUsuario.Location = new Point(30, 166);
            chkActivoUsuario.Name = "chkActivoUsuario";
            chkActivoUsuario.Size = new Size(60, 19);
            chkActivoUsuario.TabIndex = 6;
            chkActivoUsuario.Text = "Activo";
            chkActivoUsuario.UseVisualStyleBackColor = true;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(30, 100);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new Size(100, 23);
            txtIdUsuario.TabIndex = 5;
            // 
            // txtCorreoUsuario
            // 
            txtCorreoUsuario.Location = new Point(364, 100);
            txtCorreoUsuario.Name = "txtCorreoUsuario";
            txtCorreoUsuario.Size = new Size(180, 23);
            txtCorreoUsuario.TabIndex = 4;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(160, 100);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(185, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // lblCorreoUsuario
            // 
            lblCorreoUsuario.AutoSize = true;
            lblCorreoUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreoUsuario.Location = new Point(364, 80);
            lblCorreoUsuario.Name = "lblCorreoUsuario";
            lblCorreoUsuario.Size = new Size(49, 17);
            lblCorreoUsuario.TabIndex = 2;
            lblCorreoUsuario.Text = "Correo";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(160, 80);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(58, 17);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdUsuario.Location = new Point(30, 80);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(71, 17);
            lblIdUsuario.TabIndex = 0;
            lblIdUsuario.Text = "ID Usuario";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1663, 921);
            Controls.Add(tabControl1);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Biblioteca";
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtAño;
        private CheckBox chkDisponible;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridView dgvLibros;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private TabPage tabPage2;
        private DataGridView dgvUsuarios;
        private Button btnEditarUsuario;
        private Button btnEliminarUsuario;
        private Button btnAgregarUsuario;
        private CheckBox chkActivoUsuario;
        private TextBox txtIdUsuario;
        private TextBox txtCorreoUsuario;
        private TextBox txtNombreUsuario;
        private Label lblCorreoUsuario;
        private Label lblNombreUsuario;
        private Label lblIdUsuario;
        private Label label6;
        private Label lblIdPrestamo;
        private Label lblIdUsuarioPrestamo;
        private Label lblIdLibroPrestamo;
        private Label lblFechaPrestamo;
        private Label label7;
        private DataGridView dgvPrestamos;
        private Button btnRegistrarDevolucion;
        private Button btnRegistrarPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private TextBox txtIdLibroPrestamo;
        private TextBox txtIdUsuarioPrestamo;
        private TextBox txtIdPrestamo;
    }
}
