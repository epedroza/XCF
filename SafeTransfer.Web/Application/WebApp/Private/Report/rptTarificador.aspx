<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="rptTarificador.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Report.rptTarificador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Tarificador
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Origen</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlOrigen" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Destino</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlDestino" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Peso</td>
							<td></td>
							<td class="tdCeldaItem">
                        <asp:TextBox ID="txtPeso" runat="server" CssClass="Textbox_General" width="85px" ></asp:TextBox>&nbsp;
                        <asp:DropDownList id="ddlMedidaPeso" runat="server" CssClass="DropDownList_General" width="116px" ></asp:DropDownList>
                     </td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Volumen</td>
							<td></td>
							<td class="tdCeldaItem">
                        <asp:TextBox ID="txtVolumen" runat="server" CssClass="Textbox_General" width="85px" ></asp:TextBox>&nbsp;
                        <asp:DropDownList id="ddlMedidaVolumen" runat="server" CssClass="DropDownList_General" width="116px" ></asp:DropDownList>
                     </td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Descuento Cliente</td>
							<td></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtDescuento" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Cargos Extra</td>
							<td></td>
							<td class="tdCeldaItem">
                        <asp:CheckBoxList ID="chklistCargos" runat="server" RepeatDirection="Horizontal" CssClass="CheckBox_Regular">
                           <asp:ListItem Value="1">Material Peligroso</asp:ListItem>
									<asp:ListItem Value="2">Prime Time</asp:ListItem>
                        </asp:CheckBoxList>
                     </td>
						</tr>
					</table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
               <tr class="trFilaItem"><td colspan="3" style="text-align:center; background-color: #549CC6; border:0px solid #4B4878; color:White; font-family: Arial, Sans-Serif; font-size:12px; font-weight:bold;">Ruta Prinicpal</td></tr>
            </table>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvRuta" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
                           <td style="width:490px;">Descripción</td>
									<td style="width:150px;">México</td>
                           <td style="width:150px;">USA</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="4">Ingrese los datos del PRO maestro</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Descripción"  ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sDescripcion"   SortExpression="sDescripcion"></asp:BoundField>
							<asp:BoundField HeaderText="México"       ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sMexico"        SortExpression="sMexico"></asp:BoundField>
                     <asp:BoundField HeaderText="USA"          ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="430px" DataField="sUSA"           SortExpression="sUSA"></asp:BoundField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
</asp:Content>
