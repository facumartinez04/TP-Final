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

namespace TP_Final.Auth
{
    public partial class Registro : Form
    {
        private AuthBusiness authBusiness = new AuthBusiness();
        private Autentificar auth = new Autentificar();
        public Registro()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {
           
            txtContra.PasswordChar  = '*';
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {

                authBusiness.registro(new AuthEntity { 
                    nombreyApellido = txtNyA.Text,
                    telefono = txtTel.Text,
                    Usuario = txtUsuario.Text,
                    password = txtContra.Text
                });

                MessageBox.Show("Registrado correctamente");

                this.Hide();
                Login reg = new Login();
                reg.Show();
                reg.BringToFront();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
