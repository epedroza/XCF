<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeManifiestos.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeManifiestos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
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
                        <td><asp:TextBox ID="txtProBuacar" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                        <!-- Contenido Tab Monitor de Manifiestos -->
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="trFilaItem">
                                <td colspan="8" class="tdCeldaHeader" >Manifiestos</td>
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
							    <td class="tdCeldaItem"><asp:DropDownList ID="cboIdClaveOrigen" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Destino</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:DropDownList ID="cboIdClaveDestino" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Fecha Salida</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtFechaSalida" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Fecha Arribo</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="txtFechaArribo" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;No Tractor</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtNoTractor" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Propio</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="txtPropio" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Operador</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:TextBox ID="txtClaveOperador" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
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
							    <td class="tdCeldaItem"><asp:TextBox ID="txtEstatus" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaItem">&nbsp;</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem">&nbsp;</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Origen Pro</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaLeyendaItemLarge">&nbsp;Destino Pro</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;Pro</td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaItem">
							    <td class="tdCeldaLeyendaItemLarge"><asp:DropDownList ID="cboOrigen" runat="server" CssClass="Textbox_General" Width="100px"></asp:DropDownList></td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaLeyendaItemLarge">
                                    <asp:DropDownList ID="cboDestino" runat="server" CssClass="Textbox_General" Width="100px"></asp:DropDownList>
                                </td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaLeyendaItemLarge">&nbsp;<asp:TextBox ID="txtIdPro" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                <td style="width:5px;"></td>
                                <td class="tdCeldaItem"><asp:Button ID="cmdAgregarPro" runat="server" Text="[+]" 
                                        CssClass="Button_General" width="50px" onclick="cmdAgregarPro_Click" /></td>
                                <td style="width:5px;"></td>
						    </tr>
                            <tr class="trFilaSeparaItem"><td colspan="8"></td></tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvApps_PageIndexChanging"
                                        OnRowDataBound="gvApps_RowDataBound" OnSelectedIndexChanged="gvApps_SelectedIndexChanged"
                                        OnSelectedIndexChanging="gvApps_SelectedIndexChanging" OnRowCommand="gvApps_RowCommand"
                                        UpdateAfterCallBack="True" Width="600px" Style="text-align: center" DataKeyNames="IdManifiesto,IdPro"
                                        PageSize="30" ShowHeaderWhenEmpty="True">
                                        <RowStyle CssClass="Grid_Row" />
                                        <EditRowStyle Wrap="True" />
                                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                        <Columns>
                                            <asp:BoundField DataField="IdManifiesto" HeaderText="IdManifiesto" 
                                                Visible="False" />
                                            <asp:BoundField DataField="IdPro" HeaderText="Pro"/>
                                            <asp:BoundField DataField="OrigenPro" HeaderText="Origen Pro">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DestinoPro" HeaderText="Destino Pro">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                                <ItemStyle HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NoCaja" HeaderText="No Caja" />
                                            <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdGuardar" 
                             runat="server" Text="Buscar" CssClass="Button_General" width="125px" 
                             onclick="cmdGuardar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" /></td>
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
