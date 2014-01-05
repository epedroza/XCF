/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAPickUp
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Menús
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;
using System.Data.SqlClient;
using SafeTransfer.Entity.Object;

namespace SafeTransfer.DataAccess.Object
{
	
	public class DAPickUp : DABase
	{
        ///<remarks>
        ///   <name>DAPickUp.InsertPickUp</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Crea un nuevo PickUp</summary>
        ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para crear un nuevo registro</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse InsertPickUp(ENTPickUp oENTPickUp, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("usptblPickUp_Ins", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idCentroServicio", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCentroServicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCiudad", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCiudad;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCompany;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idSucursal", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idSucursal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("dtPickUp", SqlDbType.DateTime);
            sqlPar.Value = oENTPickUp.dtPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCliente", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCliente;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCodigoPostal", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCodigoPostal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sDireccion", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sDireccion;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sObservaciones", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sObservaciones;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sSucursal", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sSucursal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tiLlamarParaConfirmar", SqlDbType.TinyInt);
            sqlPar.Value = oENTPickUp.tiLlamarParaConfirmar;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmCierreMuelle", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmCierreMuelle;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmVentanaFinal", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmVentanaFinal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmVentanaInicio", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmVentanaInicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpCarga", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblCarga;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpCargaServicio", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblCargaServicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpContacto", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblContactos;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        /// <summary>
        ///     Inserta un registro nuevo en la tabla relPickUpProgramacion para la programación de un PickUp.
        /// </summary>
        /// <param name="Connection">Conexión a la base de datos.</param>
        /// <param name="Transaction">Trnsacción del proceso actual.</param>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse InsertPickUpProgramacion(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            SqlCommand Command;
            SqlParameter Parameter;
            ENTResponse ResponseEntity = new ENTResponse();

            try
            {
                Command = new SqlCommand("relPickUpProgramacion_Ins", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Transaction = Transaction;

                Parameter = new SqlParameter("idPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EsTransportePropio", SqlDbType.TinyInt);
                Parameter.Value = PickUpEntity.EsTransportePropio;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Proveedor", SqlDbType.VarChar);
                Parameter.Value = PickUpEntity.Proveedor;
                Command.Parameters.Add(Parameter);

                Command.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                ResponseEntity.sMessage = Exception.Message;
            }

            return ResponseEntity;
        }

        ///<remarks>
        ///   <name>DAPickUp.SelectPickUp</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Obtiene un listado de PickUps en base a los parámetros proporcionados</summary>
        ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para consultar la información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectPickUp(ENTPickUp oENTPickUp, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("usptblPickUp_Sel", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idEstatusPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idEstatusPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCliente", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCliente;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAPickUp.SelectPickUp</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Obtiene un listado de PickUps en base a los parámetros proporcionados</summary>
        ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para consultar la información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectPickUpMonitor(ENTPickUp oENTPickUp, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("usptblPickUp_SelMonitor", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCompany;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCliente", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCliente;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("FechaEstimada", SqlDbType.DateTime);
            sqlPar.Value = oENTPickUp.FechaEstimada;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("FechaRecoleccion", SqlDbType.DateTime);
            sqlPar.Value = oENTPickUp.FechaRecoleccion;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("IdEstatusPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idEstatusPickUp;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        /// <summary>
        ///     Busca la información de la programación de un PickUp.
        /// </summary>
        /// <param name="PickUpEntity">Entidad de PickUp.</param>
        /// <param name="ConnectionString">String de conexión a la base de datos.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SelectPickUpProgramacion(ENTPickUp PickUpEntity, String ConnectionString)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("relPickUpProgramacion_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("idPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("idCompany", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idCompany;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);
                ResponseEntity.dsResponse = new DataSet();

                Connection.Open();
                DataAdapter.Fill(ResponseEntity.dsResponse);
                Connection.Close();

                return ResponseEntity;
            }
            catch (SqlException Exception)
            {
                ResponseEntity.sMessage = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                return ResponseEntity;
            }
        }

        /// <summary>
        ///     Busca la información de la programación de un PickUp.
        /// </summary>
        /// <param name="PickUpEntity">Entidad de PickUp.</param>
        /// <param name="ConnectionString">String de conexión a la base de datos.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse SelectPickUpProgramacion(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            ENTResponse ResponseEntity = new ENTResponse();
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("relPickUpProgramacion_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Transaction = Transaction;

                Parameter = new SqlParameter("idPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("idCompany", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idCompany;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);
                ResponseEntity.dsResponse = new DataSet();

                DataAdapter.Fill(ResponseEntity.dsResponse);

                return ResponseEntity;
            }
            catch (SqlException Exception)
            {
                ResponseEntity.sMessage = Exception.Message;

                return ResponseEntity;
            }
        }

        ///<remarks>
        ///   <name>DAPickUp.UpdatePickUp</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Actualiza la información de un PickUp</summary>
        ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para actualizar su información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdatePickUp(ENTPickUp oENTPickUp, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("usptblPickUp_Upd", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCentroServicio", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCentroServicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCiudad", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCiudad;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idCompany", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idCompany;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idSucursal", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idSucursal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("dtPickUp", SqlDbType.DateTime);
            sqlPar.Value = oENTPickUp.dtPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCliente", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCliente;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sCodigoPostal", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sCodigoPostal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sDireccion", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sDireccion;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sObservaciones", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sObservaciones;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("sSucursal", SqlDbType.VarChar);
            sqlPar.Value = oENTPickUp.sSucursal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tiLlamarParaConfirmar", SqlDbType.TinyInt);
            sqlPar.Value = oENTPickUp.tiLlamarParaConfirmar;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmCierreMuelle", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmCierreMuelle;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmVentanaFinal", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmVentanaFinal;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tmVentanaInicio", SqlDbType.Time);
            sqlPar.Value = oENTPickUp.tmVentanaInicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpCarga", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblCarga;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpCargaServicio", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblCargaServicio;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("tblPickUpContacto", SqlDbType.Structured);
            sqlPar.Value = oENTPickUp.tblContactos;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        /// <summary>
        ///     Actualiza la información de un PickUp para realizar su programación.
        /// </summary>
        /// <param name="Connection">Conexión a la base de datos.</param>
        /// <param name="Transaction">Trnsacción del proceso actual.</param>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse UpdatePickUp(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            SqlCommand Command;
            SqlParameter Parameter;
            ENTResponse ResponseEntity = new ENTResponse();

            try
            {
                Command = new SqlCommand("usptblPickUpProgramacion_Upd", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Transaction = Transaction;

                Parameter = new SqlParameter("idPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("idCompany", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idCompany;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("idEstatusPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idEstatusPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("dtPickUp", SqlDbType.DateTime);
                Parameter.Value = PickUpEntity.dtPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("sDireccion", SqlDbType.VarChar);
                Parameter.Value = PickUpEntity.sDireccion;
                Command.Parameters.Add(Parameter);

                Command.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                ResponseEntity.sMessage = Exception.Message;
            }

            return ResponseEntity;
        }

        ///<remarks>
        ///   <name>DAPickUp.UpdatePickUp_Estatus</name>
        ///   <create>21-Octubre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Cambia el Estatus de un PickUp</summary>
        ///<param name="oENTPickUp">Entidad de PickUp con los parámetros necesarios para crear el registro</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdatePickUp_Estatus(ENTPickUp oENTPickUp, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("usptblPickUp_Upd_Estatus", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idPickUp", SqlDbType.Int);
            sqlPar.Value = oENTPickUp.idPickUp;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idEstatusPickUp", SqlDbType.TinyInt);
            sqlPar.Value = oENTPickUp.idEstatusPickUp;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        /// <summary>
        ///     Actualiza la información de la programación de un PickUp.
        /// </summary>
        /// <param name="Connection">Conexión a la base de datos.</param>
        /// <param name="Transaction">Trnsacción del proceso actual.</param>
        /// <param name="PickUpEntity">Entidad del PickUp.</param>
        /// <returns>ENTResponse</returns>
        public ENTResponse UpdatePickUpProgramacion(SqlConnection Connection, SqlTransaction Transaction, ENTPickUp PickUpEntity)
        {
            SqlCommand Command;
            SqlParameter Parameter;
            ENTResponse ResponseEntity = new ENTResponse();

            try
            {
                Command = new SqlCommand("relPickUpProgramacion_Upd", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Transaction = Transaction;

                Parameter = new SqlParameter("idPickUp", SqlDbType.Int);
                Parameter.Value = PickUpEntity.idPickUp;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EsTransportePropio", SqlDbType.TinyInt);
                Parameter.Value = PickUpEntity.EsTransportePropio;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Proveedor", SqlDbType.VarChar);
                Parameter.Value = PickUpEntity.Proveedor;
                Command.Parameters.Add(Parameter);

                Command.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                ResponseEntity.sMessage = Exception.Message;
            }

            return ResponseEntity;
        }
	}
	
}
