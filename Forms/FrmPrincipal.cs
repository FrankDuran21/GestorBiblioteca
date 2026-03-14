using GestorBiblioteca.Models;
using GestorBiblioteca.Services;
using System;
using System.Windows.Forms;

namespace GestorBiblioteca.Forms
{
    public partial class FrmPrincipal : Form
    {
        private BibliotecaService biblioteca = new BibliotecaService();
        private BindingSource bsLibros = new BindingSource();
        private BindingSource bsUsuarios = new BindingSource();

        public FrmPrincipal()
        {
            InitializeComponent();

            // TABLA LIBROS
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.MultiSelect = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.ReadOnly = true;
            dgvLibros.AutoGenerateColumns = true;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bsLibros.DataSource = biblioteca.ObtenerLibros();
            dgvLibros.DataSource = bsLibros;

            // TABLA USUARIOS
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AutoGenerateColumns = true;

            bsUsuarios.DataSource = biblioteca.ObtenerUsuarios();
            dgvUsuarios.DataSource = bsUsuarios;
        }

        // ===============================
        // REFRESCAR TABLAS
        // ===============================

        private void RefrescarLibros()
        {
            bsLibros.DataSource = null;
            bsLibros.DataSource = biblioteca.ObtenerLibros();
            dgvLibros.DataSource = bsLibros;
            dgvLibros.ClearSelection();
        }

        private void RefrescarUsuarios()
        {
            bsUsuarios.DataSource = null;
            bsUsuarios.DataSource = biblioteca.ObtenerUsuarios();
            dgvUsuarios.DataSource = bsUsuarios;
            dgvUsuarios.ClearSelection();
        }

        // ===============================
        // VALIDACIÓN LIBROS
        // ===============================

        private bool ValidarCamposLibro(out int id, out int anio)
        {
            id = 0;
            anio = 0;

            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtAño.Text))
            {
                MessageBox.Show("Completa todos los campos del libro.");
                return false;
            }

            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("El ID del libro debe ser numérico.");
                return false;
            }

            if (!int.TryParse(txtAño.Text, out anio))
            {
                MessageBox.Show("El año debe ser numérico.");
                return false;
            }

            return true;
        }

        private void LimpiarCamposLibro()
        {
            txtID.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtAño.Text = "";
            chkDisponible.Checked = false;
        }

        // ===============================
        // CRUD LIBROS
        // ===============================

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposLibro(out int id, out int anio))
                return;

            if (biblioteca.ExisteLibro(id))
            {
                MessageBox.Show("Ya existe un libro con ese ID.");
                return;
            }

            Libro libro = new Libro()
            {
                Id = id,
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Anio = anio,
                Disponible = chkDisponible.Checked
            };

            biblioteca.AgregarLibro(libro);
            RefrescarLibros();
            LimpiarCamposLibro();

            MessageBox.Show("Libro agregado correctamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposLibro(out int id, out int anio))
                return;

            Libro libro = new Libro()
            {
                Id = id,
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Anio = anio,
                Disponible = chkDisponible.Checked
            };

            bool actualizado = biblioteca.ActualizarLibro(libro);

            if (!actualizado)
            {
                MessageBox.Show("No existe un libro con ese ID para editar.");
                return;
            }

            RefrescarLibros();
            LimpiarCamposLibro();

            MessageBox.Show("Libro editado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Ingresa un ID válido para eliminar.");
                return;
            }

            bool eliminado = biblioteca.EliminarLibro(id);

            if (!eliminado)
            {
                MessageBox.Show("No existe un libro con ese ID.");
                return;
            }

            RefrescarLibros();
            LimpiarCamposLibro();

            MessageBox.Show("Libro eliminado correctamente.");
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLibros.Rows.Count)
                return;

            if (dgvLibros.Rows[e.RowIndex].DataBoundItem is not Libro libroSeleccionado)
                return;

            txtID.Text = libroSeleccionado.Id.ToString();
            txtTitulo.Text = libroSeleccionado.Titulo;
            txtAutor.Text = libroSeleccionado.Autor;
            txtAño.Text = libroSeleccionado.Anio.ToString();
            chkDisponible.Checked = libroSeleccionado.Disponible;
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // ===============================
        // VALIDACIÓN USUARIOS
        // ===============================

        private bool ValidarCamposUsuario(out int id)
        {
            id = 0;

            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoUsuario.Text))
            {
                MessageBox.Show("Completa todos los campos del usuario.");
                return false;
            }

            if (!int.TryParse(txtIdUsuario.Text, out id))
            {
                MessageBox.Show("El ID del usuario debe ser numérico.");
                return false;
            }

            return true;
        }

        private void LimpiarCamposUsuario()
        {
            txtIdUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtCorreoUsuario.Text = "";
            chkActivoUsuario.Checked = true;
        }

        // ===============================
        // CRUD USUARIOS
        // ===============================

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposUsuario(out int id))
                return;

            if (biblioteca.ExisteUsuario(id))
            {
                MessageBox.Show("Ya existe un usuario con ese ID.");
                return;
            }

            Usuario usuario = new Usuario()
            {
                Id = id,
                Nombre = txtNombreUsuario.Text,
                Correo = txtCorreoUsuario.Text,
                Activo = chkActivoUsuario.Checked
            };

            biblioteca.AgregarUsuario(usuario);
            RefrescarUsuarios();
            LimpiarCamposUsuario();

            MessageBox.Show("Usuario agregado correctamente.");
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposUsuario(out int id))
                return;

            Usuario usuario = new Usuario()
            {
                Id = id,
                Nombre = txtNombreUsuario.Text,
                Correo = txtCorreoUsuario.Text,
                Activo = chkActivoUsuario.Checked
            };

            bool actualizado = biblioteca.ActualizarUsuario(usuario);

            if (!actualizado)
            {
                MessageBox.Show("No existe un usuario con ese ID.");
                return;
            }

            RefrescarUsuarios();
            LimpiarCamposUsuario();

            MessageBox.Show("Usuario editado correctamente.");
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdUsuario.Text, out int id))
            {
                MessageBox.Show("Ingresa un ID válido.");
                return;
            }

            bool eliminado = biblioteca.EliminarUsuario(id);

            if (!eliminado)
            {
                MessageBox.Show("No existe un usuario con ese ID.");
                return;
            }

            RefrescarUsuarios();
            LimpiarCamposUsuario();

            MessageBox.Show("Usuario eliminado correctamente.");
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUsuarios.Rows.Count)
                return;

            if (dgvUsuarios.Rows[e.RowIndex].DataBoundItem is not Usuario usuarioSeleccionado)
                return;

            txtIdUsuario.Text = usuarioSeleccionado.Id.ToString();
            txtNombreUsuario.Text = usuarioSeleccionado.Nombre;
            txtCorreoUsuario.Text = usuarioSeleccionado.Correo;
            chkActivoUsuario.Checked = usuarioSeleccionado.Activo;
        }
    }
}