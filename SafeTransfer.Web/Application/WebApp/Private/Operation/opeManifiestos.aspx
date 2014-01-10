<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeManifiestos.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeManifiestos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Manifiestos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr class="trFilaItem">
            <td colspan="15">
                <table>
                    <tr>
                        <td><asp:ImageButton ID="cmdBuscarBarra" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarSearch.png" onclick="cmdBuscarBarra_Click" /></td>
                        <td><asp:ImageButton ID="cmdNextBarra" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarNext.png" /></td>
                        <td><asp:ImageButton ID="cmdPrevBarra" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarBack.png" /></td>
                        <td><asp:ImageButton ID="cmdNewBarra" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarNew.png" /></td>
                        <td><asp:ImageButton ID="cmdSaveBarra" runat="server" ImageUrl="~/Include/Image/Buttons/ToolbarRelease.png" /></td>
                        <td><asp:TextBox ID="txtProBuacar" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                        <!-- Contenido Manifiestos -->
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="trFilaItem">
                                <td colspan="8" class="tdCeldaHeader" ></td>
                            </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Manifiesto</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall"><asp:TextBox ID="txtIdManifiesto" runat="server" CssClass="Textbox_General_16" width="50px" Enabled="False" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td>&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Origen</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall"><asp:DropDownList ID="cboIdClaveOrigen" runat="server" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="cboIdClaveOrigen_SelectedIndexChanged"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Destino</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall"><asp:DropDownList ID="cboIdClaveDestino" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Fecha Salida</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall">
                                    <wuc:wucCalendar ID="txtFechaSalida" runat="server" />
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Fecha Arribo</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall">
                                    <wuc:wucCalendar ID="txtFechaArribo" runat="server" />
                                </td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;No Tractor</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall"><asp:TextBox ID="txtNoTractor" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Propio</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall"><asp:TextBox ID="txtPropio" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Operador</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall"><asp:TextBox ID="txtClaveOperador" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;No Caja 1</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall"><asp:TextBox ID="txtNoCaja1" runat="server" 
                                        CssClass="Textbox_General_16" width="50px" 
                                        ontextchanged="txtNoCaja1_TextChanged" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;No Caja 2</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall"><asp:TextBox ID="txtNoCaja2" runat="server" CssClass="Textbox_General_16" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;Estatus</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItemSmall">
                                    <asp:DropDownList ID="cboEstatus" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width:5px;"></td>
                                <td>&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td></td>
							    <td style="width:5px;"></td>
							    <td>
                                    <asp:Button ID="cmdAgregarPartidas" runat="server" CssClass="Button_General" 
                                        onclick="cmdAgregarPartidas_Click" Text="AgregarPros" width="104px" />
                                </td>
                                <td style="width:5px;"></td>
                                <td>
                                    <asp:Button ID="cmdGuardarManifiestox" runat="server" CssClass="Button_General" 
                                        onclick="cmdGuardarManifiesto" Text="Guardar" width="104px" />
                                </td>
                                <td style="width:5px;"></td>
                                <td></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaLeyendaItemWhiteRight">
                                    &nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemWhiteRight">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItemSmall">
                                    <asp:HiddenField ID="hddTipoAccion" runat="server" />
                                </td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvApps_PageIndexChanging"
                                        OnRowDataBound="gvApps_RowDataBound" OnSelectedIndexChanged="gvApps_SelectedIndexChanged"
                                        OnSelectedIndexChanging="gvApps_SelectedIndexChanging" OnRowCommand="gvApps_RowCommand"
                                        UpdateAfterCallBack="True" Width="600px" Style="text-align: center" DataKeyNames="IdPro"
                                        PageSize="30" ShowHeaderWhenEmpty="True">
                                        <RowStyle CssClass="Grid_Row" />
                                        <EditRowStyle Wrap="True" />
                                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                        <Columns>
                                            <asp:BoundField DataField="OrigenPro" HeaderText="Origen Pro">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DestinoPro" HeaderText="Destino Pro">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IdPro" HeaderText="Pro">
                                            </asp:BoundField>
                                            <asp:ButtonField CommandName="ELIMINA" HeaderText="Eliminar" Text="Eliminar" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hddIdManifiesto" runat="server" />
                                </td>
                            </tr>
                            <tr class="trFilaSeparaItem">
                                <td colspan="8">
                                    <div id="inner" style="position:absolute;top:100px;left:100px;">
                                        <asp:Panel ID="pnlDetallePros" runat="server" Visible="false" BackColor="White" 
                                            BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                            <table>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    &nbsp;<asp:GridView ID="gvAppsSelPros" runat="server" AutoGenerateColumns="False" 
                                                            AutoUpdateAfterCallBack="True" DataKeyNames="IdPro,IdOrigenPro,IdDestinoPro" 
                                                            OnPageIndexChanging="gvAppsSelPros_PageIndexChanging" OnRowCommand="gvAppsSelPros_RowCommand" 
                                                            OnRowDataBound="gvAppsSelPros_RowDataBound" 
                                                            OnSelectedIndexChanged="gvAppsSelPros_SelectedIndexChanged" 
                                                            OnSelectedIndexChanging="gvAppsSelPros_SelectedIndexChanging" PageSize="30" 
                                                            ShowHeaderWhenEmpty="True" Style="text-align: center" 
                                                            UpdateAfterCallBack="True" Width="600px">
                                                            <RowStyle CssClass="Grid_Row" />
                                                            <EditRowStyle Wrap="True" />
                                                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Seleccionar">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkTodos" runat="server" 
                                                                            oncheckedchanged="chkTodos_CheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelecciona" runat="server" 
                                                                            oncheckedchanged="chkSelecciona_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="IdPro" HeaderText="Pro" />
                                                                <asp:BoundField DataField="IdOrigenPro" HeaderText="IdOrigenPro" 
                                                                    Visible="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IdDestinoPro"  HeaderText="IdDestinoPro" 
                                                                    Visible="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Origen" HeaderText="Origen" />
                                                                <asp:BoundField DataField="Destino" HeaderText="Destino" />
                                                                <asp:BoundField DataField="NoCaja" HeaderText="No Caja" Visible="False" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    <asp:Button ID="cmdCerrar" runat="server" Text="Cerrar" CssClass="Button_General" 
                                                            width="100px" onclick="cmdCerrar_Click" />
                                                        &nbsp;<asp:Button ID="cmdAceptar" runat="server" CssClass="Button_General" 
                                                            onclick="cmdAceptar_Click" Text="Aceptar" width="100px" />
                                                    </td>
                                                    </tr>
                                                </table>
                                         </asp:Panel>
                                     </div>
                                 </td>
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
