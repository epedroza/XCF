/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPPickUp
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el Menú
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

// Referencias manuales
using SafeTransfer.DataAccess.Object;
using SafeTransfer.Entity.Object;
using System.Data;
using System.Web;

namespace SafeTransfer.BusinessProcess.Object
{

   public class BPPickUp : BPBase
   {
        /// <summary>
        ///     Comprueba si existe la programación para un PickUp.
        /// </summary>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>True|False</returns>
        private bool ExistePickUpProgramacion(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            DAPickUp PickUpAccess = new DAPickUp();

            ResponseEntity = PickUpAccess.SelectPickUpProgramacion(Connection, Transaction, PickUpEntity);

            if (ResponseEntity.dsResponse.Tables[0].Rows.Count == 0)
                return false;
            else
            {
                if (string.IsNullOrEmpty(ResponseEntity.dsResponse.Tables[0].Rows[0]["EsTransportePropio"].ToString()))
                    return false;
                else
                    return true;
            }
        }

		///<remarks>
		///   <name>BPPickUp.InsertPickUp</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Crea un nuevo PickUp</summary>
		///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para crear un nuevo registro</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertPickUp(ENTPickUp oENTPickUp){
			DAPickUp oDAPickUp = new DAPickUp();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAPickUp.InsertPickUp(oENTPickUp, this.sConnectionApplication, 0);

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

        /// <summary>
        ///     Actualiza la tabla tblPickUp con la información de la programación.
        /// </summary>
        /// <param name="Connection">Conexión a la base de datos.</param>
        /// <param name="Transaction">Trnsacción del proceso actual.</param>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        private ENTResponse SavePickUp(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            DAPickUp PickUpAccess = new DAPickUp();

            return PickUpAccess.UpdatePickUp(Connection, Transaction, PickUpEntity);
        }

        /// <summary>
        ///     Guarda la programación de un PickUp.
        /// </summary>
        /// <param name="oENTPickUp">Entidad de PickUp.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SavePickUpProgramacion(ENTPickUp PickUpEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            SqlTransaction Transaction;
            SqlConnection Connection = new SqlConnection(sConnectionApplication);

            Connection.Open();

            Transaction = Connection.BeginTransaction();

            try
            {
                ResponseEntity.sMessage = ValidarProgramacion(PickUpEntity);

                if (ResponseEntity.sMessage != "")
                {
                    Transaction.Rollback();

                    return ResponseEntity;
                }

                ResponseEntity = SavePickUp(Connection, Transaction, PickUpEntity);

                if (ResponseEntity.sMessage != "")
                {
                    Transaction.Rollback();

                    return ResponseEntity;
                }

                ResponseEntity = SavePickUpProgramacion(Connection, Transaction, PickUpEntity);

                if (ResponseEntity.sMessage == "")
                    Transaction.Commit();
                else
                {
                    Transaction.Rollback();

                    return ResponseEntity;
                }

                Connection.Close();
            }
            catch (Exception Excepcion)
            {
                ResponseEntity.sMessage = Excepcion.Message;

                Transaction.Rollback();

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return ResponseEntity;
        }

        /// <summary>
        ///     Guarda la información de la programación de un PickUp.
        /// </summary>
        /// <param name="Connection">Conexión a la base de datos.</param>
        /// <param name="Transaction">Trnsacción del proceso actual.</param>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        private ENTResponse SavePickUpProgramacion(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            DAPickUp PickUpAccess = new DAPickUp();

            if (ExistePickUpProgramacion(Connection, Transaction, PickUpEntity))
                ResponseEntity = PickUpAccess.UpdatePickUpProgramacion(Connection, Transaction, PickUpEntity);
            else
                ResponseEntity = PickUpAccess.InsertPickUpProgramacion(Connection, Transaction, PickUpEntity);

            return ResponseEntity;
        }
	  
      ///<remarks>
      ///   <name>BPPickUp.SelectPickUp</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta la tabla de PickUps</summary>
      ///<param name="oENTPickUp">Entidad de PickUp con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectPickUp(ENTPickUp oENTPickUp){
         DAPickUp oDAPickUp = new DAPickUp();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAPickUp.SelectPickUp(oENTPickUp, this.sConnectionApplication, 0);

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
      ///   <name>BPPickUp.SelectPickUp</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta la tabla de PickUps</summary>
      ///<param name="oENTPickUp">Entidad de PickUp con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectPickUpMonitor(ENTPickUp oENTPickUp)
      {
          DAPickUp oDAPickUp = new DAPickUp();
          ENTResponse oENTResponse = new ENTResponse();

          try
          {

              // Transacción en base de datos
              oENTResponse = oDAPickUp.SelectPickUpMonitor(oENTPickUp, this.sConnectionApplication, 0);

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
        ///     Busca la información de PickUp para una programación.
        /// </summary>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SelectPickUpProgramacion(ENTPickUp PickUpEntity)
        {
            DAPickUp oDAPickUp = new DAPickUp();
            ENTResponse ResponseEntity = new ENTResponse();

            try
            {
                ResponseEntity = oDAPickUp.SelectPickUpProgramacion(PickUpEntity, this.sConnectionApplication);

                return ResponseEntity;
            }
            catch (Exception ex)
            {
                ResponseEntity.ExceptionRaised(ex.Message);
            }

            // Resultado
            return ResponseEntity;
        }
	  
      ///<remarks>
      ///   <name>BPPickUp.UpdatePickUp</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Actualiza la información de un PickUp</summary>
      ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdatePickUp(ENTPickUp oENTPickUp){
			DAPickUp oDAPickUp = new DAPickUp();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAPickUp.UpdatePickUp(oENTPickUp, this.sConnectionApplication, 0);

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
      ///   <name>BPPickUp.UpdatePickUp_Estatus</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Cambia el Estatus de un PickUp</summary>
      ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdatePickUp_Estatus(ENTPickUp oENTPickUp){
			DAPickUp oDAPickUp = new DAPickUp();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
            oENTResponse = oDAPickUp.UpdatePickUp_Estatus(oENTPickUp, this.sConnectionApplication, 0);

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

        /// <summary>
        ///     Valida la información enviada para la programación del PickUp.
        /// </summary>
        /// <returns>True | Fasle</returns>
        private string ValidarProgramacion(ENTPickUp PickUpEntity)
        {
            DateTime Fecha;

            if (!DateTime.TryParse(PickUpEntity.dtPickUp, out Fecha))
                return "No se proporcionó una fecha válida";

            if (PickUpEntity.sDireccion == "")
                return "El campo [Lugar] es obligatorio";

            if (PickUpEntity.EsTransportePropio == 0)
                if (PickUpEntity.Proveedor == "")
                    return "Si el transporte no es propio, el campo [Proveedor] es obligatorio";

            return "";
        }
   }

}
