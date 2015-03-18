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


namespace Servipunto.Cartera.Web.BlueSkin.UserControls
{
    public partial class Buscador : System.Web.UI.UserControl
    {
        #region Definición de Propiedades
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        public string CampoVisible1
        {
            get { return lblCampoVisible1.Text; }
            set { lblCampoVisible1.Text = value; }
        }
        public string CampoVisible2
        {
            get { return lblCampoVisible2.Text; }
            set { lblCampoVisible2.Text = value; }
        }
        public string CampoVisible3
        {
            get { return lblCampoVisible3.Text; }
            set { lblCampoVisible3.Text = value; }
        }
        public string CampoVisible4
        {
            get { return lblCampoVisible4.Text; }
            set { lblCampoVisible4.Text = value; }
        }
        public string CampoInVisible1
        {
            get { return lblCampoInVisible1.Text; }
            set { lblCampoInVisible1.Text = value; }
        }
        public string CampoInVisible2
        {
            get { return lblCampoInVisible2.Text; }
            set { lblCampoInVisible2.Text = value; }
        }
        public string CampoInVisible3
        {
            get { return lblCampoInVisible3.Text; }
            set { lblCampoInVisible3.Text = value; }
        }
        public string CampoInVisible4
        {
            get { return lblCampoInVisible4.Text; }
            set { lblCampoInVisible4.Text = value; }
        }
        public string NoColumnas
        {
            get { return lblNoColumnas.Text; }
            set { lblNoColumnas.Text = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void PresentarDatos()
        {
            //ClienteCollection objClientes = new ClienteCollection();
            //objClientes.GetMulti(null);
            //grdBusqueda.DataSource = objClientes;
            //grdBusqueda.DataBind();
            
        }
 
    }
}