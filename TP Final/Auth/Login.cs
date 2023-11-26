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
    public partial class Login : Form
    {
        private Autentificar auth = new Autentificar();
        private AuthBusiness authBusiness = new AuthBusiness();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            txtPass.PasswordChar = '*';
        }

        private void label5_Click(object sender, EventArgs e)
        {
            auth.CambioForms();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Registro reg = new Registro();
            reg.Show();
            reg.BringToFront();


        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                
                AuthEntity entity = authBusiness.Login(new AuthEntity
                {
                    Usuario = txtUser.Text,
                    password = txtPass.Text
                });
             
                SessionManager.Login(entity);
                SessionManager sesion = SessionManager.Instance;
                MessageBox.Show("Logeado correctamente");
                txtUser.Clear();
                txtPass.Clear();
                if (entity.Usuario == "admin")
                {
                    ReservaAdmin reserva = new ReservaAdmin();
                    reserva.Show();
                    Autentificar aut = new Autentificar();
                    reserva.BringToFront();
              
                    this.Hide();
                }
                else
                {
                    ReservaCliente reserva = new ReservaCliente(entity.Usuario, entity.nombreyApellido,entity.telefono,entity.idCliente);
                    reserva.Show();
                    reserva.BringToFront();       
                    this.Hide();
                  
                }


            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                txtUser.Clear();
                txtPass.Clear();
            }
        }
    }
}
