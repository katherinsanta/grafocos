using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebas_ing_ingreso
{
    public partial class _in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                
                    //RadioButton1.Text;
            }
            else
            {
                lblprueba.Text = RadioButton2.Text;
            }
        }
    }
}