using System;
using System.Data.SqlClient;
using System.Data; 
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
	/// <summary>
	/// Administración de Usuarios del Sistema
	/// </summary>
	public class Usuarios : Servipunto.Libreria.Collection
	{
		#region Sección de Declaraciones
		private object _idUsuario;
		#endregion

		#region Propiedades Públicas
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta de Todos los Usuarios
		/// </summary>
		public Usuarios()
		{
		}

		/// <summary>
		/// Consulta de un Usuario en Particular
		/// </summary>
		/// <param name="idUsuario">Código del Usuario</param>
		internal Usuarios(string idUsuario)
		{
			this._idUsuario = idUsuario;
		}
		#endregion

		#region Indexer
		/// <summary>
		/// Indexador por Llave
		/// </summary>
		new public Usuario this[string key]
		{
			get { return (Usuario)base[key]; }
		}

		/// <summary>
		/// Indexador por Indice
		/// </summary>
		new public Usuario this[int index]
		{
			get { return (Usuario)base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección
		/// </summary>		
		protected override void Load(object sender, EventArgs e)
		{		
			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarUsuario");
			if (this._idUsuario != null)
			{
				sql.ParametersNumber = 1;
				sql.AddParameter("@IdUsuario", SqlDbType.VarChar, this._idUsuario);
			}
			#endregion

			#region Execute Sql
			dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			while (dr.Read())
			{
				Usuario objUsuario = new Usuario();
				objUsuario.IdUsuario = dr.GetString(0);
				objUsuario.IdRol = (dr.IsDBNull(1)?(byte)0:dr.GetByte(1));
				objUsuario.Nombre = dr.GetString(2);
				objUsuario.Estado = (dr.GetBoolean(3)?EstadoUsuario.Activo:EstadoUsuario.Inactivo);
				objUsuario.Contrasena = dr.GetString(4);
				objUsuario.Rol = dr.IsDBNull(5)?"Administrator ServiPunto":dr.GetString(5);
				objUsuario.CodigoEmpleado = dr.IsDBNull(6)?"":dr.GetString(6);

				base.AddItem(objUsuario.IdUsuario, objUsuario);
			}
			dr.Close();
			dr = null;
			sql = null;
			#endregion
		}
		#endregion

		#region Método Adicionar
		/// <summary>
		/// Inserción de un registro en la base de datos
		/// </summary>
		/// <param name="objUsuario">Instancia del objeto que contiene la información</param>
		public static void Adicionar(Usuario objUsuario)
		{
			if (!Aplicacion.IsNumeric(objUsuario.IdUsuario))
				throw new Exception("La identificación del usuario debe contener solo números.");

			if (objUsuario.IdUsuario.Length < 4)
				throw new Exception("La identificación del usuario debe contener como mínimo 4 dígitos.");

			objUsuario.Contrasena = Servipunto.Libreria.Cryptography.Encrypt(objUsuario.IdUsuario.Substring(objUsuario.IdUsuario.Length - 4,  4));
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("InsertarUsuario");
			sql.ParametersNumber = 6;
			sql.AddParameter("@IdUsuario", SqlDbType.VarChar, objUsuario.IdUsuario);
			if (objUsuario.IdRol == 0)
				sql.AddParameter("@IdRol", SqlDbType.TinyInt, null);
			else
				sql.AddParameter("@IdRol", SqlDbType.TinyInt, objUsuario.IdRol);

			sql.AddParameter("@Usuario", SqlDbType.VarChar, objUsuario.Nombre);
			sql.AddParameter("@Estado", SqlDbType.Bit, objUsuario.Estado == EstadoUsuario.Activo?1:0);
			sql.AddParameter("@Contrasena", SqlDbType.VarChar, objUsuario.Contrasena);
			sql.AddParameter("@Cod_Emp", SqlDbType.VarChar, objUsuario.CodigoEmpleado);
			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("VIOLATION OF PRIMARY KEY") != -1)
					throw new Exception("Ya existe una Cuenta de Usuario asociada al número de identificación " + objUsuario.IdUsuario + ", verifique e intente nuevamente!" + " !ERROR BD! ");
				else
					throw new Exception(e.Message + " !ERROR BD! ");
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Método Remover
		/// <summary>
		/// Eliminación de un registro en la base de datos
		/// </summary>
		/// <param name="idUsuario">Código del Usuario</param>
		public static void Remover(string idUsuario)
		{				
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("EliminarUsuario");
			sql.ParametersNumber = 1;
			sql.AddParameter("@IdUsuario", SqlDbType.VarChar, idUsuario);
			#endregion
			
			#region Execute Sql
			try
			{
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e)
			{
				if (e.Message.ToUpper().IndexOf("Orders") != -1)
					throw new Exception("Existe facturación asociada al usuario que desea eliminar.");
				else
					throw new Exception(e.Message);
			}
			finally 
			{
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Método Obtener
		/// <summary>
		/// Método para obtener de manera directa un elemento en particular
		/// </summary>
		/// <param name="idUsuario">Código del Usuario</param>
		/// <returns>Si existe retorna la referencia al objeto, sino retorna null</returns>
		public static Usuario Obtener(string idUsuario)
		{
			Usuarios objElementos = new Usuarios(idUsuario);
			if (objElementos.Count == 1)
				return objElementos[0];
			else
				return null;
		}
		#endregion

		#region Método ObtenerRegistros
		/// <summary>
		/// Método para obtener de manera directa uno o varios elementos en particular
		/// </summary>
		/// <param name="objUsuario">Objeto con la informacion a filtrar</param>
		/// <returns>Retorna un dataset con los registros encontrados</returns>
		public static DataSet ObtenerRegistros(Usuario objUsuario)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarUsuarioDinamico");

			if(objUsuario != null)
			{
				sql.ParametersNumber = 6;
			
				if(objUsuario.IdUsuario != null)
					if(objUsuario.IdUsuario.Trim().Length > 0)
						sql.AddParameter("@IdUsuario", SqlDbType.VarChar, objUsuario.IdUsuario.Trim());

				if(objUsuario.IdRol > 0)
					sql.AddParameter("@IdRol", SqlDbType.TinyInt, objUsuario.IdRol);

				if(objUsuario.Nombre != null)
					if(objUsuario.Nombre.Trim().Length > 0)
						sql.AddParameter("@Usuario", SqlDbType.VarChar, objUsuario.Nombre.Trim());

				/*if(objUsuario.Estado > 0)
					sql.AddParameter("@Estado", SqlDbType.Bit, objUsuario.Estado);
				*/ 
				if(objUsuario.Rol != null)
					if(objUsuario.Rol.Trim().Length > 0)
						sql.AddParameter("@Rol", SqlDbType.VarChar, objUsuario.Rol.Trim());

				if(objUsuario.CodigoEmpleado != null)
					if(objUsuario.CodigoEmpleado.Trim().Length > 0)
						sql.AddParameter("@CodigoEmpleado", SqlDbType.VarChar, objUsuario.CodigoEmpleado.Trim());


			}
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

		#region Reporte de auditoria de usuarios
		/// <summary>
		/// Genera un reporte de auditoria de usuarios
		/// <param name="fechaInicial">Fecha inicial desde donde se buscara</param>
		/// <param name="fechaFinal">Fecha final hasta donde se buscara</param>
		/// <param name="idAplicativo">Identificador de la aplicacion</param>
		/// <param name="idResponsable">Identificador del usuario o responsable</param>
		/// <param name="tipoResponsable">Tipo de responsable: U=usuario E=Empleado S=Servipunto</param>
		/// <param name="modulo">Modulo de la aplicacion</param>
		/// <param name="accion">Accion que se ejecuto</param>
		/// <param name="opcion">Opcion que selecciono</param>
		/// <param name="tabla">Tabla con que interactuo</param>
		/// <param name="evento">Evento que realizo sobre la tabla</param>
		/// <param name="campoOrdenar">Criterio por el cual se ordenara</param>
		/// <param name="caso">1: aplicativo 2: aplicativo con tablas</param>
		/// </summary>
		public static DataSet RptAuditoriaUsuario(DateTime fechaInicial, 
													DateTime fechaFinal, 
													int idAplicativo,
													string idResponsable,
													string tipoResponsable,
													string modulo,
													string accion,
													string opcion,
													string tabla,
													string evento,
													string campoOrdenar,
													int caso
													)
		{


			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ReporteAuditoriaUsuario");
			sql.ParametersNumber = 12;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);

			if(idAplicativo!=0)
				sql.AddParameter("@idAplicativo", SqlDbType.Int, idAplicativo);

			if(idResponsable.Trim().Length > 0)
				sql.AddParameter("@idResponsable", SqlDbType.VarChar, idResponsable);

			if(tipoResponsable.Trim().Length > 0)
				sql.AddParameter("@tipoResponsable", SqlDbType.VarChar, tipoResponsable);

			if(modulo.Trim().Length > 0)
				sql.AddParameter("@modulo", SqlDbType.VarChar, modulo);

			if(accion.Trim().Length > 0)
				sql.AddParameter("@accion", SqlDbType.VarChar, accion);

			if(opcion.Trim().Length > 0)
				sql.AddParameter("@opcion", SqlDbType.VarChar, opcion);

			if(tabla.Trim().Length > 0)
				sql.AddParameter("@tabla", SqlDbType.VarChar, tabla);

			if(evento.Trim().Length > 0)
				sql.AddParameter("@evento", SqlDbType.VarChar, evento);

			if(campoOrdenar.Trim().Length > 0)
				sql.AddParameter("@campoOrdenar", SqlDbType.VarChar, campoOrdenar);

			if(caso != 0)
				sql.AddParameter("@caso", SqlDbType.Int, caso);


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

		#region Reporte de auditoria de errores
		/// <summary>
		/// Genera un reporte de auditoria de errores
		/// </summary>
		/// <param name="fechaInicial">Fecha inicial desde donde se buscara</param>
		/// <param name="fechaFinal">Fecha final hasta donde se buscara</param>
		/// <param name="idAplicativo">Identificador de la aplicacion</param>
		/// <param name="idTipoError">Tipo de error a buscar</param>
		/// <param name="campoOrdenar">Campo por el cual se ordenará</param>
		/// <param name="detalledebug">Detalle del debug a buscar</param>
		/// <param name="detallepersonal">Detalle personal a buscar</param>
		/// <param name="posibleSuceso">Posible suceso que genero el error</param>
		public static DataSet RptAuditoriaError(DateTime fechaInicial, 
												DateTime fechaFinal, 
												int idAplicativo, 
												int idTipoError,
												string campoOrdenar,
												string detalledebug,
												string detallepersonal,
												string posibleSuceso
												)
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ReporteAuditoriaError");
			sql.ParametersNumber = 7;
			sql.AddParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial);
			sql.AddParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal);
			if(idAplicativo != 0)
				sql.AddParameter("@idAplicativo", SqlDbType.Int, idAplicativo);
			if(idTipoError != 0)
				sql.AddParameter("@idTipoError", SqlDbType.Int, idTipoError);
			if(campoOrdenar.Trim().Length > 0)
				sql.AddParameter("@campoOrdenar", SqlDbType.VarChar, campoOrdenar);
			if(detalledebug.Trim().Length > 0)
				sql.AddParameter("@detalledebug", SqlDbType.VarChar, detalledebug);
			if(detallepersonal.Trim().Length > 0)
				sql.AddParameter("@detallepersonal", SqlDbType.VarChar, detallepersonal);
			if(posibleSuceso.Trim().Length > 0)
				sql.AddParameter("@posibleSuceso", SqlDbType.VarChar, posibleSuceso);

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

		/// <summary>
		/// Obtiene los filtros para el reporte de auditoria
		/// </summary>
		public static DataSet RecuperarFiltrosReporteAuditoria()
		{
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("RecuperarFiltrosReporteAuditoria");
			#endregion

			#region Execute Sql			
			try
			{
				return(SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text));
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
	}
}