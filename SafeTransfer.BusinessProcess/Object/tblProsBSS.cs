using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class tblProsBSS : BPBase
    {
        ///<remarks>
        ///   <name>tblPros_BSS.searchtblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblPros del sistema</summary>
        public ENTResponse searchtblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblProsDATA datatblPros = new tblProsDATA();
                oENTResponse = datatblPros.searchtblPros(enttblPros);
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
        ///   <name>tblPros_BSS.searchtblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para Consultar la tblPros del sistema</summary>
        public void gettblPros(ref SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DataSet ds;
                tblProsDATA datatblPros = new tblProsDATA();
                oENTResponse = datatblPros.searchtblPros(enttblPros);
                // Aqui van los parametros para la consulta
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
        }
        ///<remarks>
        ///   <name>tblPros_DATA.inserttblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblPros del sistema</summary>
        public ENTResponse inserttblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblProsDATA datatblPros = new tblProsDATA();
                oENTResponse = datatblPros.inserttblPros(enttblPros);
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
        ///   <name>tblPros_DATA.updatetblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblPros del sistema</summary>
        public ENTResponse updatetblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblProsDATA datatblPros = new tblProsDATA();
                return datatblPros.updatetblPros(enttblPros);
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
        ///   <name>tblPros_DATA.deletetblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblPros del sistema</summary>
        public ENTResponse deletetblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblProsDATA datatblPros = new tblProsDATA();
                return datatblPros.deletetblPros(enttblPros);
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
        ///   <name>tblPros_BSS.searchtblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblPros del sistema</summary>
        public ENTResponse searchtblProsMonitor(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblProsDATA datatblPros = new tblProsDATA();
                oENTResponse = datatblPros.searchtblProsMonitor(enttblPros);
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
