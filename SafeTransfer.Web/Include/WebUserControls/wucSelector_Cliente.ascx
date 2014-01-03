<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucSelector_Cliente.ascx.cs" Inherits="SafeTransfer.Web.Include.WebUserControls.wucSelector_Cliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div style="background-color:#D5E9F3; border:1px solid #5E8291; left:0px; text-align:center; top:0px;  width:214px;">
   <table cellpadding="0" cellspacing="0" border="0">
      <tr>
         <td style="text-align:left; width:194px;"><asp:TextBox ID="txtCliente" CssClass="Textbox_Filtro" runat="server" Width="190px"></asp:TextBox></td>
         <td style="width:20px;"><asp:ImageButton ID="imgBusqueda" runat="server" ImageUrl="~/Include/Image/Buttons/Search.png" onclick="imgBusqueda_Click" /></td>
      </tr>
   </table>
</div>
<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" >
   <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:150px;" Height="305px" Width="600px">
      <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
         <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
				<tr>
               <td style="width:10px"></td>
					<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Filtro de Clientes"></asp:Label></td>
               <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
					<td style="width:10px"></td>
				</tr>
			</table>
      </asp:Panel>
      <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
         <div style="margin:0 auto; width:98%;">
            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
               <tr style="height:20px;"><td colspan="4"></td></tr>
					<tr class="trFilaItem">
                  <td style="width:100px;"></td>
						<td class="tdActionCeldaLeyendaItem">&nbsp;Compañía</td>
						<td style="width:5px;"></td>
						<td style="text-align:left;"><asp:DropDownList id="ddlCompany" runat="server" CssClass="DropDownList_General" width="310px" AutoPostBack="True" onselectedindexchanged="ddlCompany_SelectedIndexChanged" ></asp:DropDownList></td>
					</tr>
					<tr style="height:5px;"><td colspan="4"></td></tr>
               <tr class="trFilaItem">
                  <td></td>
						<td class="tdActionCeldaLeyendaItem">&nbsp;Nombre</td>
						<td></td>
						<td style="text-align:left;">
                     <asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" MaxLength="200" width="200px" ></asp:TextBox>&nbsp;
                     <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="92px" onclick="btnBuscar_Click" />
                  </td>
					</tr>
               <tr style="height:5px;"><td colspan="4"></td></tr>
               <tr style="height:155px;">
                  <td colspan="4">
                     <div style="border:1px solid #4B4878; height:170px; overflow-x:hidden; overflow-y:scroll; text-align:left; width:587px;">
				            <asp:GridView ID="gvCliente" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" Width="573px"
                           DataKeyNames="idSucursal, sCliente, sNombre"
                           OnRowCommand="gvCliente_RowCommand"
                           OnRowDataBound="gvCliente_RowDataBound"
						         OnSorting="gvCliente_Sorting">
                           <HeaderStyle CssClass="Grid_Header_Action" />
					            <RowStyle CssClass="Grid_Row_Action" />
                           <EmptyDataTemplate>
							         <table border="1px" cellpadding="0px" cellspacing="0px">
								         <tr class="Grid_Header_Action">
                                    <td style="text-align:center; width:150px;">Cliente</td>
                                    <td style="text-align:center; width:100px;">Sucursal</td>
									         <td style="text-align:center; width:323px;">Dirección</td>
								         </tr>
								         <tr class="Grid_Row">
									         <td colspan="3" style="text-align:center;">No se encontraron Clientes</td>
								         </tr>
							         </table>
						         </EmptyDataTemplate>
					            <Columns>
                              <asp:BoundField   HeaderText="Cliente"    HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px"	SortExpression="sCliente"           DataField="sCliente"></asp:BoundField>
                              <asp:BoundField   HeaderText="Sucursal"   HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px"	SortExpression="sNombre"            DataField="sNombre"></asp:BoundField>
						            <asp:BoundField   HeaderText="Dirección"  HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="303px"	SortExpression="sDireccionCompleta" DataField="sDireccionCompleta"></asp:BoundField>
                              <asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								         <ItemTemplate>
                                    <asp:ImageButton ID="imgSelectItem" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Seleccionar" ImageUrl="~/Include/Image/Buttons/SelectItem_Null.png" runat="server" />
                                 </ItemTemplate>
							         </asp:TemplateField>
					            </Columns>
				            </asp:GridView>
			            </div>
                  </td>
               </tr>
               <tr style="height:5px;"><td colspan="4"></td></tr>
               <tr>
                  <td colspan="4">
                     <asp:Label ID="lblMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                  </td>
               </tr>
				</table>
         </div>
      </asp:Panel>
   </asp:Panel>
   <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"></ajaxToolkit:DragPanelExtender>
</asp:Panel>
<asp:HiddenField ID="hddSort" runat="server" value="sNombre" />
<asp:HiddenField ID="hddSucursal" runat="server" value="0" />