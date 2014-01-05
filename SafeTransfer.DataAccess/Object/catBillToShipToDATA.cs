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
    public class catBillToShipToDATA
    {
        Database dbs;
        public catBillToShipToDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catBillToShipTo_DATA.searchcatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catBillToShipTo del sistema</summary>
        public ENTResponse searchcatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catBillToShipToSel", entcatBillToShipTo.FolioBillShip, entcatBillToShipTo.IdCliente);
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
        ///   <name>catBillToShipTo_DATA.insertcatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catBillToShipTo del sistema</summary>
        public ENTResponse insertcatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catBillToShipToIns", entcatBillToShipTo.FolioBillShip, entcatBillToShipTo.IdCliente, entcatBillToShipTo.NoFactura, entcatBillToShipTo.RFC, entcatBillToShipTo.Terminal, entcatBillToShipTo.CD, entcatBillToShipTo.Direccion, entcatBillToShipTo.IdCiudad, entcatBillToShipTo.BillORShip, entcatBillToShipTo.MensajeFactura, entcatBillToShipTo.MensajePro, entcatBillToShipTo.MensajePago);
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
        ///   <name>catBillToShipTo_DATA.updatecatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catBillToShipTo del sistema</summary>
        public ENTResponse updatecatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catBillToShipToUpd", entcatBillToShipTo.FolioBillShip, entcatBillToShipTo.IdCliente, entcatBillToShipTo.NoFactura, entcatBillToShipTo.RFC, entcatBillToShipTo.Terminal, entcatBillToShipTo.CD, entcatBillToShipTo.Direccion, entcatBillToShipTo.IdCiudad, entcatBillToShipTo.BillORShip, entcatBillToShipTo.MensajeFactura, entcatBillToShipTo.MensajePro, entcatBillToShipTo.MensajePago);
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
        ///   <name>catBillToShipTo_DATA.deletecatBillToShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catBillToShipTo del sistema</summary>
        public ENTResponse deletecatBillToShipTo(ENTBillToShip entcatBillToShipTo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catBillToShipToDel", entcatBillToShipTo.FolioBillShip, entcatBillToShipTo.IdCliente);
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
        ///   <name>catBillToShipTo_DATA.searchcatBillTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catBillToShipTo del sistema</summary>
        public ENTResponse searchcatBillToShipTocbo(ENTBillToShip entcatBillToShipTo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catBillToShipToSel", entcatBillToShipTo.BillORShip); // 1 = BillTo , 2 = ShipTo
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
