﻿using BLL;
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
using TP_Final.Auth;

namespace TP_Final
{
    public partial class ReservaAdmin : Form
    {

        private TurnoBusiness turnoBusiness = new TurnoBusiness();

        private PeluqueroBusiness PeluqueroBusiness = new PeluqueroBusiness();


        private ClienteBusiness clienteBusiness = new ClienteBusiness();




        public ReservaAdmin()
        {
            InitializeComponent();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            ListarData();
            cmbClienteExistente.Enabled = false;

            ListarCombos();

        }



        private void ListarCombos()
        {
            cmbPeluquero.DataSource = PeluqueroBusiness.listaPeluqueros();
            cmbPeluquero.DisplayMember = "nombreApellidoPeluquero";
            cmbPeluquero.ValueMember = "idPeluquero";




            cmbClienteExistente.DataSource = clienteBusiness.listarClientes();
            cmbClienteExistente.DisplayMember = "nombreApellido";
            cmbClienteExistente.ValueMember = "idCliente";


        }


        private void ListarData()
        {
            dataGridView1.DataSource = null;
            var lista = from l in turnoBusiness.listaTurnos()
                        select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

            var resultados = lista.ToList();

            dataGridView1.DataSource = resultados;
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<TurnoEntity> turnosSeleccionados = new List<TurnoEntity>();


            if (cmbFiltro.Text == "Fecha")
            {
                if (txtFiltro.Text == "")
                {
                    ListarData();
                }
                else
                {
                    foreach (TurnoEntity turno in turnoBusiness.listaTurnos())
                    {
                        if (turno.FechaRegistro.ToString().Contains(txtFiltro.Text))
                        {
                            turnosSeleccionados.Add(turno);

                        }

                        var lista = from l in turnosSeleccionados
                                    select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

                        var resultados = lista.ToList();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = resultados;
                    }
                }
            }

            if (cmbFiltro.Text == "Nombre y Apellido")
            {
                if (txtFiltro.Text == "")
                {
                    ListarData();
                }
                else
                {
                    foreach (TurnoEntity turno in turnoBusiness.listaTurnos())
                    {
                        if (turno.cliente.nombreApellido.ToString().Contains(txtFiltro.Text))
                        {
                            turnosSeleccionados.Add(turno);
                        }

                        var lista = from l in turnosSeleccionados
                                    select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

                        var resultados = lista.ToList();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = resultados;
                    }
                }
            }

            if (cmbFiltro.Text == "ID Turno")
            {
                if (txtFiltro.Text == "")
                {
                    ListarData();
                }
                else
                {
                    foreach (TurnoEntity turno in turnoBusiness.listaTurnos())
                    {
                        if (turno.idTurno.ToString().Contains(txtFiltro.Text))
                        {
                            turnosSeleccionados.Add(turno);
                        }

                        var lista = from l in turnosSeleccionados
                                    select new { l.idTurno, l.peluquero.nombreApellidoPeluquero, l.cliente.nombreApellido, l.DiaTurno, l.Hora, l.Estado, l.Servicio };

                        var resultados = lista.ToList();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = resultados;
                    }
                }
            }

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
                turno.peluquero = new PeluqueroEntity
                {
                    idPeluquero = Convert.ToInt32(cmbPeluquero.SelectedValue),
                };
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

        private void btnEditarTurno_Click(object sender, EventArgs e)
        {
            try
            {

                TurnoEntity turno = new TurnoEntity();
                turno.idTurno = Convert.ToInt32(txtIDEditar.Text);
                turno.DiaTurno = dtpFechaEditar.Value;
                turno.Hora = TimeSpan.Parse(cmbHoraEdit.Text);
                turno.Servicio = comboBox1.Text;
                turnoBusiness.editarTurno(turno);
                MessageBox.Show("Se edito correctamente");
                ListarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroPeluquero registro = new RegistroPeluquero();

            registro.Show();
            registro.BringToFront();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ReservaAdmin_Activated(object sender, EventArgs e)
        {
            ListarCombos();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
