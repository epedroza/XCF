/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catCamiones
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Camiones de la aplicación
'
' Notas:
'				Hereda de la clase base SafeTransfer.BusinessProcess.Page.BPPage
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SafeTransfer.BusinessProcess.Page;
using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.Entity.Object;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfer.Web.Application.WebApp.Private.Catalog
{
   public partial class catCamiones : BPPage
   {
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!Page.IsPostBack)
           {
               // Se inicia la pantalla con un registro nuevo y cargando todos los registros existentes en el grid
               hddTipoAccion.Value = "INSERT";
               LimpiaCampos();
               Fillcbo();
               FillGrid();
           }
       }

       #region Grid
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
               hddTipoAccion.Value = "UPDATE";
               hddIdCamion.Value = gvApps.SelectedDataKey["IdCamion"].ToString();
               txtIdCamion.Text = gvApps.SelectedDataKey["IdCamion"].ToString();
               cboTipoCamion.SelectedValue = gvApps.SelectedDataKey["IdTipoCamion"].ToString();
               txtCamion.Text = gvApps.SelectedDataKey["Camion"].ToString();
               txtCapacidadM3.Text = gvApps.SelectedDataKey["CapacidadM3"].ToString();
               txtCapacidadKg.Text = gvApps.SelectedDataKey["CapacidadKg"].ToString();
           }

           if (e.CommandName == "DELETE")
           {
               hddTipoAccion.Value = "DELETE";
               Actualizar(hddTipoAccion.Value);
           }
       }
       #endregion

       #region Rutinas de la pagina

       protected void btnBuscar_Click(object sender, EventArgs e)
       {
           Buscar();
       }

       protected void btnGuardar_Click(object sender, EventArgs e)
       {
           try
           {
               if (ValidaCampos() == true)
               {
                   Actualizar(hddTipoAccion.Value);
                   LimpiaCampos();
                   FillGrid();
                   hddTipoAccion.Value = "INSERT";
                   hddIdCamion.Value = "0";
               }
           }
           catch
           {

           }
           finally
           { }
       }

       protected void btnNuevo_Click(object sender, EventArgs e)
       {
           hddTipoAccion.Value = "INSERT";
           LimpiaCampos();
           FillGrid();
       }

       #endregion

       #region Rutinas del programador

       void FillGrid()
       {
           // Declaracion de variables
           ENTCamion ent = new ENTCamion();
           catCamionesBSS bss = new catCamionesBSS();

           // Asignar Valores
           ent.idCompany = 1;
           ent.idCamion = (txtIdCamion.Text != "" ? Int32.Parse(txtIdCamion.Text) : 0);
           ent.IdTipoCamion = (cboTipoCamion.SelectedValue != "0" ? Int32.Parse("0" + cboTipoCamion.SelectedValue) : 0);
           ent.sNombre = txtCamion.Text;

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatCamiones(ent);

           if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
           {
               gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
               gvApps.DataBind();
           }
       }

       void Fillcbo()
       {
           Utilities.FillCombo(ref cboTipoCamion, "IdTipoCamion", "TipoCamion", "TiposCamiones");
       }

       bool ValidaCampos()
       {
           bool Valido = true;
           decimal Valor = 0;

           if (cboTipoCamion.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Tipo de Camión] es obligatorio', 'Warning', true); focusControl('" + this.cboTipoCamion.ClientID + "');", true);
               return false;
           }

           if (txtCamion.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Camión] es obligatorio', 'Warning', true); focusControl('" + this.txtCamion.ClientID + "');", true);
               return false;
           }

           if (txtCapacidadM3.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Capacidad M3] es obligatorio', 'Warning', true); focusControl('" + this.txtCapacidadM3.ClientID + "');", true);
               return false;
           }

           if (!decimal.TryParse(txtCapacidadM3.Text.Trim(), out Valor))
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Capacidad M3] debe ser numérico', 'Warning', true); focusControl('" + this.txtCapacidadM3.ClientID + "');", true);
               return false;
           }

           if (txtCapacidadKg.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Capacidad Kg] es obligatorio', 'Warning', true); focusControl('" + this.txtCapacidadKg.ClientID + "');", true);
               return false;
           }

           if (!decimal.TryParse(txtCapacidadKg.Text.Trim(), out Valor))
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Capacidad Kg] debe ser numérico', 'Warning', true); focusControl('" + this.txtCapacidadKg.ClientID + "');", true);
               return false;
           }

           return Valido;

       }

       void Actualizar(string TipoAccion)
       {
           // Declaracion de variables
           ENTCamion ent = new ENTCamion();
           catCamionesBSS bss = new catCamionesBSS();
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

           try
           {
               // Asignar Valores
               ent.idCompany = 1;
               ent.idCamion = Int32.Parse(hddIdCamion.Value);
               ent.sNombre = txtCamion.Text;
               ent.IdTipoCamion = Int32.Parse(cboTipoCamion.SelectedValue);
               ent.CapacidadM3 = Decimal.Parse(txtCapacidadM3.Text);
               ent.CapacidadKg = Decimal.Parse(txtCapacidadKg.Text);

               // Transaccion
               switch (TipoAccion)
               {
                   case "INSERT":
                       oENTResponse = bss.insertcatCamiones(ent);
                       break;
                   case "UPDATE":
                       oENTResponse = bss.updatecatCamiones(ent);
                       break;
                   case "DELETE":
                       oENTResponse = bss.deletecatCamiones(ent);
                       break;
               }
           }
           catch
           { }
           finally
           { }

       }

       void Buscar()
       {
           FillGrid();
       }

       void LimpiaCampos()
       {
           txtIdCamion.Text = "";
           cboTipoCamion.SelectedValue = "0";
           txtCamion.Text = "";
           txtCapacidadM3.Text = "";
           txtCapacidadKg.Text = "";
           hddIdCamion.Value = "0";
       }

       #endregion
   }
}