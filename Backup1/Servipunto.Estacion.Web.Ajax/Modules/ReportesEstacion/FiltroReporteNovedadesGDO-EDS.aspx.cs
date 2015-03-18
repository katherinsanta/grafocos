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
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using System.Data.SqlClient;
using System.IO;

namespace Servipunto.Estacion.Reportes
{
	public partial class FiltroPlanoFacturas : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Label lblTipoReporte;
		protected System.Web.UI.WebControls.DropDownList ddlAno;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.LinkButton lblLeerNovedades;
		protected System.Web.UI.WebControls.LinkButton lblGuardar;
		protected System.Web.UI.WebControls.LinkButton lblGuardarFacturas;

		#endregion
	
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
			if (this.IsPostBack)
			{
				if (Request.Form["__EVENTTARGET"].Length == 0)
				{
					this.lblError.Visible = false;
				}
			}
			else
			{
				this.VerificarPermisos();
				this.InicializarForma();
			}
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
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
				this.MyForm.Visible = false;
				return false;
			}
			
			return true;
		}
		#endregion

		#region EjecutarSP
		private void EjecutarSP()
		{
			this.lblError.Visible = false;
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				string Directorio = Server.MapPath("../."); 
				string [] arreglo = System.IO.Directory.GetFiles(Directorio);

				string sqlcomando = "exec SP_Call_PlainGenerator '" + 
					this.FechaInicio.SelectedDate.ToString("yyyyMMdd") + "', '" +
					this.FechaInicio.SelectedDate.ToString("yyyyMMdd") + "', '" 
					+ Request.Form["txtSeparador"] + "', '" + Directorio + "'"
					+ " , 2," + Request.Form["txtIsla"] + ", " + Request.Form["txtNum_Tur"];



				SqlCommand Comando = new SqlCommand(sqlcomando,Conexion);
				Comando.CommandType = CommandType.Text;
				Comando.ExecuteNonQuery();
				arreglo = System.IO.Directory.GetFiles(Directorio);
				Conexion.Close();
				
				arreglo = System.IO.Directory.GetFiles(Directorio);

				if(arreglo.Length > 0)
				{
					Response.Clear();
					Response.ContentType = "text/plain";
					Response.AppendHeader( "Content-Disposition", "attachment; filename =" + arreglo[0].Substring(arreglo[0].LastIndexOf("\\") + 1)); 
					Response.WriteFile(arreglo[0]);
					Response.End();
					
				}
				else
				{
					this.SetError("No se creo el archivo.");
				}

			}
			catch(Exception)
			{
				SetError("Error al generar el archivo...");
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Generar Archivo Plano de Facturas</b>";
			this.FechaInicio.SelectedDate = DateTime.Now;
		}
		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}

		private void lblGuardarFacturas_Click(object sender, System.EventArgs e)
		{
			this.EjecutarSP();
		}

		private void lblLeerNovedades_Click(object sender, System.EventArgs e)
		{
			this.LeerPlanoNovedades();
		}
		#endregion

		/// <summary>
		///  Lectura Archivo plano de novedades GDO y de acuerdo al tipo de novedad actualizar las tablas
		///  clientes, automotores, financieras y porcentajes
		///  !!! SOLO APLICA PARA GDO !!!
		///  REQ. 003 FEB 21 DEL 2007
		/// </summary>
		#region Método LeerPlanoNovedades
		private void LeerPlanoNovedades()
		{
			//se hace el mismo procedimiento para la generación del plano
			this.lblError.Visible = false;
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				//StreamReader datFile = new StreamReader("c:\servipunto\estacion\administ\recibidos");
				//Leer directorio donde estan los archivos de novedades
				// c:\servipunto\estacion\administ\recibibidos
				DirectoryInfo dir = new DirectoryInfo("c:\\servipunto\\administ\\recibidos");		
				// Filtrar los archivos tipo txt
				FileSystemInfo[] fsi =  dir.GetFileSystemInfos("*.txt");
				// se toma el primer archivo y ese el que se procesa
				FileSystemInfo fil = fsi[0];			
				string nombrearchivo = fil.FullName ;
			    
				

				// SE ABRE EL ARCHIVO Y SE LEE CADA UNA DE SUS LINEAS
				StreamReader FilStream = new StreamReader(nombrearchivo);				
				string dato = FilStream.ReadLine();				
				while ( dato != null)
				{
					// TIPO DE NOVEDAD POSICION 1-2
					int _tiponovedad = Convert.ToInt32(dato.Substring(0,2));					
					
					#region Cliente Nuevo
					if ( _tiponovedad == 1)  // CLIENTE NUEVO
					{
						string _nombre = dato.Substring(2, 40);
						string _cedula = dato.Substring(42, 14);
						string _direccion = dato.Substring(56, 65);
						string _sol_credito = dato.Substring(121, 10);
						string _telefono = dato.Substring(131, 18);
						string _placa = dato.Substring(149, 10);
						string _serv_subcriptor = dato.Substring(159,8);
						string _fecha = dato.Substring(167,10);
						string _espacio = dato.Substring(177,1);
						string _horaMilitar = dato.Substring(178,5);
						decimal _valorRecaudo = Convert.ToDecimal(dato.Substring(183,13));
						int _sucursal = Convert.ToInt16(dato.Substring(196,3));
						int _financiera = Convert.ToInt32(dato.Substring(199,3));
						decimal _saldo = Convert.ToDecimal(dato.Substring(202,12));
						decimal _porcentaje = Convert.ToDecimal(dato.Substring(215,6));						

						// ADICIONAR CLIENTE
						Libreria.Comercial.Cliente _objCliente = new Libreria.Comercial.Cliente();
						_objCliente.CodigoCliente = _serv_subcriptor;
						_objCliente.DireccionCliente = _direccion;
						_objCliente.Estadocliente = "A";
						_objCliente.FormaDePagoCliente = 6;
						_objCliente.NitCedulaCliente =_cedula;
						_objCliente.NombreCliente = _nombre;
						_objCliente.TelefonoCliente = _telefono;
						_objCliente.TipoNit = "Nit";
						_objCliente.PrecioDiferencial = 0;
						_objCliente.IdCiudad = "91263";						
						Libreria.Comercial.Clientes.Adicionar(_objCliente);
						//ADICIONAT AUTOMOTOR
						Libreria.Comercial.Automotor _objAutomotor = new Libreria.Comercial.Automotor();
						_objAutomotor.AñoAutomotor = 2007;
						_objAutomotor.CodigoCausalDeBloqueoAutomotor = 0;
						_objAutomotor.CodigoCliente = _serv_subcriptor;
						_objAutomotor.TipoAutomotor = "Automovil";
						_objAutomotor.Monitoreo = "Inactivo";
						_objAutomotor.CodigoFormaDePagoAutomtor = 6;
						_objAutomotor.DescuentoAutomtor = 0;
						_objAutomotor.FechaProximoMantenimientoAutomotor = DateTime.Now.Date;
						_objAutomotor.NumeroTanquesAuto = 1;
						_objAutomotor.CapacidadTotalAutomtor = 0;
						_objAutomotor.NumeroMaxTanqueosDia = 0;
						_objAutomotor.MarcaAutomotor = "";
						_objAutomotor.ModeloAutomotor ="";
						_objAutomotor.PlacaAutomotor = _placa;
						_objAutomotor.TipoDescuento = 0;							
						Libreria.Comercial.Automotores.Adicionar(_objAutomotor);
						//ADICIONAR FINANCIERA
						DataTable Financieras = new DataTable();
						Servipunto.Estacion.Libreria.Comercial.Creditos objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos();
						Financieras = objPersonal.ObtenerFinancieras();	
						DataRow drFinanciera = Financieras.NewRow();
						drFinanciera["Codigo"]= _financiera;
						drFinanciera["Nombre"] = "Financiera " + _financiera.ToString().TrimEnd().PadLeft(2, '0');
						//Se deja abierta la opcion de mostrar este dato, significa que el DataTable todavia lee este registro de la BD
						drFinanciera["Num_Creditos"] = 0;
						drFinanciera["Estado"] = "A";
						drFinanciera["Cupo"] = 0;
						drFinanciera["Utilizado"] = 0;
						//Adicion del registro en el DataTable Financieras
						Financieras.Rows.Add(drFinanciera);		
						objPersonal.AgregarModificarFinancieras(ref Financieras);		
						// ADICIONAR PORCENTAJES
						//TipoPorcen = objPersonal.ObtenerTipoPorcen(ddlFinanciera.SelectedIndex+1);
						DataTable TipoPorcen = new DataTable();
						DataRow drPorcentaje = TipoPorcen.NewRow();
						drPorcentaje["Financiera"] = _financiera;
						drPorcentaje["Tipo"] = "A";
						drPorcentaje["Porcentaje"] = Convert.ToDecimal(_porcentaje);
						//Adiciono el registro en el DataTable
						TipoPorcen.Rows.Add(drPorcentaje);
						objPersonal.AgregarModificarPorcentajes(ref TipoPorcen);


						
					}
					#endregion
					dato = FilStream.ReadLine();					
				}
				
			}
			catch(Exception ex)
			{
				SetError("Error al generar el archivo..." + ex.Message);
			}

		}
		#endregion
	}
}
