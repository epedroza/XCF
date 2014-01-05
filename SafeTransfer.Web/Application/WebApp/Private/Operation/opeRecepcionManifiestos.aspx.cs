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
   public partial class opeRecepcionManifiestos : System.Web.UI.Page
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

      }
      #endregion

      #region Rutinas de la Pagina
      protected void cmdBuscar_Click(object sender, EventArgs e)
      {
          FillGrid();
      }

      #endregion

      #region Rutinas del Programador

      void FillGrid()
      {
          
      }

      void Fillcbo()
      {

      }

      #endregion

   }
}