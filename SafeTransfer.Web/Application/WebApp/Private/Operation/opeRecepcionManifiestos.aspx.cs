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
            protected void SearchButton_Click(object sender, EventArgs e)
            {
                SelectPros(int.Parse(CentroServicioList.SelectedValue), ManifiestoBox.Text.Trim());
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region Rutinas del Programador
            private void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    SelectCentroServicio();

                    DownloadGrid.DataSource = null;
                    DownloadGrid.DataBind();

                    UploadGrid.DataSource = null;
                    UploadGrid.DataBind();
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

            private void SelectPros(int CentroServicioId, string ManifiestoId)
            {
                if (ValidateInfo(CentroServicioId, ManifiestoId))
                {
                    SelectProsDownload(CentroServicioId, ManifiestoId);
                    SelectProsUpload(CentroServicioId, ManifiestoId);
                }
            }

            private void SelectProsDownload(int CentroServicioId, string ManifiestoId)
            {
                ENTResponse ResponseEntity = new ENTResponse();
                SafeTransfer.Entity.tblManifiestosHdr_Ent ManifiestoEntity = new SafeTransfer.Entity.tblManifiestosHdr_Ent();
                tblManifiestosHdrBSS ManifiestoProcess = new tblManifiestosHdrBSS();

                ManifiestoEntity.IdManifiesto = int.Parse(ManifiestoId);
                ManifiestoEntity.ClaveDestino = CentroServicioId;

                ResponseEntity = ManifiestoProcess.SelectProsDownload(ManifiestoEntity);

                if (ResponseEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    DownloadGrid.DataSource = ResponseEntity.dsResponse.Tables[0].DefaultView;
                    DownloadGrid.DataBind();
                }
            }

            private void SelectProsUpload(int CentroServicioId, string ManifiestoId)
            {
                ENTResponse ResponseEntity = new ENTResponse();
                SafeTransfer.Entity.tblManifiestosHdr_Ent ManifiestoEntity = new SafeTransfer.Entity.tblManifiestosHdr_Ent();
                tblManifiestosHdrBSS ManifiestoProcess = new tblManifiestosHdrBSS();

                ManifiestoEntity.IdManifiesto = int.Parse(ManifiestoId);
                ManifiestoEntity.ClaveDestino = CentroServicioId;

                ResponseEntity = ManifiestoProcess.SelectProsUpload(ManifiestoEntity);

                if (ResponseEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    UploadGrid.DataSource = ResponseEntity.dsResponse.Tables[0].DefaultView;
                    UploadGrid.DataBind();
                }
            }

            private bool ValidateInfo(int CentroServicioId, string ManifiestoId)
            {
                int Result = 0;

                if (CentroServicioId == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Centro] es obligatorio', 'Warning', true);", true);

                    return false;
                }

                if (!int.TryParse(ManifiestoId, out Result))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Manifiesto] debe ser numérico', 'Warning', true);", true);

                    return false;
                }

                return true;
            }
        #endregion
    }
}