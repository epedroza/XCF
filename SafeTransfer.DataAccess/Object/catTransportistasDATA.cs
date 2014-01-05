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
    public class catTransportistasDATA
    {
        Database dbs;
        public catTransportistasDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catTransportistas_DATA.searchcatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTransportistas del sistema</summary>
        public ENTResponse searchcatTransportistas(ENTTransportista entcatTransportistas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catTransportistasSel", entcatTransportistas.idCompany, entcatTransportistas.idTransportista, entcatTransportistas.sNombre);
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
        ///   <name>catTransportistas_DATA.insertcatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTransportistas del sistema</summary>
        public ENTResponse insertcatTransportistas(ENTTransportista entcatTransportistas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catTransportistasIns", entcatTransportistas.idCompany, entcatTransportistas.IdCiudad, entcatTransportistas.sDescripcion, entcatTransportistas.sNombre, entcatTransportistas.RFC, entcatTransportistas.Direccion, entcatTransportistas.Colonia, entcatTransportistas.RazonSocial);
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
        ///   <name>catTransportistas_DATA.updatecatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTransportistas del sistema</summary>
        public ENTResponse updatecatTransportistas(ENTTransportista entcatTransportistas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catTransportistasUpd", entcatTransportistas.idTransportista, entcatTransportistas.idCompany, entcatTransportistas.IdCiudad, entcatTransportistas.sDescripcion, entcatTransportistas.sNombre, entcatTransportistas.RFC, entcatTransportistas.Direccion, entcatTransportistas.Colonia, entcatTransportistas.RazonSocial);
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
        ///   <name>catTransportistas_DATA.deletecatTransportistas</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTransportistas del sistema</summary>
        public ENTResponse deletecatTransportistas(ENTTransportista entcatTransportistas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catTransportistasDel", entcatTransportistas.idCompany, entcatTransportistas.idTransportista);
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
