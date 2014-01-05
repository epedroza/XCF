using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.Web.Application.WebApp.Private.Catalog
{
    public partial class catTiposCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Se inicia la pantalla con un registro nuevo y cargando todos los registros existentes en el grid
                hddTipoAccion.Value = "INSERT";
                LimpiaCampos();
                FillGrid();
            }
        }

        #region Grid
        protected void gvApps_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvApps_SelectedIndexChanging(object sender, EventArgs e)
        {
        }

        protected void gvApps_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Convierte el indice del renglón la propiedad CommandArgument a un int
            int index = Convert.ToInt32(e.CommandArgument);

            // Va al renglón que contiene el botón que presionado
            GridViewRow row = gvApps.Rows[index];

            gvApps.SelectedIndex = index;

            if (e.CommandName == "EDITA")
            {
                hddTipoAccion.Value = "UPDATE";
                hddIdTipoCamion.Value = gvApps.SelectedDataKey["IdTipoCamion"].ToString();
                txtIdTipoCamion.Text = gvApps.SelectedDataKey["IdTipoCamion"].ToString();
                txtTipoCamion.Text = gvApps.SelectedDataKey["TipoCamion"].ToString();
            }

            if (e.CommandName == "DELETE")
            {
                hddTipoAccion.Value = "DELETE";
                Actualizar(hddTipoAccion.Value);
            }
        }

        #endregion

        #region Rutinas de la pagina

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos() == true)
                {
                    Actualizar(hddTipoAccion.Value);
                    LimpiaCampos();
                    FillGrid();
                    hddTipoAccion.Value = "INSERT";
                    hddIdTipoCamion.Value = "0";
                }
            }
            catch
            {

            }
            finally
            { }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            hddTipoAccion.Value = "INSERT";
            LimpiaCampos();
            FillGrid();
        }

        #endregion

        #region Rutinas del programador

        void FillGrid()
        {
            // Declaracion de variables
            ENTTipoCamion ent = new ENTTipoCamion();
            catTiposCamionesBSS bss = new catTiposCamionesBSS();

            // Asignar Valores
            ent.idTipoCamion = (txtIdTipoCamion.Text != "" ? Int32.Parse(txtIdTipoCamion.Text) : 0);
            ent.sNombre = txtTipoCamion.Text;

            // Transaccion
            SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatTiposCamiones(ent);

            gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
            gvApps.DataBind();
        }

        bool ValidaCampos()
        {
            bool Valido = true;

            if (txtTipoCamion.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Descripción] es obligatorio', 'Warning', true); focusControl('" + this.txtTipoCamion.ClientID + "');", true);
                return false;
            }

            return Valido;

        }

        void Actualizar(string TipoAccion)
        {
            // Declaracion de variables
            ENTTipoCamion ent = new ENTTipoCamion();
            catTiposCamionesBSS bss = new catTiposCamionesBSS();
            SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Asignar Valores
                ent.idTipoCamion = Int32.Parse(hddIdTipoCamion.Value);
                ent.sNombre = txtTipoCamion.Text;

                // Transaccion
                switch (TipoAccion)
                {
                    case "INSERT":
                        oENTResponse = bss.insertcatTiposCamiones(ent);
                        break;
                    case "UPDATE":
                        oENTResponse = bss.updatecatTiposCamiones(ent);
                        break;
                    case "DELETE":
                        oENTResponse = bss.deletecatTiposCamiones(ent);
                        break;
                }
            }
            catch
            { }
            finally
            { }

        }

        void Buscar()
        {
            FillGrid();
        }

        void LimpiaCampos()
        {
            txtIdTipoCamion.Text = "";
            txtTipoCamion.Text = "";
            hddIdTipoCamion.Value = "0";
        }

        #endregion
    }
}