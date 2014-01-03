<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="rptPros.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Report.rptPros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   <script type="text/javascript">

      function FillClient(idCliente, idCliente_Display) {
         var txtCliente = document.getElementById(idCliente);
         var txtCliente_Display = document.getElementById(idCliente_Display);


         if (txtCliente.value == '') {

            txtCliente_Display.value = '';
         }else{

            txtCliente_Display.value = 'ELECTROLUX S.A DE C.V.';
         }
      }

      function FocusPro(idCliente_Display) {
         var txtCliente = document.getElementById(idCliente_Display);
         txtCliente.focus();
      }

   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Consolidación de PRO
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Consolidarlos en el Pro</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtPro" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Del Cliente</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtCliente" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr><td colspan="3"><asp:TextBox ID="txtCliente_Display" runat="server" CssClass="Textbox_General" ReadOnly="true" style="background-color:#ECECEC; text-align:center; font-weight:bold;" width="100%" ></asp:TextBox></td></tr>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar"   runat="server" Text="Buscar PRO"    CssClass="Button_General" width="125px" onclick="btnBuscar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnDelete"   runat="server" Text="Eliminar PRO"  CssClass="Button_General" width="125px" onclick="btnDelete_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnCancelar" runat="server" Text="Cancelar"      CssClass="Button_General" width="125px" onclick="btnCancelar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnSave"     runat="server" Text="Guardar"       CssClass="Button_General" width="125px" onclick="btnSave_Click" /></td>
							<td style="height:24px; width:270px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvPro" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
                           <td style="width:110px;">Seleccionar</td>
									<td style="width:150px;">Pro</td>
                           <td style="width:100px;">Descuento</td>
                           <td style="width:430px;">Descripción</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="4">Ingrese los datos del PRO maestro</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
                     <asp:TemplateField	HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="110px">
							   <ItemTemplate>
                           <asp:CheckBox ID="chkActionIncluir" AutoPostBack="true" runat="server" ToolTip = "Incluir en la consolidación" />
							   </ItemTemplate>
						   </asp:TemplateField>
							<asp:BoundField HeaderText="Pro"          ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="150px" DataField="sPro"           SortExpression="sPro"></asp:BoundField>
							<asp:BoundField HeaderText="Descuento"    ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="dDiscount"      SortExpression="dDiscount"></asp:BoundField>
                     <asp:BoundField HeaderText="Descripción"  ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="430px" DataField="sDescripcion"   SortExpression="sDescripcion"></asp:BoundField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
</asp:Content>
