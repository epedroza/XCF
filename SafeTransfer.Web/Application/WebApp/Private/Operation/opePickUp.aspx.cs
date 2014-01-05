/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	opePickUp
' Autor:		Ruben.Cobos
' Fecha:		21-Octubre-2013
'
' Descripción:
'           Pantalla de PickUp de la aplicación
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

namespace SafeTransfer.Web.Application.WebApp.Private.Operation
{
   public partial class opePickUp : BPPage
   {
      
      // Utilerías
      Function utilFunction = new Function();

      
      // Rutinas del programador

      private void AgregaNuevaCarga(){
         DataTable tblServicios;
         DataTable tblCarga;
         DataRow rowCarga;

         String sIDServicios = ",";
         String sServicios = "";

         try
         {

            // Obtener el DataTable del GridView
            tblCarga = utilFunction.ParseGridViewToDataTable(this.gvCarga, false);

            // Obtener los Servicios del ViewState
            tblServicios = (DataTable)this.ViewState["tblServicios"];

            // Agregar la nueva fila
            rowCarga = tblCarga.NewRow();
            rowCarga["idTipoPieza"]             = this.ddlCarga_TipoPieza.SelectedValue;
            rowCarga["idUnidadMedidaPeso"]      = this.ddlCarga_UnidadMedidaPeso.SelectedValue;
            rowCarga["idUnidadMedidaVolumen"]   = this.ddlCarga_UnidadMedidaVolumen.SelectedValue;
            rowCarga["dPiezas"]                 = this.txtCarga_Piezas.Text.Trim();
            rowCarga["sTipoPieza"]              = this.ddlCarga_TipoPieza.SelectedItem.Text;
            rowCarga["dPeso"]                   = this.txtCarga_Peso.Text.Trim();
            rowCarga["sUnidadMedidaPeso"]       = this.ddlCarga_UnidadMedidaPeso.SelectedItem.Text;
            rowCarga["dVolumen"]                = this.txtCarga_Volumen.Text.Trim();
            rowCarga["sUnidadMedidaVolumen"]    = this.ddlCarga_UnidadMedidaVolumen.SelectedItem.Text;
            rowCarga["sInstrucciones"]          = this.txtCarga_Instrucciones.Text.Trim();

            // Servicios
            for (int i = 0; i < this.chkServicio.Items.Count; i++){
               if (this.chkServicio.Items[i].Selected){

                  sIDServicios = sIDServicios + this.chkServicio.Items[i].Value + ",";
                  sServicios = sServicios + tblServicios.Select("idServicio=" + this.chkServicio.Items[i].Value)[0]["sDescripcion"].ToString() + ", ";
               }
            }
            rowCarga["sIDServicios"]   = (sIDServicios == "," ? "" : sIDServicios);
            rowCarga["sServicios"]     = (sServicios != "" ? sServicios.Substring(0, sServicios.Length - 2) : "");
            
            tblCarga.Rows.Add(rowCarga);

            // Actualizar GridView
            this.gvCarga.DataSource = tblCarga;
            this.gvCarga.DataBind();

            // Limpiar formulario
            this.txtCarga_Piezas.Text = "";
            this.ddlCarga_TipoPieza.SelectedIndex = 0;
            this.txtCarga_Peso.Text = "";
            this.ddlCarga_UnidadMedidaPeso.SelectedIndex = 0;
            this.txtCarga_Volumen.Text = "";
            this.ddlCarga_UnidadMedidaVolumen.SelectedIndex = 0;
            this.txtCarga_Instrucciones.Text = "";
            for (int k = 0; k < this.chkServicio.Items.Count; k++){ this.chkServicio.Items[k].Selected = false; }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtCarga_Piezas.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void AgregaNuevoContacto(){
         DataTable tblContacto;
         DataRow rowContacto;

         try
         {

            // Obtener el DataTable del GridView
            tblContacto = utilFunction.ParseGridViewToDataTable(this.gvContactos, false);

            // Agregar la nueva fila
            rowContacto = tblContacto.NewRow();
            rowContacto["idTipoContacto"] = this.ddlContacto_Tipo.SelectedValue;
            rowContacto["tiRequerido"]    = (this.chkContacto_Requerido.Checked ? "1" : "0");
            rowContacto["sTipoContacto"]  = this.ddlContacto_Tipo.SelectedItem.Text;
            rowContacto["sNombre"]        = this.txtContacto_Nombre.Text.Trim();
            rowContacto["sTelefono"]      = this.txtContacto_Telefono.Text.Trim();
            rowContacto["sCorreo"]        = this.txtContacto_Correo.Text.Trim();
            rowContacto["sComentarios"]   = this.txtContacto_Comentarios.Text.Trim();
            rowContacto["sRequerido"]     = (this.chkContacto_Requerido.Checked ? "*" : "");
            tblContacto.Rows.Add(rowContacto);

            // Actualizar GridView
            this.gvContactos.DataSource = tblContacto;
            this.gvContactos.DataBind();

            // Limpiar formulario
            this.ddlContacto_Tipo.SelectedIndex = 0;
            this.txtContacto_Nombre.Text = "";
            this.txtContacto_Telefono.Text = "";
            this.txtContacto_Correo.Text = "";
            this.txtContacto_Comentarios.Text = "";
            this.chkContacto_Requerido.Checked = false;

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlContacto_Tipo.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void DeleteCarga(Int32 iRow){
         DataTable tblCarga;
         Int32 iCurrentRow = 0;

         try
         {

            // Obtener el DataTable del GridView
            tblCarga = utilFunction.ParseGridViewToDataTable(this.gvCarga, false);

            // Eliminar la fila seleccionada
            foreach(DataRow rowCarga in tblCarga.Rows){
               
               if (iCurrentRow == iRow){

                  tblCarga.Rows.Remove(rowCarga);
                  break;
               }
               iCurrentRow = iCurrentRow + 1;
            }

            // Actualizar GridView
            this.gvCarga.DataSource = tblCarga;
            this.gvCarga.DataBind();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtCarga_Piezas.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void DeleteContacto(Int32 iRow){
         DataTable tblContacto;
         Int32 iCurrentRow = 0;

         try
         {

            // Obtener el DataTable del GridView
            tblContacto = utilFunction.ParseGridViewToDataTable(this.gvContactos, false);

            // Eliminar la fila seleccionada
            foreach(DataRow rowContacto in tblContacto.Rows){

               if (iCurrentRow == iRow) {
                  tblContacto.Rows.Remove(rowContacto);
                  break;
               }
               iCurrentRow = iCurrentRow + 1;
            }

            // Actualizar GridView
            this.gvContactos.DataSource = tblContacto;
            this.gvContactos.DataBind();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlContacto_Tipo.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void FillDateAndTimeCombos(){
         String sItem;

         try
         {

            // Llenado de combos de hora
            for (int Hora = 23; Hora >= 0; Hora--){

               // Valor a mostrar
               sItem = "0" + Hora.ToString();
               sItem = sItem.Substring(sItem.Length -2);
               
               // Llenar los combos de horas
               this.ddlPickUpHora_Desde.Items.Insert(0, new ListItem(sItem, sItem));
               this.ddlPickUpHora_Hasta.Items.Insert(0, new ListItem(sItem, sItem));
               this.ddlMuelleHora_Cierre.Items.Insert(0, new ListItem(sItem, sItem));
            }

            // Llenado de combos de hora
            for (int Minuto = 45; Minuto >= 0; Minuto-=15){

               // Valor a mostrar
               sItem = "0" + Minuto.ToString();
               sItem = sItem.Substring(sItem.Length - 2);

               // Llenar los combos de minutos
               this.ddlPickUpMinuto_Desde.Items.Insert(0, new ListItem(sItem, sItem));
               this.ddlPickUpMinuto_Hasta.Items.Insert(0, new ListItem(sItem, sItem));
               this.ddlMuelleMinuto_Cierre.Items.Insert(0, new ListItem(sItem, sItem));
            }

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void InsertPickUp(){
         ENTPickUp oENTPickUp = new ENTPickUp();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPPickUp oBPPickUp = new BPPickUp();

         DataRow rowServicio = null;
         Int32 iNoPartida = 0;
         String sServicios = "";

			try{

            // Datos de usuario
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTPickUp.idCompany = oENTSession.idCompany;
            oENTPickUp.idCentroServicio = Int32.Parse(this.ddlCentroServicio.SelectedValue);
            oENTPickUp.idSucursal = this.wucSelectorCliente.idSucursal;
            oENTPickUp.idCiudad = Int32.Parse(this.ddlCiudad.SelectedValue);
            oENTPickUp.sCliente = this.wucSelectorCliente.Text.Trim();
            oENTPickUp.sSucursal = this.txtSucursal.Text.Trim();
            oENTPickUp.sCodigoPostal = this.txtCodigoPostal.Text.Trim();
            oENTPickUp.sDireccion = this.txtDireccion.Text.Trim();
            oENTPickUp.dtPickUp = this.wucCalendar.BeginDate;
            oENTPickUp.tmVentanaInicio = this.ddlPickUpHora_Desde.SelectedValue + ":" + this.ddlPickUpMinuto_Desde.SelectedValue;
            oENTPickUp.tmVentanaFinal = this.ddlPickUpHora_Hasta.SelectedValue + ":" + this.ddlPickUpMinuto_Hasta.SelectedValue;
            oENTPickUp.tiLlamarParaConfirmar = (this.chkLLamar.Checked ? Int16.Parse("1") : Int16.Parse("0"));
            oENTPickUp.sObservaciones = this.txtObservaciones.Text.Trim();
            oENTPickUp.tmCierreMuelle = this.ddlMuelleHora_Cierre.SelectedValue + ":" + this.ddlMuelleMinuto_Cierre.SelectedValue;

            // Contactos del PickUp
            oENTPickUp.tblContactos = utilFunction.ParseGridViewToDataTable(this.gvContactos, true);
            oENTPickUp.tblContactos.Columns.Remove("sTipoContacto");
            oENTPickUp.tblContactos.Columns.Remove("sRequerido");

            // Carga del PickUp
            oENTPickUp.tblCarga = utilFunction.ParseGridViewToDataTable(this.gvCarga, true);

            // Partidas
            oENTPickUp.tblCarga.Columns.Add("tiNoPartida", typeof(Int16));
            foreach(DataRow rowPartida in oENTPickUp.tblCarga.Rows){
               iNoPartida = iNoPartida + 1;
               rowPartida["tiNoPartida"] = iNoPartida;
            }

            // Servicios por cada carga
            oENTPickUp.tblCargaServicio = new DataTable("tblCargaServicio");
            oENTPickUp.tblCargaServicio.Columns.Add("tiNoPartida", typeof(Int16));
            oENTPickUp.tblCargaServicio.Columns.Add("idServicio", typeof(Int32));
            foreach(DataRow rowServicioCarga in oENTPickUp.tblCarga.Rows){

               sServicios = rowServicioCarga["sIDServicios"].ToString();
               foreach(String idServicio in rowServicioCarga["sIDServicios"].ToString().Split(new Char[] { ',' }) ){

                  if(idServicio != ""){
                     rowServicio = oENTPickUp.tblCargaServicio.NewRow();
                     rowServicio["tiNoPartida"] = rowServicioCarga["tiNoPartida"];
                     rowServicio["idServicio"] = idServicio;
                     oENTPickUp.tblCargaServicio.Rows.Add(rowServicio);
                  }

               }

            }

            // Eliminar columnas
            oENTPickUp.tblCarga.Columns.Remove("sIDServicios");
            oENTPickUp.tblCarga.Columns.Remove("sTipoPieza");
            oENTPickUp.tblCarga.Columns.Remove("sUnidadMedidaPeso");
            oENTPickUp.tblCarga.Columns.Remove("sUnidadMedidaVolumen");
            oENTPickUp.tblCarga.Columns.Remove("sServicios");

            // Transacción
            oENTResponse = oBPPickUp.InsertPickUp(oENTPickUp);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            SelectPickUp_Full(false);
            MovePickUp_ByID(oENTResponse.dsResponse.Tables[1].Rows[0]["idPickUp"].ToString());

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('PickUp creado con éxito!', 'Success', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void MovePickUp(Boolean Forward){
         DataTable tblPickUp;

         DataTable relPickUpCarga;
         DataTable relPickUpCarga_Filtrado;

         DataTable relPickUpContacto;
         DataTable relPickUpContacto_Filtrado;

         DataRow rowTemporal;

         String idNextPickUp = "";

         try
         {

            // Obtener los PickUp's del ViewState
            tblPickUp = (DataTable)this.ViewState["tblPickUp"];
            relPickUpCarga = (DataTable)this.ViewState["relPickUpCarga"];
            relPickUpContacto = (DataTable)this.ViewState["relPickUpContacto"];

            // Recuperación de Nuevo/Atrás
            if (Forward == false && this.hddCurrentPickUp.Value == "-1"){ Forward = true; }

            // Validaciones
            if(tblPickUp.Select("idPickUp " + (Forward ? "> " : "< " )  + this.hddCurrentPickUp.Value, "idPickUp").Length == 0 ){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Se ha llegado al " + (Forward ? "final " : "inicio ") + " del listado', 'Success', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
               return;
            }

            // Obtener el siguente PickUp
            idNextPickUp = tblPickUp.Select("idPickUp " + (Forward ? "> " : "< ") + this.hddCurrentPickUp.Value, "idPickUp" + (Forward ? "" : " DESC"))[0]["idPickUp"].ToString();

            // Limpiar el formulario
            SetForm_NuevoPickUp();

            // Información de PickUp
            this.hddCurrentPickUp.Value = idNextPickUp;
            this.litNoPickUp.Text = "<table border='0' cellpadding='0' cellspacing='0'><tr><td>PickUp:&nbsp;&nbsp;</td><td><div style='border-bottom:1px solid; text-align:center; width:120px'>" + idNextPickUp + "</div></td></tr></table>";
            this.ddlCentroServicio.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["idCentroServicio"].ToString();
            this.wucSelectorCliente.idSucursal = Int32.Parse(tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["idSucursal"].ToString());
            this.wucSelectorCliente.Text = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["sCliente"].ToString();
            this.txtSucursal.Text = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["sSucursal"].ToString();
            this.txtCodigoPostal.Text = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["sCodigoPostal"].ToString();
            this.txtDireccion.Text = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["sDireccion"].ToString();
            this.wucCalendar.SetDate(DateTime.Parse(tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["dtPickUp"].ToString()));
            this.chkLLamar.Checked = (tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tiLlamarParaConfirmar"].ToString() == "1" ? true : false);
            this.txtObservaciones.Text = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["sObservaciones"].ToString();
            this.ddlPickUpHora_Desde.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmVentanaInicio"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlPickUpMinuto_Desde.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmVentanaInicio"].ToString().Split(new Char[] { ':' })[1].ToString();
            this.ddlPickUpHora_Hasta.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmVentanaFinal"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlPickUpMinuto_Hasta.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmVentanaFinal"].ToString().Split(new Char[] { ':' })[1].ToString();
            this.ddlMuelleHora_Cierre.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmCierreMuelle"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlMuelleMinuto_Cierre.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["tmCierreMuelle"].ToString().Split(new Char[] { ':' })[1].ToString();
            
            this.ddlPais.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["idPais"].ToString();

            SelectEstado();
            this.ddlEstado.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["idEstado"].ToString();

            SelectCiudad();
            this.ddlCiudad.SelectedValue = tblPickUp.Select("idPickUp = " + idNextPickUp)[0]["idCiudad"].ToString();

            // Información de la Carga del PickUp
            relPickUpCarga_Filtrado = relPickUpCarga.Clone();
            foreach(DataRow rowCarga in relPickUpCarga.Select("idPickUp = " + idNextPickUp)){
               rowTemporal = relPickUpCarga_Filtrado.NewRow();
               rowTemporal["idTipoPieza"]             = rowCarga["idTipoPieza"];
               rowTemporal["idUnidadMedidaPeso"]      = rowCarga["idUnidadMedidaPeso"];
               rowTemporal["idUnidadMedidaVolumen"]   = rowCarga["idUnidadMedidaVolumen"];
               rowTemporal["sIDServicios"]            = rowCarga["sIDServicios"];
               rowTemporal["dPiezas"]                 = rowCarga["dPiezas"];
               rowTemporal["sTipoPieza"]              = rowCarga["sTipoPieza"];
               rowTemporal["dPeso"]                   = rowCarga["dPeso"];
               rowTemporal["sUnidadMedidaPeso"]       = rowCarga["sUnidadMedidaPeso"];
               rowTemporal["dVolumen"]                = rowCarga["dVolumen"];
               rowTemporal["sUnidadMedidaVolumen"]    = rowCarga["sUnidadMedidaVolumen"];
               rowTemporal["sInstrucciones"]          = rowCarga["sInstrucciones"];
               rowTemporal["sServicios"]              = rowCarga["sServicios"];
               relPickUpCarga_Filtrado.Rows.Add(rowTemporal);
            }
            this.gvCarga.DataSource = relPickUpCarga_Filtrado;
            this.gvCarga.DataBind();

            // Información de los Contactos del PickUp   relPickUpContacto_Filtrado
            relPickUpContacto_Filtrado = relPickUpContacto.Clone();
            foreach(DataRow rowCarga in relPickUpContacto.Select("idPickUp = " + idNextPickUp)){
               rowTemporal = relPickUpContacto_Filtrado.NewRow();
               rowTemporal["idTipoContacto"] = rowCarga["idTipoContacto"];
               rowTemporal["tiRequerido"]    = rowCarga["tiRequerido"];
               rowTemporal["sTipoContacto"]  = rowCarga["sTipoContacto"];
               rowTemporal["sNombre"]        = rowCarga["sNombre"];
               rowTemporal["sTelefono"]      = rowCarga["sTelefono"];
               rowTemporal["sCorreo"]        = rowCarga["sCorreo"];
               rowTemporal["sComentarios"]   = rowCarga["sComentarios"];
               rowTemporal["sRequerido"]     = rowCarga["sRequerido"];
               relPickUpContacto_Filtrado.Rows.Add(rowTemporal);
            }

            this.gvContactos.DataSource = relPickUpContacto_Filtrado;
            this.gvContactos.DataBind();

            // Obtener el monto de la Cotizacion del PickUp actual
            this.wucCotizador.Enable = true;
            this.wucCotizador.idPickUp = Int32.Parse(idNextPickUp);
            this.wucCotizador.MontoCotizado();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

         }catch(Exception ex){
            throw(ex);
         }
      }

      private void MovePickUp_ByID(String idPickUp){
         DataTable tblPickUp;

         DataTable relPickUpCarga;
         DataTable relPickUpCarga_Filtrado;

         DataTable relPickUpContacto;
         DataTable relPickUpContacto_Filtrado;

         DataRow rowTemporal;

         try
         {

            // Obtener los PickUp's del ViewState
            tblPickUp = (DataTable)this.ViewState["tblPickUp"];
            relPickUpCarga = (DataTable)this.ViewState["relPickUpCarga"];
            relPickUpContacto = (DataTable)this.ViewState["relPickUpContacto"];

            // Limpiar el formulario
            SetForm_NuevoPickUp();

            // Validación
            if (tblPickUp.Select("idPickUp = " + idPickUp).Length == 0){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No se encontró el PickUp seleccionado', 'Warning', false); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
               return;
            }

            // Información de PickUp
            this.hddCurrentPickUp.Value = idPickUp;
            this.litNoPickUp.Text = "<table border='0' cellpadding='0' cellspacing='0'><tr><td>PickUp:&nbsp;&nbsp;</td><td><div style='border-bottom:1px solid; text-align:center; width:120px'>" + idPickUp + "</div></td></tr></table>";
            this.ddlCentroServicio.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["idCentroServicio"].ToString();
            this.wucSelectorCliente.idSucursal = Int32.Parse(tblPickUp.Select("idPickUp = " + idPickUp)[0]["idSucursal"].ToString());
            this.wucSelectorCliente.Text = tblPickUp.Select("idPickUp = " + idPickUp)[0]["sCliente"].ToString();
            this.txtSucursal.Text = tblPickUp.Select("idPickUp = " + idPickUp)[0]["sSucursal"].ToString();
            this.txtCodigoPostal.Text = tblPickUp.Select("idPickUp = " + idPickUp)[0]["sCodigoPostal"].ToString();
            this.txtDireccion.Text = tblPickUp.Select("idPickUp = " + idPickUp)[0]["sDireccion"].ToString();
            this.wucCalendar.SetDate(DateTime.Parse(tblPickUp.Select("idPickUp = " + idPickUp)[0]["dtPickUp"].ToString()));
            this.chkLLamar.Checked = (tblPickUp.Select("idPickUp = " + idPickUp)[0]["tiLlamarParaConfirmar"].ToString() == "1" ? true : false);
            this.txtObservaciones.Text = tblPickUp.Select("idPickUp = " + idPickUp)[0]["sObservaciones"].ToString();
            this.ddlPickUpHora_Desde.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmVentanaInicio"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlPickUpMinuto_Desde.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmVentanaInicio"].ToString().Split(new Char[] { ':' })[1].ToString();
            this.ddlPickUpHora_Hasta.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmVentanaFinal"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlPickUpMinuto_Hasta.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmVentanaFinal"].ToString().Split(new Char[] { ':' })[1].ToString();
            this.ddlMuelleHora_Cierre.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmCierreMuelle"].ToString().Split(new Char[] { ':' })[0].ToString();
            this.ddlMuelleMinuto_Cierre.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["tmCierreMuelle"].ToString().Split(new Char[] { ':' })[1].ToString();
            
            this.ddlPais.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["idPais"].ToString();

            SelectEstado();
            this.ddlEstado.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["idEstado"].ToString();

            SelectCiudad();
            this.ddlCiudad.SelectedValue = tblPickUp.Select("idPickUp = " + idPickUp)[0]["idCiudad"].ToString();

            // Información de la Carga del PickUp
            relPickUpCarga_Filtrado = relPickUpCarga.Clone();
            foreach(DataRow rowCarga in relPickUpCarga.Select("idPickUp = " + idPickUp)){
               rowTemporal = relPickUpCarga_Filtrado.NewRow();
               rowTemporal["idTipoPieza"]             = rowCarga["idTipoPieza"];
               rowTemporal["idUnidadMedidaPeso"]      = rowCarga["idUnidadMedidaPeso"];
               rowTemporal["idUnidadMedidaVolumen"]   = rowCarga["idUnidadMedidaVolumen"];
               rowTemporal["sIDServicios"]            = rowCarga["sIDServicios"];
               rowTemporal["dPiezas"]                 = rowCarga["dPiezas"];
               rowTemporal["sTipoPieza"]              = rowCarga["sTipoPieza"];
               rowTemporal["dPeso"]                   = rowCarga["dPeso"];
               rowTemporal["sUnidadMedidaPeso"]       = rowCarga["sUnidadMedidaPeso"];
               rowTemporal["dVolumen"]                = rowCarga["dVolumen"];
               rowTemporal["sUnidadMedidaVolumen"]    = rowCarga["sUnidadMedidaVolumen"];
               rowTemporal["sInstrucciones"]          = rowCarga["sInstrucciones"];
               rowTemporal["sServicios"]              = rowCarga["sServicios"];
               relPickUpCarga_Filtrado.Rows.Add(rowTemporal);
            }
            this.gvCarga.DataSource = relPickUpCarga_Filtrado;
            this.gvCarga.DataBind();

            // Información de los Contactos del PickUp   relPickUpContacto_Filtrado
            relPickUpContacto_Filtrado = relPickUpContacto.Clone();
            foreach(DataRow rowCarga in relPickUpContacto.Select("idPickUp = " + idPickUp)){
               rowTemporal = relPickUpContacto_Filtrado.NewRow();
               rowTemporal["idTipoContacto"] = rowCarga["idTipoContacto"];
               rowTemporal["tiRequerido"]    = rowCarga["tiRequerido"];
               rowTemporal["sTipoContacto"]  = rowCarga["sTipoContacto"];
               rowTemporal["sNombre"]        = rowCarga["sNombre"];
               rowTemporal["sTelefono"]      = rowCarga["sTelefono"];
               rowTemporal["sCorreo"]        = rowCarga["sCorreo"];
               rowTemporal["sComentarios"]   = rowCarga["sComentarios"];
               rowTemporal["sRequerido"]     = rowCarga["sRequerido"];
               relPickUpContacto_Filtrado.Rows.Add(rowTemporal);
            }

            this.gvContactos.DataSource = relPickUpContacto_Filtrado;
            this.gvContactos.DataBind();

            // Obtener el monto de la Cotizacion del PickUp actual
            this.wucCotizador.Enable = true;
            this.wucCotizador.idPickUp = Int32.Parse(idPickUp);
            this.wucCotizador.MontoCotizado();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

         }catch(Exception ex){
            throw(ex);
         }
      }

      private void RefreshTooltipServices(){
         DataTable tblServicios;

         try
         {

            // Validación
            if (this.ViewState["tblServicios"] == null){ return; }

            // Obtener los Servicios del ViewState
            tblServicios = (DataTable)this.ViewState["tblServicios"];

            // Tooltip a cada elemento del listado
            for (int i = 0; i < this.chkServicio.Items.Count; i++){

               this.chkServicio.Items[i].Attributes["title"] = tblServicios.Select("idServicio=" + this.chkServicio.Items[i].Value)[0]["sDescripcion"].ToString();
            }

         }catch(Exception ex){
            throw(ex);
         }
      }

      private void SelectCentroServicio(){
         ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPCentroServicio oBPCentroServicio = new BPCentroServicio();

			try{

            // Datos de usuario
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTCentroServicio.idCentroServicio = 0;
            oENTCentroServicio.idCompany = oENTSession.idCompany;
            oENTCentroServicio.sNombre = "";
            oENTCentroServicio.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCentroServicio.SelectCentroServicio(oENTCentroServicio);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlCentroServicio.DataTextField = "sNombre";
				this.ddlCentroServicio.DataValueField = "idCentroServicio";
				this.ddlCentroServicio.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlCentroServicio.DataBind();

				// Agregar Item de selección
				this.ddlCentroServicio.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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
            oENTCiudad.idEstado = Int32.Parse(this.ddlEstado.SelectedValue);
            oENTCiudad.idPais = Int32.Parse(this.ddlPais.SelectedValue);
            oENTCiudad.sNombre = "";
            oENTCiudad.tiActivo = 1;

				// Transacción
				oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false); focusControl('" + this.ddlEstado.ClientID + "');", true); }

            // Llenado de combo
            if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

               this.ddlCiudad.Items.Clear();
               this.ddlCiudad.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

            }else{

               this.ddlCiudad.DataTextField = "sNombre";
               this.ddlCiudad.DataValueField = "idCiudad";
               this.ddlCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlCiudad.DataBind();

            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectCliente(Int32 idSucursal){
         ENTCliente oENTCliente = new ENTCliente();
			ENTResponse oENTResponse = new ENTResponse();

			BPCliente oBPCliente = new BPCliente();

			try{

            // Formulario
            oENTCliente.idCliente   = 0;
            oENTCliente.idCompany   = 0;
            oENTCliente.idSucursal  = idSucursal;
            oENTCliente.sNombre     = "";
            oENTCliente.tiActivo    = 1;

				// Transacción
				oENTResponse = oBPCliente.SelectCliente(oENTCliente);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Llenado de formulario
            if(oENTResponse.dsResponse.Tables[2].Rows.Count == 0){

               this.txtSucursal.Text = "";
               this.txtCodigoPostal.Text = "";
               this.txtDireccion.Text = "";
            }else{

               this.txtSucursal.Text = oENTResponse.dsResponse.Tables[2].Rows[0]["sNombre"].ToString();
               this.txtCodigoPostal.Text = oENTResponse.dsResponse.Tables[2].Rows[0]["sCodigoPostal"].ToString();
               this.txtDireccion.Text = oENTResponse.dsResponse.Tables[2].Rows[0]["sDireccion"].ToString();

               this.ddlPais.SelectedValue = oENTResponse.dsResponse.Tables[2].Rows[0]["idPais"].ToString();

               SelectEstado();
               this.ddlEstado.SelectedValue = oENTResponse.dsResponse.Tables[2].Rows[0]["idEstado"].ToString();

               SelectCiudad();
               this.ddlCiudad.SelectedValue = oENTResponse.dsResponse.Tables[2].Rows[0]["idCiudad"].ToString();

               this.gvContactos.DataSource = oENTResponse.dsResponse.Tables[3];
               this.gvContactos.DataBind();
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtSucursal.ClientID + "');", true);

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
            oENTEstado.idPais = Int32.Parse(this.ddlPais.SelectedValue);
            oENTEstado.sNombre = "";
            oENTEstado.tiActivo = 1;

				// Transacción
				oENTResponse = oBPEstado.SelectEstado(oENTEstado);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false); focusControl('" + this.ddlPais.ClientID + "');", true); }

            // Llenado de combo
             if (oENTResponse.dsResponse.Tables[1].Rows.Count == 0 ){

                this.ddlEstado.Items.Clear();
                this.ddlEstado.Items.Insert(0, new ListItem("--Sin Elementos--", "-1"));

            }else{

               this.ddlEstado.DataTextField = "sNombre";
               this.ddlEstado.DataValueField = "idEstado";
               this.ddlEstado.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlEstado.DataBind();

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
				this.ddlPais.DataTextField = "sNombre";
				this.ddlPais.DataValueField = "idPais";
				this.ddlPais.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlPais.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectPickUp(){
         ENTPickUp oENTPickUp = new ENTPickUp();
			ENTResponse oENTResponse = new ENTResponse();

			BPPickUp oBPPickUp = new BPPickUp();

			try{

            // Formulario
            oENTPickUp.idPickUp = (this.txtPickUp.Text.Trim() == "" ? 0 : Int32.Parse(this.txtPickUp.Text.Trim()));
            oENTPickUp.sCliente = this.txtCliente.Text.Trim();
            oENTPickUp.idEstatusPickUp = 1;

				// Transacción
				oENTResponse = oBPPickUp.SelectPickUp(oENTPickUp);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false); focusControl('" + this.txtPickUp.ClientID + "');", true); }

            // Llenado de controles
            this.gvPickUp.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvPickUp.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectPickUp_Full(Boolean Move){
         ENTPickUp oENTPickUp = new ENTPickUp();
			ENTResponse oENTResponse = new ENTResponse();

         BPPickUp oBPPickUp = new BPPickUp();

			try{

            // Todos los PickUps activos
            oENTPickUp.idPickUp = 0;
            oENTPickUp.sCliente = "";
            oENTPickUp.idEstatusPickUp = 1;

				// Transacción
				oENTResponse = oBPPickUp.SelectPickUp(oENTPickUp);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Almacenar en ViewState
            this.ViewState["tblPickUp"] = oENTResponse.dsResponse.Tables[1];
            this.ViewState["relPickUpCarga"] = oENTResponse.dsResponse.Tables[2];
            this.ViewState["relPickUpContacto"] = oENTResponse.dsResponse.Tables[3];

            // No se encontraron PickUps
            if(oENTResponse.dsResponse.Tables[1].Rows.Count == 0){

               SetForm_NuevoPickUp();
               this.wucToolbar.Enabled_Back = false;
               this.wucToolbar.Enabled_Delete = false;
               this.wucToolbar.Enabled_Next = false;
               this.wucToolbar.Enabled_Release = false;
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No se encontraron PickUps abiertos', 'Warning', false); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
            }else{

               this.wucToolbar.Enabled_Back = true;
               this.wucToolbar.Enabled_Delete = true;
               this.wucToolbar.Enabled_Next = true;
               this.wucToolbar.Enabled_Release = true;

               // Posicionarse en el primer PickUp
               this.hddCurrentPickUp.Value = "0";
               if(Move){ MovePickUp(true); }else{ ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCentroServicio.ClientID + "');", true);}
            }

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectTipoContacto(){
         ENTTipoContacto oENTTipoContacto = new ENTTipoContacto();
			ENTResponse oENTResponse = new ENTResponse();

			BPTipoContacto oBPTipoContacto = new BPTipoContacto();

			try{

            // Formulario
            oENTTipoContacto.idTipoContacto = 0;
            oENTTipoContacto.sNombre = "";
            oENTTipoContacto.tiActivo = 1;

				// Transacción
				oENTResponse = oBPTipoContacto.SelectTipoContacto(oENTTipoContacto);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlContacto_Tipo.DataTextField = "sNombre";
            this.ddlContacto_Tipo.DataValueField = "idTipoContacto";
            this.ddlContacto_Tipo.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlContacto_Tipo.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectTipoPieza(){
         ENTTipoPieza oENTTipoPieza = new ENTTipoPieza();
			ENTResponse oENTResponse = new ENTResponse();

			BPTipoPieza oBPTipoPieza = new BPTipoPieza();

			try{

            // Formulario
            oENTTipoPieza.idTipoPieza = 0;
            oENTTipoPieza.sNombre = "";
            oENTTipoPieza.tiActivo = 1;

				// Transacción
				oENTResponse = oBPTipoPieza.SelectTipoPieza(oENTTipoPieza);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlCarga_TipoPieza.DataTextField = "sNombre";
            this.ddlCarga_TipoPieza.DataValueField = "idTipoPieza";
            this.ddlCarga_TipoPieza.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlCarga_TipoPieza.DataBind();

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
				this.chkServicio.DataTextField = "sNombre";
            this.chkServicio.DataValueField = "idServicio";
            this.chkServicio.DataSource = oENTResponse.dsResponse.Tables[1];
            this.chkServicio.DataBind();

            // Tooltip a cada elemento del listado
            for (int i = 0; i < this.chkServicio.Items.Count; i++) {
               this.chkServicio.Items[i].Attributes["title"] = oENTResponse.dsResponse.Tables[1].Select("idServicio = " + this.chkServicio.Items[i].Value )[0]["sDescripcion"].ToString();
            }

            // Guardar Servicios en ViewState
            this.ViewState["tblServicios"] = oENTResponse.dsResponse.Tables[1];

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SetForm_NuevoPickUp(){
         try
         {

            this.litNoPickUp.Text = "<table border='0' cellpadding='0' cellspacing='0'><tr><td>PickUp:&nbsp;&nbsp;</td><td><div style='border-bottom:1px solid; text-align:center; width:120px'>&nbsp;</div></td></tr></table>";
            this.ddlCentroServicio.SelectedIndex = 0;
            this.wucSelectorCliente.Text = "";
            this.wucSelectorCliente.idSucursal = 0;
            this.txtSucursal.Text = "";
            this.txtCodigoPostal.Text = "";
            this.txtDireccion.Text = "";
            this.wucCalendar.SetDate(DateTime.Now);
            this.ddlPickUpHora_Desde.SelectedIndex = 0;
            this.ddlPickUpMinuto_Desde.SelectedIndex = 0;
            this.ddlPickUpHora_Hasta.SelectedIndex = 0;
            this.ddlPickUpMinuto_Hasta.SelectedIndex = 0;
            this.chkLLamar.Checked = true;
            this.txtObservaciones.Text = "";
            this.ddlMuelleHora_Cierre.SelectedIndex = 0;
            this.ddlMuelleMinuto_Cierre.SelectedIndex = 0;

            this.hddCurrentPickUp.Value = "-1"; // Bandera de modo de Edición

            this.gvContactos.DataSource = null;
            this.gvContactos.DataBind();

            this.gvCarga.DataSource = null;
            this.gvCarga.DataBind();

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdatePickUp(Int32 idPickUp){
         ENTPickUp oENTPickUp = new ENTPickUp();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPPickUp oBPPickUp = new BPPickUp();

         DataRow rowServicio = null;
         Int32 iNoPartida = 0;
         String sServicios = "";

			try{

            // Datos de usuario
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTPickUp.idPickUp = idPickUp;
            oENTPickUp.idCompany = oENTSession.idCompany;
            oENTPickUp.idCentroServicio = Int32.Parse(this.ddlCentroServicio.SelectedValue);
            oENTPickUp.idSucursal = this.wucSelectorCliente.idSucursal;
            oENTPickUp.idCiudad = Int32.Parse(this.ddlCiudad.SelectedValue);
            oENTPickUp.sCliente = this.wucSelectorCliente.Text.Trim();
            oENTPickUp.sSucursal = this.txtSucursal.Text.Trim();
            oENTPickUp.sCodigoPostal = this.txtCodigoPostal.Text.Trim();
            oENTPickUp.sDireccion = this.txtDireccion.Text.Trim();
            oENTPickUp.dtPickUp = this.wucCalendar.BeginDate;
            oENTPickUp.tmVentanaInicio = this.ddlPickUpHora_Desde.SelectedValue + ":" + this.ddlPickUpMinuto_Desde.SelectedValue;
            oENTPickUp.tmVentanaFinal = this.ddlPickUpHora_Hasta.SelectedValue + ":" + this.ddlPickUpMinuto_Hasta.SelectedValue;
            oENTPickUp.tiLlamarParaConfirmar = (this.chkLLamar.Checked ? Int16.Parse("1") : Int16.Parse("0"));
            oENTPickUp.sObservaciones = this.txtObservaciones.Text.Trim();
            oENTPickUp.tmCierreMuelle = this.ddlMuelleHora_Cierre.SelectedValue + ":" + this.ddlMuelleMinuto_Cierre.SelectedValue;

            // Contactos del PickUp
            oENTPickUp.tblContactos = utilFunction.ParseGridViewToDataTable(this.gvContactos, true);
            oENTPickUp.tblContactos.Columns.Remove("sTipoContacto");
            oENTPickUp.tblContactos.Columns.Remove("sRequerido");

            // Carga del PickUp
            oENTPickUp.tblCarga = utilFunction.ParseGridViewToDataTable(this.gvCarga, true);

            // Partidas
            oENTPickUp.tblCarga.Columns.Add("tiNoPartida", typeof(Int16));
            foreach(DataRow rowPartida in oENTPickUp.tblCarga.Rows){
               iNoPartida = iNoPartida + 1;
               rowPartida["tiNoPartida"] = iNoPartida;
            }

            // Servicios por cada carga
            oENTPickUp.tblCargaServicio = new DataTable("tblCargaServicio");
            oENTPickUp.tblCargaServicio.Columns.Add("tiNoPartida", typeof(Int16));
            oENTPickUp.tblCargaServicio.Columns.Add("idServicio", typeof(Int32));
            foreach(DataRow rowServicioCarga in oENTPickUp.tblCarga.Rows){

               sServicios = rowServicioCarga["sIDServicios"].ToString();
               foreach(String idServicio in rowServicioCarga["sIDServicios"].ToString().Split(new Char[] { ',' }) ){

                  if(idServicio != ""){
                     rowServicio = oENTPickUp.tblCargaServicio.NewRow();
                     rowServicio["tiNoPartida"] = rowServicioCarga["tiNoPartida"];
                     rowServicio["idServicio"] = idServicio;
                     oENTPickUp.tblCargaServicio.Rows.Add(rowServicio);
                  }

               }

            }

            // Eliminar columnas
            oENTPickUp.tblCarga.Columns.Remove("sIDServicios");
            oENTPickUp.tblCarga.Columns.Remove("sTipoPieza");
            oENTPickUp.tblCarga.Columns.Remove("sUnidadMedidaPeso");
            oENTPickUp.tblCarga.Columns.Remove("sUnidadMedidaVolumen");
            oENTPickUp.tblCarga.Columns.Remove("sServicios");

            // Transacción
            oENTResponse = oBPPickUp.UpdatePickUp(oENTPickUp);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            SelectPickUp_Full(false);
            MovePickUp_ByID(idPickUp.ToString());

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('PickUp actualizado con éxito!', 'Success', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdatePickUp_Estatus(Int32 idPickUp, Int32 idEstatusPickUp){
         ENTPickUp oENTPickUp = new ENTPickUp();
			ENTResponse oENTResponse = new ENTResponse();

			BPPickUp oBPPickUp = new BPPickUp();

			try{

            // Formulario
            oENTPickUp.idPickUp = idPickUp;
            oENTPickUp.idEstatusPickUp = idEstatusPickUp;

				// Transacción
            oENTResponse = oBPPickUp.UpdatePickUp_Estatus(oENTPickUp);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transaccion exitosa
            SelectPickUp_Full(true);

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('PickUp actualizado con éxito!', 'Success', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }


      // Funciones del programador

      private Boolean ValidaNuevaCarga(){
         try
         {

            // Piezas
            if (this.txtCarga_Piezas.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Piezas] es obligatorio', 'Warning', false); focusControl('" + this.txtCarga_Piezas.ClientID + "');", true);
               return false;
            }

            // Peso
            if (this.txtCarga_Peso.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Peso] es obligatorio', 'Warning', false); focusControl('" + this.txtCarga_Peso.ClientID + "');", true);
               return false;
            }

            // Volumen
            if (this.txtCarga_Volumen.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Volumen] es obligatorio', 'Warning', false); focusControl('" + this.txtCarga_Volumen.ClientID + "');", true);
               return false;
            }

            // Resultado
            return true;

         }catch (Exception ex){
            throw (ex);
         }
      }

      private Boolean ValidaNuevoContacto(){
         try
         {

            // sNombre
            if (this.txtContacto_Nombre.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es obligatorio', 'Warning', false); focusControl('" + this.txtContacto_Nombre.ClientID + "');", true);
               return false;
            }

            // sPhoneNumber
            if (this.txtContacto_Telefono.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono] es obligatorio', 'Warning', false); focusControl('" + this.txtContacto_Telefono.ClientID + "');", true);
               return false;
            }

            // Resultado
            return true;

         }catch (Exception ex){
            throw (ex);
         }
      }

      private Boolean ValidaPickUp(){
         try
         {

            // Centro
            if (this.ddlCentroServicio.SelectedIndex == 0){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Centro de Servicio] es obligatorio', 'Warning', false); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
               return false;
            }

            // Compañia
            if (this.wucSelectorCliente.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Compañía] es obligatorio', 'Warning', false); focusControl('" + this.wucSelectorCliente.ClientID_Canvas + "');", true);
               return false;
            }

            // Estado
            if (this.ddlEstado.SelectedValue == "-1"){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado] es obligatorio', 'Warning', false); focusControl('" + this.ddlEstado.ClientID + "');", true);
               return false;
            }

            // Ciudad
            if (this.ddlCiudad.SelectedValue == "-1"){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es obligatorio', 'Warning', false); focusControl('" + this.ddlCiudad.ClientID + "');", true);
               return false;
            }

            // Código Postal
            if (this.txtCodigoPostal.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Código Postal] es obligatorio', 'Warning', false); focusControl('" + this.txtCodigoPostal.ClientID + "');", true);
               return false;
            }

            // Dirección
            if (this.txtDireccion.Text.Trim() == ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dirección] es obligatorio', 'Warning', false); focusControl('" + this.txtDireccion.ClientID + "');", true);
               return false;
            }

            // Fecha
            if( DateTime.Parse(this.wucCalendar.EndDate) < DateTime.Now ){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No es posible crear un PickUp en el pasado', 'Warning', false); focusControl('" + this.wucCalendar.ClientID_Canvas + "');", true);
               return false;
            }

            // Por lo menos un contacto
            if (this.gvContactos.Rows.Count == 0){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Es necesario incluír por lo menos un [Contacto]', 'Warning', false); focusControl('" + this.ddlContacto_Tipo.ClientID + "');", true);
               return false;
            }

            // Por lo menos una carga
            if (this.gvCarga.Rows.Count == 0){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Es necesario incluír por lo menos una [Carga]', 'Warning', false); focusControl('" + this.txtCarga_Piezas.ClientID + "');", true);
               return false;
            }

            // Resultado
            return true;

         }catch (Exception ex){
            throw (ex);
         }
      }
      

      // Eventos de la página

      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) {

            // Recargar Tooltip de Servicios debido a que se pierde en el Postback
            RefreshTooltipServices();
            return;
         }

         // Lógica de la página
         try{

            // Estado inicial de los controles
            this.wucToolbar.AddAttributes_Search("onclick", "clickAccordionPane();");
            this.wucToolbar.SetTooltip("PickUp");

            this.gvPickUp.DataSource = null;
            this.gvPickUp.DataBind();

            this.gvContactos.DataSource = null;
            this.gvContactos.DataBind();

            this.gvCarga.DataSource = null;
            this.gvCarga.DataBind();


            // Llenado de controles
            FillDateAndTimeCombos();
            SelectCentroServicio();
            SelectPais();
            SelectEstado();
            SelectCiudad();
            SelectTipoContacto();
            SelectTipoPieza();
            SelectUnidadMedida_Peso();
            SelectUnidadMedida_Volumen();
            SelectServicios();
            SelectPickUp_Full(true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try
         {

            // Validación
            if (this.txtPickUp.Text.Trim() != ""){

               if(utilFunction.IsNumber(this.txtPickUp.Text, Function.NumberTypes.Int32Type) == false){
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo PickUp debe de ser numérico', 'Warning', false); focusControl('" + this.txtPickUp.ClientID + "');", true);
                  return;
               }
            }

            //  Buscar PickUp
            SelectPickUp();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void btnCarga_Nueva_Click(object sender, EventArgs e){
         try
         {

            // Validación
            if (ValidaNuevaCarga()){

               // Agregar la carga
               AgregaNuevaCarga();
            }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void btnContacto_Nuevo_Click(object sender, EventArgs e){
         try
         {

            // Validación
            if (ValidaNuevoContacto()){

               // Agregar el contacto
               AgregaNuevoContacto();
            }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de estados y ciudades
            SelectEstado();
            SelectCiudad();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e){
         try
         {

            // Consulta de ciudades
            SelectCiudad();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void gvCarga_RowCommand(object sender, GridViewCommandEventArgs e){
         String strCommand = "";
			Int32 intRow = 0;
			
			try{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Acción
				switch (strCommand){
               case "Eliminar":
                  DeleteCarga(intRow);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
			}
		}

      protected void gvCarga_RowDataBound(object sender, GridViewRowEventArgs e){
         ImageButton imgEliminar = null;
         String sImagesAttributes = "";

			try{

            // Validación de que sea fila
            if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            // Obtener imagenes
            imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");

            // Atributos Over
            sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
            e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            // Atributos Out
            sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
            e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
				
			}catch (Exception ex){
				throw (ex);
			}
		}

      protected void gvCarga_Sorting(object sender, CommandEventArgs e){
         DataTable tblCarga = null;
         DataView viewCarga = null;
			
         try{

            // Obtener DataTable y DataView del GridView
            tblCarga = utilFunction.ParseGridViewToDataTable(this.gvCarga, true);
            viewCarga = new DataView(tblCarga);

            // Determinar ordenamiento
            this.hddSort.Value = (this.hddSort.Value == e.CommandName ? e.CommandName + " DESC" : e.CommandName);

            // Ordenar vista
            viewCarga.Sort = this.hddSort.Value;

            // Vaciar datos
            this.gvCarga.DataSource = viewCarga;
            this.gvCarga.DataBind();
				
         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
		}

      protected void gvContactos_RowCommand(object sender, GridViewCommandEventArgs e){
         String strCommand = "";
			Int32 intRow = 0;
			
			try{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Acción
				switch (strCommand){
               case "Eliminar":
                  DeleteContacto(intRow);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
			}
		}

      protected void gvContactos_RowDataBound(object sender, GridViewRowEventArgs e){
         ImageButton imgEliminar = null;
         String sImagesAttributes = "";

			try{

            // Validación de que sea fila
            if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            // Obtener imagenes
            imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");

            // Atributos Over
            sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
            e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            // Atributos Out
            sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
            e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
				
			}catch (Exception ex){
				throw (ex);
			}
		}

      protected void gvContactos_Sorting(object sender, CommandEventArgs e){
         DataTable tblContactos = null;
         DataView viewContactos = null;
			
         try{

            // Obtener DataTable y DataView del GridView
            tblContactos = utilFunction.ParseGridViewToDataTable(this.gvContactos, true);
            viewContactos = new DataView(tblContactos);

            // Determinar ordenamiento
            this.hddSort.Value = (this.hddSort.Value == e.CommandName ? e.CommandName + " DESC" : e.CommandName);

            // Ordenar vista
            viewContactos.Sort = this.hddSort.Value;

            // Vaciar datos
            this.gvContactos.DataSource = viewContactos;
            this.gvContactos.DataBind();
				
         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
		}

      protected void gvPickUp_RowDataBound(object sender, GridViewRowEventArgs e){
         ImageButton imgSelectItem = null;
         String sImagesAttributes = "";

         try{

            // Validación de que sea fila
			   if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            // Obtener imágen
				imgSelectItem = (ImageButton)e.Row.FindControl("imgSelectItem");

            // Atributos Over
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem.png';";
            e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            // Atributos Out
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem_Null.png';";
            e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row'; " + sImagesAttributes);

         }catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvPickUp_RowCommand(object sender, GridViewCommandEventArgs e){
         String strCommand = "";
			Int32 intRow = 0;
			
			try{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

            // Esconder filtro
            this.acrdFiltro.SelectedIndex = -1;

            // Seleccionar PickUp
            MovePickUp_ByID(this.gvPickUp.DataKeys[intRow]["idPickUp"].ToString());
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtPickUp.ClientID + "');", true);
			}
		}

		protected void gvPickUp_Sorting(object sender, GridViewSortEventArgs e){
         DataTable tblPickUp = null;
         DataView viewPickUp = null;
			
         try{

            // Obtener DataTable y DataView del GridView
            tblPickUp = utilFunction.ParseGridViewToDataTable(this.gvPickUp, true);
            viewPickUp = new DataView(tblPickUp);

            // Determinar ordenamiento
            this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

            // Ordenar vista
            viewPickUp.Sort = this.hddSort.Value;

            // Vaciar datos
            this.gvPickUp.DataSource = viewPickUp;
            this.gvPickUp.DataBind();
				
         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtPickUp.ClientID + "');", true);
         }
		}


      // Eventos de los Web User Control's

      protected void wucCotizador_ClickCotizarImage(){
         try
         {

            // Habilitar Control
            this.wucCotizador.Enable = true;

            // Incializar PickUp (si es cero se inhabilita automáticamente)
            this.wucCotizador.idPickUp = (this.hddCurrentPickUp.Value == "-1" ? 0 : Int16.Parse(this.hddCurrentPickUp.Value));

            // Moverse al PickUp anterior
            this.wucCotizador.Cotizar();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucSelectorCliente_ItemSelected(){
         try
         {

            // Buscar Sucursal
            SelectCliente(this.wucSelectorCliente.idSucursal);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }
      
      protected void wucToolbar_ClickBackImage(){
         try
         {

            // Moverse al PickUp anterior
            MovePickUp(false);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucToolbar_ClickDeleteImage(){
         try
         {

            // Validación
            if(this.hddCurrentPickUp.Value == "-1"){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No ha seleccionado ningún PickUp para eliminar', 'Warning', false); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
               return;
            }

            // Actualizar el estatus (Cancelado)
            UpdatePickUp_Estatus(Int32.Parse(this.hddCurrentPickUp.Value),  5);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucToolbar_ClickNewImage(){
         try
         {

            // Limpiar formulario
            SetForm_NuevoPickUp();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCentroServicio.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucToolbar_ClickNextImage(){
         try
         {

            // Moverse al siguiente PickUp
            MovePickUp(true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucToolbar_ClickReleaseImage(){
         try
         {

            // Validación
            if(this.hddCurrentPickUp.Value == "-1"){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No ha seleccionado ningún PickUp para liberar', 'Warning', false); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
               return;
            }

            // Actualizar el estatus (Liberado)
            UpdatePickUp_Estatus(Int32.Parse(this.hddCurrentPickUp.Value),  2);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

      protected void wucToolbar_ClickSaveImage(){
         try
         {

            // Validación de formulario
            if (ValidaPickUp() == false){ return; }

            // Transacción
            switch (this.hddCurrentPickUp.Value){
               case "-1":  // Nuevo PickUp
                  InsertPickUp();
                  break;

               default: // Editar PickUp
                  UpdatePickUp(Int32.Parse(this.hddCurrentPickUp.Value));
                  break;
            }

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCentroServicio.ClientID + "');", true);
         }
      }

   }
}