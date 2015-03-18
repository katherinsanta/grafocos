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
    public partial class FiltroImportarClientesCorporativos : System.Web.UI.Page
    {
     

        #region load
        private void Page_Load(object sender, System.EventArgs e){
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            // Introducir aqu� el c�digo de usuario para inicializar la p�gina
            lblError.Visible = false;
            this.VerificarPermisos();
            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 223, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
            this.InicializarForma();

        }
        #endregion

        #region Inicializaci�n del Formulario
        private void InicializarForma()
        {
            try
            {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(885, Global.Idioma)+"</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(930, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            #endregion
                Libreria.Configuracion.Dat_Gene objDat_Gene = null;
                objDat_Gene = Libreria.Configuracion.Datos_Gene.ObtenerItem();
                txtSeparador.Text = objDat_Gene.SeparadorPlanosPredeterminado;
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region importar archivo clientes corporativos
        private void lblImportarArchivo_Click(object sender, System.EventArgs e)
        {
            string resultado;
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 224, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.ImportarPlanosClientesCorporativos("", txtSeparador.Text.Trim());
                if (resultado != "OK")
                {
                    SetError(resultado,false);
                    return;
                }
                else
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2148, Global.Idioma),false);


            }
            catch (Exception ex)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma) + ex.Message, false);
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

        #region C�digo generado por el Dise�ador de Web Forms
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar
        /// el contenido del m�todo con el editor de c�digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblImportarArchivo.Click += new System.EventHandler(this.lblImportarArchivo_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
