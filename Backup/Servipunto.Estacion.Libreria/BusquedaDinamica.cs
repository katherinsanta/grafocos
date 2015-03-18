using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


using Servipunto.Estacion.AccesoDatos.EntityClasses;
using Servipunto.Estacion.AccesoDatos.CollectionClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Servipunto.Estacion.AccesoDatos.HelperClasses;
using System.Data;

namespace Servipunto.Estacion.Libreria
{
    public enum BusquedaDesignada
    {
        Ninguno,
        Cliente,      
        Automotor,
        Prepago,
        AutomotoresCliente,
        Empleado
    }

    public class BusquedaDinamica
    {
        #region Declaracion de variables
        
        Utilidades _objUtilidades = new Utilidades();
        //Cultura _objCultura = new Cultura();
        #endregion

        #region MetodosPrivados

        #endregion

        #region MetodosPublicos

        #region RecuperarTipoDeBusqueda
        /// <summary>
        /// Recupera el enumerado correspondiente al tipo de busqueda
        /// </summary>
        /// Referencia Documental: (Falta)
        /// Fecha: 09/06/2009
        /// Autor: Elvis Astaiza
        public BusquedaDesignada RecuperarBusquedaDesignada(string tipoBusqueda)
        {
            string[] tiposDeBusqueda = Enum.GetNames(typeof(BusquedaDesignada));
            for (int i = 0; i < tiposDeBusqueda.Length; i++)
                if (tipoBusqueda.Trim().ToLower() == tiposDeBusqueda[i].ToLower())
                    return (BusquedaDesignada)i;
            throw new Exception("Tipo de busqueda no configurada: " + tipoBusqueda + "!.");
        }
        #endregion

        #region RecuperarDatos
        /// <summary>
        /// Parametros de la busqueada
        /// </summary>
        /// <param name="parametros">[0]TipoDeBusqueda La entidad en la cual se va a buscar ej: Cliente, Articulo 
        ///                          [1]CriterioDeBusqueda El campo por el cual se va a filtrar ej : Identificacion, Nombre, 
        ///                          [2]DatoABuscar Dato que se va a buscar en la coleccion ej: Oliver
        ///                          [3]Comodin Como se van a utilizar los comodines de busqueda ej: Inicien, Terminen</param>
        ///                          [n...] Otros parametros que requiera la consulta.
        /// Referencia Documental: (Falta)
        /// Fecha:  09/06/2009
        /// Autor:  Elvis Astaiza Gutierrez        
        public DataTable RecuperarDatos(ArrayList parametros
                                        )
        {
            #region Declaracion de variables
            BusquedaDesignada tipoDeBusqueda = BusquedaDesignada.Ninguno;
            string criterioDeBusqueda;
            string datoABuscar;
            string comodin;
            DataTable tabla = new DataTable("Busqueda");
            DataColumn columna;
            DataRow row;
            IPredicateExpression filtro = new PredicateExpression();
            ISortExpression objOrden = new SortExpression();            
            ClientesCollection objClientes = new ClientesCollection();
            EmpleadoCollection objEmpleados = new EmpleadoCollection();
            AutomotoCollection objAutomotores = new AutomotoCollection();
                         
            #endregion
            try
            {
                #region Asignacion de parametros de busqueda
                if (parametros.Count < 4)
                    throw new Exception("Parametros incompletos para la consulta!");
                tipoDeBusqueda = this.RecuperarBusquedaDesignada(parametros[0].ToString());
                criterioDeBusqueda = parametros[1].ToString();
                datoABuscar = parametros[2].ToString();
                comodin = parametros[3].ToString();
                datoABuscar = _objUtilidades.AsignarComodines(datoABuscar, comodin);
                #endregion

                #region RecuperarDatos
                switch (tipoDeBusqueda)
                {
                  
                    #region Cliente
                    case BusquedaDesignada.Cliente:                                              
                        if (datoABuscar.Trim().Length > 0)
                        {
                            if (criterioDeBusqueda == "Cod_Cli")
                                filtro.AddWithAnd(new PredicateExpression(ClientesFields.CodCli % datoABuscar));
                            else if (criterioDeBusqueda == "Nombre")
                                filtro.AddWithAnd(new PredicateExpression(ClientesFields.Nombre % datoABuscar));
                        }
                        objClientes.GetMulti(filtro);

                        columna = new DataColumn("Cod_Cli", Type.GetType("System.String"));
                        tabla.Columns.Add(columna);
                        columna = new DataColumn("Nombre", Type.GetType("System.String"));
                        tabla.Columns.Add(columna);

                        foreach (ClientesEntity objCliente in objClientes)
                        {
                            row = tabla.NewRow();
                            row["Cod_Cli"] = objCliente.CodCli;
                            row["Nombre"] = objCliente.Nombre;
                            tabla.Rows.Add(row);
                        }
                        break;
                    #endregion

                    case BusquedaDesignada.Empleado:
                        if (datoABuscar.Trim().Length > 0)
                        {
                            if (criterioDeBusqueda == "CodEmp")
                                filtro.AddWithAnd(new PredicateExpression(EmpleadoFields.CodEmp % datoABuscar));
                            else if (criterioDeBusqueda == "Nombre")
                                filtro.AddWithAnd(new PredicateExpression(EmpleadoFields.Nombre % datoABuscar));
                        }
                        objEmpleados.GetMulti(filtro);

                        columna = new DataColumn("CodEmp", Type.GetType("System.String"));
                        tabla.Columns.Add(columna);
                        columna = new DataColumn("Nombre", Type.GetType("System.String"));
                        tabla.Columns.Add(columna);

                        foreach (EmpleadoEntity objEmpleado in objEmpleados)
                        {
                            row = tabla.NewRow();
                            row["CodEmp"] = objEmpleado.CodEmp;
                            row["Nombre"] = objEmpleado.Nombre;
                            tabla.Rows.Add(row);
                        }
                        break;

                    case BusquedaDesignada.Automotor:
                        if (datoABuscar.Trim().Length > 0)
                        {                          
                             filtro.AddWithAnd(new PredicateExpression(AutomotoFields.Placa % datoABuscar));
                          
                        }
                        objAutomotores.GetMulti(filtro);

                        columna = new DataColumn("Placa", Type.GetType("System.String"));
                        tabla.Columns.Add(columna);                     

                        foreach (AutomotoEntity objAutomoto in objAutomotores)
                        {
                            row = tabla.NewRow();
                            row["Placa"] = objAutomoto.Placa;                          
                            tabla.Rows.Add(row);
                        }
                        break;
                   

                    default:
                        throw new Exception("Busqueda no configurada: " + tipoDeBusqueda.ToString());
                }
                #endregion
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas al buscar: " + tipoDeBusqueda.ToString() + " " + ex.Message);
            }
        }
        #endregion

        #endregion
    }
}
