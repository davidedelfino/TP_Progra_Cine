using Cine.Datos;
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
using Cine.Presentacion;

namespace Cine
{
    public partial class FrmPrincipal : Form
    {
        DBHelper oDatos;
        Ticket oTicket;
        
        public FrmPrincipal()
        {
            InitializeComponent();
            oDatos = new DBHelper();
            oTicket = new Ticket();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        

        private void CargarCboFunciones(DateTime fecha)
        {
            DataTable tabla= oDatos.ConsultarFunciones("SP_CONSULTAR_FUNCIONES_FILTRO", fecha);
            DataTable tablaVacia=new DataTable();
            if(tabla!=null)
            {
                cboFuncion.DataSource = tabla;
                cboFuncion.DisplayMember = "titulo";
                cboFuncion.ValueMember = "id_funcion";
            }
            else
            {
                if(tabla.Rows.Count==0)
                {
                    cboFuncion.Items.Clear();
                    cboFuncion.DataSource = tablaVacia;
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarCboFunciones(dtpFecha.Value);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaCliente frm = new FrmAltaCliente();
            frm.Show();
        }

        private void funciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaFuncion frm = new FrmAltaFuncion();
            frm.Show();
        }
    }
}
