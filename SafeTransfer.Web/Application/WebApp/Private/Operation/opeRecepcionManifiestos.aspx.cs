using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTransfer.Entity.Object;
using SafeTransfer.BusinessProcess.Object;
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfere.Web.Application.WebApp.Private.Operation
{
    public partial class opeRecepcionManifiestos : System.Web.UI.Page
    {
        #region Rutinas de la Pagina
            protected void cmdBuscar_Click(object sender, EventArgs e)
            {
                FillGrid();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region Rutinas del Programador
            void FillGrid()
            {
          
            }

            void Fillcbo()
            {

            }

            private void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    SelectCentroServicio();

                    DescargarGrid.DataSource = null;
                    DescargarGrid.DataBind();

                    CargarGrid.DataSource = null;
                    CargarGrid.DataBind();
                }
            }

            private void SelectCentroServicio()
            {
                ENTCentroServicio oENTCentroServicio = new ENTCentroServicio();
                ENTResponse oENTResponse = new ENTResponse();
                ENTSession oENTSession;
                BPCentroServicio oBPCentroServicio = new BPCentroServicio();

                try
                {
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
                    CentroServicioList.DataTextField = "sNombre";
                    CentroServicioList.DataValueField = "idCentroServicio";
                    CentroServicioList.DataSource = oENTResponse.dsResponse.Tables[1];
                    CentroServicioList.DataBind();

                    // Agregar Item de selección
                    CentroServicioList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        #endregion
    }
}