using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class catTiposCamionesBSS : BPBase
    {
        ///<remarks>
        ///   <name>catTiposCamiones_BSS.searchcatTiposCamiones</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTiposCamiones del sistema</summary>
        public ENTResponse searchcatTiposCamiones(ENTTipoCamion entcatTiposCamiones)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                catTiposCamionesDATA datacatTiposCamiones = new catTiposCamionesDATA();
                oENTResponse = datacatTiposCamiones.searchcatTiposCamiones(entcatTiposCamiones);
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
        ///   <name>catTiposCamiones_DATA.insertcatTiposCamiones</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTiposCamiones del sistema</summary>
        public ENTResponse insertcatTiposCamiones(ENTTipoCamion entcatTiposCamiones)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DataAccess.Object.catTiposCamionesDATA datacatTiposCamiones = new SafeTransfer.DataAccess.Object.catTiposCamionesDATA();
                oENTResponse = datacatTiposCamiones.insertcatTiposCamiones(entcatTiposCamiones);
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
        ///   <name>catTiposCamiones_DATA.updatecatTiposCamiones</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTiposCamiones del sistema</summary>
        public ENTResponse updatecatTiposCamiones(ENTTipoCamion entcatTiposCamiones)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DataAccess.Object.catTiposCamionesDATA datacatTiposCamiones = new SafeTransfer.DataAccess.Object.catTiposCamionesDATA();
                return datacatTiposCamiones.updatecatTiposCamiones(entcatTiposCamiones);
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
        ///   <name>catTiposCamiones_DATA.deletecatTiposCamiones</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTiposCamiones del sistema</summary>
        public ENTResponse deletecatTiposCamiones(ENTTipoCamion entcatTiposCamiones)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DataAccess.Object.catTiposCamionesDATA datacatTiposCamiones = new SafeTransfer.DataAccess.Object.catTiposCamionesDATA();
                return datacatTiposCamiones.deletecatTiposCamiones(entcatTiposCamiones);
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
        ///   <name>catTiposCamiones_BSS.searchcatTiposCamionescbo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTiposCamiones del sistema</summary>
        public ENTResponse searchcatTiposCamionescbo(ENTTipoCamion entcatTiposCamiones)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                SafeTransfer.DataAccess.Object.catTiposCamionesDATA datacatTiposCamiones = new SafeTransfer.DataAccess.Object.catTiposCamionesDATA();
                oENTResponse = datacatTiposCamiones.searchcatTiposCamionescbo(entcatTiposCamiones);
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