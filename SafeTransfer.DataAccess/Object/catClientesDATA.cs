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
    public class catClientesDATA
    {
        Database dbs;
        public catClientesDATA()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>catClientes_DATA.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catClientesSel", entcatClientes.IdCompania, entcatClientes.IdCliente, entcatClientes.Nombre);
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
        ///   <name>catClientes_DATA.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientesBILLSHIP(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catClientesBillToShipToSel", entcatClientes.IdCompania, entcatClientes.IdCliente, entcatClientes.FolioBillShip, entcatClientes.BillOrShip);
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
        ///   <name>catClientes_DATA.searchcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catClientes del sistema</summary>
        public ENTResponse searchcatClientescbo(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catClientesSelcbo", entcatClientes.IdCompania);
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
        ///   <name>catClientes_DATA.insertcatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catClientes del sistema</summary>
        public ENTResponse insertcatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catClientesIns", entcatClientes.IdCompania, entcatClientes.IdTipoCliente, entcatClientes.Nombre, entcatClientes.Direccion1, entcatClientes.Direccion2, entcatClientes.Terminal, entcatClientes.IdPais, entcatClientes.IdEstado, entcatClientes.IdCiudad, entcatClientes.CP, entcatClientes.Contacto1, entcatClientes.Correo1, entcatClientes.Telefono1, entcatClientes.Contacto2, entcatClientes.Correo2, entcatClientes.Telefono2, entcatClientes.Fax, entcatClientes.IdMoneda, entcatClientes.IdMetodoPago, entcatClientes.Tarifa, entcatClientes.DiasCredito, entcatClientes.PorcientoIVA, entcatClientes.Preferencial, entcatClientes.ClaveVendedorOriginal, entcatClientes.ClaveGTEDes, entcatClientes.IdBillTo, entcatClientes.IdShipTo);
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
        ///   <name>catClientes_DATA.updatecatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catClientes del sistema</summary>
        public ENTResponse updatecatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catClientesUpd", entcatClientes.IdCompania, entcatClientes.IdCliente, entcatClientes.IdTipoCliente, entcatClientes.Nombre, entcatClientes.Direccion1, entcatClientes.Direccion2, entcatClientes.Terminal, entcatClientes.IdPais, entcatClientes.IdEstado, entcatClientes.IdCiudad, entcatClientes.CP, entcatClientes.Contacto1, entcatClientes.Correo1, entcatClientes.Telefono1, entcatClientes.Contacto2, entcatClientes.Correo2, entcatClientes.Telefono2, entcatClientes.Fax, entcatClientes.IdMoneda, entcatClientes.IdMetodoPago, entcatClientes.Tarifa, entcatClientes.DiasCredito, entcatClientes.PorcientoIVA, entcatClientes.Preferencial, entcatClientes.ClaveVendedorOriginal, entcatClientes.ClaveGTEDes, entcatClientes.IdBillTo, entcatClientes.IdShipTo);
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
        ///   <name>catClientes_DATA.deletecatClientes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catClientes del sistema</summary>
        public ENTResponse deletecatClientes(SafeTransfer.Entity.catClientes_Ent entcatClientes)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catClientesDel", entcatClientes.IdCompania, entcatClientes.IdCliente);
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
