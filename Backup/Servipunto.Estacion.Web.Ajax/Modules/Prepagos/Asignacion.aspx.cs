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

namespace Servipunto.Estacion.Web.Ajax.Modules.Prepagos
{
    public partial class Asignacion : System.Web.UI.Page
    {
        DataTable _dtasignaciones = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VerificarPermisos())
            {
                traducir();
                if (!this.IsPostBack)
                {
                    Inicializar();
                    CrearDataTableAsignaciones();
                    CargarExistencias();
                    CargarClientes();
                    CargarDenominaciones();
                }
            }
        }

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Prepagos";
            const string opcion = "Asignar";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Asignar");

            if (!permiso)
            {
                lblError.Visible = true;
                lblError.Text = Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma);
                this.pnlForm.Visible = false;

                //this.MyForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion

        private void traducir() 
        {
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23863, Servipunto.Estacion.Web.Global.Idioma);
            lblALLOCATION.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23868, Servipunto.Estacion.Web.Global.Idioma);
            lblValue.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23861, Servipunto.Estacion.Web.Global.Idioma);
            lblVa.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23861, Servipunto.Estacion.Web.Global.Idioma);
            lblSTOCKS.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23869, Servipunto.Estacion.Web.Global.Idioma);
            
            lblname.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23865, Servipunto.Estacion.Web.Global.Idioma);
            lblCcode.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23864, Servipunto.Estacion.Web.Global.Idioma);
            lblCantidad.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23860, Servipunto.Estacion.Web.Global.Idioma);
            lblCanti.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23860, Servipunto.Estacion.Web.Global.Idioma);
            lblAsignado.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23866, Servipunto.Estacion.Web.Global.Idioma);
            lblAs.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23866, Servipunto.Estacion.Web.Global.Idioma);
            lblAprop.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23867, Servipunto.Estacion.Web.Global.Idioma);
            
        }

        private void Inicializar()
        {
            Session["Asignaciones"] = null;
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23870, Servipunto.Estacion.Web.Global.Idioma);
            this.lblBack.NavigateUrl = "default.aspx";
        }

        private void CargarExistencias()
        {
            DataTable datos = Libreria.Prepagos.Prepagos.ObtenerExistencias();
            grdExistencias.DataSource = datos;            
            grdExistencias.DataBind();
        }

        private void CargarClientes()
        {
            //Libreria.Comercial.Clientes objclientes = new Servipunto.Estacion.Libreria.Comercial.Clientes();
            //ddlClientes.DataSource = objclientes;
            //ddlClientes.DataValueField = "CodigoCliente";
            //ddlClientes.DataTextField = "NombreCliente";
            //ddlClientes.DataBind();

        }

        private void CargarDenominaciones()
        {
            DataTable datos = Libreria.Prepagos.Prepagos.ObtenerExistencias();
            ddlDenominaciones.DataSource = datos;
            ddlDenominaciones.DataTextField = "Value";
            ddlDenominaciones.DataValueField = "Value";
            ddlDenominaciones.DataBind();
        }   

        protected void grdExistencias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            decimal valor = 0;
            decimal cant = 0;
            decimal subt = 0;
            try
            {
                if (!ValidarDatosBasicos())
                {
                    return;
                }
                try
                {
                     valor = Convert.ToDecimal(ddlDenominaciones.SelectedValue);
                     cant = Convert.ToDecimal(txtCantidad_.Text);
                     subt = (valor * cant);
                }
                catch
                {
                    Mensaje1.ShowMessage("Valores no validos", "Error");                     
                    
                }


                try
                {
                    if (VerificarExitencia(valor, cant))
                    {
                        if (ValidarParciales(valor, cant))
                        {
                            decimal valorPrepago = Decimal.Parse(txtValor.Text, System.Globalization.NumberStyles.Currency);
                            _dtasignaciones = (DataTable)Session["Asignaciones"];

                            bool existe = false;
                            if (_dtasignaciones != null)
                            {

                                foreach (DataRow objRow in _dtasignaciones.Rows)
                                {
                                    decimal denoparcial = Decimal.Parse(objRow[0].ToString(), System.Globalization.NumberStyles.Currency);
                                    decimal cantparcial = Decimal.Parse(objRow[1].ToString(), System.Globalization.NumberStyles.Number);
                                    decimal subtparcial = Decimal.Parse(objRow[2].ToString(), System.Globalization.NumberStyles.Currency);
                                    if (denoparcial == valor)
                                    {
                                        objRow[1] = (cantparcial + cant).ToString("n");
                                        objRow[2] = (subtparcial + cant * valor).ToString("c");
                                        existe = true;
                                    }
                                }
                                if (!existe)
                                    _dtasignaciones.Rows.Add(valor, cant, subt);
                            }
                            else
                            {
                                CrearDataTableAsignaciones();
                                _dtasignaciones.Rows.Add(valor, cant, subt);
                            }

                            grdAsignaciones.DataSource = _dtasignaciones;
                            grdAsignaciones.DataBind();
                            Session["Asignaciones"] = _dtasignaciones;
                            SumarParciales();
                            txtCantidad_.Text = "0";
                            txtSubtotal.Text = "0";
                            ddlDenominaciones.SelectedIndex = 0;
                        }
                        else
                        {
                            Mensaje1.ShowMessage("Total asignado excede el valor del prepago, Elimine o modifique los valores asignados parcialmente", "Error");  

                        }
                    }
                    else
                    {
                        Mensaje1.ShowMessage("Cantida no existe en inventario", "Error");  
                        
                    }
                }
                catch(Exception ex)
                {
                    Mensaje1.ShowMessage(ex.Message, "Error");  


                }
            }
            catch
            {

            }

        }

        private void CrearDataTableAsignaciones()
        {
            _dtasignaciones = (DataTable)Session["Asignaciones"];
            if (_dtasignaciones == null)
            {
                _dtasignaciones = new DataTable();
                _dtasignaciones.Columns.Add("Value");
                _dtasignaciones.Columns.Add("Quantity");
                _dtasignaciones.Columns.Add("Subtotal");
                Session["Asignaciones"] = _dtasignaciones;
            }

        }

        protected void txtCantidad__TextChanged(object sender, EventArgs e)
        {
            decimal valor = Convert.ToDecimal(ddlDenominaciones.SelectedValue);
            decimal cant = Convert.ToDecimal(txtCantidad_.Text);
            //txtSubtotal.Text = (valor * cant).ToString();
            decimal subt = (valor * cant);
            txtSubtotal.Text = subt.ToString("c"); 
        }

        private void SumarParciales()
        {
            _dtasignaciones = (DataTable)Session["Asignaciones"];
            decimal sumAsignado = 0;
            decimal sumPorAsignar = 0;
            decimal sumSubtotal = 0;
            decimal sumCant = 0;
            foreach (DataRow objFila in _dtasignaciones.Rows)
            {
                sumAsignado += Convert.ToDecimal(objFila[0].ToString());
                sumCant += Convert.ToDecimal(objFila[1].ToString());
                sumSubtotal += Decimal.Parse(objFila[2].ToString(), System.Globalization.NumberStyles.Currency);
            }
            txtCantidad.Text = sumCant.ToString();
            decimal valor = decimal.Parse(txtValor.Text.Trim(), System.Globalization.NumberStyles.Currency);
            sumPorAsignar = valor - sumAsignado;
            txtValorAsignado.Text = sumSubtotal.ToString("c");
            txtValorPorAsignar.Text = (valor - sumSubtotal).ToString("c");

        }

        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
            txtValor.Text = Decimal.Parse(txtValor.Text, System.Globalization.NumberStyles.Currency).ToString("c");
        }

        protected void grdExistencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Cells[0].Text = Convert.ToDecimal(e.Row.Cells[0].Text).ToString("C");
            }
        }

        protected void grdAsignaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Cells[0].Text = Convert.ToDecimal(e.Row.Cells[0].Text).ToString("C");
                e.Row.Cells[2].Text = Convert.ToDecimal(e.Row.Cells[2].Text).ToString("C");
            }

        }

        private bool VerificarExitencia(decimal valor, decimal cant)
        {
            DataTable datos = Libreria.Prepagos.Prepagos.ObtenerExistencias();
            foreach (DataRow objDenominacion in datos.Rows)
            {
                decimal denominacion = decimal.Parse(objDenominacion.ItemArray.GetValue(0).ToString(), System.Globalization.NumberStyles.Currency);
                decimal cantidad = decimal.Parse(objDenominacion.ItemArray.GetValue(1).ToString());
                if (denominacion == valor)
                {
                    if (cantidad < cant)
                        return false;
                    else
                        return true;
                }               
            }
            return false;
        }

        private bool ValidarDatosBasicos()
        {
            if (txtIdentificacion.Text != "")
            {
                try
                {
                    Libreria.Cliente objCliente = Libreria.Clientes.Obtener(txtIdentificacion.Text);
                    if (objCliente == null)
                    {
                        Mensaje1.ShowMessage("Cliente No Existe", "Error");
                        return false;
                    }

                    txtValor.Text = Decimal.Parse(txtValor.Text, System.Globalization.NumberStyles.Currency).ToString("c");
                   
                }
                catch
                {
                    Mensaje1.ShowMessage("Valor prepago no valido", "Error");
                    return false;
                }

            }
            else
            {
                Mensaje1.ShowMessage("Cliente No Existe", "Error");
                return false;
            }
            return true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            decimal valor = decimal.Parse(txtValor.Text.Trim(), System.Globalization.NumberStyles.Currency);
            decimal porasignar = decimal.Parse(txtValorPorAsignar.Text, System.Globalization.NumberStyles.Currency);

            _dtasignaciones = (DataTable)Session["Asignaciones"];

            if (_dtasignaciones.Rows.Count > 0)
            {
                if (porasignar == 0)
                {
                    foreach (DataRow objFila in _dtasignaciones.Rows)
                    {
                        decimal deno = decimal.Parse(objFila[0].ToString(), System.Globalization.NumberStyles.Currency);
                        int cant = int.Parse(objFila[1].ToString(), System.Globalization.NumberStyles.Currency);

                        // Obtener los prepagos disponibles
                        Libreria.Prepagos.Prepagos objPrepagos = new Servipunto.Estacion.Libreria.Prepagos.Prepagos(deno, 1);
                        if (objPrepagos.Count >= cant)
                        {
                            int asignados = 0;
                            foreach (Libreria.Prepagos.Prepago objPrepago in objPrepagos)
                            {
                                objPrepago.Cod_Cli = txtIdentificacion.Text;
                                objPrepago.EstadoPrepago = Libreria.EstadoPrepago.Asignado;
                                objPrepago.FechaAsignacion = DateTime.Now;
                                objPrepago.Modificar();
                                asignados++;
                                if (asignados == cant)
                                    break;
                            }
                        }
                       

                    }
                    Mensaje1.ShowMessage("Asignación Exitosa", "Information");
                    Borrar();
                   // Response.Redirect("default.aspx");

                }
                else
                {
                    Mensaje1.ShowMessage("Valor prepago diferente al asignado", "Information");
                }
            }
            else
            {
                Mensaje1.ShowMessage("Asignaciones", "Error");
            }
        }

        private bool ValidarParciales(decimal valorp, decimal cantp)
        {
            _dtasignaciones = (DataTable)Session["Asignaciones"];
            decimal sumAsignado = 0;
            decimal sumPorAsignar = 0;
            decimal sumSubtotal = 0;
            decimal sumCant = 0;

            if (_dtasignaciones == null)
                return true;

            foreach (DataRow objFila in _dtasignaciones.Rows)
            {
                sumAsignado += Convert.ToDecimal(objFila[0].ToString());
                sumCant += Convert.ToDecimal(objFila[1].ToString());
                sumSubtotal += Decimal.Parse(objFila[2].ToString(), System.Globalization.NumberStyles.Currency);
            }
            sumSubtotal += valorp * cantp;
            decimal valor = decimal.Parse(txtValor.Text.Trim(), System.Globalization.NumberStyles.Currency);
            return (valor >= sumSubtotal);                

        }

       

        #region Borrar Fila
        public static void BorrarFila(DataTable Tabla, string LLave)
        {
            DataColumn[] myPrimaryKey = new DataColumn[1];
            myPrimaryKey[0] = Tabla.Columns["Value"];
            Tabla.PrimaryKey = myPrimaryKey;
            DataRow myRemoveDataRow = Tabla.Rows.Find(LLave);
            myRemoveDataRow.Delete();
            Tabla.AcceptChanges();
        }
        #endregion

        protected void grdAsignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string caso = Convert.ToString(e.CommandName);
            switch (caso)
            {
                case "Quitar":
                    foreach (GridViewRow Fila in grdAsignaciones.Rows)
                    {
                        CheckBox ChkBorrarUnoPorAsignar = ((CheckBox)Fila.FindControl("ChkBorrarUnoPorAsignar"));
                        if (ChkBorrarUnoPorAsignar.Checked == true)
                        {
                            Label ValorPrepago = ((Label)Fila.FindControl("lblValue"));
                            BorrarFila((DataTable)Session["Asignaciones"], ValorPrepago.Text);
                        }
                    }
                    grdAsignaciones.DataSource = (DataTable)Session["Asignaciones"];
                    grdAsignaciones.DataBind();
                    _dtasignaciones = (DataTable)Session["Asignaciones"];
                    SumarParciales();
                    break;
            }

        }

        private void Borrar()
        {
            txtSubtotal.Text = "0";
            txtIdentificacion.Text = "";
            txtValor.Text = "";
            txtValorAsignado.Text = "";
            txtValorPorAsignar.Text = "";
            txtSubtotal.Text = "0";
            txtNombreRazonSocial.Text = "";
            _dtasignaciones = null;
            txtCantidad.Text = "";
            txtCantidad_.Text = "";
            Session["Asignaciones"] = (_dtasignaciones);
            grdAsignaciones.DataSource = _dtasignaciones;
            grdAsignaciones.DataBind();
            CargarExistencias();            
            CargarDenominaciones();
        }



    }
}
