/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DACotizacion
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con las Cotizaciones
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
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

   public class DACotizacion : DABase
   {

      ///<remarks>
		///   <name>DACotizacion.SelectCotizacion</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene la información de una cotización asociada a un PickUp en base a los parámetros proporcionados</summary>
		///<param name="oENTCotizacion">Entidad de Cotizacion con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectCotizacion(ENTCotizacion oENTCotizacion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
         sqlCom = new SqlCommand("usptblCotizacion_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idPickUp;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiRecalculo", SqlDbType.TinyInt);
         sqlPar.Value = oENTCotizacion.tiRecalculo;
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
		///   <name>DACotizacion.InsertCotizacion</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
      ///<summary>Crea una nueva Cotización asociada a un PickUp</summary>
		///<param name="oENTCotizacion">Entidad de Cotizacion con los parámetros necesarios para crearla</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertCotizacion(ENTCotizacion oENTCotizacion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
         sqlCom = new SqlCommand("usptblCotizacion_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idCiudad_Destino", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCiudad_Destino;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCiudad_Origen", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCiudad_Origen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCompany;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idMoneda", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idMoneda;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idPickUp;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idUnidadMedida_Peso", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idUnidadMedida_Peso;
			sqlCom.Parameters.Add(sqlPar);
         
         sqlPar = new SqlParameter("idUnidadMedida_Volumen", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idUnidadMedida_Volumen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPeso", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.dPeso;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dVolumen", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.dVolumen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("mCargoExtra", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.mCargoExtra;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("mDescuento", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.mDescuento;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tblCotizacionPartidas", SqlDbType.Structured);
         sqlPar.Value = oENTCotizacion.tblCotizacionPartidas;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tblServicios", SqlDbType.Structured);
         sqlPar.Value = oENTCotizacion.tblServicios;
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
		///   <name>DACotizacion.UpdateCotizacion</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
      ///<summary>Actualiza una Cotización asociada a un PickUp existente</summary>
		///<param name="oENTCotizacion">Entidad de Cotizacion con los parámetros necesarios para actualizar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateCotizacion(ENTCotizacion oENTCotizacion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
         sqlCom = new SqlCommand("usptblCotizacion_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idCiudad_Destino", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCiudad_Destino;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCiudad_Origen", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCiudad_Origen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idCompany;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idMoneda", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idMoneda;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idPickUp;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idUnidadMedida_Peso", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idUnidadMedida_Peso;
			sqlCom.Parameters.Add(sqlPar);
         
         sqlPar = new SqlParameter("idUnidadMedida_Volumen", SqlDbType.Int);
         sqlPar.Value = oENTCotizacion.idUnidadMedida_Volumen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dPeso", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.dPeso;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("dVolumen", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.dVolumen;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("mCargoExtra", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.mCargoExtra;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("mDescuento", SqlDbType.Decimal);
         sqlPar.Value = oENTCotizacion.mDescuento;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tblCotizacionPartidas", SqlDbType.Structured);
         sqlPar.Value = oENTCotizacion.tblCotizacionPartidas;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tblServicios", SqlDbType.Structured);
         sqlPar.Value = oENTCotizacion.tblServicios;
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
