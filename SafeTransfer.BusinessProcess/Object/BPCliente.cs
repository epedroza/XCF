/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPCliente
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Clientes
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

   public class BPCliente : BPBase
   {

      ///<remarks>
      ///   <name>catClientes_BSS.searchcatClientes</name>
      ///   <create>24/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Metodo para obtener las catClientes del sistema</summary>
      public ENTResponse searchcatClientescbo(ENTCliente entcatClientes)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACliente datacatClientes = new DACliente();
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
      public ENTResponse searchcatClientesBILLSHIP(ENTCliente entcatClientes)
      {

          ENTResponse oENTResponse = new ENTResponse();
          try
          {
              // Consulta a base de datos
              DACliente datacatClientes = new DACliente();
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
		///   <name>BPCliente.InsertCliente</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la información de un Cliente</summary>
		///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para actualizar su información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertCliente(ENTCliente oENTCliente){
			DACliente oDACliente = new DACliente();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDACliente.InsertCliente(oENTCliente, this.sConnectionApplication, 0);

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
      ///   <name>BPCliente.SelectCliente</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Clientes</summary>
      ///<param name="oENTCliente">Entidad de Cliente con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCliente(ENTCliente oENTCliente){
         DACliente oDACliente = new DACliente();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACliente.SelectCliente(oENTCliente, this.sConnectionApplication, 0);

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
      ///   <name>BPCliente.SelectCliente_Catalogo</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Clientes</summary>
      ///<param name="oENTCliente">Entidad de Cliente con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCliente_Catalogo(ENTCliente oENTCliente){
         DACliente oDACliente = new DACliente();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDACliente.SelectCliente_Catalogo(oENTCliente, this.sConnectionApplication, 0);

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
      ///   <name>BPCliente.UpdateCliente</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Actualiza la información de un Cliente</summary>
      ///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateCliente(ENTCliente oENTCliente){
			DACliente oDACliente = new DACliente();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDACliente.UpdateCliente(oENTCliente, this.sConnectionApplication, 0);

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
      ///   <name>BPCliente.UpdateCliente_Estatus</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Activa/inactiva un Cliente</summary>
      ///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateCliente_Estatus(ENTCliente oENTCliente){
			DACliente oDACliente = new DACliente();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
            oENTResponse = oDACliente.UpdateCliente_Estatus(oENTCliente, this.sConnectionApplication, 0);

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