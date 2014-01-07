/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatCentroServicio
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de CentroServicios de la aplicación
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
   public partial class catCentrosDeServicio : BPPage
   {

      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum CentroServicioActionTypes { DeleteCentroServicio, InsertCentroServicio, ReactivateCentroServicio, UpdateCentroServicio }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         try
         {

            // Limpiar formulario
            this.txtActionTerminal.Text = "";
            this.txtActionCD.Text = "";
            this.txtActionRFC.Text = "";
            this.txtActionProExterno.Text = "";
            this.txtActionNombre.Text = "";
            this.txtActionDescripcion.Text = "";
            this.txtActionDireccion.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddCentroServicio.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void InsertCentroServicio(){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();

			try{

            // Formulario
            oENTCentroServicio.idCompany = Int32.Parse(this.ddlActionCompany.SelectedValue);
            oENTCentroServicio.idCiudad = Int32.Parse(this.ddlActionCiudad.SelectedValue);
            oENTCentroServicio.iTerminal = Int32.Parse(this.txtActionTerminal.Text.Trim());
            oENTCentroServicio.sCD = this.txtActionCD.Text.Trim();
            oENTCentroServicio.sDireccion = this.txtActionDireccion.Text.Trim();
            oENTCentroServicio.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCentroServicio.sNombre = this.txtActionNombre.Text.Trim();
            oENTCentroServicio.sRFC = this.txtActionRFC.Text.Trim();
            oENTCentroServicio.sProExterno = this.txtActionProExterno.Text.Trim();
            oENTCentroServicio.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCentroServicio.InsertCentroServicio(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCentroServicio();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Centro de Servicio creado con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCentroServicio(){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Formulario
            oENTCentroServicio.idCompany = Int32.Parse(this.ddlCompany.SelectedItem.Value);
            oENTCentroServicio.idCentroServicio = 0;
            oENTCentroServicio.sNombre = this.txtNombre.Text;
            oENTCentroServicio.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPCentroServicio.SelectCentroServicio(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvCentroServicio.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvCentroServicio.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCentroServicio_ForEdit(Int32 idCentroServicio){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();

			try{

            // Formulario
            oENTCentroServicio.idCentroServicio = idCentroServicio;
            oENTCentroServicio.sNombre = "";
            oENTCentroServicio.tiActivo = 2;

				// Transacción
				oENTResponse = oBPCentroServicio.SelectCentroServicio(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario
            this.txtActionTerminal.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["iTerminal"].ToString();
            this.txtActionCD.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sCD"].ToString();
            this.txtActionRFC.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sRFC"].ToString();
            this.txtActionProExterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.txtActionDireccion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDireccion"].ToString();
            this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

            this.ddlActionPais.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idPais"].ToString();

            SelectEstado();
            this.ddlActionEstado.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idEstado"].ToString();

            SelectCiudad();
            this.ddlActionCiudad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idCiudad"].ToString();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCiudad(){
         ENTCiudad oENTCiudad = new ENTCiudad();
			ENTResponse oENTResponse = new ENTResponse();

			BPCiudad oBPCiudad = new BPCiudad();

			try{

            // Formulario
            oENTCiudad.idCiudad = 0;
            oENTCiudad.idEstado = Int32.Parse(this.ddlActionEstado.SelectedValue);
            oENTCiudad.idPais = Int32.Parse(this.ddlActionPais.SelectedValue);
            oENTCiudad.sNombre = "";
            oENTCiudad.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            //if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false); focusControl('" + this.ddlActionEstado.ClientID + "');", true); }

            // Llenado de combo
            if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

               this.ddlActionCiudad.Items.Clear();
               this.ddlActionCiudad.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

            }else{

               this.ddlActionCiudad.DataTextField = "sNombre";
               this.ddlActionCiudad.DataValueField = "idCiudad";
               this.ddlActionCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlActionCiudad.DataBind();

            }

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

      private void SelectEstado(){
         ENTEstado oENTEstado = new ENTEstado();
			ENTResponse oENTResponse = new ENTResponse();

			BPEstado oBPEstado = new BPEstado();

			try{

            // Formulario
            oENTEstado.idEstado = 0;
            oENTEstado.idPais = Int32.Parse(this.ddlActionPais.SelectedValue);
            oENTEstado.sNombre = "";
            oENTEstado.tiActivo = 1;

				// Transacción
				oENTResponse = oBPEstado.SelectEstado(oENTEstado);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            //if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false); focusControl('" + this.ddlActionPais.ClientID + "');", true); }

            // Llenado de combo
             if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                this.ddlActionEstado.Items.Clear();
                this.ddlActionEstado.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

            }else{

               this.ddlActionEstado.DataTextField = "sNombre";
               this.ddlActionEstado.DataValueField = "idEstado";
               this.ddlActionEstado.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlActionEstado.DataBind();

            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectPais(){
         ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			BPPais oBPPais = new BPPais();

			try{

            // Formulario
            oENTPais.idPais = 0;
            oENTPais.sNombre = "";
            oENTPais.tiActivo = 1;

				// Transacción
				oENTResponse = oBPPais.SelectPais(oENTPais);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlActionPais.DataTextField = "sNombre";
				this.ddlActionPais.DataValueField = "idPais";
				this.ddlActionPais.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlActionPais.DataBind();

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

      private void SetPanel(CentroServicioActionTypes CentroServicioActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddCentroServicio.Value = idItem.ToString();

            // Detalle de acción
            switch (CentroServicioActionType){
               case CentroServicioActionTypes.InsertCentroServicio:
                  this.lblActionTitle.Text = "Nuevo Centro de Servicio";
                  this.btnAction.Text = "Crear Centro de Servicio";
                  break;

               case CentroServicioActionTypes.UpdateCentroServicio:
                  this.lblActionTitle.Text = "Edición de Centro de  Servicio";
                  this.btnAction.Text = "Actualizar Centro de Servicio";
                  SelectCentroServicio_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" +  (this.ddlCompany.Enabled ? this.ddlActionCompany.ClientID : this.ddlActionPais.ClientID ) + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateCentroServicio(Int32 idCentroServicio){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();

			try{

            // Formulario
            oENTCentroServicio.idCentroServicio = idCentroServicio;
            oENTCentroServicio.idCompany = Int32.Parse(this.ddlActionCompany.SelectedValue);
            oENTCentroServicio.idCiudad = Int32.Parse(this.ddlActionCiudad.SelectedValue);
            oENTCentroServicio.iTerminal = Int32.Parse(this.txtActionTerminal.Text.Trim());
            oENTCentroServicio.sCD = this.txtActionCD.Text.Trim();
            oENTCentroServicio.sDireccion = this.txtActionDireccion.Text.Trim();
            oENTCentroServicio.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCentroServicio.sNombre = this.txtActionNombre.Text.Trim();
            oENTCentroServicio.sRFC = this.txtActionRFC.Text.Trim();
            oENTCentroServicio.sProExterno = this.txtActionProExterno.Text.Trim();
            oENTCentroServicio.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCentroServicio.UpdateCentroServicio(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCentroServicio();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateCentroServicio_Estatus(Int32 idCentroServicio, CentroServicioActionTypes CentroServicioActionType){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();

			try{

            // Formulario
            oENTCentroServicio.idCentroServicio = idCentroServicio;
            switch (CentroServicioActionType){
               case CentroServicioActionTypes.DeleteCentroServicio:
                  oENTCentroServicio.tiActivo = 0;
                  break;
               case CentroServicioActionTypes.ReactivateCentroServicio:
                  oENTCentroServicio.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPCentroServicio.UpdateCentroServicio_Estatus(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectCentroServicio();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Compañía
            if (this.ddlActionCompany.SelectedIndex == 0) { throw new Exception("* El campo [Compañía] es requerido"); }

            // Ciudad
            if (this.ddlActionCiudad.SelectedValue == "-1") { throw new Exception("* El campo [Ciudad] es requerido"); }

            // Terminal
            if (this.txtActionTerminal.Text.Trim() == "") { throw new Exception("* El campo [Terminal] es requerido"); }

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
            SelectPais();
            SelectEstado();
            SelectCiudad();
            SelectStatus();
            SelectStatus_Action();
            SelectCentroServicio();

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
            if (this.hddCentroServicio.Value == "0"){

               InsertCentroServicio();
            }else{

               UpdateCentroServicio(Int32.Parse(this.hddCentroServicio.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectCentroServicio();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(CentroServicioActionTypes.InsertCentroServicio);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
         }
      }

      protected void ddlActionPais_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de estados y ciudades
            SelectEstado();
            SelectCiudad();

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
         }
      }

      protected void ddlActionEstado_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de ciudades
            SelectCiudad();

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
         }
      }

      protected void gvCentroServicio_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idCentroServicio = "";
         String sNombreCentroServicio = "";
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
            idCentroServicio = this.gvCentroServicio.DataKeys[e.Row.RowIndex]["idCentroServicio"].ToString();
            tiActivo = this.gvCentroServicio.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreCentroServicio = this.gvCentroServicio.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

            // Tooltip Edición
            sTootlTip = "Editar Centro de Servicio [" + sNombreCentroServicio + "]";
            imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
            imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
            sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Centro de Servicio [" + sNombreCentroServicio + "]";
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

		protected void gvCentroServicio_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idCentroServicio = 0;

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
				idCentroServicio = Int32.Parse(this.gvCentroServicio.DataKeys[intRow]["idCentroServicio"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvCentroServicio.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(CentroServicioActionTypes.UpdateCentroServicio, idCentroServicio);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateCentroServicio_Estatus(idCentroServicio, CentroServicioActionTypes.DeleteCentroServicio);
                  break;
               case "Reactivar":
                  UpdateCentroServicio_Estatus(idCentroServicio, CentroServicioActionTypes.ReactivateCentroServicio);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID ) + "');", true);
			}
		}

		protected void gvCentroServicio_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvCentroServicio, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCentroServicio.DataSource = viewRegionesTelcel;
				this.gvCentroServicio.DataBind();
				
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