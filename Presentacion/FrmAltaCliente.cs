using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cine.Dominio;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using Cine.Datos;

namespace Cine.Presentacion
{
    public partial class FrmAltaCliente : Form
    {
        Cliente oCliente;
        DBHelper oDatos;
        public FrmAltaCliente()
        {
            InitializeComponent();
            oCliente= new Cliente();
            oDatos=new DBHelper();
        }

        private void FrmAltaUsuario_Load(object sender, EventArgs e)
        {

        }

        private bool Validar()
        {
            bool ok = true;

            if(txtNombre.Text=="")
            {
                MessageBox.Show("Ingrese Nombre");
                txtNombre.Focus();
                ok = false;
                
            }
            
            if(txtApellido.Text=="")
            {
                MessageBox.Show("Ingrese Apellido");
                txtApellido.Focus();
                ok = false;


            }
            if(txtDni.Text=="")
            {
                MessageBox.Show("Ingrese DNI");
                txtDni.Focus();
                ok = false;
            }
            else
            {
                try
                {
                    Convert.ToInt64(txtDni.Text);
                }
                catch(FormatException)
                {
                    MessageBox.Show("DNI sólo admite números");
                    txtDni.Clear();
                    txtDni.Focus();
                    ok = false;
                }
            }
            if(txtCalle.Text=="")
            {
                MessageBox.Show("Ingrese Calle");
                txtCalle.Focus();
                ok = false;
            }
           
            if(txtAltura.Text=="")
            {
                MessageBox.Show("Ingrese altura");
                txtAltura.Focus();
                ok = false;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtAltura.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Altura solo admite números");
                    txtAltura.Clear();
                    txtAltura.Focus();
                    ok = false;
                }
               

            }
            if(txtTelefono.Text=="")
            {
                MessageBox.Show("Ingrese Teléfono");
                txtTelefono.Focus();
                ok = false;
            }
            else
            {
                try
                {
                    Convert.ToInt64(txtTelefono.Text);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Teléfono solo admite números");
                    txtTelefono.Clear();
                    txtTelefono.Focus();
                    ok = false;
                }
            }
            string email = txtEmail.Text;
            if(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido");
                txtEmail.Clear();
                txtEmail.Focus();
                ok = false;
            }

            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtCalle.Clear();
            txtAltura.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                oCliente.Nombre = txtNombre.Text.ToString();
                oCliente.Apellido = txtApellido.Text.ToString();
                oCliente.Dni = Convert.ToInt64(txtDni.Text);
                oCliente.Calle=txtCalle.Text.ToString();
                oCliente.Altura = Convert.ToInt32(txtAltura.Text);
                oCliente.Telefono = Convert.ToInt64(txtTelefono.Text);
                oCliente.Email = txtEmail.Text.ToString();

                if(oDatos.GrabarCliente(oCliente))
                {
                    MessageBox.Show("Cliente Grabado");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al grabar cliente");
                    return;
                }

                


            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
