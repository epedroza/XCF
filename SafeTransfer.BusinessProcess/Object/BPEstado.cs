/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPEstado
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Estados
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

   public class BPEstado : BPBase
   {
	  
      ///<remarks>
      ///   <name>BPEstado.SelectEstado</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Estados</summary>
      ///<param name="oENTEstado">Entidad de Estado con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectEstado(ENTEstado oENTEstado){
         DAEstado oDAEstado = new DAEstado();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAEstado.SelectEstado(oENTEstado, this.sConnectionApplication, 0);

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
      ///   <name>catEstados_BSS.searchcatEstados</name>
      ///   <create>30/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Metodo para obtener las catEstados del sistema</summary>
      public ENTResponse searchcatEstadoscbo(ENTEstado entcatEstados)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DAEstado datacatEstados = new DAEstado();
              oENTResponse = datacatEstados.searchcatEstadoscbo(entcatEstados);
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