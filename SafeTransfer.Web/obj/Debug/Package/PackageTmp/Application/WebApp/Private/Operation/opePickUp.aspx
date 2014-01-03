<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opePickUp.aspx.cs" Inherits="SafeTransfer.Web.Application.WebApp.Private.Operation.opePickUp" %>
<%@ Register src="../../../../Include/WebUserControls/wucSelector_Cliente.ascx" tagname="wucSelector_Cliente" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucCotizador.ascx" tagname="wucCotizador" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucToolbar.ascx" tagname="wucToolbar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   <script language="JavaScript" type="text/javascript">
	<!--

      // Funciones del programador
      function clickAccordionPane() {
         var ancTrigger = document.getElementById('ancTrigger');

         //Acionar Accordeon
         ancTrigger.click();
      }

   -->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Recolección
            <wuc:wucToolbar ID="wucToolbar" runat="server"
               OnClickBackImage     ="wucToolbar_ClickBackImage"
               OnClickDeleteImage   ="wucToolbar_ClickDeleteImage"
               OnClickNewImage      ="wucToolbar_ClickNewImage"
               OnClickNextImage     ="wucToolbar_ClickNextImage"
               OnClickReleaseImage  ="wucToolbar_ClickReleaseImage"
               OnClickSaveImage     ="wucToolbar_ClickSaveImage"
            />
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFiltro" runat="server" Width="100%">
               <ajaxToolkit:Accordion ID="acrdFiltro" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="500" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
				      <Panes>
					       <ajaxToolkit:AccordionPane ID="apnlFiltro" runat="server">
						      <Header>
							      <a id="ancTrigger" href="" class="accordionLink" visible="false"></a>
						      </Header>
						      <Content>
							         <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                 <tr class="trFilaItem">
							               <td class="tdCeldaLeyendaItem">&nbsp;PickUp</td>
							               <td style="width:5px;"></td>
							               <td class="tdCeldaItem"><asp:TextBox ID="txtPickUp" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						               </tr>
                                 <tr style="height:3px;"><td colspan="3"></td></tr>
                                 <tr class="trFilaItem">
                                    <td class="tdCeldaLeyendaItem">&nbsp;Cliente</td>
                                    <td style="width:5px;"></td>
                                    <td class="tdCeldaItem"><asp:TextBox ID="txtCliente" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
                                 </tr>
                                 <tr style="height:10px;"><td colspan="3"></td></tr>
                                 <tr class="trFilaItem">
                                    <td colspan="3" style="text-align:left;">
                                       <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" OnClick="btnBuscar_Click" />
                                    </td>
                                 </tr>
                                 <tr style="height:10px;"><td colspan="3"></td></tr>
                                 <tr class="trFilaItem">
                                    <td colspan="3">
                                       <asp:GridView id="gvPickUp" runat="server" border="0" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						                        DataKeyNames="idPickUp"
						                        OnRowDataBound="gvPickUp_RowDataBound"
						                        OnRowCommand="gvPickUp_RowCommand"
						                        OnSorting="gvPickUp_Sorting">
						                        <alternatingrowstyle cssclass="Grid_Row_Alternating" />
						                        <headerstyle cssclass="Grid_Header" />
						                        <rowstyle cssclass="Grid_Row" />
						                        <EmptyDataTemplate>
							                        <table border="1px" cellpadding="0px" cellspacing="0px">
								                        <tr class="Grid_Header">
									                        <td style="width:100px;">PickUp</td>
									                        <td style="width:190px;">Cliente</td>
                                                   <td style="width:190px;">Sucursal</td>
                                                   <td style="width:310px;">Dirección</td>
								                        </tr>
								                        <tr class="Grid_Row">
									                        <td colspan="4">No se encontraron PickUp's</td>
								                        </tr>
							                        </table>
						                        </EmptyDataTemplate>
						                        <Columns>
							                        <asp:BoundField HeaderText="PickUp"    ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="idPickUp"    SortExpression="idPickUp"></asp:BoundField>
                                             <asp:BoundField HeaderText="Cliente"   ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="190px" DataField="sCliente"    SortExpression="sCliente"></asp:BoundField>
							                        <asp:BoundField HeaderText="Sucursal"  ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="190px" DataField="sSucursal"   SortExpression="sSucursal"></asp:BoundField>
                                             <asp:BoundField HeaderText="Dirección" ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="290px" DataField="sDireccion"  SortExpression="sDireccion"></asp:BoundField>
							                        <asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								                        <ItemTemplate>
                                                   <asp:ImageButton ID="imgSelectItem" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Seleccionar" ImageUrl="~/Include/Image/Buttons/SelectItem_Null.png" runat="server" />
                                                </ItemTemplate>
							                        </asp:TemplateField>
						                        </Columns>
					                        </asp:GridView>
                                       <br />
                                       <div style="border-bottom:1px solid #4B4878; width:790px; height:1px;"></div>
                                       <br />
                                    </td>
                                 </tr>
					               </table>
						      </Content>
					       </ajaxToolkit:AccordionPane>
				      </Panes>
			      </ajaxToolkit:Accordion>
            </asp:Panel>
         </td>
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td colspan="2" style="text-align:right; width:100%">
                        <div style="float:right;">
                           <asp:Literal id="litNoPickUp" runat="server" text="<table border='0' cellpadding='0' cellspacing='0'><tr><td>PickUp:&nbsp;&nbsp;</td><td><div style='border-bottom:1px solid; text-align:center; width:120px'>&nbsp;</div></td></tr></table>"></asp:Literal>
                        </div>
                     </td>
                  </tr>
                  <tr style="height:10px;"><td colspan="2"></td></tr>
                  <tr>
                     <td colspan="2" style="text-align:right; width:100%">
                        <div style="float:right; text-align:right;">
                            <wuc:wucCotizador ID="wucCotizador" runat="server" OnClickCotizarImage ="wucCotizador_ClickCotizarImage" />
                        </div>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:left; width:100%">
                        <asp:Panel id="pnlShipperInfo" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td colspan="2" style="height:60px; text-align:left; vertical-align:middle;">Información del Embarcador (Campos obligatorios son marcados con *)</td></tr>
                              <tr class="trFilaItem">
	                              <td class="tdOPCeldaItem">Centro: *</td>
	                              <td><asp:DropDownList id="ddlCentroServicio" runat="server" CssClass="DropDownList_General" width="215px" ></asp:DropDownList></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
	                              <td class="tdOPCeldaItem">Compañia: *</td>
	                              <td><wuc:wucSelector_Cliente ID="wucSelectorCliente" runat="server" OnItemSelected="wucSelectorCliente_ItemSelected"  /></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
                                 <td class="tdOPCeldaItem">Sucursal:</td>
                                 <td><asp:TextBox ID="txtSucursal" runat="server" CssClass="Textbox_General" width="212px" ></asp:TextBox></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
	                              <td colspan="2">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                       <tr>
                                          <td class="tdOPCeldaItem">Pais: *</td>
	                                       <td style="width:150px;"><asp:DropDownList id="ddlPais" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlPais_SelectedIndexChanged" ></asp:DropDownList></td>
                                          <td style="width:85px; color:#4B4878; font-size:11px; font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;Estado: *</td>
	                                       <td><asp:DropDownList id="ddlEstado" runat="server" CssClass="DropDownList_General" width="150px" AutoPostBack="True" onselectedindexchanged="ddlEstado_SelectedIndexChanged" ></asp:DropDownList></td>
                                        </tr>
                                    </table>
                                 </td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
                                 <td class="tdOPCeldaItem">Ciudad: *</td>
                                 <td><asp:DropDownList id="ddlCiudad" runat="server" CssClass="DropDownList_General" width="385px" ></asp:DropDownList></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
                                 <td class="tdOPCeldaItem">CP: *</td>
                                 <td><asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="Textbox_General" width="90px" ></asp:TextBox></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
                                 <td class="tdOPCeldaItem">Dirección: *</td>
                                 <td><asp:TextBox ID="txtDireccion" runat="server" CssClass="Textarea_General" width="380px" TextMode="MultiLine" ></asp:TextBox></td>
                              </tr>
                           </table>
                        </asp:Panel>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:left; width:100%">
                        <asp:Panel id="pnlPickUpInfo" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td colspan="2" style="height:60px; text-align:left; vertical-align:middle;">Información del PickUp (Campos obligatorios son marcados con *)</td></tr>
                              <tr class="trFilaItem">
	                              <td class="tdOPCeldaItem">Fecha: *</td>
	                              <td><wuc:wucCalendar ID="wucCalendar" runat="server" /></td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
	                              <td colspan="2">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                       <tr>
                                          <td class="tdOPCeldaItem">Desde: *</td>
	                                       <td style="width:110px;">
                                             <asp:DropDownList id="ddlPickUpHora_Desde" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>&nbsp;:
                                             <asp:DropDownList id="ddlPickUpMinuto_Desde" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>
                                          </td>
                                          <td style="width:40px; color:#4B4878; font-size:11px; font-weight:bold;">Hasta:</td>
	                                       <td>
                                             <asp:DropDownList id="ddlPickUpHora_Hasta" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>&nbsp;:
                                             <asp:DropDownList id="ddlPickUpMinuto_Hasta" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>&nbsp;
                                             <asp:CheckBox ID="chkLLamar" runat="server" CssClass="CheckBox_Regular" Text="LLamar para confirmar" Checked="True" />
                                          </td>
                                        </tr>
                                    </table>
                                 </td>
                              </tr>
                              <tr><td colspan="2" style="height:10px;"></td></tr>
                              <tr class="trFilaItem">
                                 <td class="tdOPCeldaItem">Observaciones:</td>
                                 <td><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="380px" TextMode="MultiLine" ></asp:TextBox></td>
                              </tr>
                           </table>
                        </asp:Panel>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:left; width:100%">
                        <asp:Panel id="pnlDockInfo" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td colspan="2" style="height:60px; text-align:left; vertical-align:middle;">Información del Muelle</td></tr>
                              <tr class="trFilaItem">
	                              <td class="tdOPCeldaItem">Cierre:</td>
	                              <td>
                                    <asp:DropDownList id="ddlMuelleHora_Cierre" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>&nbsp;:&nbsp;
                                    <asp:DropDownList id="ddlMuelleMinuto_Cierre" runat="server" CssClass="DropDownList_General" width="40px" ></asp:DropDownList>
                                 </td>
                              </tr>
                           </table>
                        </asp:Panel>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:left; width:100%">
                        <asp:Panel id="pnlContactInfo" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td colspan="2" style="height:60px; text-align:left; vertical-align:middle;">Contactos (Por lo menos uno obligatorio)</td></tr>
                              <tr>
                                 <td colspan="2">
                                    <div id="tblHeader_Contacto" style="border:0px solid #000000; clear:both; position:relative; width:790px;">
						                     <table cellspacing="0" rules="all" border="1" style="border-collapse:collapse; width:790px;">
                                          <tr class="Grid_Header_Action">
								                     <th scope="col" style="width:130px;"><asp:LinkButton id="lnkContacto_Tipo"          runat="server" Text="Tipo de Contacto" CommandName="sTipoContacto"   OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:130px;"><asp:LinkButton id="lnkContacto_Nombre"        runat="server" Text="Nombre"           CommandName="sNombre"         OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:130px;"><asp:LinkButton id="lnkContacto_Telefono"      runat="server" Text="Telefono"         CommandName="sTelefono"       OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:130px;"><asp:LinkButton id="lnkContacto_Mail"          runat="server" Text="Correo"           CommandName="sCorreo"         OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
                                             <th scope="col" style="width:130px;"><asp:LinkButton id="lnkContacto_Comentarios"   runat="server" Text="Comentarios"      CommandName="sComentarios"    OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
                                             <th scope="col" style="width:25px;"><asp:LinkButton  id="lnkContacto_Requerido"     runat="server" Text="Req"              CommandName="sRequerido"      OnCommand="gvContactos_Sorting"></asp:LinkButton></th>
								                     <th scope="col"></th>
							                     </tr>
							                     <tr class="Grid_Header_Action">
								                     <th scope="col"><asp:DropDownList id="ddlContacto_Tipo"     runat="server" CssClass="DropDownList_General" Width="125px"></asp:DropDownList></th>
								                     <th scope="col"><asp:TextBox ID="txtContacto_Nombre"        runat="server" CssClass="Textbox_General" MaxLength="200"   width="125px" ></asp:TextBox></th>
								                     <th scope="col"><asp:TextBox ID="txtContacto_Telefono"      runat="server" CssClass="Textbox_General" MaxLength="100"   width="125px" ></asp:TextBox></th>
								                     <th scope="col"><asp:TextBox ID="txtContacto_Correo"        runat="server" CssClass="Textbox_General" MaxLength="200"   width="125px" ></asp:TextBox></th>
                                             <th scope="col"><asp:TextBox ID="txtContacto_Comentarios"   runat="server" CssClass="Textbox_General" MaxLength="500"   width="125px" ></asp:TextBox></th>
                                             <th scope="col"><asp:CheckBox ID="chkContacto_Requerido"    runat="server" CssClass="CheckBox_Regular" /></th>
								                     <th scope="col"><asp:Button ID="btnContacto_Nuevo"          runat="server" CssClass="Button_General"  Text="Agregar" width="90px" onclick="btnContacto_Nuevo_Click" /></th>
							                     </tr>
						                     </table>
                                    </div>
                                    <div id="tblBody_Contacto" style="border:0px solid #000000; clear:both; position:relative; top:-1px; width:100%;">
						                     <asp:GridView id="gvContactos" runat="server" border="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" ShowHeader="false" Width="790px"
                                          DataKeyNames="idTipoContacto,tiRequerido"
                                          OnRowCommand="gvContactos_RowCommand"
							                     OnRowDataBound="gvContactos_RowDataBound">
							                     <alternatingrowstyle cssclass="Grid_Row_Alternating" />
							                     <rowstyle cssclass="Grid_Row" />
							                     <EmptyDataTemplate>
								                     <div class="Grid_Row" style="border:1px solid #C1C1C1; clear:both; left:-1px; position:relative; text-align:center; top:-2px; width:788px;">
									                     Agregue un nuevo Contacto
								                     </div>
							                     </EmptyDataTemplate>
							                     <Columns>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="126px"	DataField="sTipoContacto"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="130px"	DataField="sNombre"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="129px"	DataField="sTelefono"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="129px"	DataField="sCorreo"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="129px"	DataField="sComentarios"></asp:BoundField>
                                             <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="21px"	DataField="sRequerido"></asp:BoundField>
								                     <asp:TemplateField	ItemStyle-HorizontalAlign ="Center">
									                     <ItemTemplate>
										                     <asp:ImageButton ID="imgEliminar" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" ToolTip="Eliminar Contacto" runat="server" />
									                     </ItemTemplate>
								                     </asp:TemplateField>
							                     </Columns>
						                     </asp:GridView>
                                    </div>
                                 </td>
                              </tr>
                           </table>
                        </asp:Panel>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:left; width:100%">
                        <asp:Panel id="pnlItemsInfo" runat="server" Width="100%">
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr><td colspan="2" style="height:60px; text-align:left; vertical-align:middle;">Carga (Por lo menos uno obligatorio)</td></tr>
                              <tr>
                                 <td colspan="2">
                                    <div id="tblHeader_Carga" style="border:0px solid #000000; clear:both; position:relative; width:790px;">
						                     <table cellspacing="0" rules="all" border="1" style="border-collapse:collapse; width:790px;">
                                          <tr class="Grid_Header_Action">
								                     <th scope="col" style="width:65px;"><asp:LinkButton id="lnkCarga_Piezas"               runat="server" Text="Piezas"                 CommandName="dPiezas"               OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:80px;"><asp:LinkButton id="lnkCarga_TipoPieza"            runat="server" Text="Tipo"                   CommandName="sTipoPieza"            OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:65px;"><asp:LinkButton id="lnkCarga_Peso"                 runat="server" Text="Peso"                   CommandName="dPeso"                 OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:80px;"><asp:LinkButton id="lnkCarga_UnidadMedidaPeso"     runat="server" Text="Unidad"                 CommandName="sUnidadMedidaPeso"     OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
                                             <th scope="col" style="width:65px;"><asp:LinkButton id="lnkCarga_Volumen"              runat="server" Text="Volumen"                CommandName="dPeso"                 OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
								                     <th scope="col" style="width:80px;"><asp:LinkButton id="lnkCarga_UnidadMedidaVolumen"  runat="server" Text="Unidad"                 CommandName="sUnidadMedidaVolumen"  OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
                                             <th scope="col" style="width:140px;"><asp:LinkButton id="lnkCarga_Instrucciones"       runat="server" Text="Apuntes/Instrucciones"  CommandName="sInstrucciones"        OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
                                             <th scope="col" style="width:120px;"><asp:LinkButton  id="lnkCarga_Servicios"          runat="server" Text="Servicios"              CommandName="sServicios"            OnCommand="gvCarga_Sorting"></asp:LinkButton></th>
								                     <th scope="col"></th>
							                     </tr>
							                     <tr class="Grid_Header_Action">
								                     <th scope="col">
                                                <asp:TextBox ID="txtCarga_Piezas" runat="server" CssClass="Textbox_General" MaxLength="12" width="60px" ></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="maskCarga_Piezas" runat="server" TargetControlID="txtCarga_Piezas" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                                             </th>
								                     <th scope="col"><asp:DropDownList id="ddlCarga_TipoPieza" runat="server" CssClass="DropDownList_General" Width="75px"></asp:DropDownList></th>
								                     <th scope="col">
                                                <asp:TextBox ID="txtCarga_Peso" runat="server" CssClass="Textbox_General" MaxLength="12" width="60px" ></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="maskCarga_Peso" runat="server" TargetControlID="txtCarga_Peso" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                                             </th>
								                     <th scope="col"><asp:DropDownList id="ddlCarga_UnidadMedidaPeso"  runat="server" CssClass="DropDownList_General" Width="75px"></asp:DropDownList></th>
                                             <th scope="col">
                                                <asp:TextBox ID="txtCarga_Volumen" runat="server" CssClass="Textbox_General" MaxLength="12" width="60px" ></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="maskCarga_Volumen" runat="server" TargetControlID="txtCarga_Volumen" Mask="999,999.99" AcceptNegative="None" MessageValidatorTip="false" MaskType="Number" InputDirection="RightToLeft" DisplayMoney="None" ErrorTooltipEnabled="False"/>
                                             </th>
								                     <th scope="col"><asp:DropDownList id="ddlCarga_UnidadMedidaVolumen"   runat="server" CssClass="DropDownList_General" Width="75px"></asp:DropDownList></th>
                                             <th scope="col"><asp:TextBox ID="txtCarga_Instrucciones" runat="server" CssClass="Textbox_General" MaxLength="500"   width="130px" ></asp:TextBox></th>
                                             <th scope="col">
                                                <asp:CheckBoxList ID="chkServicio" runat="server" CssClass="CheckBox_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="5"></asp:CheckBoxList>
                                             </th>
								                     <th scope="col"><asp:Button ID="btnCarga_Nueva"          runat="server" CssClass="Button_General"  Text="Agregar" width="90px" onclick="btnCarga_Nueva_Click" /></th>
							                     </tr>
						                     </table>
                                    </div>
                                    <div id="tblBody_Carga" style="border:0px solid #000000; clear:both; position:relative; top:-1px; width:100%;">
						                     <asp:GridView id="gvCarga" runat="server" border="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" ShowHeader="false" Width="790px"
                                          DataKeyNames="idTipoPieza,idUnidadMedidaPeso,idUnidadMedidaVolumen,sIDServicios"
                                          OnRowCommand="gvCarga_RowCommand"
							                     OnRowDataBound="gvCarga_RowDataBound">
							                     <alternatingrowstyle cssclass="Grid_Row_Alternating" />
							                     <rowstyle cssclass="Grid_Row" />
							                     <EmptyDataTemplate>
								                     <div class="Grid_Row" style="border:1px solid #C1C1C1; clear:both; left:-1px; position:relative; text-align:center; top:-2px; width:788px;">
									                     Agregue una nueva Carga
								                     </div>
							                     </EmptyDataTemplate>
							                     <Columns>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="64px"	DataField="dPiezas"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="75px"	DataField="sTipoPieza"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="64px"	DataField="dPeso"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="76px"	DataField="sUnidadMedidaPeso"></asp:BoundField>
                                             <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="64px"	DataField="dVolumen"></asp:BoundField>
								                     <asp:BoundField		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="76px"	DataField="sUnidadMedidaVolumen"></asp:BoundField>
                                             <asp:BoundField		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="135px"	DataField="sInstrucciones"></asp:BoundField>
                                             <asp:BoundField		ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="100px"	DataField="sServicios"></asp:BoundField>
								                     <asp:TemplateField	ItemStyle-HorizontalAlign ="Center">
									                     <ItemTemplate>
										                     <asp:ImageButton ID="imgEliminar" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" ToolTip="Eliminar Carga" runat="server" />
									                     </ItemTemplate>
								                     </asp:TemplateField>
							                     </Columns>
						                     </asp:GridView>
                                    </div>
                                 </td>
                              </tr>
                           </table>
                        </asp:Panel>
                     </td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddCurrentPickUp" runat="server" value="-1" />
   <asp:HiddenField ID="hddSort" runat="server" value="sPickUp" />
</asp:Content>
