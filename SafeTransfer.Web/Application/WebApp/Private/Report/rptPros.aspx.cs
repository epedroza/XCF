using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using System.Data;

namespace SafeTransfer.Web.Application.WebApp.Private.Report
{
   public partial class rptPros : System.Web.UI.Page
   {


      // Funciones del programador

      void ClearForm(){
         try{

            // Textboc
            this.txtPro.Text = "";
            this.txtCliente.Text = "";
            this.txtCliente_Display.Text = "";

            // Grid
            this.gvPro.DataSource = null;
            this.gvPro.DataBind();

         }catch (Exception ex){
            throw (ex);
         }
      }

      void SelectPro(){
         DataTable tblPro = null;
         DataRow rowPro = null;

         try{

            // Definición del DataTable
            tblPro = new DataTable("tblPro");
            tblPro.Columns.Add("sPro", typeof(String));
            tblPro.Columns.Add("dDiscount", typeof(String));
            tblPro.Columns.Add("sDescripcion", typeof(String));

            // Llenado de DataTable
            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40221004";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 1";
            tblPro.Rows.Add(rowPro);

            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40226938";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 2";
            tblPro.Rows.Add(rowPro);

            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40230138";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 3";
            tblPro.Rows.Add(rowPro);

            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40246464";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 4";
            tblPro.Rows.Add(rowPro);

            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40247967";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 5";
            tblPro.Rows.Add(rowPro);

            rowPro = tblPro.NewRow();
            rowPro["sPro"] = "40247959";
            rowPro["dDiscount"] = "0.0";
            rowPro["sDescripcion"] = "Descripción general para el PRO 6";
            tblPro.Rows.Add(rowPro);

            // Grid
            this.gvPro.DataSource = tblPro;
            this.gvPro.DataBind();


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

            // Atributos
            this.txtCliente.Attributes.Add("onblur", "FillClient('" + this.txtCliente.ClientID + "', '" + this.txtCliente_Display.ClientID + "')");
            this.txtCliente_Display.Attributes.Add("onfocus", "FocusPro('" + this.txtPro.ClientID + "')");

            // Estado inicial de la pantalla
            ClearForm();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtPro.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            SelectPro();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtPro.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }

      protected void btnCancelar_Click(object sender, EventArgs e){
         try{

            ClearForm();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtPro.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }

      protected void btnDelete_Click(object sender, EventArgs e){
         try{

            ClearForm();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('PRO Master eliminado con éxito!', 'Success', true); focusControl('" + this.txtPro.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }   

      protected void btnSave_Click(object sender, EventArgs e){
         try{

            ClearForm();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Consolidación exitosa!', 'Success', true); focusControl('" + this.txtPro.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }

   }
}