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

namespace Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion
{
    public partial class FiltroInventarioCanastilla : System.Web.UI.Page
    {
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();
            }
            else
            {
                this.VerificarPermisos();
                this.InicializarForma();
                Traducir();
            }
        }
        #endregion

        #region Validar
        private bool Validar()
        {
            if (this.FechaInicio.SelectedDate > this.FechaFin.SelectedDate)
            {
                this.SetError("La fecha inicial no puede ser superior a la final!");
                return false;
            }
            return true;
        }
        #endregion

        #region EjecutarReporte
        private void EjecutarReporte()
        {
          
            if (this.Validar())
            {
                try
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 341, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    DataDynamics.ActiveReports.ActiveReport report = null;

                    int cod_art = 0;
                    try
                    {
                         cod_art =  !chkTodos.Checked ?  Convert.ToInt32(ddlArticulos.SelectedValue.ToString()) : 0;                          
                    }
                    catch
                    {

                    }
                    if (lblReporte.Text == "Basket Inventory Report")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.RptInventarioCanastilla(FechaInicio.SelectedDate, FechaFin.SelectedDate, cod_art, 1);
                    else
                        report = new Servipunto.Estacion.Web.Modules.Rpt.RptInventarioCanastilla(FechaInicio.SelectedDate, FechaFin.SelectedDate, cod_art, 0);
                  
                    Session.Add("LastReport", report);
                    Response.Redirect("../Visor/PDF.aspx", false);
                }
                catch (Exception ex)
                {
                    this.SetError(ex.Message);
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                            ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de ventas por cliente. ");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                        this.SetError(lblError.Text);

                    }
                    #endregion

                }
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Cliente";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas NIT");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                this.pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            this.lblReporte.Text = "<b>Reporte de Inventario Canastilla</b>";
            this.FechaInicio.SelectedDate = System.DateTime.Now;
            this.FechaFin.SelectedDate = System.DateTime.Now;
            CargarProductos();
          
        }
        #endregion

        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

      

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

        private void CargarProductos()
        {
            Libreria.Configuracion.Articulos objs = new Servipunto.Estacion.Libreria.Configuracion.Articulos(Libreria.TipoArticulo.Canastilla);
            ddlArticulos.DataSource = objs;
            ddlArticulos.DataTextField = "Descripcion";
            ddlArticulos.DataValueField = "IdArticulo";
            ddlArticulos.DataBind();
        }

        protected void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            ddlArticulos.Enabled = !chkTodos.Checked;
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 16/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23711, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            chkTodos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(809, Global.Idioma);
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma);
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma);
            LinkButton1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(38, Global.Idioma);
        }
        #endregion
    }
}
