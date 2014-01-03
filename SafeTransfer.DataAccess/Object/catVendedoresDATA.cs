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
    public class catVendedoresDATA
    {
        Database dbs;
        public catVendedoresDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catVendedores_DATA.searchcatVendedores</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catVendedores del sistema</summary>
        public ENTResponse searchcatVendedores(ENTVendedor entcatVendedores)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catVendedoresSel", entcatVendedores.idCompany, entcatVendedores.idVendedor, entcatVendedores.sNombre, entcatVendedores.sApellidoPaterno, entcatVendedores.sApellidoMaterno);
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
        ///   <name>catVendedores_DATA.insertcatVendedores</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catVendedores del sistema</summary>
        public ENTResponse insertcatVendedores(ENTVendedor entcatVendedores)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catVendedoresIns", entcatVendedores.idCompany, entcatVendedores.sDescripcion, entcatVendedores.sNombre, entcatVendedores.sApellidoPaterno, entcatVendedores.sApellidoMaterno, entcatVendedores.sDireccion, entcatVendedores.idCiudad, entcatVendedores.sCP, entcatVendedores.sTelefono1, entcatVendedores.sTelefono2, entcatVendedores.sCorreo);
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
        ///   <name>catVendedores_DATA.updatecatVendedores</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catVendedores del sistema</summary>
        public ENTResponse updatecatVendedores(ENTVendedor entcatVendedores)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catVendedoresUpd", entcatVendedores.idVendedor, entcatVendedores.idCompany, entcatVendedores.sDescripcion, entcatVendedores.sNombre, entcatVendedores.sApellidoPaterno, entcatVendedores.sApellidoMaterno, entcatVendedores.sDireccion, entcatVendedores.idCiudad, entcatVendedores.sCP, entcatVendedores.sTelefono1, entcatVendedores.sTelefono2, entcatVendedores.sCorreo);
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
        ///   <name>catVendedores_DATA.deletecatVendedores</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catVendedores del sistema</summary>
        public ENTResponse deletecatVendedores(ENTVendedor entcatVendedores)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catVendedoresDel", entcatVendedores.idCompany, entcatVendedores.idVendedor);
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
        ///   <name>catVendedores_DATA.searchcatVendedorescbo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catVendedores del sistema</summary>
        public ENTResponse searchcatVendedorescbo(ENTVendedor entcatVendedores)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catVendedoresSelcbo", entcatVendedores.idCompany);
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
