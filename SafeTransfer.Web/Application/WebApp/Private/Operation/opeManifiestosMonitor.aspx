<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeManifiestosMonitor.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeManifiestosMonitor" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Tracking Manifiestos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                
                        <!-- Contenido Tab Monitor de Manifiestos -->
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="trFilaItem">
                                <td colspan="8" class="tdCeldaHeader" >Tracking Manifiestos</td>
                            </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Manifiesto</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtIdManifiesto" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Origen</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:DropDownList ID="cboOrigen" runat="server" CssClass="Textbox_General" width="155px" ></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Destino</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:DropDownList ID="cboDestino" runat="server" CssClass="Textbox_General" width="155px" ></asp:DropDownList></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Fecha Salida</td>
							    <td style="width:5px;"></td>
							    <td  class="tdCeldaItem">
                                    <wuc:wucCalendar ID="wucFechaInicial" runat="server" />
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Fecha Arribo</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">
                                    <wuc:wucCalendar ID="WucFechaFinal" runat="server" />
                                </td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;No Tractor</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtNoTractor" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Propio</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="TextBox8" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Operador</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtPropio" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;No Caja 1</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtNoCaja1" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;No Caja 2</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="txtNoCaja2" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Estatus</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem">
                                    <asp:DropDownList ID="cboEstatus" runat="server" CssClass="Textbox_General" 
                                        Width="155px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaItem">&nbsp;</td> 
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:Button ID="cmdBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="110px" onclick="cmdBuscar_Click" />
                                    &nbsp;<asp:Button ID="cmdNuevo" runat="server" CssClass="Button_General" 
                                        OnClick="cmdNuevo_Click" Text="Nuevo" Width="110px" />
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
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
                                            <asp:BoundField DataField="IdManifiesto" HeaderText="Manifiesto"/>
                                            <asp:BoundField DataField="ClaveOrigen" HeaderText="Origen">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaveDestino" HeaderText="Destino">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NoTractor" HeaderText="NoTractor">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TractorPropio" HeaderText="Tractor Propio">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaSalida" HeaderText="fecha Salida">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fechaLlegada" HeaderText="fecha Llegada">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                                <ItemStyle HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:ButtonField CommandName="EDITA" HeaderText="Detalle" Text="Detalle" />
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
