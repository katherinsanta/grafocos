using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Ajax.Modules.Prepagos
{
    public partial class Anulacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            traducir();
            try
            {
                if (this.VerificarPermisos())
                {
                    //				if (Request.UrlReferrer != null)
                    //					this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                    //				else
                    lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23876, Global.Idioma);
                    this.lblBack.NavigateUrl = "default.aspx";
                
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error iniciando el formulario: " + ex.Message;
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error iniciando el formulario de perfil de usuario");
                }
                catch (Exception exx)
                {
                    lblError.Text = "El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                }
                #endregion

            }
        }
        #region traducir
        private void traducir() 
        {
            lblValue.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23861, Servipunto.Estacion.Web.Global.Idioma);
            lblNUMBER.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23864, Servipunto.Estacion.Web.Global.Idioma);
            lblName.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23865, Servipunto.Estacion.Web.Global.Idioma);

            lblFechFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23872, Servipunto.Estacion.Web.Global.Idioma);
            lblFechCre.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23871, Servipunto.Estacion.Web.Global.Idioma);
            lblFechaUso.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23873, Servipunto.Estacion.Web.Global.Idioma);
            lblCustome.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23877, Servipunto.Estacion.Web.Global.Idioma);
            lblCausal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23875, Servipunto.Estacion.Web.Global.Idioma);
            lblAnul.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23874, Servipunto.Estacion.Web.Global.Idioma);
        }

        #endregion



        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Prepagos";
            const string opcion = "Cancelar";
            bool permiso;            
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Cancelar");
            
            if (!permiso)
            {
                lblError.Visible= true;
                lblError.Text= Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, 1);
                pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Libreria.Prepagos.Prepagos prepagos = new Servipunto.Estacion.Libreria.Prepagos.Prepagos(Convert.ToInt32(txtNumeroInicial.Text));
            if (prepagos.Count > 0)
            {
                Libreria.Prepagos.Prepago objPrepago = prepagos[0];
                
                Libreria.Cliente objCliente = Libreria.Clientes.Obtener(objPrepago.Cod_Cli);
                txtCod_Cli.Text = objPrepago.Cod_Cli;
                if ( objCliente != null)
                    txtNombre.Text = objCliente.Nombre;
                txtEstado.Text = objPrepago.EstadoPrepago.ToString();
                txtValor.Text = objPrepago.Denominacion.ToString();
                txtFechaCreacion.Text = objPrepago.FechaCreacion.ToString("dd/MM/yyyy");
                if (txtEstado.Text != "Creado") 
                    txtFechaAsignacion.Text = objPrepago.FechaAsignacion.ToString("dd/MM/yyyy");
                if (txtEstado.Text == "Utilizado" || objPrepago.FechaRealUtilizacion.Year > 1900) 
                    txtFechaUtilizacion.Text = objPrepago.FechaRealUtilizacion.ToString("dd/MM/yyyy");
                if (txtEstado.Text == "Anulado") 
                    txtFechaAnulacion.Text = objPrepago.FechaAnulacion.ToString("dd/MM/yyyy");
            }
            
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {

              Libreria.Prepagos.Prepagos prepagos = new Servipunto.Estacion.Libreria.Prepagos.Prepagos(Convert.ToInt32(txtNumeroInicial.Text));
              if (prepagos.Count > 0)
              {
                  Libreria.Prepagos.Prepago objPrepago = prepagos[0];
                  if (objPrepago.EstadoPrepago == Servipunto.Estacion.Libreria.EstadoPrepago.Utilizado)
                  {
                      Mensaje1.ShowMessage("Prepago Utilizado, No se puede anular");
                      return;
                  }

                  if (objPrepago.EstadoPrepago == Servipunto.Estacion.Libreria.EstadoPrepago.Anulado)
                  {
                      Mensaje1.ShowMessage("Prepago ya Anulado");
                      return;
                  }

                  if (objPrepago.EstadoPrepago != Servipunto.Estacion.Libreria.EstadoPrepago.Utilizado)
                  {
                      objPrepago.EstadoPrepago = Servipunto.Estacion.Libreria.EstadoPrepago.Anulado;
                      objPrepago.FechaAnulacion = DateTime.Now;
                      objPrepago.Modificar();
                      Mensaje1.ShowMessage("Anulación Prepago " + objPrepago.NumeroPrepago.ToString() + " Exitosa");
                      Borrar();
                  }
              }
        }

        private void Borrar()
        {
            txtEstado.Text = "";
            txtFechaAnulacion.Text = "";
            txtFechaAsignacion.Text = "";
            txtFechaCreacion.Text = "";
            txtFechaUtilizacion.Text = "";
            txtNombre.Text = "";
            txtNumeroInicial.Text = "";
            txtValor.Text = "";
            txtCod_Cli.Text = "";

        }
    }
}
