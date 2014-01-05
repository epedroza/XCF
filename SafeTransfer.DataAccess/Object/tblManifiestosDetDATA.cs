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
    public class tblManifiestosDetDATA : DABase
    {
        Database dbs;
        public tblManifiestosDetDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_DATA.searchtblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblManifiestosDet del sistema</summary>
        public ENTResponse searchtblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblManifiestosDetSel", enttblManifiestosDet.IdManifiesto);
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
        ///   <name>tblManifiestosDet_DATA.inserttblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblManifiestosDet del sistema</summary>
        public ENTResponse inserttblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblManifiestosDetIns", enttblManifiestosDet.IdManifiesto);
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
        ///   <name>tblManifiestosDet_DATA.updatetblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblManifiestosDet del sistema</summary>
        public ENTResponse updatetblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblManifiestosDetUpd", enttblManifiestosDet.IdManifiesto);
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
        ///   <name>tblManifiestosDet_DATA.deletetblManifiestosDet</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblManifiestosDet del sistema</summary>
        public ENTResponse deletetblManifiestosDet(SafeTransfer.Entity.tblManifiestosDet_Ent enttblManifiestosDet)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblManifiestosDetDel", enttblManifiestosDet.IdManifiesto);
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
