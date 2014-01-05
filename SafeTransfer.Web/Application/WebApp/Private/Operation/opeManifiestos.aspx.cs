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
   public partial class opeManifiestos : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!Page.IsPostBack)
          {
              if (Request.QueryString["IdManifiesto"].ToString() != "0")
              {
                  txtIdManifiesto.Text = Request.QueryString["IdManifiesto"].ToString();
                  Buscar();
              }

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
      protected void cmdBuscar_Click(object sender, EventArgs e)
      {
          FillGrid();
      }

      protected void cmdBuscarBarra_Click(object sender, ImageClickEventArgs e)
      {

      }

      protected void cmdAgregarPro_Click(object sender, EventArgs e)
      {
          //// Agregar a grid
          //DataTable dt = new DataTable();
          //DataRow dr;
          //DataColumn dc = new DataColumn();

          //dc = new DataColumn("Fecha");
          //dt.Columns.Add(dc);
          //dc = new DataColumn("NotadeEvolucion");
          //dt.Columns.Add(dc);
          //dr = dt.NewRow();

          //dr["Fecha"] = DateTime.Now.ToString("yyyy MM dd  HH:mm:ss");
          //dr["NotadeEvolucion"] = txtNotasEvolucion.Text;
          //dt.Rows.Add(dr);

          //for (int i = 0; i <= gvApps3.Rows.Count - 1; i++)
          //{
          //    dr = dt.NewRow();
          //    dr[0] = Server.HtmlEncode(gvApps3.Rows[i].Cells[0].Text);
          //    dr[1] = Server.HtmlEncode(gvApps3.Rows[i].Cells[1].Text);
          //    dt.Rows.Add(dr);
          //}

          //DataSet dsA = new DataSet();
          //dsA.Tables.Add(dt);

          //gvApps3.DataSource = dsA;
          //gvApps3.DataBind();
      }

      protected void cmdGuardar_Click(object sender, EventArgs e)
      {
          Guardar();
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
                  txtFechaSalida.Text = ds.Tables[1].Rows[0]["FechaSalida"].ToString();
                  txtFechaArribo.Text = ds.Tables[1].Rows[0]["FechaLlegada"].ToString();

                  FillGrid();
              }
              else
              {
                  Limpiacampos();
              }
          }
          catch (Exception ex)
          {
              throw(ex);
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
              ent.FechaSalida = System.DateTime.Parse(txtFechaSalida.Text);
              ent.FechaLlegada = System.DateTime.Parse(txtFechaArribo.Text);

              // Transaccion
              SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.inserttblManifiestosHdr(ent);
              ds = oENTResponse.dsResponse;

              // Transaccion Deetalle
              // INCLUIR AQUI LA TRANSACCION DEL DETALLE

              if (ds.Tables[1].Rows.Count > 0)
              {
                  txtIdManifiesto.Text = ds.Tables[1].Rows[0]["IdManifiesto"].ToString();

                  FillGrid();
              }
              else
              {
                  Limpiacampos();
              }
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
              Utilities.FillCombo(ref cboIdClaveOrigen, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
              Utilities.FillCombo(ref cboIdClaveDestino, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
              Utilities.FillCombo(ref cboOrigen, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
              Utilities.FillCombo(ref cboDestino, "IdCentroDeServicio", "sNombre", "CentrosdeServicio");
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
      }

      void Limpiacampos()
      { 
      
      }

      #endregion

   }
}