/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPCiudad
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Ciudades
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

   public class BPCiudad : BPBase
   {
	  
      ///<remarks>
      ///   <name>BPCiudad.SelectCiudad</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Ciudades</summary>
      ///<param name="oENTCiudad">Entidad de Ciudad con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCiudad(ENTCiudad oENTCiudad){
         DACiudad oDACiudad = new DACiudad();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACiudad.SelectCiudad(oENTCiudad, this.sConnectionApplication, 0);

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
      ///   <name>catCiudades_BSS.searchcatCiudades</name>
      ///   <create>30/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Metodo para obtener las catCiudades del sistema</summary>
      public ENTResponse searchcatCiudadescbo(ENTCiudad entcatCiudades)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACiudad datacatCiudades = new DACiudad();
              oENTResponse = datacatCiudades.searchcatCiudadescbo(entcatCiudades);
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