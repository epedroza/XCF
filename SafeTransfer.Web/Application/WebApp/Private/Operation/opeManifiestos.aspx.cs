using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTransfer.Entity.Object;
using SafeTransfer.Entity;
using SafeTransfer.BusinessProcess.Object;
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfere.Web.Application.WebApp.Private.Operation
{
   public partial class opeManifiestos : System.Web.UI.Page
   {
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!Page.IsPostBack)
           {
               Fillcbo();
               if (Request.QueryString["IdManifiesto"].ToString() != "0")
               {
                   txtIdManifiesto.Text = Request.QueryString["IdManifiesto"].ToString();
                   hddIdManifiesto.Value = Request.QueryString["IdManifiesto"].ToString();
                   Buscar();
                   FillGridSelPros();
               }
               else
               {
                   gvApps.DataSource = null;
                   gvApps.DataBind();

                   gvAppsSelPros.DataSource = null;
                   gvAppsSelPros.DataBind();
               }
           }
       }

       #region GridgvApps
       protected void gvApps_SelectedIndexChanged(object sender, EventArgs e)
       {
       }

       protected void gvApps_SelectedIndexChanging(object sender, EventArgs e)
       {
       }

       protected void gvApps_PageIndexChanging(Object sender, GridViewPageEventArgs e)
       {
       }

       protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
       {
       }

       protected void gvApps_RowCommand(Object sender, GridViewCommandEventArgs e)
       {
           //// Convierte el indice del renglón la propiedad CommandArgument a un int
           int index = Convert.ToInt32(e.CommandArgument);
           DataSet ds = new DataSet();
           tblManifiestosDet_Ent ent = new tblManifiestosDet_Ent();
           tblManifiestosDetBSS bss = new tblManifiestosDetBSS();

           // Va al renglón que contiene el botón que presionado
           GridViewRow row = gvApps.Rows[index];

           gvApps.SelectedIndex = index;

           if (e.CommandName == "ELIMINA")
           {
               // Asigna valores
               hddTipoAccion.Value = "DELETE";
               ent.IdManifiesto = Int32.Parse(txtIdManifiesto.Text);
               ent.Pro = Int32.Parse(gvApps.SelectedDataKey["IdPro"].ToString());

               //Transaccion
               SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.deletetblManifiestosDet(ent);
               ds = oENTResponse.dsResponse;
           }

           //if (e.CommandName == "DELETE")
           //{
           //    hddTipoAccion.Value = "DELETE";
           //    Actualizar(hddTipoAccion.Value);
           //}
       }
       #endregion

       #region GridgvAppsSelPros
       protected void gvAppsSelPros_SelectedIndexChanged(object sender, EventArgs e)
       {
       }

       protected void gvAppsSelPros_SelectedIndexChanging(object sender, EventArgs e)
       {
       }

       protected void gvAppsSelPros_PageIndexChanging(Object sender, GridViewPageEventArgs e)
       {
       }

       protected void gvAppsSelPros_RowDataBound(object sender, GridViewRowEventArgs e)
       {
       }

       protected void gvAppsSelPros_RowCommand(Object sender, GridViewCommandEventArgs e)
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

       protected void cboIdClaveOrigen_SelectedIndexChanged(object sender, EventArgs e)
       {
           FillGridSelPros();
       }

       protected void cmdBuscar_Click(object sender, EventArgs e)
       {
           FillGrid();
       }

       protected void cmdBuscarBarra_Click(object sender, ImageClickEventArgs e)
       {

       }

       protected void cmdGuardar_Click(object sender, EventArgs e)
       {
           Guardar();
       }

       protected void cmdGuardarManifiesto(object sender, EventArgs e)
       {
           if (ValidaCampos() == 1)
           Guardar();
       }

       protected void cmdAgregarPartidas_Click(object sender, EventArgs e)
       {
           if(txtIdManifiesto.Text !="")
               pnlDetallePros.Visible = true;
           else
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debe guardar el manifiesto antes de seleccionar los pros')", true);
       }

       protected void cmdCerrar_Click(object sender, EventArgs e)
       {
           pnlDetallePros.Visible = false;
       }

       protected void cmdAceptar_Click(object sender, EventArgs e)
       {
           if (txtIdManifiesto.Text != "")
           {
               GuardaProsSeleccionados();
               FillGrid();
               pnlDetallePros.Visible = false;
           }
           else
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debe guardar el manifiesto antes de seleccionar los pros')", true);
           }
       }

       protected void chkSelecciona_CheckedChanged(object sender, EventArgs e)
       {

       }

       protected void chkTodos_CheckedChanged(object sender, EventArgs e)
       {
           CheckBox chk;
           foreach (GridViewRow Row in gvAppsSelPros.Rows)
           {
               chk = (CheckBox)(Row.Cells[0].FindControl("chkSelecciona"));
               chk.Checked = ((CheckBox)sender).Checked;
           }
       }

       #endregion

       #region Rutinas del Programador

       void Buscar()
       {
           // Declaracion de variables
           SafeTransfer.Entity.tblManifiestosHdr_Ent ent = new SafeTransfer.Entity.tblManifiestosHdr_Ent();
           tblManifiestosHdrBSS bss = new tblManifiestosHdrBSS();
           DataSet ds = new DataSet();
           try
           {
               // Asignar Valores
               ent.IdManifiesto = (txtIdManifiesto.Text != "" ? Int32.Parse(txtIdManifiesto.Text) : 0);
               // Transaccion
               SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblManifiestosHdr(ent);
               ds = oENTResponse.dsResponse;

               if (ds.Tables[1].Rows.Count > 0)
               {
                   cboIdClaveOrigen.SelectedValue = ds.Tables[1].Rows[0]["ClaveOrigen"].ToString();
                   cboIdClaveDestino.SelectedValue = ds.Tables[1].Rows[0]["ClaveDestino"].ToString();
                   txtNoTractor.Text = ds.Tables[1].Rows[0]["NoTractor"].ToString();
                   txtNoCaja1.Text = ds.Tables[1].Rows[0]["NoCaja1"].ToString();
                   txtNoCaja2.Text = ds.Tables[1].Rows[0]["NoCaja2"].ToString();
                   txtPropio.Text = ds.Tables[1].Rows[0]["TractorPropio"].ToString();
                   txtClaveOperador.Text = ds.Tables[1].Rows[0]["CveOperador"].ToString();
                   //txtFechaSalida.Text = ds.Tables[1].Rows[0]["FechaSalida"].ToString();
                   //txtFechaArribo.Text = ds.Tables[1].Rows[0]["FechaLlegada"].ToString();

                   FillGrid();
               }
               else
               {
                   Limpiacampos();
               }
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           { }
       }

       void Guardar()
       {
           // Declaracion de variables
           SafeTransfer.Entity.tblManifiestosHdr_Ent ent = new SafeTransfer.Entity.tblManifiestosHdr_Ent();
           tblManifiestosHdrBSS bss = new tblManifiestosHdrBSS();
           DataSet ds = new DataSet();
           try
           {
               // Asignar Valores
               ent.IdManifiesto = (txtIdManifiesto.Text != "" ? Int32.Parse(txtIdManifiesto.Text) : 0);
               ent.ClaveOrigen = Int32.Parse(cboIdClaveOrigen.SelectedValue);
               ent.ClaveDestino = Int32.Parse(cboIdClaveDestino.SelectedValue);
               ent.NoTractor = Int32.Parse(txtNoTractor.Text);
               ent.NoCaja1 = Int32.Parse(txtNoCaja1.Text);
               ent.NoCaja2 = Int32.Parse(txtNoCaja2.Text);
               ent.TractorPropio = Int32.Parse(txtPropio.Text);
               ent.Caja1Propia = 1;
               ent.Caja2Propia = 1;
               ent.CveOperador = Int32.Parse(txtClaveOperador.Text);
               ent.FechaSalida = System.DateTime.Parse(txtFechaSalida.DisplayDate);
               ent.FechaLlegada = System.DateTime.Parse(txtFechaArribo.DisplayDate);

               // Transaccion
               SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.inserttblManifiestosHdr(ent);
               ds = oENTResponse.dsResponse;

               if (ds.Tables[1].Rows.Count > 0)
               {
                   txtIdManifiesto.Text = ds.Tables[1].Rows[0]["IdManifiesto"].ToString();
                   hddIdManifiesto.Value = ds.Tables[1].Rows[0]["IdManifiesto"].ToString();

                   //FillGrid();
               }
               else
               {
                   Limpiacampos();
               }
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           finally
           { }
       }

       void GuardaProsSeleccionados()
       {
           // Declaracion de variables
           int Contador = 0;
           DataSet ds = new DataSet();
           tblManifiestosDet_Ent ent = new tblManifiestosDet_Ent();
           tblManifiestosDetBSS bss = new tblManifiestosDetBSS();

           for (int i = 0; i <= gvAppsSelPros.Rows.Count - 1; i++)
           {
               GridViewRow Row = gvAppsSelPros.Rows[i];
               bool isChecked = ((CheckBox)Row.FindControl("chkSelecciona")).Checked;

               gvAppsSelPros.SelectedIndex = i;

               if (isChecked)
               {
                   if (Contador == 0)
                   {
                       //if (ValidaCampos() == 1)
                       //{
                       //    Guardar();
                       //    Contador++;
                       //}
                   }
                   // Asigna valores
                   ent.IdManifiesto = Int32.Parse(hddIdManifiesto.Value);
                   ent.Pro = Int32.Parse(gvAppsSelPros.SelectedDataKey["IdPro"].ToString());
                   ent.OrigenPro = Int32.Parse(gvAppsSelPros.SelectedDataKey["IdOrigenPro"].ToString());
                   ent.DestinoPro = Int32.Parse(gvAppsSelPros.SelectedDataKey["IdDestinoPro"].ToString());
                   //ent.NoCaja = Int32.Parse(gvApps.SelectedDataKey["NoCaja"].ToString());

                   // Guarda pros seleccionados
                   // Transacción
                   SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.inserttblManifiestosDet(ent);
                   ds = oENTResponse.dsResponse;
               }
           }

           // Llenar Grid principal
           FillGrid();

       }

       void Fillcbo()
       {
           try
           {
               Utilities.FillCombo(ref cboIdClaveOrigen, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               Utilities.FillCombo(ref cboIdClaveDestino, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               //Utilities.FillCombo(ref cboOrigen, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               //Utilities.FillCombo(ref cboDestino, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               Utilities.FillCombo(ref cboEstatus, "IdEstatus", "Estatus", "EstatusManifiestos");
           }
           catch
           { }
           finally
           { }
       }

       void FillGrid()
       {
           // Declaracion de variables
           SafeTransfer.Entity.tblManifiestosDet_Ent ent = new SafeTransfer.Entity.tblManifiestosDet_Ent();
           tblManifiestosDetBSS bss = new tblManifiestosDetBSS();

           // Asignar Valores
           ent.IdManifiesto = (txtIdManifiesto.Text != "0" ? Int32.Parse(txtIdManifiesto.Text) : 0);

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblManifiestosDet(ent);

           if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
           {
               gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
               gvApps.DataBind();
           }
           else
           {
               gvApps.DataSource = null;
               gvApps.DataBind();
           }
       }

       void FillGridSelPros()
       {
           // Declaracion de variables
           SafeTransfer.Entity.tblPros_Ent ent = new SafeTransfer.Entity.tblPros_Ent();
           tblProsBSS bss = new tblProsBSS();

           // Asignar Valores
           ent.IdClaveOrigen = (cboIdClaveOrigen.SelectedValue != "0" ? Int32.Parse(cboIdClaveOrigen.SelectedValue) : 0);

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblProsOrigen(ent);

           if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
           {
               gvAppsSelPros.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
               gvAppsSelPros.DataBind();
           }
           else
           {
               gvAppsSelPros.DataSource = null;
               gvAppsSelPros.DataBind();
           }
       }

       void Limpiacampos()
       {

       }

       int ValidaCampos()
       {
           int Valido = 1;

           //if (txtIdManifiesto.Text == "") { Valido = 0; }
           if (cboIdClaveOrigen.SelectedValue == "0") { Valido = 0; }
           if (cboIdClaveDestino.SelectedValue == "0") { Valido = 0; }
           if (txtNoTractor.Text == "") { Valido = 0; }
           if (txtPropio.Text == "") { Valido = 0; }
           //if (txtClaveOperador.Text == "") { Valido = 0; }
           //if (txtNoCaja1.Text == "") { Valido = 0; }

           return Valido;
       }

       #endregion


   }
}