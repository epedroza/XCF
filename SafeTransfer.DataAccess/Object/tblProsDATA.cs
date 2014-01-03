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
    public class tblProsDATA : DABase
    {
        Database dbs;
        public tblProsDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>tblPros_DATA.searchtblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblPros del sistema</summary>
        public ENTResponse searchtblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblProsSel", enttblPros.IdPro);
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
        ///   <name>tblPros_DATA.inserttblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar tblPros del sistema</summary>
        public ENTResponse inserttblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblProsIns", enttblPros.IdPro, enttblPros.IdPickUp, enttblPros.ClaveTerminal, enttblPros.FechaCaptura, enttblPros.FechaCargado, enttblPros.NoFacturacion, enttblPros.IdClaveOrigen, enttblPros.IdClaveDestino, enttblPros.IdClaveClienteFiscal, enttblPros.IdClaveAgenteAduanal, enttblPros.IdClaveCobrarA, enttblPros.IdCondicionesPago, enttblPros.IdVendedorOrigen, enttblPros.IdVendedorDestino, enttblPros.TermFact, enttblPros.Patente, enttblPros.Pedimento, enttblPros.Ocurre, enttblPros.PesoTotalKg, enttblPros.PiezasTotal, enttblPros.ValorMercancia, enttblPros.IdMoneda, enttblPros.TCambio, enttblPros.TotalCargos, enttblPros.NoDescuentos, enttblPros.Descuentos, enttblPros.SubToral, enttblPros.PorcIVA, enttblPros.IVA, enttblPros.PorcRetencion, enttblPros.Retencion, enttblPros.Total);
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
        ///   <name>tblPros_DATA.updatetblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza tblPros del sistema</summary>
        public ENTResponse updatetblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblProsUpd", enttblPros.IdPro, enttblPros.IdPickUp, enttblPros.ClaveTerminal, enttblPros.FechaCaptura, enttblPros.FechaCargado, enttblPros.NoFacturacion, enttblPros.IdClaveOrigen, enttblPros.IdClaveDestino, enttblPros.IdClaveClienteFiscal, enttblPros.IdClaveAgenteAduanal, enttblPros.IdClaveCobrarA, enttblPros.IdCondicionesPago, enttblPros.IdVendedorOrigen, enttblPros.IdVendedorDestino, enttblPros.TermFact, enttblPros.Patente, enttblPros.Pedimento, enttblPros.Ocurre, enttblPros.PesoTotalKg, enttblPros.PiezasTotal, enttblPros.ValorMercancia,/* enttblPros.BL, enttblPros.PE,*/ enttblPros.IdMoneda, enttblPros.TCambio, enttblPros.TotalCargos, enttblPros.NoDescuentos, enttblPros.Descuentos, enttblPros.SubToral, enttblPros.PorcIVA, enttblPros.IVA, enttblPros.PorcRetencion, enttblPros.Retencion, enttblPros.Total);
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
        ///   <name>tblPros_DATA.deletetblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de tblPros del sistema</summary>
        public ENTResponse deletetblPros(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("tblProsDel", enttblPros.IdPro);
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
        ///   <name>tblPros_DATA.searchtblPros</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las tblPros del sistema</summary>
        public ENTResponse searchtblProsMonitor(SafeTransfer.Entity.tblPros_Ent enttblPros)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("tblProsSelMonitor", enttblPros.IdPro, enttblPros.IdPickUp, enttblPros.IdClaveOrigen, enttblPros.IdClaveDestino, enttblPros.FechaCargoInicial, enttblPros.FechaCargoFinal, enttblPros.Pedimento, enttblPros.Estatus);
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
