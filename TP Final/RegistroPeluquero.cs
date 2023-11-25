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
    public partial class RegistroPeluquero : Form
    {
        private PeluqueroBusiness peluqueroBusiness = new PeluqueroBusiness();
        public RegistroPeluquero()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                PeluqueroEntity peluquero = new PeluqueroEntity {
                    nombreApellidoPeluquero = txtNombreyApellido.Text,
                    telefono = txtTel.Text,
                    fechaIngreso = dtpIngreso.Value,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                };

                peluqueroBusiness.AgregarPeluquero(peluquero);
                MessageBox.Show("Se añadio un nuevo peluquero");
                listaPeluqueros();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listaPeluqueros()
        {

            dataGridView1.DataSource = null;
           dataGridView1.DataSource = peluqueroBusiness.listaPeluqueros();
        }

        private void RegistroPeluquero_Load(object sender, EventArgs e)
        {
            listaPeluqueros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {

                peluqueroBusiness.EliminarPeluquero(Convert.ToInt32(txtEliminar.Text));
                MessageBox.Show("Se elimino el peluquero");
                listaPeluqueros();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
