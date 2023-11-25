using Microsoft.Win32;
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
    public partial class Autentificar : Form
    {
        Boolean formulario = false;
        public Autentificar()
        {
            InitializeComponent();
        }

        private void Autentificar_Load(object sender, EventArgs e)
        {
            openChildForm(new Login());
        }

        public void CambioForms()
        {
            
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {


            activeForm = childForm;
            childForm.TopLevel = false;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.BringToFront();
            childForm.Show();
        }



   


        public void Cerrar()
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
