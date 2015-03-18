using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Web.Ajax.Modules.Procesos
{
    public partial class PlanillaTurno : System.Web.UI.Page
    {

        decimal _TotalCantidad;
        decimal _TotalSubtotal;
        decimal _Total;
        decimal _TotalDescuento;

        decimal _TotalDiferenciaLects;
        decimal _TotalCalibracionLects;
        decimal _TotalCantidadLects;
        decimal _TotalValorLects;


        decimal _TotalArticulosCantidad;
        decimal _TotalArticulosSubtotal;

        decimal _TotalFormaPago;

        decimal _TotalCantidadCanastilla;
        decimal _TotalSubtotalCanastilla;
        decimal _TotalTotalIvaCanastilla;
        decimal _TotalTotalCanastilla;

        decimal _TotalBilletesConsignaciones;
        decimal _TotalMonedaConsignaciones;
        decimal _TotalTotalConsignaciones;


        bool _adicionarBolsa = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CargarEncabezado();
                CargarArticulosVenta();
                CargarFormasPago();
                CargarCaraVenta();
                CargueDatos();
                CargarDatosAprobacion();
            }

        }

        private void CargarEncabezado()
        {
            this.lblBack.NavigateUrl = "FiltroPlantillaTurno.aspx";
            lblFechaInicial.Text = Convert.ToDateTime(Request.QueryString["FechaInicial"]).ToString("yyyy-MM-dd");
            txtIsla.Text = Request.QueryString["Isla"];
            txtTurno.Text = Request.QueryString["Turno"];

            DateTime fecha = Convert.ToDateTime(Request.QueryString["FechaInicial"]);
            DataSet datosTurno = Servipunto.Estacion.Libreria.Turnos.TurnosLaborales.ReporteTurnos(fecha, txtTurno.Text, int.Parse(txtIsla.Text));

            if (datosTurno != null)
            {
                if (datosTurno.Tables[0].Rows.Count > 0)
                {
                    txtCodigoEmpleado.Text = datosTurno.Tables[0].Rows[0].ItemArray[4].ToString();
                    txtHoraInico.Text = datosTurno.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtHoraFinal.Text = datosTurno.Tables[0].Rows[0].ItemArray[3].ToString();
                    txtNombreEmpleado.Text = datosTurno.Tables[0].Rows[0].ItemArray[5].ToString();

                }
            }


        }

        private void CargueDatos()
        {
            lblFechaInicial.Text = DateTime.Parse(lblFechaInicial.Text).ToString("yyyy-MM-dd");

            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;

            CargarVentasTurno();
            CargueDatosLecturas();
            CargarDatosCanastilla();
            CargarDatosBolsas();
            CargarResumenArticulos();
            CargarResumenFormasPago();
            CargarDescuadreEmpleado();
            SumarIngresos();

        }

        private void CargarDescuadreEmpleado()
        {
            DataTable datosDescuadre;
            datosDescuadre = GetDataDescuadre();
            grdDescuadre.DataSource = datosDescuadre;
            grdDescuadre.DataBind();

        }

        private void CargarResumenFormasPago()
        {
            DataTable datosResumenFormasPago;
            datosResumenFormasPago = GetDataResumenFormasPago();
            grdFormasPago.DataSource = datosResumenFormasPago;
            grdFormasPago.DataBind();

        }

        private void CargarResumenArticulos()
        {
            DataTable datosResumenArticulo;
            datosResumenArticulo = GetDataResumenArticulos();
            grdArticulos.DataSource = datosResumenArticulo;
            grdArticulos.DataBind();


        }

        private void CargarDatosBolsas()
        {
            DataTable datosBolsas = GetDataBolsa();
            grdBolsasTurno.DataSource = datosBolsas;
            grdBolsasTurno.DataBind();

        }

        private void CargarDatosCanastilla()
        {
            DataTable datosCanastilla = GetDataCanastilla();
            grdCanastilla.DataSource = datosCanastilla;
            grdCanastilla.DataBind();
        }

        private void CargueDatosLecturas()
        {
            DataTable datosLecturas = GetDataLecturas();
            GridLecturas.DataSource = datosLecturas;
            GridLecturas.DataBind();
        }

        protected void grdDetalleVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;

                    _TotalCantidad += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                    _TotalSubtotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SubTotal"));
                    _TotalDescuento += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Descuento"));
                    _Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {

                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;

                    e.Row.Cells[8].Text = "Totales:";

                    e.Row.Cells[9].Text = _TotalCantidad.ToString("n3");
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[10].Text = _TotalSubtotal.ToString("c3");
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[11].Text = _TotalDescuento.ToString("c3");
                    e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[12].Text = _Total.ToString("c3");
                    e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Right;


                    e.Row.Font.Bold = true;

                }

                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;

                }
            }



            catch (Exception err)
            {

                string error = err.Message.ToString() + " - " + err.Source.ToString();

            }


        }

        protected void GridLecturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[8].Visible = false;
                    _TotalDiferenciaLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "diferencia"));
                    _TotalCalibracionLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Calibracion"));
                    _TotalCantidadLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VentasGls"));
                    _TotalValorLects += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VentasVentas"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {

                    e.Row.Cells[3].Text = "Totales:";

                    e.Row.Cells[4].Text = _TotalDiferenciaLects.ToString("n3");

                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[5].Text = _TotalCalibracionLects.ToString("N3");
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[6].Text = _TotalCantidadLects.ToString("N3");
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[7].Text = _TotalValorLects.ToString("c3");
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Font.Bold = true;

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[8].Visible = false;
                }


            }



            catch (Exception err)
            {

                string error = err.Message.ToString() + " - " + err.Source.ToString();

            }


        }

        protected void SortingGrilla(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            string direction = string.Empty;

            if (e.SortDirection == SortDirection.Ascending)
            {

                e.SortDirection = SortDirection.Ascending;
                direction = " ASC";
            }
            else
            {
                e.SortDirection = SortDirection.Descending;
                direction = " DESC";
            }



            DataTable table = this.GetDataVentas();
            table.DefaultView.Sort = sortExpression + direction;
            grdDetalleVentas.DataSource = table;
            grdDetalleVentas.DataBind();

        }

        private DataTable GetDataVentas()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDDVentasCombustible", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataLecturas()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);


            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioLecturas", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataCanastilla()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDDVentasCanastilla", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataBolsa()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SP_ConsultaBolsasTurno", parameters);

            return reader.Tables[0];
        }


        private DataTable GetDataResumenArticulos()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SP_ResumenArticuloTurno", parameters);

            return reader.Tables[0];
        }


        private DataTable GetDataDescuadre()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "SubRptResumenDiarioConsignaciones", parameters);

            return reader.Tables[0];
        }

        private DataTable GetDataResumenFormasPago()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            parameters[0] = new SqlParameter("@FechaInicial", SqlDbType.DateTime);
            parameters[1] = new SqlParameter("@FechaFinal", SqlDbType.DateTime);
            parameters[2] = new SqlParameter("@Cod_Isl", SqlDbType.Int);
            parameters[3] = new SqlParameter("@Num_Tur", SqlDbType.Int);

            parameters[0].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[1].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[2].Value = int.Parse(txtIsla.Text);
            parameters[3].Value = int.Parse(txtTurno.Text);


            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "RptRDFormasPago", parameters);

            return reader.Tables[0];
        }



        /// <summary>
        /// Gets or sets the grid view sort direction.
        /// </summary>
        /// <value>
        /// The grid view sort direction.
        /// </value>
        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                {
                    ViewState["SortDirection"] = SortDirection.Descending;
                }
                else if ((SortDirection)ViewState["SortDirection"] == SortDirection.Descending)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }

                return (SortDirection)ViewState["SortDirection"];
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }



        private void MostrarDatos()
        {
            // lblFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
            DataTable datos;
            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;
            datos = GetDataVentas();
            grdDetalleVentas.DataSource = datos;
            grdDetalleVentas.DataBind();

        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (decimal.Parse(txtValorNeto.Text) == 0)
            {
                Response.Write("<script>alert('Error: No se puede adicionar venta con valores de venta en ceros')</script>");
                return;
            } 

            if (Session["AdicionarVenta"] == "0")
            { 
                ActualizarVenta();
                CargueDatos();
            }
            else
            {
                AdiconarVentaBasico();
                CargueDatos();
            }
            //this.ModalPopupExtender1.Show();
        }

        /// <summary>
        ///  carga las ventas de turno
        /// </summary>
        private void CargarVentasTurno()
        {
            DataTable datosVentas = GetDataVentas();
            grdDetalleVentas.DataSource = datosVentas;
            grdDetalleVentas.DataBind();
        }


        protected void btnUpdateLectura_Click(object sender, EventArgs e)
        {
            ActualizarLectura();
            CargueDatos();
        }

        protected void btnUpdateCanastilla_Click(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(txtCantidadCanastilla.Text) * decimal.Parse(txtPrecioCanastila.Text);
            if (total > 0)
            {
                ActualizarCanastilla();
                CargueDatos();
            }
            else
            {
                Response.Write("<script>alert('Error: No se pueden actualizar total de Canastilla en ceros" + "')</script>");

            }

        }

        protected void btnUpdateBolsa_Click(object sender, EventArgs e)
        {
           
            try{

                decimal total = decimal.Parse(txtMonedaBolsa.Text) + decimal.Parse(txtBilleteBolsa.Text);
                if (total > 0)
                {
                    ActualizarBolsa();
                    CargueDatos();
                }
                else
                {
                    Response.Write("<script>alert('Error: No se pueden adicionar valores de Bolsa de Turno en ceros"  + "')</script>");

                } 
            }
            catch
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //this.ModalPopupExtender1.Show();

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {

            lblFechaInicial.Text = DateTime.Parse(lblFechaInicial.Text).ToString("dd-MM-yyyy");
            DataTable datosVentas;
            DataTable datosLecturas;
            DataTable datosCanastilla;
            DataTable datosBolsas;
            DataTable datosResumenArticulo;
            DataTable datosResumenFormasPago;
            DataTable datosDescuadre;

            _TotalCantidad = 0;
            _TotalSubtotal = 0;
            _TotalDescuento = 0;
            _Total = 0;

            datosVentas = GetDataVentas();
            grdDetalleVentas.DataSource = datosVentas;
            grdDetalleVentas.DataBind();

            datosLecturas = GetDataLecturas();
            GridLecturas.DataSource = datosLecturas;
            GridLecturas.DataBind();


            datosCanastilla = GetDataCanastilla();
            grdCanastilla.DataSource = datosCanastilla;
            grdCanastilla.DataBind();

            datosBolsas = GetDataBolsa();
            grdBolsasTurno.DataSource = datosBolsas;
            grdBolsasTurno.DataBind();

            datosResumenArticulo = GetDataResumenArticulos();
            grdArticulos.DataSource = datosResumenArticulo;
            grdArticulos.DataBind();



            datosResumenFormasPago = GetDataResumenFormasPago();
            grdFormasPago.DataSource = datosResumenFormasPago;
            grdFormasPago.DataBind();


            datosDescuadre = GetDataDescuadre();
            grdDescuadre.DataSource = datosDescuadre;
            grdDescuadre.DataBind();
            //this.ModalPopupExtender1.Show();


        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Session["AdicionarVenta"] = "0";

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            lblConsecutivo.Text = grdDetalleVentas.DataKeys[gvrow.RowIndex].Value.ToString();

            ddlCaraVenta.SelectedValue = gvrow.Cells[2].Text;
            txtCodigoCliente.Text = gvrow.Cells[4].Text.TrimEnd().Replace("&nbsp;", "");

            txtNombreCliente.Text = BuscarNombreCliente(txtCodigoCliente.Text);
            txtPlaca.Text = gvrow.Cells[5].Text.TrimEnd().Replace("&nbsp;", ""); ;
            ddlFormasPagoVenta.SelectedValue = gvrow.Cells[18].Text;
            ddlArticuloVenta.SelectedValue = gvrow.Cells[17].Text;
           
            txtPrecio.Text = decimal.Parse(gvrow.Cells[8].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtCantidad.Text = decimal.Parse(gvrow.Cells[9].Text, System.Globalization.NumberStyles.Number).ToString();
            txtValorNeto.Text = decimal.Parse(gvrow.Cells[10].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtDescuento.Text = decimal.Parse(gvrow.Cells[11].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtTotal.Text = decimal.Parse(gvrow.Cells[12].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtKilometraje.Text = (long.Parse(gvrow.Cells[13].Text.Replace(",", "").Replace(".", "") )/100).ToString();
            txtManifiesto.Text = gvrow.Cells[14].Text.Replace("&nbsp;", "");
            ModalPopupExtender2.Show();
           
        }

        protected void imgbtnLecturas_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtMangueraLec.Text = GridLecturas.DataKeys[gvrow.RowIndex].Value.ToString();
            txtArticulolec.Text = gvrow.Cells[8].Text;
            txtLecturaInicialLec.Text = decimal.Parse(gvrow.Cells[2].Text, System.Globalization.NumberStyles.Number).ToString();
            txtLecturaFinallec.Text = decimal.Parse(gvrow.Cells[3].Text, System.Globalization.NumberStyles.Number).ToString();
            this.ModalPopupExtenderLects.Show();
        }


        protected void imgbtnCanastilla_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtPrefijoCanastilla.Text = gvrow.Cells[0].Text;
            lblConsecutivoCanastilla.Text = gvrow.Cells[1].Text;
            txtPrecioCanastila.Text = decimal.Parse(gvrow.Cells[4].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtCod_artCanastilla.Text = gvrow.Cells[2].Text;
            txtCantidadCanastilla.Text = decimal.Parse(gvrow.Cells[6].Text, System.Globalization.NumberStyles.Number).ToString();
            lblArticuloHideCanastilla.Text = txtCod_artCanastilla.Text;
            this.MpeCanastilla.Show();

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FiltroPlanillaTurno.aspx");
        }

        protected void imgbtnBolsa_Click(object sender, ImageClickEventArgs e)
        {
            Session["adicionarBolsa"] = "0";
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtConsecutivoBolsa.Text = grdBolsasTurno.DataKeys[gvrow.RowIndex].Value.ToString();
            txtMonedaBolsa.Text = decimal.Parse(gvrow.Cells[1].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtBilleteBolsa.Text = decimal.Parse(gvrow.Cells[2].Text, System.Globalization.NumberStyles.Currency).ToString();
            this.mdlBolsaTurno.Show();
        }


        private void ActualizarVenta()
        {

            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();

            string sql = "Update Ventas ";
            sql += "Set cod_car = '" + ddlCaraVenta.Text + "'";
            sql += ", placa = '" + txtPlaca.Text + "'";
            sql += ", cod_cli = '" + txtCodigoCliente.Text + "'";
            sql += ", cantidad = '" + txtCantidad.Text.Replace(",", ".") + "'";
            sql += ", precio_uni = '" + txtPrecio.Text.Replace(",", ".") + "'";
            sql += ", Subtotal = '" + txtValorNeto.Text.Replace(",", ".") + "'";
            sql += ", Total = '" + txtTotal.Text.Replace(",", ".") + "'";
            sql += ", descuento = '" + txtDescuento.Text.Replace(",", ".") + "'";
            sql += ", cod_art = '" + ddlArticuloVenta.SelectedValue.Replace(",", ".") + "'";
            sql += ", cod_for_pag = '" + ddlFormasPagoVenta.SelectedValue.Replace(",", ".") + "'";
            sql += ", kil_act = '" + txtKilometraje.Text.Replace(",", ".") + "'";
            sql += ", IdentificadorManifiesto = '" + txtManifiesto.Text + "'";
            sql += " Where Consecutivo = " + lblConsecutivo.Text;
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

            InsertarLogPlanilla("actualizada venta consecutivo:" + lblConsecutivo.Text + " Isla: " + txtIsla.Text + " Turno:" + txtTurno.Text);

        }

        private void ActualizarLectura()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();

            string sql = "Update TURN_LEC ";
            sql += "Set lect_ini1 = '" + txtLecturaInicialLec.Text.Replace(",", ".") + "'";
            sql += ", lect_fin1 = '" + txtLecturaFinallec.Text.Replace(",", ".") + "'";
            sql += ", diferencia = '" + (decimal.Parse(txtLecturaFinallec.Text) - decimal.Parse(txtLecturaInicialLec.Text)).ToString().Replace(",", ".") + "'";
            sql += ", VR_DIFERENCIA = " + (decimal.Parse(txtLecturaFinallec.Text) - decimal.Parse(txtLecturaInicialLec.Text)).ToString().Replace(",", ".") + " * PRECIO ";
            sql += " Where COD_MAN = " + txtMangueraLec.Text + " AND dbo.finteger(fecha) = '" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") + "' And Cod_Isl = " + txtIsla.Text + " And NUM_TUR =" + txtTurno.Text;
            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

            InsertarLogPlanilla("actualizada Lectura Manguera:" + txtMangueraLec.Text + " Isla:" + txtIsla + " Turno:" +  txtTurno.Text);
        }

        private void ActualizarCanastilla()
        {

            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();

            Servipunto.Estacion.Libreria.Configuracion.Articulo art = Servipunto.Estacion.Libreria.Configuracion.Articulos.ObtenerItem(short.Parse(txtCod_artCanastilla.Text));

            if (art != null)
            {
                decimal vlr_sub = art.Precio * decimal.Parse(txtCantidadCanastilla.Text);
                decimal vlr_iva = vlr_sub * art.Iva / 100;
                decimal vlr_total = vlr_iva + vlr_sub;

                try
                {
                    string sql = "Update VENTACANASTILLAITEMS ";
                    sql += "Set Cod_art = '" + txtCod_artCanastilla.Text.Replace(",", ".") + "'";
                    sql += ", Cantidad=" + txtCantidadCanastilla.Text.Replace(",", ".") + "";
                    sql += ", Precio_uni = '" + txtPrecioCanastila.Text.Replace(",", ".") + "'";
                    sql += ", Subtotal = " + vlr_sub.ToString().Replace(",", ".");
                    sql += ", vr_iva = " + vlr_iva.ToString().Replace(",", ".");
                    sql += ", Total = " + vlr_total.ToString().Replace(",", ".");
                    sql += " Where consecutivo = " + lblConsecutivoCanastilla.Text + " AND Prefijo = '" + txtPrefijoCanastilla.Text + "'"
                             + " And Cod_art = '" + lblArticuloHideCanastilla.Text + "'";
                    reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);


                    sql = "UPDATE VENTACANASTILLA   SET SUBTOTAL = (select sum(subtotal) FROM VENTACANASTILLAITEMS where PREFIJO = '" + txtPrefijoCanastilla.Text + "' AND CONSECUTIVO = " + lblConsecutivoCanastilla.Text + ")";
                    sql += ", TOTAl = (select sum(total) FROM VENTACANASTILLAITEMS where PREFIJO = '" + txtPrefijoCanastilla.Text + "' AND CONSECUTIVO = " + lblConsecutivoCanastilla.Text + ")";
                    sql += ", TOTAliva = (select sum(vr_iva) FROM VENTACANASTILLAITEMS where PREFIJO = '" + txtPrefijoCanastilla.Text + "' AND CONSECUTIVO = " + lblConsecutivoCanastilla.Text + ")";
                    reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

                    InsertarLogPlanilla("actualizada valores canastilla  prefijo-Consecutivo:" + txtPrefijoCanastilla.Text + "-" + lblConsecutivoCanastilla.Text + " Isla: " + txtIsla.Text + " Turno:" + txtTurno.Text);
                }
                catch
                {
                }
            }
        }

        private void ActualizarBolsa()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            decimal vlr_tot = decimal.Parse(txtMonedaBolsa.Text) + decimal.Parse(txtBilleteBolsa.Text);

            if (Session["adicionarBolsa"] == "0")
            {
                string sql = "Update BOLS_TUR ";
                sql += "Set vr_billete = " + txtBilleteBolsa.Text.Replace(",", ".");
                sql += ", Vr_Moneda =" + txtMonedaBolsa.Text.Replace(",", ".") + "";
                sql += ", Vr_Total = " + vlr_tot.ToString().Replace(",", ".");
                sql += " Where consecutivo = " + txtConsecutivoBolsa.Text + " And Cod_Isl = " + txtIsla.Text + " And Num_Tur = " + txtTurno.Text + " AND dbo.finteger(fecha) = '" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") + "'";
                reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

                InsertarLogPlanilla("actualizada valores bolsa  consecutivo:" + txtConsecutivoBolsa.Text + "-" + lblConsecutivoCanastilla.Text  +" Isla:" + txtIsla + " Turno:" + txtTurno.Text);



            }

            else
            {
                Servipunto.Estacion.Libreria.Turnos.BolsasTurno objBolsas = new Libreria.Turnos.BolsasTurno();

                if (!objBolsas.ExisteConsecutivo(DateTime.Parse(lblFechaInicial.Text), int.Parse(txtIsla.Text), int.Parse(txtTurno.Text), short.Parse(txtConsecutivoBolsa.Text)))
                {
                    objBolsas.AdicionarBolsa(DateTime.Parse(lblFechaInicial.Text), int.Parse(txtIsla.Text), int.Parse(txtTurno.Text), int.Parse(txtCodigoEmpleado.Text), short.Parse(txtConsecutivoBolsa.Text), decimal.Parse(txtMonedaBolsa.Text), decimal.Parse(txtBilleteBolsa.Text), vlr_tot);
                }

            }
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("FiltroPlantillaTurno.aspx");

        }

        protected void EliminarVenta(int consecutivo)
        {

            DataSet reader = new DataSet();
            string sql = "delete ventas ";
            sql += " Where consecutivo = " + consecutivo.ToString();


            try
            {
                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            }
            catch
            {
            }

            InsertarLogPlanilla("eliminada venta consecutivo:" + consecutivo.ToString() + " Isla: " + txtIsla.Text + " Turno:" + txtTurno.Text);

            CargarVentasTurno();

        }

        protected void imgEliminarLecturaTurno_Click(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtMangueraLec.Text = GridLecturas.DataKeys[gvrow.RowIndex].Value.ToString();

            DataSet reader = new DataSet();
            string sql = "delete turn_lec ";
            sql += " Where COD_MAN = " + txtMangueraLec.Text + " AND dbo.finteger(fecha) = '" + lblFechaInicial.Text + "' And Cod_Isl = " + lblIsla.Text + " And NUM_TUR =" + lblTurno.Text;

            try
            {
                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            }
            catch
            {
            }
            CargueDatosLecturas();
        }

        protected void EliminarBolsa(int consecutivo)
        {

            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            string sql = "delete BOLS_TUR ";
            sql += " Where consecutivo = " + consecutivo.ToString() + " And Cod_Isl = " + txtIsla.Text + " And Num_Tur = " + txtTurno.Text + " And dbo.finteger(fecha) = '" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") +"'";
            try
            {
                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            }
            catch
            {
            }

            InsertarLogPlanilla("eliminada bolsa de turno consecutivo:" + consecutivo.ToString() + " Isla: " + txtIsla.Text + " Turno:" + txtTurno.Text);

            CargarDatosBolsas();
        }

        protected void imgEliminarVentaCanastilla_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();
            string sql = "delete ventacanastillaitems ";
            sql += " Where consecutivo = " + lblConsecutivoCanastilla.Text + " AND Prefijo = '" + txtPrefijoCanastilla.Text + "'"
                  + " And Cod_art = '" + lblArticuloHideCanastilla.Text + "'";
            try
            {
                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            }
            catch
            {
            }
            CargarDatosCanastilla();
        }

        protected void grdDetalleVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int nfila = int.Parse(e.CommandArgument.ToString());
                    int consecutivo = int.Parse(grdDetalleVentas.Rows[nfila].Cells[0].Text);
                    EliminarVenta(consecutivo);
                }
                catch
                {
                }


            }

        }

        protected void grdArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    _TotalArticulosCantidad += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Volumen"));
                    _TotalArticulosSubtotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));


                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {


                    e.Row.Cells[1].Text = "Totales:";

                    e.Row.Cells[2].Text = _TotalArticulosCantidad.ToString("n3");
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[3].Text = _TotalArticulosSubtotal.ToString("c3");
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;


                    e.Row.Font.Bold = true;

                }
            }
            catch
            {

            }
        }

        protected void grdFormasPago_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    _TotalFormaPago += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorFormaPago"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {


                    e.Row.Cells[1].Text = "Totales:";

                    e.Row.Cells[2].Text = _TotalFormaPago.ToString("c3");
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;



                    e.Row.Font.Bold = true;

                }
            }
            catch
            {

            }

        }

        protected void grdCanastilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    _TotalCantidadCanastilla += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                    _TotalSubtotalCanastilla += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Subtotal"));
                    _TotalTotalIvaCanastilla += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "vr_iva"));
                    _TotalTotalCanastilla += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {


                    e.Row.Cells[5].Text = "Totales:";

                    e.Row.Cells[6].Text = _TotalCantidadCanastilla.ToString("n3");
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[7].Text = _TotalSubtotalCanastilla.ToString("c3");
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[8].Text = _TotalTotalIvaCanastilla.ToString("c3");
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[9].Text = _TotalTotalCanastilla.ToString("c3");
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;


                    e.Row.Font.Bold = true;

                }
            }
            catch
            {

            }
        }

        protected void grdBolsasTurno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    _TotalBilletesConsignaciones += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Vr_billete"));
                    _TotalMonedaConsignaciones += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Vr_moneda"));
                    _TotalTotalConsignaciones += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Vr_total"));

                }

                else if (e.Row.RowType == DataControlRowType.Footer)
                {


                    e.Row.Cells[0].Text = "Totales:";

                    e.Row.Cells[1].Text = _TotalMonedaConsignaciones.ToString("c3");
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[2].Text = _TotalBilletesConsignaciones.ToString("c3");
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[3].Text = _TotalTotalConsignaciones.ToString("c3");
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;


                    e.Row.Font.Bold = true;

                }
            }
            catch
            {

            }

        }

        private void SumarIngresos()
        {
            txtTotalIngresos.Text = (_TotalValorLects + _TotalTotalCanastilla).ToString("c");

        }


        protected void imgAdiconarBolsa_Click(object sender, ImageClickEventArgs e)
        {
            Session["adicionarBolsa"] = "1";
            txtConsecutivoBolsa.Text = "0";
            txtMonedaBolsa.Text = "0";
            txtBilleteBolsa.Text = "0";
            this.mdlBolsaTurno.Show();

        }

        protected void grdBolsasTurno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int nfila = int.Parse(e.CommandArgument.ToString());
                    int consecutivo = int.Parse(grdBolsasTurno.Rows[nfila].Cells[0].Text);
                    EliminarBolsa(consecutivo);
                }
                catch
                {
                }
            }
        }

        protected void imgAdicionVenta_Click(object sender, ImageClickEventArgs e)
        {

            Session["AdicionarVenta"] = "1";

            lblConsecutivo.Text = "";

            ddlCaraVenta.SelectedIndex =0;
            txtCodigoCliente.Text = string.Empty;
            txtPlaca.Text = string.Empty;

            //txtFormaPago.Text = string.Empty;
            //txtCodArticulo.Text = string.Empty;

            ddlArticuloVenta.SelectedIndex = 0;
            ddlFormasPagoVenta.SelectedIndex = 3;
            txtPrecio.Text = "0";
            txtCantidad.Text = "0";
            txtValorNeto.Text = "0";
            txtDescuento.Text = "0";
            txtTotal.Text = "0";
            txtKilometraje.Text = "0";
            txtManifiesto.Text = "0";
            txtCodigoCliente.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            txtKilometraje.Text = "0";
            txtManifiesto.Text = string.Empty;

             try
            {
                ddlArticuloVenta.SelectedIndex = 0;
                if (int.Parse(ddlArticuloVenta.SelectedValue) > 0)
                {
                    Libreria.Configuracion.Articulo art = Libreria.Configuracion.Articulos.ObtenerItem(short.Parse(ddlArticuloVenta.SelectedValue));
                    txtPrecio.Text = art.Precio.ToString();


                }
            }
            catch
            {
            }
           
            this.ModalPopupExtender2.Show();
        }

        private void CargarArticulosVenta()
        {
            if (ddlArticuloVenta.Items.Count == 0)
            {
                Servipunto.Estacion.Libreria.Articulos arts = new Libreria.Articulos(Libreria.TipoArticulo.Combustible);
                ddlArticuloVenta.DataSource = arts;
                ddlArticuloVenta.DataTextField = "Descripcion";
                ddlArticuloVenta.DataValueField = "IdArticulo";
                ddlArticuloVenta.DataBind();
            }
        }

        private void CargarFormasPago()
        {
            if (ddlFormasPagoVenta.Items.Count == 0)
            {
                Servipunto.Estacion.Libreria.FormasPago formasPago = new Libreria.FormasPago();
                ddlFormasPagoVenta.DataSource = formasPago;
                ddlFormasPagoVenta.DataTextField = "Nombre";
                ddlFormasPagoVenta.DataValueField = "IdFormaPago";
                ddlFormasPagoVenta.DataBind();
            }
        }


        private void CargarCaraVenta()
        {
            if (ddlCaraVenta.Items.Count == 0)
            {

                DataTable tablaCaras = GetCarasIsla();
                ddlCaraVenta.DataSource = tablaCaras;
                ddlCaraVenta.DataTextField = "Cod_car";
                ddlCaraVenta.DataValueField = "Cod_car";
                ddlCaraVenta.DataBind();
            }
        }

        private DataTable GetCarasIsla()
        {
            SqlParameter[] parameters = new SqlParameter[4];
            DataSet reader = new DataSet();

            string sql = "select cod_car, cod_car from caras  where cod_isl = " + txtIsla.Text ;
            

            reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql, parameters);


            return reader.Tables[0];
        }

        private string BuscarNombreCliente(string codigoCliente)
        {
            Servipunto.Estacion.Libreria.Comercial.Clientes clientes = new Libreria.Comercial.Clientes();
            Servipunto.Estacion.Libreria.Comercial.Cliente  cte = clientes[codigoCliente.TrimEnd()];
            
            if (cte != null)
            {


                return cte.NombreCliente;
               
            }

            return string.Empty;
        }

        private void AdiconarVentaBasico()
        {
            SqlParameter[] parameters = new SqlParameter[14];
            parameters[0] = new SqlParameter("@CodigoFormaPago", SqlDbType.SmallInt);
            parameters[1] = new SqlParameter("@CodigoArticulo", SqlDbType.SmallInt);
            parameters[2] = new SqlParameter("@CodigoCara", SqlDbType.SmallInt);
            parameters[3] = new SqlParameter("@Placa", SqlDbType.VarChar);
            parameters[4] = new SqlParameter("@Total", SqlDbType.Decimal);
            parameters[5] = new SqlParameter("@CodigoEmpleado", SqlDbType.VarChar);
            parameters[6] = new SqlParameter("@FechaFecha", SqlDbType.DateTime);
            parameters[7] = new SqlParameter("@FechaRealFecha", SqlDbType.DateTime);
            parameters[8] = new SqlParameter("@NumeroTurno", SqlDbType.SmallInt);
            parameters[9] = new SqlParameter("@CodigoCliente", SqlDbType.VarChar);
            parameters[10] = new SqlParameter("@KilometrajeActual", SqlDbType.Decimal);
            parameters[11] = new SqlParameter("@ValorNeto", SqlDbType.Decimal);
            parameters[12] = new SqlParameter("@Cantidad", SqlDbType.Decimal);
            parameters[13] = new SqlParameter("@Descuento", SqlDbType.Decimal);

            parameters[0].Value = short.Parse(ddlFormasPagoVenta.SelectedValue);
            parameters[1].Value = short.Parse(ddlArticuloVenta.SelectedValue);
            parameters[2].Value = short.Parse(ddlCaraVenta.SelectedValue);
            parameters[3].Value = txtPlaca.Text;
            parameters[4].Value = decimal.Parse(txtTotal.Text);
            parameters[5].Value = (txtCodigoEmpleado.Text);
            parameters[6].Value = DateTime.Parse(lblFechaInicial.Text);
            parameters[7].Value = DateTime.Today;
            parameters[8].Value = short.Parse(txtTurno.Text);
            parameters[9].Value = (txtCodigoCliente.Text);
            parameters[10].Value = decimal.Parse(txtKilometraje.Text);
            parameters[11].Value = decimal.Parse(txtValorNeto.Text);
            parameters[12].Value = decimal.Parse(txtCantidad.Text);
            parameters[13].Value = decimal.Parse(txtDescuento.Text);

            try
            {

                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, "InsertarVentaBasico", parameters);
            }

            catch(Exception ex)
            {
                

            }

        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            txtValorNeto.Text = decimal.Round((decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text)),3).ToString();
            txtTotal.Text = decimal.Round((decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text)- decimal.Parse(txtDescuento.Text)),3).ToString();
            ModalPopupExtender2.Show();
        }

        private bool ValidarIntegridadDatosVenta()
        {

            try
            {
                decimal totalventacalculado = decimal.Parse(txtPrecio.Text) * decimal.Parse(txtCantidad.Text);
                decimal valorneto = decimal.Parse(txtValorNeto.Text);

                decimal totalCalculado =  valorneto - decimal.Parse(txtDescuento.Text) ;
                decimal total = decimal.Parse(txtTotal.Text);

                if (Math.Abs(total - totalventacalculado) > 100)
                {
                    return false;
                }

                if (Math.Abs(total - totalCalculado) > 100)
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
            return true;
        }

        protected void btnConfirmacion_Click(object sender, EventArgs e)
        {

            if (txtNombreConfirmacion.Text == string.Empty)
            {

                Response.Write("<script>alert('Ingrese por favor el Nombre de quien aprueba el turno ')</script>");
                return;
            }


            string sql = "INSERT INTO APROBACIONTURNO VALUES("
                + "'" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") + "'"
                + ",'" + txtIsla.Text + "'"
                + ",'" + txtTurno.Text + "'"
                + ",'" + DateTime.Now.ToString() + "'"
                + ",'" + txtNombreConfirmacion.Text + "'"
                + ")";

            try
            {

                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

                mdlAprobarCierre.Show();
            }

            catch(Exception ex)
            {


            }
                    
        }

        protected void btnTurnoAprobado_Click(object sender, EventArgs e)
        {
            chkTurnoVerificado.Checked = true;
            txtFechaConfirmacion.ReadOnly = true;
            txtNombreConfirmacion.ReadOnly = true;
            chkTurnoVerificado.Enabled = false;
            btnConfirmacion.Enabled = false;
            grdDetalleVentas.Enabled = false;
            grdCanastilla.Enabled = false;
            grdBolsasTurno.Enabled = false;
            GridLecturas.Enabled = false;
            imgAdicionVenta.Enabled = false;
            imgAdiconarBolsa.Enabled = false;

            CargarDatosAprobacion();
        }

        protected bool CargarDatosAprobacion()
        {
            bool retorno = false;
            DataSet reader = new DataSet();
            string sql = "SELECT fecha,isla,turno,fechaAprobacion,nombreaprobo FROM  APROBACIONTURNO  WHERE "
                + "FECHA ='" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") + "'"
                + " AND ISLA ='" + txtIsla.Text + "'"
                + " AND TURNO ='" + txtTurno.Text + "'";
                
            try
            {

                reader = SqlHelper.ExecuteDataset(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('Error: cargando aprobacion turno:" + ex.Message + "')</script>");
                return false;

            }
            

            if (reader.Tables.Count <= 0)
            {
                Response.Write("<script>alert('No se encuentra tabla aprobacion')</script>");
                return false;

            }

            if (reader.Tables[0].Rows.Count > 0)
            {
                chkTurnoVerificado.Checked = true;
                txtFechaConfirmacion.Text = reader.Tables[0].Rows[0].ItemArray[3].ToString();
                txtNombreConfirmacion.Text = reader.Tables[0].Rows[0].ItemArray[4].ToString();
                txtFechaConfirmacion.ReadOnly = true;
                txtNombreConfirmacion.ReadOnly = true;
                chkTurnoVerificado.Enabled = false;
                btnConfirmacion.Enabled = false;
                retorno = true;
                grdDetalleVentas.Enabled = false;
                grdCanastilla.Enabled = false;
                grdBolsasTurno.Enabled = false;
                GridLecturas.Enabled = false;
                imgAdicionVenta.Enabled = false;
                imgAdiconarBolsa.Enabled = false;
            }
            else
            {
                txtFechaConfirmacion.ReadOnly = true;
                
            }

            reader = null;           
            return retorno;



        }


        protected void ArticuloVenta_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                 Libreria.Configuracion.Articulo art = Libreria.Configuracion.Articulos.ObtenerItem(short.Parse(ddlArticuloVenta.SelectedValue));
                 txtPrecio.Text = art.Precio.ToString();
                 decimal cant = decimal.Parse(txtValorNeto.Text) / decimal.Parse(txtPrecio.Text);
                 txtCantidad.Text = decimal.Round(cant, 3).ToString();
                 txtValorNeto.Text = (decimal.Round(cant * decimal.Parse(txtPrecio.Text), 3)).ToString();
                 txtTotal.Text = (decimal.Round(cant * decimal.Parse(txtPrecio.Text), 3) - decimal.Parse(txtDescuento.Text)).ToString();
                 ModalPopupExtender2.Show();
            }

            catch
            {
            }
        }

        protected void txtValorNeto_TextChanged(object sender, EventArgs e)
        {

            try
            {
                decimal cant = decimal.Parse(txtValorNeto.Text)/ decimal.Parse(txtPrecio.Text);
                txtCantidad.Text = decimal.Round(cant, 3).ToString();

                txtTotal.Text = decimal.Round( (decimal.Parse(txtValorNeto.Text) - decimal.Parse(txtDescuento.Text)),3).ToString();
                ModalPopupExtender2.Show();
            }

            catch
            {
            }
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {

            try
            {
                txtValorNeto.Text = decimal.Round ((decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text)),3).ToString();
                decimal cant = decimal.Parse(txtCantidad.Text);
                txtCantidad.Text = decimal.Round(cant, 3).ToString();               
                txtTotal.Text = decimal.Round( (decimal.Round(cant * decimal.Parse(txtPrecio.Text),3) - decimal.Parse(txtDescuento.Text)),3).ToString();
                ModalPopupExtender2.Show();
            }

            catch
            {
            }
        }

        protected void txtDescuento_TextChanged(object sender, EventArgs e)
        {

            try
            {              
              
                txtTotal.Text = (decimal.Parse(txtValorNeto.Text) - decimal.Parse(txtDescuento.Text)).ToString();
                ModalPopupExtender2.Show();
            }

            catch
            {
            }
        }


        private void InsertarLogPlanilla(string mensaje)
        {

            Libreria.Usuario usu = (Libreria.Usuario)Session["Usuario"];

            string sql = "INSERT INTO LogPlanillaDia  VALUES("
                + "'" + DateTime.Parse(lblFechaInicial.Text).ToString("yyyyMMdd") + "'"
                + ",'" + txtIsla.Text + "'"
                + ",'" + txtTurno.Text + "'"
                + ",'" + DateTime.Now.ToShortTimeString().ToString() + "'"
                + ",'" + usu.Nombre + "'"
                + ",'" + mensaje + "'"
                + ")";

            try
            {

                SqlHelper.ExecuteNonQuery(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString, CommandType.Text, sql);

              
            }

            catch (Exception ex)
            {


            }
        }


    }
}

       