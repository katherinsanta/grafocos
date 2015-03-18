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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Descripción breve de FiltroInterfazGDO_EDS.
	/// </summary>
	public class FiltroInterfazGDO_EDS : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Label lblArchivo;
		protected System.Web.UI.WebControls.LinkButton lblImportarNovedades;
		protected System.Web.UI.WebControls.Label lblEstado;
	
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
			// Introducir aquí el código de usuario para inicializar la página
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

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
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
			//this.lblImportarNovedades.Click += new System.EventHandler(this.lblImportarNovedades_Click);
			this.lblImportarNovedades.Click += new System.EventHandler(this.lblImportarNovedades_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Generar Archivo Plano de Facturas</b>";
			this.FechaInicio.SelectedDate = DateTime.Now;
		}
		#endregion

		private void lblImportarNovedades_Click(object sender, System.EventArgs e)
		{
			this.ActualizarNovedadesGDO();
		}


		#region Método ActualizarNovedadesGDO
		private void ActualizarNovedadesGDO()
		{
			//se hace el mismo procedimiento para la generación del plano
			this.lblError.Visible = false;
			Servipunto.Estacion.Libreria.Comercial.Clientes objClientess = new Servipunto.Estacion.Libreria.Comercial.Clientes();
			Servipunto.Estacion.Libreria.Comercial.Automotores objAutomotoress = new Servipunto.Estacion.Libreria.Comercial.Automotores();
			Servipunto.Estacion.Libreria.Comercial.Creditos creditos = new Servipunto.Estacion.Libreria.Comercial.Creditos();
			StreamReader fileNovedades  = null;
			
		
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				//string Directorio = Server.MapPath("C:\\servipunto\\administ\\recibidos"); 
				DirectoryInfo dir = new DirectoryInfo( "C:\\servipunto\\administ\\recibidos" );
				FileSystemInfo [] files = dir.GetFileSystemInfos("*.txt");
				
				
				DataTable financieras;
				DataTable tipoPorcens;
				
                				
				int _serv_subscriptor = 0;
				decimal _recaudo = 0;
				int _sucursal = 0;
				int _financiera = 0;
				decimal _saldo = 0;
				decimal _porcentaje  = 0;
				int _numeroCredito = 0;
				financieras = new DataTable();
				tipoPorcens = new DataTable();
				financieras = creditos.ObtenerFinancieras();
				
				this.lblEstado.Text = "Procesando..";				
				if(files.Length > 0)
				{
					string filename = files[0].FullName;
					fileNovedades  = new StreamReader(filename);			
					
					string registro = fileNovedades.ReadLine();
					this.lblArchivo.Text = filename;
					this.lblEstado.Text = "Procesando..";
					int nregistro = 0;
					while ( registro != null)
					{						
						// TIPO DE NOVEDAD
						this.lblEstado.Text = "Procesando Registro : " + (nregistro+1).ToString();
						int _concepto = Convert.ToInt32(registro.Substring(0,2));
						string _nombre = registro.Substring(2, 40);
						string _cedula = registro.Substring(42, 14);
						string _direccion = registro.Substring(56,65);
						string _solcredito = registro.Substring(121, 10);
						string _telefono = registro.Substring(131, 18);
						string _placa = registro.Substring(149, 10);
						try{_serv_subscriptor = Convert.ToInt32(registro.Substring(159,10));}	catch{_serv_subscriptor = 1;}
						string _fecha = registro.Substring(167,10);
						string _espacio = registro.Substring(177,1);
						string _horaMilitar = registro.Substring(178,5);
						try	{_recaudo = Convert.ToDecimal(registro.Substring(183,13));}	catch{ _recaudo = 0;}
						try{_sucursal = Convert.ToInt32(registro.Substring(196,3));} catch{ _sucursal = 0;}
						try{ _financiera = Convert.ToInt32(registro.Substring(199,3));} catch{ _financiera = 0;}
						try	{ _saldo = Convert.ToDecimal(registro.Substring(202,13));} catch	{ _saldo = 0;}
						try	{_porcentaje = Convert.ToDecimal(registro.Substring(215,6));} catch {	 _porcentaje = 0;}					

						bool error;
					
					
						switch ( _concepto)
						{
							case 1:	
								#region nuevos
								error = false;
								objClientess = new Servipunto.Estacion.Libreria.Comercial.Clientes();
								objAutomotoress = new Servipunto.Estacion.Libreria.Comercial.Automotores();
								creditos = new Servipunto.Estacion.Libreria.Comercial.Creditos();							
								
								Libreria.Comercial.Automotores autoscli = Libreria.Comercial.Automotores.ObtenerItems(_cedula);																
								int _maxfin = 0;
								bool _existe = false;
								int consecutivo = 0;
								string codFinanciera = "";
								string _tipoPorcentaje = "";
								try
								{						

									if ( Servipunto.Estacion.Libreria.Comercial.Clientes.ObtenerItem(_cedula, 1) == null)
									{

										try
										{
											Servipunto.Estacion.Libreria.Comercial.Cliente _objClientes  = new Servipunto.Estacion.Libreria.Comercial.Cliente();								
											_objClientes.CodigoCliente = _cedula;
											_objClientes.DireccionCliente = _direccion;
											_objClientes.Estadocliente = "A";
											_objClientes.FormaDePagoCliente = 4;
											_objClientes.NitCedulaCliente = _serv_subscriptor.ToString();
											_objClientes.NombreCliente = _nombre;
											_objClientes.TelefonoCliente =_telefono;
											_objClientes.TipoNit = "Nit";
											_objClientes.PrecioDiferencial = 0;
											_objClientes.IdCiudad = "76001";	
											Libreria.Comercial.Clientes.Adicionar(_objClientes);
										}
										catch(Exception ex)
										{
											SetError("Error al crear cliente..." + ex.Message);
											error = true;

										}
									}


									if ( autoscli != null)
									{
										foreach ( Libreria.Comercial.Automotor auto in autoscli)
										{
											if (auto.PlacaAutomotor.IndexOf(_placa.TrimEnd()) >= 0)
											{
												_existe = true;
												break;
											}
										}
									}

									if ( autoscli == null || !_existe  && !error)
									{
										try
										{
											Libreria.Comercial.Automotor _objAutomotor = new Libreria.Comercial.Automotor();
											_objAutomotor.AñoAutomotor = 2007;
											_objAutomotor.CodigoCausalDeBloqueoAutomotor = 0;
											_objAutomotor.CodigoCliente = _cedula;
											_objAutomotor.TipoAutomotor = "Automovil";
											_objAutomotor.Monitoreo = "Inactivo";
											_objAutomotor.CodigoFormaDePagoAutomtor = 4;
											_objAutomotor.DescuentoAutomtor = 0;
											_objAutomotor.FechaProximoMantenimientoAutomotor = DateTime.Now.Date;
											_objAutomotor.NumeroTanquesAuto = 1;										
											_objAutomotor.CapacidadTotalAutomtor = 0;
											_objAutomotor.NumeroMaxTanqueosDia = 0;
											_objAutomotor.MarcaAutomotor = _solcredito;
											_objAutomotor.ModeloAutomotor = _serv_subscriptor.ToString();
											_objAutomotor.PlacaAutomotor = _placa;
											_objAutomotor.TipoDescuento = 0;
											Libreria.Comercial.Automotores.Adicionar(_objAutomotor);
										}
										catch(Exception ex)
										{
											SetError("Error al crear automotor..." + ex.Message);
											error = true;

										}
									}
								
								
									_existe = false;
									
									foreach ( DataRow fila in  financieras.Rows)
									{
										if ((string)fila["Nombre"] == "Financiera" + _financiera.ToString())
										{
											_existe = true;
											break;

										}
										_maxfin++;
									}
								
									codFinanciera = (_maxfin+1).ToString();
									if ( !_existe && !error )
									{	
										try
										{
											DataRow drFinanciera = financieras.NewRow();
											drFinanciera["Codigo"]= codFinanciera;
											drFinanciera["Nombre"] = "Financiera" + _financiera.ToString();
											//Se deja abierta la opcion de mostrar este dato, significa que el DataTable todavia lee este registro de la BD
											drFinanciera["Num_Creditos"] = 0;
											drFinanciera["Estado"] = "A";
											drFinanciera["Cupo"] = 0;
											drFinanciera["Utilizado"] = 0;
											//Adicion del registro en el DataTable Financieras
											financieras.Rows.Add(drFinanciera);
											creditos.AgregarModificarFinancieras(ref financieras);
										}
										catch(Exception ex)
										{
											SetError("Error al crear financiera..." + ex.Message);
											error = true;

										}

											
									}
								
									// TABLA DE PORCENTAJES
									tipoPorcens = creditos.ObtenerTipoPorcen(_maxfin+1);
									_existe = false;
									
									foreach ( DataRow fila in  tipoPorcens.Rows)
									{
										if ((decimal)fila["Porcentaje"] == _porcentaje/100)
										{
											_existe = true;			
											break;

										}
										consecutivo ++;
									}
								
									 _tipoPorcentaje = (consecutivo + 1).ToString();
									if ( !_existe && !error )
									{
										try
										{
											DataRow drPorcentaje = tipoPorcens.NewRow();
											drPorcentaje["Financiera"] = codFinanciera;
											drPorcentaje["Tipo"] = _tipoPorcentaje;
											drPorcentaje["Porcentaje"] = _porcentaje/100;
											//Adiciono el registro en el DataTable
											tipoPorcens.Rows.Add(drPorcentaje);
											creditos.AgregarModificarPorcentajes(ref tipoPorcens);
										}
										catch(Exception ex)
										{
											SetError("Error al crear porcentaje..." + ex.Message);
											error = true;

										}
									}
									_existe = false;
									_numeroCredito = 0;			
									creditos = new Servipunto.Estacion.Libreria.Comercial.Creditos(0,_placa,"0");
									
										try
										{
											foreach( Servipunto.Estacion.Libreria.Comercial.Credito _credito in creditos)
											{
												if ( _credito.PlacaAutomotor.IndexOf(_placa.TrimEnd()) != -1)
												{
													_existe = true;
													break;
												}

											}
											if (!_existe && !error)
											{
												Libreria.Comercial.Credito objCredito = new Libreria.Comercial.Credito();
												objCredito.Numero = _numeroCredito + 1;
												objCredito.EntConsig = "";
												objCredito.PlacaAutomotor = _placa;
												objCredito.Tipo = "Kit";
												objCredito.Financiera = codFinanciera;
												objCredito.TipoPorcentaje = _tipoPorcentaje;
												objCredito.Monto = _saldo;
												objCredito.Saldo = _saldo;										
												#region Insertar Credito
												Libreria.Comercial.Creditos.Adicionar(objCredito);
												#endregion
												objCredito = null;
											}										


										}
										catch(Exception ex)
										{
											SetError("Error al crear nuevo credito..." + ex.Message);
											creditos = null;
											error = true;
										

										}
										creditos = null;
									
								}
								catch(Exception ex)

								{
									SetError("Error desde 0..." + ex.Message);
									error = true;
								}

								break;
								#endregion
							case 2:
								#region
							
								autoscli = Libreria.Comercial.Automotores.ObtenerItems(_cedula);																																				
								
								try
								{
									if ( autoscli != null)
									{
										foreach ( Libreria.Comercial.Automotor auto in autoscli)
										{
											if (auto.PlacaAutomotor.IndexOf(_placa.TrimEnd()) >= 0)
											{
												auto.CodigoCausalDeBloqueoAutomotor = 1;
												auto.Modificar();
												_existe = true;
												break;
											}
										}
									}	
								}
									
								
								catch(Exception ex)
								{

									SetError("Error al actualizar bloqueo..." + ex.Message);
								}
								break;
								#endregion
							case 3:
								#region
								_numeroCredito = 0;							
								creditos = new Servipunto.Estacion.Libreria.Comercial.Creditos(0,_placa,"0");

								foreach(Servipunto.Estacion.Libreria.Comercial.Credito _credito in creditos)
								{
									try
									{
										if ( _credito.PlacaAutomotor.IndexOf(_placa.TrimEnd()) != -1)
										{
											_numeroCredito = _credito.Numero;
											_credito.Saldo = 0;
											_credito.Modificar();
											break;
										}
									}
									catch(Exception ex)
									{
										SetError("Error al actualizar saldo en 0.." + ex.Message);
									}
								}
								
								break;
								#endregion

							case 4:
								#region desbloqueo
								autoscli = Libreria.Comercial.Automotores.ObtenerItems(_cedula);																																				
								
								if ( autoscli != null)
								{
									foreach ( Libreria.Comercial.Automotor auto in autoscli)
									{
										if (auto.PlacaAutomotor.IndexOf(_placa.TrimEnd()) >= 0)
										{
											auto.CodigoCausalDeBloqueoAutomotor = 0;
											auto.Modificar();
											_existe = true; 
											break;
										}
									}
								}	
							
								break;
								#endregion				
									
							
							case 5:
								
								#region actualizacion saldo
								
								creditos = new Servipunto.Estacion.Libreria.Comercial.Creditos(0,_placa,"0");								
								_existe = false;
								
									
								foreach( Servipunto.Estacion.Libreria.Comercial.Credito _credito in creditos)
								{
									if ( _credito.PlacaAutomotor.IndexOf(_placa.TrimEnd()) != -1)
									{											
										_maxfin = 0;
										foreach ( DataRow fila in  financieras.Rows)
										{
											if ((string)fila["Nombre"] == "Financiera" + _financiera.ToString())
											{
												_existe = true;
												break;

											}
											_maxfin++;
										}
											
										codFinanciera = (_maxfin+1).ToString();
										if ( !_existe)
										{											
											DataRow drFinanciera = financieras.NewRow();
											drFinanciera["Codigo"]= codFinanciera;
											drFinanciera["Nombre"] = "Financiera" + _financiera.ToString();
											//Se deja abierta la opcion de mostrar este dato, significa que el DataTable todavia lee este registro de la BD
											drFinanciera["Num_Creditos"] = 0;
											drFinanciera["Estado"] = "A";
											drFinanciera["Cupo"] = 0;
											drFinanciera["Utilizado"] = 0;
											//Adicion del registro en el DataTable Financieras
											financieras.Rows.Add(drFinanciera);
											creditos.AgregarModificarFinancieras(ref financieras);
											
										}

										// TABLA DE PORCENTAJES
										tipoPorcens = creditos.ObtenerTipoPorcen(_maxfin+1);
										_existe = false;
										consecutivo = 0;
										foreach ( DataRow fila in  tipoPorcens.Rows)
										{
											if ((decimal)fila["Porcentaje"] == _porcentaje/100)
											{
												_existe = true;			
												break;

											}
											consecutivo ++;
										}
										_tipoPorcentaje = (consecutivo + 1).ToString();
										if ( !_existe)
										{
											DataRow drPorcentaje = tipoPorcens.NewRow();
											drPorcentaje["Financiera"] = codFinanciera;
											drPorcentaje["Tipo"] = _tipoPorcentaje;
											drPorcentaje["Porcentaje"] = _porcentaje/100;
											//Adiciono el registro en el DataTable
											tipoPorcens.Rows.Add(drPorcentaje);
											creditos.AgregarModificarPorcentajes(ref tipoPorcens);
										}
										_credito.TipoPorcentaje=_tipoPorcentaje;
										_credito.Modificar();											
											
										
										break;
									}									
										
								}						

									
								break;
								#endregion
								
						}
						registro = fileNovedades.ReadLine();

					}
					
//					FileInfo x = new FileInfo(filename);					
//					x.MoveTo("c:\\servipunto\\administ\\procesados\\" + filename.Substring(filename.LastIndexOf("\\")+1));
					fileNovedades.Close();
					this.lblArchivo.Text = "";
					objClientess = null;
					objAutomotoress = null;
					creditos = null;
					this.lblEstado.Text = "Proceso Finalizado";



					
				}
				else
				{
					this.SetError("No hay archivos pendientes de procesar");
				}

			}
			catch(Exception ex)
			{
				fileNovedades.Close();
				objClientess = null;
				objAutomotoress = null;
				creditos = null;
				SetError("Error al generar el archivo..." + ex.Message);
			}
			
			

		}

		
		
		#endregion

		#endregion
		
	}
}
