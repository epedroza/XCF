<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="catCentrosDeServicio.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Catalog.catCentrosDeServicio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Centros de Servicio
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="2" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Clave Centro de Servicio</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtIdCentroDeServicio" runat="server" 
                                    CssClass="Textbox_General" width="80px" Enabled="False" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;RFC</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtRFC" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Terminal</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtTerminal" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;CD</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtCD" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Dirección</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtDireccion" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Ciudad</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="cboCiudad" runat="server" CssClass="Textbox_General" width="155px" ></asp:DropDownList></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Pro Externo</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtProExterno" runat="server" CssClass="Textbox_General" width="310px" ></asp:TextBox></td>
						</tr>
					</table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" />
                     </td>
                     <td style="height:24px; text-align:left; width:130px;">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" />
                     </td>
					 <td style="height:24px; width:530px;" align="left">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="Button_General" Text="Guardar" width="125px" onclick="btnGuardar_Click" />
                      </td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
         <table>
            <tr>
            <td colspan="6">
                <img src="../../../../Include/Image/Web/Div.png" />
                <a href="" class="accordionLink"></a><br />
                <br /></td>
            </tr>
        </table>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
                <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvApps_PageIndexChanging"
                        OnRowDataBound="gvApps_RowDataBound" OnSelectedIndexChanged="gvApps_SelectedIndexChanged"
                        OnSelectedIndexChanging="gvApps_SelectedIndexChanging" OnRowCommand="gvApps_RowCommand"
                        UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="idCentroDeServicio, idCompany, sNombre, sRFC, iTerminal, sCD, sDireccion, idCiudad, sProExterno"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <Columns>
                            <asp:BoundField DataField="idCentroDeServicio" HeaderText="Id" Visible="False"/>
                            <asp:BoundField DataField="sNombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sRFC" HeaderText="RFC" />
                            <asp:BoundField DataField="iTerminal" HeaderText="Terminal" />
                            <asp:BoundField DataField="sCD" HeaderText="CD" />
                            <asp:BoundField DataField="sDireccion" HeaderText="Dirección" />
                            <asp:BoundField DataField="idCiudad" HeaderText="IdCiudad" Visible="False" />
                            <asp:BoundField DataField="idCiudad" HeaderText="Ciudad" />
                            <asp:BoundField DataField="sProExterno" HeaderText="ProExterno" />
                            <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
   <asp:HiddenField ID="hddIdCentroDeServicio" runat="server" Value="0" />
   <asp:HiddenField ID="hddTipoAccion" runat="server" Value="INSERT" />
</asp:Content>
