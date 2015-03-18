using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ventasTipoAutomotorResumido.
    /// </summary>
    public partial class ventasTipoAutomotorResumido : DataDynamics.ActiveReports.ActiveReport
    {

       		#region Definicion de Variables
		DateTime _fechaInicio;
		DateTime _fechaFin;
		string _tipoAutomotor;
		#endregion

		#region Costructor de la clase
		public ventasTipoAutomotorResumido(DateTime fechaInicio, DateTime fechaFin, string tipoAutomotor)
		{
			_fechaInicio = fechaInicio;
			_fechaFin = fechaFin;
			_tipoAutomotor = tipoAutomotor;
			InitializeComponent();
			InitializeDatabase();
            Traducir();
		}
		#endregion

		#region QueryEncabezado
		private string QueryEncabezado()
		{
			System.Text.StringBuilder sql = new System.Text.StringBuilder();

			sql.Append("Select");
			sql.Append(" Razon_Social,");
			sql.Append(" Nit,");
			sql.Append(" Nit_Dive");
			sql.Append(" From Dat_Gene");
			return sql.ToString();
		}
		#endregion

		#region Formato del Encabezado de Pagina
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
            #region fechas
            this.lblFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma) + ": " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma) + ": " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(836, Global.Idioma) + ": " +
                this._fechaInicio.ToString("dd/MM/yyyy") + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2186, Global.Idioma) +
                this._fechaFin.ToString("dd/MM/yyyy");
            #endregion

			this.srptEncabezado.Report = new SubEncabezado();
			this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
			((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
			((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();			
		}
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2308, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1127, Global.Idioma);
            lblConsecutivo.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma);            
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma);
            lblIva.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma);
            lblRecaudo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(419, Global.Idioma);
            lblTotalVenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2248, Global.Idioma);
            #region Pie de pagina

            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            lblModulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
            #endregion

        }
        #endregion
		#endregion

		#region QueryPrincipal
		private string QueryPrincipal()
		{
			System.Text.StringBuilder sql = new System.Text.StringBuilder();

			sql.Append("exec RptVentasTipoAuto ");
			sql.Append("'" + this._fechaInicio.ToString("yyyyMMdd") + "', ");
			sql.Append("'" + this._fechaFin.ToString("yyyyMMdd") + "', 0 ");
			if(_tipoAutomotor != "-1")
				sql.Append(",'" + _tipoAutomotor + "'");			
			return sql.ToString();
		}
		#endregion

		#region InitializeDatabase
		private void InitializeDatabase()
		{
			this.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
			((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
			((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.DataSource).SQL = QueryPrincipal();
		}
		#endregion	

		#region Pie de pagina
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			this.lblAno.Text = System.DateTime.Now.Year.ToString();
		}
		#endregion
    }
}
