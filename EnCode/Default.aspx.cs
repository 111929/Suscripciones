using EnCode.Data;
using EnCode.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnCode
{
    public partial class _Default : Page
    {
        Conexion conexion = new Conexion();
        Suscriptor UnSuscriptor = new Suscriptor();
        Suscripcion s = new Suscripcion();
       // private bool hacer = true;
      
        private void Mensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensaje + "')", true);
        }
        private void Deshabilitar()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtContrasena.Enabled = false;
            txtDireccion.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;

        }
        private void Habilitar()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtContrasena.Enabled = true;
            txtDireccion.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlSuscribir.Visible = false;
            PnlSubscripto.Visible = false;
            btnAceptar.Enabled = false;
            btnNuevo.Enabled = true;
            btnVerificar.Enabled = false;
            btnModificar.Enabled = false;
            PnlMensaje.Visible = false;
            Deshabilitar();
            

        }
        private void ModificarSuscriptor()
        {
            var EditandoSuscriptor = new Suscriptor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                NroDocumento = Convert.ToInt32(txtNumeroDoc.Text),
                TipoDocumento = cboTipoDocumento.SelectedValue,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContrasena.Text

            };
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(EditandoSuscriptor.Contraseña);
            EditandoSuscriptor.Contraseña = passwordHash;

            UnSuscriptor.EditarSuscriptor(EditandoSuscriptor);
           
        }

        private void InsertarNuevo()
        {
            var nuevoSuscriptor = new Suscriptor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                NroDocumento = Convert.ToInt32(txtNumeroDoc.Text),
                TipoDocumento = cboTipoDocumento.SelectedValue,
                Direccion = txtDireccion.Text,
                Telefono =  txtNombreUsuario.Text,
                Email = txtEmail.Text,
                NombreUsuario = txtNombreUsuario.Text,
                
                Contraseña = txtContrasena.Text

            };
           
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(nuevoSuscriptor.Contraseña);
            nuevoSuscriptor.Contraseña = passwordHash;

            
                conexion.BuscarSuscriptor(nuevoSuscriptor.TipoDocumento, nuevoSuscriptor.NroDocumento);
            if (!conexion.Tabla.Read() && nuevoSuscriptor.NombreUsuario!=nuevoSuscriptor.NombreUsuario)
            {
                conexion.Tabla.Close();
                conexion.CerrarConexion();

                UnSuscriptor.InsertarSuscripcion(nuevoSuscriptor);
                Mensaje("El Usuario : " + nuevoSuscriptor.NombreUsuario + " con contraseña : " + nuevoSuscriptor.Contraseña + " se ha registrado correctamente");
               
            }
           
            else
            {
                Mensaje ( "esta persona ya esta subscripta o usuario existente");
            }
           
        }
      
        private void InsertarSuscripcion()
        {
            int DNI = Convert.ToInt32(txtNumeroDoc.Text);
            string TipoDoc = cboTipoDocumento.SelectedValue;
            int ID;
              conexion.BuscarSuscriptor(TipoDoc,DNI);
            if (conexion.Tabla.Read())
            {
                
                 ID =(int)conexion.Tabla["IdSuscriptor"];
                var nuevaSuscripcion = new Suscripcion()
                { 
                    IdSuscriptor=ID,
                   FechaAlta = DateTime.Now,
                    FechaFin= null,
                    MotivoFin = null
                };
                s.AgregarSuscripcion(nuevaSuscripcion);
                Mensaje("La Suscripcion se realizara con la fecha: " + nuevaSuscripcion.FechaAlta);
            }
            else
            {
                Mensaje("esta persona ya esta subscripta");
            }

        }
        private void CargarTextBox(string TipoDoc, int NroDoc)
        {
            conexion.BuscarSuscriptor(TipoDoc, NroDoc);
            if (conexion.Tabla.Read())
            {
                txtNombre.Text = conexion.Tabla["Nombre"].ToString();
                txtApellido.Text = conexion.Tabla["Apellido"].ToString();
                txtDireccion.Text = conexion.Tabla["Direccion"].ToString();
                txtEmail.Text = conexion.Tabla["Email"].ToString();
                txtNombreUsuario.Text = conexion.Tabla["NombreUsuario"].ToString();
                txtTelefono.Text = conexion.Tabla["Telefono"].ToString();
                txtContrasena.Text = conexion.Tabla["Contraseña"].ToString();
                btnModificar.Enabled = true;
            }
            else
            {
                Mensaje("este suscriptor no esta cargado ");
                btnBuscar.Enabled = true;
                PnlMensaje.Visible = true;
                btnModificar.Enabled = false;
               
            }
            conexion.CerrarConexion();

        }
        

        private bool SuscriptorConSuscripcion(string TipoDoc, int NroDocu)
        {
            DataTable table = new DataTable();
            bool tiene = false;

            table = conexion.VerificarSuscriptor(TipoDoc, NroDocu);
            if (table.Rows.Count != 0)
            {
                tiene = true;

            }
            conexion.CerrarConexion();
            return tiene;

        }
        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumeroDoc.Text = "";
            cboTipoDocumento.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasena.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
             InsertarNuevo();
            

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
        Habilitar();
        
        btnAceptar.Enabled = true;
        btnModificar.Enabled = false;
        btnNuevo.Enabled = false;
        
        
        }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        Mensaje("se modifico correctamente");
        Habilitar();
        txtNumeroDoc.Enabled = false;
        cboTipoDocumento.Enabled = false;
        btnAceptar.Enabled = false;
        btnModificar.Enabled = false;
        btnNuevo.Enabled = true;
        
         ModificarSuscriptor();
    }

    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
          Habilitar();
        CargarTextBox(cboTipoDocumento.SelectedValue, Convert.ToInt32(txtNumeroDoc.Text));
        btnBuscar.Enabled = false;
        btnVerificar.Enabled = true;
        btnModificar.Enabled = true;

    }

    protected void btnVerificar_Click(object sender, EventArgs e)
    {


        if (SuscriptorConSuscripcion(cboTipoDocumento.SelectedValue, Convert.ToInt32(txtNumeroDoc.Text)))
        {

                 Mensaje("esta persona ya tiene una suscripcion vigente");
                PnlSubscripto.Visible = true;

            
                btnBuscar.Enabled = true;
                btnModificar.Enabled = true;
            }
        else
        {
                Mensaje("esta persona no tiene suscripcion desea agregarle una");
                pnlSuscribir.Visible = true;
                btnModificar.Enabled = true;
            }
        btnCancelar.Enabled = true;
        btnAceptar.Enabled = true;
        
        }

    protected void BtnSi_Click(object sender, EventArgs e)
    {
        btnNuevo.Enabled = true;
        Deshabilitar();

    }

    protected void BtnNo_Click(object sender, EventArgs e)
    {
        Limpiar();
        btnBuscar.Enabled = true;
          
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
            cboTipoDocumento.Enabled = true;
            txtNumeroDoc.Enabled = true;
        btnBuscar.Enabled = true;
        Limpiar();
     }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Habilitar();
            PnlSubscripto.Visible = false;
            btnModificar.Enabled = true;
        }

        protected void btnSuscribir_Click(object sender, EventArgs e)
        {
            InsertarSuscripcion();
            pnlSuscribir.Visible = false;
            Mensaje("se ha suscripto correctamente");
            Limpiar();
            btnBuscar.Enabled = true;
        }

        protected void btnNoSus_Click(object sender, EventArgs e)
        {
            pnlSuscribir.Visible = false;
            
        }


    }
 
}