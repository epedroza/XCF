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
   public partial class opePickUpMonitor : System.Web.UI.Page
   {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
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
                Int16 Row = 0;
                Int16 PickUp = 0;
                Int16 idEstatusPickUp = 0;

                Row = Int16.Parse(e.CommandArgument.ToString());
                PickUp = Int16.Parse(gvApps.DataKeys[Row]["idPickUp"].ToString());
                idEstatusPickUp = Int16.Parse(gvApps.DataKeys[Row]["idEstatusPickUp"].ToString());

                if (e.CommandName == "Select")
                    ProgramarPickUp.PageLoad(PickUp, idEstatusPickUp);
            }
        #endregion

        #region Rutinas de la Pagina
            protected void cmdBuscar_Click(object sender, EventArgs e)
            {
                FillGrid();
            }

            protected void cmdNuevo_Click(object sender, EventArgs e)
            {
                Response.Redirect("opeProgPickUps.aspx?IdPickUp=0");
            }
      #endregion

        #region Rutinas del Programador
            public void FillGrid()
            {
                // Declaracion de variables
                ENTPickUp ent = new ENTPickUp();
                BPPickUp bss = new BPPickUp();

                // Asignar Valores
                ent.idPickUp = (txtIdPickUp.Text !="" ? Int32.Parse(txtIdPickUp.Text) : 0);
                ent.idCompany = 2;
                ent.FechaEstimada = DateTime.Parse(wucCalendarInicio.BeginDate);
                ent.FechaRecoleccion = DateTime.Parse(wucCalendarFinal.EndDate);
                ent.idEstatusPickUp = int.Parse(cboEstatus.SelectedValue);

                // Transaccion
                SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.SelectPickUpMonitor(ent);

                if (oENTResponse.dsResponse.Tables[0].Rows.Count > 0)
                {
                    gvApps.DataSource = oENTResponse.dsResponse.Tables[0].DefaultView;
                    gvApps.DataBind();
                }
            }

            void Fillcbo()
            {
                Utilities.FillCombo(ref cboCliente, "IdCliente", "Nombre", "Clientes");
                Utilities.FillCombo(ref cboEstatus, "idEstatusPickUp", "sNombre", "EstatusPickUp");
            }

            private void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    wucCalendarInicio.SetDate(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));

                    Fillcbo();
                    //FillGrid();
                }
            }
        #endregion
   }
}