<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRecepcionManifiestos.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opeRecepcionManifiestos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <link href="/Include/Style/Tabla.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Recepción de manifiestos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table class="GeneralTable">
                    <tr>
						<td class="Nombre">Centro</td>
						<td><asp:DropDownList CssClass="DropDownList_General" id="CentroServicioList" runat="server" width="215px" ></asp:DropDownList></td>
					</tr>
                    <tr>
                        <td class="Nombre">Manifiesto</td>
					    <td class="Control"><asp:TextBox CssClass="Textbox_General" ID="ManifiestoBox" MaxLength="6" runat="server" width="100px"></asp:TextBox></td>
				    </tr>
                    <tr>
                        <td class="Nombre">&nbsp;</td>
                        <td>
                            <asp:Button CssClass="Button_General" ID="SearchButton" OnClick="SearchButton_Click" runat="server" Text="Buscar" Width="110px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            Descargar Pros
                            <br />
                            <asp:GridView ID="DownloadGrid" runat="server">
                                <EmptyDataTemplate>
                                    <table>
                                        <tr class="Grid_Header">
                                            <th style="width: 75px;"></th>
                                            <th style="width: 95px;">Pro</th>
                                            <th style="width: 195px;">Origen</th>
                                            <th style="width: 195px;">Destino</th>
                                        </tr>
                                        <tr>
                                            <td class="Grid_Row" colspan="4">&nbsp;</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox id="ProCheck" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Pro" HeaderText="Pro" />
                                    <asp:BoundField DataField="NombreOrigen" HeaderText="Origen" />
                                    <asp:BoundField DataField="NombreDestino" HeaderText="Pro" />
                                </Columns>
                                <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                <RowStyle CssClass="Grid_Row" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="BotonRight" colspan="2">
                            <asp:Button CssClass="Button_General" ID="DownloadButton" OnClick="DownloadButton_Click" runat="server" Text="Descargar Pros" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br /><br />
                            Cargar Pros
                            <br />
                            <asp:GridView ID="UploadGrid" runat="server">
                                <EmptyDataTemplate>
                                    <table>
                                        <tr class="Grid_Header">
                                            <th style="width: 75px;"></th>
                                            <th style="width: 95px;">Pro</th>
                                            <th style="width: 195px;">Origen</th>
                                            <th style="width: 195px;">Destino</th>
                                        </tr>
                                        <tr>
                                            <td class="Grid_Row" colspan="4">&nbsp;</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox id="ProCheck" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Pro" HeaderText="Pro" />
                                    <asp:BoundField DataField="NombreOrigen" HeaderText="Origen" />
                                    <asp:BoundField DataField="NombreDestino" HeaderText="Pro" />
                                </Columns>
                                <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                <RowStyle CssClass="Grid_Row" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="BotonRight" colspan="2">
                            <asp:Button CssClass="Button_General" ID="UploadButton" OnClick="UploadButton_Click" runat="server" Text="Cargar Pros" />
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
