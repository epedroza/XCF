<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeProsMonitor.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeProsMonitor" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Tracking de Pros
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                        <!-- Contenido Tab Monitor de Manifiestos -->
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="trFilaItem">
                                <td colspan="8" class="tdCeldaHeader" >Tracking de Pros</td>
                            </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">Pro</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtIdPro" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;PickUp</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtIdPickUp" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Origen</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:DropDownList ID="cboOrigen" runat="server" CssClass="Textbox_General" Width="155px"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Destino</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:DropDownList ID="cboDestino" runat="server" CssClass="Textbox_General" Width="155px"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Cliente</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:DropDownList ID="cboClientes" runat="server" CssClass="Textbox_General" Width="155px"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">Rango de Fechas</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><wuc:wucCalendar ID="wucFechaInicial" runat="server" /><wuc:wucCalendar ID="WucFechaFinal" runat="server" />
                                    <asp:CheckBox ID="chkFechas" runat="server" CssClass="Textbox_General" 
                                        Text="Usar Fechas" />
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
						    </tr>
                            <caption>
                                <tr>
                                    <td class="tdCeldaLeyendaItemLarge">
                                        &nbsp;Pedimento</td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaItem">
                                        <asp:TextBox ID="txtPedimento" runat="server" CssClass="Textbox_General" 
                                            Width="100px"></asp:TextBox>
                                    </td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaLeyendaItemLarge">
                                        &nbsp;</td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaItem">
                                    </td>
                                    <td style="width:5px;">
                                    </td>
                                </tr>
                                <tr class="trFilaItem">
							        <td class="tdCeldaLeyendaItemLarge">&nbsp;Estatus</td>
							        <td style="width:5px;"></td>
							        <td class="tdCeldaItem"><asp:DropDownList ID="cboEstatus" runat="server" 
                                            CssClass="Textbox_General" Width="155px"></asp:DropDownList></td>
                                    <td style="width:5px;"></td>
                                    <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                    <td style="width:5px;"></td>
                                    <td class="tdCeldaItem">&nbsp;</td>
                                    <td style="width:5px;"></td>
						        </tr>
                                <tr class="trFilaItem">
                                    <td class="tdCeldaItem">
                                        &nbsp;</td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaItem">
                                        <asp:Button ID="cmdBuscar" runat="server" CssClass="Button_General" 
                                            onclick="cmdBuscar_Click" Text="Buscar" Width="110px" />
                                        &nbsp;<asp:Button ID="cmdNuevo" runat="server" CssClass="Button_General" 
                                            OnClick="cmdNuevo_Click" Text="Nuevo" Width="110px" />
                                    </td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaItem">
                                        &nbsp;</td>
                                    <td style="width:5px;">
                                    </td>
                                    <td class="tdCeldaItem">
                                    </td>
                                    <td style="width:5px;">
                                    </td>
                                </tr>
                                <tr class="trFilaSeparaItem">
                                    <td colspan="8">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False" 
                                            AutoUpdateAfterCallBack="True" DataKeyNames="IdPro" 
                                            OnPageIndexChanging="gvApps_PageIndexChanging" OnRowCommand="gvApps_RowCommand" 
                                            OnRowDataBound="gvApps_RowDataBound" 
                                            OnSelectedIndexChanged="gvApps_SelectedIndexChanged" 
                                            OnSelectedIndexChanging="gvApps_SelectedIndexChanging" PageSize="30" 
                                            ShowHeaderWhenEmpty="True" Style="text-align: center" 
                                            UpdateAfterCallBack="True" Width="800px">
                                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                            <Columns>
                                                <asp:BoundField DataField="IdPro" HeaderText="Pro" />
                                                <asp:BoundField DataField="IdClaveOrigen" HeaderText="IdOrigen Pro" 
                                                    Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IdClaveDestino" HeaderText="IdDestino Pro" 
                                                    Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Origen" HeaderText="Origen Pro" />
                                                <asp:BoundField DataField="Destino" HeaderText="Destino Pro" />
                                                <asp:BoundField DataField="Pedimento" HeaderText="Pedimento">
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IdEstatus" HeaderText="IdEstatus" Visible="False" />
                                                <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:ButtonField CommandName="EDITA" HeaderText="Detalle" Text="Detalle" />
                                            </Columns>
                                            <EditRowStyle Wrap="True" />
                                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                            <RowStyle CssClass="Grid_Row" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr class="trFilaSeparaItem">
                                    <td colspan="8">
                                    </td>
                                </tr>
                            </caption>
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
                     <td style="height:24px; text-align:left; width:130px;">&nbsp;</td>
                     <td style="height:24px; text-align:left; width:130px;">&nbsp;</td>
							<td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <!-- GRID -->
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
