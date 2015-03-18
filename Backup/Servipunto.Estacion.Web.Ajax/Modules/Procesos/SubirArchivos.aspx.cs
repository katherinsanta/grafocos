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

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class SubirArchivos : System.Web.UI.Page
    {
        
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
            if (!IsPostBack)
                Iniciar_forma();
        }
        #endregion

        #region Iniciar Forma
        private void Iniciar_forma()
        {
            string[] arreglo = System.IO.Directory.GetFiles(Server.MapPath("../."));

            foreach (string c in arreglo)
                System.IO.File.Delete(c);
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(874, Global.Idioma) + "</b>";
            this.Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(876, Global.Idioma);
            this.btnadjuntar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(877, Global.Idioma);            
            this.Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
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


        #region Cargar Repeater
        private void Buscar()
        {
            try
            {
                Results.DataSource = this.CreateDataSource();
                Results.DataBind();
                this.SeccionResultados.Visible = true;
            }
            catch (Exception)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2132, Global.Idioma),false);
            }
        }
        #endregion

        #region CreateDataSource
        private ArrayList CreateDataSource()
        {
            ArrayList lista = new ArrayList();

            foreach (string c in System.IO.Directory.GetFiles(Server.MapPath("../.")))
                lista.Add(c);

            return lista;
        }
        #endregion

        #region Boton Adjuntar
        private void btnadjuntar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.inputFile.PostedFile != null)
                    if (this.inputFile.PostedFile.ContentType == "text/plain")
                        this.inputFile.PostedFile.SaveAs(Server.MapPath("../.") + "/" + System.IO.Path.GetFileName(this.inputFile.PostedFile.FileName));
                    else
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma),false);
                else
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2134, Global.Idioma), false);
            }
            catch (Exception)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma), false);
            }
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
            this.btnadjuntar.Click += new System.EventHandler(this.btnadjuntar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
