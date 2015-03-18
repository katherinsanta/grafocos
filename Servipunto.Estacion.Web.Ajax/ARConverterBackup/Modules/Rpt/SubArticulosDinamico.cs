using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubArticulosDinamico.
    /// </summary>
    public partial class SubArticulosDinamico : DataDynamics.ActiveReports.ActiveReport3
    {


        #region declaracion de variables
        DateTime _fechaInicial;
        DateTime _fechafinal;
        string _codigoCliente = "";

        #endregion


        #region iniciar formulario

        public SubArticulosDinamico()
        {
            InitializeComponent();
            /*_fechaInicial = fechaInicial;
            _fechafinal = fechafinal;
            _codigoCliente = codigoCliente;
            //EjecutarConsulta();
            */

            Traducir();

        }
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {            
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(65, Global.Idioma);
         
        }
        #endregion
        #endregion

        #region ejecutar consulta
        private void EjecutarConsulta()
        {
            /*this.DataSource = Servipunto.Estacion.Libreria.Ventas.RptVentasPorArticulo(_fechaInicial,
                                                                                        _fechafinal,
                                                                                        _codigoCliente);
                                                                                        */
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubArticulosDinamico.rpx");
            this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
            this.ghArticulos = ((DataDynamics.ActiveReports.Detail)(this.Sections["ghArticulos"]));
            this.gfArticulos = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["gfArticulos"]));
            this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
            this.Line = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[1]));
            this.txtNombre = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulos.Controls[0]));
            this.txtCodigo = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulos.Controls[1]));
            this.txtCantidad = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulos.Controls[2]));
            this.txtTotal = ((DataDynamics.ActiveReports.TextBox)(this.ghArticulos.Controls[3]));
            this.Line1 = ((DataDynamics.ActiveReports.Line)(this.gfArticulos.Controls[0]));
            this.Line2 = ((DataDynamics.ActiveReports.Line)(this.gfArticulos.Controls[1]));
        }

    }
}
