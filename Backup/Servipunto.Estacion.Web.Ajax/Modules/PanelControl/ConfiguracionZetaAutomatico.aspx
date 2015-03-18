<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ConfiguracionZetaAutomatico.aspx.cs"
    Inherits="Servipunto.Estacion.Web.Modules.PanelControl.ConfiguracionZetaAutomatico"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
 <script type="text/javascript">
  function VentanaEmergente()
    {
        var resultado = window.showModalDialog('../Busqueda/BuscadorDinamico.aspx?TipoDeBusqueda=Empleado',window,'dialogWidth:700px;dialogHeight:450px;resizable:no;center:yes');
        var txtIdenficacion = document.getElementById('<%=txtCodigoEmpleado.ClientID%>');
        var txtNombreRazonSocial =  document.getElementById('<%=txtNombreEmpleado.ClientID%>');
        if(resultado != null)
        {
            var arreglo = resultado.split('©');
            txtIdenficacion.value = arreglo[0];
            txtNombreRazonSocial.value = arreglo[1];  
        }
        
    }  
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
        <!-- Page Body -->
        <tr>
            <td valign="top" style="height: 100%">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="height: 100%">
                    <tr>
                        <!-- Topic Body -->
                        <td valign="top" style="width: 100%">
                            <!-- Topic Content -->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 30px; padding-left: 40px; height: 309px;">
                                        <br />
                                        <p>
                                            <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="Red"></asp:Label></p>
                                        <asp:Panel ID="pnlForm" Visible="true" runat="server">
                                            <p>
                                            </p>
                                            <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 333px;
                                                height: 220px">
                                                <tr>
                                                    <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="height: 5px">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblFormTitle" runat="server">Titulo</asp:Label></td>
                                                                <td align="right">
                                                                    <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ResultsItem" valign="middle" align="left" style="width: 1267px; height: 214px;">
                                                        <table cellpadding="4" border="0" style="width: 464px; height: 129px">
                                                            <tr>
                                                                <td style="height: 27px; width: 1384px;">
                                                                    Hora Inicio(hh:mm):</td>
                                                                <td style="height: 27px; width: 1424px;">
                                                                    <asp:DropDownList ID="ddlHoraInicio" runat="server" Width="44px">
                                                                        <asp:ListItem>00</asp:ListItem>
                                                                        <asp:ListItem Value="1">01</asp:ListItem>
                                                                        <asp:ListItem Value="2">02</asp:ListItem>
                                                                        <asp:ListItem Value="3">03</asp:ListItem>
                                                                        <asp:ListItem Value="4">04</asp:ListItem>
                                                                        <asp:ListItem Value="5">05</asp:ListItem>
                                                                        <asp:ListItem Value="6">06</asp:ListItem>
                                                                        <asp:ListItem>07</asp:ListItem>
                                                                        <asp:ListItem Value="8">08</asp:ListItem>
                                                                        <asp:ListItem Value="9">09</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                        <asp:ListItem>13</asp:ListItem>
                                                                        <asp:ListItem>14</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>16</asp:ListItem>
                                                                        <asp:ListItem>17</asp:ListItem>
                                                                        <asp:ListItem>18</asp:ListItem>
                                                                        <asp:ListItem>19</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>21</asp:ListItem>
                                                                        <asp:ListItem>22</asp:ListItem>
                                                                        <asp:ListItem>23</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    :<asp:DropDownList ID="ddlMinutoInicio" runat="server" Width="44px">
                                                                        <asp:ListItem Value="0">00</asp:ListItem>
                                                                        <asp:ListItem Value="5">05</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>30</asp:ListItem>
                                                                        <asp:ListItem>35</asp:ListItem>
                                                                        <asp:ListItem>40</asp:ListItem>
                                                                        <asp:ListItem>45</asp:ListItem>
                                                                        <asp:ListItem>50</asp:ListItem>
                                                                        <asp:ListItem>55</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 1384px; height: 35px">
                                                                    Hora Final(hh:mm):</td>
                                                                <td style="width: 1424px; height: 35px">
                                                                    <asp:DropDownList ID="ddlHoraFinal" runat="server" Width="44px">
                                                                        <asp:ListItem>00</asp:ListItem>
                                                                        <asp:ListItem Value="1">01</asp:ListItem>
                                                                        <asp:ListItem Value="2">02</asp:ListItem>
                                                                        <asp:ListItem Value="3">03</asp:ListItem>
                                                                        <asp:ListItem Value="4">04</asp:ListItem>
                                                                        <asp:ListItem Value="5">05</asp:ListItem>
                                                                        <asp:ListItem Value="6">06</asp:ListItem>
                                                                        <asp:ListItem Value="7">07</asp:ListItem>
                                                                        <asp:ListItem Value="8">08</asp:ListItem>
                                                                        <asp:ListItem Value="9">09</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                        <asp:ListItem>13</asp:ListItem>
                                                                        <asp:ListItem>14</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>16</asp:ListItem>
                                                                        <asp:ListItem>17</asp:ListItem>
                                                                        <asp:ListItem>18</asp:ListItem>
                                                                        <asp:ListItem>19</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>21</asp:ListItem>
                                                                        <asp:ListItem>22</asp:ListItem>
                                                                        <asp:ListItem>23</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    :<asp:DropDownList ID="ddlMinutoFinal" runat="server" Width="44px">
                                                                        <asp:ListItem Value="0">00</asp:ListItem>
                                                                        <asp:ListItem Value="5">05</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>30</asp:ListItem>
                                                                        <asp:ListItem>35</asp:ListItem>
                                                                        <asp:ListItem>40</asp:ListItem>
                                                                        <asp:ListItem>45</asp:ListItem>
                                                                        <asp:ListItem>50</asp:ListItem>
                                                                        <asp:ListItem>55</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 40%; height: 15px" valign="top">
                                                                    Código
                                                                    <asp:Label ID="Label2" runat="server" Text="Empleado"></asp:Label>:</td>
                                                                <td style="width: 60%" align="left">
                                                                    <asp:TextBox ID="txtCodigoEmpleado" runat="server" Width="100px"></asp:TextBox>
                                                                &nbsp;&nbsp;
                                                                    <input onclick="VentanaEmergente()" type="button" value="..." title="Buscar empleados"
                                                                        id="Button2" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigoEmpleado"
                                                                        ErrorMessage="*Codigo Empleado Requerido"></asp:RequiredFieldValidator>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 40%; height: 15px" valign="top">
                                                                    Nombre Empleado:</td>
                                                                <td style="width: 60%" align="left">
                                                                    <asp:TextBox ID="txtNombreEmpleado" runat="server" Width="306px" AutoPostBack="True"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 29px; width: 1384px;">
                                                                    &nbsp;<asp:CheckBox ID="chkZetaAutomatico" runat="server" AutoPostBack="True" Visible="False"
                                                                        Width="121px" /></td>
                                                                <td style="height: 29px; width: 1424px;">
                                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar" />
                                                                    <asp:Label ID="lblHide" runat="server" Visible="False"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <!-- End Topic Content -->
                        </td>
                        <!-- End Topic Body -->
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
