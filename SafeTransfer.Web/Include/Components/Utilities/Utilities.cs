using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

using SafeTransfer.Entity.Object;
using SafeTransfer.BusinessProcess.Object;

namespace SafeTransfer.Include.Components.Utilities
{
    public class Utilities
    {
        internal static void FillCombo(ref System.Web.UI.WebControls.DropDownList cb, string strColValue, string strColDisplay, string Tipo)
        {
            SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();
            string ValorCero = "[--------]";
            System.Data.DataSet ds = new System.Data.DataSet();
            cb.Items.Clear();

            try
            {
                switch (Tipo)
                {
                    case "Paises":
                        ENTPais entPais = new ENTPais();
                        BPPais bssPais = new BPPais();
                        oENTResponse = bssPais.searchcatPaisescbo(entPais);
                        break;
                    case "Estados":
                        ENTEstado entEstado = new ENTEstado();
                        entEstado.idPais = 1; // Provisional, cambiar a nuevo metodo con parametro entero para consulta
                        BPEstado bssEstado = new BPEstado();
                        oENTResponse = bssEstado.searchcatEstadoscbo(entEstado);
                        break;
                    case "Ciudades":
                        ENTCiudad entCiudad = new ENTCiudad();
                        entCiudad.idPais = 1; // Provisional, cambiar a nuevo metodo con parametro entero para consulta
                        entCiudad.idEstado = 18; // Provisional, cambiar a nuevo metodo con parametro entero para consulta
                        BPCiudad bssCiudad = new BPCiudad();
                        oENTResponse = bssCiudad.searchcatCiudadescbo(entCiudad);
                        break;
                    case "TiposCamiones":
                        ENTTipoCamion entTipoCamion = new ENTTipoCamion();
                        BusinessProcess.Object.catTiposCamionesBSS bssTipoCamion = new BusinessProcess.Object.catTiposCamionesBSS();
                        oENTResponse = bssTipoCamion.searchcatTiposCamionescbo(entTipoCamion);
                        break;
                    case "TiposClientes":
                        ENTTipoCliente entTipoCliente = new ENTTipoCliente();
                        BusinessProcess.Object.catTiposClienteBSS bssTipoCliente = new BusinessProcess.Object.catTiposClienteBSS();
                        oENTResponse = bssTipoCliente.searchcatTiposClientecbo(entTipoCliente);
                        break;
                    case "Vendedores":
                        ENTVendedor entVendedor = new ENTVendedor();
                        entVendedor.idCompany = 1;
                        catVendedoresBSS bssVendedor = new catVendedoresBSS();
                        oENTResponse = bssVendedor.searchcatVendedorescbo(entVendedor);
                        break;
                    case "BillTo":
                        ENTBillToShip entBillTo = new ENTBillToShip();
                        // Asigna valores
                        entBillTo.BillORShip = 1;
                        BusinessProcess.Object.catBillToShipToBSS bssBillTo = new BusinessProcess.Object.catBillToShipToBSS();
                        oENTResponse = bssBillTo.searchcatBillToShipTocbo(entBillTo);
                        break;
                    case "ShipTo":
                        ENTBillToShip entShipTo = new ENTBillToShip();
                        entShipTo.BillORShip = 2;
                        BusinessProcess.Object.catBillToShipToBSS bssShipto = new BusinessProcess.Object.catBillToShipToBSS();
                        oENTResponse = bssShipto.searchcatBillToShipTocbo(entShipTo);
                        break;
                    case "CentrosdeServicio":
                        ENTCentroServicio entCentrosdeServicio = new ENTCentroServicio();
                        entCentrosdeServicio.idCompany = 1;
                        BPCentroServicio bssCentrosdeServicio = new BPCentroServicio();
                        oENTResponse = bssCentrosdeServicio.searchcatCentrosDeServiciocbo(entCentrosdeServicio);
                        break;
                    case "Clientes":
                        ENTCliente entClientes = new ENTCliente();
                        entClientes.idCompany = 1;
                        BPCliente bssClientes = new BPCliente();
                        oENTResponse = bssClientes.searchcatClientescbo(entClientes);
                        break;
                    case "AgentesAduanales":
                        ENTAgenteAduanal entAgentesaduanales = new ENTAgenteAduanal();
                        entAgentesaduanales.IdCompania = 1;
                        BusinessProcess.Object.catAgentesAduanalesBSS bssAgentesaduanales = new BusinessProcess.Object.catAgentesAduanalesBSS();
                        oENTResponse = bssAgentesaduanales.searchcatAgentesAduanalescbo(entAgentesaduanales);
                        break;

                    case "EstatusPickUp":
                        ENTEstatusPickUp entEstatusPickUp = new ENTEstatusPickUp();
                        BPEstatusPickUp bssEstautsPickUp = new BPEstatusPickUp();

                        entEstatusPickUp.tiActivo = 1;

                        oENTResponse = bssEstautsPickUp.SelectEstatusPickUp(entEstatusPickUp);
                        break;

                    case "EstatusPro":
                        catEstatusPros_Ent entEstatusPros = new catEstatusPros_Ent();
                        catEstatusProsBSS bssEstautsPros = new catEstatusProsBSS();
                        oENTResponse = bssEstautsPros.searchcatEstatusProscbo(entEstatusPros);
                        break;

                    case "EstatusManifiestos":
                        catEstatusManifiestos_Ent entEstatusManifiestos = new catEstatusManifiestos_Ent();
                        catEstatusManifiestosBSS bssEstautsManifiestos = new catEstatusManifiestosBSS();
                        oENTResponse = bssEstautsManifiestos.searchcatEstatusManifiestoscbo(entEstatusManifiestos);
                        break;
                }

                if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
                {
                    oENTResponse.dsResponse.Tables[1].Rows.Add(0, ValorCero);

                    if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
                    {
                        cb.DataSource = oENTResponse.dsResponse.Tables[1];
                        cb.DataValueField = strColValue;
                        cb.DataTextField = strColDisplay;
                        cb.DataBind();
                    }
                }

                //cb.Items.Insert(0, new ListItem(ValorCero, "0"));

                SortDDL(ref cb);
            }
            catch
            { }
            finally
            { }
        }

        internal static void FillCombo(ref System.Web.UI.WebControls.DropDownList cb, string strColValue, string strColDisplay, string Tipo, string Parametro)
        {
            string ValorCero = "---------------";
            System.Data.DataSet ds = new System.Data.DataSet();
            cb.Items.Clear();
            //switch (Tipo)
            //{
            //    case "ICDCapitulos":  //JJGU
            //        ASISTEME_Entity.ICD_Ent entICDCapitulos = new ASISTEME_Entity.ICD_Ent();
            //        ASISTEME_BSS.ICDBSS bssICDCapitulos = new ASISTEME_BSS.ICDBSS();
            //        entICDCapitulos.Catalogo = Parametro;
            //        ds = bssICDCapitulos.searchICDCapituloscbo(entICDCapitulos);
            //        break;
            //    case "ICDGruposServ":  //JJGU
            //        ASISTEME_Entity.ICD_Ent entICDGruposServ = new ASISTEME_Entity.ICD_Ent();
            //        ASISTEME_BSS.ICDBSS bssICDGruposServ = new ASISTEME_BSS.ICDBSS();
            //        entICDGruposServ.Capitulo = Parametro;
            //        ds = bssICDGruposServ.searchICDGruposServcbo(entICDGruposServ);
            //        break;
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows.Add(0, ValorCero);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cb.DataSource = ds;
                    cb.DataValueField = strColValue;
                    cb.DataTextField = strColDisplay;
                    cb.DataBind();
                }
            }
        }

        internal static void FillCombo(ref System.Web.UI.WebControls.DropDownList cb, string strColValue, string strColDisplay, string Tipo, string Parametro, int Para)
        {
            string ValorCero = "---------------";
            System.Data.DataSet ds = new System.Data.DataSet();
            cb.Items.Clear();
            //switch (Tipo)
            //{
            //    case "ICDDiagnostico":  //JJGU
            //        ASISTEME_Entity.ICD_Ent entICDDiagnostico = new ASISTEME_Entity.ICD_Ent();
            //        ASISTEME_BSS.ICDBSS bssICDDiagnostico = new ASISTEME_BSS.ICDBSS();
            //        entICDDiagnostico.Grupo = Parametro;
            //        ds = bssICDDiagnostico.searchICDcboD(entICDDiagnostico);
            //        break;
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows.Add(0, ValorCero);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cb.DataSource = ds;
                    cb.DataValueField = strColValue;
                    cb.DataTextField = strColDisplay;
                    cb.DataBind();
                }
            }

        }

        internal static void FillCombo(ref System.Web.UI.WebControls.DropDownList cb, string strColValue, string strColDisplay, string Tipo, string Parametro, string Parametro2)
        {
            string ValorCero = "---------------";
            System.Data.DataSet ds = new System.Data.DataSet();
            cb.Items.Clear();
            //switch (Tipo)
            //{
            //    case "ICSeccElemProc":  //JJGU
            //        ASISTEME_Entity.ICD_Ent entICSeccElemProc = new ASISTEME_Entity.ICD_Ent();
            //        ASISTEME_BSS.ICDBSS bssICSeccElemProc = new ASISTEME_BSS.ICDBSS();
            //        entICSeccElemProc.Capitulo = Parametro;
            //        entICSeccElemProc.Grupo = Parametro2;
            //        ds = bssICSeccElemProc.searchICDSeccElemProccbo(entICSeccElemProc);
            //        break;
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows.Add(0, ValorCero);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cb.DataSource = ds;
                    cb.DataValueField = strColValue;
                    cb.DataTextField = strColDisplay;
                    cb.DataBind();
                }
            }
        }

        internal static void SortDDL(ref System.Web.UI.WebControls.DropDownList objDDL)
        {
            ArrayList textList = new ArrayList();
            ArrayList valueList = new ArrayList();

            foreach (ListItem li in objDDL.Items)
            {
                textList.Add(li.Text);
            }

            textList.Sort();


            foreach (object item in textList)
            {
                string value = objDDL.Items.FindByText(item.ToString()).Value;
                valueList.Add(value);
            }
            objDDL.Items.Clear();

            for (int i = 0; i < textList.Count; i++)
            {
                ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
                objDDL.Items.Add(objItem);
            }
        }

        internal static void GeneraSemaforo(ref System.Drawing.Image Imagen, int Nivel)
        {
            switch (Nivel)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        ///<remarks>
        ///   <name>Function.GetStandarDate</name>
        ///   <create>29-Octubre-2012</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene una fecha en el formato universal</summary>
        ///<param name="sDate">Fecha a convertir</param>
        ///<param name="sSeparatorDate">Caracter de separación de la fecha</param>
        ///<param name="sTipoFecha">Fecha requerida ini = Inicial, fin = Final, st = Sin Tiempo</param>
        ///<returns>La fecha en formato universal</returns>
        internal static String GetStandarDate(String sDate, Char sSeparatorDate, string sTipoFecha)
        {
            string sDateReturn = "";

            switch (sTipoFecha)
            {
                case "st":
                    sDateReturn = sDate.Split(new Char[] { sSeparatorDate })[2] + "-" + sDate.Split(new Char[] { sSeparatorDate })[1] + "-" + sDate.Split(new Char[] { sSeparatorDate })[0];
                    break;
                case "ini":
                    sDateReturn = sDate.Split(new Char[] { sSeparatorDate })[2] + "-" + sDate.Split(new Char[] { sSeparatorDate })[1] + "-" + sDate.Split(new Char[] { sSeparatorDate })[0] + " " + "00:00";
                    break;
                case "fin":
                    sDateReturn = sDate.Split(new Char[] { sSeparatorDate })[2] + "-" + sDate.Split(new Char[] { sSeparatorDate })[1] + "-" + sDate.Split(new Char[] { sSeparatorDate })[0] + " " + "23:59";
                    break;
                default:
                    sDateReturn = sDate.Split(new Char[] { sSeparatorDate })[2] + "-" + sDate.Split(new Char[] { sSeparatorDate })[1] + "-" + sDate.Split(new Char[] { sSeparatorDate })[0];
                    break;
            }

            return sDateReturn;
        }
    }
}