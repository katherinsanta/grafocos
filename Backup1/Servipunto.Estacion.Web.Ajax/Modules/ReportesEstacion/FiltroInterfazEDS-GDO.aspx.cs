using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;
using System.Data.SqlClient;
using System.IO;


namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Descripción breve de FiltroInterfazEDS_GDO.
	/// </summary>
	public class FiltroInterfazEDS_GDO : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Label lblArchivo;
		protected System.Web.UI.WebControls.LinkButton lblImportarNovedades;
		protected System.Web.UI.WebControls.Label lblEstado;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
			// Introducir aquí el código de usuario para inicializar la página
			if (this.IsPostBack)
			{
				if (Request.Form["__EVENTTARGET"].Length == 0)
				{
					this.lblError.Visible = false;
				}
			}
			else
			{
				this.VerificarPermisos();
				this.InicializarForma();
			}
		}
		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Interfaz Contable";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generacion Archivo Plano de Facturas");
		
			if (!permiso)
			{
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
				this.MyForm.Visible = false;
				return false;
			}
		
			return true;
		}

		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
		}
		#endregion

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lblImportarNovedades.Click += new System.EventHandler(this.lblEnviaRecaudoGDO_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Generar Archivo Plano Recaudos GDO</b>";
			this.FechaInicio.SelectedDate = DateTime.Now;
		}
		#endregion

		private void lblEnviaRecaudoGDO_Click(object sender, System.EventArgs e)
		{
			this.GenerarArchivoRecaudoGDO();
		}


		#region Método ActualizarNovedadesGDO
		private void GenerarArchivoRecaudoGDO()
		{
			//se hace el mismo procedimiento para la generación del plano
			this.lblError.Visible = false;
			StreamWriter filereporte  = null;		
			
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);

				//SqlConnection Conexion = new SqlConnection("Server = (local); DataBase = EstacionCali; Integrated Security = false; user = sa; password = sa");
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				
				string filename = "C:\\servipunto\\administ\\enviados\\enviados.txt"; 
				filereporte  = new StreamWriter(filename);		
				string _fechastr =  this.FechaInicio.SelectedDate.Year.ToString().TrimEnd().PadLeft(4,'0') + "-" + this.FechaInicio.SelectedDate.Month.ToString().TrimEnd().PadLeft(2,'0') + "-" + this.FechaInicio.SelectedDate.Day.ToString().TrimEnd().PadLeft(2,'0') ; 
				//	string _fechastr = "2007-02-24";
				string sql = "select c.nombre, c.cod_cli, c.dir_oficina, a.marca, c.tel_oficina, v.placa, a.modelo, dbo.finteger(v.fecha_real) fecha, dbo.hinteger(v.hora) hora, v.total_cuota, v.cod_est, f.nombre, cd.saldo, tp.porcentaje";
				sql += " from ventas v inner join clientes c on v.cod_cli = c.cod_cli ";
				sql += " inner join creditos cd on v.placa = cd.placa ";	
				sql += " inner join automoto a on a.placa = v.placa ";	
				sql += " inner join financieras f on cd.financiera = f.codigo ";
				sql += " inner join tipo_porcen tp on tp.tipo = cd.tipoporcentaje and v.financiera = tp.financiera";
				sql += " where dbo.finteger(fecha_real) ='" +  _fechastr + "'"; 
				sql += " and v.total_cuota > 0";
				

				SqlCommand com = new SqlCommand();

				com.CommandText = sql;
				com.Connection = Conexion;
				com.CommandType = CommandType.Text;
				SqlDataReader objDr = com.ExecuteReader();

				string registro = "";
				string concepto = "10";
				char espacio = ' ';
				char cero = '0';
				string blanco = " ";			
				string hora;
				string strFinanciera;
			

				this.lblEstado.Text = "Procesando..";

				while (objDr.Read())
				{
					registro = "";
					registro += concepto.PadLeft(2, cero); //concepto
					registro += objDr.IsDBNull(0)? blanco.PadLeft(40,espacio): objDr.GetString(0).Substring(0,40);  // nombre					
					registro += objDr.IsDBNull(1)? blanco.PadLeft(14, cero): objDr.GetString(1).Substring(0,14); // Cedula
					registro += objDr.IsDBNull(2)? blanco.PadRight(65,espacio) : objDr.GetString(2).PadRight(65,espacio); //direccion
					registro += objDr.IsDBNull(3)? blanco.PadLeft(10,cero) : objDr.GetString(3).TrimEnd().PadLeft(10, cero);  //sol credito
					registro += objDr.IsDBNull(4)? blanco.PadRight(18, espacio): objDr.GetString(4).TrimEnd().PadRight(18,' '); // telefono
					//registro += " ".PadLeft(11,' ');
					registro += objDr.IsDBNull(5)? blanco.PadLeft(10,espacio): objDr.GetString(5).TrimEnd().PadRight(10,espacio); // placa
					string serv = objDr.IsDBNull(6)? blanco.PadLeft(8,cero): objDr.GetString(6).TrimEnd().PadLeft(8,cero); // serv subscriptor
					registro += "0" + serv.Substring(0,7); 									
					DateTime ffecha =  objDr.IsDBNull(7)? DateTime.Now.Date: objDr.GetDateTime(7); // fecha
					registro += ffecha.Day.ToString().TrimEnd().PadLeft(2,'0') + "/" +  ffecha.Month.ToString().TrimEnd().PadLeft(2,'0') + "/" + ffecha.Year.ToString().TrimEnd().PadLeft(4,'0'); 
					registro += espacio ; //espacio					
					hora = objDr.IsDBNull(8)? "00:00:00" : objDr.GetString(8); // hora
					registro += hora.Length == 8 ? hora.Substring(0,5): cero + hora.Substring(0,4);
					decimal recaudo = objDr.IsDBNull(9)? (decimal)0: objDr.GetDecimal(9); 
					registro +=  cero + (recaudo.ToString().PadLeft(13, cero)).Substring(0,12);  // sucursal
					int sucursal = objDr.IsDBNull(10)? 0: objDr.GetInt32(10); 
					registro += sucursal.ToString().TrimEnd().PadRight(3,espacio);					
					strFinanciera = objDr.IsDBNull(11)? "000": objDr.GetString(11).Substring(10); // financiera					
					registro += strFinanciera.TrimEnd().PadLeft(3, cero);
					decimal saldo = objDr.IsDBNull(12)? (decimal)0: objDr.GetDecimal(12); // saldo
					registro += saldo.ToString().TrimEnd().PadLeft(13, cero); 
					decimal porcentaje = objDr.IsDBNull(13)? (decimal)0: objDr.GetDecimal(13); // porcentaje
					registro += porcentaje.ToString().TrimEnd().PadLeft(6, cero);
					registro = registro.Replace(',', '.');
					filereporte.WriteLine(registro);				
					
				}
				this.lblEstado.Text = "Proceso Finalizado";


				filereporte.Close();
				objDr = null;				

				
			}
			catch(Exception ex)
			{
				filereporte.Close();
				this.SetError("error: "  + ex.Message);
				//MessageBox.Show(ex.Message);

			}

		}



		
		
		#endregion

		#endregion
	}
}
