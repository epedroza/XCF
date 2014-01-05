/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPCentroServicio
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Centros de Servicio
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;
using System.Data;
using System.Web;

namespace SafeTransfer.BusinessProcess.Object
{

   public class BPCentroServicio : BPBase
   {
	  
      ///<remarks>
      ///   <name>BPCentroServicio.SelectCentroServicio</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Centros de Servicio</summary>
      ///<param name="oENTCentroServicio">Entidad de CentroServicio con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCentroServicio(ENTCentroServicio oENTCentroServicio){
         DACentroServicio oDACentroServicio = new DACentroServicio();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACentroServicio.SelectCentroServicio(oENTCentroServicio, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
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
      public ENTResponse searchcatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACentroServicio datacatCentrosDeServicio = new DACentroServicio();
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
      public ENTResponse searchcatCentrosDeServiciocbo(ENTCentroServicio entcatCentrosDeServicio)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACentroServicio datacatCentrosDeServicio = new DACentroServicio();
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
      public ENTResponse insertcatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACentroServicio datacatCentrosDeServicio = new DACentroServicio();
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
      public ENTResponse updatecatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACentroServicio datacatCentrosDeServicio = new DACentroServicio();
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
      public ENTResponse deletecatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACentroServicio datacatCentrosDeServicio = new DACentroServicio();
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