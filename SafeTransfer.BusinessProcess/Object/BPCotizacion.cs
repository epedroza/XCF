/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPCotizacion
' Autor: Ruben.Cobos
' Fecha: 19-Diciembre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Cotizacions
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

   public class BPCotizacion : BPBase
   {
	  
      ///<remarks>
      ///   <name>BPCotizacion.SelectCotizacion</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta una cotización asociada a un PickUp</summary>
      ///<param name="oENTCotizacion">Entidad de Cotizacion con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCotizacion(ENTCotizacion oENTCotizacion){
         DACotizacion oDACotizacion = new DACotizacion();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACotizacion.SelectCotizacion(oENTCotizacion, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

      ///<remarks>
      ///   <name>BPCotizacion.InsertCotizacion</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Crea una nueva Cotización asociada a un PickUp</summary>
      ///<param name="oENTCotizacion">Entidad de Cotizacion</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse InsertCotizacion(ENTCotizacion oENTCotizacion){
         DACotizacion oDACotizacion = new DACotizacion();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACotizacion.InsertCotizacion(oENTCotizacion, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

      ///<remarks>
      ///   <name>BPCotizacion.UpdateCotizacion</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Actualiza una Cotización asociada a un PickUp existente</summary>
      ///<param name="oENTCotizacion">Entidad de Cotizacion</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse UpdateCotizacion(ENTCotizacion oENTCotizacion){
         DACotizacion oDACotizacion = new DACotizacion();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACotizacion.UpdateCotizacion(oENTCotizacion, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

   }

}