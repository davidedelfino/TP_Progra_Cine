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

namespace Cine.Presentacion
{
    public partial class FrmAltaFuncion : Form
    {
        DBHelper oDatos;
        List<Funcion> funciones;
        
        public FrmAltaFuncion()
        {
            InitializeComponent();
            oDatos = new DBHelper();
            funciones = new List<Funcion>();
        }

        private void FrmAltaFuncion_Load(object sender, EventArgs e)
        {
            CargarCboPeliculas();
        }

        private void CargarCboPeliculas()
        {
            cboPeliculas.DataSource = oDatos.ConsultarDB("SP_CONSULTAR_PELICULAS");
            cboPeliculas.DisplayMember = "titulo";
            cboPeliculas.ValueMember = "id_pelicula";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarFuncion())
            {
                DataRowView item = (DataRowView)cboPeliculas.SelectedItem;

                int idPelicula = Convert.ToInt32(item.Row.ItemArray[0]);
                string titulo = item.Row.ItemArray[1].ToString();
                double precio = Convert.ToDouble(txtPrecio.Text);
                DateTime fecha = dtpFecha.Value;
                int sala = Convert.ToInt32(cboSalas.Text);

                dgvFunciones.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], fecha, sala, precio });

                Funcion func = new Funcion(idPelicula,fecha,precio,sala);

                funciones.Add(func);
                LimpiarCampos();


            }

        }

        private bool ValidarFuncion()
        {
            bool ok = true;
            if(cboPeliculas.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione película");
                cboPeliculas.Focus();
                ok = false;
            }
            if(cboSalas.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione sala");
                cboSalas.Focus();
                ok = false;
            }
            if(txtPrecio.Text=="")
            {
                MessageBox.Show("Ingrese Precio");
                txtPrecio.Focus();
                ok=false;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtPrecio.Text);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Ingrese un número válido");
                    txtPrecio.Clear();
                    ok = false;
                }
            }

            return ok;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(GrabarFunciones())
            {
                MessageBox.Show("Funciones Cargadas");
                dgvFunciones.Rows.Clear();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al cargar funciones");
            }
        }

        private bool GrabarFunciones()
        {
            bool ok = true;
            foreach(Funcion item in funciones)
            {
                if(oDatos.GrabarFuncion(item))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                }
                
            }

            return ok;
        }

        private void LimpiarCampos()
        {
            txtPrecio.Clear();
            cboSalas.Text = "";
            cboPeliculas.Text = "";
        }

        
    }
}
