<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Descuento.aspx.cs" Inherits="Servipunto.Estacion.Web.Ajax.Modules.PanelControl.Descuentos"
    MasterPageFile="~/PaginaMaestra/actualizacion.Master" %>

<%@ Register Src="~/ControlesdelUsuario/Mensaje.ascx" TagName="Mensaje" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMaestro1" runat="server">
    <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlForm" Visible="true" runat="server">
        <table class="ResultsTable" cellspacing="1" cellpadding="4" border="0" style="width: 80%;">
            <tr>
                <td class="ResultsHeader4" valign="middle" align="left" colspan="2" style="height: 40px">
                    <table width="100%">
                        <tr>
                            <td style="height: 15px">
                                <asp:Label ID="lblFormTitle" runat="server">Título</asp:Label>
                            </td>
                            <td align="right" style="height: 15px">
                                <asp:HyperLink ID="lblBack" runat="server">Volver</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="ResultsItem" valign="middle" align="left" style="width: 80%">
                    <table cellpadding="4" border="0" style="width: 100%">
                        <tr>
                            <td colspan="2">
                                <label>
                                    Fecha De Creacion
                                </label>
                                <asp:Label ID="LabelFechaCreac" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <label>
                                    Fecha De Modificacion</label>
                                <asp:Label ID="LabelFechaModifi" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 400px" valign="top" rowspan="10">
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <asp:Image ID="ImgHelp" ImageUrl="~/BlueSkin/Update/consultas-48.png" runat="server" />
                                        </td>
                                        <td>
                                            En este descuento usted puede definir:<br />
                                            <i>- Si es por articulo, manguera surtidor, isla o general.<br />
                                                - Si es en porcentaje o valor.<br />
                                                - Días de la semana y horario de aplicación.<br />
                                            </i>También se puede definir cuando aplica en los siguientes casos:<br />
                                            <i><b>Precio Diferencial: </b>Este define si se debe aplicar este descuento programado
                                                cuando un cliente tiene un precio diferencial.<br />
                                                Precio diferencial es que el sistema vende con un precio diferente al del surtidor
                                                a un cliente especifico y esto se hace por comerciales, clientes.<br />
                                                <b>Automotor: </b>Este define si se debe aplicar este descuento programado cuando
                                                un automotor tiene un descuento.<br />
                                                Descuento automotor se asigna por comerciales, clientes.<br />
                                                <b>Fidelizado: </b>Define si al fidelizado si se le aplica este descuento.</i><br />
                                            <b>NOTA:</b><br />
                                            También usted puede inactivar un descuento en cualquier momento dentro del lapso
                                            de tiempo programado. Lo mismo Si ya este descuento ha sido aplicado al menos una
                                            vez, ya no se podrá eliminar.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 182px">
                                &nbsp;Descuento:<br />
                            </td>
                            <td style="width: 200px">
                                <asp:RadioButton runat="server" ID="RadioButton1" Text="Valor" GroupName="GrupTipoDescuento" Checked="false" AutoPostBack="True"  />
                                    <asp:RadioButton runat="server" ID="RadioButton2" Text="%Descuento" GroupName="GrupTipoDescuento" Checked="true" AutoPostBack="True"  /></td>
                            <td style="width: 280px">
                                <label style="height: 17px">
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Height="17px" Text="Tipo Descuento:"
                                    Width="113px"></asp:Label>
                                <asp:DropDownList ID="ddlTipoDescuento" runat="server" Width="107px" AutoPostBack="True"
                                    OnTextChanged="ddlTipoDescuento_TextChanged">
                                    <asp:ListItem Value="0">General</asp:ListItem>
                                    <asp:ListItem Value="1">Articulo</asp:ListItem>
                                    <asp:ListItem Value="2">Manguera</asp:ListItem>
                                    <asp:ListItem Value="3">Surtidor</asp:ListItem>
                                    <asp:ListItem Value="4">Isla</asp:ListItem>
                                </asp:DropDownList></label></td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 29px;">
                            <asp:Label ID="LabelValor" runat="server" Text="Valor:" Height="17px" Width="79px"
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="LabelPorc" runat="server" Text="% Descuento:" Height="17px" Width="79px"
                                    Font-Bold="True"></asp:Label></td>
                            <td style="width: 200px; height: 29px;">
                                <asp:TextBox ID="TexValor" runat="server"></asp:TextBox>
                                </td>
                            <td style="width: 280px; height: 29px;">
                                <label>
                                    Redondear</label>
                                <asp:RadioButton runat="server" ID="RbReSi" Text="Si" GroupName="GrupRedondear" Checked="false"  />
                                <asp:RadioButton runat="server" ID="RbReNo" Text="No" GroupName="GrupRedondear" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 30px">
                                <asp:Label ID="lblTipoDescuento" runat="server" Font-Bold="True" Height="17px" Text="Selección Articulo:"
                                    Width="115px"></asp:Label></td>
                            <td style="width: 200px; height: 20px">
                                <asp:CheckBoxList ID="chkListaItems" runat="server" Height="43px" Width="221px" BorderStyle="Groove" />
                                <asp:CheckBox ID="chkChequeoLista" runat="server" Text="Todos" Width="91px" OnCheckedChanged="chkChequeoLista_CheckedChanged"
                                    AutoPostBack="True" Enabled="False" Font-Bold="True" />
                            </td>
                            <td style="width: 280px; height: 20px">
                                <label>
                                    Activar</label>&nbsp;&nbsp;
                                <asp:RadioButton runat="server" ID="RbInactivo" Text="Inactivo" GroupName="GrupEstado"
                                    Checked="false" />
                                <asp:RadioButton runat="server" ID="RbActivo" Text="Activo" GroupName="GrupEstado"
                                    Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 4px">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Height="17px" Text="Dias Semana: "
                                    Width="79px"></asp:Label>&nbsp;
                                <asp:CheckBox ID="chkTodosLosDias" runat="server" Text="Todos los días" AutoPostBack="True"
                                    Checked="True" OnCheckedChanged="chkTodosLosDias_CheckedChanged" Width="99px" />
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                            <td style="width: 200px; height: 4px">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Height="17px" Text="Fecha Inicio"
                                    Width="79px"></asp:Label></td>
                            <td style="width: 280px; height: 4px">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Height="17px" Text="Fecha Final:"
                                    Width="79px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 20px" valign="top">
                                &nbsp;
                                <br />
                                <asp:CheckBoxList ID="chkListaDiasSemana" runat="server" Height="136px" Width="116px"
                                    BorderStyle="Groove" Enabled="False">
                                    <asp:ListItem Value="1" Selected="True">Lunes</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">Martes</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">Miercoles</asp:ListItem>
                                    <asp:ListItem Value="4" Selected="True">Jueves</asp:ListItem>
                                    <asp:ListItem Value="5" Selected="True">Viernes</asp:ListItem>
                                    <asp:ListItem Value="6" Selected="True">Sabado</asp:ListItem>
                                    <asp:ListItem Value="7" Selected="True">Domingo</asp:ListItem>
                                </asp:CheckBoxList></td>
                            <td style="width: 200px; height: 20px" valign="top">
                                &nbsp;<asp:Calendar ID="calFechaInicio" runat="server" BackColor="White" BorderColor="White"
                                    BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="152px"
                                    NextPrevFormat="FullMonth" Width="230px">
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#333399" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 280px; height: 20px" valign="top">
                                &nbsp;<asp:Calendar ID="calFechaFinal" runat="server" BackColor="White" BorderColor="White"
                                    BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="152px"
                                    NextPrevFormat="FullMonth" Width="230px">
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#333399" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 20px">
                                <asp:CheckBox ID="ChkTodasHoras" runat="server" Text="Todas las Horas" Width="113px"
                                    AutoPostBack="True" Checked="True" Font-Bold="True" OnCheckedChanged="ChkTodasHoras_CheckedChanged" /></td>
                            <td style="width: 200px; height: 20px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Height="17px" Text="Hora Inicio (hh:mm):"
                                    Width="143px"></asp:Label></td>
                            <td style="width: 280px; height: 20px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Height="17px" Text="Hora Final(hh:mm):"
                                    Width="111px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 182px; height: 20px">
                            </td>
                            <td style="width: 200px; height: 20px">
                                <asp:DropDownList ID="ddlHoraInicio" runat="server" Width="47px" Enabled="False">
                                </asp:DropDownList>:<asp:DropDownList ID="ddlMinutoInicio" runat="server" Width="47px"
                                    Enabled="False">
                                </asp:DropDownList></td>
                            <td style="width: 280px; height: 20px">
                                <asp:DropDownList ID="ddlHoraFinal" runat="server" Width="47px" Enabled="False">
                                </asp:DropDownList>:<asp:DropDownList ID="ddlMinutoFinal" runat="server" Width="47px"
                                    Enabled="False">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Aplica</label>
                                &nbsp;&nbsp;
                                <asp:CheckBoxList ID="ChkAplica" runat="server" BorderStyle="Groove" Enabled="True">
                                    <asp:ListItem Value="1">Cliente</asp:ListItem>
                                    <asp:ListItem Value="2">Automotor</asp:ListItem>
                                    <asp:ListItem Value="3">Fidelizado</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 29px;" align="center" colspan="3">
                                <asp:Button ID="btnGuardar" runat="server" Height="31px" OnClick="btnGuardar_Click"
                                    Text="Guardar" Width="80px" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" class="ResultsItem" style="width: 575px" valign="middle">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
