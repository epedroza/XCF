using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catEstatusManifiestosBSS : BPBase
    {
        ///<remarks>
        ///   <name>catEstatusManifiestos_BSS.searchcatEstatusManifiestos</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstatusManifiestos del sistema</summary>
        public ENTResponse searchcatEstatusManifiestoscbo(catEstatusManifiestos_Ent entcatEstatusManifiestos)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catEstatusManifiestosDATA datacatEstatusManifiestos = new SafeTransfer.DATA.catEstatusManifiestosDATA();
                oENTResponse = datacatEstatusManifiestos.searchcatEstatusManifiestoscbo(entcatEstatusManifiestos);
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