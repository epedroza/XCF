<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCotizador.ascx.cs" Inherits="SafeTransfer.Web.Include.WebUserControls.wucCotizador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div style="background-color:#D5E9F3; border:1px solid #5E8291; left:0px; text-align:center; top:0px;  width:182px;">
   <table cellpadding="0" cellspacing="0" border="0">
      <tr>
         <td style="text-align:left; width:194px;"><asp:TextBox ID="txtCotizar" CssClass="Textbox_Filtro" runat="server" Enabled="false" Text="0.00 MXP" Width="158px"></asp:TextBox></td>
         <td style="width:20px;"><asp:ImageButton ID="imgCotizar" runat="server" ImageUrl="~/Include/Image/Buttons/Cotizar.png" ToolTip="Cotizar" onclick="imgCotizar_Click" /></td>
      </tr>
   </table>
</div>
<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" >
   <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:80px;" Height="520px" Width="580px">
      <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
         <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
				<tr>
               <td style="width:10px"></td>
					<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Cotizador"></asp:Label></td>
               <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
					<td style="width:10px"></td>
				</tr>
			</table>
      </asp:Panel>
      <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
         <div style="margin:0 auto; width:98%;">
            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
               <tr style="height:20px;"><td></td></tr>
               <tr>
                  <td>
                     <ajaxToolkit:TabContainer ID="tabCotizacion" runat="server" ActiveTabIndex="0">
                        <ajaxToolkit:TabPanel ID="tpnlRuta" runat="server">
                           <HeaderTemplate>Ruta</HeaderTemplate>
                           <ContentTemplate>
                              <div style="text-align:center; height:210px;">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr><td style="height:25px; text-align:left;">Origen</td></tr>
                                    <tr>
                                       <td>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                             <tr class="trFilaItem">
	                                             <td colspan="2">
                                                   <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                      <tr>
                                                         <td class="tdOPCeldaItem">Pais: *</td>
	                                                      <td style="width:150px;"><asp:DropDownList id="ddlPaisOrigen" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlPaisOrigen_SelectedIndexChanged" ></asp:DropDownList></td>
                                                         <td style="width:85px; color:#4B4878; font-size:11px; font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;Estado: *</td>
	                                                      <td><asp:DropDownList id="ddlEstadoOrigen" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlEstadoOrigen_SelectedIndexChanged" ></asp:DropDownList></td>
                                                       </tr>
                                                   </table>
                                                </td>
                                             </tr>
                                             <tr><td colspan="2" style="height:10px;"></td></tr>
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Ciudad: *</td>
                                                <td style="text-align:left;"><asp:DropDownList id="ddlCiudadOrigen" runat="server" CssClass="DropDownList_General" width="423px" ></asp:DropDownList></td>
                                             </tr>
                                             <tr><td colspan="2" style="height:10px;"></td></tr>
                                          </table>
                                       </td>
                                    </tr>
                                    <tr style="height:10px;"><td></td></tr>
                                    <tr><td style="height:25px; text-align:left;">Destino</td></tr>
                                    <tr>
                                       <td>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                             <tr class="trFilaItem">
	                                             <td colspan="2">
                                                   <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                      <tr>
                                                         <td class="tdOPCeldaItem">Pais: *</td>
	                                                      <td style="width:150px;"><asp:DropDownList id="ddlPaisDestino" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlPaisDestino_SelectedIndexChanged" ></asp:DropDownList></td>
                                                         <td style="width:85px; color:#4B4878; font-size:11px; font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;Estado: *</td>
	                                                      <td><asp:DropDownList id="ddlEstadoDestino" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlEstadoDestino_SelectedIndexChanged" ></asp:DropDownList></td>
                                                       </tr>
                                                   </table>
                                                </td>
                                             </tr>
                                             <tr><td colspan="2" style="height:10px;"></td></tr>
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Ciudad: *</td>
                                                <td style="text-align:left;"><asp:DropDownList id="ddlCiudadDestino" runat="server" CssClass="DropDownList_General" width="423px" ></asp:DropDownList></td>
                                             </tr>
                                          </table>
                                       </td>
                                    </tr>
                                 </table>
                              </div>
                           </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="tpnlServicios" runat="server">
                           <HeaderTemplate>Servicios</HeaderTemplate>
                           <ContentTemplate>
                              <div style="text-align:center; height:210px;">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr><td style="height:25px; text-align:left;">Solicitados</td></tr>
                                    <tr>
                                       <td>
                                          <asp:CheckBoxList ID="chkServicio" runat="server" CssClass="CheckBox_Regular" RepeatDirection="Horizontal"  RepeatColumns="4" CellSpacing="25" Style="text-align:left;"></asp:CheckBoxList>
                                       </td>
                                    </tr>
                                 </table>
                              </div>
                           </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="tpnlMedidas" runat="server">
                           <HeaderTemplate>Medidas</HeaderTemplate>
                           <ContentTemplate>
                              <div style="text-align:center; height:210px;">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr><td style="height:25px; text-align:left;">Peso</td></tr>
                                    <tr>
                                       <td>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Carga:</td>
                                                <td style="text-align:left;">
                                                   <asp:TextBox ID="txtCarga_Peso" runat="server" CssClass="Textbox_General" MaxLength="12" width="60px" ></asp:TextBox>&nbsp;&nbsp;
                                                   <asp:DropDownList id="ddlCarga_UnidadMedidaPeso" runat="server" CssClass="DropDownList_General" Width="100px"></asp:DropDownList>
                                                   <ajaxToolkit:MaskedEditExtender ID="maskCotizador_Peso" runat="server" TargetControlID="txtCarga_Peso" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                                                </td>
                                             </tr>
                                          </table>
                                       </td>
                                    </tr>
                                    <tr style="height:20px;"><td></td></tr>
                                    <tr><td style="height:25px; text-align:left;">Volumen</td></tr>
                                    <tr>
                                       <td>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Cubicaje:</td>
                                                <td style="text-align:left;">
                                                   <asp:TextBox ID="txtCarga_Volumen" runat="server" CssClass="Textbox_General" MaxLength="12" width="60px" ></asp:TextBox>&nbsp;&nbsp;
                                                   <asp:DropDownList id="ddlCarga_UnidadMedidaVolumen"  runat="server" CssClass="DropDownList_General" Width="100px"></asp:DropDownList>
                                                   <ajaxToolkit:MaskedEditExtender ID="maskCotizador_Volumen" runat="server" TargetControlID="txtCarga_Volumen" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                                                </td>
                                             </tr>
                                          </table>
                                       </td>
                                    </tr>
                                 </table>
                              </div>
                           </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="tpnlVarios" runat="server">
                           <HeaderTemplate>Varios</HeaderTemplate>
                           <ContentTemplate>
                              <div style="text-align:center; height:210px;">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr><td style="height:25px; text-align:left;">Varios</td></tr>
                                    <tr>
                                       <td>
                                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Moneda:</td>
                                                <td style="text-align:left;">
                                                   <asp:DropDownList id="ddlMoneda" runat="server" CssClass="DropDownList_General" width="100px" ></asp:DropDownList>
                                                </td>
                                             </tr>
                                             <tr style="height:10px;"><td colspan="2"></td></tr>
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Descuento:</td>
                                                <td style="text-align:left;">
                                                   <asp:TextBox ID="txtDescuentoCliente" runat="server" CssClass="Textbox_General" MaxLength="12" width="96px" ></asp:TextBox>
                                                   <ajaxToolkit:MaskedEditExtender ID="maskCotizador_Descuento" runat="server" TargetControlID="txtDescuentoCliente" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="Left" ErrorTooltipEnabled="False"/>
                                                </td>
                                             </tr>
                                             <tr style="height:10px;"><td colspan="2"></td></tr>
                                             <tr class="trFilaItem">
                                                <td class="tdOPCeldaItem">Cargo Extra:</td>
                                                <td style="text-align:left;">
                                                   <asp:TextBox ID="txtCargoExtra" runat="server" CssClass="Textbox_General" MaxLength="12" width="96px" ></asp:TextBox>
                                                   <ajaxToolkit:MaskedEditExtender ID="maskCotizador_Extra" runat="server" TargetControlID="txtCargoExtra" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="Left" ErrorTooltipEnabled="False"/>
                                                </td>
                                             </tr>
                                          </table>
                                       </td>
                                    </tr>
                                 </table>
                              </div>
                           </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                     </ajaxToolkit:TabContainer>
                  </td>
               </tr>
               <tr style="height:10px;"><td></td></tr>
               <tr><td><asp:Label ID="lblMessage" runat="server" CssClass="ActionContentMessage"></asp:Label></td></tr>
               <tr style="height:10px;"><td></td></tr>
               <tr>
                  <td style="height:24px; text-align:left;">
                     <asp:Button ID="btnTarificar" runat="server" Text="Tarificar" CssClass="Button_General" ToolTip="Calcula la cotización en base a la información capturada" Visible="false" width="125px" onclick="btnTarificar_Click" />&nbsp;&nbsp;
                     <asp:Button ID="btnRecalcular" runat="server" Text="Recalcular" CssClass="Button_General" ToolTip="Recalcula los servicios y medidas en base al PickUp seleccionado" Visible="false" width="125px" onclick="btnRecalcular_Click" />
                  </td>
               </tr>
               <tr style="height:10px;"><td></td></tr>
               <tr>
                  <td>
                     <asp:GridView ID="gvCotizacion" runat="server" AllowSorting="False" AutoGenerateColumns="True" BorderWidth="0px" ShowFooter="true" Width="100%"
                        OnRowDataBound="gvCotizacion_RowDataBound">
                        <HeaderStyle CssClass="Grid_Header_Action" />
					         <RowStyle CssClass="Grid_Row_Action" />
                        <footerStyle CssClass="Grid_Footer_Action" />
				         </asp:GridView>
                  </td>
               </tr>
               <tr style="height:10px;"><td></td></tr>
               <tr><td style="height:24px; text-align:right;"><asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="Button_General" width="125px" onclick="btnCrear_Click" /></td></tr>
            </table>
         </div>
      </asp:Panel>
   </asp:Panel>
   <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"></ajaxToolkit:DragPanelExtender>
</asp:Panel>
<asp:HiddenField ID="hddEnable" runat="server" value="false" />
<asp:HiddenField ID="hddInsert" runat="server" value="-1" />
<asp:HiddenField ID="hddPickUp" runat="server" value="0" />