using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catTiposClienteBSS : BPBase
    {
        ///<remarks>
        ///   <name>catTiposCliente_BSS.searchcatTiposCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTiposCliente del sistema</summary>
        public ENTResponse searchcatTiposCliente(ENTTipoCliente entcatTiposCliente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposClienteDATA datacatTiposCliente = new catTiposClienteDATA();
                oENTResponse = datacatTiposCliente.searchcatTiposCliente(entcatTiposCliente);
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
        ///   <name>catTiposCliente_DATA.insertcatTiposCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTiposCliente del sistema</summary>
        public ENTResponse insertcatTiposCliente(ENTTipoCliente entcatTiposCliente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposClienteDATA datacatTiposCliente = new catTiposClienteDATA();
                oENTResponse = datacatTiposCliente.insertcatTiposCliente(entcatTiposCliente);
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
        ///   <name>catTiposCliente_DATA.updatecatTiposCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTiposCliente del sistema</summary>
        public ENTResponse updatecatTiposCliente(ENTTipoCliente entcatTiposCliente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposClienteDATA datacatTiposCliente = new catTiposClienteDATA();
                return datacatTiposCliente.updatecatTiposCliente(entcatTiposCliente);
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
        ///   <name>catTiposCliente_DATA.deletecatTiposCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTiposCliente del sistema</summary>
        public ENTResponse deletecatTiposCliente(ENTTipoCliente entcatTiposCliente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposClienteDATA datacatTiposCliente = new catTiposClienteDATA();
                return datacatTiposCliente.deletecatTiposCliente(entcatTiposCliente);
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
        ///   <name>catTiposCliente_BSS.searchcatTiposClientecbo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTiposCliente del sistema</summary>
        public ENTResponse searchcatTiposClientecbo(ENTTipoCliente entcatTiposCliente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposClienteDATA datacatTiposCliente = new catTiposClienteDATA();
                oENTResponse = datacatTiposCliente.searchcatTiposClientecbo(entcatTiposCliente);
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