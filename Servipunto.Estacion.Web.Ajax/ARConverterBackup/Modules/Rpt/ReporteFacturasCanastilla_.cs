using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ReporteFacturasCanastilla_.
    /// </summary>
    public partial class ReporteFacturasCanastilla_ : DataDynamics.ActiveReports.ActiveReport3
    {
        DateTime _fechaInicio;
        DateTime _fechaFin;

        public ReporteFacturasCanastilla_(DateTime fechaInicial, DateTime fechaFinal)
        {

            _fechaInicio = fechaInicial;
            _fechaFin = fechaFinal;
            //this.InitializeDatabase();
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
           /* Libreria.Configuracion.Datos_Gene objdatosGene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();            
            this.lblFechaInicial.Text = _fechaInicio.ToString("dd/MM/yyyy");
            this.lblFechaFinal.Text = _fechaFin.ToString("dd/MM/yyyy");
            this.lblCompania.Text = objdatosGene[0].RazonSocial;*/

        }

      

        
        
    }
}
