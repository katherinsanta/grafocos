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
    public partial class FiltroExtracto : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                //CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                //CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
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

            if (this.cbTodosAutomotores.Checked == false && this.txtAutomotor.Text == "")
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2338, Global.Idioma), false);
                return false;
            }

            return true;
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Credito Directo";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Extracto Clientes");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.pnlForm.Visible = false;
                //this.MyForm.Visible = false;
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

                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 352, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    DataDynamics.ActiveReports.ActiveReport report = null;
                   
                    switch (this.ddlNivelDetalle.SelectedValue)
                    {
                        case "1":
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteDetalleBajo(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), ddlHoraInicio.SelectedValue.ToString() + ":" + ddlMinutosInicio.SelectedValue.ToString() + ":00.000", ddlHoraFinal.SelectedValue.ToString() + ":" + ddlMinutosFinal.SelectedValue.ToString() + ":00.000", Convert.ToInt32(this.ddlFormaPago.SelectedValue), this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
                            break;

                        case "2":
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteDetalleMedio(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), ddlHoraInicio.SelectedValue.ToString() + ":" + ddlMinutosInicio.SelectedValue.ToString() + ":00.000", ddlHoraFinal.SelectedValue.ToString() + ":" + ddlMinutosFinal.SelectedValue.ToString() + ":00.000", Convert.ToInt32(this.ddlFormaPago.SelectedValue), this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
                            break;

                        case "3":
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteValor(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text),  ddlHoraInicio.SelectedValue.ToString() + ":" + ddlMinutosInicio.SelectedValue.ToString() + ":00.000", ddlHoraFinal.SelectedValue.ToString() + ":" + ddlMinutosFinal.SelectedValue.ToString() + ":00.000", Convert.ToInt32(this.ddlFormaPago.SelectedValue), this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
                            break;

                        case "4":
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteClasico(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), ddlHoraInicio.SelectedValue.ToString() + ":" + ddlMinutosInicio.SelectedValue.ToString() + ":00.000", ddlHoraFinal.SelectedValue.ToString() + ":" + ddlMinutosFinal.SelectedValue.ToString() + ":00.000", Convert.ToInt32(this.ddlFormaPago.SelectedValue), this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
                            break;
                        case "5":
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ExtractoClienteDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), ddlHoraInicio.SelectedValue.ToString() + ":" + ddlMinutosInicio.SelectedValue.ToString() + ":00.000", ddlHoraFinal.SelectedValue.ToString() + ":" + ddlMinutosFinal.SelectedValue.ToString() + ":00.000", Convert.ToInt32(this.ddlFormaPago.SelectedValue), this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
                            break;

                    }
                    Session.Add("LastReport", report);
                    Session["Formato"] = rbFormato.SelectedValue;
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
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(352, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(362, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(372, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  TipoReporte
            this.ddlNivelDetalle.Items.Clear();
            this.ddlNivelDetalle.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(373, Global.Idioma), "1"));
            this.ddlNivelDetalle.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(374, Global.Idioma), "2"));
            this.ddlNivelDetalle.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(375, Global.Idioma), "3"));
            this.ddlNivelDetalle.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(376, Global.Idioma), "4"));
            this.ddlNivelDetalle.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma), "5"));
            this.ddlNivelDetalle.SelectedValue = "0";
            #endregion
            ViewState["Control"] = "1";
            #endregion
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
            CargarFormasPago();
            LlenarHoras();
            this.cbTodos_CheckedChanged(null, null);
            this.cbTodosAutomotores_CheckedChanged(null, null);
        }
        #endregion

        #region Cargar Formas de Pago
        private void CargarFormasPago()
        {
            Servipunto.Estacion.Libreria.FormasPago objFormasPago = new Servipunto.Estacion.Libreria.FormasPago();

            this.ddlFormaPago.DataSource = objFormasPago;
            this.ddlFormaPago.DataValueField = "IdFormaPago";
            this.ddlFormaPago.DataTextField = "Nombre";
            this.ddlFormaPago.DataBind();

            this.ddlFormaPago.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
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
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            this.cbTodosAutomotores.CheckedChanged += new System.EventHandler(this.cbTodosAutomotores_CheckedChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region	Seleccionar Todos
        private void cbTodos_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbTodos.Checked)
                this.txtCodigoCliente.Enabled = false;
            else
                this.txtCodigoCliente.Enabled = true;
        }

        private void cbTodosAutomotores_CheckedChanged(object sender, System.EventArgs e)
        {

            if (this.cbTodosAutomotores.Checked)
                this.txtAutomotor.Enabled = false;
            else
                this.txtAutomotor.Enabled = true;
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

        private void LlenarHoras()
        {
            for (int i = 0; i <= 23; i++)
            {
                ddlHoraInicio.Items.Add(new ListItem(i.ToString().PadLeft(2,'0')));
                ddlHoraFinal.Items.Add(new ListItem(i.ToString().PadLeft(2, '0')));
            }

            for (int j = 0; j < 60; j=j+5)
            {
                ddlMinutosInicio.Items.Add(new ListItem(j.ToString().PadLeft(2, '0')));
                ddlMinutosFinal.Items.Add(new ListItem(j.ToString().PadLeft(2, '0')));
            }

        }
    }
}
