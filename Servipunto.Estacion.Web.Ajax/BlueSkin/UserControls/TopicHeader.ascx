<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicHeader.ascx.cs" Inherits="Servipunto.Cartera.Web.BlueSkin.UserControls.TopicHeader" %>
<!-- Topic Header -->
		<table class="pageheading" cellspacing=0 cellpadding="5" width='100%' bgcolor="#0347bf" border="0">
			<tr>
			    <td style="width: 69px">
			      <img height="48"" src='<%=ImagenT%>' width=48 border=0 alt=""/>									        
			    </td>
				
				<td class="pageheading" align="left">
					<font class="title"><%=Title%></font>
					<br/><%=ShortDescription%>
				</td>
				
				<td valign="top" align="right"></td>
			</tr>
			
		</table>