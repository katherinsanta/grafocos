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
using Servipunto.Estacion.Libreria;

namespace Servipunto.Estacion.Web.Ajax.Modules.Procesos
{
    public partial class ActualizarVentaCliente : System.Web.UI.Page
    {
        #region Declaracion Variables
        protected Libreria.Auditoria objAuditoria = null;
        #endregion
        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            /*  Traducir();
              ViewState["Control"] = "0";
              #region verificar session
              if (Session["Usuario"] == null)
              {
                  if (Session["Usuario"] == null)
                  {
                      Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                  }

              }
              #endregion*/
        }
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Visible = false;
            if (!this.Page.IsPostBack)
            {
                if (this.VerificarPermisos())
                {
                    //if (ViewState["Control"].ToString() != "1")
                    //{
                        this.Visualizar();
                    //}
                }
            }
            else
            {
                this.Eliminar();
            }

        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            //const string modulo = "Procesos";
            //const string opcion = "ActualizarVentaCliente";
            //bool Modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar Tiquete De Venta");

            ////Revisión de permiso de consulta
            //if (!Modificar)
            //{
            //    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
            //    return false;
            //}

            ////Configuración de Acciones
            //string htmlAcciones = "";
            //if (nuevo)
            //    this.AgregarAccion(ref htmlAcciones, "ActualizarVentaCliente.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1661, Global.Idioma));
            //if (eliminar)
            //    this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1684, Global.Idioma));

            //if (Request.QueryString["Consecutivo"] != null || Request.QueryString["IdCliente"] != "")
            //    this.AgregarAccion(ref htmlAcciones, "default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));

            //this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

            ////Configuración del permiso de modificación
            //if (modificar)
            //    this.HiddenUpdate.Value = "Allow";
            //else
            //    this.HiddenUpdate.Value = "Deny";

            return true;
        }

        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
        }
        #endregion
        #region Visualizar
        private void Visualizar()
		{
            try
            {
                //if (Request.QueryString["Consecutivo"])
                //{
                //    Session["IdCliente"] = DecryptText(Convert.ToString(Request.QueryString["IdCliente"].Replace(" ", "+")));
                //}

                //lblCliente.Text = "Automotores registrados para el Cliente: " + Session["IdCliente"].ToString() + " - " + Session["NombreCliente"].ToString();
            //    Libreria.Comercial.Automotores objAutomotores = null;
            //    if (Session["BuscarPlaca"] == null || Session["BuscarPlaca"].ToString() == "")
            //        objAutomotores = new Libreria.Comercial.Automotores(0, Session["IdCliente"].ToString());

            //    else
            //        objAutomotores = new Libreria.Comercial.Automotores(1, Session["BuscarPlaca"].ToString());

            //    Results.DataSource = objAutomotores;
            //    Results.DataBind();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
            }
		}
		#endregion

		#region Eliminar
		private void Eliminar()
		{
			if (Request.Form["chkID"] != null)
			{
				int i;
				string [] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,293, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this.lblError.Visible = true;
				this.lblError.Text = "";
				for (i = 0; i <= aSelectedItems.Length-1; i++) 
				{
					try
					{
						Libreria.Comercial.Automotores.Eliminar(1,aSelectedItems[i]);
					}
					catch (Exception ex)
					{
						this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
					}
				}
				this.Visualizar();
			}
		}
		#endregion

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            PnlEditar.Enabled = true;
            PnlEditar.Visible = true;

            CargarFormasPago();
            txtCodCliEdit.Text = txtCodCli.Text;
            txtPlacaEdit.Text = txtPlaca.Text;
            ddlFormaDePagoEdit.SelectedValue = ddlFormaDePagoEdit.SelectedValue;
            
        }

        protected void BtnBuscarTiquete_Click(object sender, EventArgs e)
        {
            BuscarConsecutivos();
        }

        #region Cargar Formas de Pago
        private void CargarFormasPago()
        {
            Libreria.Configuracion.FormasPago objFormasPago = new Libreria.Configuracion.FormasPago();
            ddlFormaDePagoEdit.DataSource = objFormasPago;
            ddlFormaDePagoEdit.DataTextField = "Descripcion";
            ddlFormaDePagoEdit.DataValueField = "IdFormaPago";
            ddlFormaDePagoEdit.DataBind();
            //ddlFormaDePagoEdit.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
        }
        #endregion

        private void BuscarConsecutivos()
        {
            try
            {
                lblError.Visible = false;
                if (txtTiquete.Text != null)
                {

                    pnlDatos.Visible = true;
                    pnlDatos.Enabled = true;
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 377, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.objAuditoria = Libreria.Auditorias.ObtenerItem(int.Parse(txtTiquete.Text));
                    if (objAuditoria != null)
                    {
                        pnlDatos.Visible = true;
                        txtCodCli.Text = objAuditoria.Cod_Cli;
                        txtPlaca.Text = objAuditoria.Placa;
                        txtFormaPago.Text = objAuditoria.FormaDepago.ToString();
                        txtTotalVenta.Text = objAuditoria.Total.ToString();
                    }
                    else
                    {
                        lblError.Text = "Tiquete: " + txtTiquete.Text + " No Existe";
                        lblError.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Debe digitar el numero del tiquete";
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2132, Global.Idioma) + ": " + txtTiquete.Text + "! " + ex.Message, false);
            }
        }

        protected void ModificarDatosVenta(object sender, EventArgs e)
        {
            try
            {
                PnlEditar.Enabled = true;
                lblError.Visible = false;
                if (Session != null)
                {
                    int i = 0; i++;
                    this.objAuditoria = Libreria.Auditorias.ObtenerItem(int.Parse(txtTiquete.Text));
               
                    //  Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 372, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    objAuditoria.Consecutivo = Convert.ToInt32(txtTiquete.Text);
                    objAuditoria.Placa = txtPlacaEdit.Text;
                    objAuditoria.Cod_Cli = txtCodCliEdit.Text;
                    objAuditoria.FormaDepago = Convert.ToInt32(ddlFormaDePagoEdit.SelectedValue);
                    objAuditoria.Total = Convert.ToDecimal(txtTotalVenta.Text);
                    Auditorias.ActualizarVenta(objAuditoria);
                    pnlDatos.Enabled = false;
                    PnlEditar.Enabled = false;
                }
                else
                {
                    int j = 0; j++;
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message, false);
                //SetError("Ocurrio un error al guardar el cupo en la DB: " + ex.Message + "<br><br>Detalle del error:<br><br>" +ex.StackTrace, false);

                objAuditoria = null;
                return;
            }
        }



        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.pnlForm.Visible = false;
        }
        #endregion

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                lblError.Visible = false;
                if (Session != null)
                {
                    int i = 0; i++;
                    this.objAuditoria = Libreria.Auditorias.ObtenerItem(int.Parse(txtTiquete.Text));

                    //  Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 372, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    objAuditoria.Consecutivo = Convert.ToInt32(txtTiquete.Text);
                    objAuditoria.Placa = txtPlacaEdit.Text;
                    objAuditoria.Cod_Cli = txtCodCliEdit.Text;
                    objAuditoria.FormaDepago = Convert.ToInt32(ddlFormaDePagoEdit.SelectedValue);
                    objAuditoria.Total = Convert.ToDecimal(txtTotalVenta.Text);
                    Auditorias.ActualizarVenta(objAuditoria);
                    //pnlDatos.Visible = false;
                    pnlDatos.Enabled = false;
                    PnlEditar.Enabled = false;
                    //PnlEditar.Visible = true;

                }
                else
                {
                    int j = 0; j++;
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message, false);
                //SetError("Ocurrio un error al guardar el cupo en la DB: " + ex.Message + "<br><br>Detalle del error:<br><br>" +ex.StackTrace, false);

                objAuditoria = null;
                return;
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //pnlDatos.Visible = false;
            pnlDatos.Enabled = false;
            PnlEditar.Enabled = false;
            //PnlEditar.Visible = true;

          
        }

  
        //#region ModificarVenta
    }
}