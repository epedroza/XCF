<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRecepcionManifiestos.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeRecepcionManifiestos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Recepcion de Manifiestos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                
                        <!-- Contenido Tab Monitor de Manifiestos -->
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="trFilaItem">
                                <td colspan="8" class="tdCeldaHeader" ></td>
                            </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge2">&nbsp;Manifiesto</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtIdManifiesto" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaItem">&nbsp;</td> 
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem" colspan="3"><asp:Button ID="cmdBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="110px" onclick="cmdBuscar_Click" />
                                    &nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvApps_PageIndexChanging"
                                        OnRowDataBound="gvApps_RowDataBound" OnSelectedIndexChanged="gvApps_SelectedIndexChanged"
                                        OnSelectedIndexChanging="gvApps_SelectedIndexChanging" OnRowCommand="gvApps_RowCommand"
                                        UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="IdManifiesto"
                                        PageSize="30" ShowHeaderWhenEmpty="True">
                                        <RowStyle CssClass="Grid_Row" />
                                        <EditRowStyle Wrap="True" />
                                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                        <Columns>
                                            <asp:BoundField DataField="IdPro" HeaderText="Pro"/>
                                            <asp:BoundField DataField="ClaveOrigen" HeaderText="Origen">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaveDestino" HeaderText="Destino">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
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
