<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="catCamiones.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Catalog.catCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Camiones
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr class="trFilaItem">
						<td class="tdCeldaLeyendaItem">&nbsp;Número Camión</td>
						<td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtIdCamion" runat="server" CssClass="Textbox_General" width="210px" Enabled="False" ></asp:TextBox></td>
					</tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                    <tr class="trFilaItem">
						<td class="tdCeldaLeyendaItem">&nbsp;Tipo de Camión</td>
						<td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:DropDownList ID="cboTipoCamion" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
					</tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                    <tr class="trFilaItem">
						<td class="tdCeldaLeyendaItem">&nbsp;Camión</td>
						<td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtCamion" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
					</tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                    <tr class="trFilaItem">
						<td class="tdCeldaLeyendaItem">&nbsp;Capacidad M3</td>
						<td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtCapacidadM3" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
					</tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                    <tr class="trFilaItem">
						<td class="tdCeldaLeyendaItem">&nbsp;Capacidad Kg</td>
						<td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtCapacidadKg" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
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
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <!-- GRID -->
               <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvApps_PageIndexChanging"
                        OnRowDataBound="gvApps_RowDataBound" OnSelectedIndexChanged="gvApps_SelectedIndexChanged"
                        OnSelectedIndexChanging="gvApps_SelectedIndexChanging" OnRowCommand="gvApps_RowCommand"
                        UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="IdCamion,IdTipoCamion,TipoCamion,Camion,CapacidadM3,CapacidadKg"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <Columns>
                            <asp:BoundField DataField="IdCamion" HeaderText="IdCamion" Visible="False"/>
                            <asp:BoundField DataField="IdCompania" HeaderText="Compañía"/>
                            <asp:BoundField DataField="IdTipoCamion" HeaderText="IdTipoCamion" 
                                Visible="False"/>
                            <asp:BoundField DataField="TipoCamion" HeaderText="Tipo Camion">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="camion" HeaderText="Descripción"/>
                            <asp:BoundField DataField="CapacidadM3" HeaderText="Capacidad M3"/>
                            <asp:BoundField DataField="CapacidadKg" HeaderText="Capacidad KG"/>
                            <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
   <asp:HiddenField ID="hddIdCamion" runat="server" Value="0" />
   <asp:HiddenField ID="hddTipoAccion" runat="server" Value="INSERT" />
</asp:Content>
