using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Servipunto.Estacion.Libreria
{
    public class InventarioItemCanastilla
    {
         #region Sección de Declaraciones
        DateTime _fecha;
        short _cod_art;
        decimal _compraFactura;        
        decimal _salidas;        
        decimal _saldoSistema;
        decimal _saldoFisico;
        decimal _sobrante;
        decimal _faltante;

        #endregion

        #region Constructor y Destructor
		/// <summary>
		/// Constructor de la Clase
		/// </summary>
        public InventarioItemCanastilla()
		{
		}
		#endregion


        #region Propiedades Públicas
        
        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Fecha
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }

       
        /// <summary>
        /// Id Concepto
        /// </summary>
        public short Cod_Art
        {
            get { return this._cod_art; }
            set { this._cod_art = value; }
        }

        /// <summary>
        /// Valor
        /// </summary>

        public decimal CompraFactura
        {
            get { return _compraFactura; }
            set { _compraFactura = value; }
        }

        public decimal Salidas
        {
            get { return _salidas; }
            set { _salidas = value; }
        }


        public decimal SaldoSistema
        {
            get { return _saldoSistema; }
            set { _saldoSistema = value; }
        }

        public decimal SaldoFisico
        {
            get { return _saldoFisico; }
            set { _saldoFisico = value; }
        }

        public decimal Sobrante
        {
            get { return _sobrante; }
            set { _sobrante = value; }
        }

        public decimal Faltante
        {
            get { return _faltante; }
            set { _faltante = value; }
        }

        #endregion

        #region Modificar
        /// <summary>
        /// Actualiza inventario de unn articulo
        /// </summary>
        public void Modificar()
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ActualizarInventarioCanastilla");
            sql.ParametersNumber = 8;
            sql.AddParameter("@Fecha", SqlDbType.DateTime, this._fecha);
            sql.AddParameter("@Cod_Art", SqlDbType.SmallInt, this._cod_art);
            sql.AddParameter("@FacturaCompra", SqlDbType.Decimal, this._compraFactura);
            sql.AddParameter("@Salidas", SqlDbType.Decimal, this._salidas);
            sql.AddParameter("@SaldoSistema", SqlDbType.Decimal, this._saldoSistema);
            sql.AddParameter("@SaldoFisico", SqlDbType.Decimal, this._saldoFisico);
            sql.AddParameter("@Sobrante", SqlDbType.Decimal, this._sobrante);
            sql.AddParameter("@Faltante", SqlDbType.Decimal, this._faltante);            

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

    }
}
