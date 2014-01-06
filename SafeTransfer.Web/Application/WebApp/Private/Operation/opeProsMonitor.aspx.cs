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
   public partial class opeProsMonitor : System.Web.UI.Page
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
               Response.Redirect("opePros.aspx?IdPro=" + gvApps.SelectedDataKey["IdPro"].ToString());
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
           Response.Redirect("opePros.aspx?IdPro=0");
       }
       #endregion

       #region Rutinas del Programador
       void FillGrid()
       {
           // Declaracion de variables
           SafeTransfer.Entity.tblPros_Ent ent = new SafeTransfer.Entity.tblPros_Ent();
           tblProsBSS bss = new tblProsBSS();

           try
           {

               // Asignar Valores
               ent.IdPro = (txtIdPro.Text != "" ? Int32.Parse(txtIdPro.Text) : 0);
               ent.IdPickUp = (txtIdPickUp.Text != "" ? Int32.Parse(txtIdPickUp.Text) : 0);
               ent.IdClaveOrigen = (cboOrigen.SelectedValue != "0" ? Int32.Parse(cboOrigen.SelectedValue) : 0);
               ent.IdClaveDestino = (cboDestino.SelectedValue != "0" ? Int32.Parse(cboDestino.SelectedValue) : 0);
               ent.Pedimento = txtPedimento.Text;
               ent.FechaCargoInicial = System.DateTime.Parse(wucFechaInicial.BeginDate);
               ent.FechaCargoFinal = System.DateTime.Parse(WucFechaFinal.EndDate);
               ent.Estatus = Int32.Parse(cboEstatus.SelectedValue);

               // Transaccion
               SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchtblProsMonitor(ent);

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
           catch { }
           finally { }
       }

       void Fillcbo()
       {
           try
           {
               Utilities.FillCombo(ref cboOrigen, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               Utilities.FillCombo(ref cboDestino, "IdCentroDeServicio", "Nombre", "CentrosdeServicio");
               Utilities.FillCombo(ref cboClientes, "IdCliente", "Nombre", "Clientes");
               Utilities.FillCombo(ref cboEstatus, "IdEstatus", "Estatus", "EstatusPro");
           }
           catch { }
           finally { }
       }

       #endregion

   }
}