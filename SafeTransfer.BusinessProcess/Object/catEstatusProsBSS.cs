using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catEstatusProsBSS : BPBase
    {
        ///<remarks>
        ///   <name>catEstatusPros_BSS.searchcatEstatusPros</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstatusPros del sistema</summary>
        public ENTResponse searchcatEstatusProscbo(catEstatusPros_Ent entcatEstatusPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catEstatusProsDATA datacatEstatusPros = new SafeTransfer.DATA.catEstatusProsDATA();
                oENTResponse = datacatEstatusPros.searchcatEstatusProscbo(entcatEstatusPros);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }

    }
}