<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="catClientes.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Catalog.catClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Clientes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Compañía</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlCompany" runat="server" CssClass="DropDownList_General" width="216px" AutoPostBack="True" ></asp:DropDownList></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Estatus</td>
							<td></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlStatus" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"></td>
							<td style="height:24px; width:400px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvCliente" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="idCliente, tiActivo, sNombre"
						OnRowDataBound="gvCliente_RowDataBound"
						OnRowCommand="gvCliente_RowCommand"
						OnSorting="gvCliente_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:100px;">Compañía</td>
									<td style="width:250px;">Cliente</td>
                           <td style="width:100px;">Tipo de Cliente</td>
                           <td style="width:240px;">Descripción</td>
                           <td style="width:100px;">Estatus</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron Clientes registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Compañía"        ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="sCompany"       SortExpression="sCompany"></asp:BoundField>
                     <asp:BoundField HeaderText="Cliente"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="250px" DataField="sNombre"        SortExpression="sNombre"></asp:BoundField>
                     <asp:BoundField HeaderText="Tipo de Cliente" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sTipoCliente"   SortExpression="sTipoCliente"></asp:BoundField>
							<asp:BoundField HeaderText="Descripción"     ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="200px" DataField="sDescripcion"	SortExpression="sDescripcion"></asp:BoundField>
                     <asp:BoundField HeaderText="Estatus"         ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sEstatus"       SortExpression="sEstatus"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                           <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                        </ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                           <asp:ImageButton ID="imgAction" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Action" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" >
               <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:20px;" Height="570px" Width="400px">
                  <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                     <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
								<tr>
                           <td style="width:10px"></td>
									<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
                           <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
								   <td style="width:10px"></td>
								</tr>
							</table>
                  </asp:Panel>
                  <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                     <div style="margin:0 auto; width:98%;">
                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                           <tr style="height:20px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Compañía</td>
									   <td style="width:5px;"></td>
									   <td><asp:DropDownList id="ddlActionCompany" runat="server" CssClass="DropDownList_General" width="266px" ></asp:DropDownList></td>
								   </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
                              <td class="tdActionCeldaLeyendaItem_High">&nbsp;Tipo de Cliente</td>
                              <td style="width:5px;"></td>
                              <td><asp:DropDownList id="ddlActionTipoCliente" runat="server" CssClass="DropDownList_General" width="266px" ></asp:DropDownList></td>
                           </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;% Impuestos</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionPorcientoImpuestos" runat="server" CssClass="Textbox_General" MaxLength="6" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionImpuestos" runat="server" TargetControlID="txtActionPorcientoImpuestos" Mask="999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;% Retención</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionPorcientoRetencion" runat="server" CssClass="Textbox_General" MaxLength="6" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionRetencion" runat="server" TargetControlID="txtActionPorcientoRetencion" Mask="999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Clave GTE</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionClaveGTEDes" runat="server" CssClass="Textbox_General" MaxLength="10" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionClaveGTEDes" runat="server" TargetControlID="txtActionClaveGTEDes" Mask="9999999999" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Clave Vendedor</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionClaveVendedorOriginal" runat="server" CssClass="Textbox_General" MaxLength="10" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionClaveVendedorOriginal" runat="server" TargetControlID="txtActionClaveVendedorOriginal" Mask="9999999999" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Días de Crédito</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionDiasCredito" runat="server" CssClass="Textbox_General" MaxLength="10" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionDiasCredito" runat="server" TargetControlID="txtActionDiasCredito" Mask="9999999999" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Preferencial</td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionPreferencial" runat="server" CssClass="Textbox_General" MaxLength="10" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionPreferencial" runat="server" TargetControlID="txtActionPreferencial" Mask="9999999999" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Terminal </td>
									   <td style="width:5px;"></td>
									   <td>
                                 <asp:TextBox ID="txtActionTerminal" runat="server" CssClass="Textbox_General" MaxLength="10" width="260px" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="maskActionTerminal" runat="server" TargetControlID="txtActionTerminal" Mask="9999999999" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                              </td>
								   </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Nombre</td>
									   <td style="width:5px;"></td>
									   <td><asp:TextBox ID="txtActionNombre" runat="server" CssClass="Textbox_General" MaxLength="100" width="260px" ></asp:TextBox></td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Fax</td>
									   <td style="width:5px;"></td>
									   <td><asp:TextBox ID="txtActionFax" runat="server" CssClass="Textbox_General" MaxLength="50" width="260px" ></asp:TextBox></td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Método Pago</td>
									   <td style="width:5px;"></td>
									   <td><asp:TextBox ID="txtActionMetodoPago" runat="server" CssClass="Textbox_General" MaxLength="100" width="260px" ></asp:TextBox></td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Descripción</td>
									   <td></td>
									   <td><asp:TextBox ID="txtActionDescripcion" runat="server" CssClass="Textarea_General" height="50px" MaxLength="200" TextMode="MultiLine" width="260px" ></asp:TextBox></td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
									   <td class="tdActionCeldaLeyendaItem_High">&nbsp;Tarifa</td>
									   <td style="width:5px;"></td>
									   <td><asp:TextBox ID="txtActionTarifa" runat="server" CssClass="Textbox_General" MaxLength="100" width="260px" ></asp:TextBox></td>
								   </tr>
								   <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
							         <td class="tdActionCeldaLeyendaItem_High">&nbsp;Estatus</td>
							         <td></td>
							         <td><asp:DropDownList id="ddlActionStatus" runat="server" CssClass="DropDownList_General" width="266px" ></asp:DropDownList></td>
						         </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr>
                              <td colspan="3" style="text-align:right;">
                                 <asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" width="150px" onclick="btnAction_Click" />
                              </td>
                           </tr>
                           <tr>
                              <td colspan="3">
                                 <asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                              </td>
                           </tr>
							   </table>
                     </div>
                  </asp:Panel>
               </asp:Panel>
               <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddCliente" runat="server" value="" />
   <asp:HiddenField ID="hddSort" runat="server" value="sNombre" />
</asp:Content>
