using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SafeTransfer.BusinessProcess.Object;
using SafeTransfer.Entity.Object;
using SafeTransfer.Include.Components.Utilities;

namespace SafeTransfer.Web.Application.WebApp.Private.Catalog
{
    public partial class catCentrosDeServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Se inicia la pantalla con un registro nuevo y cargando todos los registros existentes en el grid
                hddTipoAccion.Value = "INSERT";
                LimpiaCampos();
                Fillcbo();
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
                hddIdCentroDeServicio.Value = gvApps.SelectedDataKey["idCentroDeServicio"].ToString();
                txtNombre.Text = gvApps.SelectedDataKey["sNombre"].ToString();
                txtRFC.Text = gvApps.SelectedDataKey["sRFC"].ToString();
                txtTerminal.Text = gvApps.SelectedDataKey["iTerminal"].ToString();
                txtCD.Text = gvApps.SelectedDataKey["sCD"].ToString();
                txtDireccion.Text = gvApps.SelectedDataKey["sDireccion"].ToString();
                cboCiudad.SelectedValue = gvApps.SelectedDataKey["idCiudad"].ToString();
                txtProExterno.Text = gvApps.SelectedDataKey["sProExterno"].ToString();
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
                    hddIdCentroDeServicio.Value = "0";
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
            ENTCentroServicio ent = new ENTCentroServicio();
            BPCentroServicio bss = new BPCentroServicio();

            // Asignar Valores
            ent.idCompany = 1;
            ent.idCentroServicio = (txtIdCentroDeServicio.Text != "" ? Int32.Parse(txtIdCentroDeServicio.Text) : 0);
            ent.sNombre = txtNombre.Text;

            // Transaccion
            SafeTransfer.Entity.Object.ENTResponse oENTResponse = bss.searchcatCentrosDeServicio(ent);

            gvApps.DataSource = oENTResponse.dsResponse.Tables[1].DefaultView;
            gvApps.DataBind();
        }

        void Fillcbo()
        {
            Utilities.FillCombo(ref cboCiudad, "idCiudad", "Ciudad", "Ciudades");
        }

        bool ValidaCampos()
        {
            bool Valido = true;
            int Terminal = 0;

            if (txtNombre.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es obligatorio', 'Warning', true); focusControl('" + this.txtNombre.ClientID + "');", true);
                return false;
            }

            if (txtRFC.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [RFC] es obligatorio', 'Warning', true); focusControl('" + this.txtRFC.ClientID + "');", true);
                return false;
            }

            if (txtTerminal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Terminal] es obligatorio', 'Warning', true); focusControl('" + this.txtTerminal.ClientID + "');", true);
                return false;
            }

            if (!int.TryParse(txtTerminal.Text.Trim(), out Terminal))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Terminal] debe ser númerico', 'Warning', true); focusControl('" + this.txtTerminal.ClientID + "');", true);
                return false;
            }

            if (txtCD.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [CD] es obligatorio', 'Warning', true); focusControl('" + this.txtCD.ClientID + "');", true);
                return false;
            }

            if (txtDireccion.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dirección] es obligatorio', 'Warning', true); focusControl('" + this.txtDireccion.ClientID + "');", true);
                return false;
            }

            if (cboCiudad.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es obligatorio', 'Warning', true); focusControl('" + this.cboCiudad.ClientID + "');", true);
                return false;
            }

            if (txtProExterno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Pro Externo] es obligatorio', 'Warning', true); focusControl('" + this.txtProExterno.ClientID + "');", true);
                return false;
            }


            return Valido;

        }

        void Actualizar(string TipoAccion)
        {
            // Declaracion de variables
            ENTCentroServicio ent = new ENTCentroServicio();
            BPCentroServicio bss = new BPCentroServicio();
            SafeTransfer.Entity.Object.ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Asignar Valores
                ent.idCompany = 2;
                ent.idCentroServicio = Int32.Parse(hddIdCentroDeServicio.Value);
                ent.sNombre = txtNombre.Text;
                ent.RFC = txtRFC.Text;
                ent.Terminal = Int32.Parse(txtTerminal.Text);
                ent.CD = txtCD.Text;
                ent.Direccion = txtDireccion.Text;
                ent.IdCiudad = Int32.Parse(cboCiudad.SelectedValue);
                ent.ProExterno = txtProExterno.Text.Trim();

                // Transaccion
                switch (TipoAccion)
                {
                    case "INSERT":
                        oENTResponse = bss.insertcatCentrosDeServicio(ent);
                        break;
                    case "UPDATE":
                        oENTResponse = bss.updatecatCentrosDeServicio(ent);
                        break;
                    case "DELETE":
                        oENTResponse = bss.deletecatCentrosDeServicio(ent);
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
            txtIdCentroDeServicio.Text = "";
            txtNombre.Text = "";
            txtRFC.Text = "";
            txtTerminal.Text = "";
            txtCD.Text = "";
            txtDireccion.Text = "";
            cboCiudad.SelectedValue = "0";
            txtProExterno.Text = "";
            hddIdCentroDeServicio.Value = "0";
        }

        #endregion
    }
}