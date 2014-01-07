<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opePickUpMonitor.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opePickUpMonitor" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register src="/Include/WebUserControls/wucProgramarPickUp.ascx" tagname="ProgramarPickUp" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <link href="/Include/Style/Tabla.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				PickUps
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <!-- Contenido Tab Monitor de Manifiestos -->
                <table class="GeneralTable">
                    <tr>
						<td class="Nombre">PickUp</td>
						<td><asp:TextBox ID="txtIdPickUp" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
					</tr>
                    <tr>
						<td class="Nombre">Cliente</td>
						<td><asp:DropDownList ID="cboCliente" runat="server" CssClass="Textbox_General" Width="180px"></asp:DropDownList></td>
					</tr>
                    <tr>
						<td class="Nombre">Fecha estimada</td>
						<td><wuc:wucCalendar ID="wucCalendarInicio" runat="server" /></td>
					</tr>
                    <tr>
						<td class="Nombre">Fecha recolección</td>
						<td><wuc:wucCalendar ID="wucCalendarFinal" runat="server" /></td>
					</tr>
                    <tr>
                        <td class="Nombre">Estatus</td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" CssClass="Textbox_General" Width="180px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Nombre">&nbsp;</td>
                        <td>
                            <asp:Button ID="cmdBuscar" runat="server" CssClass="Button_General" onclick="cmdBuscar_Click" Text="Buscar" Width="110px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False" 
                                AutoUpdateAfterCallBack="True" DataKeyNames="idPickUp, idEstatusPickUp" 
                                OnPageIndexChanging="gvApps_PageIndexChanging" OnRowCommand="gvApps_RowCommand" 
                                OnRowDataBound="gvApps_RowDataBound" 
                                OnSelectedIndexChanged="gvApps_SelectedIndexChanged" 
                                OnSelectedIndexChanging="gvApps_SelectedIndexChanging" PageSize="30" 
                                ShowHeaderWhenEmpty="True" Style="text-align: center" 
                                UpdateAfterCallBack="True" Width="800px">
                                <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                <Columns>
                                    <asp:BoundField DataField="idPickUp" HeaderText="PickUp" />
                                    <asp:BoundField DataField="sCliente" HeaderText="Cliente" Visible="False" />
                                    <asp:BoundField DataField="dtPickUp" HeaderText="Fecha Estimada" />
                                    <asp:BoundField DataField="sNombreEstatus" HeaderText="Estatus" />
                                    <asp:TemplateField HeaderText="Programar">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandArgument='<%#Container.DataItemIndex%>' CommandName="Select" ID="ProgramarLink" runat="server" Text='Programar'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle Wrap="True" />
                                <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                <RowStyle CssClass="Grid_Row" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
         </td>
      </tr>
   </table>

    <asp:Panel id="pnlGrid" runat="server" Width="100%">
        <!-- GRID -->
        <wuc:ProgramarPickUp ID="ProgramarPickUp" runat="server"  />
    </asp:Panel>

</asp:Content>
