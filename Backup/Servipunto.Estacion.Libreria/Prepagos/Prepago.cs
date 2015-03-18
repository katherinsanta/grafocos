using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

namespace Servipunto.Estacion.Libreria.Prepagos
{
    public class Prepago
    {
        #region declaraciones
        int _numeroPrepago;
	    string _idCompania;	
	    int _numeroInicialTiqueteCreado ;
	    int _numeroFinalTiqueteCreado  ;
	    int _numeroTiqueteInicialAsignacion ;
	    int _numeroTiqueteFinalAsignacion ;
	    DateTime _fechaCreacion  ;		
	    DateTime _fechaAsignacion;
	    DateTime _fechaAnulacion ;
	    DateTime _fechaTurnoUtilizacion ;
	    DateTime _fechaRealUtilizacion ;	
	    string _placa  ;
	    string _cod_Cli  ;
	    string _codigoCentroVenta  ;
	    decimal _denominacion ;	
        Servipunto.Estacion.Libreria.EstadoPrepago _estadoPrepago ;
	    string _idUsuarioCreo ;
	    string _idUsuarioAsigno;
        string _idUsuarioUtilizo; 

        
        //private ColorEnum _color;
        #endregion


        public int NumeroPrepago
        {
            set { _numeroPrepago = value; }
            get { return _numeroPrepago; }
        }

        public string IdCompania
        {
            set { _idCompania = value; }
            get { return _idCompania; }

        }


        public int NumeroInicialTiqueteCreado
        {
            set { _numeroInicialTiqueteCreado = value; }
            get { return _numeroInicialTiqueteCreado; }

        }


        public int NumeroFinalTiqueteCreado
        {
            set { _numeroFinalTiqueteCreado = value; }
            get { return _numeroFinalTiqueteCreado; }

        }


        public int NumeroTiqueteInicialAsignacion
        {
            set { _numeroTiqueteInicialAsignacion = value; }
            get { return _numeroTiqueteInicialAsignacion; }

        }


        public int NumeroTiqueteFinalAsignacion
        {
            set { _numeroTiqueteFinalAsignacion = value; }
            get { return _numeroTiqueteFinalAsignacion; }

        }

        public DateTime FechaCreacion
        {
            set { _fechaCreacion = value; }
            get { return _fechaCreacion; }

        }

        public DateTime FechaAsignacion
        {
            set { _fechaAsignacion = value; }
            get { return _fechaAsignacion; }

        }

               

        public DateTime FechaTurnoUtilizacion
        {
            set { _fechaTurnoUtilizacion = value; }
            get { return _fechaTurnoUtilizacion; }
        }

        public DateTime FechaRealUtilizacion
        {
            set { _fechaRealUtilizacion = value; }
            get { return _fechaRealUtilizacion; }
        }


        public DateTime FechaAnulacion
        {
            set { _fechaAnulacion = value; }
            get { return _fechaAnulacion; }
        }

        public string Placa
        {
            set { _placa = value; }
            get { return _placa; }
        }

        public string Cod_Cli
        {
            set { _cod_Cli = value; }
            get { return _cod_Cli; }
        }

        public string CodigoCentroVenta
        {
            set { _codigoCentroVenta = value; }
            get { return _codigoCentroVenta; }
        }

      

        public EstadoPrepago EstadoPrepago
        {
            set { _estadoPrepago = value; }
            get { return _estadoPrepago; }
        }

        public string IdUsuarioCreo
        {
            set { _idUsuarioCreo = value; }
            get { return _idUsuarioCreo; }
        }

        public string IdUsuarioAsigno
        {
            set { _idUsuarioAsigno = value; }
            get { return _idUsuarioAsigno; }
        }


        public string IdUsuarioUtilizo
        {
            set { _idUsuarioUtilizo = value; }
            get { return _idUsuarioUtilizo; }
        }

        public decimal Denominacion
        {
            set { _denominacion = value; }
            get { return _denominacion; }
        }



        #region Modificar
        /// <summary>
        /// Actualización de las propiedades: IdControlador, Estado, Modo
        /// </summary>
        public void Modificar()
        {
            #region Prepare Sql Command
            Servipunto.Libreria.SqlBuilder sql = new Servipunto.Libreria.SqlBuilder();
            sql.Append("ModificarPrepago");
            sql.ParametersNumber = 12;
            sql.AddParameter("@NumeroPrepago", SqlDbType.Int, this.NumeroPrepago);
            sql.AddParameter("@Estadoprepago", SqlDbType.Int, (int)this.EstadoPrepago);
            sql.AddParameter("@FechaAsignacion", SqlDbType.DateTime,this.FechaAsignacion);
            sql.AddParameter("@FechaAnulacion", SqlDbType.DateTime, this.FechaAnulacion);
            sql.AddParameter("@IdUsuarioAsigno", SqlDbType.VarChar,this.IdUsuarioAsigno);
            sql.AddParameter("@Cod_cli", SqlDbType.VarChar, this.Cod_Cli);
            sql.AddParameter("@Placa", SqlDbType.VarChar, this.Placa);
            sql.AddParameter("@NumeroTiqueteInicialAsignacion", SqlDbType.Int, this.NumeroTiqueteInicialAsignacion);
            sql.AddParameter("@NumeroTiqueteFinalAsignacion", SqlDbType.Int, this.NumeroTiqueteFinalAsignacion);
            sql.AddParameter("@FechaRealUtilizacion", SqlDbType.DateTime, this.FechaRealUtilizacion);
            sql.AddParameter("@FechaTurnoUtilizacion", SqlDbType.DateTime, this._fechaTurnoUtilizacion);
            sql.AddParameter("@IdUsuarioUtilizo", SqlDbType.VarChar, this.IdUsuarioUtilizo);              
            
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
