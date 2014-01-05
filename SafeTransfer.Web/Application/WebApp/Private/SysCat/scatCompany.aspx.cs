/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatCompany
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Compañías de la aplicación
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
   public partial class scatCompany : BPPage
   {
     
      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum CompanyActionTypes { DeleteCompany, InsertCompany, ReactivateCompany, UpdateCompany }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         try
         {

            // Limpiar formulario
            this.txtActionNombre.Text = "";
            this.txtActionDescripcion.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddCompany.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void ExportCompany(){
         String sKey = "";
			
			try{

            // Formulario (sNombre|tiActivo)
            sKey = this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;
				
				// Encriptar la llave
				sKey = utilEncryption.EncryptString(sKey, true);
				
				// Llamada a rutina del lado del cliente
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsCompany.aspx', '" + sKey + "');", true);
			
			}catch (Exception ex){
				throw (ex);
			}
      }

      private void InsertCompany(){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();

			BPCompany oBPCompany = new BPCompany();

			try{

            // Formulario
            oENTCompany.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCompany.sNombre = this.txtActionNombre.Text.Trim();
            oENTCompany.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCompany.InsertCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCompany();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Compañía creado con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCompany(){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();

			BPCompany oBPCompany = new BPCompany();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Formulario
            oENTCompany.sNombre = this.txtNombre.Text;
            oENTCompany.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPCompany.SelectCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvCompany.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvCompany.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCompany_ForEdit(Int32 idCompany){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();

			BPCompany oBPCompany = new BPCompany();

			try{

            // Formulario
            oENTCompany.idCompany = idCompany;
            oENTCompany.sNombre = "";
            oENTCompany.tiActivo = 2;

				// Transacción
				oENTResponse = oBPCompany.SelectCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario
            this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

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

      private void SetPanel(CompanyActionTypes CompanyActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddCompany.Value = idItem.ToString();

            // Detalle de acción
            switch (CompanyActionType){
               case CompanyActionTypes.InsertCompany:
                  this.lblActionTitle.Text = "Nuevo Compañía";
                  this.btnAction.Text = "Crear Compañía";
                  
                  break;

               case CompanyActionTypes.UpdateCompany:
                  this.lblActionTitle.Text = "Edición de Compañía";
                  this.btnAction.Text = "Actualizar Compañía";
                  SelectCompany_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateCompany(Int32 idCompany){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();

			BPCompany oBPCompany = new BPCompany();

			try{

            // Formulario
            oENTCompany.idCompany = idCompany;
            oENTCompany.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTCompany.sNombre = this.txtActionNombre.Text.Trim();
            oENTCompany.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
            oENTResponse = oBPCompany.UpdateCompany(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectCompany();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateCompany_Estatus(Int32 idCompany, CompanyActionTypes CompanyActionType){
         ENTCompany oENTCompany = new ENTCompany();
			ENTResponse oENTResponse = new ENTResponse();

			BPCompany oBPCompany = new BPCompany();

			try{

            // Compañía origen
            if (idCompany == 1) { throw new Exception("No es permitido realizar transacciones sobre la compañía origen"); }

            // Formulario
            oENTCompany.idCompany = idCompany;
            switch (CompanyActionType){
               case CompanyActionTypes.DeleteCompany:
                  oENTCompany.tiActivo = 0;
                  break;
               case CompanyActionTypes.ReactivateCompany:
                  oENTCompany.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPCompany.UpdateCompany_Estatus(oENTCompany);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectCompany();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Nombre
            if(this.txtActionNombre.Text.Trim() == ""){ throw new Exception("* El campo [Nombre] es requerido"); }

            // Estatus
            if (this.ddlActionStatus.SelectedIndex == 0) { throw new Exception("* El campo [Estatus] es requerido"); }

            // Compañía origen
            if (this.hddCompany.Value == "1") { throw new Exception("* No es permitido realizar transacciones sobre la compañía origen"); }

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
            SelectStatus_Action();
            SelectStatus();
            SelectCompany();

            // Estado inicial del formulario
            ClearActionPanel();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnAction_Click(object sender, EventArgs e){
         try{

            // Validar formulario
            ValidateActionForm();

            // Determinar acción
            if (this.hddCompany.Value == "0"){

               InsertCompany();
            }else{

               UpdateCompany(Int32.Parse(this.hddCompany.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectCompany();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnExportar_Click(object sender, EventArgs e){
         try{

            // Exportar información
            ExportCompany();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(CompanyActionTypes.InsertCompany);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idCompany = "";
         String sNombreCompany = "";
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
            idCompany = this.gvCompany.DataKeys[e.Row.RowIndex]["idCompany"].ToString();
            tiActivo = this.gvCompany.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreCompany = this.gvCompany.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

            // Validación sobre la compañía origen
            if(idCompany == "1"){

               imgEdit.Visible = false;
               imgAction.Visible = false;
            }else{

               // Tooltip Edición
               sTootlTip = "Editar Compañía [" + sNombreCompany + "]";
               imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
               imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
               imgEdit.Attributes.Add("style", "cursor:hand;");

               // Tooltip Action
               sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Compañía [" + sNombreCompany + "]";
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
            }
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idCompany = 0;

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
				idCompany = Int32.Parse(this.gvCompany.DataKeys[intRow]["idCompany"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvCompany.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(CompanyActionTypes.UpdateCompany, idCompany);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateCompany_Estatus(idCompany, CompanyActionTypes.DeleteCompany);
                  break;
               case "Reactivar":
                  UpdateCompany_Estatus(idCompany, CompanyActionTypes.ReactivateCompany);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvCompany_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvCompany, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCompany.DataSource = viewRegionesTelcel;
				this.gvCompany.DataBind();
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try{

            // Cancelar transacción
            ClearActionPanel();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

   }
}