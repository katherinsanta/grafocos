using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Servipunto.Estacion.Libreria
{
    public class ExtractoDetallado
    {
        #region Sección de Declaraciones
        DateTime _fechaInicio;
        DateTime _fechaFinal;
        string _cod_cli;
        string _estadoPrepago;
        #endregion

        #region Propiedades
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        public DateTime FechaFinal
        {
            get { return _fechaFinal; }
            set { _fechaFinal = value; }
        }
        public string Cod_cli
        {
            get { return _cod_cli; }
            set { _cod_cli = value; }
        }
        public string EstadoPrepago
        {
            get { return _estadoPrepago; }
            set { _estadoPrepago = value; }
        }
        #endregion

        #region Reporte detalle de extractos

        public static DataSet RptExtractoDetallado(string _fechaInicio, string _fechaFinal,
        string _cod_cli, string _estadoPrepago)
        {


            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();

            sql.Append("ReporteDetalladoVentas");
            sql.ParametersNumber = 4;
            sql.AddParameter("@FechaInicio", SqlDbType.VarChar, _fechaInicio);
            sql.AddParameter("@FechaFinal", SqlDbType.VarChar, _fechaFinal);
            sql.AddParameter("@Cod_Cli", SqlDbType.VarChar, _cod_cli);
            sql.AddParameter("@EstadoPrepago", SqlDbType.VarChar, _estadoPrepago);

            #endregion

            #region Execute Sql
            try
            {
                return (SqlHelper.ExecuteDataset(Aplicacion.Conexion.ConnectionString, CommandType.StoredProcedure, sql.Text, sql.Parameters));
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
