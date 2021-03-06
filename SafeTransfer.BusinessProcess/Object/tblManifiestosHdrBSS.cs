using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SafeTransfer.DataAccess.Object;

using SafeTransfer.Entity.Object;

namespace SafeTransfer.BusinessProcess.Object
{
    public class tblManifiestosHdrBSS : BPBase
    {
        ///<remarks>
        ///   <name>tblManifiestosHdr_BSS.searchtblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosHdr del sistema</summary>
        public ENTResponse searchtblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosHdrDATA datatblManifiestosHdr = new tblManifiestosHdrDATA();
                oENTResponse = datatblManifiestosHdr.searchtblManifiestosHdr(enttblManifiestosHdr);
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
        ///   <name>tblManifiestosHdr_DATA.inserttblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblManifiestosHdr del sistema</summary>
        public ENTResponse inserttblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosHdrDATA datatblManifiestosHdr = new tblManifiestosHdrDATA();
                oENTResponse = datatblManifiestosHdr.inserttblManifiestosHdr(enttblManifiestosHdr);
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
        ///   <name>tblManifiestosHdr_DATA.updatetblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblManifiestosHdr del sistema</summary>
        public ENTResponse updatetblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosHdrDATA datatblManifiestosHdr = new tblManifiestosHdrDATA();
                return datatblManifiestosHdr.updatetblManifiestosHdr(enttblManifiestosHdr);
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
        ///   <name>tblManifiestosHdr_DATA.deletetblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblManifiestosHdr del sistema</summary>
        public ENTResponse deletetblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosHdrDATA datatblManifiestosHdr = new tblManifiestosHdrDATA();
                return datatblManifiestosHdr.deletetblManifiestosHdr(enttblManifiestosHdr);
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
        ///   <name>tblManifiestosHdr_BSS.searchtblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosHdr del sistema</summary>
        public ENTResponse searchtblManifiestosHdrMonitor(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                tblManifiestosHdrDATA datatblManifiestosHdr = new tblManifiestosHdrDATA();
                oENTResponse = datatblManifiestosHdr.searchtblManifiestosHdrMonitor(enttblManifiestosHdr);
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

        /// <summary>
        ///     Actualiza los estatus de los Pros de un manifiesto.
        /// </summary>
        /// <param name="ManifiestoEntity">Entidad de Manifiesto.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SaveDownloadPro(Entity.tblManifiestosHdr_Ent ManifiestoEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            tblManifiestosHdrDATA ManifiestoAccess = new tblManifiestosHdrDATA();

            ResponseEntity = ManifiestoAccess.UpdateManifiestoDownload(ManifiestoEntity, sConnectionApplication);

            return ResponseEntity;
        }

        /// <summary>
        ///     Actualiza los estatus de los Pros de un manifiesto.
        /// </summary>
        /// <param name="ManifiestoEntity">Entidad de Manifiesto.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SaveUploadPro(Entity.tblManifiestosHdr_Ent ManifiestoEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            tblManifiestosHdrDATA ManifiestoAccess = new tblManifiestosHdrDATA();

            ResponseEntity = ManifiestoAccess.UpdateManifiestoUpload(ManifiestoEntity, sConnectionApplication);

            return ResponseEntity;
        }

        /// <summary>
        ///     Obtiene el listado de los pickups que se van a descargar en la Recepción.
        /// </summary>
        /// <param name="PickUpEntity">Entidad del manifiesto.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SelectProsDownload(Entity.tblManifiestosHdr_Ent ManifiestoEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            tblManifiestosHdrDATA ManifiestoAccess = new tblManifiestosHdrDATA();

            try
            {
                ResponseEntity = ManifiestoAccess.SelectProsDownload(ManifiestoEntity, this.sConnectionApplication);

                return ResponseEntity;
            }
            catch (Exception ex)
            {
                ResponseEntity.ExceptionRaised(ex.Message);
            }

            // Resultado
            return ResponseEntity;
        }

        /// <summary>
        ///     Obtiene el listado de los pickups que se van a cargar en la Recepción.
        /// </summary>
        /// <param name="PickUpEntity">Entidad del manifiesto.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SelectProsUpload(Entity.tblManifiestosHdr_Ent ManifiestoEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            tblManifiestosHdrDATA ManifiestoAccess = new tblManifiestosHdrDATA();

            try
            {
                ResponseEntity = ManifiestoAccess.SelectProsUpload(ManifiestoEntity, this.sConnectionApplication);

                return ResponseEntity;
            }
            catch (Exception ex)
            {
                ResponseEntity.ExceptionRaised(ex.Message);
            }

            // Resultado
            return ResponseEntity;
        }
    }
}