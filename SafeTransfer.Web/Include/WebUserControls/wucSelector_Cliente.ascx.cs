/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucSelector_Cliente
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Web User Control que ayuda a filtrar una Cliente en particular
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

namespace SafeTransfer.Web.Include.WebUserControls
{
   public partial class wucSelector_Cliente : System.Web.UI.UserControl
   {
      
      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      
      // Propiedades

      ///<remarks>
      ///   <name>wucSelector_Cliente.idSucursal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador de Sucursal seleccionado por el usuario</summary>
      public Int32 idSucursal
      {
         get { return SelfInt32Parse(this.hddSucursal.Value); }
         set { this.hddSucursal.Value = value.ToString(); }
      }


      // Handlers
      
      public delegate void WUCSelectorCommandEventHandler();
      public event WUCSelectorCommandEventHandler ItemSelected;

      
      // Propiedades

      ///<remarks>
      ///   <name>wucToolbar.ClientID_Canvas</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene el ID generado del TextBox contenedor</summary>
      public String ClientID_Canvas
      {
         get { return this.txtCliente.ClientID; }
      }

      ///<remarks>
      ///   <name>wucToolbar.Text</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el texto del contenedor</summary>
      public String Text
      {
         get { return this.txtCliente.Text; }
         set { this.txtCliente.Text = value; }
      }


      // Funciones del programador

      private Int32 SelfInt32Parse(String sItem){
         Int32 iResponse;

         try
         {

            iResponse = Int32.Parse(sItem);

         }catch (Exception){
            iResponse = 0;
         }

         return iResponse;
      }


      // Rutinas del programador

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

            // Llenado de combo de filtro
				this.ddlCompany.DataTextField = "sNombre";
				this.ddlCompany.DataValueField = "idCompany";
				this.ddlCompany.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlCompany.DataBind();

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

      private void SelectCliente(Boolean Focus){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Limpiar mensajes anteriores
            this.lblMessage.Text = "";

            // Formulario
            oENTCliente.idCliente   = 0;
            oENTCliente.idCompany   = Int32.Parse(this.ddlCompany.SelectedValue);
            oENTCliente.idSucursal  = 0;
            oENTCliente.sNombre     = this.txtNombre.Text;
            oENTCliente.tiActivo    = 1;

				// Transacción
				oENTResponse = oBPCliente.SelectCliente(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { this.lblMessage.Text = oENTResponse.sMessage; }

            // Llenado de contClientees
            this.gvCliente.DataSource = oENTResponse.dsResponse.Tables[2];
            this.gvCliente.DataBind();

            // Foco
            if (Focus) {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID) + "');", true);
            }

			}catch (Exception ex){
            throw (ex);
			}
      }
      
      
      // Eventos del control

      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Lógica de la página
         try{

            // Estado inicial
            this.pnlAction.Visible = false;

            // Llenado de contClientes
            SelectCompany();
            SelectCliente(false);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectCliente(true);

         }catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID) + "');", true);
         }
      }

      protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectCliente(true);

         }catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID) + "');", true);
         }
      }

      protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e){
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
            this.hddSucursal.Value = this.gvCliente.DataKeys[intRow]["idSucursal"].ToString();

            // Mostrar nombre
            this.txtCliente.Text = this.gvCliente.DataKeys[intRow]["sCliente"].ToString();

            // Esconder control
            this.pnlAction.Visible = false;

				// Generar evento
            if (ItemSelected != null){ ItemSelected(); }
				
			}catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID) + "');", true);
			}
		}

      protected void gvCliente_RowDataBound(object sender, GridViewRowEventArgs e){
         ImageButton imgSelectItem = null;

         String sImagesAttributes = "";
         String sCliente = "";
         String sSucursal = "";
         String sTootlTip = "";

         try{

            // Validación de que sea fila
			   if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            // Obtener imágen
				imgSelectItem = (ImageButton)e.Row.FindControl("imgSelectItem");

            // Datakeys
            sCliente = this.gvCliente.DataKeys[e.Row.RowIndex]["sCliente"].ToString();
            sSucursal = this.gvCliente.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

            // Tooltip
            sTootlTip = "Seleccionar [" + sCliente + " (" + sSucursal + ")]";
            imgSelectItem.Attributes.Add("title", sTootlTip);

            // Atributos Over
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem.png';";
            e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

            // Atributos Out
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem_Null.png';";
            e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; " + sImagesAttributes);

         }catch (Exception ex){
				throw (ex);
			}
		}
      
		protected void gvCliente_Sorting(object sender, GridViewSortEventArgs e){
         DataTable tblCliente = null;
			DataView viewCliente = null;
			
			try{

				// Obtener DataTable y DataView del GridView
            tblCliente = utilFunction.ParseGridViewToDataTable(this.gvCliente, true);
				viewCliente = new DataView(tblCliente);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewCliente.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCliente.DataSource = viewCliente;
				this.gvCliente.DataBind();
				
			}catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (this.ddlCompany.Enabled ? this.ddlCompany.ClientID : this.txtNombre.ClientID) + "');", true);
			}
		}

      protected void imgBusqueda_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Mostrar/Ocultar filtro
            this.pnlAction.Visible = (this.pnlAction.Visible ? false : true);

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try{

            // Ocultar filtro
            this.pnlAction.Visible = false;

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

   }
}