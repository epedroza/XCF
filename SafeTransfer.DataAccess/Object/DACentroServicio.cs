/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DACentroServicio
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Centros de Servicio
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

   public class DACentroServicio : DABase
   {
       Database dbs;
       public DACentroServicio()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

      ///<remarks>
		///   <name>DACentroServicio.SelectCentroServicio</name>
		///   <create>26-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de CentroServicios en base a los parámetros proporcionados</summary>
		///<param name="oENTCentroServicio">Entidad de CentroServicio con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectCentroServicio(ENTCentroServicio oENTCentroServicio, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatCentroServicio_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idCentroServicio", SqlDbType.Int);
         sqlPar.Value = oENTCentroServicio.idCentroServicio;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
         sqlPar.Value = oENTCentroServicio.idCompany;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTCentroServicio.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTCentroServicio.tiActivo;
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
        ///   <name>catCentrosDeServicio_DATA.searchcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCentrosDeServicio del sistema</summary>
        public ENTResponse searchcatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioSel", entcatCentrosDeServicio.idCompany, entcatCentrosDeServicio.idCentroServicio, entcatCentrosDeServicio.sNombre);
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
        ///   <name>catCentrosDeServicio_DATA.searchcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCentrosDeServicio del sistema</summary>
        public ENTResponse searchcatCentrosDeServiciocbo(ENTCentroServicio entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioSelcbo", entcatCentrosDeServicio.idCompany);
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
        ///   <name>catCentrosDeServicio_DATA.insertcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCentrosDeServicio del sistema</summary>
        public ENTResponse insertcatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioIns", entcatCentrosDeServicio.idCompany, entcatCentrosDeServicio.sDescripcion, entcatCentrosDeServicio.sNombre, entcatCentrosDeServicio.RFC, entcatCentrosDeServicio.Terminal, entcatCentrosDeServicio.CD, entcatCentrosDeServicio.Direccion, entcatCentrosDeServicio.IdCiudad, entcatCentrosDeServicio.ProExterno);
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
        ///   <name>catCentrosDeServicio_DATA.updatecatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCentrosDeServicio del sistema</summary>
        public ENTResponse updatecatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCentrosDeServicioUpd", entcatCentrosDeServicio.idCompany, entcatCentrosDeServicio.idCentroServicio, entcatCentrosDeServicio.sDescripcion, entcatCentrosDeServicio.sNombre, entcatCentrosDeServicio.RFC, entcatCentrosDeServicio.Terminal, entcatCentrosDeServicio.CD, entcatCentrosDeServicio.Direccion, entcatCentrosDeServicio.IdCiudad, entcatCentrosDeServicio.ProExterno);
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
        ///   <name>catCentrosDeServicio_DATA.deletecatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCentrosDeServicio del sistema</summary>
        public ENTResponse deletecatCentrosDeServicio(ENTCentroServicio entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCentrosDeServicioDel", entcatCentrosDeServicio.idCompany, entcatCentrosDeServicio.idCentroServicio);
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
