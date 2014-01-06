using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catClientesBSS : BPBase
    {
        ///<remarks>
        ///   <name>catClientes_BSS.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                oENTResponse = datacatClientes.searchcatClientes(entcatClientes);
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
        ///   <name>catClientes_BSS.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientescbo(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                oENTResponse = datacatClientes.searchcatClientescbo(entcatClientes);
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
        ///   <name>catClientes_BSS.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientesBILLSHIP(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                oENTResponse = datacatClientes.searchcatClientesBILLSHIP(entcatClientes);
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
        ///   <name>catClientes_DATA.insertcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catClientes del sistema</summary>
        public ENTResponse insertcatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                oENTResponse = datacatClientes.insertcatClientes(entcatClientes);
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
        ///   <name>catClientes_DATA.updatecatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catClientes del sistema</summary>
        public ENTResponse updatecatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                return datacatClientes.updatecatClientes(entcatClientes);
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
        ///   <name>catClientes_DATA.deletecatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catClientes del sistema</summary>
        public ENTResponse deletecatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catClientesDATA datacatClientes = new SafeTransfer.DATA.catClientesDATA();
                return datacatClientes.deletecatClientes(entcatClientes);
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
