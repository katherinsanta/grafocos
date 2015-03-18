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

namespace Servipunto.Zencillo.Colombia.PaginaMaestra
{
    public partial class MasterIni : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImgServipunto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("www.servipunto.com");
        }
    }
}
