using GestorBiblioteca.Models;
using GestorBiblioteca.Services;
using System;
using System.Windows.Forms;

namespace GestorBiblioteca.Forms
{
    public partial class FrmPrincipal : Form
    {
        private BibliotecaService biblioteca = new BibliotecaService();

        public FrmPrincipal()
        {
            InitializeComponent();

            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.MultiSelect = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.ReadOnly = true;

            CargarLibros();
        }

        private void CargarLibros()
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = biblioteca.ObtenerLibros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Libro libro = new Libro()
            {
                Id = int.Parse(txtID.Text),
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Anio = int.Parse(txtAño.Text),
                Disponible = chkDisponible.Checked
            };

            biblioteca.AgregarLibro(libro);

            CargarLibros();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Libro libro = new Libro()
            {
                Id = int.Parse(txtID.Text),
                Titulo = txtTitulo.Text,
                Autor = txtAutor.Text,
                Anio = int.Parse(txtAño.Text),
                Disponible = chkDisponible.Checked
            };

            biblioteca.ActualizarLibro(libro);

            CargarLibros();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            biblioteca.EliminarLibro(id);

            CargarLibros();
            LimpiarCampos();
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >= dgvLibros.Rows.Count)
                return;

            var fila = dgvLibros.Rows[e.RowIndex];

            if (fila.DataBoundItem == null)
                return;

            Libro libroSeleccionado = fila.DataBoundItem as Libro;

            if (libroSeleccionado == null)
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
    }
}