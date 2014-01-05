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
   public partial class rptTarificador : System.Web.UI.Page
   {


      // Rutinas del programador

      void FillControls(){
         DataTable tblRuta = null;
         DataRow rowRuta = null;

         try{

            // ddlOrigen
            this.ddlOrigen.Items.Insert(0, new ListItem("Tijuana", "4"));
            this.ddlOrigen.Items.Insert(0, new ListItem("Piedras Negras", "3"));
            this.ddlOrigen.Items.Insert(0, new ListItem("Nuevo Laredo", "2"));
            this.ddlOrigen.Items.Insert(0, new ListItem("Matamoros", "1"));

            // ddlDestino
            this.ddlDestino.Items.Insert(0, new ListItem("Toluca", "4"));
            this.ddlDestino.Items.Insert(0, new ListItem("Monterrey", "3"));
            this.ddlDestino.Items.Insert(0, new ListItem("Edo. Mexico", "2"));
            this.ddlDestino.Items.Insert(0, new ListItem("Chiapas", "1"));

            // ddlMedidaPeso
            this.ddlMedidaPeso.Items.Insert(0, new ListItem("Kilogramos", "2"));
            this.ddlMedidaPeso.Items.Insert(0, new ListItem("Libras", "1"));

            // ddlMedidaVolumen
            this.ddlMedidaVolumen.Items.Insert(0, new ListItem("Pulgadas", "3"));
            this.ddlMedidaVolumen.Items.Insert(0, new ListItem("Pies", "2"));
            this.ddlMedidaVolumen.Items.Insert(0, new ListItem("Metros", "1"));

            // gvRuta
            tblRuta = new DataTable("tblRuta");
            tblRuta.Columns.Add("sDescripcion", typeof(String));
            tblRuta.Columns.Add("sMexico", typeof(String));
            tblRuta.Columns.Add("sUSA", typeof(String));

            rowRuta = tblRuta.NewRow();
            rowRuta["sDescripcion"] = "Paso Natural";
            rowRuta["sMexico"] = "660.00";
            rowRuta["sUSA"] = "1,455.04";
            tblRuta.Rows.Add(rowRuta);

            rowRuta = tblRuta.NewRow();
            rowRuta["sDescripcion"] = "Peso Volumétrico [Factor: 300]";
            rowRuta["sMexico"] = "1,629.00";
            rowRuta["sUSA"] = "3,591.29";
            tblRuta.Rows.Add(rowRuta);

            rowRuta = tblRuta.NewRow();
            rowRuta["sDescripcion"] = "Tarifa Regular Tabulador";
            rowRuta["sMexico"] = "8,907.65";
            rowRuta["sUSA"] = "664.75";
            tblRuta.Rows.Add(rowRuta);

            rowRuta = tblRuta.NewRow();
            rowRuta["sDescripcion"] = "Tarifa Final";
            rowRuta["sMexico"] = "8,907.65";
            rowRuta["sUSA"] = "664.75";
            tblRuta.Rows.Add(rowRuta);

            this.gvRuta.DataSource = tblRuta;
            this.gvRuta.DataBind();


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
            FillControls();
            
            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlOrigen.ClientID + "');", true);

         }catch (Exception){
            // Do Nothing
         }
      }

   }
}