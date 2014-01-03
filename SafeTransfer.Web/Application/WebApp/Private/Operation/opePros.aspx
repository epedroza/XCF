<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opePros.aspx.cs" Inherits="SafeTransfere.Web.Application.WebApp.Private.Operation.opePros" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
            vertical-align: middle;
            height: 14px;
            width: 211px;
        }
        .style3
        {
            background-color: Green;
            border: 1px none #4B4878;
            color: White;
            font-family: Arial, Sans-Serif;
            font-size: 11px;
            font-weight: lighter;
            text-align: right;
            width: 211px;
            height: 14px;
        }
        .style4
        {
            background-color: white;
            border: 1px none #4B4878;
            color: Black;
            font-family: Arial, Sans-Serif;
            font-size: 11px;
            font-weight: lighter;
            text-align: right;
            width: 211px;
            height: 14px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Pros
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td align="left">
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
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
                        <tr class="trFilaItem">
                            <td colspan="15" class="tdCeldaHeader" >Carátula</td>
                        </tr>
                        <tr class="trFilaSeparaItem"><td colspan="15"></td></tr><!--Division de seccion encabezado a Captura-Cargado -->
                        <tr>
                            <td colspan="15">
                                <table cellpadding="0"  cellspacing="1" width="100%" border="0">
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaItem" align="center">&nbsp;</td>
                                        <td class="tdCeldaItem" colspan="3" align="center">&nbsp;</td>
                                        <td class="tdCeldaItemLine" colspan="4" align="center">&nbsp;Captura</td>
                                        <td class="tdCeldaItemLine" colspan="4" align="center">&nbsp;Cargado</td>
                                        <td class="tdCeldaLeyendaItemLargeLeft" colspan="1">&nbsp;<asp:CheckBox ID="chkPrimeTime" runat="server" Text="PrimeTime" /></td>
						            </tr>
						            <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge" style="width:50px;">Pro</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtClavePro" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Terminal</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtTerminalPro" runat="server" CssClass="Textbox_General" width="70px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge" style="background-color:Yellow;">&nbsp;Fecha</td>
                                        <td class="tdCeldaItem" style="background-color:Yellow;">
                                            <wuc:wucCalendar ID="txtFechaCaptura" runat="server" />
                                        </td>
                                        <td class="tdCeldaLeyendaItemLarge" style="background-color:Yellow;">&nbsp;Hora</td>
                                        <td class="tdCeldaItem" style="background-color:Yellow;"><asp:TextBox ID="txtHoraCaptura" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge" style="background-color:Orange;">&nbsp;Fecha</td>
                                        <td class="tdCeldaItem" style="background-color:Orange;">
                                            <wuc:wucCalendar ID="txtFechaCargado" runat="server" />
                                        </td>
                                        <td class="tdCeldaLeyendaItemLarge" style="background-color:Orange;">&nbsp;Hora</td>
                                        <td class="style1" style="background-color:Orange;"><asp:TextBox ID="txtHoraCargado" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeLeft" colspan="2">&nbsp;<asp:CheckBox ID="chkMaterialPeligroso" runat="server" Text="Material Peligroso" /></td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Factura</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtNoFactura" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge" colspan="3">&nbsp;Factura Fecha</td>
                                        <td class="tdCeldaItem">
                                            <wuc:wucCalendar ID="txtFechaFactura" runat="server" />
                                        </td>
                                        <td class="tdCeldaItem" colspan="6"></td>
                                        <td class="tdCeldaLeyendaItemLargeLeft" colspan="1">&nbsp;<asp:CheckBox ID="chkPuertaaPuerta" runat="server" Text="Puerta a Puerta" /></td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;PickUp</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtPickUp" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge" colspan="3">&nbsp;</td>
                                        <td class="tdCeldaItem"></td>
                                        <td class="tdCeldaItem" colspan="6"></td>
                                        <td class="tdCeldaLeyendaItemLargeLeft" colspan="1">&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="Puerta a Puerta" /></td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td colspan="12"></td>                                        
                                        <td class="tdCeldaLeyendaItemLargeLeft">&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Siguiente día" /></td>
						            </tr>
                                </table>
                            </td>
                        </tr>
                        <!--Origen y Destino-->
                        <tr>
                            <td colspan="15">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr class="trFilaItem">
                                        <td colspan="7" align="center" style="color:Brown;">&nbsp;ORIGEN</td>
                                        <td colspan="5" align="center" style="color:Purple;">&nbsp;DESTINO</td>
                                        <td class="tdCeldaLeyendaItemLargeLeft" colspan="1">&nbsp;</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
                                    </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Clave</td>
                                        <td class="tdCeldaItemBrown"><asp:DropDownList ID="cboIdClaveOrigen" runat="server" AutoPostBack="True" onselectedindexchanged="cboIdClaveOrigen_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Nombre</td>
                                        <td class="tdCeldaItemBrown" colspan="4"><asp:TextBox ID="txtNombreOrigen" runat="server" CssClass="Textbox_General" width="280px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Clave</td>
                                        <td class="tdCeldaItemPurple">
                                            <asp:DropDownList ID="cboIdClaveDestino" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveDestino_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Nombre</td>
                                        <td class="tdCeldaItemPurple" colspan="4"><asp:TextBox ID="txtNombreDestino" runat="server" CssClass="Textbox_General" width="230px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr> 
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;RFC</td>
                                        <td class="tdCeldaItemBrown" colspan="2"><asp:TextBox ID="txtRFCOrigen" 
                                                runat="server" CssClass="Textbox_General" width="100px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Terminal</td>
                                        <td class="tdCeldaItemBrown"><asp:TextBox ID="txtTerminalOrigen" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Cd</td>
                                        <td class="tdCeldaItemBrown"><asp:TextBox ID="txtCdOrigen" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;RFC</td>
                                        <td class="tdCeldaItemPurple" colspan="1"><asp:TextBox ID="txtRFCDestino" 
                                                runat="server" CssClass="Textbox_General" width="100px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Terminal</td>
                                        <td class="tdCeldaItemPurple"><asp:TextBox ID="txtTerminalDestino" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Cd</td>
                                        <td class="tdCeldaItemPurple"><asp:TextBox ID="txtCdDestino" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItemPurple">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Dirección</td>
                                        <td class="tdCeldaItemBrown" colspan="6"><asp:TextBox ID="txtDireccionOrigen" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Dirección</td>
                                        <td class="tdCeldaItemPurple" colspan="6"><asp:TextBox ID="txtDireccionDestino" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Ciudad</td>
                                        <td class="tdCeldaItemBrown" colspan="6"><asp:TextBox ID="txtCiudadOrigen" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;Ciudad</td>
                                        <td class="tdCeldaItemPurple" colspan="6">
                                            <asp:TextBox ID="txtCiudadDestino" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeBrown">&nbsp;Pro Externo</td>
                                        <td class="tdCeldaItemBrown" colspan="6"><asp:TextBox ID="txtProExterno" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargePurple">&nbsp;</td>
                                        <td class="tdCeldaItemPurple" colspan="6"></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
						            </tr>
                                    <!--Cliente  Fiscal -- Agente Aduanal-->
                                    <tr class="trFilaItem">
                                        <td colspan="7" align="center" style="color:Gray;">&nbsp;CLIENTE FISCAL</td>
                                        <td colspan="7" align="center" style="color:Green;">&nbsp;AGENTE ADUANAL</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Clave</td>
                                        <td class="tdCeldaItemGray2">
                                            <asp:DropDownList ID="cboIdClaveCFiscal" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveCFiscal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Nombre</td>
                                        <td class="tdCeldaItemGray2" colspan="4"><asp:TextBox ID="txtNombreCFiscal" runat="server" 
                                                CssClass="Textbox_General" width="280px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;Clave</td>
                                        <td class="tdCeldaItemGreen">
                                            <asp:DropDownList ID="cboIdClaveAAduanal" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveAAduanal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;Nombre</td>
                                        <td class="tdCeldaItemGreen" colspan="4"><asp:TextBox ID="txtNombreAAduanal" runat="server" 
                                                CssClass="Textbox_General" width="230px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;RFC</td>
                                        <td class="tdCeldaItemGray2" colspan="2"><asp:TextBox ID="txtRFCCFiscal" 
                                                runat="server" CssClass="Textbox_General" width="100px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Terminal</td>
                                        <td class="tdCeldaItemGray2"><asp:TextBox ID="txtTerminalCFiscal" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Cd</td>
                                        <td class="tdCeldaItemGray2"><asp:TextBox ID="txtCdCFiscal" runat="server" 
                                                CssClass="Textbox_General" width="50px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;RFC</td>
                                        <td class="tdCeldaItemGreen" colspan="1"><asp:TextBox ID="txtRFCAAduanal" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;Terminal</td>
                                        <td class="tdCeldaItemGreen"><asp:TextBox ID="txtTerminalAAduanal" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="style3">&nbsp;Cd</td>
                                        <td class="tdCeldaItemGreen"><asp:TextBox ID="txtCdAAduanal" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaItemGreen">&nbsp;</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Dirección</td>
                                        <td class="tdCeldaItemGray2" colspan="6"><asp:TextBox ID="txtDireccionCFiscal" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;Dirección</td>
                                        <td class="tdCeldaItemGreen" colspan="6"><asp:TextBox ID="txtDireccionAAduanal" runat="server" CssClass="Textbox_General" width="370px" ></asp:TextBox></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLargeGray2">&nbsp;Ciudad</td>
                                        <td class="tdCeldaItemGray2" colspan="6"><asp:TextBox ID="txtCiudadCFiscal" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLargeGreen">&nbsp;Ciudad</td>
                                        <td class="tdCeldaItemGreen" colspan="6"><asp:TextBox ID="txtCiudadAAduanal" 
                                                runat="server" CssClass="Textbox_General" width="370px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
						            </tr>
                                </table>
                            </td>
                        </tr>

                        <!--Cobrar A-->
                        <tr>
                            <td colspan="15">
                                <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;COBRAR A</td>
                                        <td class="tdCeldaItem">
                                            <asp:DropDownList ID="cboIdClaveCobrarA" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveCobrarA_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Nombre</td>
                                        <td class="tdCeldaItem" colspan="4"><asp:TextBox ID="txtNombreCobrarA" runat="server" CssClass="Textbox_General" width="220px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;RFC</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtRFCCobrarA" runat="server" CssClass="Textbox_General" width="70px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Terminal</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtTerminalCobrarA" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="style4">&nbsp;Cd</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtCdCobrarA" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaItem">&nbsp;</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Cond Pago</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtCondPago" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Vend Origen</td>
                                        <td class="tdCeldaItem" colspan="4">
                                            <asp:DropDownList ID="cboIdClaveVendOrigen" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveVendOrigen_SelectedIndexChanged">
                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtVendedorOrigen" 
                                                runat="server" CssClass="Textbox_General" width="160px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem" colspan="2">&nbsp;</td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Vend Destino</td>
                                        <td class="tdCeldaItem" align="right" colspan="3">
                                            <asp:DropDownList ID="cboIdClaveVendDestino" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="cboIdClaveVendDestino_SelectedIndexChanged">
                                            </asp:DropDownList>
                                                                                <asp:TextBox ID="txtVendedorDestino" 
                                                runat="server" CssClass="Textbox_General" width="160px" Enabled="False" ></asp:TextBox></td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                                    <tr class="trFilaItem">
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Term Fac.</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtTermFac" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Patente</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtPatente" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Pedimento</td>
                                        <td class="tdCeldaItem" colspan="1"><asp:TextBox ID="txtPedimento" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;<asp:CheckBox ID="chkOcurre" runat="server" Text="Ocurre" /></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Días Crédito</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtDiasCredito" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="tdCeldaLeyendaItemLarge">&nbsp;Peso Total</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtPesoTotal" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="style4">&nbsp;Pzas. Total</td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="txtPzasTotal" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                        <td class="tdCeldaItem">&nbsp;</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
						            </tr>
                             </table>
                            </td>
                        </tr>
                        <tr class="trFilaItem">
                            <td class="tdCeldaItem" colspan="15">&nbsp;</td>
						</tr>
                        <tr class="trFilaItem">
                            <td class="tdCeldaItem" colspan="12">
                                <div style="Height:100px;">
                                    <asp:panel runat="server">
                                        <asp:GridView ID="gvAppsPros" runat="server" AutoGenerateColumns="False"
                                                AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvAppsPros_PageIndexChanging"
                                                OnRowDataBound="gvAppsPros_RowDataBound" OnSelectedIndexChanged="gvAppsPros_SelectedIndexChanged"
                                                OnSelectedIndexChanging="gvAppsPros_SelectedIndexChanging" OnRowCommand="gvAppsPros_RowCommand"
                                                UpdateAfterCallBack="True" Width="600px" Style="text-align: center" DataKeyNames="Numero"
                                                PageSize="30" ShowHeaderWhenEmpty="True">
                                                <RowStyle CssClass="Grid_Row" />
                                                <EditRowStyle Wrap="True" />
                                                <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                                <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                                <Columns>
                                                    <asp:BoundField DataField="Numero" HeaderText="Número"/>
                                                    <asp:BoundField DataField="Clase" HeaderText="Clase">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Puesto" HeaderText="Puesto">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MetrosCubicos" HeaderText="Metros cubicos">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PesoKg" HeaderText="PesoKg">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factor" HeaderText="Factor">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PesoEst" HeaderText="PesoEst">
                                                        <ItemStyle HorizontalAlign="Left"/>
                                                    </asp:BoundField>
                                                    <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
                                                </Columns>
                                           </asp:GridView>
                                   </asp:panel>
                                </div>
                            </td>
                            <td class="tdCeldaItem" colspan="3">&nbsp;
                                <table>
                                    <tr>
                                        <td class="tdCeldaItem">&nbsp;Valor de Mercancía</td>
                                        <td class="tdCeldaItem">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="tdCeldaItem" colspan="2"><asp:TextBox ID="txtValorMercancia" runat="server" CssClass="Textbox_General" width="100px" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="tdCeldaItem">&nbsp;BL</td>
                                        <td class="tdCeldaItem">&nbsp;PE</td>
                                    </tr>
                                </table>
                            </td>
						</tr>
                        <tr class="trFilaItem">
                            <td class="tdCeldaLeyendaItemLarge" colspan="11">
                                <table width="100%">
                                    <tr>
                                        <td><!--Grid 2--></td>
                                        <td><!--Grid 3--></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="tdCeldaLeyendaItemLarge" colspan="4"><!--Totales-->
                                <table width="100%">
                                    <tr>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
						</tr>
                        <tr class="trFilaItem" >
                            <td class="tdCeldaLeyendaItemLarge" style="background-color:Gray;">&nbsp;[Ctrl]+[N] para agregar, [Ctrl]+[T] para borrar</td>
                            <td class="tdCeldaLeyendaItemLarge" style="background-color:Gray;"><asp:Button ID="Button1" runat="server" Text="Agregar referencia" CssClass="Button_General" width="125px" /></td>
                            <td class="tdCeldaItem">&nbsp;</td>
						</tr>

					</table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace">
            <asp:GridView ID="gvAppsServicios" runat="server" AutoGenerateColumns="False"
                    AutoUpdateAfterCallBack="True" OnPageIndexChanging="gvAppsPros_PageIndexChanging"
                    OnRowDataBound="gvAppsPros_RowDataBound" OnSelectedIndexChanged="gvAppsPros_SelectedIndexChanged"
                    OnSelectedIndexChanging="gvAppsPros_SelectedIndexChanging" OnRowCommand="gvAppsPros_RowCommand"
                    UpdateAfterCallBack="True" Width="600px" Style="text-align: center" DataKeyNames="Numero"
                    PageSize="30" ShowHeaderWhenEmpty="True">
                    <RowStyle CssClass="Grid_Row" />
                    <EditRowStyle Wrap="True" />
                    <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                    <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                    <Columns>
                        <asp:BoundField DataField="Cargo" HeaderText="Cargo"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Importe" HeaderText="Importe">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
                    </Columns>
                </asp:GridView>
            </td>
         </tr>
         <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" /></td>
                     <td style="height:24px; width:530px;">
                         <asp:Button ID="cmdGuardar" runat="server" CssClass="Button_General" 
                             Text="Nuevo" width="125px" onclick="cmdGuardar_Click" />
                      </td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td>
      <td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
        <td class="tdCeldaMiddleSpace">Observaciones</td>
        <td class="tdCeldaMiddleSpace"></td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace">
          <asp:TextBox ID="txtObervaciones" runat="server" Height="70px" Width="532px"></asp:TextBox>
          </td>
      <td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
