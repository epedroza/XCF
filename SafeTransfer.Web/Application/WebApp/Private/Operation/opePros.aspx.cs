using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTransfer.Entity.Object;
using SafeTransfer.BusinessProcess.Object;
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfere.Web.Application.WebApp.Private.Operation
{
    public partial class opePros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Fillcbo();
                if (Request.QueryString["IdPro"].ToString() != "0")
                {
                    txtClavePro.Text = Request.QueryString["IdPro"].ToString();
                    txtProBuacar.Text = Request.QueryString["IdPro"].ToString();
                    Buscar();
                }
                FillGridPros();
                FillGridServicios();
            }
        }

        #region GridgvAppsPros
        protected void gvAppsPros_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvAppsPros_SelectedIndexChanging(object sender, EventArgs e)
        {
        }

        protected void gvAppsPros_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvAppsPros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvAppsPros_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //// Convierte el indice del renglón la propiedad CommandArgument a un int
            //int index = Convert.ToInt32(e.CommandArgument);

            //// Va al renglón que contiene el botón que presionado
            //GridViewRow row = gvApps.Rows[index];

            //gvApps.SelectedIndex = index;

            //if (e.CommandName == "EDITA")
            //{
            //    hddTipoAccion.Value = "UPDATE";
            //    hddClaveAgenteAduanal.Value = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
            //    txtClaveAgente.Text = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
            //    txtNombre.Text = gvApps.SelectedDataKey["Nombre"].ToString();
            //    txtRFC.Text = gvApps.SelectedDataKey["RFC"].ToString();
            //    txtTerminal.Text = gvApps.SelectedDataKey["Terminal"].ToString();
            //    txtCD.Text = gvApps.SelectedDataKey["CD"].ToString();
            //    txtDireccion.Text = gvApps.SelectedDataKey["Direccion"].ToString();
            //    cboCiudad.SelectedValue = gvApps.SelectedDataKey["IdCiudad"].ToString();
            //}

            //if (e.CommandName == "DELETE")
            //{
            //    hddTipoAccion.Value = "DELETE";
            //    Actualizar(hddTipoAccion.Value);
            //}
        }
        #endregion

        #region GridgvAppsServicios
        protected void gvAppsServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvAppsServicios_SelectedIndexChanging(object sender, EventArgs e)
        {
        }

        protected void gvAppsServicios_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvAppsServicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvAppsServicios_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //// Convierte el indice del renglón la propiedad CommandArgument a un int
            //int index = Convert.ToInt32(e.CommandArgument);

            //// Va al renglón que contiene el botón que presionado
            //GridViewRow row = gvApps.Rows[index];

            //gvApps.SelectedIndex = index;

            //if (e.CommandName == "EDITA")
            //{
            //    hddTipoAccion.Value = "UPDATE";
            //    hddClaveAgenteAduanal.Value = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
            //    txtClaveAgente.Text = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
            //    txtNombre.Text = gvApps.SelectedDataKey["Nombre"].ToString();
            //    txtRFC.Text = gvApps.SelectedDataKey["RFC"].ToString();
            //    txtTerminal.Text = gvApps.SelectedDataKey["Terminal"].ToString();
            //    txtCD.Text = gvApps.SelectedDataKey["CD"].ToString();
            //    txtDireccion.Text = gvApps.SelectedDataKey["Direccion"].ToString();
            //    cboCiudad.SelectedValue = gvApps.SelectedDataKey["IdCiudad"].ToString();
            //}

            //if (e.CommandName == "DELETE")
            //{
            //    hddTipoAccion.Value = "DELETE";
            //    Actualizar(hddTipoAccion.Value);
            //}
        }
        #endregion

        #region Rutinas de la Pagina
        protected void cmdBuscarBarra_Click(object sender, ImageClickEventArgs e)
        {
            Buscar();
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void cboIdClaveOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosOrigen();
        }

        protected void cboIdClaveDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosDestino();
        }

        protected void cboIdClaveCFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosCFiscal();
        }

        protected void cboIdClaveAAduanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosAAduanal();
        }

        protected void cboIdClaveCobrarA_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosCobrarA();
        }

        protected void cboIdClaveVendOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosVendedor("ORIGEN");
        }

        protected void cboIdClaveVendDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDatosVendedor("DESTINO");
        }

        #endregion

        #region Rutinas del Programador

        void Buscar()
        {
            // Declaracion de variables
            SafeTransfer.Entity.tblPros_Ent ent = new SafeTransfer.Entity.tblPros_Ent();
            tblProsBSS bss = new tblProsBSS();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.IdPro = (txtProBuacar.Text != "" ? Int32.Parse(txtProBuacar.Text) : 0);
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblPros(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtTerminalPro.Text = ds.Tables[1].Rows[0]["ClaveTerminal"].ToString();
//                    txtFechaCaptura.Text = ds.Tables[1].Rows[0]["FechaCaptura"].ToString();
//                    this.txtFechaCaptura.DisplayDate = ds.Tables[1].Rows[0]["FechaCaptura"].ToString();

                    txtClavePro.Text = ds.Tables[1].Rows[0]["IdPro"].ToString();
                    txtHoraCaptura.Text = ds.Tables[1].Rows[0]["FechaCaptura"].ToString();
                    //txtfechaCargado.Text = ds.Tables[1].Rows[0]["FechaCargado"].ToString();
                    txtHoraCargado.Text = ds.Tables[1].Rows[0]["FechaCargado"].ToString();
                    txtNoFactura.Text = ds.Tables[1].Rows[0]["NoFacturacion"].ToString();
                    txtPickUp.Text = ds.Tables[1].Rows[0]["IdPickUp"].ToString();
                    // Origen
                    cboIdClaveOrigen.SelectedValue = ds.Tables[1].Rows[0]["IdClaveOrigen"].ToString();
                    txtNombreOrigen.Text = ds.Tables[1].Rows[0]["NombreOrigen"].ToString();
                    txtRFCOrigen.Text = ds.Tables[1].Rows[0]["RFCOrigen"].ToString();
                    txtTerminalOrigen.Text = ds.Tables[1].Rows[0]["TerminalOrigen"].ToString();
                    txtCdOrigen.Text = ds.Tables[1].Rows[0]["CdOrigen"].ToString();
                    txtProExterno.Text = ds.Tables[1].Rows[0]["CdOrigen"].ToString();
                    txtDireccionOrigen.Text = ds.Tables[1].Rows[0]["DireccionOrigen"].ToString();
                    txtCiudadOrigen.Text = ds.Tables[1].Rows[0]["CiudadOrigen"].ToString();
                    // Destino
                    cboIdClaveDestino.SelectedValue = ds.Tables[1].Rows[0]["IdClaveDestino"].ToString();
                    txtNombreDestino.Text = ds.Tables[1].Rows[0]["NombreDestino"].ToString();
                    txtRFCDestino.Text = ds.Tables[1].Rows[0]["RFCDestino"].ToString();
                    txtTerminalDestino.Text = ds.Tables[1].Rows[0]["TerminalDestino"].ToString();
                    txtCdDestino.Text = ds.Tables[1].Rows[0]["CdDestino"].ToString();
                    txtDireccionDestino.Text = ds.Tables[1].Rows[0]["DireccionDestino"].ToString();
                    txtCiudadDestino.Text = ds.Tables[1].Rows[0]["CiudadDestino"].ToString();
                    // Cliente Fiscal
                    cboIdClaveCFiscal.SelectedValue = ds.Tables[1].Rows[0]["IdClaveClienteFiscal"].ToString();
                    txtNombreCFiscal.Text = ds.Tables[1].Rows[0]["NombreCFiscal"].ToString();
                    txtRFCCFiscal.Text = ds.Tables[1].Rows[0]["RFCCFiscal"].ToString();
                    txtTerminalCFiscal.Text = ds.Tables[1].Rows[0]["TerminalCFiscal"].ToString();
                    txtCdCFiscal.Text = ds.Tables[1].Rows[0]["CdCFiscal"].ToString();
                    txtDireccionCFiscal.Text = ds.Tables[1].Rows[0]["DireccionCFiscal"].ToString();
                    txtCiudadCFiscal.Text = ds.Tables[1].Rows[0]["CiudadCFiscal"].ToString();
                    // Agente Aduanal
                    cboIdClaveAAduanal.SelectedValue = ds.Tables[1].Rows[0]["IdClaveAgenteAduanal"].ToString();
                    txtNombreAAduanal.Text = ds.Tables[1].Rows[0]["NombreAAduanal"].ToString();
                    txtRFCAAduanal.Text = ds.Tables[1].Rows[0]["RFCAAduanal"].ToString();
                    txtTerminalAAduanal.Text = ds.Tables[1].Rows[0]["TerminalAAduanal"].ToString();
                    txtCdAAduanal.Text = ds.Tables[1].Rows[0]["CdAAduanal"].ToString();
                    txtDireccionAAduanal.Text = ds.Tables[1].Rows[0]["DireccionAAduanal"].ToString();
                    txtCiudadAAduanal.Text = ds.Tables[1].Rows[0]["CiudadAAduanal"].ToString();
                    // Cobrar A
                    cboIdClaveCobrarA.SelectedValue = ds.Tables[1].Rows[0]["IdClaveCobrarA"].ToString();
                    txtNombreCobrarA.Text = ds.Tables[1].Rows[0]["NombreCobrarA"].ToString();
                    txtRFCCobrarA.Text = ds.Tables[1].Rows[0]["RFCCobrarA"].ToString();
                    txtTerminalCobrarA.Text = ds.Tables[1].Rows[0]["TerminalCobrarA"].ToString();
                    txtCdCobrarA.Text = ds.Tables[1].Rows[0]["CdCobrarA"].ToString();
                    //// Ultimo de Encabezado
                    txtCondPago.Text = ds.Tables[1].Rows[0]["IdCondicionesPago"].ToString();
                    cboIdClaveVendOrigen.SelectedValue = ds.Tables[1].Rows[0]["IdVendedorOrigen"].ToString();
                    txtVendedorOrigen.Text = ds.Tables[1].Rows[0]["VendedorOrigen"].ToString();
                    cboIdClaveVendDestino.SelectedValue = ds.Tables[1].Rows[0]["IdVendedorDestino"].ToString();
                    txtVendedorDestino.Text = ds.Tables[1].Rows[0]["VendedorDestino"].ToString();
                    txtTermFac.Text = ds.Tables[1].Rows[0]["TermFact"].ToString();
                    txtPatente.Text = ds.Tables[1].Rows[0]["Patente"].ToString();
                    txtPedimento.Text = ds.Tables[1].Rows[0]["Pedimento"].ToString();
                    if (ds.Tables[1].Rows[0]["Ocurre"].ToString() == "1")
                        chkOcurre.Checked = true;
                    else
                        chkOcurre.Checked = false;
                    txtDiasCredito.Text = ds.Tables[1].Rows[0]["DiasCredito"].ToString();
                    txtPesoTotal.Text = ds.Tables[1].Rows[0]["PesoTotalKg"].ToString();
                    txtPzasTotal.Text = ds.Tables[1].Rows[0]["PiezasTotal"].ToString();
                }
                else
                {
                    Limpiacampos();
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            { }
        }

        void Guardar()
        {
            // Declaracion de variables
            SafeTransfer.Entity.tblPros_Ent ent = new SafeTransfer.Entity.tblPros_Ent();
            tblProsBSS bss = new tblProsBSS();
            DataSet ds = new DataSet();
            try
            {
                //// Asignar Valores
                 if (Valido() == 1)
                 {
                    ent.IdPro = Int32.Parse(txtClavePro.Text);
                    ent.ClaveTerminal = txtTerminalPro.Text;
                    ent.FechaCaptura = System.DateTime.Now;
                    ent.FechaCargado = System.DateTime.Parse(txtFechaCargado.EndDate);
                    ent.IdPickUp = Int32.Parse(txtPickUp.Text);
                    ent.IdClaveOrigen = Int32.Parse(cboIdClaveOrigen.SelectedValue);
                    ent.IdClaveDestino = Int32.Parse(cboIdClaveDestino.SelectedValue);
                    ent.IdClaveClienteFiscal = Int32.Parse(cboIdClaveCFiscal.SelectedValue);
                    ent.IdClaveAgenteAduanal = Int32.Parse(cboIdClaveAAduanal.SelectedValue);
                    ent.IdClaveCobrarA = Int32.Parse(cboIdClaveCobrarA.SelectedValue);
                    ent.IdCondicionesPago = Int32.Parse(txtCondPago.Text);
                    ent.IdVendedorOrigen = Int32.Parse(cboIdClaveVendOrigen.SelectedValue);
                    ent.IdVendedorDestino = Int32.Parse(cboIdClaveVendDestino.SelectedValue);
                    ent.TermFact = Int32.Parse(txtTermFac.Text);
                    ent.Patente = Int32.Parse(txtPatente.Text);
                    ent.Pedimento = txtPedimento.Text;
                    ent.Ocurre = (chkOcurre.Checked == true ? 1 : 0);
                    ent.DiasCredito = Int32.Parse(txtDiasCredito.Text);
                    ent.PesoTotalKg = double.Parse(txtPesoTotal.Text);
                    ent.PiezasTotal = double.Parse(txtPzasTotal.Text);
                }
                 // Transaccion
                 SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.inserttblPros(ent);
                 ds = oENTResponse.dsResponse;

                // Transaccion Deetalle
                // INCLUIR AQUI LA TRANSACCION DEL DETALLE

                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    txtIdManifiesto.Text = ds.Tables[1].Rows[0]["IdManifiesto"].ToString();

                //    FillGrid();
                //}
                //else
                //{
                //    Limpiacampos();
                //}
            }
            catch
            {
            }
            finally
            { }
        }

        void Fillcbo()
        {
            try
            {
                Utilities.FillCombo(ref cboIdClaveCFiscal, "IdCliente", "Nombre", "Clientes");
                Utilities.FillCombo(ref cboIdClaveOrigen, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
                Utilities.FillCombo(ref cboIdClaveDestino, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
                Utilities.FillCombo(ref cboIdClaveAAduanal, "ClaveAgenteAduanal", "Nombre", "AgentesAduanales");
                Utilities.FillCombo(ref cboIdClaveCobrarA, "IdCliente", "Nombre", "Clientes");
                Utilities.FillCombo(ref cboIdClaveVendOrigen, "IdVendedor", "IdVendedor", "Vendedores");
                Utilities.FillCombo(ref cboIdClaveVendDestino, "IdVendedor", "IdVendedor", "Vendedores");
            }
            catch
            { }
            finally
            { }
        }

        void FillGridPros()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            DataRow dr;
            dc = new DataColumn("Numero");
            dt.Columns.Add(dc);
            dc = new DataColumn("Clase");
            dt.Columns.Add(dc);
            dc = new DataColumn("Puesto");
            dt.Columns.Add(dc);
            dc = new DataColumn("MetrosCubicos");
            dt.Columns.Add(dc);
            dc = new DataColumn("PesoKg");
            dt.Columns.Add(dc);
            dc = new DataColumn("Factor");
            dt.Columns.Add(dc);
            dc = new DataColumn("PesoEst");
            dt.Columns.Add(dc);

            dr = dt.NewRow();
            dr[0] = "6";
            dr[1] = "Palets";
            dr[2] = "1,544";
            dr[3] = "Exprimidor de Limones";
            dr[4] = "7.72";
            dr[5] = "300";
            dr[6] = "2,316";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);

            gvAppsPros.DataSource = ds.Tables[0];
            gvAppsPros.DataBind();
        }

        void FillGridServicios()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            DataRow dr;
            dc = new DataColumn("Cargo");
            dt.Columns.Add(dc);
            dc = new DataColumn("Descripcion");
            dt.Columns.Add(dc);
            dc = new DataColumn("Importe");
            dt.Columns.Add(dc);

            dr = dt.NewRow();
            dr[0] = "0001";
            dr[1] = "Flete";
            dr[2] = "3,256";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);

            //////gvAppsServicios.DataSource = ds.Tables[0];
            //////gvAppsServicios.DataBind();
        }

        void FillDatosOrigen()
        {
            // Declaracion de variables
            ENTCentroServicio ent = new ENTCentroServicio();
            BPCentroServicio bss = new BPCentroServicio();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.idCompany = 1;
                ent.idCentroServicio = Int32.Parse(cboIdClaveOrigen.SelectedValue);
                ent.sNombre = "";
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatCentrosDeServicio(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // Origen
                    txtNombreOrigen.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    txtRFCOrigen.Text = ds.Tables[1].Rows[0]["RFC"].ToString();
                    txtTerminalOrigen.Text = ds.Tables[1].Rows[0]["Terminal"].ToString();
                    txtCdOrigen.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                    txtProExterno.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                    txtDireccionOrigen.Text = ds.Tables[1].Rows[0]["Direccion"].ToString();
                    txtCiudadOrigen.Text = ds.Tables[1].Rows[0]["Ciudad"].ToString();
                }
            }
            catch
            { }
            finally
            { }
        }

        void FillDatosDestino()
        {
            // Declaracion de variables
            ENTCentroServicio ent = new ENTCentroServicio();
            BPCentroServicio bss = new BPCentroServicio();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.idCompany = 1;
                ent.idCentroServicio = Int32.Parse(cboIdClaveDestino.SelectedValue);
                ent.sNombre = "";
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatCentrosDeServicio(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // Origen
                    txtNombreDestino.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    txtRFCDestino.Text = ds.Tables[1].Rows[0]["RFC"].ToString();
                    txtTerminalDestino.Text = ds.Tables[1].Rows[0]["Terminal"].ToString();
                    txtCdDestino.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                    txtDireccionDestino.Text = ds.Tables[1].Rows[0]["Direccion"].ToString();
                    txtCiudadDestino.Text = ds.Tables[1].Rows[0]["Ciudad"].ToString();
                }
            }
            catch
            { }
            finally
            { }
        }

        void FillDatosCFiscal()
        {
            // Declaracion de variables
            ENTCliente ent = new ENTCliente();
            BPCliente bss = new BPCliente();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.idCompany = 1;
                ent.idCliente = Int32.Parse(cboIdClaveCFiscal.SelectedValue);
                ent.sNombre = "";
                ent.BillOrShip = 1;
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatClientesBILLSHIP(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // Cliente Fiscal
                    txtNombreCFiscal.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    txtRFCCFiscal.Text = ds.Tables[1].Rows[0]["RFC"].ToString();
                    txtTerminalCFiscal.Text = ds.Tables[1].Rows[0]["Terminal"].ToString();
                    txtCdCFiscal.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                    txtDireccionCFiscal.Text = ds.Tables[1].Rows[0]["Direccion"].ToString();
                    txtCiudadCFiscal.Text = ds.Tables[1].Rows[0]["Ciudad"].ToString();
                }
            }
            catch
            { }
            finally
            { }
        }

        void FillDatosAAduanal()
        {
            // Declaracion de variables
            ENTAgenteAduanal ent = new ENTAgenteAduanal();
            catAgentesAduanalesBSS bss = new catAgentesAduanalesBSS();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.IdCompania = 1;
                ent.ClaveAgenteAduanal = Int32.Parse(cboIdClaveAAduanal.SelectedValue);
                ent.Nombre = "";
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatAgentesAduanales(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // Agente Aduanal
                    txtNombreAAduanal.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    txtRFCAAduanal.Text = ds.Tables[1].Rows[0]["RFC"].ToString();
                    txtTerminalAAduanal.Text = ds.Tables[1].Rows[0]["Terminal"].ToString();
                    txtCdAAduanal.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                    txtDireccionAAduanal.Text = ds.Tables[1].Rows[0]["Direccion"].ToString();
                    txtCiudadAAduanal.Text = ds.Tables[1].Rows[0]["Ciudad"].ToString();
                }
            }
            catch
            { }
            finally
            { }
        }

        void FillDatosVendedor(string TIPOVENDEDOR)
        {
            // Declaracion de variables
            ENTVendedor ent = new ENTVendedor();
            catVendedoresBSS bss = new catVendedoresBSS();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.idCompany = 1;
                 if (TIPOVENDEDOR == "ORIGEN"){
                ent.idVendedor = Int32.Parse(cboIdClaveVendOrigen.SelectedValue);
                }
                 else
                 {
                ent.idVendedor = Int32.Parse(cboIdClaveVendDestino.SelectedValue);
                }
                
                ent.sNombre = "";
                ent.sApellidoPaterno = "";
                ent.sApellidoMaterno = "";

                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatVendedores(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (TIPOVENDEDOR == "ORIGEN")
                    {
                        txtVendedorOrigen.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    }
                    else
                    {
                        txtVendedorDestino.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    }
                }
            }
            catch
            { }
            finally
            { }
        }

        void FillDatosCobrarA()
        {
            // Declaracion de variables
            ENTCliente ent = new ENTCliente();
            BPCliente bss = new BPCliente();
            DataSet ds = new DataSet();
            try
            {
                // Asignar Valores
                ent.idCompany = 1;
                ent.idCliente = Int32.Parse(cboIdClaveCFiscal.SelectedValue);
                ent.sNombre = "";
                ent.BillOrShip = 2;
                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatClientesBILLSHIP(ent);
                ds = oENTResponse.dsResponse;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    // Cobrar A
                    txtNombreCobrarA.Text = ds.Tables[1].Rows[0]["Nombre"].ToString();
                    txtRFCCobrarA.Text = ds.Tables[1].Rows[0]["RFC"].ToString();
                    txtTerminalCobrarA.Text = ds.Tables[1].Rows[0]["Terminal"].ToString();
                    txtCdCobrarA.Text = ds.Tables[1].Rows[0]["Cd"].ToString();
                }
            }
            catch
            { }
            finally
            { }
        }

        void Limpiacampos()
        { 
        
        }

        int Valido()
        {

            return 1;
        }

        #endregion

    }
}

