/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTPickUp
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la tabla de PickUps de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Data;

namespace SafeTransfer.Entity.Object
{

   public class ENTPickUp : ENTBase
   {

        // Definiciones
        private Int32	_idPickUp;			      // Identificador único de PickUp
        private Int32  _idCentroServicio;      // Identificador único del Centro de Servicio en donde se registró la transacción
        private Int32  _idCiudad;              // Identificador único de la Ciudad donde se encuentra el Cliente/Prospecto
        private Int32  _idCompany;             // Identificador único de la Compañía dueña del registro
        private Int32  _idSucursal;            // Identificador único de la Sucursal del Cliente (en caso de que exista)
        private Int32  _idEstatusPickUp;       // Identificador único del estatus del PickUp
		private String	_dtFechaCreacion;	      // Fecha de creación del registro
        private String _dtPickUp;	            // Fecha de agenda del PickUp
        private String _sCliente;			      // Cliente del PickUp
        private String _sCodigoPostal;         // Código Postal del cliente que solicita un PickUp
        private String _sDireccion;		      // Dirección del cliente/prospecto
        private String _sObservaciones;		   // Observaciones del PickUp
        private String _sSucursal;			      // Sucursal del Cliente del PickUp
        private Int16  _tiLlamarParaConfirmar; // Indica con un 1 si es necesario llamar para confirmar la hora para el levantamiento del PickUp (la hora del campo dtPickUp no es importante) o un 0 de lo contrario.
        private String _tmCierreMuelle;        // Hora de cierre diario del muelle/bodega
        private String _tmVentanaFinal;        // Fin de la ventana de tiempo de recolección
        private String _tmVentanaInicio;       // Inicio de la ventana de tiempo de recolección
        private DataTable _tblContactos;       // Almacena el listado de contactos registrados en el PickUp
        private DataTable _tblCarga;           // Almacena el listado de articulos a recolectar
        private DataTable _tblCargaServicio;   // Almacena el listado de servicios por pieza a recolectar

        private DateTime _FechaEstimada;      // fecha estimada de recoleccion
        private DateTime _FechaRecoleccion;   // Fecha real de recoleccion   
        private int _Estatus;

       // Programación
        private Int16 _EsTransportePropio;
        private string _Proveedor;

		 //Constructor

		public ENTPickUp(){
            _idPickUp = 0;
            _idCentroServicio = 0;
            _idCiudad = 0;
            _idCompany = 0;
            _idSucursal = 0;
            _idEstatusPickUp = 0;
            _dtFechaCreacion = "";
            _dtPickUp = "";
            _sCliente = "";
            _sCodigoPostal = "";
            _sDireccion = "";
            _sObservaciones = "";
            _sSucursal = "";
            _tiLlamarParaConfirmar = 0;
            _tmCierreMuelle = "";
            _tmVentanaFinal = "";
            _tmVentanaInicio = "";
            _tblContactos = null;
            _tblCarga = null;
            _tblCargaServicio = null;

            _EsTransportePropio = 0;
            _Proveedor = string.Empty;
            _FechaEstimada = System.DateTime.Now;
            _FechaRecoleccion = System.DateTime.Now;
            _Estatus = 0;
		}

      // Propiedades

		///<remarks>
		///   <name>ENTPickUp.idPickUp</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de PickUp</summary>
		public Int32 idPickUp
		{
			get { return _idPickUp; }
			set { _idPickUp = value; }
		}

      ///<remarks>
      ///   <name>ENTRol.idCentroServicio</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Centro de Servicio en donde se registró la transacción</summary>
      public Int32 idCentroServicio
      {
         get { return _idCentroServicio; }
         set { _idCentroServicio = value; }
      }

      ///<remarks>
      ///   <name>ENTRol.idCiudad</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la Ciudad donde se encuentra el Cliente/Prospecto</summary>
      public Int32 idCiudad
      {
         get { return _idCiudad; }
         set { _idCiudad = value; }
      }

      ///<remarks>
      ///   <name>ENTRol.idCompany</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la Compañía dueña del registro</summary>
      public Int32 idCompany
      {
         get { return _idCompany; }
         set { _idCompany = value; }
      }

      ///<remarks>
      ///   <name>ENTRol.idSucursal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la Sucursal del Cliente (en caso de que exista)</summary>
      public Int32 idSucursal
      {
         get { return _idSucursal; }
         set { _idSucursal = value; }
      }

      ///<remarks>
      ///   <name>ENTRol.idEstatusPickUp</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del estatus del PickUp</summary>
      public Int32 idEstatusPickUp
      {
         get { return _idEstatusPickUp; }
         set { _idEstatusPickUp = value; }
      }
		
		///<remarks>
		///   <name>ENTPickUp.dtFechaCreacion</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de creación del registro</summary>
		public String dtFechaCreacion
		{
			get { return _dtFechaCreacion; }
			set { _dtFechaCreacion = value; }
		}

      ///<remarks>
      ///   <name>ENTPickUp.dtPickUp</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la fecha de agenda del PickUp</summary>
      public String dtPickUp
      {
         get { return _dtPickUp; }
         set { _dtPickUp = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.sCliente</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el Cliente del PickUp</summary>
      public String sCliente
      {
         get { return _sCliente; }
         set { _sCliente = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.sCodigoPostal</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el Código Postal del cliente que solicita un PickUp</summary>
      public String sCodigoPostal
      {
         get { return _sCodigoPostal; }
         set { _sCodigoPostal = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.sDireccion</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la dirección del cliente/prospecto</summary>
      public String sDireccion
      {
         get { return _sDireccion; }
         set { _sDireccion = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.sObservaciones</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna las observaciones del PickUp</summary>
      public String sObservaciones
      {
         get { return _sObservaciones; }
         set { _sObservaciones = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.sSucursal</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la Sucursal del Cliente del PickUp</summary>
      public String sSucursal
      {
         get { return _sSucursal; }
         set { _sSucursal = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tiLlamarParaConfirmar</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna un valor que indica con un 1 si es necesario llamar para confirmar la hora para el levantamiento del PickUp (la hora del campo dtPickUp no es importante) o un 0 de lo contrario.</summary>
      public Int16 tiLlamarParaConfirmar
      {
         get { return _tiLlamarParaConfirmar; }
         set { _tiLlamarParaConfirmar = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tmCierreMuelle</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la hora de cierre diario del muelle/bodega</summary>
      public String tmCierreMuelle
      {
         get { return _tmCierreMuelle; }
         set { _tmCierreMuelle = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tmVentanaFinal</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el Fin de la ventana de tiempo de recolección</summary>
      public String tmVentanaFinal
      {
         get { return _tmVentanaFinal; }
         set { _tmVentanaFinal = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tmVentanaInicio</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el Inicio de la ventana de tiempo de recolección</summary>
      public String tmVentanaInicio
      {
         get { return _tmVentanaInicio; }
         set { _tmVentanaInicio = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tblContactos</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de contactos registrados en el PickUp</summary>
      public DataTable tblContactos
      {
         get { return _tblContactos; }
         set { _tblContactos = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tblCarga</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de artículos a recolectar</summary>
      public DataTable tblCarga
      {
         get { return _tblCarga; }
         set { _tblCarga = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tblCargaServicio</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el listado de servicios por pieza a recolectar</summary>
      public DataTable tblCargaServicio
      {
          get { return _tblCargaServicio; }
          set { _tblCargaServicio = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tblCarga</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de artículos a recolectar</summary>
      public DateTime FechaEstimada
      {
          get { return _FechaEstimada; }
          set { _FechaEstimada = value; }
      }

      ///<remarks>
      ///   <name>ENTPickUp.tblCarga</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de artículos a recolectar</summary>
      public DateTime FechaRecoleccion
      {
          get { return _FechaRecoleccion; }
          set { _FechaRecoleccion = value; }
      }
      ///<remarks>
      ///   <name>ENTPickUp.tblCarga</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de artículos a recolectar</summary>
      public int Estatus
      {
          get { return _Estatus; }
          set { _Estatus = value; }
      }

      /// <summary>
      ///      Nombre del proveedor.
      /// </summary>
      public Int16 EsTransportePropio
      {
          get { return _EsTransportePropio; }
          set { _EsTransportePropio = value; }
      }

       /// <summary>
       ///      Nombre del proveedor.
       /// </summary>
      public String Proveedor
      {
          get { return _Proveedor; }
          set { _Proveedor = value; }
      }
   }

}
