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
    public class catCentrosDeServicioDATA
    {
        Database dbs;
        public catCentrosDeServicioDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catCentrosDeServicio_DATA.searchcatCentrosDeServicio</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCentrosDeServicio del sistema</summary>
        public ENTResponse searchcatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioSel", entcatCentrosDeServicio.IdCompania, entcatCentrosDeServicio.IdCentroDeServicio, entcatCentrosDeServicio.Nombre);
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
        public ENTResponse searchcatCentrosDeServiciocbo(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioSelcbo", entcatCentrosDeServicio.IdCompania);
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
        public ENTResponse insertcatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCentrosDeServicioIns", entcatCentrosDeServicio.IdCompania, entcatCentrosDeServicio.Nombre, entcatCentrosDeServicio.RFC, entcatCentrosDeServicio.Terminal, entcatCentrosDeServicio.CD, entcatCentrosDeServicio.Direccion, entcatCentrosDeServicio.IdCiudad, entcatCentrosDeServicio.ProExterno);
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
        public ENTResponse updatecatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCentrosDeServicioUpd", entcatCentrosDeServicio.IdCompania, entcatCentrosDeServicio.IdCentroDeServicio, entcatCentrosDeServicio.Nombre, entcatCentrosDeServicio.RFC, entcatCentrosDeServicio.Terminal, entcatCentrosDeServicio.CD, entcatCentrosDeServicio.Direccion, entcatCentrosDeServicio.IdCiudad, entcatCentrosDeServicio.ProExterno);
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
        public ENTResponse deletecatCentrosDeServicio(SafeTransfer.Entity.catCentrosDeServicio_Ent entcatCentrosDeServicio)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCentrosDeServicioDel", entcatCentrosDeServicio.IdCompania, entcatCentrosDeServicio.IdCentroDeServicio);
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
