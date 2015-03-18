using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptFormasPago.
    /// </summary>
    public partial class SubRptFormasPago : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de Variables
        DateTime _fechaInicio;
        DateTime _fechaFin;
        int _isla;
        string _turno;
        #endregion

        #region Constructor de la Clase
        public SubRptFormasPago(DateTime fechaInicio, int isla, string turno)
        {
            _fechaInicio = _fechaFin = fechaInicio;
            _isla = isla;
            _turno = turno;
            InitializeComponent();
            InitializeDatabase();
            Traducir();
        }
        #endregion
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(148, Global.Idioma);
            lblTituloFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            lblUnidades.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2083, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(148, Global.Idioma);
            lblUnidades.Text ="No. "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(754, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
        }
        #endregion
        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select");
            sql.Append(" F.Cod_For_Pag Codigo,");
            sql.Append(" F.Descripcion Forma_De_Pago,");
            sql.Append(" IsNull(Count(V.Consecutivo), 0) Cantidad_de_Ventas,");
            sql.Append(" IsNull(Sum(Cantidad), 0) Unidades,");
            sql.Append(" IsNull(Sum(ValorNeto), 0) ValorNeto,");
            sql.Append(" IsNull(Sum(Descuento), 0) Descuento,");
            sql.Append(" IsNull(Sum(SubTotal), 0) SubTotal,");
            sql.Append(" IsNull(Sum(Vr_Iva), 0) Iva,");
            sql.Append(" IsNull(Sum(Total_Cuota), 0) Recaudo,");
            sql.Append(" IsNull(Sum(Total), 0) Total");
            sql.Append(" From Form_Pag F Left Join Ventas V");
            sql.Append(" On (F.Cod_For_Pag = V.Cod_For_pag)");
            sql.Append(" And (Dbo.Finteger(Fecha) Between '" + this._fechaInicio.ToString("yyyyMMdd") + "'");
            sql.Append(" And '" + this._fechaFin.ToString("yyyyMMdd") + "')");
            sql.Append(" And V.Num_Tur = " + this._turno);
            sql.Append(" And V.Cod_Isl = " + this._isla);
            sql.Append(" Group By F.Cod_For_Pag, F.Descripcion");
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
    }
}
