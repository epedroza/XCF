﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatUsuario
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Usuarios de la aplicación
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

namespace SafeTransfer.Web.Application.WebApp.Private.SysCat
{
   public partial class scatUsuario : BPPage
   {
     
      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum UsuarioActionTypes { DeleteUsuario, InsertUsuario, ReactivateUsuario, UpdateUsuario }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         try
         {

            // Limpiar formulario
            if (this.ddlActionCompany.Enabled) { this.ddlActionCompany.SelectedIndex = 0; }
            this.ddlActionRol.SelectedIndex = 0;
            this.txtActionEmail.Text = "";
            this.txtActionNombre.Text = "";
            this.txtActionApellidoPaterno.Text = "";
            this.txtActionApellidoMaterno.Text = "";
            this.txtActionDescripcion.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddUsuario.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void ExportUsuario(){
         String sKey = "";
			
			try{

            // Formulario (idRol|sEmail|sNombre|tiActivo)
            sKey = this.ddlRol.SelectedItem.Value + "|" + this.txtEmail.Text + "|" + this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;
				
				// Encriptar la llave
				sKey = utilEncryption.EncryptString(sKey, true);
				
				// Llamada a rutina del lado del cliente
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsUsuario.aspx', '" + sKey + "');", true);
			
			}catch (Exception ex){
				throw (ex);
			}
      }

      private void InsertUsuario(){
         ENTUsuario oENTUsuario = new ENTUsuario();
         ENTResponse oENTResponse = new ENTResponse();

         BPUsuario oBPUsuario = new BPUsuario();

         try{

            // Formulario
            oENTUsuario.idRol             = Int32.Parse(this.ddlActionRol.SelectedValue);
            oENTUsuario.sApellidoMaterno  = this.txtActionApellidoMaterno.Text.Trim();
            oENTUsuario.sApellidoPaterno  = this.txtActionApellidoPaterno.Text.Trim();
            oENTUsuario.sDescripcion      = this.txtActionDescripcion.Text.Trim();
            oENTUsuario.sEmail            = this.txtActionEmail.Text.Trim();
            oENTUsuario.sNombre           = this.txtActionNombre.Text.Trim();
            oENTUsuario.tiActivo          = Int16.Parse(this.ddlActionStatus.SelectedValue);

            // Transacción
            oENTResponse = oBPUsuario.InsertUsuario(oENTUsuario);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

            // Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectUsuario();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Usuario creado con éxito!. La contraseña fue enviada por correo electrónico. Favor de revisar el correo no deseado.', 'Success', true); focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID) + "');", true);

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

      private void SelectRol(){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

			try{

            // Formulario
            oENTRol.idCompany = Int32.Parse(this.ddlCompany.SelectedValue);
            oENTRol.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPRol.SelectRol(oENTRol);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlRol.DataTextField = "sNombre";
				this.ddlRol.DataValueField = "idRol";
				this.ddlRol.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlRol.DataBind();

				// Agregar Item de selección
				this.ddlRol.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectRol_Action(){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

			try{

            // Estado inicial
            this.lblActionMessage.Text = "";

            // Formulario
            oENTRol.idCompany = Int32.Parse((this.ddlActionCompany.SelectedIndex == 0 ? "-1" : this.ddlActionCompany.SelectedValue));
            oENTRol.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPRol.SelectRol(oENTRol);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { this.lblActionMessage.Text = oENTResponse.sMessage; }

            // Llenado de combo
            this.ddlActionRol.DataTextField = "sNombre";
            this.ddlActionRol.DataValueField = "idRol";
            this.ddlActionRol.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlActionRol.DataBind();

				// Agregar Item de selección
            this.ddlActionRol.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

      private void SelectUsuario(){
         ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Formulario
            oENTUsuario.idRol = Int32.Parse(this.ddlRol.SelectedItem.Value);
            oENTUsuario.idCompany = Int32.Parse(this.ddlCompany.SelectedItem.Value);
            oENTUsuario.sEmail = this.txtEmail.Text;
            oENTUsuario.sNombre = this.txtNombre.Text;
            oENTUsuario.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvUsuario.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvUsuario.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectUsuario_ForEdit(Int32 idUsuario){
         ENTUsuario oENTUsuario = new ENTUsuario();
         ENTResponse oENTResponse = new ENTResponse();

         BPUsuario oBPUsuario = new BPUsuario();

         try{

            // Formulario
            oENTUsuario.idCompany = 0;
            oENTUsuario.idRol = 0;
            oENTUsuario.idUsuario = idUsuario;
            oENTUsuario.sEmail = "";
            oENTUsuario.sNombre = "";
            oENTUsuario.tiActivo = 2;

            // Transacción
            oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario (Compañía/Roles)
            this.ddlActionCompany.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idCompany"].ToString();
            SelectRol_Action();
            this.ddlActionRol.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idRol"].ToString();

            // Llenado de formulario (Campos del usuario)
            this.txtActionEmail.Text            = oENTResponse.dsResponse.Tables[1].Rows[0]["sEmail"].ToString();
            this.txtActionNombre.Text           = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            this.txtActionApellidoPaterno.Text  = oENTResponse.dsResponse.Tables[1].Rows[0]["sApellidoPaterno"].ToString();
            this.txtActionApellidoMaterno.Text  = oENTResponse.dsResponse.Tables[1].Rows[0]["sApellidoMaterno"].ToString();
            this.txtActionDescripcion.Text      = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.ddlActionStatus.SelectedValue  = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SetPanel(UsuarioActionTypes UsuarioActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddUsuario.Value = idItem.ToString();

            // Detalle de acción
            switch (UsuarioActionType){
               case UsuarioActionTypes.InsertUsuario:
                  this.lblActionTitle.Text = "Nuevo Usuario";
                  this.btnAction.Text = "Crear Usuario";
                  
                  break;

               case UsuarioActionTypes.UpdateUsuario:
                  this.lblActionTitle.Text = "Edición de Usuario";
                  this.btnAction.Text = "Actualizar Usuario";
                  SelectUsuario_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlActionCompany.Enabled ? this.ddlActionCompany.ClientID : this.ddlActionRol.ClientID) + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateUsuario(Int32 idUsuario){
         ENTUsuario oENTUsuario = new ENTUsuario();
         ENTResponse oENTResponse = new ENTResponse();

         BPUsuario oBPUsuario = new BPUsuario();

         try{

            // Formulario
            oENTUsuario.idUsuario         = idUsuario;
            oENTUsuario.idRol             = Int32.Parse(this.ddlActionRol.SelectedValue);
            oENTUsuario.sApellidoMaterno  = this.txtActionApellidoMaterno.Text.Trim();
            oENTUsuario.sApellidoPaterno  = this.txtActionApellidoPaterno.Text.Trim();
            oENTUsuario.sDescripcion      = this.txtActionDescripcion.Text.Trim();
            oENTUsuario.sEmail            = this.txtActionEmail.Text.Trim();
            oENTUsuario.sNombre           = this.txtActionNombre.Text.Trim();
            oENTUsuario.tiActivo          = Int16.Parse(this.ddlActionStatus.SelectedValue);

            // Transacción
            oENTResponse = oBPUsuario.UpdateUsuario(oENTUsuario);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

            // Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectUsuario();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID) + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateUsuario_Estatus(Int32 idUsuario, UsuarioActionTypes UsuarioActionType){
         ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();

			try{

            // Formulario
            oENTUsuario.idUsuario = idUsuario;
            switch (UsuarioActionType){
               case UsuarioActionTypes.DeleteUsuario:
                  oENTUsuario.tiActivo = 0;
                  break;
               case UsuarioActionTypes.ReactivateUsuario:
                  oENTUsuario.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPUsuario.UpdateUsuario_Estatus(oENTUsuario);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectUsuario();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Compañía
            if (this.ddlActionCompany.SelectedIndex == 0) { throw new Exception("* El campo [Compañía] es requerido"); }

            // Rol
            if (this.ddlActionRol.SelectedIndex == 0 && this.ddlActionCompany.SelectedValue != "1") { throw new Exception("* El campo [Rol] es requerido"); }

            // Email
            if (this.txtActionEmail.Text.Trim() == "") { throw new Exception("* El campo [Email] es requerido"); }

            // Nombre
            if(this.txtActionNombre.Text.Trim() == ""){ throw new Exception("* El campo [Nombre] es requerido"); }

            // Apellido Paterno
            if (this.txtActionApellidoPaterno.Text.Trim() == "") { throw new Exception("* El campo [Apellido Paterno] es requerido"); }

            // Estatus
            if (this.ddlActionStatus.SelectedIndex == 0 && this.ddlActionCompany.SelectedValue != "1") { throw new Exception("* El campo [Estatus] es requerido"); }

         }catch (Exception ex){
            throw (ex);
         }
      }


      // Eventos de la página
      
      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Lógica de la página
         try{

            // Llenado de controles
            SelectCompany();
            SelectCompany_Action();
            SelectStatus();
            SelectStatus_Action();
            SelectRol();
            SelectRol_Action();
            SelectUsuario();

            // Estado inicial del formulario
            ClearActionPanel();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void btnAction_Click(object sender, EventArgs e){
         try{

            // Validar formulario
            ValidateActionForm();

            // Determinar acción
            if (this.hddUsuario.Value == "0"){

               InsertUsuario();
            }else{

               UpdateUsuario(Int32.Parse(this.hddUsuario.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlActionCompany.Enabled ? this.ddlActionCompany.ClientID : this.ddlActionRol.ClientID) + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectUsuario();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void btnExportar_Click(object sender, EventArgs e){
         try{

            // Exportar información
            ExportUsuario();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(UsuarioActionTypes.InsertUsuario);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void ddlActionCompany_SelectedIndexChanged(object sender, EventArgs e){
         try{

            // Recalcular roles
            SelectRol_Action();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionRol.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e){
         try{

            // Recalcular roles
            SelectRol();
            SelectUsuario();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlRol.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
         }
      }

      protected void gvUsuario_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idUsuario = "";
         String sNombreUsuario = "";
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
            idUsuario = this.gvUsuario.DataKeys[e.Row.RowIndex]["idUsuario"].ToString();
            tiActivo = this.gvUsuario.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreUsuario = this.gvUsuario.DataKeys[e.Row.RowIndex]["sFullName"].ToString();

            // Tooltip Edición
            sTootlTip = "Editar Usuario [" + sNombreUsuario + "]";
            imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
            imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
            sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Usuario [" + sNombreUsuario + "]";
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

		protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idUsuario = 0;

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
				idUsuario = Int32.Parse(this.gvUsuario.DataKeys[intRow]["idUsuario"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvUsuario.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(UsuarioActionTypes.UpdateUsuario, idUsuario);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateUsuario_Estatus(idUsuario, UsuarioActionTypes.DeleteUsuario);
                  break;
               case "Reactivar":
                  UpdateUsuario_Estatus(idUsuario, UsuarioActionTypes.ReactivateUsuario);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
			}
		}

		protected void gvUsuario_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvUsuario, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvUsuario.DataSource = viewRegionesTelcel;
				this.gvUsuario.DataBind();
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID ) + "');", true);
			}

		}

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Cancelar transacción
            ClearActionPanel();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.ddlRol.ClientID) + "');", true);
         }
      }

   }
}