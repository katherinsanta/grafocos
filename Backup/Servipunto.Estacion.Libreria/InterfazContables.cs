using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Text;
using System.Collections;
using HardTech.Components.HardLibrary;



namespace Servipunto.Estacion.Libreria.Planos
{
	/// <summary>
	/// Summary description for InterfazContables.
	/// </summary>
	public class InterfazContables : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idInterfaz = null;		
		private static bool _fallaArchivo;
		int _numeroRegistro;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todas las Configuraciones de generación de archivos planos
		/// </summary>
		public InterfazContables()
		{ }		
		/// <summary>
		/// Consulta una configuración en específico de configuración (Reservada para uso futuro)
		/// </summary>
		/// <param name="idInterfaz"></param>
		internal InterfazContables(int idInterfaz)
		{
			this._idInterfaz = idInterfaz;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por llave
		/// </summary>
		new public InterfazContable this[string key]
		{
			get { return (InterfazContable)base[key];}
		}
		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public InterfazContable this[int index]
		{
			get { return (InterfazContable)base[index];}
		}
		#endregion

		#region Event Load
		/// <summary>
		/// Recuperación de información contenida en la tabla InterfazContable que sirve de configuración para la generación de 
		/// archivos planos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e)
		{
			#region Prepara el Estamento SQL
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ConsultarIContable");
			#endregion

			#region Ejecución del Estamento SQL
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				InterfazContable objInterfazContable = new InterfazContable();
				objInterfazContable.IDInterfaz = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
				objInterfazContable.NCAbono = dr.IsDBNull(1) ? "Sin definir" : dr.GetString(1);
				objInterfazContable.NATAbono = dr.IsDBNull(2) ? false : dr.GetBoolean(2);
				objInterfazContable.NTAbono = dr.IsDBNull(3) ? false : dr.GetBoolean(3);
				objInterfazContable.NCDescuento = dr.IsDBNull(4) ? "Sin definir" : dr.GetString(4);
				objInterfazContable.NATDescuento = dr.IsDBNull(5) ? false : dr.GetBoolean(5);
				objInterfazContable.NTDescuento = dr.IsDBNull(6) ? false : dr.GetBoolean(6);
				objInterfazContable.NCIva = dr.IsDBNull(7) ? "Sin definir" : dr.GetString(7);
				objInterfazContable.NATIva = dr.IsDBNull(8) ? false : dr.GetBoolean(8);
				objInterfazContable.NTIva = dr.IsDBNull(9) ? false : dr.GetBoolean(9);
				objInterfazContable.CODCentroCostos = dr.IsDBNull(10) ? "Sin definir" : dr.GetString(10);
				objInterfazContable.NUMCompFacturas = dr.IsDBNull(11) ? "Sin definir" : dr.GetString(11);
				objInterfazContable.CODSucursal = dr.IsDBNull(12) ? "Sin definir" : dr.GetString(12);
				objInterfazContable.NCVentasGNV = dr.IsDBNull(13) ? "Sin definir" : dr.GetString(13);
				objInterfazContable.NATVentasGNV = dr.IsDBNull(14) ? false : dr.GetBoolean(14);
				objInterfazContable.NTVentasGNV = dr.IsDBNull(15) ? false : dr.GetBoolean(15);
				objInterfazContable.NCVentasCanas = dr.IsDBNull(16) ? "Sin definir" : dr.GetString(16);
				objInterfazContable.NATVentasCanas = dr.IsDBNull(17) ? false : dr.GetBoolean(17);
				objInterfazContable.NTVentasCanas = dr.IsDBNull(18) ? false : dr.GetBoolean(18);

				objInterfazContable.ClasedePedido_Sap = dr.IsDBNull(19) ? "Sin definir" : dr.GetString(19);
				objInterfazContable.OrganizaciondeVentas_Sap = dr.IsDBNull(20) ? "Sin definir" : dr.GetString(20);
				objInterfazContable.Canal_Sap = dr.IsDBNull(21) ? "Sin definir" : dr.GetString(21);
				objInterfazContable.Sector_Sap = dr.IsDBNull(22) ? "Sin definir" : dr.GetString(22);
				objInterfazContable.OficinadeVentas_Sap = dr.IsDBNull(23) ? "Sin definir" : dr.GetString(23);
				objInterfazContable.GrupodeVendedores_Sap = dr.IsDBNull(24) ? "Sin definir" : dr.GetString(24);
				objInterfazContable.Asignacion_Sap = dr.IsDBNull(25) ? "Sin definir" : dr.GetString(25);
				objInterfazContable.Cod_Cli_Contado_Sap = dr.IsDBNull(26) ? "Sin definir" : dr.GetString(26);
				objInterfazContable.Puesto_Exp_Sap = dr.IsDBNull(27) ? "Sin definir" : dr.GetString(27);
				objInterfazContable.Clase_Doc_Sap = dr.IsDBNull(28) ? "Sin definir" : dr.GetString(28);
				objInterfazContable.Sociedad_Sap = dr.IsDBNull(29) ? "Sin definir" : dr.GetString(29);
				objInterfazContable.Tipo_Moneda_Sap = dr.IsDBNull(30) ? "Sin definir" : dr.GetString(30);
				objInterfazContable.RutaImportarSap = dr.IsDBNull(31) ? "" : dr.GetString(31).Trim();
				objInterfazContable.RutaExportarSap = dr.IsDBNull(32) ? "" : dr.GetString(32).Trim();
				objInterfazContable.RutaImportarClientesCorporativos = dr.IsDBNull(33) ? "" : dr.GetString(33).Trim();
				objInterfazContable.CodigoEstacionSap = dr.IsDBNull(34) ? "" : dr.GetString(34).Trim();
				
				base.AddItem(objInterfazContable.IDInterfaz.ToString(), objInterfazContable);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Guarda log
		/// <summary>
		/// Guarda en el archivo c:\logServipuntoSap.txt algun problema que se haya generado
		///<param name="informacion">Cadena de texto de la información que se quiere guardar en el log</param>
		/// </summary>

		private static void EscribirLog(string informacion)
		{

			FileStream stream = new FileStream("d:\\logServipuntoSap.txt", FileMode.Append, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			writer.WriteLine(DateTime.Now + " Resultado - > " + informacion);
			writer.Close();

			#region registro del log de errores
			try
			{
				Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
					2, 0,
					informacion + " !ERROR APP! ", " Error con el sistema SAP. ");
			}
			catch(Exception)
			{}
			#endregion

		}
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

		#region Ajustar tamaños de datos fijos
		/// <summary>
		/// Ajusta el tamaño del dato a un determinado tamaño
		///<param name="cadena">Cadena de texto a la que se quiere fijar un tamaño</param>
		///<param name="tamañoMax">Tamaño maximo a convertir la cadena</param>
		/// </summary>
		private static string AjustarTamaño(string cadena, int tamañoMax)
		{
			int i=0;
			StringBuilder arreglo = new StringBuilder(cadena);
			string nuevaCadena="";

			while(nuevaCadena.Length < tamañoMax)
			{
				if(nuevaCadena.Length < cadena.Length)
				{
					nuevaCadena += arreglo[i];
				}
				else
				{
					nuevaCadena += " ";
				}
				i += 1;
			}
			return nuevaCadena;
		}
		#endregion

		#region Leer archivo plano
		/// <summary>
		/// Lee un archivo de plano y retorna su contenido en un ArrayList
		///<param name="nombreArchivo">Ruta y nombre del archivo a cargar</param>
		/// </summary>
		private static ArrayList LeerArchivo(string nombreArchivo)
		{

			string filaTexto="";
			ArrayList arreglo= new ArrayList();
			try
			{
				FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
				StreamReader reader = new StreamReader(stream);
				while (reader.Peek() > -1) 
				{
					filaTexto = reader.ReadLine();
					if(filaTexto.Trim().Length > 0)
						arreglo.Add(filaTexto);
					
				}
				reader.Close();
				return arreglo;
			}
			catch(Exception)
			{
				arreglo.Add("No existe el archivo");
				return arreglo;
				//throw new Exception (exception.Message);
			}



		}

		#endregion

		#region Validar Estructura de los archivos
		/// <summary>
		/// Valida el numero de columnas de un archivo plano
		/// </summary>
		///<param name="arreglo">Datos leidos del archivo</param>
		///<param name="totalColumnas">total de columnas que debe tener las filas del arreglo</param>
		///<param name="nombreArchivo">Nombre del archivo el cual se va a verificar</param>		
		private static void ValidarColumnas(ArrayList arreglo, int totalColumnas, string nombreArchivo)
		{
			#region Declaraciones
			string [] cadena;
			
			#endregion

			#region Validadora
			for(int i=0; i<arreglo.Count; i++) //recorre la lista para validar el numero de columnas de cada fila
			{
					
				cadena = arreglo[i].ToString().Split(";".ToCharArray());
				if(cadena.Length != totalColumnas)
				{
					EscribirLog("Error en la lina: '" + Convert.ToString(i+1) + "' El archivo debe tener '" + totalColumnas.ToString() + "' columnas '" + " y tiene '" + cadena.Length.ToString() + "'"+ nombreArchivo);
					_fallaArchivo = true;

				}

			}
			#endregion

		}
		
		/// <summary>
		/// Valida el numero de columnas de un archivo plano
		/// <summary>
		///<param name="arreglo">Datos leidos del archivo</param>
		///<param name="ColumnaAnalizar">Columna que sera analizada para ver si tiene datos repetidos</param>
		///<param name="nombreArchivo">Nombre del archivo el cual se va a verificar</param>		
		private static void ValidarDatoRepetido(ArrayList arreglo, int ColumnaAnalizar, string nombreArchivo)
		{
			#region Declaraciones
			string [] cadena;
			string valor1;
			string valor2;
			int repetidos;
			ArrayList arreglo2 = new ArrayList(arreglo);
			
			#endregion

			#region Validadora
			for(int i=0; i<arreglo.Count; i++) //recorre la lista para validar el numero de columnas de cada fila
			{
					
				cadena = arreglo[i].ToString().Split(";".ToCharArray());
				valor1 = cadena[ColumnaAnalizar];
				repetidos = 0;
				for(int j=0; j<arreglo2.Count; j++) //recorre la lista para validar el numero de columnas de cada fila
				{
					cadena = arreglo2[j].ToString().Split(";".ToCharArray());
					valor2 = cadena[ColumnaAnalizar];
					if(valor2==valor1)
					{
						repetidos = repetidos + 1;
						if(repetidos > 1)
						{
							EscribirLog("Error con el valor '" + valor1 + "' de la linea: '" + Convert.ToString(i+1) + "' Se encuentra repetido con el valor de la linea: '" + Convert.ToString(j+1) + "' de la columna: '" + Convert.ToString(ColumnaAnalizar+1) + "' " + nombreArchivo);
							arreglo2.RemoveAt(j);
							_fallaArchivo = true;
							j -= 1;
						}
					}


				}
			

			}
			#endregion
			
		}

		/// <summary>
		/// Valida si los datos de au archivo si se relacionan con otros datos de otro archivo entre los cuales debe de existir integridad
		/// </summary>
		///<param name="arreglo1">Datos leidos del archivo 1</param>
		///<param name="ColumnaAnalizar1">Columna del archivo 1 que sera analizada para ver si existe integridad</param>
		///<param name="nombreArchivo1">Nombre del archivo 1 el cual se va a analizar</param>
		///<param name="arreglo2">Datos leidos del archivo 2</param>
		///<param name="ColumnaAnalizar2">Columna de archivo 2 que sera analizada para ver si existe integridad</param>
		///<param name="nombreArchivo2">Nombre del archivo 2 el cual se va a analizar</param>
		private static void ValidarRelacionDatos(ArrayList arreglo1, int ColumnaAnalizar1, string nombreArchivo1,ArrayList arreglo2, int ColumnaAnalizar2, string nombreArchivo2)
		{
			#region Declaraciones
			string [] cadena;
			string valor1;
			string valor2;
			bool falla = true;
			#endregion

			#region Validadora
			for(int i=0; i<arreglo1.Count; i++) //recorre la lista para validar el numero de columnas de cada fila
			{
				falla = true;
				cadena = arreglo1[i].ToString().Split(";".ToCharArray());
				valor1 = cadena[ColumnaAnalizar1];
				for(int j=0; j<arreglo2.Count; j++) //recorre la lista para validar el numero de columnas de cada fila
				{
					cadena = arreglo2[j].ToString().Split(";".ToCharArray());
					valor2 = cadena[ColumnaAnalizar2];
					if(valor1 == valor2)
					{
						falla = false;

					}
					
				}
				if(falla == true)
				{
					EscribirLog("Error de integridad con el valor '" + valor1 + "' de la linea: '" + Convert.ToString(i+1) + "' con columna '" + Convert.ToString(ColumnaAnalizar1+1) + "' del archivo: '" + nombreArchivo1 + "' Debe existir relación con algún elemento de la columna:  '" + Convert.ToString(ColumnaAnalizar2+1) + "'" + " del archivo '" + nombreArchivo2 + "'");
					_fallaArchivo = true;
				}

			}						
			#endregion
		}

		/// <summary>
		/// Lee un archivo plano y retorna su contenido en un ArrayList
		/// </summary>
		///<param name="directorio">Ruta del directorio donde se encuentran los archivos a importar</param>		
		private static bool EstructuraArchivo(string directorio)
		{
			#region Declaraciones
			ArrayList datosCliente = new ArrayList();
			ArrayList datosAutomotor = new ArrayList();
			ArrayList datosIdentificador = new ArrayList();
			ArrayList datosRestriccion = new ArrayList();
			_fallaArchivo = false;			
			#endregion
			try
			{
				#region cargar datos de los archivos
				datosCliente = LeerArchivo(directorio + "/SERVIPUNTO_MTO_CLIENTES.txt");
				datosAutomotor = LeerArchivo(directorio + "/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				datosIdentificador = LeerArchivo(directorio + "/SERVIPUNTO_MTO_IDENTIFICADORES.txt");
				datosRestriccion = LeerArchivo(directorio + "/SERVIPUNTO_MTO_RESTRICCION.txt");
				if(datosCliente.Count <= 1 && datosAutomotor.Count <= 1 && datosIdentificador.Count <= 1)
				{
					return _fallaArchivo;
				}
				#endregion
				
				#region valida total de columnas de cada archivo

				ValidarColumnas(datosCliente,7,"/SERVIPUNTO_MTO_CLIENTES.txt");
				ValidarColumnas(datosAutomotor,11,"/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				ValidarColumnas(datosIdentificador,3,"/SERVIPUNTO_MTO_IDENTIFICADORES.txt");
				if(datosRestriccion.Count>1)
					ValidarColumnas(datosRestriccion,4,"/SERVIPUNTO_MTO_RESTRICCION.txt");
				
				#endregion

				#region valida codigos repetidos en determinada columna de el archivo
				ValidarDatoRepetido(datosCliente,0,"/SERVIPUNTO_MTO_CLIENTES.txt");
				ValidarDatoRepetido(datosCliente,2,"/SERVIPUNTO_MTO_CLIENTES.txt");
				ValidarDatoRepetido(datosAutomotor,1,"/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				ValidarDatoRepetido(datosIdentificador,0,"/SERVIPUNTO_MTO_IDENTIFICADORES.txt");
				ValidarDatoRepetido(datosIdentificador,1,"/SERVIPUNTO_MTO_IDENTIFICADORES.txt");
				#endregion 
				
				#region valida si existe relacion entre la columna de un archivo y la columna de otro archivo
				ValidarRelacionDatos(datosAutomotor,0,"/SERVIPUNTO_MTO_AUTOMOTORES.txt",datosCliente,0,"/SERVIPUNTO_MTO_CLIENTES.txt");
				ValidarRelacionDatos(datosIdentificador,1,"/SERVIPUNTO_MTO_IDENTIFICADORES.txt",datosAutomotor,1,"/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				if(datosRestriccion.Count>1)
					ValidarRelacionDatos(datosRestriccion,0,"/SERVIPUNTO_MTO_RESTRICCION.txt",datosAutomotor,1,"/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				#endregion 
			}
			catch(Exception)
			{
				return _fallaArchivo;
			}
			return _fallaArchivo;
		}
		#endregion		

		#region formato de espacios para columnas de planos
		private string EspacioPlanoTotales(string cadena, string separador)
		{
			string cadenaAux = cadena;
			string [] arreglo;
			try
			{
				arreglo = cadena.Split(separador.ToCharArray());
				cadena = arreglo[0].ToString().PadRight(15,' ') + separador;				//codigo contable
				cadena += bool.Parse(arreglo[1].ToString())?"1" + separador:"0" + separador;//naturaleza de la cuenta
				if(bool.Parse(arreglo[1].ToString()))
				{
					cadena += "0.000".PadLeft(16,' ') + separador;
					cadena += arreglo[2].ToString().Replace(",",".").PadLeft(16,' ');				//valor
				}
				else
				{
					cadena += arreglo[2].ToString().Replace(",",".").PadLeft(16,' ') + separador;	//valor
					cadena += "0.000".PadLeft(16,' ');
				}

			}
			catch(Exception ex)
			{
				string a = ex.Message.ToString();
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, 0,   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de totales para la interfaz contable estandar ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);

				}
				#endregion
				cadena = cadenaAux;
			}
			
			return cadena;
		}

		private string EspacioPlanoTerceros(string cadena, string separador)
		{
			string cadenaAux = cadena;
			string [] arreglo;
			try
			{
				arreglo = cadena.Split(separador.ToCharArray());
				cadena = arreglo[0].ToString().PadRight(5,' ') + separador;					//contador
				cadena += arreglo[1].ToString().PadRight(15,' ') + separador;				//codigo 
				cadena += arreglo[2].ToString().PadRight(14,' ') + separador;				//nit
				cadena += arreglo[3].ToString().PadRight(60,' ') + separador;				//nombre 
				cadena += arreglo[4].ToString().PadRight(10,' ') + separador;				//telefono oficina 
				cadena += arreglo[5].ToString().PadRight(10,' ') + separador;				//telefono particular
				cadena += arreglo[6].ToString().PadRight(1,' ') + separador;				//tipo nit
				cadena += arreglo[7].ToString().PadRight(100,' ');							//direccion 

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
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de terceros para la interfaz contable estandar. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);

				}
				#endregion
			}
			
			return cadena;
		}

		private string EspacioPlanoArticulos(string cadena, string separador)
		{
			string cadenaAux = cadena;
			string [] arreglo;
			try
			{
				arreglo = cadena.Split(separador.ToCharArray());
				cadena = arreglo[0].ToString().PadRight(3,' ') + separador;					//codigo
				cadena += arreglo[1].ToString().PadRight(40,' ') + separador;				//descripcion
				cadena += arreglo[2].ToString().PadRight(3,' ') + separador;				//isla
				cadena += arreglo[3].ToString().Replace(",",".").PadLeft(15,' ') + separador;				//precio unitario 
				cadena += arreglo[4].ToString().Replace(",",".").PadLeft(15,' ');							//cantidad

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
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas por articulos para la interfaz contable estandar. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);

				}
				#endregion
			}
			
			return cadena;
		}


		private static string EspacioPlanoCreditoOContado(string cadena, string separador)
		{
			string cadenaAux = cadena;
			string [] arreglo;
			try
			{
				arreglo = cadena.Split(separador.ToCharArray());

				cadena = DateTime.Parse(arreglo[0].ToString()).ToString("yyyyMMdd") + arreglo[1].ToString().Trim().PadRight(2,' ');	//fecha y turno 1
				cadena += "2";															//predeterminado 2
				cadena = cadena.PadRight(cadena.Length + 20, ' ');						//predeterminado 3
				cadena += arreglo[2].ToString().Trim().PadRight(13,' ');				//nit del cliente 4
				cadena += "00";															//predeterminado 5
				cadena += DateTime.Parse(arreglo[0].ToString()).ToString("yyyyMMdd");	//fecha factura 6
				cadena += arreglo[7].ToString().PadLeft(3,'0');							//Codigo alterno estacion 7 ***
				cadena += "01";															//predeterminado 8
				cadena += "I";															//predeterminado 9
				cadena = cadena.PadRight(cadena.Length + 15, ' ');						//predeterminado 10
				cadena += arreglo[3].ToString().Trim().PadRight(15,' ');				//codigo alterno del articulo 11
				cadena = cadena.PadRight(cadena.Length + 3, ' ');						//predeterminado 12
				cadena += "02 ";														//predeterminado 13
				cadena += arreglo[5].ToString().Replace(".","").Replace(",","").Trim().PadLeft(12,'0') + "+";	 //cantidad 14
				cadena = cadena.PadRight(cadena.Length + 12, '0') + "+";				//predeterminado 15
				cadena += "1";															//predeterminado 16
				cadena += (arreglo[7].ToString().Substring(arreglo[7].Length -2,arreglo[7].Length-1) + "C").PadRight(3,' ');	//Codigo alterno estacion 17 ***	
				cadena += "  ";															//predeterminado 18
				cadena += arreglo[4].ToString().Replace(".","").Replace(",","").Trim().Substring(0,arreglo[4].Length-2).PadLeft(11,'0') + "+";	 //precio unitario 19
				cadena += arreglo[6].ToString().Trim().PadRight(2,' ');					//tipoCredito 20
				cadena += "  ";															//predeterminado 21
				cadena = cadena.PadRight(cadena.Length + 8, ' ');						//predeterminado 22
				cadena = cadena.PadRight(cadena.Length + 10, ' ');						//predeterminado 23
				cadena = cadena.PadRight(cadena.Length + 14, '0') + "+";				//predeterminado 24
				cadena = cadena.PadRight(cadena.Length + 6, ' ');						//predeterminado 25

			}
			catch(Exception ex)
			{
				string a = ex.Message;
				cadena = cadenaAux + " " + ex.Message;
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, 0,   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas por articulos para la interfaz contable estandar. ");
				}
				catch(Exception)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);

				}
				#endregion
			}
			
			return cadena;
		}
		#endregion 

		#region Método Adicionar
		/// <summary>
		/// Inserción de registros en la tabla InterfazContable, se deja abierto para uso de varias configuraciones
		/// </summary>
		/// <param name="objInterfazContable"></param>
		public static void Adicionar (InterfazContable objInterfazContable)
		{
			#region Prepara el Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("InsertarIContable");
			sql.ParametersNumber = 34;
			sql.AddParameter("@NCABONO", SqlDbType.VarChar, objInterfazContable.NCAbono);
			sql.AddParameter("@NATABONO", SqlDbType.Bit, objInterfazContable.NATAbono);
			sql.AddParameter("@NTABONO", SqlDbType.Bit, objInterfazContable.NTAbono);
			sql.AddParameter("@NCDESCUENTO", SqlDbType.VarChar, objInterfazContable.NCDescuento);
			sql.AddParameter("@NATDESCUENTO", SqlDbType.Bit, objInterfazContable.NATDescuento);
			sql.AddParameter("@NTDESCUENTO", SqlDbType.Bit, objInterfazContable.NTDescuento);
			sql.AddParameter("@NCIVA", SqlDbType.VarChar, objInterfazContable.NCIva);
			sql.AddParameter("@NATIVA", SqlDbType.Bit, objInterfazContable.NATIva);
			sql.AddParameter("@NTIVA", SqlDbType.Bit, objInterfazContable.NTIva);
			sql.AddParameter("@CODCENTROCOSTOS", SqlDbType.VarChar , objInterfazContable.CODCentroCostos);
			sql.AddParameter("@NUMCOMPFACTURAS", SqlDbType.VarChar, objInterfazContable.NUMCompFacturas);
			sql.AddParameter("@CODSUCURSAL", SqlDbType.VarChar, objInterfazContable.CODSucursal);
			sql.AddParameter("@NCVENTASGNV", SqlDbType.VarChar, objInterfazContable.NCVentasGNV);
			sql.AddParameter("@NATVENTASGNV", SqlDbType.Bit, objInterfazContable.NATVentasGNV);
			sql.AddParameter("@NTVENTASGNV", SqlDbType.Bit, objInterfazContable.NTVentasGNV);
			sql.AddParameter("@NCVENTASCANAS", SqlDbType.VarChar, objInterfazContable.NCVentasCanas);
			sql.AddParameter("@NATVENTASCANAS", SqlDbType.Bit, objInterfazContable.NATVentasCanas);
			sql.AddParameter("@NTVENTASCANAS", SqlDbType.Bit, objInterfazContable.NTVentasCanas);

			//Modificado:	Ing. Elvis Astaiza
			//Fecha:		03-12-2007
			//Parametros para SAP
			sql.AddParameter("@ClasedePedido_Sap", SqlDbType.VarChar, objInterfazContable.ClasedePedido_Sap);
			sql.AddParameter("@OrganizaciondeVentas_Sap", SqlDbType.VarChar, objInterfazContable.OrganizaciondeVentas_Sap);
			sql.AddParameter("@Canal_Sap", SqlDbType.VarChar, objInterfazContable.Canal_Sap);
			sql.AddParameter("@Sector_Sap", SqlDbType.VarChar, objInterfazContable.Sector_Sap);
			sql.AddParameter("@OficinadeVentas_Sap", SqlDbType.VarChar, objInterfazContable.OficinadeVentas_Sap);
			sql.AddParameter("@GrupodeVendedores_Sap", SqlDbType.VarChar, objInterfazContable.GrupodeVendedores_Sap);
			sql.AddParameter("@Asignacion_Sap", SqlDbType.VarChar, objInterfazContable.Asignacion_Sap);
			sql.AddParameter("@Cod_Cli_Contado_Sap", SqlDbType.VarChar, objInterfazContable.Cod_Cli_Contado_Sap);
			sql.AddParameter("@Puesto_Exp_Sap", SqlDbType.VarChar, objInterfazContable.Puesto_Exp_Sap);
			sql.AddParameter("@Clase_Doc_Sap", SqlDbType.VarChar, objInterfazContable.Clase_Doc_Sap);
			sql.AddParameter("@Sociedad_Sap", SqlDbType.VarChar, objInterfazContable.Sociedad_Sap);
			sql.AddParameter("@Tipo_Mon_Sap", SqlDbType.VarChar,  objInterfazContable.Tipo_Moneda_Sap);
			sql.AddParameter("@RutaImportarSap", SqlDbType.VarChar, objInterfazContable.RutaImportarSap);
			sql.AddParameter("@RutaExportarSap", SqlDbType.VarChar,  objInterfazContable.RutaExportarSap);
			
			//otros
			sql.AddParameter("@RutaImportarClientesCorporativos", SqlDbType.VarChar, objInterfazContable.RutaImportarClientesCorporativos);
			sql.AddParameter("@CodigoEstacionSap", SqlDbType.VarChar, objInterfazContable.CodigoEstacionSap);


			
			#endregion
			#region Ejecución del Estamento SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				throw new Exception (e.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Método Actualizar codigo del cliente por codigo SAP
		/// <summary>
		/// Actualiza el codigo principal del cliente por su codigo alterno proveniente de sap
		/// </summary>
		public static void ActualizarCodigoClienteSap()
		{
			#region Prepara el Estamento SQL
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ActualizarCodigoClienteSap");
	
			#endregion
			#region Ejecución del Estamento SQL
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
			}
			catch (SqlException e)
			{
				throw new Exception (e.Message + " !ERROR BD! ");
			}
			finally
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Generar Plano de ventas Sap 
		/// <summary>
		/// Genera los archivos planos de ventas para la interfaz contable SAP
		/// </summary>
		/// <param name="_nombreArchivo">Ruta y nombre del archivo que se genera</param>
		/// <param name="_fecha">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="_separador">Caractér separador entre campos</param>
		/// <param name="_cod_isl">Numero de isla a consultar</param>
		/// <param name="_turno">Turno a consultar</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		public static string PlanoVentasSap(string _nombreArchivo, string DirectorioTemporal, DateTime _fecha,int _cod_isl,int _turno,string _separador) 
		{

			#region Declaraciones
			string filaTexto="";
			string _cod_cli="";
			string _placa="";
			string _cod_cli_contado;
			string _nom_cli_contado;
			string _pla_contado;
			string _codigoAlternoContado;
			int _numItem;
			string tipoEstacion = "";
			
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;
			string dia = _fecha.Day.ToString();
			string mes = _fecha.Month.ToString();
			string año = _fecha.Year.ToString();
			string _fechaPlana = (dia.PadLeft(2,'0') + mes.PadLeft(2,'0') + año.PadLeft(4,'0'));
			Configuracion.Dat_Gene objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
			Configuracion.Datos_Gene objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			
		
			
			#endregion
			
			#region Directorio de exportación
			//tipo de estacion GAS O GASOLINA
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			tipoEstacion = objDat_Gene.TipoEstacion.Trim()=="Gasolina"?"L":"G";
			tipoEstacion = objDat_Gene.TipoEstacion.Trim()=="Dual"?"D":tipoEstacion;	
			//nombre de archivo
			try
			{

				if(_nombreArchivo == "")
				{
					objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
					if(objInterfazContables.Count == 0) 
					{
						EscribirLog("Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.");
						return "Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.";
					}
					objInterfazContable = objInterfazContables[0];
					UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,1,"*.txt");
					_nombreArchivo = objInterfazContable.RutaExportarSap;
					if(_nombreArchivo == "")
						throw new Exception("Error, debe de configurar en interfaz contable las rutas de importación y exportación de archivos planos para SAP");
					_nombreArchivo += "\\V" + 
								objInterfazContable.OficinadeVentas_Sap.Trim().PadLeft(4,'0') + 
								tipoEstacion + 
								año + 
								mes.PadLeft(2,'0') + 
								dia.PadLeft(2,'0') + 
								_cod_isl.ToString() +
								_turno.ToString() + ".txt";

				}
			}
			catch(Exception exception)
			{
				
				EscribirLog(("Debe configurar la interfaz SAP! " + exception.Message.ToString()));
				throw new Exception ("Debe configurar la interfaz SAP! " + exception.Message.ToString());
			}	

			try
			{
				System.IO.File.Delete(_nombreArchivo);
			}
			catch(Exception){}
			
			#endregion

			#region Prepare Sql Command
			//sql para la CABECERA SAP
			SqlDataReader drCabeceras = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("CabecerasSap");
			sql.ParametersNumber = 3;
			sql.AddParameter("@fecha", SqlDbType.DateTime, _fecha);
			sql.AddParameter("@num_tur", SqlDbType.Int, _turno);
			sql.AddParameter("@cod_isl", SqlDbType.Int, _cod_isl);
			//sql para el cliente de contado SAP				
			SqlDataReader drClienteContado = null;
			Servipunto.Libreria.SqlBuilder sql3 = new Servipunto.Libreria.SqlBuilder();
			sql3.Append("ClienteContadoSAPQuery");
			try
			{
				drClienteContado = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql3.Text);
				drClienteContado.Read();
				_cod_cli_contado = drClienteContado.GetValue(0).ToString();
				_nom_cli_contado = drClienteContado.GetValue(1).ToString();
				_pla_contado = drClienteContado.GetValue(2).ToString();
				_codigoAlternoContado = drClienteContado.GetValue(3).ToString();
				drClienteContado.Close();
			}
			catch(Exception)
			{
				drClienteContado.Close();
				EscribirLog("Debe configurar un cliente de contado en la interfaz SAP y en la lista de Clientes!");
				throw new Exception ("Debe configurar un cliente de contado en la interfaz SAP y en la lista de Clientes!");

			}

			

			//sql para los DETALLES SAP
			SqlDataReader drDetalles = null;
			Servipunto.Libreria.SqlBuilder sql2 = null;
			#endregion

			#region Execute sql Command
			try
			{
				//Consulta la cabecera
				
				drCabeceras = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(drCabeceras.HasRows == false)
					throw new Exception(" No se encontaron datos en la busqueda para crear las cabeceras por dos motivos, 1. No existen ventas en esta fecha, 2. No esta configurada correctamente la interfaz contable y su cliente de contado!");
							
				FileStream stream = new FileStream(_nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
	
				while (drCabeceras.Read())
				{
					_numItem = 0;
					filaTexto = AjustarTamaño(_numItem.ToString(),1) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["clasedePedido_Sap"].ToString().Trim(),4) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["organizaciondeVentas_Sap"].ToString().Trim(),4) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["canal_Sap"].ToString().Trim(),2) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["Sector_Sap"].ToString().Trim(),2) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["OficinadeVentas_Sap"].ToString().Trim(),4) + _separador;
					filaTexto += AjustarTamaño(drCabeceras["GrupodeVendedores_Sap"].ToString().Trim(),3) + _separador;
					if(drCabeceras["nombre"].ToString().Trim()!="" && drCabeceras["cod_cli"].ToString().Trim()!="" && drCabeceras["placa"].ToString().Trim()!="")
						filaTexto += AjustarTamaño(drCabeceras["CodigoAlterno"].ToString().Trim(),10) + _separador;
					else
						filaTexto += AjustarTamaño(_codigoAlternoContado,10) + _separador;					
					if(drCabeceras["nombre"].ToString().Trim()!="" && drCabeceras["cod_cli"].ToString().Trim()!="" && drCabeceras["placa"].ToString().Trim()!="")
						filaTexto += AjustarTamaño(drCabeceras["nombre"].ToString().Trim(),40) + _separador;
					else
						filaTexto += AjustarTamaño(_nom_cli_contado,40) + _separador;
					//filaTexto += AjustarTamaño(drCabeceras["fecha"].ToString().Replace("/",""),8) + _separador;
					filaTexto += AjustarTamaño(_fechaPlana,8) + _separador;
					if(drCabeceras["nombre"].ToString().Trim()!="" && drCabeceras["cod_cli"].ToString().Trim()!="" && drCabeceras["placa"].ToString().Trim()!="")
						filaTexto += AjustarTamaño(drCabeceras["placa"].ToString().Trim(),18) + _separador;
					else
						filaTexto += AjustarTamaño(_pla_contado,18) + _separador;					
					filaTexto += AjustarTamaño(drCabeceras["Puesto_Exp_Sap"].ToString().Trim(),4) + _separador;

					//Busca los detalles de productos para el cliente que esta en la cabecera
					_cod_cli = drCabeceras["cod_cli"].ToString();
					_placa = drCabeceras["placa"].ToString();
					writer.WriteLine(filaTexto);
					
					#region Prepare Sql2 Command
					//sql para los DETALLES
					sql2 = new Servipunto.Libreria.SqlBuilder();
					sql2.Append("DetallesVentasSAP");
					sql2.ParametersNumber = 5;
					sql2.AddParameter("@cod_cli", SqlDbType.Char, _cod_cli);
					sql2.AddParameter("@placa", SqlDbType.Char, _placa);
					sql2.AddParameter("@Fecha", SqlDbType.DateTime, _fecha);
					sql2.AddParameter("@cod_isl", SqlDbType.Int, _cod_isl);
					sql2.AddParameter("@num_tur", SqlDbType.Int, _turno);
					//Consulta los DETALLES
					drDetalles = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql2.Text, sql2.Parameters);
					#endregion
					while (drDetalles.Read())
					{
						_numItem += 1;
						filaTexto = AjustarTamaño(_numItem.ToString(),1) + _separador;
						filaTexto += AjustarTamaño(drDetalles["CodigoAlterno"].ToString().Trim(),18) + _separador;
						filaTexto += AjustarTamaño(drDetalles["Cantidad"].ToString().Trim(),15) + _separador;
						filaTexto += AjustarTamaño(drDetalles["total"].ToString().Trim(),13) + _separador;
						writer.WriteLine(filaTexto);
					}
				}
				writer.Close();				
				drCabeceras.Close();
				drDetalles.Close();
			}
			catch(Exception exception)
			{
				EscribirLog(exception.Message.ToString());
				throw new Exception(exception.Message.ToString());
			
			}

			
			drCabeceras = null;
			drDetalles = null;					
			sql = null;			
			return "OK," + _nombreArchivo; 
			//"Creado satisfactoriamente: " + _nombreArchivo;
			#endregion
		}
		#endregion

		#region Generar Plano de traslados Sap
		/// <summary>
		/// Genera los archivos planos de traslados para la interfaz contable SAP
		/// </summary>
		/// <param name="_nombreArchivo">Ruta y nombre del archivo que se genera</param>
		/// <param name="_fecha">Fecha de la cual se desea hacer hacer el traslado</param>
		/// <param name="_separador">Caractér separador entre campos</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		public static string PlanoTrasladosSap(string _nombreArchivo, string DirectorioTemporal, DateTime _fecha,string _separador) 
		{

			#region Declaraciones
			string filaTexto="";
			int _numItem=0;
			string _clase_Doc_Sap;
			string _sociedad_Sap;
			string _tipo_Mon_Sap;
			string _dia = _fecha.Day.ToString();
			string _mes = _fecha.Month.ToString();
			string _año = _fecha.Year.ToString();
			string tipoEstacion = "";
			string _fechaPlana = (_dia.PadLeft(2,'0') + _mes.PadLeft(2,'0') + _año.PadLeft(4,'0'));
			InterfazContables objInterfazContables = new InterfazContables();
			InterfazContable objInterfazContable = new InterfazContable();
			Configuracion.Dat_Gene objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
			Configuracion.Datos_Gene objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();

			#endregion
			
			#region Directorio de exportación
			//tipo de estacion GAS O GASOLINA
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			tipoEstacion = objDat_Gene.TipoEstacion.Trim()=="Gasolina"?"L":"G";
			tipoEstacion = objDat_Gene.TipoEstacion.Trim()=="Dual"?"D":tipoEstacion;	
			//nombre de archivo
			try
			{

				if(_nombreArchivo == "")
				{
					objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
					if(objInterfazContables.Count == 0) 
					{
						EscribirLog("Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.");
						return "Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.";
					}
					objInterfazContable = objInterfazContables[0];
					UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,1,"*.txt");
					_nombreArchivo = objInterfazContable.RutaExportarSap;
					if(_nombreArchivo == "")
						throw new Exception("Error, debe de configurar en interfaz contable las rutas de importación y exportación de archivos planos para SAP");
					_nombreArchivo += "\\T" + objInterfazContable.OficinadeVentas_Sap.Trim().PadLeft(4,'0') + tipoEstacion + _año + _mes.PadLeft(2,'0') + _dia.PadLeft(2,'0') + ".txt";

				}
			}
			catch(Exception exception)
			{
				
				EscribirLog(("Debe configurar la interfaz SAP! " + exception.Message.ToString()));
				throw new Exception ("Debe configurar la interfaz SAP! " + exception.Message.ToString());
			}	

			try
			{
				System.IO.File.Delete(_nombreArchivo);
			}
			catch(Exception){}

			#endregion

			#region Cabecera de Traslados
			
			if (objInterfazContables == null)
			{
				EscribirLog("Debe configurar la 'Interfaz Contable' en el panel de control");
				throw new Exception("Debe configurar la 'Interfaz Contable' en el panel de control");
			}

			objInterfazContable = objInterfazContables[0];
			_clase_Doc_Sap = objInterfazContable.Clase_Doc_Sap;
			_sociedad_Sap = objInterfazContable.Sociedad_Sap;
			_tipo_Mon_Sap = objInterfazContable.Tipo_Moneda_Sap;
			
			FileStream stream = new FileStream(_nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			
			_numItem = 0;
			filaTexto += AjustarTamaño(_numItem.ToString(),1) + _separador;
			//filaTexto += AjustarTamaño(_fecha.Replace("/",""),8) + _separador;
			filaTexto += AjustarTamaño(_fechaPlana,8) + _separador;
			filaTexto += AjustarTamaño(_clase_Doc_Sap,2) + _separador;
			filaTexto += AjustarTamaño(_sociedad_Sap,4) + _separador;
			//filaTexto += AjustarTamaño(_fecha.Replace("/",""),8) + _separador;
			filaTexto += AjustarTamaño(_fechaPlana,8) + _separador;
			filaTexto += AjustarTamaño(_mes,2) + _separador;
			filaTexto += AjustarTamaño(_tipo_Mon_Sap,5) + _separador;
			writer.WriteLine(filaTexto);
			#endregion

			#region detalle de traslados SAP
		
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("DetallesTrasladosSAP");
			sql.ParametersNumber = 1;
			sql.AddParameter("@fecha", SqlDbType.DateTime, _fecha);			
			SqlDataReader dr = null;
			try
			{
				dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters);
				while (dr.Read())
				{
					filaTexto = "";
					_numItem += 1;
					filaTexto += AjustarTamaño(_numItem.ToString(),1) + _separador;
					filaTexto += AjustarTamaño(dr["referencia"].ToString().Trim(),16) + _separador;
					filaTexto += AjustarTamaño(dr["referencia"].ToString().Trim() + " " + _fechaPlana,25) + _separador;
					filaTexto += AjustarTamaño("50",2) + _separador;
					filaTexto += AjustarTamaño(dr["num_cuentac_sap"].ToString().Trim(),17) + _separador;
					filaTexto += AjustarTamaño(dr["importe"].ToString().Trim(),15) + _separador;
					filaTexto += AjustarTamaño(dr["divisionc_sap"].ToString().Trim(),4) + _separador;
					filaTexto += AjustarTamaño(_fechaPlana,8) + _separador;
					filaTexto += AjustarTamaño(dr["asignacionc_sap"].ToString().Trim() + " " + _fechaPlana,18) + _separador;
					filaTexto += AjustarTamaño(dr["textoc_sap"].ToString().Trim() + " " + _fechaPlana,50) + _separador;					
					filaTexto += AjustarTamaño("40",2) + _separador;
					filaTexto += AjustarTamaño(dr["num_cuentad_sap"].ToString().Trim(),17) + _separador;
					filaTexto += AjustarTamaño(dr["importe"].ToString().Trim(),15) + _separador;
					filaTexto += AjustarTamaño(dr["divisiond_sap"].ToString().Trim(),4) + _separador;
					filaTexto += AjustarTamaño(_fechaPlana,8) + _separador;
					filaTexto += AjustarTamaño(dr["asignaciond_sap"].ToString().Trim() + " " + _fechaPlana,18) + _separador;
					filaTexto += AjustarTamaño(dr["textod_sap"].ToString().Trim() + " " + _fechaPlana,50) + _separador;
					writer.WriteLine(filaTexto);
									
				}
				writer.Close();
				dr.Close();				
			}
			catch(Exception exception)
			{   dr.Close();	
				EscribirLog("Debe configurar la interfaz SAP! " + exception.Message.ToString());
				throw new Exception("Debe configurar la interfaz SAP! " + exception.Message.ToString());
			}	
			return "OK," + _nombreArchivo; 
			#endregion
		}
		#endregion

		#region Importar archivos Planos Sap
		/// <summary>
		/// Importa los archivos planos de 'clientes, automotores, restricciones horaria, identificadores' provenientes de SAP a la base de datos;
		/// </summary>
		public static string ImportarPlanosSap() 
		{
			#region Declaraciones
			ArrayList arreglo= new ArrayList();
			string [] cadena;
			string directorio = "";
			string mensaje = "";
			Libreria.Comercial.Cliente objCliente = null;
			Libreria.Comercial.Automotor objAutomotor = null;
			Libreria.Configuracion.Identificador objIdentificador = null;
			Libreria.Comercial.Restriccion objRestriccion = null;
			Libreria.Configuracion.Datos_Gene objDatosGenerales = new Libreria.Configuracion.Datos_Gene();
			InterfazContables objInterfazContables = new InterfazContables();
			InterfazContable objInterfazContable = new InterfazContable();
			int filasAfectadas=0;
			
			#endregion

			#region Directorio de importacion 
		
            //objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
            //if(objInterfazContables.Count == 0) 
            //{
            //    EscribirLog("Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.");
            //    return "Error! Por favor Configure la Interfaz Contable para SAP en el panel de control, gracias.";
            //} 

            //objInterfazContable = objInterfazContables[0];
            directorio = "D:\\Desarrollos\\ser\\planos";
            //if(directorio == "D:\\Desarrollos\\ser\\planos")
            //{
            //    EscribirLog("Error, debe de configurar en interfaz contable las rutas de importación y exportación de archivos planos para SAP!");
            //    throw new Exception("Error, debe de configurar en interfaz contable las rutas de importación y exportación de archivos planos para SAP!");
            //}

			
			#endregion

			#region Importar Clientes


			if(EstructuraArchivo(directorio)== true)
			{
				EscribirLog(" ---> Por las anteriores anomalias provenientes de los datos de los archivos planos fue cancelada la importación de los mismos al sistema Administrativo de Servipunto");
				return("Importación Cancelada por errores en la estructrura de los archivos planos, revisar 'c:\\logServipuntoSap.txt'");
			}
			
			#region Consulta todos los clientes existentes		
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("clientesquery");
			SqlDataReader drClientes = null;
			
			drClientes = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
			SqlConnection connection = new SqlConnection(Aplicacion.Conexion.ConnectionString);
			connection.Open();

			
			#endregion

			try
			{
				arreglo = LeerArchivo(directorio + "/SERVIPUNTO_MTO_CLIENTES.txt");
				if(arreglo[0].ToString() == "No existe el archivo")
					return "No existe el archivo: " + directorio + "\\SERVIPUNTO_MTO_CLIENTES.txt";
				while (drClientes.Read())
				{
					//foreach(string filaTexto in arreglo) //recorre la lista del archivo plano para modificar los clientes existentes
					for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para modificar los clientes existentes
					{
						//cadena = filaTexto.ToString().Split(";".ToCharArray());
						cadena = arreglo[i].ToString().Split(";".ToCharArray());
						if(cadena.Length > 1 )
						{
							if(drClientes["Nit"].ToString().Trim() == cadena[2].ToString().Trim())
							{
								//arreglo.Remove(filaTexto);
								objCliente = new Libreria.Comercial.Cliente();
								objCliente.CodigoCliente = drClientes["CodCliente"].ToString().Trim();							
								objCliente.CodigoAlterno = cadena[0].ToString().Trim();
								objCliente.NombreCliente = cadena[1].ToString().Trim();
								objCliente.NitCedulaCliente = cadena[2].ToString().Trim();
								objCliente.IgNit = cadena[3].ToString().Trim()==""?0:int.Parse(cadena[3].ToString().Trim());
								objCliente.Estadocliente = cadena[4].ToString().Trim();
								objCliente.Cupo_Asignado = cadena[5].ToString().Trim()==""?0:decimal.Parse(cadena[5].ToString().Trim());
								objCliente.Cupo_Disponible = cadena[6].ToString().Trim()==""?0:decimal.Parse(cadena[6].ToString().Trim());							
								try
								{
									SqlCommand command = new SqlCommand("ModificacionBasicaCliente", connection);
									command.CommandType = CommandType.StoredProcedure;

									command.Parameters.Add("@Cod_Cli", SqlDbType.VarChar);
									command.Parameters["@Cod_Cli"].Value = objCliente.CodigoCliente;

									command.Parameters.Add("@Nombre", SqlDbType.VarChar);
									command.Parameters["@Nombre"].Value = objCliente.NombreCliente;

									command.Parameters.Add("@Nit", SqlDbType.VarChar);
									command.Parameters["@Nit"].Value = objCliente.NitCedulaCliente;

									command.Parameters.Add("@IgNit", SqlDbType.Int);
									command.Parameters["@IgNit"].Value = objCliente.IgNit;

									command.Parameters.Add("@Estado_", SqlDbType.Bit);
									command.Parameters["@Estado_"].Value = objCliente.Estadocliente=="A"?1:0;

									command.Parameters.Add("@CodigoAlterno", SqlDbType.VarChar);
									command.Parameters["@CodigoAlterno"].Value = objCliente.CodigoAlterno;

									command.Parameters.Add("@Cupo_Asignado", SqlDbType.VarChar);
									command.Parameters["@Cupo_Asignado"].Value = objCliente.Cupo_Asignado;

									command.Parameters.Add("@Cupo_Disponible", SqlDbType.VarChar);
									command.Parameters["@Cupo_Disponible"].Value = objCliente.Cupo_Disponible;
									
									filasAfectadas = command.ExecuteNonQuery();
									
									//objCliente.ModificarBasicos();
								}
								catch(Exception exception)
								{
									EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_CLIENTES.txt' ");
								}
								arreglo.RemoveAt(i);
								i=-1;
								//break;

							}

							
						}
					}
				}
				drClientes.Close();

				for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para agregar los nuevos clientes que quedaron
				{
	
					cadena = arreglo[i].ToString().Split(";".ToCharArray());
					if(cadena.Length > 1 )
					{
						objCliente = new Libreria.Comercial.Cliente();
						objCliente.CodigoCliente = cadena[0].ToString().Trim();
						objCliente.CodigoAlterno = cadena[0].ToString().Trim();
						objCliente.NombreCliente = cadena[1].ToString().Trim();
						objCliente.NitCedulaCliente = cadena[2].ToString().Trim();
						objCliente.IgNit = cadena[3].ToString().Trim()==""?0:int.Parse(cadena[3].ToString().Trim());
						objCliente.Estadocliente = cadena[4].ToString().Trim();
						objCliente.IdCiudad = objDatosGenerales[0].Ciudad.ToString();
						//if(objInterfazContable.Cod_Cli_Contado_Sap.Trim() != objCliente.CodigoCliente.Trim())
							objCliente.FormaDePagoCliente = 6;
                        //else
                        //    objCliente.FormaDePagoCliente = 4;
                        objCliente.TipoNit = "Nit";
						
						try
						{
							SqlCommand command = new SqlCommand("ClientesInsertion", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Cod_Cli", SqlDbType.VarChar);
							command.Parameters["@Cod_Cli"].Value = objCliente.CodigoCliente;

							command.Parameters.Add("@Nombre", SqlDbType.VarChar);
							command.Parameters["@Nombre"].Value = objCliente.NombreCliente;

							command.Parameters.Add("@Tipo_Nit", SqlDbType.VarChar);
							command.Parameters["@Tipo_Nit"].Value = objCliente.TipoNit;

							command.Parameters.Add("@Nit", SqlDbType.VarChar);
							command.Parameters["@Nit"].Value = objCliente.NitCedulaCliente;

							//command.Parameters.Add("@IgNit", SqlDbType.Int);
							//command.Parameters["@IgNit"].Value = objCliente.IgNit;

							command.Parameters.Add("@CodigoAlterno", SqlDbType.VarChar);
							command.Parameters["@CodigoAlterno"].Value = objCliente.CodigoAlterno;

							command.Parameters.Add("@Cod_For_Pag", SqlDbType.Int);
							command.Parameters["@Cod_For_Pag"].Value = objCliente.FormaDePagoCliente;

							command.Parameters.Add("@IdCiudad", SqlDbType.VarChar);
							command.Parameters["@IdCiudad"].Value = objCliente.IdCiudad;
									
							filasAfectadas = command.ExecuteNonQuery();

							//Libreria.Comercial.Clientes.Adicionar(objCliente);
						}
						catch(Exception exception)
						{
							EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_CLIENTES.txt' ");
						}

						objCliente.Cupo_Asignado = cadena[5].ToString().Trim()==""?0:decimal.Parse(cadena[5].ToString().Trim());
						objCliente.Cupo_Disponible = cadena[6].ToString().Trim()==""?0:decimal.Parse(cadena[6].ToString().Trim());
						try
						{
							SqlCommand command = new SqlCommand("ModificacionBasicaCliente", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Cod_Cli", SqlDbType.VarChar);
							command.Parameters["@Cod_Cli"].Value = objCliente.CodigoCliente;

							command.Parameters.Add("@Nombre", SqlDbType.VarChar);
							command.Parameters["@Nombre"].Value = objCliente.NombreCliente;

							command.Parameters.Add("@Nit", SqlDbType.VarChar);
							command.Parameters["@Nit"].Value = objCliente.NitCedulaCliente;

							command.Parameters.Add("@IgNit", SqlDbType.Int);
							command.Parameters["@IgNit"].Value = objCliente.IgNit;

							command.Parameters.Add("@Estado_", SqlDbType.Bit);
							command.Parameters["@Estado_"].Value = objCliente.Estadocliente=="A"?1:0;

							command.Parameters.Add("@CodigoAlterno", SqlDbType.VarChar);
							command.Parameters["@CodigoAlterno"].Value = objCliente.CodigoAlterno;

							command.Parameters.Add("@Cupo_Asignado", SqlDbType.VarChar);
							command.Parameters["@Cupo_Asignado"].Value = objCliente.Cupo_Asignado;

							command.Parameters.Add("@Cupo_Disponible", SqlDbType.VarChar);
							command.Parameters["@Cupo_Disponible"].Value = objCliente.Cupo_Disponible;
									
							filasAfectadas = command.ExecuteNonQuery();
									
							//objCliente.ModificarBasicos();

						}
						catch(Exception exception)
						{
							EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_CLIENTES.txt' ");
						}
					}
					arreglo.RemoveAt(i);
					i=-1;
					
								
				}
											
			}
			
			catch(Exception exception)
			{
				EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_CLIENTES.txt' ");
				//throw new Exception(exception.Message.ToString() + " 'SERVIPUNTO_MTO_CLIENTES.txt' ");
				
			}
			#endregion

			#region Importar Automotores

			arreglo.Clear();
			try
			{
				arreglo = LeerArchivo(directorio + "/SERVIPUNTO_MTO_AUTOMOTORES.txt");
				for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para modificar o crear los automotores existentes
				{
					
					cadena = arreglo[i].ToString().Split(";".ToCharArray());
					if(cadena.Length > 1 )
					{
                        try
                        {
                            objAutomotor = new Libreria.Comercial.Automotor();
                            objAutomotor.CodigoAlterno = cadena[0].ToString().Trim();
                            objAutomotor.PlacaAutomotor = cadena[1].ToString().Trim();
                            objAutomotor.MarcaAutomotor = cadena[2].ToString().Trim();
                            objAutomotor.ModeloAutomotor = cadena[3].ToString().Trim();
                            objAutomotor.AñoAutomotor = int.Parse(cadena[4].ToString().Trim());
                            objAutomotor.CapacidadTotalAutomtor = decimal.Parse(cadena[5].ToString().Trim());
                            objAutomotor.NumeroMaxTanqueosDia = int.Parse(cadena[6].ToString().Trim());
                            objAutomotor.CodigoFormaDePagoAutomtor = cadena[7].ToString().Trim() == "0" ? 4 : int.Parse(cadena[7].ToString().Trim());
                            //objCliente.Cupo_Asignado = decimal.Parse(cadena[5].ToString().Trim());
                            //objCliente.Cupo_Disponible = decimal.Parse(cadena[6].ToString().Trim());
                            objAutomotor.Cupo_Asignado = decimal.Parse(cadena[8].ToString().Trim());
                            objAutomotor.Cupo_Disponible = decimal.Parse(cadena[9].ToString().Trim());
                            objAutomotor.CodigoCausalDeBloqueoAutomotor = Int16.Parse(cadena[10].ToString().Trim());
                        }

                        catch(Exception ex)
                        {
                            EscribirLog(ex.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_AUTOMOTORES.txt' Placa:" + objAutomotor.PlacaAutomotor +  " Linea archivo:" + (i+1).ToString() );
		                }

						try
						{
							SqlCommand command = new SqlCommand("ModificarBasicoAutomoto", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Placa", SqlDbType.VarChar);
							command.Parameters["@Placa"].Value = objAutomotor.PlacaAutomotor;

							command.Parameters.Add("@Marca", SqlDbType.VarChar);
							command.Parameters["@Marca"].Value = objAutomotor.MarcaAutomotor;

							command.Parameters.Add("@Modelo", SqlDbType.VarChar);
							command.Parameters["@Modelo"].Value = objAutomotor.ModeloAutomotor;

							command.Parameters.Add("@Ano", SqlDbType.Int);
							command.Parameters["@Ano"].Value = objAutomotor.AñoAutomotor;

							command.Parameters.Add("@Cap_Total", SqlDbType.Decimal);
							command.Parameters["@Cap_Total"].Value = objAutomotor.CapacidadTotalAutomtor;

							command.Parameters.Add("@Max_Num_Tan", SqlDbType.Int);
							command.Parameters["@Max_Num_Tan"].Value = objAutomotor.NumeroMaxTanqueosDia;

							command.Parameters.Add("@Cod_For_Pag", SqlDbType.Int);
							command.Parameters["@Cod_For_Pag"].Value = objAutomotor.CodigoFormaDePagoAutomtor;

							command.Parameters.Add("@Cupo_Asignado", SqlDbType.VarChar);
							command.Parameters["@Cupo_Asignado"].Value = objAutomotor.Cupo_Asignado;

							command.Parameters.Add("@Cupo_Disponible", SqlDbType.VarChar);
							command.Parameters["@Cupo_Disponible"].Value = objAutomotor.Cupo_Disponible;

							command.Parameters.Add("@CodigoAlterno", SqlDbType.VarChar);
							command.Parameters["@CodigoAlterno"].Value = objAutomotor.CodigoAlterno;

							command.Parameters.Add("@Causal", SqlDbType.Int);
							command.Parameters["@Causal"].Value = objAutomotor.CodigoCausalDeBloqueoAutomotor;
									
							filasAfectadas = command.ExecuteNonQuery();

							//objAutomotor.ModificarBasicos();
						}
						catch(Exception exception)
						{
							EscribirLog(exception.Message.ToString()  + " Problemas con: 'SERVIPUNTO_MTO_AUTOMOTORES.txt' ");
						}
					}

                    try
                    {

                        arreglo.RemoveAt(i);
                        i = -1;
                    }
                    catch
                    {
                    }
				}
				
			}
			
			catch(Exception exception)
			{
				connection.Close();
				connection.Dispose();
				EscribirLog(exception.Message.ToString()  + " 'SERVIPUNTO_MTO_AUTOMOTORES.txt' ");
				throw new Exception(exception.Message.ToString()  + " 'SERVIPUNTO_MTO_AUTOMOTORES.txt' ");
				
			}
			#endregion
			
			#region Importar Identificadores

			arreglo.Clear();
			try
			{
				arreglo = LeerArchivo(directorio + "/SERVIPUNTO_MTO_IDENTIFICADORES.txt");
				for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para modificar o crear los identificadores existentes
				{
						
					cadena = arreglo[i].ToString().Split(";".ToCharArray());
					if(cadena.Length > 1 )
					{
						objIdentificador = new Libreria.Configuracion.Identificador();
						objIdentificador.IdRom = cadena[0].ToString().Trim();
						objIdentificador.Placa = cadena[1].ToString().Trim();
						objIdentificador.IdentificadorActivo = cadena[2].ToString().Trim();
						try
						{
							SqlCommand command = new SqlCommand("ModificarBasicoIdentificador", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Rom_Iden", SqlDbType.VarChar);
							command.Parameters["@Rom_Iden"].Value = objIdentificador.IdRom;

							command.Parameters.Add("@Placa", SqlDbType.VarChar);
							command.Parameters["@Placa"].Value = objIdentificador.Placa;

							command.Parameters.Add("@Activa", SqlDbType.Bit);
							command.Parameters["@Activa"].Value = objIdentificador.IdentificadorActivo == "A"?1:0;

							filasAfectadas = command.ExecuteNonQuery();


							//objIdentificador.ModificarBasicos();
						}
						catch(Exception exeption)
						{
							EscribirLog(exeption.Message.ToString()  + " Problemas con: 'SERVIPUNTO_MTO_AUTOMOTORES.txt' ");
						}
					}
					arreglo.RemoveAt(i);
					i=-1;
				}
			
			}
			catch(Exception exception)
			{
				connection.Close();
				connection.Dispose();
				EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_IDENTIFICADORES.txt' ");
				throw new Exception(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_IDENTIFICADORES.txt' ");
				
			}
			#endregion
			
			#region Importar Restricciones

			arreglo.Clear();
			try
			{
				
				arreglo = LeerArchivo(directorio + "/SERVIPUNTO_MTO_RESTRICCION.txt");
				if(arreglo.Count > 0 && arreglo[0].ToString() != "No existe el archivo")
					Libreria.Comercial.Restricciones.Eliminar("*",0,DateTime.Parse("01-01-1900"));
				for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para modificar o crear los identificadores existentes
				{
						
					cadena = arreglo[i].ToString().Split(";".ToCharArray());
					if(cadena.Length > 1 )
					{
						objRestriccion = new Libreria.Comercial.Restriccion();
						objRestriccion.Placa = cadena[0].ToString().Trim();
						objRestriccion.Dia = short.Parse(cadena[1].ToString().Trim());
						objRestriccion.HoraInicio = DateTime.Parse("01-01-1900 " + cadena[2].ToString().Trim());
						objRestriccion.HoraFin = DateTime.Parse("01-01-1900 " + cadena[3].ToString().Trim());
						try
						{
							SqlCommand command = new SqlCommand("InsertarRestriccion", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Placa", SqlDbType.VarChar);
							command.Parameters["@Placa"].Value = objRestriccion.Placa;

							command.Parameters.Add("@Dia", SqlDbType.Int);
							command.Parameters["@Dia"].Value = objRestriccion.Dia;

							command.Parameters.Add("@Hora_Inicio", SqlDbType.DateTime);
							command.Parameters["@Hora_Inicio"].Value = objRestriccion.HoraInicio;

							command.Parameters.Add("@Hora_Fin", SqlDbType.DateTime);
							command.Parameters["@Hora_Fin"].Value = objRestriccion.HoraFin;

							filasAfectadas = command.ExecuteNonQuery();
							//Libreria.Comercial.Restricciones.Adicionar(objRestriccion);
						}
						catch(Exception exception)
						{
							EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_RESTRICCION.txt' ");
						}				
					}
					arreglo.RemoveAt(i);
					i=-1;
				}
				
			}
			catch(Exception exception)
			{
				connection.Close();
				connection.Dispose();
				EscribirLog(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_RESTRICCION.txt' ");
				UtilidadesGenerales.LimpiarDirectorio(directorio,1,"*.txt");
				return(exception.Message.ToString() + " Problemas con: 'SERVIPUNTO_MTO_RESTRICCION.txt' ");
				
			}
			#endregion
			
			#region actualiza codigo del cliente por codigo Sap
			try
			{
				DataSet dsCodigosRepetidos = ValdidarCodigoClienteSap();
				if(dsCodigosRepetidos.Tables[0].Rows.Count>0)
				{
					for(int i=0; i<dsCodigosRepetidos.Tables[0].Rows.Count; i++)
						mensaje += " Error: El codigo alterno '" + dsCodigosRepetidos.Tables[0].Rows[i]["codigoalterno"].ToString().Trim() + "' de cliente ya existe! \n";
					EscribirLog(mensaje + " - Verifique estos codigos alternos en la base de datos.");
					return mensaje + " - Verifique estos codigos alternos en la base de datos.";
				}


			}
			catch(Exception ex)
			{
				EscribirLog(ex.Message);
				return ex.Message;
			}

			try
			{
				connection.Close();
				connection.Dispose();
				ActualizarCodigoClienteSap();
			}
			catch(Exception ex)
			{
				EscribirLog(ex.Message + " - Los registros fueron importados pero al momento de actualizar los codigos de cliente Servipunto por los codigos de cliente SAP ocurrio un error(s)!, Posiblemente existe mas de un codigo alterno de SAP duplicado para diferentes clientes... Verifique la integridad de codigos alternos.");				
				return ex.Message + " - Los registros fueron importados pero al momento de actualizar los codigos de cliente Servipunto por los codigos de cliente SAP ocurrio un error(s)!, Posiblemente existe mas de un codigo alterno de SAP duplicado para diferentes clientes... Verifique la integridad de codigos alternos.";
			}

			#endregion

			#region Elimina los archivos del directorio
			UtilidadesGenerales.LimpiarDirectorio(directorio,1,"*.txt");
			return "OK";
			#endregion
		}
		
		#endregion

		#region Importar archivos Planos de clientes corporativos
		/// <summary>
		/// Importa los archivos planos de 'clientes, automotores'
		/// </summary>
		/// <param name="rutaArchivo">Ruta y nombre del archivo que se importará</param>
		/// <param name="separador">Separador</param>
		
		public static string ImportarPlanosClientesCorporativos(string rutaArchivo,string separador) 
		{
			#region Declaraciones
			ArrayList arreglo= new ArrayList();
			string [] cadena;
			string directorio = "";
			string ciudad;
			string resultado = "";
			Libreria.Configuracion.Datos_Gene objDatosGenerales = new Libreria.Configuracion.Datos_Gene();
			InterfazContables objInterfazContables = new InterfazContables();
			InterfazContable objInterfazContable = new InterfazContable();
			if(objDatosGenerales.Count == 0)
				throw new Exception("Error, debe de Configurar los datos generales, Gracias!");
			ciudad = objDatosGenerales[0].Ciudad;
			int FilasAfectadas = 0;
			#endregion

			#region Directorio de importacion 

			separador = separador.Trim()==""?",":separador.Trim();//objDatosGenerales[0].SeparadorPlanosPredeterminado:separador.Trim();
			if(rutaArchivo == "")
			{
				objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
				if(objInterfazContables.Count == 0) 
				{
					return "Error, Por favor configure la ruta y nombre de archivo plano para importación de clientes corporativos en: panel de control > Interfaz Contable Estandar, gracias.";
				}

				objInterfazContable = objInterfazContables[0];
				directorio = objInterfazContable.RutaImportarClientesCorporativos;
				if(directorio == "")
				{
					return "Error, Por favor configure la ruta y nombre de archivo plano para importación de clientes corporativos en: panel de control > Interfaz Contable Estandar, gracias.";
				}
			}
			else
				directorio = rutaArchivo;
			#endregion

			#region Importar Clientes y vehiculos

			arreglo = LeerArchivo(directorio);
			if(arreglo[0].ToString() == "No existe el archivo")
				return "No existe el archivo: " + directorio;
			SqlConnection connection = new SqlConnection(Aplicacion.Conexion.ConnectionString);
			connection.Open();


				for(int i=0; i<arreglo.Count; i++) //recorre la lista del archivo plano para crear o modificar los clientes y sus automotores
				{
					try
					{

						cadena = arreglo[i].ToString().Split(separador.ToCharArray());
						if(cadena.Length == 3 )
						{

							#region Prepare Sql Command para actualizar los clientes corporativos  y sus vehiculos 
							SqlCommand command = new SqlCommand("ActualizarClientesCorporativos", connection);
							command.CommandType = CommandType.StoredProcedure;

							command.Parameters.Add("@Cod_Cli", SqlDbType.VarChar);
							command.Parameters["@Cod_Cli"].Value = UtilidadesGenerales.SoloNumeros(cadena[1].ToString());

							command.Parameters.Add("@Nombre", SqlDbType.VarChar);
							command.Parameters["@Nombre"].Value = cadena[2].ToString();

							command.Parameters.Add("@Nit", SqlDbType.VarChar);
							command.Parameters["@Nit"].Value = UtilidadesGenerales.SoloNumeros(cadena[1].ToString());

							command.Parameters.Add("@Placa", SqlDbType.VarChar);
							command.Parameters["@Placa"].Value =  cadena[0].ToString();

							command.Parameters.Add("@Ciudad", SqlDbType.VarChar);
							command.Parameters["@Ciudad"].Value = ciudad;

							command.Parameters.Add("@Contador", SqlDbType.Int);
							command.Parameters["@Contador"].Value = i;

							#endregion
	 
							#region Execute SqlCommand
							FilasAfectadas = command.ExecuteNonQuery();
							#endregion	
											
						}
					}
					catch (SqlException e)
					{
						resultado += e.Message + " !ERROR BD! ";
					}

				}
				connection.Close();

			resultado += Libreria.UtilidadesGenerales.MoverArchivoAProcesados(directorio,DateTime.Now.ToString("yyyyMMdd.HHmmss."),true);
			if(resultado.Length == 0)
				return "OK";		
			else
			{
				Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, 0,   	
					resultado  + " !ERROR APP! ", " Error interno importando el archivo de Clientes Corporativos. ");
				return resultado;
			}
		
			#endregion 
			
		}
		#endregion

		#region Genera numero de registro para ventas estandar
		private string NumeroRegistro(string separador)
		{
			return Convert.ToString(_numeroRegistro+=1) + separador;
		}
		#endregion

		#region Generar plano de Ventas Estandar
		/// <summary>
		/// Genera el archivo plano de ventas para la interfaz contable Estandar
		/// </summary>
		/// <param name="fecha">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="cod_isl">Numero de isla a consultar</param>
		/// <param name="turno">Turno a consultar</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		public string PlanoFacturasEstandar(string DirectorioTemporal, DateTime fecha,int cod_isl,int turno) 
		{
			#region Declaraciones
			string filaTexto;
			string filaTextoAux;
			_numeroRegistro=0;
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;			
			objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
			string valorAux;
			if(objInterfazContables.Count == 0) 
			{
				return ("Error! Por favor configure la interfaz contable estandar en Administrativo > panel de control > Interfaz Contable, gracias.");
			}
			objInterfazContable = objInterfazContables[0];
			DataSet ds;
			Int16 [,] estructuraPlano = new Int16[0,0];
			bool anchoFijo = false;
			string separador = "©"; //interno
			string separadorConfigurado = "|"; //configurado
			string separadorDecimal = ".";
			string formatoFecha = "DD/MM/YYYY";
			string nombreArchivo = "Fact-DD-MM-YYYY.txt";
			#endregion
 
			#region Recuperar la estructura flexible del plano			
			#region cargar columnas
			ds = UtilidadesGenerales.RecuperarEstructuraPlano(0,"","Columna","FacturaEstandar");
			if(ds.Tables[0].Rows.Count >= 0)
			{
				estructuraPlano = new Int16 [ds.Tables[0].Rows.Count,6]; //codigocolumna(8), orden(2), tamaño(5), Mascara(9), Acii(10), Direccion(11)
				for(int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					estructuraPlano[i,0] = (Int16)(ds.Tables[0].Rows[i][8]); //codigocolumna
					estructuraPlano[i,1] = (Int16)(ds.Tables[0].Rows[i][2]); //orden
					estructuraPlano[i,2] = (Int16)(ds.Tables[0].Rows[i][5]); //tamaño
					estructuraPlano[i,3] = (Int16)(ds.Tables[0].Rows[i][9]); //mascara
					estructuraPlano[i,4] = (Int16)(ds.Tables[0].Rows[i][10]); //Ascii del relleno
					estructuraPlano[i,5] = (Int16)(ds.Tables[0].Rows[i][11]); //Direccion del relleno 1:Izquierdo 2:Derecho
				}
			}

			#endregion

			#region carga el resto de configuraciones
			if(ds.Tables.Count > 5)
			{
				//carga ancho			
				if(ds.Tables[1].Rows.Count >= 0)				
					anchoFijo = ds.Tables[1].Rows[0][1].ToString().Trim()=="Si"?true:false;			
			
				//carga separador			
				if(ds.Tables[2].Rows.Count >= 0)				
					separadorConfigurado = ds.Tables[2].Rows[0][1].ToString();			
			
				//carga separador decimales
				if(ds.Tables[3].Rows.Count >= 0)
					separadorDecimal = ds.Tables[3].Rows[0][1].ToString();			

				//carga fecha
				if(ds.Tables[4].Rows.Count >= 0)
					formatoFecha = ds.Tables[4].Rows[0][1].ToString();			

				//carga nombre archivo
				if(ds.Tables[5].Rows.Count >= 0)
					nombreArchivo = ds.Tables[5].Rows[0][1].ToString().Replace("DD",fecha.ToString("dd")).Replace("MM",fecha.ToString("MM")).Replace("YYYY",fecha.ToString("yyyy")).Replace("HH",DateTime.Now.ToString("HH")).Replace("mm",DateTime.Now.ToString("mm")).Replace("SS",DateTime.Now.ToString("ss"));			
			}
			ds = null;
			#endregion

			#endregion

			#region Directorio temporal y nombre del archivo
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,2,"*.txt");
			nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoContableEstandar");
			sql.ParametersNumber = 3;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fecha);
			if(cod_isl != 0)
				sql.AddParameter("@cod_isl", SqlDbType.Int, cod_isl);
			if(turno != 0)
				sql.AddParameter("@num_turn", SqlDbType.Int, turno);

			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					#region fila de datos basicos del registro
					//				if(ds.Tables[0].Rows[i]["consecutivo"].ToString() == "464701")
					//					filaTexto = "";
					filaTexto += ds.Tables[0].Rows[i]["ano"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["periodo"].ToString() + separador;
					filaTexto += objInterfazContable.NUMCompFacturas + separador;
					filaTexto += ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["fecha"].ToString() + separador;
					#endregion

					#region fila de descuentos
					if(Decimal.Parse(ds.Tables[0].Rows[i]["descuento"].ToString())>0)
					{					
						filaTextoAux = objInterfazContable.NCDescuento + separador;
						filaTextoAux += objInterfazContable.CODSucursal + separador;
						filaTextoAux += objInterfazContable.CODCentroCostos + separador;
						if(objInterfazContable.NTDescuento)
							filaTextoAux += ds.Tables[0].Rows[i]["nit"].ToString() + separador;
						else
							filaTextoAux += "" + separador;
						filaTextoAux += "FRA" + ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
						if(objInterfazContable.NATDescuento)
						{
							filaTextoAux += "0.000" + separador;
							filaTextoAux += ds.Tables[0].Rows[i]["descuento"].ToString().Replace(",",".");
						}
						else
						{						
							filaTextoAux += ds.Tables[0].Rows[i]["descuento"].ToString().Replace(",",".") + separador;
							filaTextoAux += "0.000";
						}
						writer.WriteLine(UtilidadesGenerales.FormatearEstructura(NumeroRegistro(separador) + filaTexto + filaTextoAux,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, false));
					}
					#endregion

					#region fila de iva
					if(Decimal.Parse(ds.Tables[0].Rows[i]["vr_iva"].ToString())>0)
					{

						filaTextoAux = objInterfazContable.NCIva + separador;
						filaTextoAux += objInterfazContable.CODSucursal + separador;
						filaTextoAux += objInterfazContable.CODCentroCostos + separador;
						if(objInterfazContable.NTIva)
							filaTextoAux += ds.Tables[0].Rows[i]["nit"].ToString() + separador;
						else
							filaTextoAux += "" + separador;
						filaTextoAux += "FRA" + ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
						if(objInterfazContable.NATIva)
						{
							filaTextoAux += "0.000" + separador;
							filaTextoAux += ds.Tables[0].Rows[i]["vr_iva"].ToString().Replace(",",".");
						}
						else
						{						
							filaTextoAux += ds.Tables[0].Rows[i]["vr_iva"].ToString().Replace(",",".") + separador;
							filaTextoAux += "0.000";
						}
						writer.WriteLine(UtilidadesGenerales.FormatearEstructura(NumeroRegistro(separador) + filaTexto + filaTextoAux,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, false));
					}
					#endregion

					#region fila de cuota
					if(Decimal.Parse(ds.Tables[0].Rows[i]["total_cuota"].ToString())>0)
					{

						filaTextoAux = objInterfazContable.NCAbono + separador;
						filaTextoAux += objInterfazContable.CODSucursal + separador;
						filaTextoAux += objInterfazContable.CODCentroCostos + separador;
						if(objInterfazContable.NTAbono)
							filaTextoAux += ds.Tables[0].Rows[i]["nit"].ToString() + separador;
						else
							filaTextoAux += "" + separador;
						filaTextoAux += "FRA" + ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
						if(objInterfazContable.NATIva)
						{
							filaTextoAux += "0.000" + separador;
							filaTextoAux += ds.Tables[0].Rows[i]["total_cuota"].ToString().Replace(",",".");
						}
						else
						{						
							filaTextoAux += ds.Tables[0].Rows[i]["total_cuota"].ToString().Replace(",",".") + separador;
							filaTextoAux += "0.000";
						}
						writer.WriteLine(UtilidadesGenerales.FormatearEstructura(NumeroRegistro(separador) + filaTexto + filaTextoAux,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado,false));
					}
					#endregion

					#region fila de articulo
					if(ds.Tables[0].Rows[i]["cuentaArticulo"].ToString().Length > 0 )
					{
						filaTextoAux = ds.Tables[0].Rows[i]["cuentaArticulo"].ToString() + separador;
						filaTextoAux += objInterfazContable.CODSucursal + separador;
						filaTextoAux += objInterfazContable.CODCentroCostos + separador;
						filaTextoAux += "" + separador; //no maneja terceros
						filaTextoAux += "FRA" + ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
						valorAux = Convert.ToString(decimal.Parse(ds.Tables[0].Rows[i]["valorneto"].ToString()) - decimal.Parse(ds.Tables[0].Rows[i]["vr_iva"].ToString())).Replace(",",".");
						if(bool.Parse(ds.Tables[0].Rows[i]["naturalezaArticulo"].ToString()))
						{
							filaTextoAux += "0.000" + separador;
							filaTextoAux += valorAux;
						}
						else
						{						
							filaTextoAux += valorAux + separador;
							filaTextoAux += "0.000";
						}
						writer.WriteLine(UtilidadesGenerales.FormatearEstructura(NumeroRegistro(separador) + filaTexto + filaTextoAux,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado,false));
					}
					#endregion

					#region fila de forma de pago
					if(ds.Tables[0].Rows[i]["cuentaFormaPago"].ToString().Length > 0)
					{
						filaTextoAux = ds.Tables[0].Rows[i]["cuentaFormaPago"].ToString() + separador;
						filaTextoAux += objInterfazContable.CODSucursal + separador;
						filaTextoAux += objInterfazContable.CODCentroCostos + separador;
						if(bool.Parse(ds.Tables[0].Rows[i]["terceroFormaPago"].ToString())) //no maneja terceros
							filaTextoAux += ds.Tables[0].Rows[i]["nit"].ToString() + separador;
						else
							filaTextoAux += "" + separador;
						filaTextoAux += "FRA" + ds.Tables[0].Rows[i]["consecutivo"].ToString() + separador;
						//valorAux = Convert.ToString(decimal.Parse(ds.Tables[0].Rows[i]["valorneto"].ToString()) - decimal.Parse(ds.Tables[0].Rows[i]["descuento"].ToString())).Replace(",","."); //subtotal
						valorAux = Convert.ToString(decimal.Parse(ds.Tables[0].Rows[i]["total"].ToString())).Replace(",",".");
						if(bool.Parse(ds.Tables[0].Rows[i]["naturalezaFormaPago"].ToString()))
						{
							filaTextoAux += "0.000" + separador;
							filaTextoAux += valorAux;
						}
						else
						{						
							filaTextoAux += valorAux + separador;
							filaTextoAux += "0.000";
						}
						writer.WriteLine(UtilidadesGenerales.FormatearEstructura(NumeroRegistro(separador) + filaTexto + filaTextoAux,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado,false));
					}
					#endregion
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de facturas para la interfaz contable estandar. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion

		#region Generar plano de Totatales Estandar
		/// <summary>
		/// Genera el archivo plano de totales para la interfaz contable Estandar
		/// </summary>
		/// <param name="nombreArchivo">Ruta y nombre del archivo que se generar</param>
		/// <param name="fecha">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="separador">Caractér separador entre campos</param>
		/// <param name="cod_isl">Numero de isla a consultar</param>
		/// <param name="turno">Turno a consultar</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		public string PlanoTotalesEstandar(string nombreArchivo, string DirectorioTemporal, DateTime fecha,int cod_isl,int turno,string separador) 
		{
			#region Declaraciones
			string filaTexto;
			_numeroRegistro=0;
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;			
			objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();			
			if(objInterfazContables.Count == 0) 
			{
				return ("Error! Por favor Configure la Interfaz Contable Estandar en el panel de control, gracias.");
			}
			objInterfazContable = objInterfazContables[0];
			DataSet ds;
			#endregion

			#region Directorio temporal y nombre del archivo
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,2,"*.txt");
			nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoContableEstandar");
			sql.ParametersNumber = 3;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fecha);
			sql.AddParameter("@Opcion", SqlDbType.Int, 2);			
			if(turno != 0)
				sql.AddParameter("@num_turn", SqlDbType.Int, turno);

			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim();
						if(j<ds.Tables[0].Columns.Count-1)
								filaTexto += separador;	
					
					}									
					writer.WriteLine(EspacioPlanoTotales(filaTexto,separador));
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de totales para la interfaz contable estandar. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion

		#region Generar plano de Terceros Estandar
		/// <summary>
		/// Genera el archivo plano de terceros para la interfaz contable Estandar
		/// </summary>
		/// <param name="nombreArchivo">Ruta y nombre del archivo que se generar</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		/// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
		/// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
		/// <param name="separador">Caractér separador entre campos</param>
		public string PlanoTercerosEstandar(string nombreArchivo, string DirectorioTemporal, DateTime fechaInicial,DateTime fechaFinal,string separador)
		{
			#region Declaraciones
			string filaTexto;
			_numeroRegistro=0;
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;			
			objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();			
			if(objInterfazContables.Count == 0) 
			{
				return ("Error! Por favor Configure la Interfaz Contable Estandar en el panel de control, gracias.");
			}
			objInterfazContable = objInterfazContables[0];
			DataSet ds;
			#endregion

			#region Directorio temporal y nombre del archivo
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,2,"*.txt");
			nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoTercerosEstandar");
			sql.ParametersNumber = 2;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);

			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim();
						if(j<ds.Tables[0].Columns.Count-1)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(EspacioPlanoTerceros(NumeroRegistro(separador) + filaTexto,separador));
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de terceros para la interfaz contable estandar. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion

		#region Generar plano de Articulos Estandar
		/// <summary>
		/// Genera el archivo plano de terceros para la interfaz contable Estandar
		/// </summary>
		/// <param name="nombreArchivo">Ruta y nombre del archivo que se generar</param>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		/// <param name="fechaInicial">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
		/// <param name="turno">Turno a consultar</param>
		/// <param name="separador">Caractér separador entre campos</param>
		public string PlanoArticulosEstandar(string nombreArchivo, string DirectorioTemporal, DateTime fechaInicial,DateTime fechaFinal,int turno,string separador)
		{
			#region Declaraciones
			string filaTexto;
			_numeroRegistro=0;
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;			
			objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();			
			if(objInterfazContables.Count == 0) 
			{
				return ("Error! Por favor Configure la Interfaz Contable Estandar en el panel de control, gracias.");
			}
			objInterfazContable = objInterfazContables[0];
			DataSet ds;
			#endregion

			#region Directorio temporal y nombre del archivo
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			UtilidadesGenerales.LimpiarDirectorio(DirectorioTemporal,2,"*.txt");
			nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoArticulosEstandar");
			sql.ParametersNumber = 3;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);
			if(turno != 0)
				sql.AddParameter("@num_turn", SqlDbType.Int, turno);

			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim();
						if(j<ds.Tables[0].Columns.Count-1)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(EspacioPlanoArticulos(filaTexto,separador));
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas por articulo. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion

		#region Validar codigos alternos repetidos para importar SAP
		
		/// <summary>
		/// Método para obtener codigos alternos repetidos de clientes
		/// </summary>
		public static DataSet ValdidarCodigoClienteSap()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ValdidarCodigoClienteSap");
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure,sql.Text));
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message);
			}
			finally 
			{
				sql = null;
			}

			#endregion
		}
		#endregion

		#region Generar Plano de total de lecturas para SAP
		/// <summary>
		/// Genera el archivo plano de totales para SAP
		/// </summary>
		/// <param name="nombreArchivo">Ruta y nombre del archivo que se genera, si es vacio el sistema autoidentificara la ruta configurada para SAP</param>
		/// <param name="fechaInicial">Fecha inicial de la cual se desea consultar la informacion para el archivo plano</param>
		/// <param name="turno">Turno a consultar</param>
		/// <param name="separador">Caractér separador entre campos</param>
		public static string PlanoTotalLecturasSap(string nombreArchivo, 
											DateTime fechaInicial,
											int turno,
											string separador) 
		{

			#region Declaraciones
			string filaTexto="";	
			string resultado="";
			DataSet ds;
			char separadorEspecial;
			Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
			Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;
			Configuracion.Dat_Gene objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
			Configuracion.Datos_Gene objDatos_Gene; //= new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();			
			Configuracion.Comunicacion objComunicacion = new Servipunto.Estacion.Libreria.Configuracion.Comunicacion();
			Configuracion.Comunicaciones objComunicaciones; //= new Servipunto.Estacion.Libreria.Configuracion.Comunicaciones();

			if(separador=="")
			{
				separadorEspecial = (char)9;
				separador = separadorEspecial.ToString();
			}
			#endregion
			
			#region Directorio de exportación
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			//nombre de archivo
			try 
			{

				if(nombreArchivo == "")
				{
					objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
					if(objInterfazContables.Count == 0) 
					{
						EscribirLog("Error! Por favor Configure la Interfaz Contable para SAP en: Administrativo > Panel de control > Interfaz contable, gracias.");
						return "Error! Por favor Configure la Interfaz Contable para SAP en: Administrativo > Panel de control > Interfaz contable, gracias";
					}
					objInterfazContable = objInterfazContables[0];

					
					nombreArchivo = objInterfazContable.RutaExportarSap.Trim();
					if(nombreArchivo == "")
						throw new Exception("Error, debe de configurar en: Administrativo > Panel de control > Interfaz contable > SAP > Importacion - Exportacion y otros, la ruta de exportación para archivos planos de SAP");

					if(objInterfazContable.CodigoEstacionSap.Trim() == "")
						throw new Exception("Error, debe de configurar en: Administrativo > Panel de control > Interfaz contable > SAP > Importacion - Exportacion y otros, el codigo de estación SAP");

						nombreArchivo += "\\" + objInterfazContable.CodigoEstacionSap.Trim().PadLeft(10,'0') + fechaInicial.ToString("yyyyMMdd") + ".txt";
						
						//System.IO.Directory.CreateDirectory(DirectorioTemporal);
						UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");

				}
			}
			catch(Exception exception)
			{
				
				EscribirLog((" Configuración invalida de SAP. " + exception.Message.ToString()));
				throw new Exception (" Configuración invalida de SAP.   " + exception.Message.ToString());
			}	

			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperTotalLecturas");
			sql.ParametersNumber = 3;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaInicial);
			if(turno != 0)
				sql.AddParameter("@num_tur", SqlDbType.Int, turno);

			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text,sql.Parameters);
			}
			catch(SqlException ex)
			{
				EscribirLog("Error interno realizando la consulta de lecturas para SAP. " + ex.Message);
				throw new Exception ("Error interno realizando la consulta de lecturas para SAP. " + ex.Message);

			}

			finally 
			{
				sql = null;
			}
			#endregion

			#region Generar plano con los registros

			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim();
						if(j<ds.Tables[0].Columns.Count-1)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	

					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de totales de lecturas para SAP. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				}

				
			}
			
			writer.Close();
			ds.Dispose();

			#endregion		

			#region enviar por FTP

			
			objComunicaciones = new Servipunto.Estacion.Libreria.Configuracion.Comunicaciones();
			if(objComunicaciones.Count > 0) 
			{
				objComunicacion = objComunicaciones[0];
				if(objComunicacion.FtpServerIp.Trim().Length <= 0)
					goto Final;

				if(objComunicacion.FtpUserName.Trim().Length <= 0)
					goto Final;

				if(objComunicacion.FtpPort <= 0)
					goto Final;

				if(objComunicacion.FtpUserPasswd.Length <= 0)
					goto Final;

				try
				{
					resultado = objComunicaciones.EnviarAFTP(objComunicacion.FtpServerIp,
						objComunicacion.FtpUserName,
						objComunicacion.FtpUserPasswd,
						objComunicacion.FtpPort,
						nombreArchivo,
						"",
						objComunicacion.FtpVirtualDirectory,
						true,
						true
						);
												
					if(resultado.Length > 0)
						EscribirLog(" Error al enviar el archivo de Lecturas via FTP: " + resultado);

				}
				catch(Exception ex)
				{
					EscribirLog(" Error la enviar el archivo via FTP: " + ex.Message);					
				}

			}
			
				#endregion

		Final:
				return "OK," + nombreArchivo; 
		}
		#endregion	

		#region Generar plano de ventas Credito o Contado
		/// <summary>
		/// Genera un plano de ventas Credito o Contado
		/// <param name="fechaInicial">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="fechaFinal">Fecha de la cual se desea hacer el archivo plano</param>
		/// <param name="caso">Tipo de archivo; 1. Ventas credito, 2. Ventas de contado</param>
		/// </summary>
		public static string PlanoVentasCotadoOCredito(
											DateTime fechaInicial,
											DateTime fechaFinal,
											int caso
											)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;			
			string separador = "|";
			string codigoSucursal = "";
			DataSet ds;
			Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
			#endregion

			#region Ruta Exportacion y nombre del archivo
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
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
			codigoSucursal = codigoSucursal.PadLeft(3,'0');
			nombreArchivo = fechaInicial.ToString("yyyyMMdd") + ".RM" + caso.ToString();
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperVentasCreditoOContado");
			sql.ParametersNumber = 3;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);
			sql.AddParameter("@caso", SqlDbType.Int, caso);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim();
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(EspacioPlanoCreditoOContado(filaTexto + codigoSucursal,separador));
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas credito o contado. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);

					}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion

		#region Generar plano de ventas no transmitidas 
		/// <summary>
		/// Generar plano de ventas no transmitidas hacia el servidor de un tercero
		/// </summary> 
		/// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
		/// <param name="fechaFinal">Fecha final de la cual se desea hacer el archivo plano</param>
		/// <param name="separador">Separador de registros en el archivo plano</param>
		/// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_003_GR_SC
		/// Fecha:  09/09/2008
		/// Autor:  Elvis Astaiza Gutierrez		
		public static string PlanoVentasNoTransmitidas(
			DateTime fechaInicial,
			DateTime fechaFinal,
			string separador
			)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;		
			string ultimoConsecutivo="";
			string cadena;
			separador = separador.Trim()==""?"|":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "E" +
							objDat_Gene.CodigoSucursal.ToString() +
							DateTime.Now.ToString("ddMMyyyy") + 
							".csv";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperarVentasNoTransmitidas");
			sql.ParametersNumber = 2;
			sql.AddParameter("@FechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@FechaFinal", SqlDbType.DateTime, fechaFinal);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros
			
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			filaTexto = "TIPO;CONSECUTIVO;FECHA_EMI;FECHA_REA;HORA;TURNO;COD_ISL;COD_MAN;NUMTAR;COD_CLI;PLACA;FINANCIERA;HORA_INI;HORA_TER;LECT_INI;LECT_FIN;TOTAL_CON;TOTAL_CUO;GRAN_TOTAL;VAL_COMB;GAL_CONS;ANULADO;COD_SUC;CANAL_DED;ID_ROM_SUI;".Replace(";",separador);
			writer.WriteLine(filaTexto);
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{
					filaTexto = "";
					ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						cadena = ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(cadena.LastIndexOf(".") > 0 && cadena.Length > 3) //trunca a 2 decimales
							filaTexto += (cadena.Length - cadena.LastIndexOf(".")==4?cadena.Substring(0,cadena.Length -1):cadena); 
						else
							filaTexto += cadena;

						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;						
					}									
					writer.WriteLine(filaTexto);					
				}
				catch(Exception ex)				
				{						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas transmitidas. ");
					}
					catch(Exception)
					{}
					#endregion
				}				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo + "," + ultimoConsecutivo; 
		}

		#endregion

		#region Genera plano de ventas Reporte Master
		/// <summary>
		/// Genera plano de ventas llamado Reporte Master
		/// </summary>
		/// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
		/// <param name="turno">Turno del cual se quiere hacer el reporte</param>
		/// <param name="separador">Separador de registros en el archivo plano</param>
		
		public static string PlanoMasterReporte(
			DateTime fechaInicial,
			int turno,
			string separador
			)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;	
			string dato;
			separador = separador.Trim()==""?"·":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "01_" +
				 System.DateTime.Now.ToString("yyyyMMddHHmmss") +  //fechaInicial.ToString("yyyyMMddhhmmss") + 
				".dep";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperMasterReporte");
			sql.ParametersNumber = 2;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@turno", SqlDbType.Int, turno);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					//ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						dato = ds.Tables[0].Rows[i][j].ToString().Trim()==""?"-":ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(j >=1  && j <= 6)
							dato = dato.PadLeft(2,'0');
						filaTexto += dato;
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de ventas Reporte Master. ");
					}
					catch(Exception)
					{}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion		

		#region Genera plano de Mapa Master
		/// <summary>
		/// Genera plano de articulos llamado Master
		/// </summary>
		
		public static string PlanoMasterMapa(string separador)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;	
			separador = separador.Trim()==""?"·":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "03_" +
				System.DateTime.Now.ToString("yyyyMMddHHmmss") +  //fechaInicial.ToString("yyyyMMddhhmmss") + 
				".dep";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperMasterMapa");
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					//ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim()==""?"-":ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de Mapa Master. ");
					}
					catch(Exception)
					{}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion		

		#region Genera plano de ventas Totales Electronicos Master
		/// <summary>
		/// Genera plano de totales de lecturas llamado Totales Electronicos Master
		/// </summary>
		/// <param name="fechaInicial">Fecha inicial de la cual se desea hacer el archivo plano</param>
		/// <param name="turno">Turno del cual se quiere hacer el reporte</param>
		/// <param name="separador">Separador de registros en el archivo plano</param>
		
		public static string PlanoMasterTotalesElectronicos(
			DateTime fechaInicial,
			int turno,
			string separador
			)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;	
			string dato;
			separador = separador.Trim()==""?"·":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "06_" +
				System.DateTime.Now.ToString("yyyyMMddHHmmss") +  //fechaInicial.ToString("yyyyMMddhhmmss") + 
				".dep";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperMasterTotalesElectronicos");
			sql.ParametersNumber = 2;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@turno", SqlDbType.Int, turno);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					//ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						dato = ds.Tables[0].Rows[i][j].ToString().Trim()==""?"-":ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(j >=1  && j <= 6)
							dato = dato.PadLeft(2,'0');
						filaTexto += dato;
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de Totales Electronicos Master. ");
					}
					catch(Exception)
					{}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion		

		#region Genera plano de Precios de Articulos Master
		/// <summary>
		/// Generar plano de precios de Articulos Master
		/// </summary>
		
		public static string PlanoMasterPrecios(string separador)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;	
			separador = separador.Trim()==""?"·":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "09_" +
				System.DateTime.Now.ToString("yyyyMMddHHmmss") +  //fechaInicial.ToString("yyyyMMddhhmmss") + 
				".dep";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperMasterPrecios");
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					//ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim()==""?"-":ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de Precios Master. ");
					}
					catch(Exception)
					{}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion		

		#region Genera plano de Precios de Articulos Master
		/// <summary>
		/// Generar plano de Cuentas de clientes Master
		/// </summary>
		
		public static string PlanoMasterCuentas(string separador)
		{
			#region Declaraciones
			string nombreArchivo;
			string directorio;
			string filaTexto;	
			separador = separador.Trim()==""?"·":separador;
			DataSet ds;
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
				{}
				#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			
			nombreArchivo = "10_" +
				System.DateTime.Now.ToString("yyyyMMddHHmmss") +  //fechaInicial.ToString("yyyyMMddhhmmss") + 
				".dep";
			System.IO.Directory.CreateDirectory(directorio);
			nombreArchivo = directorio + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("RecuperMasterCuentas");
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");

			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";
					//ultimoConsecutivo = ds.Tables[0].Rows[i]["consecutivo"].ToString();
					for(int j=0; j<ds.Tables[0].Columns.Count; j++ )
					{
						filaTexto += ds.Tables[0].Rows[i][j].ToString().Trim()==""?"-":ds.Tables[0].Rows[i][j].ToString().Trim().Replace(",",".");
						if(j<ds.Tables[0].Columns.Count)
							filaTexto += separador;	
					
					}									
					writer.WriteLine(filaTexto);
					
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de Cuentas Master. ");
					}
					catch(Exception)
					{}
					#endregion
				}

				
			}
			
			writer.Close();

			#endregion		

			ds.Dispose();
			return "OK," + nombreArchivo; 
		}

		#endregion		

		#region Importar archivos Planos de Novedades Gases de Occidente
		/// <summary>
		/// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_013_DT_SC
		/// Descripcion: Importa las novedades de gases occidente
		/// Autor: Rodrigo Figueroa Rivera
		/// Fecha creación: 25/10/2008
		/// </summary>
		/// <param name="rutaArchivo">Ruta y nombre del archivo que se importará</param>
		/// <param name="separador">Separador</param>
		
		public static string ImportarPlanosNovedadesGDO(string rutaArchivo,string separador) 
		{
			#region Declaraciones
			ArrayList arreglo = new ArrayList();
			ArrayList arregloConSeparador = new ArrayList();			
			string [] cadena;
			string directorio = "";			
			string resultado = "";		
			InterfazContables objInterfazContables = new InterfazContables();
			InterfazContable objInterfazContable = new InterfazContable();						
			int FilasAfectadas = 0;
			FileSystemInfo [] files = null;   //Arreglo de Archivos a procesar
			// Tamaño de columnas del archivo a importar
			int[] arregloTamañoColumnas = {2,40,14,65,10,18,10,8,10,1,5,13,3,3,13,6}; 
			int numErrores = 0; 
			#endregion			

			#region Existencia de Directorio de recibidos								
			// Verificar Existencia del directorio, si no existe se crea
			if ( !System.IO.Directory.Exists(rutaArchivo))			
				System.IO.Directory.CreateDirectory(rutaArchivo);
			#endregion

			#region Obtener Archivos directorio
			directorio = rutaArchivo;
			DirectoryInfo dir = new DirectoryInfo( directorio );
			files = dir.GetFileSystemInfos("*.txt");
			if ( files.Length <= 0)
			{
				return "Error, No se encontraron archivos para procesar en la ruta " + dir.Name + ", gracias.";
			}
			#endregion

			#region Verificar ruta y conectar a la  base de base de datos
			// Se toma el primer archivo y es el unico que se procesa
			string ArchivoProcesar = rutaArchivo + "\\"  + files[0].Name ;			
			// Leer Archivo y armar un arraylists con los registros leidos
			if ( !File.Exists(ArchivoProcesar))			
				return "Error, No se encontraron archivos para procesar en la ruta " + ArchivoProcesar + ", gracias.";

			//Obtener Conexion Base de datos
			SqlConnection connection = new SqlConnection(Aplicacion.Conexion.ConnectionString);
			// Abrir Conexion
			connection.Open();
			#endregion

			#region Leer Archivo y Llenar arreglos de registros
			// Obtener arreglo de registros por cada registro del archivo
			// Obtener arreglo con separador
			arreglo = LeerArchivo(ArchivoProcesar);
			separador = separador.Trim()==""?";":separador.Trim();
			arregloConSeparador = AdministradorArchivos.ColocarSeparador(arreglo,arregloTamañoColumnas,separador, "c:\\logImportacionGDO.txt", false, ref numErrores);
			string valor;
			#endregion

			#region Leer Registros y Procesar Novedades
			for(int i=0; i<arregloConSeparador.Count; i++) //recorre la lista del archivo plano para crear o modificar los clientes y sus automotores
			{
				try
				{

					cadena = arregloConSeparador[i].ToString().Split(separador.ToCharArray());
					if(cadena.Length == 16 )
					{
						#region Prepare Sql Command para actualizar los clientes corporativos  y sus vehiculos 
						SqlCommand command = new SqlCommand("ActualizarNovedadesGDO", connection);
						command.CommandType = CommandType.StoredProcedure;						

						command.Parameters.Add("@Concepto", SqlDbType.VarChar);
						command.Parameters["@Concepto"].Value = cadena[0].ToString();

						command.Parameters.Add("@Nombre", SqlDbType.VarChar);
						command.Parameters["@Nombre"].Value = cadena[1].ToString();

						command.Parameters.Add("@Cedula", SqlDbType.VarChar);
						command.Parameters["@Cedula"].Value = cadena[2].ToString();

						command.Parameters.Add("@Direccion", SqlDbType.VarChar);
						command.Parameters["@Direccion"].Value = cadena[3].ToString();

						command.Parameters.Add("@SolCredito", SqlDbType.VarChar);
						command.Parameters["@SolCredito"].Value =  cadena[4].ToString();

						command.Parameters.Add("@Telefono", SqlDbType.VarChar);
						command.Parameters["@Telefono"].Value = cadena[5].ToString();

						command.Parameters.Add("@Placa", SqlDbType.VarChar);
						command.Parameters["@Placa"].Value = cadena[6].ToString();

						command.Parameters.Add("@ServSuscriptor", SqlDbType.VarChar);
						command.Parameters["@ServSuscriptor"].Value = cadena[7].ToString();

						command.Parameters.Add("@Fecha", SqlDbType.VarChar);
						command.Parameters["@Fecha"].Value = cadena[8].ToString();

						command.Parameters.Add("@HoraMilitar", SqlDbType.VarChar);
						command.Parameters["@HoraMilitar"].Value = cadena[10].ToString();

						valor = cadena[11].Replace(".", ",");
						command.Parameters.Add("@ValorRecaudo", SqlDbType.Decimal);
						command.Parameters["@ValorRecaudo"].Value = Convert.ToDecimal(valor);

						command.Parameters.Add("@Sucursal", SqlDbType.Int);
						command.Parameters["@Sucursal"].Value = Convert.ToInt32(cadena[12]);

						command.Parameters.Add("@EmpresaFinanciera", SqlDbType.TinyInt);
						command.Parameters["@EmpresaFinanciera"].Value = Convert.ToInt16(cadena[13]);

						valor = cadena[14].Replace(".", ",");
						command.Parameters.Add("@SaldoCapital", SqlDbType.Decimal);
						command.Parameters["@SaldoCapital"].Value = Convert.ToDecimal(valor);

						valor = cadena[15].Replace(".", ",");
						command.Parameters.Add("@PorcentajeRecaudo", SqlDbType.Decimal);
						command.Parameters["@PorcentajeRecaudo"].Value = Convert.ToDecimal(valor);

						#endregion
	 
						#region Execute SqlCommand
						FilasAfectadas = command.ExecuteNonQuery();
						#endregion	
											
					}
				}
				catch (SqlException e)
				{
					resultado += e.Message + " !ERROR BD! ";
				}

			}
			connection.Close();
			#endregion

			#region Mover Archivo procesado
			resultado += Libreria.UtilidadesGenerales.MoverArchivoAProcesadosGDO(ArchivoProcesar,DateTime.Now.ToString("yyyyMMdd.HHmmss."),true);
			if(resultado.Length == 0)
				return "OK";		
			else
			{
				Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
					2, 0,   	
					resultado  + " !ERROR APP! ", " Error interno importando el archivo de Clientes Corporativos. ");
				return resultado;
			}
			#endregion
			
		}
		#endregion
		
		#region Genera el archivo plano de recaudos para gases de occidente
		/// <summary>
		/// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_013_DT_SC
		/// Descripcion: Genera el archivo plano de recaudos para gases de occidente
		/// Autor: Rodrigo Figueroa Rivera
		/// Fecha: 25/10/2008
		/// </summary>
		/// <param name="fecha">Fecha real de las ventas con recaudo </param>			
		
		public static string PlanoRecaudosGDO(DateTime fecha) 
		{
		#region Declaraciones
			string filaTexto;													
			DataSet ds;
			string concepto = "10";			
			char cero = '0';
			string blanco = " ";
			char espacio = ' ';
			string hora;
			string strFinanciera = "";
		#endregion

		#region Armar nombre Archivo enviado
		string filename = "C:\\servipunto\\administ\\enviados\\";

		if ( !System.IO.Directory.Exists(filename) )
			System.IO.Directory.CreateDirectory(filename);

			#region Obtener datos sucursal datos generales
			Servipunto.Estacion.Libreria.Configuracion.Datos_Gene _objDat_Generales = null;
			_objDat_Generales = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objEstacion = _objDat_Generales[0];					
			string codSucursal  = objEstacion.CodigoSucursal.ToString().PadLeft(4,'0');
			#endregion

		filename += codSucursal;
		filename += fecha.Day.ToString().TrimEnd().PadLeft(2,'0');
		filename += fecha.Month.ToString().TrimEnd().PadLeft(2,'0');
		filename += fecha.Year.ToString().TrimEnd().PadLeft(4,'0');
		filename += ".txt";
		#endregion

 
		#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("GenerarPlanoRecaudosGDO");
			sql.ParametersNumber = 1;
			sql.AddParameter("@fecha", SqlDbType.DateTime, fecha);		

		#endregion

		#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");

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

		#region Generar plano con los registros

			FileStream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{

					filaTexto = "";					
					#region fila de datos basicos del registro					
					filaTexto += concepto.PadLeft(2, cero); //concepto
					filaTexto += ds.Tables[0].Rows[i].IsNull(0)? blanco.PadLeft(40,espacio): ds.Tables[0].Rows[i][0].ToString().Substring(0,40);  // nombre					
					filaTexto += ds.Tables[0].Rows[i].IsNull(1)? blanco.PadLeft(14, cero): ds.Tables[0].Rows[i][1].ToString().Substring(0,14); // Cedula
					filaTexto += ds.Tables[0].Rows[i].IsNull(2)? blanco.PadRight(65,espacio) : ds.Tables[0].Rows[i][2].ToString().PadRight(65,espacio); //direccion
					filaTexto += ds.Tables[0].Rows[i].IsNull(3)? blanco.PadLeft(10,cero) : ds.Tables[0].Rows[i][3].ToString().TrimEnd().PadLeft(10, cero);  //sol credito
					filaTexto += ds.Tables[0].Rows[i].IsNull(4)? blanco.PadRight(18, espacio): ds.Tables[0].Rows[i][4].ToString().TrimEnd().PadRight(18,' '); // telefono					
					filaTexto += ds.Tables[0].Rows[i].IsNull(5)? blanco.PadLeft(10,espacio): ds.Tables[0].Rows[i][5].ToString().TrimEnd().PadRight(10,espacio); // placa
					string serv = ds.Tables[0].Rows[i].IsNull(6)? blanco.PadLeft(8,cero): ds.Tables[0].Rows[i][6].ToString().TrimEnd().PadLeft(8,cero); // serv subscriptor
					filaTexto += serv;
					DateTime ffecha =  ds.Tables[0].Rows[i].IsNull(7)? DateTime.Now.Date: Convert.ToDateTime(ds.Tables[0].Rows[i][7]); // fecha
					filaTexto += ffecha.Day.ToString().TrimEnd().PadLeft(2,'0') + "/" +  ffecha.Month.ToString().TrimEnd().PadLeft(2,'0') + "/" + ffecha.Year.ToString().TrimEnd().PadLeft(4,'0'); 
					filaTexto += espacio ; //espacio					
					hora = ds.Tables[0].Rows[i].IsNull(8)? "00:00:00" : ds.Tables[0].Rows[i][8].ToString(); // hora
					filaTexto += hora.Length == 8 ? hora.Substring(0,5): cero + hora.Substring(0,4);
					decimal recaudo = ds.Tables[0].Rows[i].IsNull(9)? (decimal)0: Convert.ToDecimal(ds.Tables[0].Rows[i][9]); 
					filaTexto +=  (recaudo.ToString().TrimEnd().PadLeft(13, cero));  // sucursal
					int sucursal = ds.Tables[0].Rows[i].IsNull(10)? 0: Convert.ToInt32(ds.Tables[0].Rows[i][10]); 
					filaTexto += sucursal.ToString().TrimEnd().PadRight(3,espacio);					
					strFinanciera = ds.Tables[0].Rows[i].IsNull(11)? "000": ds.Tables[0].Rows[i][11].ToString(); // financiera					
					filaTexto += strFinanciera.TrimEnd().PadLeft(3, cero);
					decimal saldo = ds.Tables[0].Rows[i].IsNull(12)? (decimal)0: Convert.ToDecimal(ds.Tables[0].Rows[i][12]); // saldo
					filaTexto += saldo.ToString().TrimEnd().PadLeft(13, cero); 
					decimal porcentaje = ds.Tables[0].Rows[i].IsNull(13)? (decimal)0: Convert.ToDecimal(ds.Tables[0].Rows[i][13]); // porcentaje
					filaTexto += porcentaje.ToString().TrimEnd().PadLeft(6, cero);
					filaTexto = filaTexto.Replace(',', '.');
					writer.WriteLine(filaTexto);		
				}
				catch
				{
				}
			}
			writer.Close();		
			ds.Dispose();
			return "OK," + filename; 
		}
		#endregion
		#endregion

		#endregion

		#region Generar plano de Inventarios
		/// <summary>
		/// Genera el archivo plano de inventarios
		/// </summary>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		/// <param name="fecha">Fecha de turno</param>
		/// <param name="turno">Turno a consultar</param>
		/// <param name="isla">Isla a consultar</param>
		/// Referencia Documental:  Automatizacion > Automatizacion de Islas_DT_SC_16
		/// Fecha:  26/08/2008 11:56 a.m.
		/// Autor:  Elvis Astaiza Gutierrez			

		/// Actualizacion: Se incluyo filtro por isla y se actualizo el nombre del archivo
		/// Referencia Documental:  (Falta)
		/// Fecha:  31/03/2009 03:56 p.m.
		/// Autor:  Elvis Astaiza Gutierrez			

		public string PlanoInventarios(string DirectorioTemporal, DateTime fecha,int turno, int isla) 
		{
			#region Declaraciones
			Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
			string filaTexto;			
			_numeroRegistro=0;
			int numeroItem = 1;
			string consecutivoAnterior = "";
			DataSet ds;
			Int16 [,] estructuraPlano = new Int16[0,0];
			bool anchoFijo = false;
			string separador = "©"; //interno
			string separadorConfigurado = "|"; //configurado
			string separadorDecimal = ".";
			string formatoFecha = "DD/MM/YYYY";
			string nombreArchivo = "Fact-DD-MM-YYYY.txt";
			string directorioExportar;			
			#endregion

			#region Directorio de exportacion configurado
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			directorioExportar = objDat_Gene.RutaExportarPredeterminada;
			if(directorioExportar == "")
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
			#endregion
 
			#region Recuperar la estructura flexible del plano	
		
			#region cargar columnas
			ds = UtilidadesGenerales.RecuperarEstructuraPlano(0,"","Columna","Inventarios");
			if(ds.Tables[0].Rows.Count >= 0)
			{
				estructuraPlano = new Int16 [ds.Tables[0].Rows.Count,6]; //codigocolumna(8), orden(2), tamaño(5), Mascara(9), Acii(10), Direccion(11)
				for(int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					estructuraPlano[i,0] = (Int16)(ds.Tables[0].Rows[i][8]); //codigocolumna
					estructuraPlano[i,1] = (Int16)(ds.Tables[0].Rows[i][2]); //orden
					estructuraPlano[i,2] = (Int16)(ds.Tables[0].Rows[i][5]); //tamaño
					estructuraPlano[i,3] = (Int16)(ds.Tables[0].Rows[i][9]); //mascara
					estructuraPlano[i,4] = (Int16)(ds.Tables[0].Rows[i][10]); //Ascii del relleno
					estructuraPlano[i,5] = (Int16)(ds.Tables[0].Rows[i][11]); //Direccion del relleno 1:Izquierdo 2:Derecho
				}
			}
			#endregion

			#region carga el resto de configuraciones
			if(ds.Tables.Count > 5)
			{
				//carga ancho			
				if(ds.Tables[1].Rows.Count >= 0)				
					anchoFijo = ds.Tables[1].Rows[0][1].ToString().Trim()=="Si"?true:false;			
			
				//carga separador			
				if(ds.Tables[2].Rows.Count >= 0)				
					separadorConfigurado = ds.Tables[2].Rows[0][1].ToString();			
			
				//carga separador decimales
				if(ds.Tables[3].Rows.Count >= 0)
					separadorDecimal = ds.Tables[3].Rows[0][1].ToString();			

				//carga fecha
				if(ds.Tables[4].Rows.Count >= 0)
					formatoFecha = ds.Tables[4].Rows[0][1].ToString();			

				//carga nombre archivo
				if(ds.Tables[5].Rows.Count >= 0)
					nombreArchivo = ds.Tables[5].Rows[0][1].ToString().Replace("DD",fecha.ToString("dd")).Replace("MM",fecha.ToString("MM")).Replace("YYYY",fecha.ToString("yyyy")).Replace("HH",DateTime.Now.ToString("HH")).Replace("mm",DateTime.Now.ToString("mm")).Replace("SS",DateTime.Now.ToString("ss")).Replace("TT",turno.ToString().PadLeft(2,'0')).Replace("II",isla.ToString().PadLeft(2,'0'));			
			}
			ds = null;
			#endregion

			#endregion

			#region Directorio temporal y nombre del archivo
			//nombreArchivo = turno.ToString().PadLeft(2,'0') + nombreArchivo;
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			
			nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"*.txt");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoInventario");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
			sql.AddParameter("@Turno", SqlDbType.Int, turno);
			sql.AddParameter("@Isla", SqlDbType.Int, isla);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");
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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{
					filaTexto = "";
					filaTexto = ds.Tables[0].Rows[i]["Moneda"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Bodega"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["TipoDocumento"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Consecutivo"].ToString() + separador;					
					filaTexto += ds.Tables[0].Rows[i]["Origen"].ToString() + separador;
					//filaTexto += ds.Tables[0].Rows[i]["NumeroItems"].ToString() + separador;
					if(consecutivoAnterior != ds.Tables[0].Rows[i]["Consecutivo"].ToString())
						numeroItem = 1; 
					else
						numeroItem += 1;
					consecutivoAnterior = ds.Tables[0].Rows[i]["Consecutivo"].ToString();
					filaTexto += numeroItem.ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Modelo"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Cliente"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Articulo"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Oferta"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Periodo"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Cantidad"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Descuento"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Valor"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["PorcentajeIva"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Iva"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Impuesto"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["fecha"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["Hora"].ToString().Replace(":","") + separador;
					filaTexto += ds.Tables[0].Rows[i]["TipoVenta"].ToString();
					//cuenta el numero de item del articulo

					writer.WriteLine(UtilidadesGenerales.FormatearEstructura(filaTexto,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, true));
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de inventarios. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);
					}
					#endregion				
				}				
			}			
			writer.Close();			
			#endregion	
	
			ds.Dispose();
			return "OK," + UtilidadesGenerales.MoverArchivo(nombreArchivo,directorioExportar,false,"");
		}

		#endregion	

		#region Generar plano de Lecturas Syscon
		/// <summary>
		/// Genera el archivo plano de lecturas Syscon
		/// </summary>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		/// <param name="fecha">Fecha de turno</param>
		/// <param name="turno">Turno a consultar</param>	
		/// Referencia Documental:  Automatizacion de Islas_DT_SC_16
		/// Fecha:  08/02/2009 10:30 a.m.
		/// Autor:  Rodrigo Figueroa		
		public string PlanoLecturas(string DirectorioTemporal, DateTime fecha,int turno, string idisla) 
		{
			#region Declaraciones
			 Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
			string filaTexto;			
			_numeroRegistro=0;
			int numeroItem = 1;
			string consecutivoAnterior = "";
			DataSet ds;
			Int16 [,] estructuraPlano = new Int16[0,0];
			bool anchoFijo = false;
			string separador = "©"; //interno
			string separadorConfigurado = ""; //configurado
			string separadorDecimal = "";
			string formatoFecha = "DD/MM/YYYY";
			string nombreArchivo = "YYMMDDHHmmss.txt";
			string directorioExportar;			
			#endregion

			#region Directorio de exportacion configurado
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
			}
			objDat_Gene = objDatos_Gene[0];
			directorioExportar = objDat_Gene.DirPlanoLecturas;
			if(directorioExportar == "")
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
			#endregion
 
			#region Recuperar la estructura flexible del plano			
			#region cargar columnas
			ds = UtilidadesGenerales.RecuperarEstructuraPlano(0,"","Columna","Lecturas");
			if(ds.Tables[0].Rows.Count >= 0)
			{
				estructuraPlano = new Int16 [ds.Tables[0].Rows.Count,6]; //codigocolumna(8), orden(2), tamaño(5), Mascara(9), Acii(10), Direccion(11)
				for(int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					estructuraPlano[i,0] = (Int16)(ds.Tables[0].Rows[i][8]); //codigocolumna
					estructuraPlano[i,1] = (Int16)(ds.Tables[0].Rows[i][2]); //orden
					estructuraPlano[i,2] = (Int16)(ds.Tables[0].Rows[i][5]); //tamaño
					estructuraPlano[i,3] = (Int16)(ds.Tables[0].Rows[i][9]); //mascara
					estructuraPlano[i,4] = (Int16)(ds.Tables[0].Rows[i][10]); //Ascii del relleno
					estructuraPlano[i,5] = (Int16)(ds.Tables[0].Rows[i][11]); //Direccion del relleno 1:Izquierdo 2:Derecho
				}
			}
			#endregion

			#region carga el resto de configuraciones
			if(ds.Tables.Count > 5)
			{
				//carga ancho			
				if(ds.Tables[1].Rows.Count >= 0)				
					anchoFijo = ds.Tables[1].Rows[0][1].ToString().Trim()=="Si"?true:false;			
			
				//carga separador			
				if(ds.Tables[2].Rows.Count >= 0)				
					separadorConfigurado = ds.Tables[2].Rows[0][1].ToString();			
			
				//carga separador decimales
				if(ds.Tables[3].Rows.Count >= 0)
					separadorDecimal = ds.Tables[3].Rows[0][1].ToString();			

				//carga fecha
				if(ds.Tables[4].Rows.Count >= 0)
					formatoFecha = ds.Tables[4].Rows[0][1].ToString();			

				//carga nombre archivo
				if(ds.Tables[5].Rows.Count >= 0)	
				{
					nombreArchivo = ds.Tables[5].Rows[0][1].ToString().Replace("DD",fecha.ToString("dd")).Replace("MM",fecha.ToString("MM")).Replace("YYYY",fecha.ToString("yyyy")).Replace("HH",DateTime.Now.ToString("HH")).Replace("mm",DateTime.Now.ToString("mm")).Replace("ss",DateTime.Now.ToString("ss"));			
					nombreArchivo = nombreArchivo.Substring(2);
				}
				
				

			}
			ds = null;
			#endregion



			#endregion

			#region Directorio temporal y nombre del archivo			
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			
			nombreArchivo = DirectorioTemporal + "\\" +idisla + nombreArchivo;			
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"*.txt");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoLecturas");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
			if(turno != 0)
				sql.AddParameter("@Turno", SqlDbType.Int, turno);
			#endregion

			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");
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

			#region Generar plano con los registros

			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream);
			if(ds == null || ds.Tables[0].Rows.Count == 0)
				return("No se encontraron registros en la busqueda!");
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{
					filaTexto = "";
					filaTexto = ds.Tables[0].Rows[i]["CodigoSurtidor"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["CodigoCara"].ToString() + separador;
					filaTexto += ds.Tables[0].Rows[i]["CodigoManguera"].ToString() + separador;					
					filaTexto += ds.Tables[0].Rows[i]["LecturaPesos"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["LecturaGalones"].ToString() + separador;
                    // Linea Agregada 27/01/2010
                    filaTexto += ds.Tables[0].Rows[i]["LecturaFinal"].ToString(); 
					
					//cuenta el numero de item del articulo

					writer.WriteLine(UtilidadesGenerales.FormatearEstructura(filaTexto,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, true));
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de inventarios. ");
					}
					catch(Exception)
					{
						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);
					}
					#endregion				
				}				
			}			
			writer.Close();			
			#endregion	
	
			ds.Dispose();
			return "OK," + UtilidadesGenerales.MoverArchivo(nombreArchivo,directorioExportar,false,"");
		}

		#endregion	

		#region Generar plano de Ventas Syscon
		/// <summary>
		/// Genera el archivo plano de Ventas Syscon
		/// </summary>
		/// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
		/// <param name="fecha">Fecha de turno</param>
		/// <param name="turno">Turno a consultar</param>	
		/// Referencia Documental:  Automatizacion de Islas_DT_SC_16
		/// Fecha:  08/02/2009 10:30 a.m.
		/// Autor:  Rodrigo Figueroa		
		public string PlanoVentas(string DirectorioTemporal, DateTime fecha,int turno,string sistemaContable,string isla ) 
		{

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Entro al Metodo Plano Ventas en la Libreria de Yuly:", HardLog.TypeLog.LogApp);

            //#endregion

			#region Declaraciones
			Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
			Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
			string filaTexto;			
			_numeroRegistro=0;			
			DataSet ds;
			Int16 [,] estructuraPlano = new Int16[0,0];
			bool anchoFijo = false;
			string separador = "©"; //interno
			string separadorConfigurado = ""; //configurado
			string separadorDecimal = "";
			string formatoFecha = "DD/MM/YYYY";
			string nombreArchivo = "YYMMDDHHmmss.txt";
			string directorioExportar;			
			#endregion

			#region Directorio de exportacion configurado
			objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Recupera Informacion de la Tabla DATGENE Filas encontradas:" + objDatos_Gene.Count, HardLog.TypeLog.LogApp);

            //#endregion

			if(objDatos_Gene.Count == 0) 
			{
				EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");


                /////
                /////TODO: JCMM:
                ///// Añado comentario para depurar el proceso de generacion planos Syscom
                /////
                //#region Proceso depuracion planos Syscom

                //HardLog.Write("Depurando Plano Ventas JCMM:Sale a Return por que dat gene es igual a:" + objDatos_Gene.Count.ToString(), HardLog.TypeLog.LogApp);

                //#endregion
				return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";


			}
			objDat_Gene = objDatos_Gene[0];
			directorioExportar = objDat_Gene.DirPlanoVentas;

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Directorio a Exportar: (" + directorioExportar+")", HardLog.TypeLog.LogApp);

            //#endregion
			if(directorioExportar == "")
			{
				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 2, 0,
						" No se a configurado la ruta predeterminada para la exportar archivos " + " !ERROR APP! ", " Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias. ");
				}
				catch(Exception exx)
				{
					//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					//this.SetError(lblError.Text);
                    /////
                    /////TODO: JCMM:
                    ///// Añado comentario para depurar el proceso de generacion planos Syscom
                    /////
                    //#region Proceso depuracion planos Syscom

                    //HardLog.Write("Depurando Plano Ventas JCMM:Catch sin controlar el error se presento en exx: " + exx.Message, HardLog.TypeLog.LogApp);

                    //#endregion
				}
				#endregion
                /////
                /////TODO: JCMM:
                ///// Añado comentario para depurar el proceso de generacion planos Syscom
                /////
                //#region Proceso depuracion planos Syscom

                //HardLog.Write("Depurando Plano Ventas JCMM:No esta configurada la ruta *O*", HardLog.TypeLog.LogApp);

                //#endregion
				return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
			}
			#endregion
 
			#region Recuperar la estructura flexible del plano			
			#region cargar columnas

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:La Variable sistema contable tiene: " + sistemaContable, HardLog.TypeLog.LogApp);

            //#endregion
            if (sistemaContable == "Syscom")
                ds = UtilidadesGenerales.RecuperarEstructuraPlano(0, "", "Columna", "SyscomVentas");
            else if (sistemaContable == "AS400")
                ds = UtilidadesGenerales.RecuperarEstructuraPlano(0, "", "Columna", "AS400Ventas");
            else
                ds = UtilidadesGenerales.RecuperarEstructuraPlano(0, "", "Columna", "Ventas");
			if(ds.Tables[0].Rows.Count >= 0)
			{
				estructuraPlano = new Int16 [ds.Tables[0].Rows.Count,6]; //codigocolumna(8), orden(2), tamaño(5), Mascara(9), Acii(10), Direccion(11)
				for(int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					estructuraPlano[i,0] = (Int16)(ds.Tables[0].Rows[i][8]); //codigocolumna
					estructuraPlano[i,1] = (Int16)(ds.Tables[0].Rows[i][2]); //orden
					estructuraPlano[i,2] = (Int16)(ds.Tables[0].Rows[i][5]); //tamaño
					estructuraPlano[i,3] = (Int16)(ds.Tables[0].Rows[i][9]); //mascara
					estructuraPlano[i,4] = (Int16)(ds.Tables[0].Rows[i][10]); //Ascii del relleno
					estructuraPlano[i,5] = (Int16)(ds.Tables[0].Rows[i][11]); //Direccion del relleno 1:Izquierdo 2:Derecho
				}
			}
			#endregion

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Carga Estructura Plano: " + estructuraPlano.Length.ToString(), HardLog.TypeLog.LogApp);

            //#endregion

			#region carga el resto de configuraciones
			if(ds.Tables.Count > 5)
			{
				//carga ancho			
				if(ds.Tables[1].Rows.Count >= 0)				
					anchoFijo = ds.Tables[1].Rows[0][1].ToString().Trim()=="Si"?true:false;			
			
				//carga separador			
				if(ds.Tables[2].Rows.Count >= 0)				
					separadorConfigurado = ds.Tables[2].Rows[0][1].ToString();			
			
				//carga separador decimales
				if(ds.Tables[3].Rows.Count >= 0)
					separadorDecimal = ds.Tables[3].Rows[0][1].ToString();			

				//carga fecha
				if(ds.Tables[4].Rows.Count >= 0)
					formatoFecha = ds.Tables[4].Rows[0][1].ToString();			

				//carga nombre archivo
				if(ds.Tables[5].Rows.Count >= 0)	
				{
					nombreArchivo = ds.Tables[5].Rows[0][1].ToString().Replace("DD",fecha.ToString("dd")).Replace("MM",fecha.ToString("MM")).Replace("YYYY",fecha.ToString("yyyy")).Replace("HH",DateTime.Now.ToString("HH")).Replace("mm",DateTime.Now.ToString("mm")).Replace("ss",DateTime.Now.ToString("ss"));			
					nombreArchivo = nombreArchivo.Substring(2);
				}
				
				

			}
			ds = null;

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Carga El Resto de la Configuracion: ", HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM: Nombre de Archivo: " + nombreArchivo, HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM: Formato de Fecha: " + formatoFecha, HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM: Separador Decimal: " + separadorDecimal, HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM: Separador Configurado: " + separadorConfigurado, HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM: Ancho Fijo: " + anchoFijo, HardLog.TypeLog.LogApp);

            //#endregion
			#endregion



			#endregion

			#region Directorio temporal y nombre del archivo			
			System.IO.Directory.CreateDirectory(DirectorioTemporal);
			
			nombreArchivo = DirectorioTemporal + "\\" +isla+nombreArchivo;			
			UtilidadesGenerales.LimpiarDirectorio(nombreArchivo,3,"*.txt");
			#endregion

			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("PlanoVentas");
			sql.ParametersNumber = 3;
			sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
			if(turno != 0)
				sql.AddParameter("@Turno", SqlDbType.Int, turno);
            sql.AddParameter("@Sist_Contable", SqlDbType.VarChar, sistemaContable);
			#endregion
            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Carga objeto sql:", HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM:Parametro @Fecha:" + fecha.ToString(), HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM:Parametro @Turno:" + turno.ToString(), HardLog.TypeLog.LogApp);
            //HardLog.Write("Depurando Plano Ventas JCMM:Parametro @Sist_Contable:" + sistemaContable, HardLog.TypeLog.LogApp);

            //#endregion
			#region Execute Sql
			try
			{
				ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                /////
                /////TODO: JCMM:
                ///// Añado comentario para depurar el proceso de generacion planos Syscom
                /////
                //#region Proceso depuracion planos Syscom

                //HardLog.Write("Depurando Plano Ventas JCMM:Ejecuto el Procedimiento Almacenado y retorno " + ds.Tables[0].Rows.Count +" Filas", HardLog.TypeLog.LogApp);

                //#endregion
				if(ds.Tables[0].Rows.Count == 0)
					throw new Exception("No se encontraron coincidencias en la busqueda!");
			}
			catch (SqlException e)
			{
                /////
                /////TODO: JCMM:
                ///// Añado comentario para depurar el proceso de generacion planos Syscom
                /////
                //#region Proceso depuracion planos Syscom

                //HardLog.Write("Depurando Plano Ventas JCMM:Entro al Metodo Plano Ventas en la Libreria de Yuly(Excepcion"+e.Message+"):", HardLog.TypeLog.LogApp);

                //#endregion
				throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion

			#region Generar plano con los registros
            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Prepara el objeto File Stream para generar el plano en el disco.", HardLog.TypeLog.LogApp);

            //#endregion
			FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);


            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Nombre de Archivo:" + nombreArchivo, HardLog.TypeLog.LogApp);

            //#endregion


			StreamWriter writer = new StreamWriter(stream);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                /////
                /////TODO: JCMM:
                ///// Añado comentario para depurar el proceso de generacion planos Syscom
                /////
                //#region Proceso depuracion planos Syscom

                //HardLog.Write("Depurando Plano Ventas JCMM:No hay Filas en ds(dataset)", HardLog.TypeLog.LogApp);

                //#endregion
                return ("No se encontraron registros en la busqueda!");
            }
			for(int i=0; i< ds.Tables[0].Rows.Count; i++)
			{
				try
				{
                    filaTexto = "";
                    if (sistemaContable != "AS400")
                    {
                        filaTexto = ds.Tables[0].Rows[i]["Referencia"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Fecha"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Consecutivo"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Manguera"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["FormaPago"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Cantidad"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Total"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Precio"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Cedula"].ToString() + separador;
                        filaTexto += ds.Tables[0].Rows[i]["Placa"].ToString() + separador;
                        //filaTexto += ds.Tables[0].Rows[i]["Ruta"].ToString();
                        filaTexto += ds.Tables[0].Rows[i]["Cod_Int_Vehiculo"].ToString();
                    }
                    else
                    {
                        if (i == 0)
                            writer.WriteLine("0;" + fecha.ToShortDateString());
                            filaTexto = ds.Tables[0].Rows[i]["Detalle"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Placa"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["TipoCombustible"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Fecha"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Hora"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Cantidad"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Total"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Consecutivo"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Manguera"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Precio"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Cliente"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["IDRom"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["FormaPago"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Identificado"].ToString() + separador;
                            filaTexto += ds.Tables[0].Rows[i]["Cod_Int_Vehiculo"].ToString();
                    }


                    /////
                    /////TODO: JCMM:
                    ///// Añado comentario para depurar el proceso de generacion planos Syscom
                    /////
                    //#region Proceso depuracion planos Syscom

                    //HardLog.Write("Depurando Plano Ventas JCMM:Entro al for que controla el formato del archivo en la fila " + i, HardLog.TypeLog.LogApp);

                    //#endregion


					//cuenta el numero de item del articulo

					writer.WriteLine(UtilidadesGenerales.FormatearEstructura(filaTexto,separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, true));
                    
				}
				catch(Exception ex)				
				{
						
					writer.WriteLine("Error " + ex.Message.ToString());	
					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, 0,   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de inventarios. ");
					}
					catch(Exception exxx)
					{
                        /////
                        /////TODO: JCMM:
                        ///// Añado comentario para depurar el proceso de generacion planos Syscom
                        /////
                        //#region Proceso depuracion planos Syscom

                        //HardLog.Write("Depurando Plano Ventas JCMM:Excepcion sin controlar exxx:" + exxx.ToString(), HardLog.TypeLog.LogApp);

                        //#endregion

						//lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						//this.SetError(lblError.Text);
					}
					#endregion				
				}				
			}			
			writer.Close();			
			#endregion	

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Genero Archivo en: "+directorioExportar+" Con Nombre: " + nombreArchivo, HardLog.TypeLog.LogApp);

            //#endregion

            /////
            /////TODO: JCMM:
            ///// Añado comentario para depurar el proceso de generacion planos Syscom
            /////
            //#region Proceso depuracion planos Syscom

            //HardLog.Write("Depurando Plano Ventas JCMM:Generò plano! :D ", HardLog.TypeLog.LogApp);

            //#endregion
			ds.Dispose();
			return "OK," + UtilidadesGenerales.MoverArchivo(nombreArchivo,directorioExportar,false,"");
		}

		#endregion	

        #region Generar plano de Ventas Syscon
        /// <summary>
        /// Genera el archivo plano de Ventas Syscon
        /// </summary>
        /// <param name="DirectorioTemporal">Directorio temporal del servidor donde se creará el archivo</param>
        /// <param name="fecha">Fecha de turno</param>
        /// <param name="turno">Turno a consultar</param>	
        /// <param name="opcion">opcion (0)Agrupado, (1)detallado </param>	
        /// Referencia Documental:  !falta!
        /// Fecha:  12/12/2009 10:30 a.m.
        /// Autor:  Rodrigo Figueroa
        /// Fecha Modificacion: 02/11/2010
        /// Rodrigo Cerquera
        /// Descripcion: Se modifica el metodo de persistencia a la DB para solo traer las ventas vale credito
        public string PlanoVentasInsepec(string DirectorioTemporal, DateTime fecha, int turno, int opcion)
        {
            #region Declaraciones
            Servipunto.Estacion.Libreria.Configuracion.Datos_Gene objDatos_Gene;
            Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene;
            string filaTexto;
            _numeroRegistro = 0;
            DataSet ds;
            Int16[,] estructuraPlano = new Int16[0, 0];
            bool anchoFijo = false;
            string separador = "©"; //interno
            string separadorConfigurado = ""; //configurado
            string separadorDecimal = "";
            string formatoFecha = "YYYYMMDD";
            string nombreArchivo = "YYMMDDHHmmss.txt";
            string directorioExportar;
            #endregion

            #region Directorio de exportacion configurado
            objDatos_Gene = new Servipunto.Estacion.Libreria.Configuracion.Datos_Gene();
            if (objDatos_Gene.Count == 0)
            {
                EscribirLog("Error! Por favor Configure los Datos Generales de la Estación, gracias.");
                return "Error! Por favor Configure los Datos Generales de la Estación, gracias.";
            }
            objDat_Gene = objDatos_Gene[0];
            directorioExportar = objDat_Gene.DirPlanoVentas;
            if (directorioExportar == "")
            {
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 2, 0,
                        " No se a configurado la ruta predeterminada para la exportar archivos " + " !ERROR APP! ", " Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias. ");
                }
                catch (Exception)
                {
                    //lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    //this.SetError(lblError.Text);
                }
                #endregion
                return "Error! Por favor Configure la ruta predeterminda de exportación en Administrativo > Panel de control > Datos generales > Generar, gracias.";
            }
            #endregion

            #region Recuperar la estructura flexible del plano
            #region cargar columnas
            ds = UtilidadesGenerales.RecuperarEstructuraPlano(0, "", "Columna", "Insepec");
            if (ds.Tables[0].Rows.Count >= 0)
            {
                estructuraPlano = new Int16[ds.Tables[0].Rows.Count, 6]; //codigocolumna(8), orden(2), tamaño(5), Mascara(9), Acii(10), Direccion(11)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    estructuraPlano[i, 0] = (Int16)(ds.Tables[0].Rows[i][8]); //codigocolumna
                    estructuraPlano[i, 1] = (Int16)(ds.Tables[0].Rows[i][2]); //orden
                    estructuraPlano[i, 2] = (Int16)(ds.Tables[0].Rows[i][5]); //tamaño
                    estructuraPlano[i, 3] = (Int16)(ds.Tables[0].Rows[i][9]); //mascara
                    estructuraPlano[i, 4] = (Int16)(ds.Tables[0].Rows[i][10]); //Ascii del relleno
                    estructuraPlano[i, 5] = (Int16)(ds.Tables[0].Rows[i][11]); //Direccion del relleno 1:Izquierdo 2:Derecho
                }
            }
            #endregion

            #region carga el resto de configuraciones
            if (ds.Tables.Count > 5)
            {
                //carga ancho			
                if (ds.Tables[1].Rows.Count > 0)
                    anchoFijo = ds.Tables[1].Rows[0][1].ToString().Trim() == "Si" ? true : false;

                //carga separador			
                if (ds.Tables[2].Rows.Count > 0)
                    separadorConfigurado = ds.Tables[2].Rows[0][1].ToString();

                //carga separador decimales
                if (ds.Tables[3].Rows.Count > 0)
                    separadorDecimal = ds.Tables[3].Rows[0][1].ToString();

                //carga fecha
                if (ds.Tables[4].Rows.Count > 0)
                    formatoFecha = ds.Tables[4].Rows[0][1].ToString();

                //carga nombre archivo
                if (ds.Tables[5].Rows.Count > 0)
                {
                    nombreArchivo = ds.Tables[5].Rows[0][1].ToString().Replace("DD", fecha.ToString("dd")).Replace("MM", fecha.ToString("MM")).Replace("YYYY", fecha.ToString("yyyy")).Replace("HH", DateTime.Now.ToString("HH")).Replace("mm", DateTime.Now.ToString("mm")).Replace("SS", DateTime.Now.ToString("ss"));
                    nombreArchivo = nombreArchivo.Substring(2);
                }
                #region  pone nombre al archivo de vales credito Diego
                if (opcion == 2)
                {
                    nombreArchivo = nombreArchivo + " ValesCredito";
                }
                #endregion

            }
            ds = null;
            #endregion



            #endregion

            #region Directorio temporal y nombre del archivo
            System.IO.Directory.CreateDirectory(DirectorioTemporal);

            nombreArchivo = DirectorioTemporal + "\\" + nombreArchivo;
            UtilidadesGenerales.LimpiarDirectorio(nombreArchivo, 3, "*.txt");
            #endregion

            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            if (opcion == 0)
            {
                sql.Append("PlanoVentasInsepec");
                sql.ParametersNumber = 3;
                sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
                if (turno != 0)
                    sql.AddParameter("@Turno", SqlDbType.Int, turno);
            }
            else if (opcion == 1)
            {
                sql.Append("PlanoVentasInsepecDetallado");
                sql.ParametersNumber = 3;
                sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);
                if (turno != 0)
                    sql.AddParameter("@Turno", SqlDbType.Int, turno);

            }
            #region Retorna Vales Credito diego
            else
            {
                //Este procedimiento se creo
                sql.Append("PlanoVentasInsepecValesCredito");
                sql.ParametersNumber = 1;
                sql.AddParameter("@Fecha", SqlDbType.DateTime, fecha);

            }
            #endregion

            #endregion

            #region Execute Sql
            try
            {
                ds = SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
                if (ds.Tables[0].Rows.Count == 0)
                    throw new Exception("No se encontraron coincidencias en la busqueda!");
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

            #region Generar plano con los registros

            FileStream stream = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return ("No se encontraron registros en la busqueda!");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {
                    filaTexto = "";
                    filaTexto = ds.Tables[0].Rows[i]["TipoCombustible"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Fecha"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Consecutivo"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Pos"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["CreditoContado"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Cantidad"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Total"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Precio"].ToString() + separador;
                    filaTexto += ds.Tables[0].Rows[i]["Cliente"].ToString() + separador;                   
                    if (ds.Tables[0].Rows[i]["Placa"].ToString() != "")
                        filaTexto += ds.Tables[0].Rows[i]["Placa"].ToString() + separador;                    
                    filaTexto += ds.Tables[0].Rows[i]["CodigoSucursal"].ToString().PadLeft(4,'0') + separador;

                    //cuenta el numero de item del articulo

                    writer.WriteLine(UtilidadesGenerales.FormatearEstructura(filaTexto, separador, estructuraPlano, anchoFijo, separadorDecimal, formatoFecha, separadorConfigurado, true));
                }
                catch (Exception ex)
                {

                    writer.WriteLine("Error " + ex.Message.ToString());
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, 0,
                            ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el archivo plano de inventarios. ");
                    }
                    catch (Exception)
                    {
                        //lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                        //this.SetError(lblError.Text);
                    }
                    #endregion
                }
            }
            writer.Close();
            #endregion

            ds.Dispose();
            return "OK," + UtilidadesGenerales.MoverArchivo(nombreArchivo, directorioExportar, false, "");
        }

        #endregion	
	}
}



