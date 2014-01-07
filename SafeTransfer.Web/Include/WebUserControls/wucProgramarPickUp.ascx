<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucProgramarPickUp.ascx.cs" Inherits="SafeTransfer.Web.Include.WebUserControls.wucProgramarPickUp" %>

<%@ Register src="/Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
    <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:150px;" Height="305px" Width="600px">
        <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
			    <tr>
                    <td style="width:10px"></td>
				    <td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Programar pickup"></asp:Label></td>
                    <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
					<td style="width:10px"></td>
				</tr>
			</table>
        </asp:Panel>
        <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
            <div style="margin:0 auto; width:98%;">
                <table class="GeneralTable">
                    <tr>
                        <td class="Nombre">Número de PickUp</td>
					    <td class="Espacio"></td>
					    <td class="Control"><asp:TextBox CssClass="Textbox_General" ID="PickUpBox" ReadOnly="true" runat="server" width="100px"></asp:TextBox></td>
				    </tr>
				    <tr>
                        <td class="Nombre">Cliente</td>
					    <td class="Espacio"></td>
					    <td class="Control"><asp:TextBox CssClass="Textbox_General" ID="ClienteBox" ReadOnly="true" runat="server" width="200px"></asp:TextBox></td>
				    </tr>
				    <tr>
                        <td class="Nombre">Fecha de recolección</td>
					    <td class="Espacio"></td>
					    <td class="Control"><wuc:wucCalendar ID="wucCalendar" runat="server" /></td>
				    </tr>
				    <tr>
                        <td class="Nombre">Lugar de recolección</td>
					    <td class="Espacio"></td>
					    <td class="Control"><asp:TextBox CssClass="Textbox_General" ID="LugarBox" runat="server" width="200px"></asp:TextBox></td>
				    </tr>
                    <tr>
                        <td class="Nombre">Transporte propio</td>
					    <td class="Espacio"></td>
					    <td class="Control">
                            <asp:RadioButtonList ID="TransporteRadio" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">
                                <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Nombre">Proveedor</td>
					    <td class="Espacio"></td>
					    <td class="Control"><asp:TextBox CssClass="Textbox_General" ID="ProveedorBox" runat="server" width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="Boton" colspan="3">
                            <br />
                            <asp:Button CssClass="Button_General" ID="GuardarButton" runat="server" Text="Guardar" Width="110px" onclick="GuardarButton_Click" />&nbsp;&nbsp;
                            <asp:Button CssClass="Button_General" ID="CancelarButton" runat="server" Text="Cancelar" Width="110px" onclick="CancelarButton_Click" />

                            <br />
                            <asp:Label CssClass="ErrorText" ID="MessageLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Panel>
