using System;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Clase encargada de la generación e importacion de archivos que involucran varias tablas
	/// Autor:			Ing. Elvis Astaiza Gutierrez
	/// Fecha Creacion:	16/04/2008 09:00 AM		
	/// </summary>
	public class AdministradorArchivos  
	{  
		#region Sección de Declaraciones
		private Configuracion.Dat_Gene _objDat_Gene = null;
		private int _informacionRegistroActual=0;
		private int _informacionTotalRegistros=0;		
		private string _informacionNombreArchivo="";
		private int _informacionErrores=0;
		private string _rutaEntrada="";
		private string _rutaSalida="";
		#endregion

		#region Constructor / Destructor
		/// <summary>
		/// Clase encargada de la generación e importacion de archivos que involucran varias tablas
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	16/04/2008 09:00 AM		
		/// </summary>
		public AdministradorArchivos()
		{
			_objDat_Gene = Configuracion.Datos_Gene.ObtenerItem();
			if(_objDat_Gene == null)
				throw new Exception("Debe de configurar los datos generales de estación 'Administrativo > Panel de Control > Datos Generales.' Gracias!");
			if(_objDat_Gene.RutaExportarPredeterminada.Trim().Length == 0 || _objDat_Gene.RutaImportarPredeterminada.Trim().Length == 0 || _objDat_Gene.RutaPlanoVentasProcesadas.Trim().Length == 0)
				throw new Exception("Debe de configurar las rutas de importar, exportar, archivos procesados en 'Administrativo > Panel de Control > Datos Generales > Generar' Gracias!");
			_rutaEntrada = _objDat_Gene.RutaImportarPredeterminada;
			_rutaSalida = _objDat_Gene.RutaExportarPredeterminada;

		}
		/// <summary>
		/// Destructor de la clase
		/// </summary>
		~AdministradorArchivos()
		{
			_objDat_Gene = null;			
		}
				
		#endregion

		#region Propiedades Públicas

		/// <summary>
		/// Numero o indice del registro actual en proceso
		/// </summary>
		public int InformacionRegistroActual
		{
			get {return _informacionRegistroActual; }
			set {_informacionRegistroActual = value; }
		}
		/// <summary>
		/// Total de registros a procesar del archivo plano
		/// </summary>
		public int InformacionTotalRegistros
		{
			get {return _informacionTotalRegistros; }
			set {_informacionTotalRegistros = value; }
		}


		/// <summary>
		/// Nombre del archivo actual en proceso 
		/// </summary>
		public string InformacionNombreArchivo
		{
			get {return _informacionNombreArchivo; } 
			set {_informacionNombreArchivo = value; }
		}

		/// <summary>
		/// Informacion del total de errores
		/// </summary>
		public int InformacionTotalErrores
		{
			get {return _informacionErrores; }
			set {_informacionErrores = value; }
		}

		/// <summary>
		/// Directorio de archivos de entrada
		/// </summary>
		public string RutaEntrada
		{
			get {return _rutaEntrada; } 
			set {_rutaEntrada = value; }
		}
		
		/// <summary>
		/// Directorio de archivos de Salida
		/// </summary>
		public string RutaSalida
		{
			get {return _rutaSalida; } 
			set {_rutaSalida = value; }
		}

		#endregion

        #region Importar planos CPD
		/// <summary>
		/// Descripcion:	Importa los archivos planos CPD provenientes del centro de computo
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	30/04/2008 09:50 AM
		///</summary>
		///<param name="fecha">Fecha en la cual se genero el archivo a importar</param>
		///<param name="separador">Separador de columnas en el archivo plano</param>
        public int ImportarPlanoCPD(DateTime fecha, string separador)
		{
			#region Declaraciones
			ArrayList arreglo = new ArrayList();
			string [] cadena;
			string directorio = "";
			string resultado = "";
			string [] siglasArchivo = {"AUTO","IDEN","FINA","TPOR","BLOQ","CRED"};
			string nombreArchivo = "";
			int filasAfectadas;
			int totalRegistros=0;
			int registroActual=0;
			int totalErrores=0;
			string archivoProcesado="";
			#endregion
 
			#region Directorio de importacion
			separador = separador.Trim()==""?"*":separador;							
			directorio = _objDat_Gene.RutaImportarPredeterminada.Trim();
			if(directorio.Trim().Length < 3)
				throw new Exception("Debe de configurar los datos generales de estación y las rutas para importar y exportar archivos en 'Administrativo > Panel de Control > Datos Generales > Generar.' Gracias!");
			directorio += "\\CPD" + fecha.ToString("ddMMyyyy");
			if(!File.Exists(directorio + ".zip"))			
				throw new Exception("No existe el archivo '" + directorio + ".zip" + "' para ser importado.");
			try
			{
				UtilidadesGenerales.DescomprimirArchivos(directorio,directorio + ".zip",true);
			}
			catch(Exception ex)
			{
				throw new Exception("Error al descomprimir el archivo '" + directorio + ".zip" + "' para ser importado. " + ex.Message);
			}
			#endregion

			#region Importar registros
			SqlConnection connection = new SqlConnection(Aplicacion.Conexion.ConnectionString);
			connection.Open();
			for(int k=0; k<6; k++)
			{
				try
				{
					nombreArchivo = directorio + "\\" + siglasArchivo[k] +  fecha.ToString("ddMMyyyy") + ".txt";
					arreglo = LeerArchivo(nombreArchivo);
					archivoProcesado = nombreArchivo;
					totalRegistros = arreglo.Count;					
					for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para crear o modificar los registros
					{ 						
						registroActual = i + 1;		
						AsignarProgreso(registroActual,totalRegistros,archivoProcesado,totalErrores);
						cadena = arreglo[i].ToString().Split(separador.ToCharArray());
						switch(k)  
                        {  
                            #region Automotores
                            case 0:
								if(cadena.Length == 10) 
								{
									#region Prepare Sql Command para actualizar los registros
									try
									{
										SqlCommand command = new SqlCommand("InsertarAutomotorCPD", connection);
										command.CommandType = CommandType.StoredProcedure;

										command.Parameters.Add("@Nit", SqlDbType.VarChar);
										command.Parameters["@Nit"].Value = cadena[0].ToString();

										command.Parameters.Add("@Placa", SqlDbType.VarChar);
										command.Parameters["@Placa"].Value = cadena[1].ToString();

										command.Parameters.Add("@Descuento", SqlDbType.Decimal);
										command.Parameters["@Descuento"].Value = Decimal.Parse(cadena[2].ToString().Replace(".",","));

										command.Parameters.Add("@IdformaPago", SqlDbType.SmallInt);
										command.Parameters["@IdformaPago"].Value = Int16.Parse(cadena[3].ToString());

										command.Parameters.Add("@TipoAuto", SqlDbType.VarChar);
										command.Parameters["@TipoAuto"].Value = cadena[4].ToString();
 
										command.Parameters.Add("@CapacidadTotal", SqlDbType.Decimal);
										command.Parameters["@CapacidadTotal"].Value = Decimal.Parse(cadena[5].ToString().Replace(".",","));

										command.Parameters.Add("@FechaCreacion", SqlDbType.DateTime);
										command.Parameters["@FechaCreacion"].Value = DateTime.ParseExact(cadena[6].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										command.Parameters.Add("@Estado", SqlDbType.VarChar);
										command.Parameters["@Estado"].Value = cadena[7].ToString()=="1"?"A":"I";

										command.Parameters.Add("@FecUltimaActualizacion", SqlDbType.DateTime);
										command.Parameters["@FecUltimaActualizacion"].Value = DateTime.ParseExact(cadena[8].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										command.Parameters.Add("@IdSucursal", SqlDbType.SmallInt);
										command.Parameters["@IdSucursal"].Value = Int16.Parse(cadena[9].ToString());

										#endregion
 
										#region Execute SqlCommand

										filasAfectadas = command.ExecuteNonQuery();
									}
									catch (SqlException ex)
									{										
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[1].ToString() + "'. " + ex.Message + "!ERROR BD!",0); //+ ex.StackTrace);
										 
									}								
									catch(Exception ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[1].ToString() + "'. " + ex.Message + "!ERROR APP!",0); //+ ex.StackTrace);
									}
									#endregion	
								} 
								break;
                            #endregion

                            #region Identificadores
                            case 1: 
								if(cadena.Length == 8) 
								{
									#region Prepare Sql Command para actualizar los registros
									try
									{
										SqlCommand command = new SqlCommand("InsertarIdentificadorCPD", connection);
										command.CommandType = CommandType.StoredProcedure;

										command.Parameters.Add("@NumeroIdentificador", SqlDbType.Int);
										command.Parameters["@NumeroIdentificador"].Value = Int32.Parse(cadena[0].ToString());

										command.Parameters.Add("@SerieIdentificador", SqlDbType.VarChar);
										command.Parameters["@SerieIdentificador"].Value = cadena[1].ToString();

										command.Parameters.Add("@NumeroRom", SqlDbType.VarChar);
										command.Parameters["@NumeroRom"].Value = cadena[2].ToString();
                                          
										command.Parameters.Add("@Categoria", SqlDbType.VarChar);
										command.Parameters["@Categoria"].Value = cadena[3].ToString();

										command.Parameters.Add("@Tipo", SqlDbType.VarChar);
										command.Parameters["@Tipo"].Value = cadena[4].ToString();

										command.Parameters.Add("@Activa", SqlDbType.VarChar);
                                        command.Parameters["@Activa"].Value = cadena[5].ToString() == "1" ? "S" : "N";

										command.Parameters.Add("@FechaCreacion", SqlDbType.DateTime);
										command.Parameters["@FechaCreacion"].Value = DateTime.ParseExact(cadena[6].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										command.Parameters.Add("@Placa", SqlDbType.VarChar);
										command.Parameters["@Placa"].Value = cadena[7].ToString();

										#endregion
 
										#region Execute SqlCommand

                                        //filasAfectadas = command.ExecuteNonQuery();
                                        command.ExecuteNonQuery();
									}
									catch (SqlException ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[7].ToString() + "'. " + ex.Message + "!ERROR BD!",0);//+ ex.StackTrace);
										
									}								
									catch(Exception ex)
									{ 
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[7].ToString() + "'. " + ex.Message + "!ERROR APP!",0);// + ex.StackTrace);
									}
									#endregion	
								} 
								break;
                            #endregion

                            #region Financieras
                            case 2: 
                                if (cadena.Length == 7)
                                {
                                    #region Prepare Sql Command para actualizar los registros
                                    try
                                    {
                                        SqlCommand command = new SqlCommand("InsertarFinancieraCPD", connection);
                                        command.CommandType = CommandType.StoredProcedure;

                                        command.Parameters.Add("@Nombre", SqlDbType.VarChar);
                                        command.Parameters["@Nombre"].Value = cadena[0].ToString();

                                        command.Parameters.Add("@Nit", SqlDbType.VarChar);
                                        command.Parameters["@Nit"].Value = cadena[1].ToString();

                                        command.Parameters.Add("@IdCiudad", SqlDbType.VarChar);
                                        command.Parameters["@IdCiudad"].Value = cadena[2].ToString();
 
                                        command.Parameters.Add("@Direccion", SqlDbType.VarChar);
                                        command.Parameters["@Direccion"].Value = cadena[3].ToString();

                                        command.Parameters.Add("@Telefonos", SqlDbType.VarChar);
                                        command.Parameters["@Telefonos"].Value = cadena[4].ToString();

										command.Parameters.Add("@NombreContacto", SqlDbType.VarChar);
										command.Parameters["@NombreContacto"].Value = cadena[5].ToString(); ;

										command.Parameters.Add("@Estado", SqlDbType.VarChar);
                                        command.Parameters["@Estado"].Value = cadena[6].ToString() == "1" ? "A" : "I";

                                    #endregion

                                        #region Execute SqlCommand

                                        //filasAfectadas = command.ExecuteNonQuery();
                                        command.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de la financiera de NIT '" + cadena[1].ToString() + "'. " + ex.Message + "!ERROR BD!",0);//+ ex.StackTrace);

                                    }
                                    catch (Exception ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de la financiera de NIT '" + cadena[1].ToString() + "'. " + ex.Message + "!ERROR APP!",0);//+ ex.StackTrace);
                                    }
                                        #endregion
                                }
                                break;
                            #endregion

							#region Tipos de porcentaje
							case 3:
								if(cadena.Length == 4) 
								{
									#region Prepare Sql Command para actualizar los registros
									try
									{
										SqlCommand command = new SqlCommand("InsertarTiposPorcentajeCPD", connection);
										command.CommandType = CommandType.StoredProcedure;

										command.Parameters.Add("@NitFinanciera", SqlDbType.VarChar);
										command.Parameters["@NitFinanciera"].Value = cadena[0].ToString();

										command.Parameters.Add("@Tipo", SqlDbType.VarChar);
										command.Parameters["@Tipo"].Value = cadena[1].ToString();

										command.Parameters.Add("@Porcentaje", SqlDbType.Decimal);
										command.Parameters["@Porcentaje"].Value = Decimal.Parse(cadena[2].ToString().Replace(".",","));

										#endregion
 
										#region Execute SqlCommand

										filasAfectadas = command.ExecuteNonQuery();
									}
									catch (SqlException ex)
									{
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de la financiera de NIT '" + cadena[0].ToString() + "' y el porcentaje de tipo '" +  cadena[1].ToString() + "'. " + ex.Message + "!ERROR BD!",0);//+ ex.StackTrace);
										  
									}								
									catch(Exception ex)
									{
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de la financiera de NIT '" + cadena[0].ToString() + "' y el porcentaje de tipo '" +  cadena[1].ToString() + "'. " + ex.Message + "!ERROR APP!",0);//+ ex.StackTrace);
									}
									#endregion	
								} 
								break;
								#endregion

							#region Bloqueos
							case 4:
								if(cadena.Length == 4) 
								{
									#region Prepare Sql Command para actualizar los registros
									try
									{
										SqlCommand command = new SqlCommand("InsertarBloqueoCPD", connection);
										command.CommandType = CommandType.StoredProcedure;

										command.Parameters.Add("@Placa", SqlDbType.VarChar);
										command.Parameters["@Placa"].Value = cadena[0].ToString();

										command.Parameters.Add("@IdCausal", SqlDbType.SmallInt);
										command.Parameters["@IdCausal"].Value = Int16.Parse(cadena[1].ToString());

										command.Parameters.Add("@FechaInicial", SqlDbType.DateTime);
										command.Parameters["@FechaInicial"].Value = DateTime.ParseExact(cadena[2].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										command.Parameters.Add("@FechaFinal", SqlDbType.DateTime);
										command.Parameters["@FechaFinal"].Value = DateTime.ParseExact(cadena[3].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										#endregion
 
										#region Execute SqlCommand

										filasAfectadas = command.ExecuteNonQuery();
									}
									catch (SqlException ex)
									{
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[0].ToString() + "'. " + ex.Message + "!ERROR BD!",0); //+ ex.StackTrace);
										 
									}								
									catch(Exception ex)
									{
										totalErrores += 1;
										UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' de placa '" + cadena[0].ToString() + "'. " + ex.Message + "!ERROR APP!",0); //+ ex.StackTrace);
									}
									#endregion	
								} 
								break;
								#endregion

							#region Creditos
							case 5:
								if(cadena.Length == 13) 
								{
									#region Prepare Sql Command para actualizar los registros
									try
									{
										SqlCommand command = new SqlCommand("InsertarCreditoCPD", connection);
										command.CommandType = CommandType.StoredProcedure;

										command.Parameters.Add("@DocumentoCliente", SqlDbType.VarChar);
										command.Parameters["@DocumentoCliente"].Value = cadena[0].ToString();

										command.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
										command.Parameters["@NombreCliente"].Value = cadena[1].ToString();

										command.Parameters.Add("@DireccionCliente", SqlDbType.VarChar);
										command.Parameters["@DireccionCliente"].Value = cadena[2].ToString();

										command.Parameters.Add("@Placa", SqlDbType.VarChar);
										command.Parameters["@Placa"].Value = cadena[3].ToString();

										command.Parameters.Add("@NitFinanciera", SqlDbType.VarChar);
										command.Parameters["@NitFinanciera"].Value = cadena[4].ToString();

										command.Parameters.Add("@CodigoFinanciera", SqlDbType.VarChar);
										command.Parameters["@CodigoFinanciera"].Value = cadena[5].ToString();

										command.Parameters.Add("@Pagare", SqlDbType.VarChar);
										command.Parameters["@Pagare"].Value = cadena[6].ToString();

										command.Parameters.Add("@Observaciones", SqlDbType.VarChar);
										command.Parameters["@Observaciones"].Value = cadena[7].ToString();

										command.Parameters.Add("@TipoCredito", SqlDbType.VarChar);
										command.Parameters["@TipoCredito"].Value = cadena[8].ToString();

										command.Parameters.Add("@Monto", SqlDbType.Decimal);
										command.Parameters["@Monto"].Value = Decimal.Parse(cadena[9].ToString().Replace(".",","));

										command.Parameters.Add("@Saldo", SqlDbType.Decimal);
										command.Parameters["@Saldo"].Value = Decimal.Parse(cadena[10].ToString().Replace(".",","));

										command.Parameters.Add("@TipoPorcentaje", SqlDbType.VarChar);
										command.Parameters["@TipoPorcentaje"].Value = cadena[11].ToString();

										command.Parameters.Add("@FechaCreacion", SqlDbType.DateTime);
										command.Parameters["@FechaCreacion"].Value = DateTime.ParseExact(cadena[12].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

										#endregion
 
										#region Execute SqlCommand

										filasAfectadas = command.ExecuteNonQuery();
									}
									catch (SqlException ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' con el credito perteneciente a la placa '" + cadena[3].ToString() +  "' de la financiera de NIT '" + cadena[4].ToString() + "'. " + ex.Message + "!ERROR BD!",0);//+ ex.StackTrace);

                                    }
                                    catch (Exception ex)
									{
										totalErrores += 1;
                                        UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(nombreArchivo + " - Error al importar el registro número '" + Convert.ToString((i + 1)) + "' con el credito perteneciente a la placa '" + cadena[3].ToString() + "' de la financiera de NIT '" + cadena[4].ToString() + "'. " + ex.Message + "!ERROR APP!",0);//+ ex.StackTrace);
                                    }
                                    #endregion	
								} 
								break;
								#endregion
                        }				
					}
				}
				catch(Exception ex)
				{
					totalErrores += 1;
					UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos(ex.Message,0);
				}			
			}
			connection.Close();
			try
			{
				UtilidadesGenerales.MoverArchivo(directorio + ".zip",_objDat_Gene.RutaPlanoVentasProcesadas,true,directorio);
			}
			catch(Exception)
			{
				throw new Exception(" error al mover el archivo '" + directorio + ".zip' a la ruta '" + _objDat_Gene.RutaPlanoVentasProcesadas + "'");
			}
			#endregion 

			return totalErrores;
		}

		#endregion

		#region Generar plano de ventas CPD
		/// <summary>
		/// Descripcion:	Genera el archivo plano de ventas CPD para el centro de computo
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	30/04/2008 09:50 AM
		///</summary>
		///<param name="fechaInicial">Fecha inicial a consultar</param>
		///<param name="fechaFinal">Fecha final a consultar</param>
		public int GenerarPlanoVentasCPD(DateTime fechaInicial, DateTime fechaFinal)
		{
			#region declaraciones
			string nombreArchivo = "";
			string directorio = _objDat_Gene.RutaExportarPredeterminada;
			DateTime fechaEnProceso = fechaInicial;
			string fechaTexto = "";
			string filaTexto="";
			string separador = "*";
            int totalRegistros = 0;
            int registroActual = 0;
			int totalErrores=0;
            string archivoProcesado = "";
			#endregion 

			#region directorio de exportacion
			if(directorio.Trim().Length== 0)
				throw new Exception("Debe de configurar los datos generales de estación y las rutas para importar y exportar archivos en 'Administrativo > Panel de Control > Datos Generales > Generar.' Gracias!");
			
			UtilidadesGenerales.CrearDirectorio(directorio,1);
			#endregion

			#region generar planos
			while(fechaEnProceso <= fechaFinal)
			{
				fechaTexto = fechaEnProceso.ToString("ddMMyyyy"); 
				nombreArchivo = directorio + "\\E" + _objDat_Gene.CodigoSucursal.ToString().PadLeft(3,'0') + "PD" + fechaTexto + ".txt";
				UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"*.txt");
                totalRegistros = 0; 
                registroActual = 0;				
                archivoProcesado = nombreArchivo;  
				AsignarProgreso(registroActual, totalRegistros, archivoProcesado, totalErrores);
 
				#region Prepare Sql Command 
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("RecuperarVentasCPD");
				sql.ParametersNumber = 2;
				sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaEnProceso);			
				sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaEnProceso);			
				#endregion
				
				#region Execute Sql
				try
				{  
					DataSet ds = null;
					ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
					if(ds == null || ds.Tables[0].Rows.Count == 0)
					{ 
						totalErrores += 1;
						UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("No se encontraron registros para generar el archivo '" + nombreArchivo + "' Criterio de selección Rango '" + fechaEnProceso.ToShortDateString() + "'",0);
					}
					else
					{
						FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
						StreamWriter writer = new StreamWriter(stream);
						totalRegistros = ds.Tables[0].Rows.Count;	
						for(int j=0; j<ds.Tables[0].Rows.Count; j++)
						{
							try
							{
								registroActual = j + 1;
								AsignarProgreso(registroActual, totalRegistros, archivoProcesado, totalErrores);
								filaTexto = "";
								for(int k=0; k<ds.Tables[0].Columns.Count; k++)
								{
									filaTexto += ds.Tables[0].Rows[j][k].ToString().Trim();
									if(k+1 < ds.Tables[0].Columns.Count)
										filaTexto += separador;	 
								}
								writer.WriteLine(filaTexto);
							}
							catch(Exception ex)
							{
								totalErrores += 1;
								UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error al generar el archivo '" + nombreArchivo + "' al escribir la fila '" + filaTexto + "'" + ex.Message + " !ERROR BD! ",0);
							}
						}
						writer.Close();
						#region Comprimir los archivos generados
						try 
						{
							UtilidadesGenerales.ComprimirArchivos(new ArrayList(nombreArchivo.Split('|')), Path.GetDirectoryName(nombreArchivo) + "\\" + (Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip"), true); 
						} 
						catch(Exception ex)
						{
							totalErrores += 1;
							UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error al comprimir el archivo de ventas CPD '" + nombreArchivo + "'. " + ex.Message,0);
						}

						#endregion						
					}
					fechaEnProceso = fechaEnProceso.AddDays(1);
				}
				catch (SqlException ex)
				{
					totalErrores += 1;
					UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error al generar el archivo '" + nombreArchivo + "' " + ex.Message + " !ERROR BD! ",0);
				}
				catch (Exception ex)
				{
					totalErrores += 1;
					UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error al generar el archivo '" + nombreArchivo + "' " + ex.Message + " !ERROR APP! ",0);
				}
				finally 
				{
					sql = null;
				}
				#endregion		
			}
			#endregion			
			return	totalErrores;
		}
		#endregion

	    #region Leer archivo plano
        /// <summary>
        /// Lee un archivo de plano y retorna su contenido en un ArrayList
		/// </summary>
        ///<param name="nombreArchivo">Ruta y nombre del archivo a cargar</param>        
        public static ArrayList LeerArchivo(string nombreArchivo)
        {
            string filaTexto = "";
            ArrayList arreglo = new ArrayList();
			UtilidadesGenerales.CrearDirectorio(nombreArchivo,2);
            try
            {
                FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                while (reader.Peek() > -1)
                {
                    filaTexto = reader.ReadLine();
                    if (filaTexto.Trim().Length > 0)
                        arreglo.Add(filaTexto);
 
                }
                reader.Close();
                return arreglo;
            }
            catch (Exception ex)
            {
                arreglo.Add("Error al procesar el archivo '"+ nombreArchivo + "': " + ex.Message + " !ERROR APP! ");
				throw new Exception (arreglo[0].ToString());
				//return arreglo;
            }



        }

        #endregion

		#region Colocar separador de columnas a un arreglo de archivo con filas de ancho fijo
		/// <summary>
		/// Descripcion:	Colocar separador a un arreglo de archivo con filas de ancho fijo
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	18/04/2008 09:00 AM		
		///</summary>
		///<param name="arreglo">Arreglo con las filas del archivo</param>
		///<param name="tamañoColumnas">Arreglo con el tamaño de ancho fijo de cada una de las columnas</param>
		///<param name="separador">Caracter que separará las columnas</param>
		///<param name="nombreArchivo">Nombre del archivo procesado</param>		
		///<param name="quitarEspacios">Determina si elimina los espacios en los extremos de las columnas</param>		
		///<param name="errores">Errores detectados</param>				
		public static ArrayList ColocarSeparador(ArrayList arreglo, int [] tamañoColumnas, string separador, string nombreArchivo, bool quitarEspacios, ref int errores)
		{
			#region Declaracion de variables
			string filaTexto;
			int acumulador;
			int tamañoFila=0;
			string cadena;
			ArrayList nuevoArreglo = new ArrayList();
			#endregion

			#region crear separadores
			for(int i=0; i<tamañoColumnas.Length; i++)
				tamañoFila += tamañoColumnas[i];

			for(int i=0; i<arreglo.Count; i++)
			{
				try
				{
					filaTexto = arreglo[i].ToString();
					if(filaTexto.Trim().Length > 0)
					{

						if(filaTexto.Length != tamañoFila)
						{	errores += 1;
							UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error en el archivo '" + nombreArchivo + "'; la fila '" + Convert.ToString(i + 1) + "' tiene un ancho de '" + filaTexto.Length.ToString() + "' caracteres y deberia tener '" + tamañoFila + "' caracteres",0);
						}
						else
						{
							cadena = "";
							acumulador = 0;
							for(int j=0; j<tamañoColumnas.Length; j++)
							{
								if(j>0)
									cadena += separador;
								cadena += quitarEspacios?filaTexto.Substring(acumulador,tamañoColumnas[j]).Trim():filaTexto.Substring(acumulador,tamañoColumnas[j]);
								acumulador += tamañoColumnas[j];
							}
							nuevoArreglo.Add(cadena);
						}
					}
				}
				catch (Exception ex)
				{
					errores += 1;
					UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error en el archivo '" + nombreArchivo + "'; la fila '" + Convert.ToString(i + 1) + "' no se pudo procesar. " + ex.ToString(),0);
				}
			}
			#endregion

			return nuevoArreglo;

		}

		#endregion

		#region Validar Estructura de los archivos
		/// <summary>
		/// Valida el numero de columnas de un archivo plano
		/// </summary>
		///<param name="arreglo">Datos leidos del archivo</param>
		///<param name="totalColumnas">Total de columnas que debe tener las filas del arreglo</param>
		///<param name="separador">Separador de columnas por fila</param>
		///<param name="nombreArchivo">Nombre del archivo el cual se va a verificar</param>
		private static int ValidarColumnas(ArrayList arreglo, int totalColumnas, string separador, string nombreArchivo)
		{
			#region Declaraciones
			string [] cadena;
			int errores=0;			
			#endregion

			#region Validadora
			for(int i=0; i<arreglo.Count; i++) //recorre la lista para validar el numero de columnas de cada fila
			{
					
				cadena = arreglo[i].ToString().Split(separador.ToCharArray());
				if(cadena.Length != totalColumnas)
				{
					errores+=1;
					UtilidadesGenerales.EscribirLogYAuditoriaAdministradorArchivos("Error en la lina: '" + Convert.ToString(i+1) + "' El archivo debe tener '" + totalColumnas.ToString() + "' columnas '" + " y tiene '" + cadena.Length.ToString() + "'"+ nombreArchivo,0);
				}
			}
			#endregion
			return errores;
		}

		#endregion

		#region AsignarProgreso
		/// <summary>
		/// Descripcion:	Asigna las variables de progreso para la barra de estado
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	07/05/2008 12:00 PM
		///</summary>
		///<param name="registroActual">Registro actual analizado</param>
		///<param name="totalRegistros">Total de registros</param>
		///<param name="nombreArchivo">Nombre del archivo procesado</param>
		///<param name="totalErrores">Total de errores encotrandos</param>
		private void AsignarProgreso(int registroActual, int totalRegistros, string nombreArchivo, int totalErrores)
		{ 
			_informacionTotalRegistros = totalRegistros;
			_informacionRegistroActual = registroActual;
			_informacionNombreArchivo = nombreArchivo;
			_informacionErrores = totalErrores;			
		}
		#endregion

    }
}
