using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Filtro Imprimir tiquete de venta por consecutivo
	/// </summary>
	public class FiltroTiqueteVenta : System.Web.UI.Page
	{
		#region constantes
		private const int LINEWITH  = 33;
		private const string NEWLINE = "\r\n";
		private const string LINE =				"--------------------------------------\r\n";  
		private const string LINEASTERISCO =	"**************************************\r\n";
		#endregion  

		public enum TipoAlineacion {Centrado, Izquierda, Derecha}
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.DropDownList ddlImpresoras;
		protected System.Web.UI.WebControls.TextBox txtRutaArchivo;
		protected System.Web.UI.WebControls.TextBox txtImpresora;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.WebControls.TextBox txtConsecutivos;
        protected System.Web.UI.WebControls.Label Label2;        
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            ViewState["Control"] = "0";
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
        }
        #endregion
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                //if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();
            }
            else
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    this.VerificarPermisos();
                    this.InicializarForma();
                }
            }
        }
        #endregion
		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(143, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(145, Global.Idioma);
            
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
            ViewState["Control"] = "1";
            #endregion            
			CargarImpresoras();
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Reportes Generales";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Tiquete Venta");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			return true;
		}
		#endregion

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{  		
			this.Load += new System.EventHandler(this.Page_Load);

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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

		#region EjecutarReporte
		private void EjecutarReporte()
		{
			if (this.Validar())
			{
				try
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,354, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(this.txtConsecutivos.Text == "")
						this.txtConsecutivos.Text = "0";

					ImprimirTiqueteVenta();
				}
				catch (Exception ex)
				{
                    this.SetError(ex.Message, false);
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
		}
		#endregion
		
		#region Validar
		private bool Validar()
		{			
			try
			{
				int.Parse(this.txtConsecutivos.Text);	
			}
			catch(Exception)
			{
				this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1971, Global.Idioma),false);
				return false;
			}

			return true;
		}
		#endregion


		#region Cargar Impresoras
		/// <summary>
		/// Carga las impresoras a la lista de impresoras configuradas
		/// </summary>
		/// Fecha: 04/02/2009
		/// Autor: Rodrigo Figueroa Rivera		
		private void CargarImpresoras()
		{		

			Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection Printers = 
				new Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection();

			foreach(string printername in Printers.PrintersNames())
				this.ddlImpresoras.Items.Add(new ListItem(printername, printername));

			Printers = null;
		}
		#endregion

		#region Generar Arhivo de Impresion
		/// <summary>
		/// Genera el archivo de impresion
		/// </summary>
		/// <param name="consecutivo"></param>
		/// <returns></returns>
		private string GenerarContenidoImpresion(int consecutivo)
		{		
			string report = "";
			try
			{
				bool result = false;
				string tituloCopia ;				
				try
				{
					
					Servipunto.Estacion.Libreria.Configuracion.Datos_Gene datosGenerales = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();					
					Servipunto.Estacion.Libreria.Configuracion.Dat_Gene  datosGeneral = datosGenerales[0];

					Servipunto.Estacion.Libreria.Configuracion.Estaciones  estaciones = new Servipunto.Estacion.Libreria.Configuracion.Estaciones();					
					Servipunto.Estacion.Libreria.Configuracion.Estacion estacion = estaciones[0];

					estaciones = null;
					string titulo = Libreria.Configuracion.PalabrasIdioma.Traduccion(27, Global.Idioma); //R.F. JUL 26/05 					
					
					Servipunto.Estacion.Libreria.Ventas ventas = new Servipunto.Estacion.Libreria.Ventas(consecutivo, null, null, null);
					
					if (ventas.Count == 0)
					{
						SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2328, Global.Idioma),false);
						return "";
					}
					Servipunto.Estacion.Libreria.Venta venta = ventas[0];
					Servipunto.Estacion.Libreria.Configuracion.Islas islas = new Servipunto.Estacion.Libreria.Configuracion.Islas();					
					Servipunto.Estacion.Libreria.Configuracion.Isla isla = islas[venta.CodigoIsla.ToString()];				

					if (venta.TiqueteImpreso != 0)
						tituloCopia = AlinearLinea(Libreria.Configuracion.PalabrasIdioma.Traduccion(2329, Global.Idioma), LINEWITH, TipoAlineacion.Centrado);
					else					
						tituloCopia = AlinearLinea(Libreria.Configuracion.PalabrasIdioma.Traduccion(2330, Global.Idioma), LINEWITH, TipoAlineacion.Centrado);
					
		
					
					/*ENCABEZADO*/
					report += AlinearLinea(datosGeneral.RazonSocial,LINEWITH,TipoAlineacion.Centrado) ;
					report += AlinearLinea("NIT: "+ datosGeneral.Nit.TrimEnd() + datosGeneral.NitDive.ToString().TrimEnd() ,LINEWITH,TipoAlineacion.Centrado) ;
					report += AlinearLinea(estacion.Nombre,LINEWITH,TipoAlineacion.Centrado) ;

//					if (reimpresion)
//					{
//						//report += AlinearLinea(titulo,LINEWITH,TipoAlineacion.Centrado) ;
						report += AlinearLinea(tituloCopia,LINEWITH,TipoAlineacion.Centrado) ;
//					}
//					else
//						report += AlinearLinea(titulo,LINEWITH,TipoAlineacion.Centrado) ;

					report += AlinearLinea(datosGeneral.Direccion,LINEWITH,TipoAlineacion.Centrado) ;				
					report += AlinearLinea(datosGeneral.Telefono,LINEWITH,TipoAlineacion.Centrado) ;				
					
					//DATOS
					report += LINE; 
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma)+"    : " +  venta.FechaReal.ToShortDateString() ;
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma)+"  : " +  venta.Hora.ToShortTimeString() + NEWLINE;
				
					report += "Nro.     : " + venta.PrefijoVenta.TrimEnd() + " " +  venta.Consecutivo.ToString().PadLeft(10,' ')  ;
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma)+"  : " + venta.Placa  +  NEWLINE ;		
				
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma)+"    : " +  venta.NumeroTurno.ToString().PadLeft(2,' ');
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma)+"         : " +  venta.CodigoIsla.ToString().PadLeft(2,' ') + NEWLINE;				
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(75, Global.Idioma)+" : " +  venta.CodigoSurtidor.ToString().PadLeft(2,' ') ;
                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1725, Global.Idioma) + "          : " + venta.CodigoCara.ToString().PadLeft(2, ' ') + NEWLINE;
					report += Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma)+" : " +  venta.CodigoManguera.ToString().PadLeft(2,' ')  + NEWLINE;
					if (venta.KilometrajeActual >0)
						report += Libreria.Configuracion.PalabrasIdioma.Traduccion(2207, Global.Idioma)+" : " + venta.KilometrajeActual.ToString()    +  NEWLINE ;		
					Servipunto.Estacion.Libreria.Configuracion.Empleado empleado = Libreria.Configuracion.Empleados.ObtenerItem(venta.CodigoEmpleado.ToString());
					report += LINE;
					//DETALLE
					Servipunto.Estacion.Libreria.Configuracion.Articulo articulo = Libreria.Configuracion.Articulos.ObtenerItem((short)venta.CodigoArticulo);
                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma) + ": " + articulo.Descripcion.TrimEnd() + NEWLINE;					
					report += articulo.UnidadMedida + ": "  + venta.Cantidad.ToString().PadRight(12,' ') ; 
			
					report += "  PVP  ( $): " + venta.PrecioUnitario.ToString("N",NumberFormatInfo.CurrentInfo).Trim().PadRight(9,' ')   +   NEWLINE;
					if ( venta.Preset > 0)
                        report += Libreria.Configuracion.PalabrasIdioma.Traduccion(483, Global.Idioma) + "  $: " + venta.Preset.ToString("N", NumberFormatInfo.CurrentInfo).Trim().PadRight(9, ' ') + NEWLINE;

                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(837, Global.Idioma) +" ( $) : " + AlinearLinea(venta.ValorNeto.ToString("N", NumberFormatInfo.CurrentInfo).Trim().PadRight(9, ' '), LINEWITH - 15, TipoAlineacion.Derecha);
                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(852, Global.Idioma) + "(" + venta.PorcDescuento.ToString().TrimEnd().PadRight(3, ' ') + "%) $: " + AlinearLinea(venta.Descuento.ToString("N", NumberFormatInfo.CurrentInfo).Trim().PadRight(9, ' '), LINEWITH - 15, TipoAlineacion.Derecha); 					
					report += "Subtotal   ( $) : "  + AlinearLinea(venta.SubTotal.ToString("N",NumberFormatInfo.CurrentInfo).Trim().PadRight(9,' '),LINEWITH-15,TipoAlineacion.Derecha )  ;
                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1637, Global.Idioma) + "( $) : " + AlinearLinea(venta.TotalCuota.ToString("N", NumberFormatInfo.CurrentInfo).Trim().PadRight(9, ' '), LINEWITH - 15, TipoAlineacion.Derecha); 
					report += "Total      ( $) : "  + AlinearLinea(venta.Total.ToString("N",NumberFormatInfo.CurrentInfo).Trim().PadRight(9,' '),LINEWITH-15,TipoAlineacion.Derecha )   ; 
				
					if ( venta.Preset > 0)
                        report += Libreria.Configuracion.PalabrasIdioma.Traduccion(2265, Global.Idioma) + "     $:" + (venta.Preset - venta.Total).ToString("N", NumberFormatInfo.CurrentInfo).Trim().PadRight(9, ' ') + NEWLINE;
			
					
					Servipunto.Estacion.Libreria.Configuracion.FormaPago formaPago =  Libreria.Configuracion.FormasPago.ObtenerItem((short)venta.CodigoFormaPago);



                    report += Libreria.Configuracion.PalabrasIdioma.Traduccion(155, Global.Idioma) + " : " + formaPago.Descripcion.TrimEnd() + NEWLINE;
										
					Servipunto.Estacion.Libreria.Comercial.Cliente cliente = Libreria.Comercial.Clientes.ObtenerItem(venta.CodigoCliente,1) ;
					if ( cliente != null)
                        report += Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma) + "   : " + cliente.NombreCliente.TrimEnd() + NEWLINE;							
					
					cliente = null ;					
 
				
					report += LINE;
			

					if (empleado != null)
                        report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1641, Global.Idioma) + ": " + empleado.NombreEmpleado.TrimEnd() + NEWLINE;
					else
                        report += Libreria.Configuracion.PalabrasIdioma.Traduccion(1641, Global.Idioma) + ": " + venta.CodigoEmpleado + NEWLINE;

					if (articulo.UnidadMedida.Trim().IndexOf("M3") >= 0)  // SOLO PARA GAS
					{
						report += NEWLINE + AlinearLinea(Libreria.Configuracion.PalabrasIdioma.Traduccion(1642, Global.Idioma),LINEWITH,TipoAlineacion.Centrado  ) ;  
						report += AlinearLinea(Libreria.Configuracion.PalabrasIdioma.Traduccion(2331, Global.Idioma)+":"+ venta.FechaMantenimiento.ToShortDateString(),LINEWITH,TipoAlineacion.Centrado  )  + NEWLINE ;
					}					
					
					report += NEWLINE ;				
				
					if (datosGeneral.Slogan != null && datosGeneral.Slogan.Trim() != "")  
						report +=  AlinearLinea(datosGeneral.Slogan.TrimEnd(),LINEWITH,TipoAlineacion.Centrado) ;			
				
					report += "\r\n.\r\n.\r\n.";
					if (venta.TiqueteImpreso == 0)
					{
							venta.TiqueteImpreso = 1;
							venta.Modificar();
					}
				}
				catch (Exception ex)
				{
					//HardLog.Write(GenericFunctions.AnalizarExcepcion(ex),HardLog.TypeLog.LogApp);
					result = false;
				}			
			}		
			
			catch 
			{
				return "";
			}			

			return report;
		}
		#endregion

		#region Generar Archivo plano para el servicio de impresion
		/// <summary>
		/// Genera el archivo plano
		/// </summary>
		/// <param name="contenido"></param>
		/// <returns></returns>
		private string GenerarArchivoImpresion(string contenido)
		{
			try
			{
				#region Verificar Directorio
				System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\servipunto\tiquetes");
				if ( !dir.Exists)				
					dir.Create();
				
				#endregion

				string fileName = @"c:\servipunto\tiquetes\" + this.ddlImpresoras.SelectedValue + "-ticket" + DateTime.Now.Ticks.ToString() + ".txt";
				//System.IO.StreamWriter objFile = new System.IO.StreamWriter(fileName, true, System.Text.Encoding.Unicode);
				System.IO.StreamWriter objFile = new System.IO.StreamWriter(fileName, true, System.Text.Encoding.Default);
				objFile.Write(contenido);				
				objFile.Close();
				return fileName;
			}
			catch (Exception ex)
			{
				return "";
			}			
		}
		#endregion

		#region Imprimir Tiquete de Venta
		/// <summary>
		/// Genera el contenido y el archivo plano de impresion
		/// 
		/// </summary>
		private void ImprimirTiqueteVenta()
		{
			try
			{
				string report = GenerarContenidoImpresion(Convert.ToInt32(this.txtConsecutivos.Text));
				string archivo = GenerarArchivoImpresion(report);			
				txtRutaArchivo.Text = archivo;					
			}
			catch
			{
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma),false);

			}
		}		
		#endregion
		/// <summary>
		/// Justifica (alinea el texto indicado en la longitud especificada)
		/// el resultado es una cadena de la longitud especificada.
		/// NOTA: Si la el valor de texto es mayor a la longitud especifiada este se 
		/// truncapà hasta la lngitud especificada. si el texto es menor este se rellena
		/// con espacios. Arega un fin de linea y  retorno de carro
		/// </summary>
		/// <param name="cadena">Cadena a alinear</param>
		/// <param name="longitud">Tamaño de la cadena en que se alineará</param>
		/// <param name="alineacion">Tipo de alineacion Cetrado, Derecha , Izquierda</param>
		/// <returns>cadena con la longitud especificada con un fin de linea y retorno de carro</returns>
		public  static string AlinearLinea(string cadena, int longitud,TipoAlineacion alineacion)
		{

			string result = new string((char)0x20,longitud) ;
			cadena = cadena.Trim();   
			if (cadena.Length >= longitud)   
				result = cadena.Substring(0,  longitud);
			else if (alineacion == TipoAlineacion.Derecha)
			{	
				int starIndex = longitud - cadena.Length; 
				result = result.Insert(starIndex,cadena);
			}
			else if (alineacion == TipoAlineacion.Izquierda)
			{	
				int starIndex = 0; 
				result = result.Insert(starIndex,cadena);
			}
			else if (alineacion == TipoAlineacion.Centrado)
			{	
				int starIndex = (longitud - cadena.Length) / 2; 
				result = result.Insert(starIndex,cadena);
			}
			return result.TrimEnd()  + "\r\n";

		}
	}
}
