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

namespace Servipunto.ReconversionTarija.Web.ControlesDeUsuario
{
    public partial class Mensaje : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgAceptar.OnClientClick = String.Format("fnClickOK('{0}','{1}')", ImgAceptar.UniqueID, "");
            btnOk1.OnClientClick = String.Format("fnClickOK('{0}','{1}')", btnOk1.UniqueID, "");
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
            lblCaption.Text = "";
            tdCaption.Visible = false;
            mpeMensaje.Show();
        }

        public void ShowMessage(string Message, string Caption)
        {
            lblMessage.Text = Message;
            lblCaption.Text = Caption;
            tdCaption.Visible = true;
            mpeMensaje.Show();
        }

        private void Hide()
        {
            lblMessage.Text = "";
            lblCaption.Text = "";
            mpeMensaje.Hide();
        }

        public void btnOk1_Click(object sender, EventArgs e)
        {
            OnOk1ButtonPressed(e);
        }
        
        public delegate void Ok1ButtonPressedHandler(object sender, EventArgs args);
        public event Ok1ButtonPressedHandler Ok1ButtonPressed;
        protected virtual void OnOk1ButtonPressed(EventArgs e)
        {
            if (Ok1ButtonPressed != null)
                Ok1ButtonPressed(btnOk1, e);
        }

        public delegate void OkButtonPressedHandler(object sender, EventArgs args);
        public event OkButtonPressedHandler OkButtonPressed;
        protected virtual void OnOkButtonPressed(EventArgs e)
        {
            if (OkButtonPressed != null)
                OkButtonPressed(ImgAceptar, e);
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            OnOkButtonPressed(e);
        }
    }
}