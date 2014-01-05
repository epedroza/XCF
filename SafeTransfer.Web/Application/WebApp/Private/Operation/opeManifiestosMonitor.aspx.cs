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
   public partial class opeManifiestosMonitor : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!Page.IsPostBack)
          {
              Fillcbo();
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
          // Convierte el indice del renglón la propiedad CommandArgument a un int
          int index = Convert.ToInt32(e.CommandArgument);

          // Va al renglón que contiene el botón que presionado
          GridViewRow row = gvApps.Rows[index];

          gvApps.SelectedIndex = index;

          if (e.CommandName == "EDITA")
          {
              Response.Redirect("opeManifiestos.aspx?IdManifiesto=" + gvApps.SelectedDataKey["IdManifiesto"].ToString());
          }
      }
      #endregion

      #region Rutinas de la Pagina
      protected void cmdBuscar_Click(object sender, EventArgs e)
      {
          FillGrid();
      }

      protected void cmdNuevo_Click(object sender, EventArgs e)
      {
          Response.Redirect("opeManifiestos.aspx?IdManifiesto=0");
      }
      #endregion

      #region Rutinas del Programador

      void FillGrid()
      {
          // Declaracion de variables
          SafeTransfer.Entity.tblManifiestosHdr_Ent ent = new SafeTransfer.Entity.tblManifiestosHdr_Ent();
          tblManifiestosHdrBSS bss = new tblManifiestosHdrBSS();

          // Asignar Valores
          ent.IdCompania = 1;
          ent.ClaveOrigen = (cboOrigen.SelectedValue != "0" ? Int32.Parse(cboOrigen.SelectedValue) : 0);
          ent.ClaveDestino = (cboDestino.SelectedValue != "0" ? Int32.Parse(cboDestino.SelectedValue) : 0);
          ent.NoTractor = (txtNoTractor.Text != "" ? Int32.Parse(txtNoTractor.Text) : 0);
          ent.TractorPropio = (txtPropio.Text !="" ? Int32.Parse(txtPropio.Text) : 0);

          // Transaccion
          SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblManifiestosHdrMonitor(ent);

          if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
          {
              gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
              gvApps.DataBind();
          }
      }
            
      void Fillcbo()
      {
          Utilities.FillCombo(ref cboOrigen, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
          Utilities.FillCombo(ref cboDestino, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
          Utilities.FillCombo(ref cboEstatus, "IdEstatus", "Estatus", "EstatusManifiestos");
      }

      #endregion

   }
}