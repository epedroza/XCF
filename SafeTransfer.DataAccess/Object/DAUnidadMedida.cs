/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAUnidadMedida
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Unidades de Medida
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.DataAccess.Object
{
	
	public class DAUnidadMedida : DABase
	{
		
		///<remarks>
		///   <name>DAUnidadMedida.SelectUnidadMedida</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene un listado de Unidades de Medida en base a los parámetros proporcionados</summary>
		///<param name="oENTUnidadMedida">Entidad de Unidad de Medida con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectUnidadMedida(ENTUnidadMedida oENTUnidadMedida, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUnidadMedida_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idUnidadMedida", SqlDbType.Int);
			sqlPar.Value = oENTUnidadMedida.idUnidadMedida;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idMagnitudFisica", SqlDbType.Int);
         sqlPar.Value = oENTUnidadMedida.idMagnitudFisica;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTUnidadMedida.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTUnidadMedida.tiActivo;
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