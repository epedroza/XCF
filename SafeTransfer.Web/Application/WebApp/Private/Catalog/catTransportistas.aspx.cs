/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catVendedores
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Transportistas de la aplicación
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
   public partial class catTransportistas : BPPage
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
               hddIdTransportista.Value = gvApps.SelectedDataKey["IdTransportista"].ToString();
               txtIdTransportista.Text = gvApps.SelectedDataKey["IdTransportista"].ToString();
               cboPais.SelectedValue = gvApps.SelectedDataKey["IdPais"].ToString();
               cboEstado.SelectedValue = gvApps.SelectedDataKey["IdEstado"].ToString();
               cboCiudad.SelectedValue = gvApps.SelectedDataKey["IdCiudad"].ToString();
               txtNombre.Text = gvApps.SelectedDataKey["Nombre"].ToString();
               txtRFC.Text = gvApps.SelectedDataKey["RFC"].ToString();
               txtDireccion.Text = gvApps.SelectedDataKey["Direccion"].ToString();
               txtColonia.Text = gvApps.SelectedDataKey["Colonia"].ToString();
               txtRazonSocial.Text = gvApps.SelectedDataKey["RazonSocial"].ToString();
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
                   hddIdTransportista.Value = "0";
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
           ENTTransportista ent = new ENTTransportista();
           catTransportistasBSS bss = new catTransportistasBSS();

           // Asignar Valores
           ent.idCompany = 1;
           ent.idTransportista = (txtIdTransportista.Text != "" ? Int32.Parse(txtIdTransportista.Text) : 0);
           ent.sNombre = txtNombre.Text;
           ent.RFC = txtRFC.Text;
           ent.RazonSocial = txtRazonSocial.Text;

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatTransportistas(ent);

           if (oENTResponse.dsResponse.Tables[1].Rows.Count > 0)
           {
               gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
               gvApps.DataBind();
           }
       }

       void Fillcbo()
       {
           Utilities.FillCombo(ref cboPais, "IdPais", "Pais", "Paises");
           Utilities.FillCombo(ref cboEstado, "IdEstado", "Estado", "Estados");
           Utilities.FillCombo(ref cboCiudad, "IdCiudad", "Ciudad", "Ciudades");
       }

       bool ValidaCampos()
       {
           bool Valido = true;

           if (cboPais.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País] es obligatorio', 'Warning', true); focusControl('" + this.cboPais.ClientID + "');", true);
               return false;
           }

           if (cboEstado.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado] es obligatorio', 'Warning', true); focusControl('" + this.cboEstado.ClientID + "');", true);
               return false;
           }

           if (cboCiudad.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es obligatorio', 'Warning', true); focusControl('" + this.cboCiudad.ClientID + "');", true);
               return false;
           }

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

           if (txtDireccion.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dirección] es obligatorio', 'Warning', true); focusControl('" + this.txtDireccion.ClientID + "');", true);
               return false;
           }

           if (txtColonia.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Colonia] es obligatorio', 'Warning', true); focusControl('" + this.txtColonia.ClientID + "');", true);
               return false;
           }

           if (txtRazonSocial.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Razón Social] es obligatorio', 'Warning', true); focusControl('" + this.txtRazonSocial.ClientID + "');", true);
               return false;
           }

           return Valido;
       }

       void Actualizar(string TipoAccion)
       {
           // Declaracion de variables
           ENTTransportista ent = new ENTTransportista();
           catTransportistasBSS bss = new catTransportistasBSS();
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

           try
           {
               // Asignar Valores
               ent.idCompany = 1;
               ent.idTransportista = Int32.Parse(hddIdTransportista.Value);
               ent.IdPais = Int32.Parse(cboPais.SelectedValue);
               ent.IdEstado = Int32.Parse(cboEstado.SelectedValue);
               ent.IdCiudad = Int32.Parse(cboCiudad.SelectedValue);
               ent.sNombre = txtNombre.Text;
               ent.RFC = txtRFC.Text;
               ent.Direccion = txtDireccion.Text;
               ent.Colonia = txtColonia.Text;
               ent.RazonSocial = txtRazonSocial.Text;

               // Transaccion
               switch (TipoAccion)
               {
                   case "INSERT":
                       oENTResponse = bss.insertcatTransportistas(ent);
                       break;
                   case "UPDATE":
                       oENTResponse = bss.updatecatTransportistas(ent);
                       break;
                   case "DELETE":
                       oENTResponse = bss.deletecatTransportistas(ent);
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
           txtIdTransportista.Text = "";
           cboPais.SelectedValue = "0";
           cboEstado.SelectedValue = "0";
           cboCiudad.SelectedValue = "0";
           txtNombre.Text = "";
           txtRFC.Text = "";
           txtDireccion.Text = "";
           txtColonia.Text = "";
           txtRazonSocial.Text = "";
           hddIdTransportista.Value = "0";
       }

       #endregion
   }
}