using GestorBiblioteca.Models;
using GestorBiblioteca.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestorBiblioteca.Forms
{
    public partial class FrmPrincipal : Form
    {
        private BibliotecaService biblioteca = new BibliotecaService();
        private BindingSource bsLibros = new BindingSource();
        private BindingSource bsUsuarios = new BindingSource();
        private BindingSource bsPrestamos = new BindingSource();

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
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bsUsuarios.DataSource = biblioteca.ObtenerUsuarios();
            dgvUsuarios.DataSource = bsUsuarios;

            // TABLA PRESTAMOS
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.AutoGenerateColumns = true;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RefrescarPrestamos();
            CargarGraficas();
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

        private void RefrescarPrestamos()
        {
            var prestamos = biblioteca.ObtenerPrestamos();
            var usuarios = biblioteca.ObtenerUsuarios();
            var libros = biblioteca.ObtenerLibros();

            var datos = prestamos.Select(p => new
            {
                p.Id,
                Usuario = usuarios.FirstOrDefault(u => u.Id == p.IdUsuario)?.Nombre,
                Libro = libros.FirstOrDefault(l => l.Id == p.IdLibro)?.Titulo,
                p.FechaPrestamo,
                p.FechaDevolucion,
                p.Estado
            }).ToList();

            bsPrestamos.DataSource = null;
            bsPrestamos.DataSource = datos;
            dgvPrestamos.DataSource = bsPrestamos;
            dgvPrestamos.ClearSelection();
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
            CargarGraficas();
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
            CargarGraficas();
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
            CargarGraficas();
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
            CargarGraficas();
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
            CargarGraficas();
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
            CargarGraficas();
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

        // ===============================
        // PRÉSTAMOS
        // ===============================

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPrestamo.Text, out int idPrestamo))
            {
                MessageBox.Show("ID de préstamo inválido.");
                return;
            }

            if (!int.TryParse(txtIdUsuarioPrestamo.Text, out int idUsuario))
            {
                MessageBox.Show("ID de usuario inválido.");
                return;
            }

            if (!int.TryParse(txtIdLibroPrestamo.Text, out int idLibro))
            {
                MessageBox.Show("ID de libro inválido.");
                return;
            }

            if (biblioteca.ExistePrestamo(idPrestamo))
            {
                MessageBox.Show("Ya existe un préstamo con ese ID.");
                return;
            }

            Prestamo prestamo = new Prestamo()
            {
                Id = idPrestamo,
                IdUsuario = idUsuario,
                IdLibro = idLibro,
                FechaPrestamo = dtpFechaPrestamo.Value,
                Estado = "Prestado"
            };

            bool registrado = biblioteca.RegistrarPrestamo(prestamo);

            if (!registrado)
            {
                MessageBox.Show("No se pudo registrar el préstamo. Verifica usuario, libro o disponibilidad.");
                return;
            }

            RefrescarPrestamos();
            RefrescarLibros();
            RefrescarUsuarios();
            CargarGraficas();

            MessageBox.Show("Préstamo registrado correctamente.");
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdPrestamo.Text, out int idPrestamo))
            {
                MessageBox.Show("ID de préstamo inválido.");
                return;
            }

            bool devuelto = biblioteca.RegistrarDevolucion(idPrestamo);

            if (!devuelto)
            {
                MessageBox.Show("No se pudo registrar la devolución.");
                return;
            }

            RefrescarPrestamos();
            RefrescarLibros();
            RefrescarUsuarios();
            CargarGraficas();

            MessageBox.Show("Libro devuelto correctamente.");
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtIdPrestamo.Text = dgvPrestamos.Rows[e.RowIndex].Cells["Id"].Value?.ToString();
        }

        private void dgvPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // ===============================
        // GRAFICAS
        // ===============================

        private void CargarGraficas()
        {
            // =========================
            // LIBROS MÁS PRESTADOS
            // =========================
            chartLibrosPrestados.Series.Clear();
            chartLibrosPrestados.Titles.Clear();
            chartLibrosPrestados.ChartAreas.Clear();
            chartLibrosPrestados.Legends.Clear();

            ChartArea areaLibros = new ChartArea("AreaLibros");
            areaLibros.BackColor = Color.White;
            areaLibros.AxisX.MajorGrid.Enabled = false;
            areaLibros.AxisY.MajorGrid.Enabled = false;
            areaLibros.AxisX.Interval = 1;
            areaLibros.AxisY.Interval = 1;
            areaLibros.AxisX.LineColor = Color.Black;
            areaLibros.AxisY.LineColor = Color.Black;
            chartLibrosPrestados.ChartAreas.Add(areaLibros);

            Title tituloLibros = new Title("Libros más prestados");
            tituloLibros.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartLibrosPrestados.Titles.Add(tituloLibros);

            Series serieLibros = new Series("Libros");
            serieLibros.ChartType = SeriesChartType.Bar;
            serieLibros.IsValueShownAsLabel = true;
            serieLibros["PointWidth"] = "0.5";

            var librosMasPrestados = biblioteca.ObtenerLibrosMasPrestados();

            foreach (var libro in librosMasPrestados)
            {
                DataPoint punto = new DataPoint();
                punto.SetValueY(libro.VecesPrestado);
                punto.AxisLabel = libro.Titulo;
                punto.Label = libro.VecesPrestado.ToString();
                serieLibros.Points.Add(punto);
            }

            chartLibrosPrestados.Series.Add(serieLibros);

            Legend legendLibros = new Legend();
            legendLibros.Docking = Docking.Right;
            chartLibrosPrestados.Legends.Add(legendLibros);


            // =========================
            // USUARIOS MÁS ACTIVOS
            // =========================
            chartUsuariosActivos.Series.Clear();
            chartUsuariosActivos.Titles.Clear();
            chartUsuariosActivos.ChartAreas.Clear();
            chartUsuariosActivos.Legends.Clear();

            ChartArea areaUsuarios = new ChartArea("AreaUsuarios");
            areaUsuarios.BackColor = Color.White;
            areaUsuarios.AxisX.MajorGrid.Enabled = false;
            areaUsuarios.AxisY.MajorGrid.Enabled = false;
            areaUsuarios.AxisX.Interval = 1;
            areaUsuarios.AxisY.Interval = 1;
            areaUsuarios.AxisX.LineColor = Color.Black;
            areaUsuarios.AxisY.LineColor = Color.Black;
            chartUsuariosActivos.ChartAreas.Add(areaUsuarios);

            Title tituloUsuarios = new Title("Usuarios más activos");
            tituloUsuarios.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartUsuariosActivos.Titles.Add(tituloUsuarios);

            Series serieUsuarios = new Series("Usuarios");
            serieUsuarios.ChartType = SeriesChartType.Bar;
            serieUsuarios.IsValueShownAsLabel = true;
            serieUsuarios["PointWidth"] = "0.5";

            var usuariosMasActivos = biblioteca.ObtenerUsuariosMasActivos();

            foreach (var usuario in usuariosMasActivos)
            {
                DataPoint punto = new DataPoint();
                punto.SetValueY(usuario.CantidadPrestamos);
                punto.AxisLabel = usuario.Nombre;
                punto.Label = usuario.CantidadPrestamos.ToString();
                serieUsuarios.Points.Add(punto);
            }

            chartUsuariosActivos.Series.Add(serieUsuarios);

            Legend legendUsuarios = new Legend();
            legendUsuarios.Docking = Docking.Right;
            chartUsuariosActivos.Legends.Add(legendUsuarios);
        }


    }
}