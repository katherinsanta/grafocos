
using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data; 
using System.Reflection;

namespace Servipunto.Estacion.Libreria.Comercial
{
	/// <summary>
	/// Descripción breve de Clientes.
	/// </summary>
	public class Clientes : Servipunto.Libreria.Collection
	{
		#region Declarations
		private object _cod_Cli = null, _nit = null, _sorted = null;
		#endregion

		#region Constructor
		/// <summary>
		/// Consulta todos clientes
		/// </summary>
		public Clientes() {	}

		/// <summary>
		/// Consulta por codigo de cliente
		/// </summary>
		/// <param name="CodigoCliente">Codigo a consultar</param>
		/// <param name="caso">caso 1. buscar por codigo, 2 buscar por nit</param>
		public Clientes(string CodigoCliente, int caso)
		{
			if(caso == 1)
				this._cod_Cli = CodigoCliente;			
			else
				this._nit = CodigoCliente;
		}
/*
		/// <summary>
		/// Consulta por Nit/cedula
		/// </summary>
		/// <param name="NitCedulaCliente">Numero de idientificacion a consultar</param>
		public Clientes(string NitCedulaCliente){
			this._nit = NitCedulaCliente;
		}
*/
		/// <summary>
		/// Ordenar por Nombre del cliente o por nit
		/// </summary>
		/// <param name="Sorted">Numero para ordenar</param>
		public Clientes(byte Sorted)
		{
			this._sorted = Sorted;
		}

		#endregion

		#region Indexer
		/// <summary>
		/// Indexes by pk
		/// </summary>
		new public Cliente this[string key]{
			get{ return (Cliente) base[key]; }
		}
		/// <summary>
		/// Indexes by cllection index
		/// </summary>
		new public Cliente this[int index]{
			get{ return (Cliente) base[index]; }
		}
		#endregion

		#region Load Event
		/// <summary>
		/// Recuperación de información contenida en la base de datos para poblar la colección.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void Load(object sender, EventArgs e) {

			#region Prepare Sql Command
			SqlDataReader dr = null;
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ClientesQuery");
			sql.ParametersNumber = 4;
			sql.AddParameter("@Sorted", SqlDbType.Int, this._sorted);
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, this._cod_Cli);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, null);
			sql.AddParameter("@Nit", SqlDbType.VarChar, this._nit);
			#endregion
		
			#region Execute sql Command
			try
			{
				dr = SqlHelper.ExecuteReader(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
				while (dr.Read())
				{
					Cliente objCliente = new Cliente();
				
					objCliente.CodigoCliente = dr.IsDBNull(0)?"(Sin Definir)":dr.GetString(0).Trim();
					objCliente.NombreCliente = dr.IsDBNull(1)?"(Sin Definir)":dr.GetString(1).Trim();
					objCliente.TipoNit = (dr.IsDBNull(2)||dr[2].ToString().Trim() == "")?"(Sin Definir)":dr.GetString(2).Trim();
					objCliente.NitCedulaCliente = dr.IsDBNull(3)?"0":dr.GetString(3);
					objCliente.FormaDePagoCliente = dr.IsDBNull(4)?(int)0:(int)dr.GetInt16(4);
					objCliente.DireccionCliente = dr.IsDBNull(5)?"(Sin Definir)":dr.GetString(5).Trim();
					objCliente.TelefonoCliente = dr.IsDBNull(6)?"(Sin Definir)":dr.GetString(6).Trim();
					objCliente.Estadocliente = dr.IsDBNull(7)?"Inactivo":dr.GetString(7);
					objCliente.PrecioDiferencial = dr.IsDBNull(8)?(int)0:dr.GetInt32(8);				
					objCliente.IdCiudad = dr.IsDBNull(9)?"0":dr.GetString(9);
					objCliente.CodigoAlterno = dr.IsDBNull(10)?"":dr.GetString(10);
					objCliente.TipoCredito = dr.IsDBNull(11)?"":dr.GetString(11);
					objCliente.TipoTransaccion = dr.IsDBNull(12)?"":dr.GetString(12);
                    objCliente.IdTipoAutorizacionExterna = dr.IsDBNull(13) ? (int)0 : (int)dr.GetByte (13);				

					base.AddItem(objCliente.CodigoCliente, objCliente);
				
				}
				dr.Close();
			}
			catch(Exception exception)
			{
				if (exception.Message.IndexOf("no existe!!!") != -1)
					throw new Exception("El usuario no se encuentra registrado como cliente del sistema");
				
			}
			
			dr = null;
			sql = null;
			
			
			#endregion
		}
		#endregion

		#region Add
		/// <summary>
		/// Inserta un Cliente en la DB.
		/// </summary>
		/// <param name="objCliente"></param>
		public static void Adicionar(Cliente objCliente){

			#region Prepare Sql
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
			sql.Append("ClientesInsertion");
			sql.ParametersNumber = 12;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, objCliente.CodigoCliente);
			sql.AddParameter("@Nombre", SqlDbType.VarChar, objCliente.NombreCliente);
			sql.AddParameter("@Tipo_Nit", SqlDbType.VarChar, objCliente.TipoNit);
			sql.AddParameter("@Nit", SqlDbType.VarChar, objCliente.NitCedulaCliente);
			sql.AddParameter("@Dir_Oficina", SqlDbType.VarChar, objCliente.DireccionCliente);
			sql.AddParameter("@Tel_Oficina", SqlDbType.VarChar, objCliente.TelefonoCliente);
			sql.AddParameter("@Cod_For_Pag", SqlDbType.Int, objCliente.FormaDePagoCliente);
			sql.AddParameter("@IdCiudad", SqlDbType.VarChar, objCliente.IdCiudad);
			sql.AddParameter("@CodigoAlterno", SqlDbType.Char, objCliente.CodigoAlterno);
            sql.AddParameter("@TipoCredito", SqlDbType.VarChar, objCliente.TipoCredito);
			sql.AddParameter("@TipoTransaccion", SqlDbType.VarChar, objCliente.TipoTransaccion);
            sql.AddParameter("@IdTipoAutorizacionExterna", SqlDbType.TinyInt, objCliente.IdTipoAutorizacionExterna);
			#endregion

			#region Execute Sql
			try 
			{
				 
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				if (e.Message.IndexOf("Llave Duplicada!") != -1)
					throw new Exception("Ya existe el cliente " + objCliente.CodigoCliente  + " !ERROR BD! ");
				else
					throw new Exception(e.Message  + " !ERROR BD! ");
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region Delete
		/// <summary>
		/// Elimina un Cliene de la DB
		/// </summary>
		/// <param name="cod_Cli">codigo del cliente a Eliminar.</param>
		public static void Eliminar(string cod_Cli) {
			
			#region Prepare Sql Command
			Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

			sql.Append("ClientesDeletion");
			sql.ParametersNumber = 2;
			sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, cod_Cli);	
			sql.AddParameter("@Nit", SqlDbType.VarChar, null);
			#endregion

			#region Execute Sql
			try {
				SqlHelper.ExecuteNonQuery(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters);
			}
			catch (SqlException e) {
				throw new Exception(e.Message);
			}
			finally {
				sql = null;
			}
			#endregion
		}
		#endregion

		#region GetItem
		/// <summary>
		/// Metodo para obtener un cliente en particular.
		/// </summary>
		/// <param name="cod_Cli">Codigo del cliente a Consultar</param>
		/// <param name="caso">caso 1, buscar por codigo, 2 buscar por nit</param>
		/// <returns>Cliente si existe. Null si no.</returns>
		public static Cliente ObtenerItem(string cod_Cli,int caso) 
		{
			Clientes objClientes = new Clientes(cod_Cli,caso);
			if (objClientes.Count == 1)
				return objClientes[0];
			else
				return null;
		}
		#endregion

		#region Obtener Items
		/// <summary>
		/// Método para obtener de manera directa uno o varios registros dependiendo de los criterios de busquda
		/// </summary>
		/// <param name="campo">Criterio por el cual se quiere buscar</param>
		/// <param name="valorCampo">Valor a buscar en la consulta</param>
		/// <param name="indexPagina">Numero de la pagina a mostrar</param>
		/// <param name="registrosPorPagina">Valor a buscar en la consulta</param>
		/// <param name="opcion">Opcion de consulta para retornar registros o cantidad de registros</param>
		/// <param name="orden">Orden en el que se retornaran los datos</param>
		public static DataSet ObtenerItems(int campo, string valorCampo, int indexPagina, int registrosPorPagina, int opcion, int orden)
		{

			#region Declaraciones

			string paramentros="";
			string [] rango;
			string valorCampoRango="";
			valorCampo = valorCampo.Trim();
			valorCampoRango = valorCampo.Replace("/","-");
			#endregion

			#region Criterios de busqueda			
			switch(campo)
			{
				case 1:
					paramentros = " @Nombre='" + valorCampo + "'";
					if(valorCampo.IndexOf("/") > -1)
						paramentros = " @Nombre='[" + valorCampoRango + "]'";
					break;
				
				case 2:
				case 4:
					paramentros = " @NitCedula='" + valorCampo + "' ";
					rango = valorCampo.Split("/".ToCharArray());
					if(rango.Length > 1)
						paramentros += ",@ValorInicial='" + rango[0].Trim() + "',@ValorFinal='" + rango[1].Trim() + "' ";
					break;
				
				case 3:
					paramentros = " @Cod_cli='" + valorCampo + "' ";
					rango = valorCampo.Split("/".ToCharArray());
					if(rango.Length > 1)
						paramentros += ",@ValorInicial='" + rango[0].Trim() + "',@ValorFinal='" + rango[1].Trim() + "' ";
					break;
				
				case 5:
					paramentros = "@DescripcionPago='" + valorCampo + "'";
					if(valorCampo.IndexOf("/") > -1)
						paramentros = " @DescripcionPago='[" + valorCampoRango + "]'";
					break;
				
				case 6:
					paramentros = "@Ciudad='" + valorCampo + "'";
					if(valorCampo.IndexOf("/") > -1)
						paramentros = " @Ciudad='[" + valorCampoRango + "]'";
					break;

				case 7:
					paramentros = "@Placa='" + valorCampo + "'";
					if(valorCampo.IndexOf("/") > -1)
						paramentros = " @Placa='[" + valorCampoRango + "]'";
					break;

				case 8:
					paramentros = "@Tipo='" + valorCampo + "'";
					if(valorCampo.IndexOf("/") > -1)
						paramentros = " @Tipo='[" + valorCampoRango + "]'";
					break;

			}

			#endregion

			#region Execute Sql

			if(valorCampo.Trim() == "")
				paramentros = "";
			if(paramentros.Trim().Length > 1)
				paramentros += ",@Opcion='" + opcion.ToString() + "' ";
			else
				paramentros += " @Opcion='" + opcion.ToString() + "' ";

			paramentros += ",@Orden='" + orden + "',@Top='" + Convert.ToString(indexPagina * registrosPorPagina + registrosPorPagina)+ "'";
			string orderSQL = "exec RecuperarClienteDinamico " + paramentros;

			SqlDataAdapter adapter = new SqlDataAdapter(orderSQL, Aplicacion.Conexion.ConnectionString);			

			DataSet dataSet = new DataSet();
			adapter.Fill(dataSet, indexPagina * registrosPorPagina,registrosPorPagina, "Clientes");
			return dataSet;

			#endregion


			
		}
		#endregion

	}
}
