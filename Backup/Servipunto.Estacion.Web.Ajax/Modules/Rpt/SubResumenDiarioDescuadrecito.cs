using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubResumenDiarioDescuadrecito.
    /// </summary>
    public partial class SubResumenDiarioDescuadrecito : DataDynamics.ActiveReports.ActiveReport
    {

        #region Definicion de variables
        DateTime _fechaInicial;
        DateTime _fechaFinal;
        int _Language = 0;
        #endregion


        #region Constructor de la Clase
        public SubResumenDiarioDescuadrecito(DateTime fechaInicial, DateTime fechaFinal,int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _Language = Idioma;
            InitializeComponent();
            InitializeDatabase();
            if (Idioma == 1)
                Traducir();
        }
        #endregion


        #region QueryPrincipal
        private string QueryPrincipal()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select dbo.CalculoDescuadreRDEstacion ('" + this._fechaInicial.ToString("yyyyMMdd") + "','" + this._fechaFinal.ToString("yyyyMMdd") + "') as  descuadre");

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

        private void groupFooter1_Format(object sender, EventArgs e)
        {

        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            decimal a = 0;
            
            try
            {
                a = decimal.Parse(txtFormaPago.Text, System.Globalization.NumberStyles.Currency);
                if (_Language == 0)
                    txtEstado.Text = a > 0 ? "SOBRANTE" : "FALTANTE";
                else
                    txtEstado.Text = a > 0 ? "EXCESS" : "MISSING";
                

            }
            catch
            {
                txtEstado.Text = "nada";

            }
        }

        private void ghTotal_Format(object sender, EventArgs e)
        {

            decimal a = 0;

            try
            {
                a = Convert.ToInt32(txtFormaPago.Text);

            }
            catch
            {
                txtEstado.Text = "nada2";

            }

        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblTituloFormasPago.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23703, Global.Idioma).ToUpper();
        }
        #endregion
    }
}
