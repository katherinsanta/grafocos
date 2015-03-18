using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

namespace Servipunto.Estacion.Libreria.Turnos
{ 
	/// <summary>
	/// Bibliote de Colección de Clases para administrar Turnos laborales en las estaciones de servicio
	/// </summary>
	public class TurnosLaborales : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		int _opcion;
		int _codigoIsla;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de todos los turnos
		/// </summary>
		public TurnosLaborales(int opcion,int codigoIsla)
		{
			this._opcion = opcion;
			this._codigoIsla = codigoIsla;
		}
		#endregion
 
		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public TurnoLaboral this[string key]
		{
			get { return (TurnoLaboral)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public TurnoLaboral this[int index]
		{
			get { return (TurnoLaboral)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperarTurnoLaboral");
			sql.ParametersNumber = 2;
			sql.AddParameter("@CodigoIsla", SqlDbType.Int, this._codigoIsla);
			sql.AddParameter("@Opcion", SqlDbType.Int, this._opcion);
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				TurnoLaboral objTurnoLaboral = new TurnoLaboral();
				objTurnoLaboral.Fecha = DateTime.Parse(dr.GetValue(0).ToString());
				objTurnoLaboral.CodigoIsla = dr.IsDBNull(1)?(short)0:dr.GetInt16(1);
				objTurnoLaboral.NumeroTurno = dr.IsDBNull(2)?(short)0:dr.GetInt16(2);
				objTurnoLaboral.Estado = dr.IsDBNull(3)?"A":dr.GetString(3);
				objTurnoLaboral.Hora_Inicial = dr.IsDBNull(4)?DateTime.Parse("01-01-1900"):DateTime.Parse("01-01-1900 " + dr.GetValue(4).ToString());
				objTurnoLaboral.Hora_Final = dr.IsDBNull(5)?DateTime.Parse("01-01-1900"):DateTime.Parse("01-01-1900 " + dr.GetValue(5).ToString());
				objTurnoLaboral.CodigoEmpleado = dr.IsDBNull(6)?"0":dr.GetValue(6).ToString().Trim();
				//objTurnoLaboral.Conciliado = DateTime.Parse("01-01-1900 " + dr.GetValue(5).ToString());

				base.AddItem(objTurnoLaboral.Fecha.ToString() + objTurnoLaboral.Hora_Inicial.ToString(), objTurnoLaboral);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un turno en particular
		/// </summary>
		public static TurnoLaboral ObtenerItem(int opcion, int codigoIsla)
		{
			TurnosLaborales objElementos = new TurnosLaborales(opcion,codigoIsla);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region Reporte detalles de un turno
		
		/// <summary>
		/// Método para obtener todos los datos de un turno en particulasr
		/// </summary>
		/// <param name="fecha">Fecha del turno</param>
		/// <param name="turno">Codigo del turno</param>
		/// <param name="isla">Codigo dela isla</param>
		public static DataSet ReporteTurnos(DateTime fecha, string turno, int isla)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RptTurnoInformacion");
			sql.ParametersNumber = 3;
			sql.AddParameter("@fecha", SqlDbType.DateTime, fecha);
			sql.AddParameter("@num_tur", SqlDbType.Int,turno);
			sql.AddParameter("@cod_isl", SqlDbType.Int,isla);
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters));
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}

			#endregion
		}
		#endregion

		#region Generar lecturas de control de turno
		/// <summary>
		/// Genera un archivo plano de lecturas de control de turno 
		/// </summary>
		/// <param name="fechaInicio">Fecha de la cual se desea verificar las lecturas</param>
		/// <param name="fechaFin">Fecha de la cual se desea verificar las lecturas</param>
		/// <param name="codigoIsla">Codigo de la isla</param>
		/// <param name="numeroTurno">Numero del turno</param>
		/// <param name="codigoManguera">Codigo de la mangera</param>
		/// <param name="separador">separador entre campos del archivo plano</param>
		/// <param name="idArticulo">Codigo del articulo a consultar, 0: para todos</param>
		/// <param name="consolidado">False: valor por defecto consolida por turno y luego por manguera, True: Consolidara por manguera</param>
		public static string PlanoLecturasControlTurno( 
			DateTime fechaInicio,  
			DateTime fechaFin, 
			int codigoIsla, 
			int numeroTurno, 
			int codigoManguera,
			string separador,
			Int16 idArticulo,
			bool consolidado
			) 
		{

			#region Declaraciones
			string filaTexto="";
			string dia = fechaInicio.Day.ToString();
			string mes = fechaInicio.Month.ToString();
			string año = fechaInicio.Year.ToString();
			//string fechaPlana = AjustarTamaño(DateTime.Parse(fecha).ToString().Replace("/",""),8);
			string fechaPlana = (dia.PadLeft(2,'0') + mes.PadLeft(2,'0') + año.PadLeft(4,'0'));
			Planos.InterfazContables objInterfazContables = new Planos.InterfazContables();
			InterfazContable objInterfazContable = new InterfazContable();
			string codigoSucursal = "";
			string directorio = "";
			string nombreArchivo = "";
			string filaTemporal = "";
			Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
			#endregion
			
			#region Ruta Exportacion y nombre del archivo
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				GuardarAuditoriaError("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			directorio = objDat_Gene.RutaExportarPredeterminada;
			if(directorio == "")
			{
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 2, 0,
						" No se a configurado la ruta predeterminada para la exportar archivos " + " !ERROR APP! ", " Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);
				}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			codigoSucursal = objDatos_Gene[0].CodigoSucursal.ToString();
			if(codigoSucursal.Trim().Length==0)
			{
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 2, 0,
						" No se a configurado el codigo de la sucursal " + " !ERROR APP! ", " Error! Por favor Configure el codigo de la sucursal en Administrativo > Panel de control > Datos generales > Comfiguración > Código Sucursal, gracias. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);
				}
				#endregion
				return " Error! Por favor Configure el codigo de la sucursal en Administrativo > Panel de control > Datos generales > Comfiguración > Código Sucursal, gracias.";

			}
			//codigoSucursal = codigoSucursal.PadLeft(3,'0');
			nombreArchivo = "EDS" +
							codigoSucursal.PadLeft(3,'0') +
							fechaInicio.ToString("ddMMyyyy") + 
							".CSV";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region generar archivo
			try
			{
				Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
				sql.Append("rptControlLecturasTurnos");
				sql.ParametersNumber = 7;
				sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicio);			
				sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFin);			
				if(codigoManguera != 0)
					sql.AddParameter("@cod_man", SqlDbType.VarChar, codigoManguera.ToString());			
				if(codigoIsla != 0)
					sql.AddParameter("@cod_isl", SqlDbType.VarChar, codigoIsla.ToString());			
				if(numeroTurno != 0)
					sql.AddParameter("@num_tur", SqlDbType.VarChar, numeroTurno.ToString());			
				if(idArticulo != 0)
					sql.AddParameter("@IdArticulo", SqlDbType.SmallInt,  idArticulo.ToString());	
				if(consolidado)
					sql.AddParameter("@Consolidado", SqlDbType.Int, 1);					

				DataSet ds = null;
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				if(ds == null || ds.Tables[0].Rows.Count == 0)
					return("No se encontraron registros en la busqueda!");
				
				for(int i=0; i< ds.Tables[0].Rows.Count; i++)
				{
					filaTexto = codigoSucursal + separador;  //codigo de la estacion
					filaTexto += ds.Tables[0].Rows[i][0].ToString() + " " + ds.Tables[0].Rows[i][1].ToString() + separador; //hora y fecha
					filaTexto += ds.Tables[0].Rows[i][2].ToString() + separador; //turno
					filaTexto += ds.Tables[0].Rows[i][3].ToString() + separador; //isla
					filaTexto += ds.Tables[0].Rows[i][4].ToString() + separador; //manguera
					
					filaTemporal = ds.Tables[0].Rows[i][5].ToString().Replace(",","."); //lectura inicial					
					filaTexto += filaTemporal.Substring(0,filaTemporal.Length -1) + separador; 
					
					filaTemporal = ds.Tables[0].Rows[i][6].ToString().Replace(",","."); //lectura final
					filaTexto += filaTemporal.Substring(0,filaTemporal.Length -1) + separador; 

					filaTemporal = ds.Tables[0].Rows[i][7].ToString() == "0"?"0.000":ds.Tables[0].Rows[i][7].ToString().Replace(",","."); //Consumo
					filaTexto += filaTemporal.Substring(0,filaTemporal.Length -1) + separador; 

					filaTemporal = ds.Tables[0].Rows[i][8].ToString() == "0"?"0.000":ds.Tables[0].Rows[i][8].ToString().Replace(",","."); //Ventas
					filaTexto += filaTemporal.Substring(0,filaTemporal.Length -1); 

					writer.WriteLine(filaTexto);
				}
			
				writer.Close();

			}
			catch(Exception exception)
			{
				GuardarAuditoriaError("Error al generar el archivo de Lecturas de turnos! " + exception.Message.ToString());
				throw new Exception ("Error al generar el archivo de Lecturas de turnos! " + exception.Message.ToString());
			}	

			return "OK," + nombreArchivo; 
			#endregion
		}
		#endregion

		#region LimpiarDirectorio
		/// <summary>
		/// Borra los archivos de planos existentes en el directorio de la aplicación
		///<param name="directorio">Directorio a elimiar archivos</param>
		///<param name="opcion">1: Archivos de casamotor, 2: Cualquier archivo txt, 3 El nombre del archivo que se especifique</param>
		///<param name="extencionArchivos">Eliminar los archivos de extencion ej "*.txt"</param>
		/// </summary>
		private static void  LimpiarDirectorio(string directorio,int opcion,string extencionArchivos)
		{
			string [] nombreArchivo;
			try
			{
				if(opcion == 3)
				{
					try
					{

						System.IO.File.Delete(directorio);						
					}
		
					catch(Exception)
					{}
					return;
				}
				System.IO.Directory.CreateDirectory(directorio);
				string [] arreglo = System.IO.Directory.GetFiles(directorio,extencionArchivos);
				foreach(string c in arreglo)
				{
					nombreArchivo = c.Split("\\".ToCharArray());
					if(opcion == 1)
					{
						if(nombreArchivo[nombreArchivo.Length -1] == "SERVIPUNTO_MTO_CLIENTES.txt" || nombreArchivo[nombreArchivo.Length -1] == "SERVIPUNTO_MTO_AUTOMOTORES.txt" || nombreArchivo[nombreArchivo.Length -1] == "SERVIPUNTO_MTO_IDENTIFICADORES.txt" || nombreArchivo[nombreArchivo.Length -1] == "SERVIPUNTO_MTO_RESTRICCION.txt")
						{
							try
							{
								System.IO.File.Delete(c);
							}
							catch(Exception ex)
							{
								GuardarAuditoriaError("Error al eliminar el archivo: '" + c + "'" + ex.Message);
							}
						}
					}
					else if(opcion == 2)
					{
						try
						{
							System.IO.File.Delete(c);
						}
						catch(Exception){}

					}
					
				}
			}
			catch(Exception)
			{
				//throw new Exception (exepcion.Message);
				GuardarAuditoriaError("Error al eliminar los archivos de: '" + directorio + "'");
			}

		}
		#endregion

		#region guardar auditoria de errores
		/// <summary>
		/// Guarda la auditoria de errores
		///<param name="informacion">Cadena de texto de la información que se quiere guardar como informacion del error</param>
		/// </summary>
		private static void GuardarAuditoriaError(string informacion)
		{
			#region registro del log de errores
			try
			{
				Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
					2, 0,
					informacion + " !ERROR APP! ", " Error con archivos planos. ");
			}
			catch(Exception)
			{}
			#endregion
		}
		#endregion
	}
}
