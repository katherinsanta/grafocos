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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
    public partial class FiltroResumenDiarioTransacciones : System.Web.UI.Page
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
            }
        }
        #endregion

        #region Validar
        private bool Validar()
        {
            //23-mayo-2011
            //Metodo comentareado por version macarena.
            //PROBLEMA:  
            //  no permite ver el reporte cuando no existe jornada Z abierta o no maneja jornada Z
            //Cambio:
            //  Aprovacion: LUISA MACA DIR.sistemas
            //      Efectuado por: miguel cantor .desarrollador junior
            //                      yuly gutierrez .desarrollador junior
            //
            //
            //
            //Servipunto.Estacion.Libreria.Turnos.JornadaZeta objJZ = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(1);
            //if (objJZ != null)
            //{
            //    if (this.FechaInicio.SelectedDate > objJZ.Fecha)
            //    {
            //        this.SetError("La fecha seleccionada deber ser una fecha donde se halla cerrado la jornada Zeta !");
            //        return false;
            //    }
            //}
            //else
            //{
            //    this.SetError("No existen jornadas Zeta Abiertas!");
            //    return false;
            //}

            return true;
        }
        #endregion

        #region EjecutarReporte
        /// <summary>
        /// Ejecuta el reporte seleccionado
        /// </summary>       
        /// Fecha:  28/10/2010
        /// Autor:  Rodrigo Cerquera
        private void EjecutarReporte()
        {
            if (this.Validar())
            {
                try
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 320, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    DataDynamics.ActiveReports.ActiveReport report = null;
                    if (TipoReporte.SelectedValue == "Resumido")
                    {
                        string usuario = ((Libreria.Usuario)Session["Usuario"]).Nombre;
                        if (lblReporte.Text == "<b>Transaction Report Daily Summary</b>")
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ResumenDiarioTransacciones(FechaInicio.SelectedDate, FechaFinal.SelectedDate, usuario, 1);
                        else
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ResumenDiarioTransacciones(FechaInicio.SelectedDate, FechaFinal.SelectedDate, usuario, 0);
                    }
                    else
                    {
                        if (lblReporte.Text == "<b>Transaction Report Daily Summary</b>")
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ResumenDiarioDetallado(FechaInicio.SelectedDate, FechaFinal.SelectedDate, 1);
                        else
                            report = new Servipunto.Estacion.Web.Modules.Rpt.ResumenDiarioDetallado(FechaInicio.SelectedDate, FechaFinal.SelectedDate, 0);
                    }
                    Session["LastReport"] = report;
                    Session["Formato"] = "pdf";
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de Articulos. ");
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
            const string opcion = "Auditoria";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Resumen Diario Transaccion");

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
            this.lblReporte.Text = "<b>Transaction Report Daily Summary</b>";
            this.FechaInicio.SelectedDate = System.DateTime.Now;
            this.FechaFinal.SelectedDate = System.DateTime.Now;
            Traducir();
        }
        #endregion

        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblTipoReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            TipoReporte.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma);
            TipoReporte.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma);
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma);
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma);
            lblAviso.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23670, Global.Idioma);
            LinkButton1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(38, Global.Idioma);
        }
        #endregion
    }
}
