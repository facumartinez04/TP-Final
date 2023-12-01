using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Final
{
    public partial class ReservaPeluquero : Form
    {

        private TurnoBusiness turnoBusiness = new TurnoBusiness();

        private PeluqueroBusiness PeluqueroBusiness = new PeluqueroBusiness();


        private ClienteBusiness clienteBusiness = new ClienteBusiness();

        private string peluquero = "";
        private int idPeluquero = 0;



        public ReservaPeluquero(string peluquero, int idPeluquero)
        {
            InitializeComponent();
            this.peluquero = peluquero;
            this.idPeluquero = idPeluquero;
        }

        private void btnReservarAhora_Click(object sender, EventArgs e)
        {
            try
            {
                TurnoEntity turno = new TurnoEntity();
                if (checkExistente.Checked)
                {
                    turno.cliente = new ClienteEntity
                    {
                        idCliente = Convert.ToInt32(cmbClienteExistente.SelectedValue),
                    };
                }
                else
                {
                    turno.cliente = new ClienteEntity
                    {
                        nombreApellido = txtNombreyApellido.Text,
                        telefono = txtTelefono.Text,
                    };
                }
                
                turno.DiaTurno = Convert.ToDateTime(dtpFechaTurno.Value.Date);
                turno.Hora = TimeSpan.Parse(cmbHorario.Text);
                turno.Servicio = cmbServicio.Text;
                turnoBusiness.agregarTurnoAdmin(turno);
                MessageBox.Show("Se agrego correctamente");
                ListarData();
                txtNombreyApellido.Clear();
                txtTelefono.Clear();
                cmbClienteExistente.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNombreyApellido.Clear();
                txtTelefono.Clear();
                cmbClienteExistente.Text = "";
            }
        }

        private void ListarData()
        {
            dataGridView1.DataSource = null;
            var lista = from l in turnoBusiness.listaTurnos()
                        select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

            var resultados = lista.ToList();

            dataGridView1.DataSource = resultados;
        }


        private void ListarCombos()
        {



            cmbClienteExistente.DataSource = clienteBusiness.listarClientes();
            cmbClienteExistente.DisplayMember = "nombreApellido";
            cmbClienteExistente.ValueMember = "idCliente";


        }

        private void ReservaPeluquero_Load(object sender, EventArgs e)
        {
            ListarCombos();
            ListarData();
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                turnoBusiness.eliminarTurno(Convert.ToInt32(txtIDEliminar.Text));

                MessageBox.Show("Se elimino correctamente el Turno");
                ListarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtIDEliminar.Clear();
            }
        }

        private void cmbClienteExistente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkExistente.Checked)
            {
                ClienteEntity clienteSeleccionado = clienteBusiness.listarClientes().ToList().Find(x => x.idCliente == Convert.ToInt32(cmbClienteExistente.SelectedValue));

                txtTelefono.Text = clienteSeleccionado.telefono;
            }
        }

        private void checkExistente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkExistente.Checked)
            {
                cmbClienteExistente.Enabled = true;
                txtTelefono.ReadOnly = true;
                txtNombreyApellido.Enabled = false;
            }
            else
            {
                cmbClienteExistente.Enabled = false;
                txtTelefono.ReadOnly = false;
                txtNombreyApellido.Enabled = true;
                txtTelefono.Clear();

            }
        }
    }
}
