using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.Web.Include.WebUserControls
{
    public partial class wucProgramarPickUp : System.Web.UI.UserControl
    {
        #region "Eventos"
            protected void CancelarButton_Click(object sender, EventArgs e)
            {
                pnlAction.Visible = false;
            }

            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                GuardarProgramacion();
            }

            protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
            {
                pnlAction.Visible = false;
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                
            }
        #endregion

        #region "Métodos"
            private void GuardarProgramacion()
            {
                ENTResponse ResponseEntity = new ENTResponse();
                ENTPickUp PickUpEntity = new ENTPickUp();
                BPPickUp PickUpProcess = new BPPickUp();

                PickUpEntity.idPickUp = int.Parse(PickUpBox.Text);
                PickUpEntity.idCompany = 2;
                PickUpEntity.idEstatusPickUp = 3;
                PickUpEntity.dtPickUp = wucCalendar.BeginDate;
                PickUpEntity.sDireccion = LugarBox.Text.Trim();

                if (TransporteRadio.Items[1].Selected)
                {
                    PickUpEntity.EsTransportePropio = 0;
                    PickUpEntity.Proveedor = ProveedorBox.Text.Trim();
                }
                else
                {
                    PickUpEntity.EsTransportePropio = 1;
                    PickUpEntity.Proveedor = "";
                }

                ResponseEntity = PickUpProcess.SavePickUpProgramacion(PickUpEntity);

                if (ResponseEntity.sMessage == "")
                {
                    LimpiarFormulario();
                    pnlAction.Visible = false;

                    this.Page.GetType().InvokeMember("FillGrid", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ResponseEntity.sMessage + "', 'Warning', true);", true);
            }

            private void LimpiarFormulario()
            {
                PickUpBox.Text = "";
                ClienteBox.Text = "";
                //wucCalendar.

            }

            public void PageLoad(Int16 PickUpId, Int16 idEstatusPickUp)
            {
                pnlAction.Visible = true;
                PickUpBox.Text = PickUpId.ToString();

                SelectPickUp(PickUpId);

                ValidateStatus(idEstatusPickUp);
            }

            private void SelectPickUp(int PickUpId)
            {
                ENTResponse ResponseEntity = new ENTResponse();
                ENTPickUp PickUpEntity = new ENTPickUp();
                BPPickUp PickUpProcess = new BPPickUp();

                PickUpEntity.idPickUp = PickUpId;
                PickUpEntity.idCompany = 2;

                ResponseEntity = PickUpProcess.SelectPickUpProgramacion(PickUpEntity);

                if (ResponseEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    wucCalendar.SetDate((DateTime)ResponseEntity.dsResponse.Tables[0].Rows[0]["dtPickUp"]);
                    ClienteBox.Text = ResponseEntity.dsResponse.Tables[0].Rows[0]["sCliente"].ToString();
                    LugarBox.Text = ResponseEntity.dsResponse.Tables[0].Rows[0]["sDireccion"].ToString();

                    if (!string.IsNullOrEmpty(ResponseEntity.dsResponse.Tables[0].Rows[0]["EsTransportePropio"].ToString()))
                    {
                        if (Int16.Parse(ResponseEntity.dsResponse.Tables[0].Rows[0]["EsTransportePropio"].ToString()) == 1)
                            ProveedorBox.Text = ResponseEntity.dsResponse.Tables[0].Rows[0]["Proveedor"].ToString();
                        else
                            ProveedorBox.Text = "";
                    }
                }
            }

            private void ValidateStatus(int idEstatusPickUp)
            {
                if (idEstatusPickUp == 2)
                {
                    GuardarButton.Enabled = true;
                    GuardarButton.CssClass = "Button_General";

                    MessageLabel.Text = "";
                }
                else
                {
                    GuardarButton.Enabled = false;
                    GuardarButton.CssClass = "Button_General_Des";

                    MessageLabel.Text = "No se puede programar un PickUp que no esté liberado para programar";
                }
            }
        #endregion
    }
}