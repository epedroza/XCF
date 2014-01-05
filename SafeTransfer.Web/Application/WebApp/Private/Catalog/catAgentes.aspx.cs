/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catAgentes
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Agentes Aduanales de la aplicación
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
using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.BusinessProcess.Page;
using SafeTransfer.Entity.Object;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfer.Web.Application.WebApp.Private.Catalog
{
   public partial class catAgentes : BPPage
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
               hddClaveAgenteAduanal.Value = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
               txtClaveAgente.Text = gvApps.SelectedDataKey["ClaveAgenteAduanal"].ToString();
               txtNombre.Text = gvApps.SelectedDataKey["Nombre"].ToString();
               txtRFC.Text = gvApps.SelectedDataKey["RFC"].ToString();
               txtTerminal.Text = gvApps.SelectedDataKey["Terminal"].ToString();
               txtCD.Text = gvApps.SelectedDataKey["CD"].ToString();
               txtDireccion.Text = gvApps.SelectedDataKey["Direccion"].ToString();
               cboCiudad.SelectedValue = gvApps.SelectedDataKey["IdCiudad"].ToString();
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
                   hddClaveAgenteAduanal.Value = "0";
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
           ENTAgenteAduanal ent = new ENTAgenteAduanal();
           catAgentesAduanalesBSS bss = new catAgentesAduanalesBSS();

           // Asignar Valores
           ent.IdCompania = 1;
           ent.ClaveAgenteAduanal = (txtClaveAgente.Text != "" ? Int32.Parse(txtClaveAgente.Text) : 0);
           ent.Nombre = txtNombre.Text;
           ent.RFC = txtRFC.Text;

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatAgentesAduanales(ent);

           gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
           gvApps.DataBind();
       }

       void Fillcbo()
       {
           Utilities.FillCombo(ref cboCiudad, "IdCiudad", "Ciudad", "Ciudades");
       }

       bool ValidaCampos()
       {
           bool Valido = true;
           int Terminal = 0;

           if (txtNombre.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es obligatorio', 'Warning', true); focusControl('" + this.txtNombre.ClientID + "');", true);
               return false;
           }

           if (txtRFC.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [RFC] es obligatorio', 'Warning', true); focusControl('" + this.txtRFC.ClientID + "');", true);
               return false;
           }

           if (txtTerminal.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Terminal] es obligatorio', 'Warning', true); focusControl('" + this.txtTerminal.ClientID + "');", true);
               return false;
           }

           if (!int.TryParse(txtTerminal.Text.Trim(), out Terminal))
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Terminal] debe ser númerico', 'Warning', true); focusControl('" + this.txtTerminal.ClientID + "');", true);
               return false;
           }

           if (txtCD.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [CD] es obligatorio', 'Warning', true); focusControl('" + this.txtCD.ClientID + "');", true);
               return false;
           }

           if (txtDireccion.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dirección] es obligatorio', 'Warning', true); focusControl('" + this.txtDireccion.ClientID + "');", true);
               return false;
           }

           if (cboCiudad.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es obligatorio', 'Warning', true); focusControl('" + this.cboCiudad.ClientID + "');", true);
               return false;
           }

           return Valido;
       }

       void Actualizar(string TipoAccion)
       {
           // Declaracion de variables
           ENTAgenteAduanal ent = new ENTAgenteAduanal();
           catAgentesAduanalesBSS bss = new catAgentesAduanalesBSS();
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

           try
           {
               // Asignar Valores
               ent.IdCompania = 1;
               ent.ClaveAgenteAduanal = Int32.Parse(hddClaveAgenteAduanal.Value);
               ent.Nombre = txtNombre.Text;
               ent.RFC = txtRFC.Text;
               ent.Terminal = Int32.Parse(txtTerminal.Text);
               ent.CD = txtCD.Text;
               ent.Direccion = txtDireccion.Text;
               ent.IdCiudad = Int32.Parse(cboCiudad.SelectedValue);

               // Transaccion
               switch (TipoAccion)
               {
                   case "INSERT":
                       oENTResponse = bss.insertcatAgentesAduanales(ent);
                       break;
                   case "UPDATE":
                       oENTResponse = bss.updatecatAgentesAduanales(ent);
                       break;
                   case "DELETE":
                       oENTResponse = bss.deletecatAgentesAduanales(ent);
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
           txtClaveAgente.Text = "";
           txtNombre.Text = "";
           txtRFC.Text = "";
           txtTerminal.Text = "";
           txtCD.Text = "";
           txtDireccion.Text = "";
           cboCiudad.SelectedValue = "0";
           hddClaveAgenteAduanal.Value = "0";
       }
       #endregion
   }
}