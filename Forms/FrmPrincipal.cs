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

        public FrmPrincipal()
        {
            InitializeComponent();

            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.MultiSelect = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.ReadOnly = true;
            dgvLibros.AutoGenerateColumns = true;

            bsLibros.DataSource = biblioteca.ObtenerLibros();
            dgvLibros.DataSource = bsLibros;
        }

        private void RefrescarLibros()
        {
            bsLibros.DataSource = null;
            bsLibros.DataSource = biblioteca.ObtenerLibros();
            dgvLibros.DataSource = bsLibros;
            dgvLibros.ClearSelection();
        }

        private bool ValidarCampos(out int id, out int anio)
        {
            id = 0;
            anio = 0;

            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtAño.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return false;
            }

            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                return false;
            }

            if (!int.TryParse(txtAño.Text, out anio))
            {
                MessageBox.Show("El año debe ser un número válido.");
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int id, out int anio))
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
            LimpiarCampos();

            MessageBox.Show("Libro agregado correctamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int id, out int anio))
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
            LimpiarCampos();

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
            LimpiarCampos();

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

        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtAño.Text = "";
            chkDisponible.Checked = false;
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}