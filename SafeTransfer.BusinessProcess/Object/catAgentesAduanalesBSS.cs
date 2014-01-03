using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catAgentesAduanalesBSS : BPBase
    {
        ///<remarks>
        ///   <name>catAgentesAduanales_BSS.searchcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catAgentesAduanales del sistema</summary>
        public ENTResponse searchcatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catAgentesAduanalesDATA datacatAgentesAduanales = new SafeTransfer.DATA.catAgentesAduanalesDATA();
                oENTResponse = datacatAgentesAduanales.searchcatAgentesAduanales(entcatAgentesAduanales);
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
        ///   <name>catAgentesAduanales_BSS.searchcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catAgentesAduanales del sistema</summary>
        public ENTResponse searchcatAgentesAduanalescbo(ENTAgenteAduanal entcatAgentesAduanales)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catAgentesAduanalesDATA datacatAgentesAduanales = new SafeTransfer.DATA.catAgentesAduanalesDATA();
                oENTResponse = datacatAgentesAduanales.searchcatAgentesAduanalescbo(entcatAgentesAduanales);
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
        ///   <name>catAgentesAduanales_DATA.insertcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catAgentesAduanales del sistema</summary>
        public ENTResponse insertcatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catAgentesAduanalesDATA datacatAgentesAduanales = new SafeTransfer.DATA.catAgentesAduanalesDATA();
                oENTResponse = datacatAgentesAduanales.insertcatAgentesAduanales(entcatAgentesAduanales);
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
        ///   <name>catAgentesAduanales_DATA.updatecatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catAgentesAduanales del sistema</summary>
        public ENTResponse updatecatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catAgentesAduanalesDATA datacatAgentesAduanales = new SafeTransfer.DATA.catAgentesAduanalesDATA();
                return datacatAgentesAduanales.updatecatAgentesAduanales(entcatAgentesAduanales);
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
        ///   <name>catAgentesAduanales_DATA.deletecatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catAgentesAduanales del sistema</summary>
        public ENTResponse deletecatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catAgentesAduanalesDATA datacatAgentesAduanales = new SafeTransfer.DATA.catAgentesAduanalesDATA();
                return datacatAgentesAduanales.deletecatAgentesAduanales(entcatAgentesAduanales);
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