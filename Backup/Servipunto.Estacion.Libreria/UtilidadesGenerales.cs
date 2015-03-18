using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Utilidades varias de tipo general.
	/// </summary>
	public class UtilidadesGenerales
	{
		#region Sección de Declaraciones
		private string _parametro1;
		private string _parametro2;
		#endregion

		#region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		public UtilidadesGenerales()
		{
		}
		#endregion

		#region Propiedades Públicas
		/// <summary>
		/// Parametro 1
		/// </summary>
		public string Parametro1
		{
			get { return this._parametro1; }
			set { this._parametro1 = value; }
		}

		#region Propiedades Públicas
		/// <summary>
		/// Parametro 2
		/// </summary>
		public string Parametro2
		{
			get { return this._parametro2; }
			set { this._parametro2 = value; }
		}

		#endregion
		#endregion

		#region metodos publicos

		#region Mantenimiento
		/// <summary>
		///  Opciones para realizar mantenimiento a la base de datos
		/// </summary>
		/// <param name="nombreBD">Nombre de la base de datos a respaldar</param>
		/// <param name="rutaGuardar">Ruta donde se guardará la copia de la base de datos</param>
		/// <param name="opcion">Opcion a realizar 1: BackUp, 2: Indexar, 3: Restaurar Log</param>
		public static void Mantenimiento(string nombreBD, string rutaGuardar, int opcion)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("Mantenimiento");
			sql.ParametersNumber = 3;
			sql.AddParameter("@NombreBD", SqlDbType.VarChar, nombreBD);
			sql.AddParameter("@Ruta", SqlDbType.VarChar, rutaGuardar);
			sql.AddParameter("@Opcion", SqlDbType.Int, opcion);
			#endregion

			#region Execute SqlCommand
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch(SqlException exx)
			{
				throw new Exception(exx.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion

		}
		#endregion

		#region Crear Directorios
		/// <summary>
		///  Crea una ruta de directorios
		/// </summary>
		/// <param name="ruta">Ruta a crear</param>
		/// <param name="opcion">Opcion a realizar 1: Ruta simple de directorio, 2: Ruta de directorio + archivo</param>

		public static void CrearDirectorio(string ruta, int opcion)
		{	
			string [] arreglo;
			string directorio = "";
			try
			{
				if(opcion == 1)
					System.IO.Directory.CreateDirectory(ruta);
				else if(opcion == 2)
				{
					arreglo = ruta.Split("\\".ToCharArray());
					for(int i=0; i< arreglo.Length-1; i++)
					{
						if(i > 0)
							directorio += "\\";
						directorio += arreglo[i].ToString();
				
					}
					System.IO.Directory.CreateDirectory(directorio);
				}
			}
			catch(Exception ex)
			{}

		}

		#endregion

		#region Devolver solo numero 
		/// <summary>
		/// devuelve solo los caracteres numericos de una cadanena
		/// </summary>
		/// <param name="cadena">Cadena a ser analizada</param>
		public static string SoloNumeros(string cadena)
		{
			string nuevaCadena="";
			char [] arreglo;
			arreglo = cadena.ToCharArray(0,cadena.Length);
			for(int i=0; i< arreglo.Length; i++)
				if(arreglo[i]>=48 && arreglo[i]<=57)
					nuevaCadena +=  arreglo[i];

			return nuevaCadena;
		}

		#endregion

		#region Mover un archivo a la ruta predeterminada de Planos procesados de datos generales
		/// <summary>
		/// Mueve un archivo a la ruta predeterminada de Planos procesados de datos generales
		/// </summary>
		/// <param name="rutaYArchivoOrigen">Ruta del archivo a ser movido</param>
		/// <param name="nuevoNombre">Nombre con el que será renombrado</param>
		/// <param name="extraerNombre">Al nuevo nombre le anexara el nombre del archivo origen</param>
		public static string MoverArchivoAProcesados(string rutaYArchivoOrigen,string nuevoNombre, bool extraerNombre)
		{
			#region declaracion de variables
			string [] nombreArchivoOrigen = rutaYArchivoOrigen.Split("\\".ToCharArray());
			Libreria.Configuracion.Dat_Gene  objdat_gene = Libreria.Configuracion.Datos_Gene.ObtenerItem();
			#endregion

			#region mover archivo

			try
			{
				System.IO.Directory.CreateDirectory(objdat_gene.RutaPlanoVentasProcesadas);
			}
			catch(Exception)
			{
			}
			
			if(extraerNombre)
				nuevoNombre = nuevoNombre + nombreArchivoOrigen[nombreArchivoOrigen.Length-1].ToString();
			try
			{
				System.IO.File.Move(rutaYArchivoOrigen,objdat_gene.RutaPlanoVentasProcesadas + "\\" + nuevoNombre);
			}
			catch(Exception ex)
			{
				return " Error al mover el archivo a la ruta de archivo procesados, " + ex.ToString();
			}
			return "";
			#endregion
		}


		#region Mover un archivo a la ruta GDO
		/// <summary>
		/// Mueve un archivo a la ruta predeterminada de Planos procesados de datos generales
		/// </summary>
		/// <param name="rutaYArchivoOrigen">Ruta del archivo a ser movido</param>
		/// <param name="nuevoNombre">Nombre con el que será renombrado</param>
		/// <param name="extraerNombre">Al nuevo nombre le anexara el nombre del archivo origen</param>
		public static string MoverArchivoAProcesadosGDO(string rutaYArchivoOrigen,string nuevoNombre, bool extraerNombre)
		{
			#region declaracion de variables
			string [] nombreArchivoOrigen = rutaYArchivoOrigen.Split("\\".ToCharArray());
			string RutaPlanoprocesado = "c:\\servipunto\\administ\\procesados";			
			#endregion

			#region mover archivo

			try
			{
				System.IO.Directory.CreateDirectory(RutaPlanoprocesado);
			}
			catch(Exception)
			{
			}			

			if(extraerNombre)
				nuevoNombre = nuevoNombre + nombreArchivoOrigen[nombreArchivoOrigen.Length-1].ToString();
			
			
			try
			{
				System.IO.File.Move(rutaYArchivoOrigen,RutaPlanoprocesado + "\\" + nuevoNombre);
			}
			catch(Exception ex)
			{
				return " Error al mover el archivo a la ruta de archivo procesados, " + ex.ToString();
			}
			return "";
			#endregion
		}
		#endregion


		#endregion

		#region Mover archivos normales
		/// <summary>
		/// Mueve el archivo especifico desde un directorio origen a un directorio destino
		/// </summary>
		///<param name="archivoOrigen">Ruta y nombre del archivo origen</param>
		///<param name="DirectorioDestino">Directorio destino</param>
		///<param name="adicionarFechaHora">Define si sera adicionada la fecha y hora al nombre del archivo</param>
		///<param name="eliminarDirectorioAdicional">Directorio a eliminar</param>
	//	///<param name="sobrescribir">Define si en caso que exista el archivo destino sera sobrescrito automaticamente</param>				
		public static string MoverArchivo(string archivoOrigen,
			string DirectorioDestino, 
			bool adicionarFechaHora, 
			string eliminarDirectorioAdicional
			//bool sobrescribir
			)
		{
			try
			{
				string nuevoNombre; 
				if(!File.Exists(archivoOrigen))
					throw new Exception("El archivo '" + archivoOrigen  + "' no existe para ser movido al directorio '" + DirectorioDestino + "'");               
				if(!Directory.Exists(DirectorioDestino))
					Directory.CreateDirectory(DirectorioDestino);
				if(adicionarFechaHora)
				{
					nuevoNombre = Path.GetFileName(Path.GetFileNameWithoutExtension(archivoOrigen));
					nuevoNombre += "_" + System.DateTime.Now.ToString("ddMMyyyyHHmmss");
					nuevoNombre += Path.GetExtension(archivoOrigen);
					nuevoNombre = DirectorioDestino + "\\" + nuevoNombre;
				}
				else
					nuevoNombre = DirectorioDestino + "\\" + Path.GetFileName(archivoOrigen);
				//if(sobrescribir)
				//{
					try
					{
						File.Delete(nuevoNombre);
					}
					catch(Exception ex)
					{
					}
				//}
				File.Move(archivoOrigen,nuevoNombre);
				if(eliminarDirectorioAdicional.Length > 0)
				{
					try
					{
						if(Directory.Exists(eliminarDirectorioAdicional))
							Directory.Delete(eliminarDirectorioAdicional,true);
					}
					catch(Exception)
					{}
				}
				return nuevoNombre;
				}
				catch(Exception ex)
				{
					throw new Exception("Error al mover el archivo '" + archivoOrigen + "' a la ruta '" + DirectorioDestino + "'" + ex.Message);

				}			
		}

		#endregion

		#region Descomprimir archivos 
		/// <summary>
		/// Descomprime los archivos de un archivo zip en el directirio que se especifique
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	05/05/2008 12:00 PM
		/// </summary>
		///<param name="directorioTemporal">Directorio donde se colocaran los archivos descompresos</param>
		///<param name="rutaArchivoZip">Ruta y nombre del archivo Zip a descomprimir</param>
		///<param name="limpiarDirectorioTemporal">Elimina los archivos contenidos en el directorio temporal</param>
		public static void DescomprimirArchivos(string directorioTemporal,string rutaArchivoZip,bool limpiarDirectorioTemporal)
		{
			#region declaraciones
			ZipUtil objZip = new ZipUtil();
			#endregion

			#region descomprimir
			if(!File.Exists(rutaArchivoZip))
				throw new Exception("El archivo '" + rutaArchivoZip  + "' no existe");               
			if(limpiarDirectorioTemporal)
				if(Directory.Exists(directorioTemporal))
					Directory.Delete(directorioTemporal,true);
			if(!Directory.Exists(directorioTemporal))
				Directory.CreateDirectory(directorioTemporal);

			objZip.Descomprimir(directorioTemporal,rutaArchivoZip,false,false);
			#endregion
		}
		#endregion
		
		#region Comprimir archivos 
		/// <summary>
		/// Comprime los archivos en un archivo zip en el directirio que se especifique
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	05/05/2008 12:00 PM
		/// </summary>
		///<param name="archivosAComprimir">Lista de archivos a comprimir</param>
		///<param name="rutaArchivoZip">Ruta y nombre del archivo Zip a generar</param>
		///<param name="elimiarFuentes">Elimina los archivos compresos</param>
		public static void ComprimirArchivos(ArrayList archivosAComprimir,string rutaArchivoZip, bool elimiarFuentes)
		{
			#region declaraciones
			ZipUtil objZip = new ZipUtil();
			string[] arregloArchivos = (string[])archivosAComprimir.ToArray(typeof(string));
			#endregion

			#region Comprimir
			if(arregloArchivos.Length == 0)
				return;

			if(File.Exists(rutaArchivoZip))
			{
				if(MessageBox.Show("El archivo '" + rutaArchivoZip + "' ya existe, desea continuar y remplazar el archivo existente?","Remplazar...",MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==  DialogResult.Yes)
					File.Delete(rutaArchivoZip);
				else
					goto EliminarArchivos;
			} 
			if(!Directory.Exists(Path.GetDirectoryName(rutaArchivoZip)))
				Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivoZip));

			objZip.Comprimir(arregloArchivos,rutaArchivoZip,false);
			#endregion

			#region eliminar archivos

			EliminarArchivos:
				if(elimiarFuentes)
				{
					for(int i=0; i<arregloArchivos.Length; i++)
					{
						try
						{
							File.Delete(arregloArchivos[i].ToString());
						}
						catch(Exception)
						{}
					}
				
				}
			#endregion

			
		}
		#endregion

		#region Comprimir directorio
		/// <summary>
		/// Comprime el directorio en un archivo ZIP
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	05/05/2008 12:00 PM
		/// </summary>
		///<param name="directorioAComprimir">Ruta del directorio a comprimir</param>
		///<param name="rutaArchivoZip">Ruta y nombre donde se colocara el archivo ZIP</param>
		///<param name="elimiarFuentes">Elimina el directorio fuente luego de ser compreso</param>
		public static void ComprimirDirectorio(string directorioAComprimir,string rutaArchivoZip, bool elimiarFuentes)
		{
			#region declaraciones
			ZipUtil objZip = new ZipUtil();
			#endregion

			#region Comprimir

			if(File.Exists(rutaArchivoZip))
			{
				if(MessageBox.Show("Remplazar...","El archivo '" + rutaArchivoZip + "' ya existe, desea continuar y remplazar el archivo existente?",MessageBoxButtons.YesNo) ==  DialogResult.Yes)
					File.Delete(rutaArchivoZip);
				else
					goto EliminarArchivos;
			} 
			if(!Directory.Exists(Path.GetDirectoryName(rutaArchivoZip)))
				Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivoZip));

			objZip.Comprimir(directorioAComprimir,"*.*",rutaArchivoZip,false);
			#endregion

			#region eliminar directorio

			EliminarArchivos:
				if(elimiarFuentes)
					Directory.Delete(directorioAComprimir,true);
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
		public static void  LimpiarDirectorio(string directorio,int opcion,string extencionArchivos)
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
								throw new Exception("Error al eliminar el archivo: '" + c + "'" + ex.Message);
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
				throw new Exception("Error al eliminar los archivos de: '" + directorio + "'");
				//GuardarAuditoriaError("Error al eliminar los archivos de: '" + directorio + "'");
			}

		}
		#endregion

		#region Guarda log AdministradorArchivo
		/// <summary> 
		/// Guarda en el archivo C:\\Servipunto\\Estacion\\LogAdministradorArchivos algun problema que se haya generado
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	06/05/2008 12:00 PM
		/// </summary>
		///<param name="informacion">Cadena de texto de la información que se quiere guardar en el log</param>		
		///<param name="idSuceso">Posible suceso que genero el error</param>		
		public static void EscribirLogYAuditoriaAdministradorArchivos(string informacion, Int64 idSuceso)
		{
			#region registro del lod de errores en archivo
			try
			{ 
				UtilidadesGenerales.EscribirArchivoLog("C:\\Servipunto\\Estacion\\LogAdministradorArchivos" + DateTime.Now.ToString("ddMMyyyy") + ".txt", informacion);
			}
			catch(Exception)
			{}
			#endregion
 
			#region registro del log de errores en auditoria
			if(informacion.LastIndexOf("ERROR BD") == -1 && informacion.LastIndexOf("ERROR APP") == -1)
				informacion += " !ERROR APP! ";
			try
			{ 
				Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
					1, idSuceso,
					informacion, " Error con el modulo Administrador de Archivos. ");
			}
			catch(Exception)
			{}
			#endregion
		}
		#endregion
		
		#region Crear archivo log
		/// <summary>
		/// Realiza un log de sucesos en un determinado archivo
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	06/05/2008 12:00 PM
		/// </summary>
		///<param name="rutaArchivo">Directorio y nombre del archivo donde se escribira</param>
		///<param name="informacion">Informacion de tipo texto a guardar en el archivo</param>		
		public static void EscribirArchivoLog(string rutaArchivo, string informacion)
		{ 
			if(!Directory.Exists(Path.GetDirectoryName(rutaArchivo)))
				Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));
			try
			{
				FileStream stream = new FileStream(rutaArchivo, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				writer.WriteLine("");
				writer.WriteLine(DateTime.Now + " Resultado - > " + informacion);
				writer.Close();
 
			}
			catch(Exception)
			{}
		}
		#endregion

		#region Estructura archivos planos flexibles

		#region ActualizarEstructuraPlano
		/// <summary>
		/// Actualiza la ubicacion y el tamaño de la columna para un arhivo plano flexible
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	11/07/2008 10:00 AM
		/// </summary>
		///<param name="idEstructuraPlano">Identificador del registro</param>
		///<param name="orden">Posicion de la columna en el archivo</param>
		///<param name="tamañoSeleccionado">Tamaño seleccionado de la columna</param>
		///<param name="asciiRelleno">Codigo ascii que representa el caracter de relleno</param>
		///<param name="rellenoDireccion">Direccion del relleno 1: Izquierdo, 2:Derecho</param>
		///<param name="valor">Valor adicional de los parametros</param>
		public static void ActualizarEstructuraPlano(int idEstructuraPlano,
												Int16 orden,
												Int16 tamañoSeleccionado,
												Int16 asciiRelleno,
												Int16 rellenoDireccion,
												string valor
												)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ActualizarEstructuraPlano");
			sql.ParametersNumber = 6;
			sql.AddParameter("@IdEstructuraPlano", SqlDbType.Int, idEstructuraPlano);
			sql.AddParameter("@Orden", SqlDbType.SmallInt, orden);
			sql.AddParameter("@TamañoSeleccionado", SqlDbType.SmallInt, tamañoSeleccionado);
			sql.AddParameter("@AsciiRelleno", SqlDbType.SmallInt, asciiRelleno);
			sql.AddParameter("@RellenoDireccion", SqlDbType.SmallInt, rellenoDireccion);
			if(valor.Length > 0)
				sql.AddParameter("@Valor", SqlDbType.VarChar, valor);

			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
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

		/// <summary>
		/// Actualiza el separador, formato de fecha, nombre de archivo u otros para un archivo plano flexible
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	11/07/2008 10:00 AM
		/// </summary>
		///<param name="idEstructuraPlano">Identificador del registro</param>
		///<param name="nombre">Nuevo formato de fecha, nombre de archivo u otros</param>
		public static void ActualizarEstructuraPlano(int idEstructuraPlano,
													string nombre
													)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ActualizarEstructuraPlano");
			sql.ParametersNumber = 2;
			sql.AddParameter("@IdEstructuraPlano", SqlDbType.Int, idEstructuraPlano);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, nombre);
			#endregion

			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
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

		#region RecuperarEstructuraPlano
		/// <summary>
		/// Recupera la configuracion de un archivo plano flexible
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	11/07/2008 10:00 AM
		/// </summary>
		///<param name="idEstructuraPlano">Identificador del registro</param>
		///<param name="nombre">Nuevo formato de fecha, nobre de archivo u otros</param>
		///<param name="tipoUso">Enviar el siguiente texto para Identifica si se recuperara Ej; 'Columna','Separador','FormatoFecha','NombreArchivo','AnchoFijo'</param>
		///<param name="tipoArchivo">Tipo de archivo a recuperar la estructura, Ej; 'FacturaEstandar'</param>
		public static DataSet RecuperarEstructuraPlano(int idEstructuraPlano,
			string nombre,
			string tipoUso,
			string tipoArchivo
			)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarEstructuraPlano");
			sql.ParametersNumber = 4;
			if(idEstructuraPlano != 0)
				sql.AddParameter("@IdEstructuraPlano", SqlDbType.Int, idEstructuraPlano);
			if(nombre.Trim().Length > 0)
				sql.AddParameter("@Nombre", SqlDbType.VarChar, nombre);
			if(tipoUso.Trim().Length > 0)
				sql.AddParameter("@TipoUso", SqlDbType.VarChar, tipoUso);
			if(tipoArchivo.Trim().Length > 0)
				sql.AddParameter("@TipoArchivo", SqlDbType.VarChar, tipoArchivo);

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

		#region Utilidades ListBox
		/// <summary>
		/// Desplaza un registro seleccionado de un listbox hacia otro listbox
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	12/07/2008 10:00 AM
		/// </summary>
		///<param name="lstOrigen">ListBox con el registro origen</param>
		///<param name="lstDestino">ListBox con el registro Destino</param>
		public static void ListBoxDesplazarHorizontal(System.Web.UI.WebControls.ListBox lstOrigen, System.Web.UI.WebControls.ListBox lstDestino)
		{
			if(lstOrigen.SelectedIndex >= 0)
			{
				lstDestino.Items.Add(new ListItem(lstOrigen.SelectedItem.ToString(),lstOrigen.SelectedValue));
				lstOrigen.Items.RemoveAt(lstOrigen.SelectedIndex);
			}
			return;
		}
		/// <summary>
		/// Desplaza un registro seleccionado hacia arriba o hacia abajo en un listbox
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	12/07/2008 10:00 AM
		/// </summary>
		///<param name="lstOrigen">ListBox con el registro origen seleccionado</param>
		///<param name="incremento">-1; un icremento hacia arriba, 1; un incremento hacia abajo</param>
		public static void ListBoxDesplazarVertical(System.Web.UI.WebControls.ListBox lstOrigen, int incremento)
		{
			int seleccionado;
			if(incremento < 0 && lstOrigen.SelectedIndex <= 0)
				return;
			if(incremento > 0 && lstOrigen.SelectedIndex >= lstOrigen.Items.Count - 1)
				return;

			seleccionado = lstOrigen.SelectedIndex;		
			ListItem origen = new ListItem(lstOrigen.SelectedItem.Text,lstOrigen.SelectedValue);
			lstOrigen.SelectedIndex = seleccionado + incremento;
			ListItem destino = new ListItem(lstOrigen.SelectedItem.Text,lstOrigen.SelectedValue);				
			lstOrigen.Items[seleccionado].Text = destino.Text;
			lstOrigen.Items[seleccionado].Value = destino.Value;
			
			lstOrigen.Items[seleccionado + incremento].Text = origen.Text;
			lstOrigen.Items[seleccionado + incremento].Value = origen.Value;
		}

		#endregion

		#region FormatearEstructura 
		/// <summary>
		/// Retorna una fila organizada dinamicamente de acuerdo a una estructura
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	14/07/2008 12:00 PM
		/// </summary>
		///<param name="cadena">Cadena de texto con los datos a dar formato</param>
		///<param name="separadorInterno">Separador de las columnas en la cadena enviada</param>
		///<param name="estructuraPlano">Matriz con la estructura establecida de cada columna para generar el plano "codigocolumna(0), orden(1), tamaño(2), Mascara(3), AsciiSeparador(4), DireccionSeparador(5)"</param>
		///<param name="anchoFijo">Define si la columna sera rellenada hasta alcanzar un ancho fijo</param>
		///<param name="separadorDecimal">Define el separador para decimales</param>
		///<param name="formatoFecha">Define el formato con que se generara la fecha</param>
		///<param name="separadorConfigurado">Define el separador de columnas que se escribira en el archivo</param>
		///<param name="respetarSoloEspacios">Define si el proceso respetara los campos que solo tienen espacios en blanco</param>
		public static string FormatearEstructura(
			string cadena, 
			string separadorInterno, 											
			Int16 [,] estructuraPlano, 
			bool anchoFijo, 
			string separadorDecimal, 
			string formatoFecha,
			string separadorConfigurado,
			bool respetarSoloEspacios							
			)
		{
			string cadenaAux = cadena;
			string [] arreglo;
			string cadenaTemp;
			DateTime fecha; 
			try
			{
				
				arreglo = cadena.Split(separadorInterno.ToCharArray());
				cadena = "";				
				for(int i=0; i < estructuraPlano.GetLength(0); i++)
				{					
					if(estructuraPlano[i,1] > 0) //si el orden es mayor a 0 quiere decir que hay que incluirlo, ya llega en orden
					{	
						cadenaTemp = arreglo[estructuraPlano[i,0]-1].ToString(); //obtiene el codigo de la columna para vincularlo con el dato del arreglo y obtiene el dato del arreglo
						if(respetarSoloEspacios) //si el campo solo tiene espacios en blanco y esta configurado que los respete aqui hace el proceso de respeto
						{
							for(int j=0; j<cadenaTemp.Length; j++)
							{
							//<< JTORRES 068/09/2011 //if (cadenaTemp.Substring(j, 1) != " ") // genera conflicto cuando viene con carateres en blanco  >>
									goto Continuar1; //quita los espacios porque tiene caracteres diferentes al espacion
							}
							goto Continuar2; //respeta los espacios porque solo contiene espacios
						}
					Continuar1:
						cadenaTemp = cadenaTemp.Trim();
					Continuar2:												
						if(estructuraPlano[i,3] == 1) // si tiene separador decimal
						{
							if(cadenaTemp.IndexOf(",") > 0)
								cadenaTemp = cadenaTemp.Replace(",",separadorDecimal);
							else
								cadenaTemp = cadenaTemp.Replace(".",separadorDecimal);
						}
						else if(estructuraPlano[i,3] == 2) // si tiene mascara de fecha
						{
							fecha = DateTime.ParseExact(arreglo[estructuraPlano[i,0]-1].ToString().Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);							
							cadenaTemp = formatoFecha.Replace("DD",fecha.ToString("dd")).Replace("MM",fecha.ToString("MM")).Replace("YYYY",fecha.ToString("yyyy")).Replace("HH",fecha.ToString("HH")).Replace("mm",fecha.ToString("mm")).Replace("SS",fecha.ToString("ss"));							
							cadenaTemp = cadenaTemp.Replace("YY",fecha.ToString("yy"));
						}

						if(anchoFijo) //si utiliza ancho fijo
						{
							if(estructuraPlano[i,5] == 1) //si es relleno izquierdo
								cadenaTemp = cadenaTemp.PadLeft(estructuraPlano[i,2],Convert.ToChar(estructuraPlano[i,4]));
							else //si es relleno derecho
								cadenaTemp = cadenaTemp.PadRight(estructuraPlano[i,2],Convert.ToChar(estructuraPlano[i,4]));
						}
						cadenaTemp += separadorConfigurado;
						cadena += cadenaTemp;
					}					
				}
			}
			catch(Exception ex)
			{
				string a = ex.Message.ToString();
				cadena = cadenaAux;
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, 0,   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno realizando el archivo plano de facturas. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);

				}
				#endregion
			}
			if(cadena.Length - separadorConfigurado.Length > 0 ) //elimina el ultimo separador
				cadena = cadena.Substring(0,cadena.Length - separadorConfigurado.Length);
			return cadena;
		}



		#endregion

		#endregion

		#region Filtrar nombres de archivos con determinada mascara
		/// <summary>
		/// Filtra los nombres de archivos que cumplan con una mascara determinada
		/// Autor:			Ing. Elvis Astaiza Gutierrez
		/// Fecha Creacion:	01/05/2008 12:00 PM
		/// </summary>
		///<param name="directorio">Directorio donde se encuentran los archivos</param>
		///<param name="mascara">Mascara que determina el nombre del archivo con los caracateres '@'=Cualquier caracter del alfabeto, '#'= cualquier caracter numerico, '?'=otro caracter en especial Ej:'E###@' = 'E584b'</param>
		///<param name="extencion">Extencion de los archivos ej "*.txt"</param>		
		public static ArrayList FiltrarArchivos(string directorio, string mascara, string extencion)
		{

			string[] arregloArchivos = System.IO.Directory.GetFiles(directorio, extencion);
			string[] nombreArchivo;
			char[] nombreAnalizar;
			ArrayList ArchivosAptos = new ArrayList();
			bool apto;
			string caracterActual;
			for (int i = 0; i < arregloArchivos.Length; i++)
			{
				nombreArchivo = arregloArchivos[i].ToString().Split('\\');
				nombreAnalizar = nombreArchivo[nombreArchivo.Length - 1].ToString().ToCharArray();
				if (nombreAnalizar.Length == (mascara.Length + extencion.Length - 1)) //compara caracter del archivo con el de la mascara
				{
					apto = true;
					for (int j = 0; j < mascara.Length; j++)
					{
						caracterActual = mascara.Substring(j,1);
						switch (caracterActual)
						{
							case "#": //verfica que sea numerico
								if (!(nombreAnalizar[j] >= 48 && nombreAnalizar[j] <= 57))
									apto = false;
								break;

							case "@": //verifica que sea un exactamente un caracter del alfabeto
								if (!((nombreAnalizar[j] >= 65 && nombreAnalizar[j] <= 90) || (nombreAnalizar[j] >= 97 && nombreAnalizar[j] <= 122)))
									apto = false;
								break;
                            
							default: //verifica que sea un caracter en especial
								if (nombreAnalizar[j].ToString().ToUpper() != caracterActual.ToUpper())
									apto = false;
								break;
						}
						if (!apto)
							break;
					}
					if(apto)
						ArchivosAptos.Add(arregloArchivos[i].ToString());
				}
			}
			return ArchivosAptos;
		}
		#endregion

		#endregion


        
	
	}
}
