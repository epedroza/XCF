using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catBillToShipToBSS : BPBase
    {
        ///<remarks>
        ///   <name>catBillToShipTo_BSS.searchcatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catBillToShipTo del sistema</summary>
        public ENTResponse searchcatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catBillToShipToDATA datacatBillToShipTo = new SafeTransfer.DATA.catBillToShipToDATA();
                oENTResponse = datacatBillToShipTo.searchcatBillToShipTo(entcatBillToShipTo);
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
        ///   <name>catBillToShipTo_DATA.insertcatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catBillToShipTo del sistema</summary>
        public ENTResponse insertcatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catBillToShipToDATA datacatBillToShipTo = new SafeTransfer.DATA.catBillToShipToDATA();
                oENTResponse = datacatBillToShipTo.insertcatBillToShipTo(entcatBillToShipTo);
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
        ///   <name>catBillToShipTo_DATA.updatecatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catBillToShipTo del sistema</summary>
        public ENTResponse updatecatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catBillToShipToDATA datacatBillToShipTo = new SafeTransfer.DATA.catBillToShipToDATA();
                return datacatBillToShipTo.updatecatBillToShipTo(entcatBillToShipTo);
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
        ///   <name>catBillToShipTo_DATA.deletecatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catBillToShipTo del sistema</summary>
        public ENTResponse deletecatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catBillToShipToDATA datacatBillToShipTo = new SafeTransfer.DATA.catBillToShipToDATA();
                return datacatBillToShipTo.deletecatBillToShipTo(entcatBillToShipTo);
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
        ///   <name>catBillToShipTo_BSS.searchcatBillToShipTocbo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catBillToShipTo del sistema</summary>
        public ENTResponse searchcatBillToShipTocbo(ENTBillToShip entcatBillToShipTo)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catBillToShipToDATA datacatBillToShipTo = new SafeTransfer.DATA.catBillToShipToDATA();
                oENTResponse = datacatBillToShipTo.searchcatBillToShipTocbo(entcatBillToShipTo);
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