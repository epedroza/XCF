using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catCentrosDeServicioBSS : BPBase
    {
        ///<remarks>
        ///   <name>catCentrosDeServicio_BSS.searchcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCentrosDeServicio del sistema</summary>
        public ENTResponse searchcatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catCentrosDeServicioDATA datacatCentrosDeServicio = new SafeTransfer.DATA.catCentrosDeServicioDATA();
                oENTResponse = datacatCentrosDeServicio.searchcatCentrosDeServicio(entcatCentrosDeServicio);
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
        ///   <name>catCentrosDeServicio_BSS.searchcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCentrosDeServicio del sistema</summary>
        public ENTResponse searchcatCentrosDeServiciocbo(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catCentrosDeServicioDATA datacatCentrosDeServicio = new SafeTransfer.DATA.catCentrosDeServicioDATA();
                oENTResponse = datacatCentrosDeServicio.searchcatCentrosDeServiciocbo(entcatCentrosDeServicio);
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
        ///   <name>catCentrosDeServicio_DATA.insertcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCentrosDeServicio del sistema</summary>
        public ENTResponse insertcatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catCentrosDeServicioDATA datacatCentrosDeServicio = new SafeTransfer.DATA.catCentrosDeServicioDATA();
                oENTResponse = datacatCentrosDeServicio.insertcatCentrosDeServicio(entcatCentrosDeServicio);
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
        ///   <name>catCentrosDeServicio_DATA.updatecatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCentrosDeServicio del sistema</summary>
        public ENTResponse updatecatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catCentrosDeServicioDATA datacatCentrosDeServicio = new SafeTransfer.DATA.catCentrosDeServicioDATA();
                return datacatCentrosDeServicio.updatecatCentrosDeServicio(entcatCentrosDeServicio);
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
        ///   <name>catCentrosDeServicio_DATA.deletecatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCentrosDeServicio del sistema</summary>
        public ENTResponse deletecatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DATA.catCentrosDeServicioDATA datacatCentrosDeServicio = new SafeTransfer.DATA.catCentrosDeServicioDATA();
                return datacatCentrosDeServicio.deletecatCentrosDeServicio(entcatCentrosDeServicio);
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
