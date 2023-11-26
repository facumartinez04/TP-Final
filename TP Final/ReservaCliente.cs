using BLL;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Final.Auth;

namespace TP_Final
{
    public partial class ReservaCliente : Form
    {

        private TurnoBusiness turnoBusiness = new TurnoBusiness();
        private PeluqueroBusiness peluqueroBusiness = new PeluqueroBusiness();
        private string miUsuario = "";
        private string miNombreyApellido = "";
        private string telefono = "";
        private int miCliente = 0;
        public ReservaCliente(string miUsuario, string miNombreyApellido,string telefono,int idCliente)
        {
            InitializeComponent();
            this.miUsuario = miUsuario;
            this.miNombreyApellido = miNombreyApellido;
            this.telefono = telefono;
            this.miCliente = idCliente;
        }

        private void ReservaCliente_Load(object sender, EventArgs e)
        {
            ListarCombos();
            ListarData();
        }

        private void ListarCombos()
        {
            cmbPeluquero.DataSource = peluqueroBusiness.listaPeluqueros();
            cmbPeluquero.DisplayMember = "nombreApellidoPeluquero";
            cmbPeluquero.ValueMember = "idPeluquero";
        }


        private void ListarData()
        {
            List<TurnoEntity> todos = turnoBusiness.listaTurnos();
            List<TurnoEntity> usuarios = new List<TurnoEntity>();

            foreach (TurnoEntity turno in todos)
            {
                if (turno.cliente.idCliente.Equals(miCliente))
                {
                    usuarios.Add(turno);
                }
            }


            var lista = from l in usuarios
                        select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

            var resultados = lista.ToList();


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultados;

        }

        private void btnReservarAhora_Click(object sender, EventArgs e)
        {
            try
            {
                TurnoEntity turno = new TurnoEntity();
                turno.cliente = new ClienteEntity
                {
                    nombreApellido = miNombreyApellido,
                    telefono = telefono,
                    usuario = miUsuario
                };
                turno.peluquero = new PeluqueroEntity
                {
                    idPeluquero = Convert.ToInt32(cmbPeluquero.SelectedValue),
                };
                turno.DiaTurno = Convert.ToDateTime(dtpFechaTurno.Value.Date);
                turno.Hora = TimeSpan.Parse(cmbHorario.Text);
                turno.Servicio = cmbServicio.Text;
                turnoBusiness.agregarTurno(turno);
                MessageBox.Show("Se agrego correctamente");
                ListarData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                
                turnoBusiness.eliminarTurno(Convert.ToInt32(txtID.Text));

                MessageBox.Show("Se elimino correctamente el Turno");
                ListarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtID.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager.Logout();
                this.Close();
                Login login = new Login();
                login.Show();
                login.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
