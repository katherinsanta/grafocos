using System;
using System.Web;
using System.Web.Security;

namespace Servipunto.Estacion.Web
{
	public class WebApplication
	{
		#region Declaration Section
		public enum FormMode { New, Edit }
		#endregion

		#region Constructor
		public WebApplication()
		{			
		}
		#endregion

		#region Función CustomDateFormat()
		public static string CustomDateFormat(string format, System.DateTime date)
		{
			return date.ToString(format, new System.Globalization.CultureInfo("es-CO", false));
		}
		#endregion

        public void construir() 
        {

        }

	}
}
