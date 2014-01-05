using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catTransportistasBSS : BPBase
    {
        ///<remarks>
        ///   <name>catTransportistas_BSS.searchcatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTransportistas del sistema</summary>
        public ENTResponse searchcatTransportistas(ENTTransportista entcatTransportistas)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catTransportistasDATA datacatTransportistas = new SafeTransfer.DATA.catTransportistasDATA();
                oENTResponse = datacatTransportistas.searchcatTransportistas(entcatTransportistas);
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
        ///   <name>catTransportistas_DATA.insertcatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTransportistas del sistema</summary>
        public ENTResponse insertcatTransportistas(ENTTransportista entcatTransportistas)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catTransportistasDATA datacatTransportistas = new SafeTransfer.DATA.catTransportistasDATA();
                oENTResponse = datacatTransportistas.insertcatTransportistas(entcatTransportistas);
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
        ///   <name>catTransportistas_DATA.updatecatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTransportistas del sistema</summary>
        public ENTResponse updatecatTransportistas(ENTTransportista entcatTransportistas)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catTransportistasDATA datacatTransportistas = new SafeTransfer.DATA.catTransportistasDATA();
                return datacatTransportistas.updatecatTransportistas(entcatTransportistas);
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
        ///   <name>catTransportistas_DATA.deletecatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTransportistas del sistema</summary>
        public ENTResponse deletecatTransportistas(ENTTransportista entcatTransportistas)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catTransportistasDATA datacatTransportistas = new SafeTransfer.DATA.catTransportistasDATA();
                return datacatTransportistas.deletecatTransportistas(entcatTransportistas);
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
