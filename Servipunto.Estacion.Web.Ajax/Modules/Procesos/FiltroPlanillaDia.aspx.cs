using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Ajax.Modules.Procesos
{
    public partial class FiltroPlanillaDia : System.Web.UI.Page
    {
        decimal _TotalCantidad;
        decimal _TotalSubtotal;
        decimal _Total;
        decimal _TotalDescuento;

        decimal _TotalDiferenciaLects;
        decimal _TotalCalibracionLects;
        decimal _TotalCantidadLects;
        decimal _TotalValorLects;


        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            if (this.IsPostBack)
            {
                //txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                {
                    this.lblError.Visible = false;
                }
            }
            else
            {
                this.VerificarPermisos();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 207, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.InicializarForma();
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Interfaz Contable";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generacion Archivo Plano de Facturas");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);

                return false;
            }

            return true;
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
       

        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
         
            this.lblReporte.Text = "<b> Generar Planilla Dia </b>";
            //MostrarDatos();

            #endregion

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
            //this.lblGuardarFacturas.Click += new System.EventHandler(this.lblGuardarFacturas_Click);
            //this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lnkGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }


        #endregion








      

        protected void btnGenerar_Click(object sender, EventArgs e)
        {

            Response.Redirect("PlanillaDia.aspx?FechaInicial=" + txtFechaInicial.Text );
          


        }

      


    }
}