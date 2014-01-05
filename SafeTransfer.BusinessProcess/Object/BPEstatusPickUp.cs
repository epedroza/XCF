/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPEstatusPickUp
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el Estatus de PickUp
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

   public class BPEstatusPickUp : BPBase
   {

		///<remarks>
      ///   <name>BPEstatusPickUp.SelectEstatusPickUp</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de EstatusPickUps</summary>
      ///<param name="oENTEstatusPickUp">Entidad de EstatusPickUp con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectEstatusPickUp(ENTEstatusPickUp oENTEstatusPickUp){
         DAEstatusPickUp oDAEstatusPickUp = new DAEstatusPickUp();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAEstatusPickUp.SelectEstatusPickUp(oENTEstatusPickUp, this.sConnectionApplication, 0);

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

   }
}
