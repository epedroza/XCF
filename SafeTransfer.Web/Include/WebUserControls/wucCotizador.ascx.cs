/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucCotizador
' Autor:		Ruben.Cobos
' Fecha:		12-Diciembre-2013
'
' Descripción:
'           Web User Control que genera una Cotización en base a un PickUp
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
using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.BusinessProcess.Page;
using SafeTransfer.Entity.Object;
using System.Data;
using System.Net;

namespace SafeTransfer.Web.Include.WebUserControls
{
   public partial class wucCotizador : System.Web.UI.UserControl
   {
      
      // Utilerías
      Function utilFunction = new Function();


      // Handlers

      public delegate void DelegateCotizarImage();
      public event DelegateCotizarImage ClickCotizarImage;

      
      // Propiedades

      ///<remarks>
      ///   <name>wucCotizador.Enable</name>
      ///   <create>12-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Habilita/Deshabilita lógicamente el control</summary>
      public Boolean Enable
      {
         set{
            
            // Asignación de valor
            this.hddEnable.Value = value.ToString();

            // Si esta deshabilitado
            if (value == false) {
               this.hddPickUp.Value = "0";
               this.hddInsert.Value = "-1";
            }
         
         }
      }

      ///<remarks>
      ///   <name>wucCotizador.idPickUp</name>
      ///   <create>12-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Asigna el identificador de PickUp asociado a la cotización</summary>
      public Int32 idPickUp
      {
         set {

            // Asignación de valor
            this.hddPickUp.Value = value.ToString();

            // Validación
            if (value == 0) { Enable = false; }

         }
      }


      // Variables públicas

      Decimal[] dTotales; // Almacena el sumarizado del Footer en el GridView


      // Métodos publicos

      ///<remarks>
      ///   <name>wucCotizador.Cotizar</name>
      ///   <create>12-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Abre la pantalla de cotización</summary>
      public void Cotizar(){
         try
         {

            // Validaciones de estado del control
            if (Boolean.Parse(this.hddEnable.Value) == false ){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Es necesario guardar el PickUp para poder cotizarlo', 'Warning', false);", true);
               return;
            }

            if (this.hddPickUp.Value == "0" ){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No se determinó el PickUp a cotizar', 'Warning', false);", true);
               return;
            }

            // Mostrar filtro
            this.pnlAction.Visible = true;

            // Consultar la información del PickUp
            SelectCotizacion();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlPaisOrigen.ClientID + "');", true);

         }catch(Exception ex){
            throw (ex);
         }
      }

      ///<remarks>
      ///   <name>wucCotizador.MontoCotizado</name>
      ///   <create>12-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene el monto cotizado para un PickUp desplegándolo en el control</summary>
      public void MontoCotizado(){
         ENTCotizacion oENTCotizacion = new ENTCotizacion();
         ENTResponse oENTResponse = new ENTResponse();

         BPCotizacion oBPCotizacion = new BPCotizacion();

         try
         {

            // Validaciones de estado del control
            if (Boolean.Parse(this.hddEnable.Value) == false ){
               this.txtCotizar.Text = "0.00 MXP";
               return;
            }

            if (this.hddPickUp.Value == "0" ){
               this.txtCotizar.Text = "0.00 MXP";
               return;
            }

            // Formulario
            oENTCotizacion.idPickUp = Int32.Parse(this.hddPickUp.Value);
            oENTCotizacion.tiRecalculo = 0;

            // Transacción
            oENTResponse = oBPCotizacion.SelectCotizacion(oENTCotizacion);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }
            
            // Transacción exitosa
            this.txtCotizar.Text = oENTResponse.dsResponse.Tables[4].Rows[0]["sCotizacion"].ToString();

         }catch(Exception){
            this.txtCotizar.Text = "0.00 MXP";
         }
      }


      // Rutinas del programador

      private void InsertCotizacion(){
         ENTCotizacion oENTCotizacion = new ENTCotizacion();
         ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

         BPCotizacion oBPCotizacion = new BPCotizacion();
         DataRow rowProceso = null;

         try
         {

            // Valores por default
            if(this.txtCarga_Peso.Text.Trim()         == "") { this.txtCarga_Peso.Text = "0"; }
            if(this.txtCarga_Volumen.Text.Trim()      == "") { this.txtCarga_Volumen.Text = "0"; }
            if(this.txtCargoExtra.Text.Trim()         == "") { this.txtCargoExtra.Text = "0"; }
            if(this.txtDescuentoCliente.Text.Trim()   == "") { this.txtDescuentoCliente.Text = "0"; }

            // Datos de usuario
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTCotizacion.idCompany = oENTSession.idCompany;
            oENTCotizacion.idCiudad_Destino = Int32.Parse(this.ddlCiudadDestino.SelectedValue);
            oENTCotizacion.idCiudad_Origen = Int32.Parse(this.ddlCiudadOrigen.SelectedValue);
            oENTCotizacion.idMoneda = Int32.Parse(this.ddlMoneda.SelectedValue);
            oENTCotizacion.idPickUp = Int32.Parse(this.hddPickUp.Value);
            oENTCotizacion.idUnidadMedida_Peso = Int32.Parse(this.ddlCarga_UnidadMedidaPeso.SelectedValue);
            oENTCotizacion.idUnidadMedida_Volumen = Int32.Parse(this.ddlCarga_UnidadMedidaVolumen.SelectedValue);
            oENTCotizacion.dPeso = Decimal.Parse(this.txtCarga_Peso.Text);
            oENTCotizacion.dVolumen = Decimal.Parse(this.txtCarga_Volumen.Text);
            oENTCotizacion.mCargoExtra = Decimal.Parse(this.txtCargoExtra.Text);
            oENTCotizacion.mDescuento = Decimal.Parse(this.txtDescuentoCliente.Text);

            // Partidas
            oENTCotizacion.tblCotizacionPartidas = new DataTable("tblCotizacionPartidas");
            oENTCotizacion.tblCotizacionPartidas.Columns.Add("idPartida", typeof(Int16));
            oENTCotizacion.tblCotizacionPartidas.Columns.Add("mMontoMX", typeof(Decimal));

            foreach (GridViewRow rowPartida in this.gvCotizacion.Rows){

               rowProceso = oENTCotizacion.tblCotizacionPartidas.NewRow();
               rowProceso["idPartida"] = WebUtility.HtmlDecode(rowPartida.Cells[0].Text);
               rowProceso["mMontoMX"] = WebUtility.HtmlDecode(rowPartida.Cells[2].Text); // La tercer columna siempre corresponde a la moneda mexicana
               oENTCotizacion.tblCotizacionPartidas.Rows.Add(rowProceso);
            }

            // Servicios
            oENTCotizacion.tblServicios = new DataTable("tblServicios");
            oENTCotizacion.tblServicios.Columns.Add("idEntry", typeof(Int32));
            for (int i = 0; i < this.chkServicio.Items.Count; i++){

               if (this.chkServicio.Items[i].Selected){
                  rowProceso = oENTCotizacion.tblServicios.NewRow();
                  rowProceso["idEntry"] = this.chkServicio.Items[i].Value;
                  oENTCotizacion.tblServicios.Rows.Add(rowProceso);
               }
            }

            // Transacción
            oENTResponse = oBPCotizacion.InsertCotizacion(oENTCotizacion);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            MontoCotizado();
            this.pnlAction.Visible = false;

         }catch(Exception ex){
            throw(ex);
         }
      }

      private void SelectCiudad(Boolean Origen){
         ENTCiudad oENTCiudad = new ENTCiudad();
			ENTResponse oENTResponse = new ENTResponse();

			BPCiudad oBPCiudad = new BPCiudad();

			try{

            // Formulario
            oENTCiudad.idCiudad = 0;
            oENTCiudad.idEstado  = (Origen ? Int32.Parse(this.ddlEstadoOrigen.SelectedValue) : Int32.Parse(this.ddlEstadoDestino.SelectedValue));
            oENTCiudad.idPais    = (Origen ? Int32.Parse(this.ddlPaisOrigen.SelectedValue) : Int32.Parse(this.ddlPaisDestino.SelectedValue));
            oENTCiudad.sNombre = "";
            oENTCiudad.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { this.lblMessage.Text = oENTResponse.sMessage; }

            // Llenado de combo
            if(Origen){
            
               if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                  this.ddlCiudadOrigen.Items.Clear();
                  this.ddlCiudadOrigen.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

               }else{

                  this.ddlCiudadOrigen.DataTextField = "sNombre";
                  this.ddlCiudadOrigen.DataValueField = "idCiudad";
                  this.ddlCiudadOrigen.DataSource = oENTResponse.dsResponse.Tables[1];
                  this.ddlCiudadOrigen.DataBind();

               }

            }else{
               
               if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                  this.ddlCiudadDestino.Items.Clear();
                  this.ddlCiudadDestino.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

               }else{

                  this.ddlCiudadDestino.DataTextField = "sNombre";
                  this.ddlCiudadDestino.DataValueField = "idCiudad";
                  this.ddlCiudadDestino.DataSource = oENTResponse.dsResponse.Tables[1];
                  this.ddlCiudadDestino.DataBind();

               }

            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCotizacion(){
         ENTCotizacion oENTCotizacion = new ENTCotizacion();
			ENTResponse oENTResponse = new ENTResponse();

			BPCotizacion oBPCotizacion = new BPCotizacion();

			try{

            // Formulario
            oENTCotizacion.idPickUp = Int32.Parse(this.hddPickUp.Value);
            oENTCotizacion.tiRecalculo = 0;

				// Transacción
				oENTResponse = oBPCotizacion.SelectCotizacion(oENTCotizacion);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Por default es una nueva Cotización
            this.hddInsert.Value = "1";

            // Llenado de Formulario - Ruta
            if (oENTResponse.dsResponse.Tables[1].Rows[0]["idCotizacion"].ToString() != "0"){

               // No existe la cotización
               this.hddInsert.Value = "0";

               // Pais, Estado y Ciudad Origen
               this.ddlPaisOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idPais_Origen"].ToString();

               SelectEstado(true);
               this.ddlEstadoOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idEstado_Origen"].ToString();

               SelectCiudad(true);
               this.ddlCiudadOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idCiudad_Origen"].ToString();

               // Pais, Estado y Ciudad Destino
               this.ddlPaisDestino.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idPais_Destino"].ToString();

               SelectEstado(false);
               this.ddlEstadoDestino.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idEstado_Destino"].ToString();

               SelectCiudad(false);
               this.ddlCiudadDestino.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idCiudad_Destino"].ToString();
            }


            // Llenado de Formulario - Servicios
            for (int i = 0; i < this.chkServicio.Items.Count; i++){

               this.chkServicio.Items[i].Selected = (oENTResponse.dsResponse.Tables[2].Select("idServicio=" + this.chkServicio.Items[i].Value).Length > 0 ? true : false);
            }

            // Llenado de Formulario - Medidas
            this.txtCarga_Peso.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["dPeso"].ToString();
            this.txtCarga_Volumen.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["dVolumen"].ToString();
            this.ddlCarga_UnidadMedidaPeso.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idUnidadMedida_Peso"].ToString();
            this.ddlCarga_UnidadMedidaVolumen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idUnidadMedida_Volumen"].ToString();

            // Llenado de Formulario - Varios
            this.ddlMoneda.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idMoneda"].ToString();
            this.txtDescuentoCliente.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["mDescuento"].ToString();
            this.txtCargoExtra.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["mCargoExtra"].ToString();

            // Llenado de Formulario - GridView
            this.gvCotizacion.DataSource = oENTResponse.dsResponse.Tables[3];
            this.gvCotizacion.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCotizacion_Recalculo(){
         ENTCotizacion oENTCotizacion = new ENTCotizacion();
			ENTResponse oENTResponse = new ENTResponse();

			BPCotizacion oBPCotizacion = new BPCotizacion();

			try{

            // Formulario
            oENTCotizacion.idPickUp = Int32.Parse(this.hddPickUp.Value);
            oENTCotizacion.tiRecalculo = 1;

				// Transacción
				oENTResponse = oBPCotizacion.SelectCotizacion(oENTCotizacion);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de Formulario - Servicios
            for (int i = 0; i < this.chkServicio.Items.Count; i++){

               this.chkServicio.Items[i].Selected = (oENTResponse.dsResponse.Tables[2].Select("idServicio=" + this.chkServicio.Items[i].Value).Length > 0 ? true : false);
            }

            // Llenado de Formulario - Medidas
            this.txtCarga_Peso.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["dPeso"].ToString();
            this.txtCarga_Volumen.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["dVolumen"].ToString();
            this.ddlCarga_UnidadMedidaPeso.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idUnidadMedida_Peso"].ToString();
            this.ddlCarga_UnidadMedidaVolumen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idUnidadMedida_Volumen"].ToString();

            // Llenado de Formulario - GridView
            this.gvCotizacion.DataSource = oENTResponse.dsResponse.Tables[3];
            this.gvCotizacion.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectEstado(Boolean Origen){
         ENTEstado oENTEstado = new ENTEstado();
			ENTResponse oENTResponse = new ENTResponse();

			BPEstado oBPEstado = new BPEstado();

			try{

            // Formulario
            oENTEstado.idEstado = 0;
            oENTEstado.idPais = (Origen ? Int32.Parse(this.ddlPaisOrigen.SelectedValue) : Int32.Parse(this.ddlPaisDestino.SelectedValue));
            oENTEstado.sNombre = "";
            oENTEstado.tiActivo = 1;

				// Transacción
				oENTResponse = oBPEstado.SelectEstado(oENTEstado);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { this.lblMessage.Text = oENTResponse.sMessage; }

            // Llenado de combo
            if(Origen){

                if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                   this.ddlEstadoOrigen.Items.Clear();
                   this.ddlEstadoOrigen.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

               }else{

                  this.ddlEstadoOrigen.DataTextField = "sNombre";
                  this.ddlEstadoOrigen.DataValueField = "idEstado";
                  this.ddlEstadoOrigen.DataSource = oENTResponse.dsResponse.Tables[1];
                  this.ddlEstadoOrigen.DataBind();

               }

            }else{
               
               if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                   this.ddlEstadoDestino.Items.Clear();
                   this.ddlEstadoDestino.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

               }else{

                  this.ddlEstadoDestino.DataTextField = "sNombre";
                  this.ddlEstadoDestino.DataValueField = "idEstado";
                  this.ddlEstadoDestino.DataSource = oENTResponse.dsResponse.Tables[1];
                  this.ddlEstadoDestino.DataBind();

               }

            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectMoneda(){
         ENTMoneda oENTMoneda = new ENTMoneda();
			ENTResponse oENTResponse = new ENTResponse();

			BPMoneda oBPMoneda = new BPMoneda();

			try{

            // Formulario
            oENTMoneda.idMoneda = 0;
            oENTMoneda.sNombre = "";
            oENTMoneda.tiActivo = 1;

				// Transacción
				oENTResponse = oBPMoneda.SelectMoneda(oENTMoneda);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlMoneda.DataTextField = "sNombre";
				this.ddlMoneda.DataValueField = "idMoneda";
				this.ddlMoneda.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlMoneda.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectPais(Boolean Origen){
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
            if(Origen){

               this.ddlPaisOrigen.DataTextField = "sNombre";
               this.ddlPaisOrigen.DataValueField = "idPais";
               this.ddlPaisOrigen.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlPaisOrigen.DataBind();

            }else{

               this.ddlPaisDestino.DataTextField = "sNombre";
               this.ddlPaisDestino.DataValueField = "idPais";
               this.ddlPaisDestino.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlPaisDestino.DataBind();

            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectServicios(){
         ENTServicio oENTServicio = new ENTServicio();
			ENTResponse oENTResponse = new ENTResponse();

			BPServicio oBPServicio = new BPServicio();

			try{

            // Formulario
            oENTServicio.idServicio = 0;
            oENTServicio.sNombre = "";
            oENTServicio.tiActivo = 1;

				// Transacción
				oENTResponse = oBPServicio.SelectServicio(oENTServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de CheckBoxList
				this.chkServicio.DataTextField = "sDescripcion";
            this.chkServicio.DataValueField = "idServicio";
            this.chkServicio.DataSource = oENTResponse.dsResponse.Tables[1];
            this.chkServicio.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectUnidadMedida_Peso(){
         ENTUnidadMedida oENTUnidadMedida = new ENTUnidadMedida();
			ENTResponse oENTResponse = new ENTResponse();

			BPUnidadMedida oBPUnidadMedida = new BPUnidadMedida();

			try{

            // Formulario
            oENTUnidadMedida.idUnidadMedida = 0;
            oENTUnidadMedida.idMagnitudFisica = 2;
            oENTUnidadMedida.sNombre = "";
            oENTUnidadMedida.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUnidadMedida.SelectUnidadMedida(oENTUnidadMedida);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlCarga_UnidadMedidaPeso.DataTextField = "sNombre";
            this.ddlCarga_UnidadMedidaPeso.DataValueField = "idUnidadMedida";
            this.ddlCarga_UnidadMedidaPeso.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlCarga_UnidadMedidaPeso.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectUnidadMedida_Volumen(){
         ENTUnidadMedida oENTUnidadMedida = new ENTUnidadMedida();
			ENTResponse oENTResponse = new ENTResponse();

			BPUnidadMedida oBPUnidadMedida = new BPUnidadMedida();

			try{

            // Formulario
            oENTUnidadMedida.idUnidadMedida = 0;
            oENTUnidadMedida.idMagnitudFisica = 1;
            oENTUnidadMedida.sNombre = "";
            oENTUnidadMedida.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUnidadMedida.SelectUnidadMedida(oENTUnidadMedida);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlCarga_UnidadMedidaVolumen.DataTextField = "sNombre";
            this.ddlCarga_UnidadMedidaVolumen.DataValueField = "idUnidadMedida";
            this.ddlCarga_UnidadMedidaVolumen.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlCarga_UnidadMedidaVolumen.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateCotizacion(){
         ENTCotizacion oENTCotizacion = new ENTCotizacion();
         ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

         BPCotizacion oBPCotizacion = new BPCotizacion();
         DataRow rowProceso = null;

         try
         {

            // Valores por default
            if(this.txtCarga_Peso.Text.Trim()         == "") { this.txtCarga_Peso.Text = "0"; }
            if(this.txtCarga_Volumen.Text.Trim()      == "") { this.txtCarga_Volumen.Text = "0"; }
            if(this.txtCargoExtra.Text.Trim()         == "") { this.txtCargoExtra.Text = "0"; }
            if(this.txtDescuentoCliente.Text.Trim()   == "") { this.txtDescuentoCliente.Text = "0"; }

            // Datos de usuario
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTCotizacion.idCompany = oENTSession.idCompany;
            oENTCotizacion.idCiudad_Destino = Int32.Parse(this.ddlCiudadDestino.SelectedValue);
            oENTCotizacion.idCiudad_Origen = Int32.Parse(this.ddlCiudadOrigen.SelectedValue);
            oENTCotizacion.idMoneda = Int32.Parse(this.ddlMoneda.SelectedValue);
            oENTCotizacion.idPickUp = Int32.Parse(this.hddPickUp.Value);
            oENTCotizacion.idUnidadMedida_Peso = Int32.Parse(this.ddlCarga_UnidadMedidaPeso.SelectedValue);
            oENTCotizacion.idUnidadMedida_Volumen = Int32.Parse(this.ddlCarga_UnidadMedidaVolumen.SelectedValue);
            oENTCotizacion.dPeso = Decimal.Parse(this.txtCarga_Peso.Text);
            oENTCotizacion.dVolumen = Decimal.Parse(this.txtCarga_Volumen.Text);
            oENTCotizacion.mCargoExtra = Decimal.Parse(this.txtCargoExtra.Text);
            oENTCotizacion.mDescuento = Decimal.Parse(this.txtDescuentoCliente.Text);

            // Partidas
            oENTCotizacion.tblCotizacionPartidas = new DataTable("tblCotizacionPartidas");
            oENTCotizacion.tblCotizacionPartidas.Columns.Add("idPartida", typeof(Int16));
            oENTCotizacion.tblCotizacionPartidas.Columns.Add("mMontoMX", typeof(Decimal));

            foreach (GridViewRow rowPartida in this.gvCotizacion.Rows){

               rowProceso = oENTCotizacion.tblCotizacionPartidas.NewRow();
               rowProceso["idPartida"] = WebUtility.HtmlDecode(rowPartida.Cells[0].Text);
               rowProceso["mMontoMX"] = WebUtility.HtmlDecode(rowPartida.Cells[2].Text); // La tercer columna siempre corresponde a la moneda mexicana
               oENTCotizacion.tblCotizacionPartidas.Rows.Add(rowProceso);
            }

            // Servicios
            oENTCotizacion.tblServicios = new DataTable("tblServicios");
            oENTCotizacion.tblServicios.Columns.Add("idEntry", typeof(Int32));
            for (int i = 0; i < this.chkServicio.Items.Count; i++){

               if (this.chkServicio.Items[i].Selected){
                  rowProceso = oENTCotizacion.tblServicios.NewRow();
                  rowProceso["idEntry"] = this.chkServicio.Items[i].Value;
                  oENTCotizacion.tblServicios.Rows.Add(rowProceso);
               }
            }

            // Transacción
            oENTResponse = oBPCotizacion.UpdateCotizacion(oENTCotizacion);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            MontoCotizado();
            this.pnlAction.Visible = false;

         }catch(Exception ex){
            throw(ex);
         }
      }

      
      // Eventos del control

      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) {
            this.lblMessage.Text = "";
            return;
         }

         // Lógica de la página
         try{

            // Estado inicial
            this.pnlAction.Visible = false;

            // Llenado de controles
            SelectPais(true);
            SelectPais(false);
            SelectEstado(true);
            SelectEstado(false);
            SelectCiudad(true);
            SelectCiudad(false);
            SelectServicios();
            SelectUnidadMedida_Peso();
            SelectUnidadMedida_Volumen();
            SelectMoneda();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void btnCrear_Click(object sender, EventArgs e){
         try
         {

            // Tipo de transacción
            switch (this.hddInsert.Value){
               case "0":
                  UpdateCotizacion();
                  break;

               case "1":
                  InsertCotizacion();
                  break;

               default:
                  throw(new Exception("Transacción inválida"));
            }

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void btnTarificar_Click(object sender, EventArgs e){

      }

      protected void btnRecalcular_Click(object sender, EventArgs e){
         try
         {

            // Recalcular los servicios y medidas en base al PickUp seleccionado
            SelectCotizacion_Recalculo();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void ddlPaisDestino_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de estados y ciudades
            SelectEstado(false);
            SelectCiudad(false);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void ddlEstadoDestino_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de ciudades
            SelectCiudad(false);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void ddlPaisOrigen_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de estados y ciudades
            SelectEstado(true);
            SelectCiudad(true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void ddlEstadoOrigen_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de ciudades
            SelectCiudad(true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

      protected void gvCotizacion_RowDataBound(object sender, GridViewRowEventArgs e){

         // Determinar el tipo de columa
         switch (e.Row.RowType){
            case DataControlRowType.Header:

               // Redimensionar el arragle acorde al número de columnas dinámicas del GridView
               dTotales = new Decimal[e.Row.Cells.Count];
               break;


            case DataControlRowType.DataRow:

               // Sombra en fila Over y Out
               e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action';");
               e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action';");

               // Sumatoria de totales de la fila actual
               for (int i = 0; i < e.Row.Cells.Count  - 1; i++){

                  // Las primeras 2 columnas corresponden a Partida y Descripción
                  if (i == 0 || i == 1){ dTotales[i] = 0; } else { dTotales[i] = dTotales[i] + Decimal.Parse(e.Row.Cells[i].Text); }
               }
               break;


            case DataControlRowType.Footer:

               // Las primeras 2 columnas corresponden a Partida y Descripción
               for (int i = 0; i < e.Row.Cells.Count  - 1; i++){
                  if (i == 0 || i == 1) { e.Row.Cells[i].Text = ""; } else { e.Row.Cells[i].Text = dTotales[i].ToString(); }
               }
               break;
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

      protected void imgCotizar_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Generar evento
            if (ClickCotizarImage != null) { ClickCotizarImage(); }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
         }
      }

   }
}