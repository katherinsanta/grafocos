using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using System.Data.SqlClient;
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
    public partial class FiltroTurnoSurtidorArticulo : System.Web.UI.Page
    {
        #region Declaración de Controles

       /* protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblReporte;
        protected System.Web.UI.WebControls.Calendar FechaInicio;
        protected System.Web.UI.WebControls.Calendar FechaFin;
        protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
        protected System.Web.UI.WebControls.DropDownList ddlSurtidor;
        protected System.Web.UI.WebControls.DropDownList ddlTurno;
        protected System.Web.UI.WebControls.DropDownList ddlArticulo;
        protected System.Web.UI.WebControls.Label lblError;*/

        #endregion

        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            ViewState["Control"] = "0";
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                { 
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
        }
        #endregion
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();
            }
            else
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    this.VerificarPermisos();
                    this.InicializarForma();
                }
            }
        }
        #endregion
        #region Validar
        private bool Validar()
        {
            if (Convert.ToDateTime(this.txtFechaInicial.Text) > Convert.ToDateTime(this.txtFechaFin.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1962, Global.Idioma), false);
                return false;
            }

            return true;
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Generales";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Surtidor");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
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
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 324, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    DataDynamics.ActiveReports.ActiveReport report = null;

                    report = new Servipunto.Estacion.Web.Modules.Rpt.VentasTurnoSurtidorArticulo(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.ddlTurno.SelectedValue), int.Parse(this.ddlSurtidor.SelectedValue), int.Parse(this.ddlArticulo.SelectedValue));
                
                    Session.Add("LastReport", report);
                    Response.Redirect("../Visor/PDF.aspx", false);
                }
                catch (Exception ex)
                {
                    this.SetError(ex.Message, false);
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                            ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                    }
                    catch (Exception exx)
                    {
                        lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                    }
                    #endregion   
                }
            }
        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(21, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(75, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
            CargarTurno();
            CargarSurtidor();
            CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
            
        }
        #endregion

        #region Cargar Turnos
        private void CargarTurno()
        {
            for (int i = 1; i <= 10; i++)
            {
                this.ddlTurno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            this.ddlTurno.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
        }
        #endregion

        #region Cargar Surtidor
        private void CargarSurtidor()
        {
            for (int i = 1; i <= 20; i++)
            {
                this.ddlSurtidor.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            this.ddlSurtidor.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
        }
        #endregion

        #region CargarArticulos
        private void CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo tipoArticulo)
        {
            Servipunto.Estacion.Libreria.Articulos objArticulos = new Servipunto.Estacion.Libreria.Articulos(tipoArticulo);

            this.ddlArticulo.DataSource = objArticulos;
            this.ddlArticulo.DataTextField = "Descripcion";
            this.ddlArticulo.DataValueField = "IdArticulo";
            this.ddlArticulo.DataBind();

            this.ddlArticulo.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));

            objArticulos = null;
        }
        #endregion




        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

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
    }
}
