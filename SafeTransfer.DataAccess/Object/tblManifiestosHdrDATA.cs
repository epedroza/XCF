using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.DataAccess.Object
{
    public class tblManifiestosHdrDATA : DABase
    {
        Database dbs;
        public tblManifiestosHdrDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_DATA.searchtblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosHdr del sistema</summary>
        public ENTResponse searchtblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblManifiestosHdrSel", enttblManifiestosHdr.IdManifiesto);
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
        ///   <name>tblManifiestosHdr_DATA.inserttblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblManifiestosHdr del sistema</summary>
        public ENTResponse inserttblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblManifiestosHdrIns", enttblManifiestosHdr.IdManifiesto);
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
        ///   <name>tblManifiestosHdr_DATA.updatetblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblManifiestosHdr del sistema</summary>
        public ENTResponse updatetblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblManifiestosHdrUpd", enttblManifiestosHdr.IdManifiesto);
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
        ///   <name>tblManifiestosHdr_DATA.deletetblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblManifiestosHdr del sistema</summary>
        public ENTResponse deletetblManifiestosHdr(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblManifiestosHdrDel", enttblManifiestosHdr.IdManifiesto);
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
        ///   <name>tblManifiestosHdr_DATA.searchtblManifiestosHdr</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosHdr del sistema</summary>
        public ENTResponse searchtblManifiestosHdrMonitor(SafeTransfer.Entity.tblManifiestosHdr_Ent enttblManifiestosHdr)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblManifiestosHdrSelMonitor", enttblManifiestosHdr.IdManifiesto, enttblManifiestosHdr.ClaveOrigen, enttblManifiestosHdr.ClaveDestino, enttblManifiestosHdr.NoTractor, enttblManifiestosHdr.TractorPropio, enttblManifiestosHdr.Estatus);
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
