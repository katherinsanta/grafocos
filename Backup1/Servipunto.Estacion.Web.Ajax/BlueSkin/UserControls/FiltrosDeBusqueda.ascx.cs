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
using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.CollectionClasses;
//using Servipunto.Zencillo.Logica.Libreria.Entidades;
//using Servipunto.Zencillo.Logica.Libreria.Varios;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;


namespace Servipunto.Cartera.Web.BlueSkin.UserControls
{
    public partial class FiltrosDeBusqueda : System.Web.UI.UserControl
    {
        #region Sección de Declaracionse de eventos
        /// <summary>
        /// Realiza una peticion de busqueda
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  11/16/2008
        /// Autor:  Elvis Astaiza Gutierrez
        public event System.EventHandler Buscar;

        #region RefrescarEstado
        /// <summary>
        /// Genera un evento de refresco de carga
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  11/06/2009
        /// Autor:  Elvis Astaiza Gutierrez                    
        private void GenerarEventoBusqueda()
        {
            if (Buscar != null)
                Buscar(null, null);
        }
        #endregion

        #endregion

        #region PropiedadesPublicas
        /// <summary>
        /// Filtro que contiene los criterios de busqueda
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  11/06/2009
        /// Autor:  Elvis Astaiza Gutierrez                    
        public IPredicateExpression Filtro
        {
            get
            {
                return (SD.LLBLGen.Pro.ORMSupportClasses.PredicateExpression)ViewState["Filtro"];
            }
            set
            {
                ViewState.Add("Filtro", value);
            }
        }

        /// <summary>
        /// Total de registros que retornara la consulta
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  11/06/2009
        /// Autor:  Elvis Astaiza Gutierrez                    
        public int Total
        {
            get
            {
                int totalRegistros = txtTotalRegistros.Text.Trim().Length == 0 ? 0 : int.Parse(txtTotalRegistros.Text.Trim());
                ViewState.Add("Total", totalRegistros);
                return (int)ViewState["Total"];
            }
            set
            {
                txtTotalRegistros.Text = value.ToString();
            }

        }

        /// <summary>
        /// Total de registros por  pagina
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  30/06/2009
        /// Autor:  Elvis Astaiza Gutierrez                    
        public int RegistrosPorPagina
        {
            get
            {
                int RegistrosPorPagina = txtTotalRegistrosPorPagina.Text.Trim().Length == 0 ? 0 : int.Parse(txtTotalRegistrosPorPagina.Text.Trim());
                if (RegistrosPorPagina <= 0)
                    RegistrosPorPagina = 10;
                ViewState.Add("RegistrosPorPagina", RegistrosPorPagina);
                return (int)ViewState["RegistrosPorPagina"];
            }
            set
            {
                txtTotalRegistrosPorPagina.Text = value.ToString();
            }
        }

        /// <summary>
        /// Ordenacion del resultado
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha:  11/06/2009
        /// Autor:  Elvis Astaiza Gutierrez                    
        public SortExpression Orden
        {
            get
            {
                return (SD.LLBLGen.Pro.ORMSupportClasses.SortExpression)ViewState["Orden"];
            }
            set
            {
                ViewState.Add("Orden", value);
            }
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2074, 1);
                Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2075, 1);
                Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2076, 1);
                txtTotalRegistrosPorPagina.ToolTip = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2077, 1);
                txtTotalRegistros.ToolTip = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2077, 1);
                lnkConsultar.ToolTip = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2078, 1);
            }
        }
        #endregion

        protected void lnkConsultar_Click(object sender, EventArgs e)
        {
            this.GenerarEventoBusqueda();
        }
    }
}