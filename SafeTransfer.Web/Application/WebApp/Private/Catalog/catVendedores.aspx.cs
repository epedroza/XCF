/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catVendedores
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Vendedores de la aplicación
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
   public partial class catVendedores : BPPage
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
               hddIdVendendor.Value = gvApps.SelectedDataKey["IdVendedor"].ToString();
               txtIdVendedor.Text = gvApps.SelectedDataKey["IdVendedor"].ToString();
               txtNombre.Text = gvApps.SelectedDataKey["Nombre"].ToString();
               txtApellidoPaterno.Text = gvApps.SelectedDataKey["ApellidoPaterno"].ToString();
               txtApellidoMaterno.Text = gvApps.SelectedDataKey["ApellidoMaterno"].ToString();
               txtDireccion.Text = gvApps.SelectedDataKey["Direccion"].ToString();
               cboPais.SelectedValue = gvApps.SelectedDataKey["IdPais"].ToString();
               cboEstado.SelectedValue = gvApps.SelectedDataKey["IdEstado"].ToString();
               cboCiudad.SelectedValue = gvApps.SelectedDataKey["IdCiudad"].ToString();
               txtCP.Text = gvApps.SelectedDataKey["CP"].ToString();
               txtTelefono1.Text = gvApps.SelectedDataKey["Telefono1"].ToString();
               txtTelefono2.Text = gvApps.SelectedDataKey["Telefono2"].ToString();
               txtCorreo.Text = gvApps.SelectedDataKey["Correo"].ToString();
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
                   hddIdVendendor.Value = "0";
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
           ENTVendedor ent = new ENTVendedor();
           catVendedoresBSS bss = new catVendedoresBSS();

           // Asignar Valores
           ent.idCompany = 1;
           ent.idVendedor = (txtIdVendedor.Text != "" ? Int32.Parse(txtIdVendedor.Text) : 0);
           ent.sNombre = txtNombre.Text;
           ent.sApellidoPaterno = txtApellidoPaterno.Text;
           ent.sApellidoMaterno = txtApellidoMaterno.Text;

           // Transaccion
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatVendedores(ent);

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

           if (txtNombre.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es obligatorio', 'Warning', true); focusControl('" + this.txtNombre.ClientID + "');", true);
               return false;
           }

           if (txtApellidoPaterno.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Apellido Paterno] es obligatorio', 'Warning', true); focusControl('" + this.txtApellidoPaterno.ClientID + "');", true);
               return false;
           }

           if (txtApellidoMaterno.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [NoApellido Maternombre] es obligatorio', 'Warning', true); focusControl('" + this.txtApellidoMaterno.ClientID + "');", true);
               return false;
           }

           if (txtDireccion.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dirección] es obligatorio', 'Warning', true); focusControl('" + this.txtDireccion.ClientID + "');", true);
               return false;
           }

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

           if (txtCP.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [CP] es obligatorio', 'Warning', true); focusControl('" + this.txtCP.ClientID + "');", true);
               return false;
           }

           if (txtTelefono1.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono 1] es obligatorio', 'Warning', true); focusControl('" + this.txtTelefono1.ClientID + "');", true);
               return false;
           }

           if (txtTelefono2.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono 2] es obligatorio', 'Warning', true); focusControl('" + this.txtTelefono2.ClientID + "');", true);
               return false;
           }

           if (txtCorreo.Text == "")
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Correo] es obligatorio', 'Warning', true); focusControl('" + this.txtCorreo.ClientID + "');", true);
               return false;
           }

           return Valido;
       }

       void Actualizar(string TipoAccion)
       {
           // Declaracion de variables
           ENTVendedor ent = new ENTVendedor();
           catVendedoresBSS bss = new catVendedoresBSS();
           SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

           try
           {
               // Asignar Valores
               ent.idCompany = 1;
               ent.idVendedor = Int32.Parse(hddIdVendendor.Value);
               ent.sNombre = txtNombre.Text;
               ent.sApellidoPaterno = txtApellidoPaterno.Text;
               ent.sApellidoMaterno = txtApellidoMaterno.Text;
               ent.sDireccion = txtDireccion.Text;
               ent.idPais = Int32.Parse(cboPais.SelectedValue);
               ent.idEstado = Int32.Parse(cboEstado.SelectedValue);
               ent.idCiudad = Int32.Parse(cboCiudad.SelectedValue);
               ent.sCP = txtCP.Text;
               ent.sTelefono1 = txtTelefono1.Text;
               ent.sTelefono2 = txtTelefono2.Text;
               ent.sCorreo = txtCorreo.Text;

               // Transaccion
               switch (TipoAccion)
               {
                   case "INSERT":
                       oENTResponse = bss.insertcatVendedores(ent);
                       break;
                   case "UPDATE":
                       oENTResponse = bss.updatecatVendedores(ent);
                       break;
                   case "DELETE":
                       oENTResponse = bss.deletecatVendedores(ent);
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
           txtIdVendedor.Text = "";
           txtNombre.Text = "";
           txtApellidoPaterno.Text = "";
           txtApellidoMaterno.Text = "";
           txtDireccion.Text = "";
           cboPais.SelectedValue = "0";
           cboEstado.SelectedValue = "0";
           cboCiudad.SelectedValue = "0";
           txtCP.Text = "";
           txtTelefono1.Text = "";
           txtTelefono2.Text = "";
           txtCorreo.Text = "";
           hddIdVendendor.Value = "0";
       }

       #endregion
   }
}