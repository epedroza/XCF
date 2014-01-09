/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DACliente
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Clientes
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.DataAccess.Object
{

   public class DACliente : DABase
   {

      // Variables
      Database dbs;

      // Constructor
      public DACliente(){

         dbs = DatabaseFactory.CreateDatabase("Conn");
      }

      ///<remarks>
      ///   <name>catClientes_DATA.searchcatClientes</name>
      ///   <create>24/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Metodo para obtener las catClientes del sistema</summary>
      public ENTResponse searchcatClientescbo(ENTCliente entcatClientes)
      {
         ENTResponse oENTResponse = new ENTResponse();
         DataSet ds = new DataSet();
         // Transacción
         try
         {
            ds = dbs.ExecuteDataSet("catClientesSelcbo", entcatClientes.idCompany);
            oENTResponse.dsResponse = ds;
         }
         catch (SqlException sqlEx)
         {
            oENTResponse.ExceptionRaised(sqlEx.Message);
         }
         catch (Exception ex)
         {
            oENTResponse.ExceptionRaised(ex.Message);
         }
         finally
         {
         }
         // Resultado
         return oENTResponse;

      }

      ///<remarks>
      ///   <name>catClientes_DATA.searchcatClientes</name>
      ///   <create>24/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Metodo para obtener las catClientes del sistema</summary>
      public ENTResponse searchcatClientesBILLSHIP(ENTCliente entcatClientes)
      {
         ENTResponse oENTResponse = new ENTResponse();
         DataSet ds = new DataSet();
         // Transacción
         try
         {
            ds = dbs.ExecuteDataSet("catClientesBillToShipToSel", entcatClientes.idCompany, entcatClientes.idCliente, entcatClientes.FolioBillShip, entcatClientes.BillOrShip);
            oENTResponse.dsResponse = ds;
         }
         catch (SqlException sqlEx)
         {
            oENTResponse.ExceptionRaised(sqlEx.Message);
         }
         catch (Exception ex)
         {
            oENTResponse.ExceptionRaised(ex.Message);
         }
         finally
         {
         }
         // Resultado
         return oENTResponse;

      }

      ///<remarks>
		///   <name>DACliente.InsertCliente</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Crea una nueva opción en el Cliente</summary>
		///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertCliente(ENTCliente oENTCliente, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatCliente_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idCompany;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idTipoCliente", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idTipoCliente;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPorcientoImpuestos", SqlDbType.Decimal);
         sqlPar.Value = oENTCliente.dPorcientoImpuestos;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPorcientoRetencion", SqlDbType.Decimal);
         sqlPar.Value = oENTCliente.dPorcientoRetencion;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iClaveGTEDes", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iClaveGTEDes;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iClaveVendedorOriginal", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iClaveVendedorOriginal;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iDiasCredito", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iDiasCredito;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iPreferencial", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iPreferencial;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iTerminal", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iTerminal;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sDescripcion ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sDescripcion;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sFax ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sFax;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sMetodoPago", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sMetodoPago;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTCliente.sNombre;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sTarifa ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sTarifa;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTCliente.tiActivo;
         sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}catch (SqlException sqlEx){
				oENTResponse.ExceptionRaised(sqlEx.Message);
			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}
		
		///<remarks>
		///   <name>DACliente.SelectCliente</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene un listado de Clientes en base a los parámetros proporcionados</summary>
		///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectCliente(ENTCliente oENTCliente, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
         sqlCom = new SqlCommand("uspcatCliente_Sel_Catalogo", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idCliente", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idCliente;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idCompany;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idSucursal", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idSucursal;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTCliente.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTCliente.tiActivo;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}catch (SqlException sqlEx){
				oENTResponse.ExceptionRaised(sqlEx.Message);
			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}
		
		///<remarks>
		///   <name>DACliente.UpdateCliente</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la información de un Cliente</summary>
		///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateCliente(ENTCliente oENTCliente, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatCliente_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idCliente", SqlDbType.Int);
			sqlPar.Value = oENTCliente.idCliente;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idCompany;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idTipoCliente", SqlDbType.Int);
         sqlPar.Value = oENTCliente.idTipoCliente;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPorcientoImpuestos", SqlDbType.Decimal);
         sqlPar.Value = oENTCliente.dPorcientoImpuestos;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPorcientoRetencion", SqlDbType.Decimal);
         sqlPar.Value = oENTCliente.dPorcientoRetencion;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iClaveGTEDes", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iClaveGTEDes;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iClaveVendedorOriginal", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iClaveVendedorOriginal;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iDiasCredito", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iDiasCredito;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iPreferencial", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iPreferencial;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("iTerminal", SqlDbType.Int);
         sqlPar.Value = oENTCliente.iTerminal;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sDescripcion ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sDescripcion;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sFax ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sFax;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sMetodoPago", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sMetodoPago;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sNombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sTarifa ", SqlDbType.VarChar);
         sqlPar.Value = oENTCliente.sTarifa;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTCliente.tiActivo;
         sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}catch (SqlException sqlEx){
				oENTResponse.ExceptionRaised(sqlEx.Message);
			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}

      ///<remarks>
      ///   <name>DACliente.UpdateCliente_Estatus</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
      ///<summary>Activa/inactiva un Cliente</summary>
		///<param name="oENTCliente">Entidad de Cliente con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateCliente_Estatus(ENTCliente oENTCliente, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatCliente_Upd_Estatus", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idCliente", SqlDbType.Int);
			sqlPar.Value = oENTCliente.idCliente;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTCliente.tiActivo;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}catch (SqlException sqlEx){
				oENTResponse.ExceptionRaised(sqlEx.Message);
			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}

   }
}
