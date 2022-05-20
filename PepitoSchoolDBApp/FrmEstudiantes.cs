using PepitoSchoolDBApp.AppCore.Interfaces;
using PepitoSchoolDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolDBApp
{
    public partial class FrmEstudiantes : Form
    {
        private IEstudianteService estudianteService;
        private Estudiante estudiante;
        public FrmEstudiantes(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante estudiante=new Estudiante();
                CrearEstudiante(estudiante);
                estudianteService.Create(estudiante);
                LimpiarCampos();
                LoadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CrearEstudiante(estudiante);
                int changes = estudianteService.Update(estudiante);
                if (changes <= 0)
                {
                    throw new Exception("No se pudo actualizar el objeto estudiante");
                }
                LimpiarCampos();
                LoadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = estudianteService.Delete(estudiante);
                if (!result)
                {
                    throw new Exception("No se puedo eliminar el objeto estudiante");
                }
                LimpiarCampos();
                LoadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                int id = (int)dgvEstudiantes.Rows[e.RowIndex].Cells[0].Value;
                estudiante = estudianteService.FindById(id);
                if (estudiante != null)
                {
                    LlenarCampos();
                    double prom = estudianteService.CalcularPromedio(estudiante);
                    txtProm.Text = prom.ToString();
                } 
            }
        }
        private void LlenarCampos()
        {
            txtApellidos.Text = estudiante.Apellidos;
            txtNombres.Text = estudiante.Nombres;
            txtDireccion.Text = estudiante.Direccion;
            txtCarnet.Text = estudiante.Carnet;
            txtCorreo.Text = estudiante.Correo;
            txtTelefono.Text = estudiante.Phone;
            nudMath.Value = estudiante.Matematica;
            nudEstad.Value = estudiante.Estadistica;
            nudContab.Value = estudiante.Contabilidad;
            nudProg.Value = estudiante.Programacion;
        }
        private void LimpiarCampos()
        {
            txtApellidos.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtCarnet.Text = String.Empty;
            txtCorreo.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            nudMath.Value = nudMath.Minimum;
            nudEstad.Value = nudEstad.Minimum;
            nudContab.Value = nudContab.Minimum;
            nudProg.Value = nudProg.Minimum;
            txtProm.Text = String.Empty;
        }
        private void LoadDgv()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = estudianteService.GetAll();
        }
        public void CrearEstudiante(Estudiante estudiante)
        {
            estudiante.Apellidos = txtApellidos.Text;
            estudiante.Nombres = txtNombres.Text;
            estudiante.Direccion = txtDireccion.Text;
            estudiante.Carnet = txtCarnet.Text;
            estudiante.Correo = txtCorreo.Text;
            estudiante.Phone = txtTelefono.Text;
            estudiante.Matematica = (int)nudMath.Value;
            estudiante.Contabilidad = (int)nudContab.Value;
            estudiante.Estadistica = (int)nudEstad.Value;
            estudiante.Programacion = (int)nudProg.Value;
        }
    }
}
