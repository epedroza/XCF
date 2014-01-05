using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.DATA
{
    public class catAgentesAduanalesDATA
    {
        Database dbs;
        public catAgentesAduanalesDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_DATA.searchcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catAgentesAduanales del sistema</summary>
        public ENTResponse searchcatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catAgentesAduanalesSel", entcatAgentesAduanales.IdCompania, entcatAgentesAduanales.ClaveAgenteAduanal, entcatAgentesAduanales.Nombre);
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
        ///   <name>catAgentesAduanales_DATA.searchcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catAgentesAduanales del sistema</summary>
        public ENTResponse searchcatAgentesAduanalescbo(ENTAgenteAduanal entcatAgentesAduanales)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catAgentesAduanalesSelcbo", entcatAgentesAduanales.IdCompania);
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
        ///   <name>catAgentesAduanales_DATA.insertcatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catAgentesAduanales del sistema</summary>
        public ENTResponse insertcatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catAgentesAduanalesIns", entcatAgentesAduanales.IdCompania, entcatAgentesAduanales.Nombre, entcatAgentesAduanales.Descripcion, entcatAgentesAduanales.RFC, entcatAgentesAduanales.Terminal, entcatAgentesAduanales.CD, entcatAgentesAduanales.Direccion, entcatAgentesAduanales.IdCiudad);
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
        ///   <name>catAgentesAduanales_DATA.updatecatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catAgentesAduanales del sistema</summary>
        public ENTResponse updatecatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catAgentesAduanalesUpd", entcatAgentesAduanales.ClaveAgenteAduanal, entcatAgentesAduanales.IdCompania, entcatAgentesAduanales.Nombre, entcatAgentesAduanales.Descripcion, entcatAgentesAduanales.RFC, entcatAgentesAduanales.Terminal, entcatAgentesAduanales.CD, entcatAgentesAduanales.Direccion, entcatAgentesAduanales.IdCiudad);
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
        ///   <name>catAgentesAduanales_DATA.deletecatAgentesAduanales</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catAgentesAduanales del sistema</summary>
        public ENTResponse deletecatAgentesAduanales(ENTAgenteAduanal entcatAgentesAduanales)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catAgentesAduanalesDel", entcatAgentesAduanales.IdCompania, entcatAgentesAduanales.ClaveAgenteAduanal);
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
