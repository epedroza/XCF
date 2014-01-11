/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatCliente
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Clientes de la aplicación
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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.BusinessProcess.Page;
using SafeTransfer.Entity.Object;
using System.Data;

namespace SafeTransfer.Web.Application.WebApp.Private.Catalog
{
   public partial class catClientes : BPPage
   {
      
      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum ClienteActionTypes { DeleteCliente, InsertCliente, ReactivateCliente, UpdateCliente }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         try
         {

            // Limpiar formulario
            this.ddlActionTipoCliente.SelectedIndex = 0;
            this.txtActionPorcientoImpuestos.Text = "";
            this.txtActionPorcientoRetencion.Text = "";
            this.txtActionClaveGTEDes.Text = "";
            this.txtActionClaveVendedorOriginal.Text = "";
            this.txtActionDiasCredito.Text = "";
            this.txtActionPreferencial.Text = "";
            this.txtActionTerminal.Text = "";
            this.txtActionDescripcion.Text = "";
            this.txtActionFax.Text = "";
            this.txtActionMetodoPago.Text = "";
            this.txtActionNombre.Text = "";
            this.txtActionTarifa.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddCliente.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void InsertCliente(){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Formulario
            oENTCliente.idCompany = Int32.Parse(this.ddlActionCompany.SelectedValue);
            oENTCliente.idTipoCliente = Int32.Parse(this.ddlActionTipoCliente.SelectedValue);
            oENTCliente.dPorcientoImpuestos = Double.Parse(this.txtActionPorcientoImpuestos.Text);
            oENTCliente.dPorcientoRetencion = Double.Parse(this.txtActionPorcientoRetencion.Text);
            oENTCliente.iClaveGTEDes = Int32.Parse(this.txtActionClaveGTEDes.Text);
            oENTCliente.iClaveVendedorOriginal = Int32.Parse(this.txtActionClaveVendedorOriginal.Text);
            oENTCliente.iDiasCredito = Int32.Parse(this.txtActionDiasCredito.Text);
            oENTCliente.iPreferencial = Int32.Parse(this.txtActionPreferencial.Text);
            oENTCliente.iTerminal = Int32.Parse(this.txtActionTerminal.Text);
            oENTCliente.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCliente.sFax = this.txtActionFax.Text.Trim();
            oENTCliente.sMetodoPago = this.txtActionMetodoPago.Text.Trim();
            oENTCliente.sNombre = this.txtActionNombre.Text.Trim();
            oENTCliente.sTarifa = this.txtActionTarifa.Text.Trim();
            oENTCliente.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCliente.InsertCliente(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCliente();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Cliente creado con éxito!. Recuerde crear Sucursales enlazadas al cliente', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCliente(){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Formulario
            oENTCliente.idCompany = Int32.Parse(this.ddlCompany.SelectedItem.Value);
            oENTCliente.idCliente = 0;
            oENTCliente.idSucursal = 0;
            oENTCliente.sNombre = this.txtNombre.Text;
            oENTCliente.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPCliente.SelectCliente_Catalogo(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvCliente.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvCliente.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCliente_ForEdit(Int32 idCliente){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Formulario
            oENTCliente.idCliente = idCliente;
            oENTCliente.idCompany = 0;
            oENTCliente.idSucursal = 0;
            oENTCliente.sNombre = "";
            oENTCliente.tiActivo = 2;

				// Transacción
				oENTResponse = oBPCliente.SelectCliente_Catalogo(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario
            this.ddlActionCompany.SelectedValue       = oENTResponse.dsResponse.Tables[1].Rows[0]["idCompany"].ToString();
            this.ddlActionTipoCliente.SelectedValue   = oENTResponse.dsResponse.Tables[1].Rows[0]["idTipoCliente"].ToString();
            this.txtActionPorcientoImpuestos.Text     = oENTResponse.dsResponse.Tables[1].Rows[0]["dPorcientoImpuestos"].ToString();
            this.txtActionPorcientoRetencion.Text     = oENTResponse.dsResponse.Tables[1].Rows[0]["dPorcientoRetencion"].ToString();
            this.txtActionClaveGTEDes.Text            = oENTResponse.dsResponse.Tables[1].Rows[0]["iClaveGTEDes"].ToString();
            this.txtActionClaveVendedorOriginal.Text  = oENTResponse.dsResponse.Tables[1].Rows[0]["iClaveVendedorOriginal"].ToString();
            this.txtActionDiasCredito.Text            = oENTResponse.dsResponse.Tables[1].Rows[0]["iDiasCredito"].ToString();
            this.txtActionPreferencial.Text           = oENTResponse.dsResponse.Tables[1].Rows[0]["iPreferencial"].ToString();
            this.txtActionTerminal.Text               = oENTResponse.dsResponse.Tables[1].Rows[0]["iTerminal"].ToString();
            this.txtActionDescripcion.Text            = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.txtActionFax.Text                    = oENTResponse.dsResponse.Tables[1].Rows[0]["sFax"].ToString();
            this.txtActionMetodoPago.Text             = oENTResponse.dsResponse.Tables[1].Rows[0]["sMetodoPago"].ToString();
            this.txtActionNombre.Text                 = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            this.txtActionTarifa.Text                 = oENTResponse.dsResponse.Tables[1].Rows[0]["sTarifa"].ToString();
            this.ddlActionStatus.SelectedValue        = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCompany(){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPCompany oBPCompany = new BPCompany();

         Encryption utilEncryption = new Encryption();
         String sKey = "";

			try{

            // Formulario
            oENTCompany.sNombre = "";
            oENTCompany.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCompany.SelectCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlCompany.DataTextField = "sNombre";
				this.ddlCompany.DataValueField = "idCompany";
				this.ddlCompany.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlCompany.DataBind();

            // Agregar Item de selección
            this.ddlCompany.Items.Insert(0, new ListItem("[Todas]", "0"));

				// Seguridad
            oENTSession = (ENTSession)this.Session["oENTSession"];
            if (oENTSession.idCompany != 1){
               this.ddlCompany.Enabled = false;
               this.ddlCompany.SelectedValue = oENTSession.idCompany.ToString();

                // Validación 
               if(this.ddlCompany.SelectedValue != oENTSession.idCompany.ToString()){
                  sKey = utilEncryption.EncryptString("[V04] Su compañía no tiene permisos para acceder a esta página", true);
                  this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
               }
            }

			}catch (Exception ex){
            throw (ex);
			}
      }
      
      private void SelectCompany_Action(){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPCompany oBPCompany = new BPCompany();

         Encryption utilEncryption = new Encryption();
         String sKey = "";

			try{

            // Formulario
            oENTCompany.sNombre = "";
            oENTCompany.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCompany.SelectCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlActionCompany.DataTextField = "sNombre";
            this.ddlActionCompany.DataValueField = "idCompany";
            this.ddlActionCompany.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlActionCompany.DataBind();

            // Agregar Item de selección
            this.ddlActionCompany.Items.Insert(0, new ListItem("[Seleccione]", "0"));

				// Seguridad
            oENTSession = (ENTSession)this.Session["oENTSession"];
            if (oENTSession.idCompany != 1){
               this.ddlActionCompany.Enabled = false;
               this.ddlActionCompany.SelectedValue = oENTSession.idCompany.ToString();

                // Validación 
               if(this.ddlCompany.SelectedValue != oENTSession.idCompany.ToString()){
                  sKey = utilEncryption.EncryptString("[V04] Su compañía no tiene permisos para acceder a esta página", true);
                  this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
               }
            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectStatus(){
         try
         {

            // Opciones de DropDownList
            this.ddlStatus.Items.Insert(0, new ListItem("[Todos]", "2"));
            this.ddlStatus.Items.Insert(1, new ListItem("Activos", "1"));
            this.ddlStatus.Items.Insert(2, new ListItem("Inactivos", "0"));

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SelectStatus_Action(){
         try
         {

            // Opciones de DropDownList
            this.ddlActionStatus.Items.Insert(0, new ListItem("[Seleccione]", "2"));
            this.ddlActionStatus.Items.Insert(1, new ListItem("Activo", "1"));
            this.ddlActionStatus.Items.Insert(2, new ListItem("Inactivo", "0"));

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SelectTipoCliente_Action(){
         ENTTipoCliente oENTTipoCliente = new ENTTipoCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPTipoCliente oBPTipoCliente = new BPTipoCliente();

			try{

            // Formulario
            oENTTipoCliente.idTipoCliente = 0;
            oENTTipoCliente.sNombre = "";
            oENTTipoCliente.tiActivo = 1;

				// Transacción
				oENTResponse = oBPTipoCliente.SelectTipoCliente(oENTTipoCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlActionTipoCliente.DataTextField = "sNombre";
				this.ddlActionTipoCliente.DataValueField = "idTipoCliente";
				this.ddlActionTipoCliente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlActionTipoCliente.DataBind();

            // Agregar Item de selección
            this.ddlActionTipoCliente.Items.Insert(0, new ListItem("[Todas]", "0"));

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SetPanel(ClienteActionTypes ClienteActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddCliente.Value = idItem.ToString();

            // Detalle de acción
            switch (ClienteActionType){
               case ClienteActionTypes.InsertCliente:
                  this.lblActionTitle.Text = "Nuevo Cliente";
                  this.btnAction.Text = "Crear Cliente";
                  break;

               case ClienteActionTypes.UpdateCliente:
                  this.lblActionTitle.Text = "Edición de Cliente";
                  this.btnAction.Text = "Actualizar Cliente";
                  SelectCliente_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlActionCompany.Enabled ? this.ddlActionCompany.ClientID : this.ddlActionTipoCliente.ClientID) + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateCliente(Int32 idCliente){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Formulario
            oENTCliente.idCliente = idCliente;
            oENTCliente.idCompany = Int32.Parse(this.ddlActionCompany.SelectedValue);
            oENTCliente.idTipoCliente = Int32.Parse(this.ddlActionTipoCliente.SelectedValue);
            oENTCliente.dPorcientoImpuestos = Double.Parse(this.txtActionPorcientoImpuestos.Text);
            oENTCliente.dPorcientoRetencion = Double.Parse(this.txtActionPorcientoRetencion.Text);
            oENTCliente.iClaveGTEDes = Int32.Parse(this.txtActionClaveGTEDes.Text);
            oENTCliente.iClaveVendedorOriginal = Int32.Parse(this.txtActionClaveVendedorOriginal.Text);
            oENTCliente.iDiasCredito = Int32.Parse(this.txtActionDiasCredito.Text);
            oENTCliente.iPreferencial = Int32.Parse(this.txtActionPreferencial.Text);
            oENTCliente.iTerminal = Int32.Parse(this.txtActionTerminal.Text);
            oENTCliente.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCliente.sFax = this.txtActionFax.Text.Trim();
            oENTCliente.sMetodoPago = this.txtActionMetodoPago.Text.Trim();
            oENTCliente.sNombre = this.txtActionNombre.Text.Trim();
            oENTCliente.sTarifa = this.txtActionTarifa.Text.Trim();
            oENTCliente.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCliente.UpdateCliente(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCliente();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateCliente_Estatus(Int32 idCliente, ClienteActionTypes ClienteActionType){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Formulario
            oENTCliente.idCliente = idCliente;
            switch (ClienteActionType){
               case ClienteActionTypes.DeleteCliente:
                  oENTCliente.tiActivo = 0;
                  break;
               case ClienteActionTypes.ReactivateCliente:
                  oENTCliente.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPCliente.UpdateCliente_Estatus(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectCliente();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Campos numéricos vacíos
            if(this.txtActionPorcientoImpuestos.Text == "") { this.txtActionPorcientoImpuestos.Text = "0"; }
            if(this.txtActionPorcientoRetencion.Text == "") { this.txtActionPorcientoRetencion.Text = "0"; }
            if(this.txtActionClaveGTEDes.Text == "") { this.txtActionClaveGTEDes.Text = "0"; }
            if(this.txtActionClaveVendedorOriginal.Text == "") { this.txtActionClaveVendedorOriginal.Text = "0"; }
            if(this.txtActionDiasCredito.Text == "") { this.txtActionDiasCredito.Text = "0"; }
            if(this.txtActionPreferencial.Text == "") { this.txtActionPreferencial.Text = "0"; }
            if(this.txtActionTerminal.Text == "") { this.txtActionTerminal.Text = "0"; }

            // Compañía
            if (this.ddlActionCompany.SelectedIndex == 0) { throw new Exception("* El campo [Compañía] es requerido"); }

            // Tipo de Cliente
            if (this.ddlActionTipoCliente.SelectedIndex == 0) { throw new Exception("* El campo [Tipo de Cliente] es requerido"); }

            // Nombre
            if(this.txtActionNombre.Text.Trim() == ""){ throw new Exception("* El campo [Nombre] es requerido"); }

            // Estatus
            if (this.ddlActionStatus.SelectedIndex == 0) { throw new Exception("* El campo [Estatus] es requerido"); }

         }catch (Exception ex){
            throw (ex);
         }
      }


      // Eventos de la página
      
      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) {

            this.lblActionMessage.Text = "";
            return;
         }

         // Lógica de la página
         try{

            // Llenado de controles
            SelectCompany();
            SelectCompany_Action();
            SelectTipoCliente_Action();
            SelectStatus();
            SelectStatus_Action();
            SelectCliente();

            // Estado inicial del formulario
            ClearActionPanel();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

      protected void btnAction_Click(object sender, EventArgs e){
         try{

            // Validar formulario
            ValidateActionForm();

            // Determinar acción
            if (this.hddCliente.Value == "0"){

               InsertCliente();
            }else{

               UpdateCliente(Int32.Parse(this.hddCliente.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectCliente();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(ClienteActionTypes.InsertCliente);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

      protected void gvCliente_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idCliente = "";
         String sNombreCliente = "";
         String tiActivo = "";

         String sImagesAttributes = "";
         String sTootlTip = "";
			
			try{

            // Validación de que sea fila
            if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
            imgAction = (ImageButton)e.Row.FindControl("imgAction");

				// Datakeys
            idCliente = this.gvCliente.DataKeys[e.Row.RowIndex]["idCliente"].ToString();
            tiActivo = this.gvCliente.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreCliente = this.gvCliente.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

            // Tooltip Edición
            sTootlTip = "Editar Cliente [" + sNombreCliente + "]";
            imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
            imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
            sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Cliente [" + sNombreCliente + "]";
				imgAction.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgAction.Attributes.Add("onmouseout", "tooltip.hide();");
				imgAction.Attributes.Add("style", "cursor:hand;");

            // Imagen del botón [imgAction]
            imgAction.ImageUrl = "../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + ".png";

				// Atributos Over
            sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
            sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + "_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
            sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
            sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + ".png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idCliente = 0;

			String strCommand = "";
			Int32 intRow = 0;
			
			try{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				idCliente = Int32.Parse(this.gvCliente.DataKeys[intRow]["idCliente"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvCliente.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(ClienteActionTypes.UpdateCliente, idCliente);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateCliente_Estatus(idCliente, ClienteActionTypes.DeleteCliente);
                  break;
               case "Reactivar":
                  UpdateCliente_Estatus(idCliente, ClienteActionTypes.ReactivateCliente);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
			}
		}

		protected void gvCliente_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvCliente, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCliente.DataSource = viewRegionesTelcel;
				this.gvCliente.DataBind();
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
			}

		}

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try{

            // Cancelar transacción
            ClearActionPanel();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

   }
}