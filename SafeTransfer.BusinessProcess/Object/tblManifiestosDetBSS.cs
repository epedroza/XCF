using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class tblManifiestosDetBSS : BPBase
    {
        ///<remarks>
        ///   <name>tblManifiestosDet_BSS.searchtblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosDet del sistema</summary>
        public ENTResponse searchtblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosDetDATA datatblManifiestosDet = new tblManifiestosDetDATA();
                oENTResponse = datatblManifiestosDet.searchtblManifiestosDet(enttblManifiestosDet);
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
        ///<remarks>
        ///   <name>tblManifiestosDet_DATA.inserttblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblManifiestosDet del sistema</summary>
        public ENTResponse inserttblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosDetDATA datatblManifiestosDet = new tblManifiestosDetDATA();
                oENTResponse = datatblManifiestosDet.inserttblManifiestosDet(enttblManifiestosDet);
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
        ///<remarks>
        ///   <name>tblManifiestosDet_DATA.updatetblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblManifiestosDet del sistema</summary>
        public ENTResponse updatetblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosDetDATA datatblManifiestosDet = new tblManifiestosDetDATA();
                return datatblManifiestosDet.updatetblManifiestosDet(enttblManifiestosDet);
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
        ///<remarks>
        ///   <name>tblManifiestosDet_DATA.deletetblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblManifiestosDet del sistema</summary>
        public ENTResponse deletetblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosDetDATA datatblManifiestosDet = new tblManifiestosDetDATA();
                return datatblManifiestosDet.deletetblManifiestosDet(enttblManifiestosDet);
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