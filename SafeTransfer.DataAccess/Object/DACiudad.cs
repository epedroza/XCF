/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DACiudad
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Menús
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

   public class DACiudad : DABase
   {
       Database dbs;
       public DACiudad()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
      ///<remarks>
		///   <name>DACiudad.SelectCiudad</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Ciudades en base a los parámetros proporcionados</summary>
		///<param name="oENTCiudad">Entidad de Ciudad con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectCiudad(ENTCiudad oENTCiudad, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatCiudad_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idCiudad", SqlDbType.Int);
			sqlPar.Value = oENTCiudad.idCiudad;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idEstado", SqlDbType.Int);
         sqlPar.Value = oENTCiudad.idEstado;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idPais", SqlDbType.Int);
         sqlPar.Value = oENTCiudad.idPais;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTCiudad.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTCiudad.tiActivo;
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
        ///   <name>catCiudades_DATA.searchcatCiudades</name>
        ///   <create>30/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCiudades del sistema</summary>
        public ENTResponse searchcatCiudadescbo(ENTCiudad entcatCiudades)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCiudadesSelcbo", entcatCiudades.idPais, entcatCiudades.idEstado);
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

   }

}
