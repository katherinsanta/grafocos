using System;
using DataDynamics.ActiveReports;

namespace Servipunto.Estacion.Modules.Visor
{
	/// <summary>
	/// Clase para el diseño de Reportes en ActiveReports.
	/// </summary>
	

	public class Reporte : System.Web.HttpApplication
	{
	
		#region Sección de Declaraciones		
		#endregion

		#region Constructor
		public Reporte()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		#endregion
		
		#region Reporte: VentasPorEmpleadoTurnoIslaManguera
		public DataDynamics.ActiveReports.ActiveReport VentasPorEmpleadoTurnoIslaManguera(System.DateTime fechaInicio, System.DateTime fechaFin, int empleado, bool todosEmpleados, int turno, bool todosTurnos, int isla, int manguera, bool todasMangueras)
		{		//Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaManguera(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate, int.Parse( this.txtEmpleado.Text ), this.cbTodosEmpleados.Checked, int.Parse( this.txtTurno.Text ), this.cbTodosTurnos.Checked, int.Parse( cboIsla.SelectedValue ),int.Parse( this.txtManguera.Text ), this.cbTodasManguera.Checked);				
			Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaManguera objReporte = new Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaManguera(fechaInicio, fechaFin, empleado, todosEmpleados, turno, todosTurnos, isla, manguera, todasMangueras);
			
			return objReporte;
		}
		#endregion
		
	}
}
