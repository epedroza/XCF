/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCliente
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Clientes de la aplicación
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

   public class ENTCliente : ENTBase
   {

      // Definiciones
		private Int32	   _idCliente;                // Identificador único de Cliente
      private Int32     _idCompany;                // Identificador único de la Compañía dueña del registro
      private Int32     _idSucursal;               // Identificador único de la Sucursal perteneciente al Cliente
      private Int32     _idTipoCliente;
      private Double    _dPorcientoImpuestos;
      private Double    _dPorcientoRetencion;      
		private String    _dtFechaCreacion;          // Fecha de creación del registro
      private Int32     _iClaveGTEDes;             
      private Int32     _iClaveVendedorOriginal;   
      private Int32     _iDiasCredito;
      private Int32     _iPreferencial;
      private Int32     _iTerminal;
      private String    _sDescripcion;		         // Descripción/notas del registro
      private String    _sFax;                     // 
      private String    _sMetodoPago;              // 
      private String    _sNombre;			         // Nombre del Cliente
      private String    _sTarifa;                  // 
		private Int16     _tiActivo;                 // Control de baja lógica de registro
      private DataTable _tblSucursal;              

        private int _IdBillTo; // Identificador de IdBillTo
        private int _IdShipTo; // Identificador de IdShipTo
        private int _FolioBillShip;
        private int _BillOrShip;

		
		 //Constructor

		public ENTCliente(){
			_idCliente = 0;
         _idCompany = 0;
         _idSucursal = 0;
         _idTipoCliente = 0;
         _dPorcientoImpuestos = 0;
         _dPorcientoRetencion = 0;
			_dtFechaCreacion = "";
         _iClaveGTEDes = 0;
         _iClaveVendedorOriginal = 0;
         _iDiasCredito = 0;
         _iPreferencial = 0;
         _iTerminal = 0;
			_sDescripcion = "";
         _sFax = "";
         _sMetodoPago = "";
			_sNombre = "";
         _sTarifa = "";
			_tiActivo = 0;

            _IdBillTo = 0;
            _IdShipTo = 0;
            _FolioBillShip = 0;
            _BillOrShip = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCliente.idCliente</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Cliente</summary>
		public Int32 idCliente
		{
			get { return _idCliente; }
			set { _idCliente = value; }
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
      ///   <name>ENTCliente.idSucursal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la Sucursal perteneciente al Cliente</summary>
      public Int32 idSucursal
      {
         get { return _idSucursal; }
         set { _idSucursal = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.idTipoCliente</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de Tipo de Cliente perteneciente al Cliente</summary>
      public Int32 idTipoCliente
      {
         get { return _idTipoCliente; }
         set { _idTipoCliente = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.dPorcientoImpuestos</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de Porciento de Impuestos</summary>
      public Double dPorcientoImpuestos
      {
         get { return _dPorcientoImpuestos; }
         set { _dPorcientoImpuestos = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.dPorcientoRetencion</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de Porciento de Retención</summary>
      public Double dPorcientoRetencion
      {
         get { return _dPorcientoRetencion; }
         set { _dPorcientoRetencion = value; }
      }
		
		///<remarks>
		///   <name>ENTCliente.dtFechaCreacion</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de creación del registro</summary>
		public String dtFechaCreacion
		{
			get { return _dtFechaCreacion; }
			set { _dtFechaCreacion = value; }
		}

      ///<remarks>
      ///   <name>ENTCliente.iClaveGTEDes</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de GTEDes</summary>
      public Int32 iClaveGTEDes
      {
         get { return _iClaveGTEDes; }
         set { _iClaveGTEDes = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.iClaveVendedorOriginal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de clave de vendedor original</summary>
      public Int32 iClaveVendedorOriginal
      {
         get { return _iClaveVendedorOriginal; }
         set { _iClaveVendedorOriginal = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.iDiasCredito</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de los dias de crédito</summary>
      public Int32 iDiasCredito
      {
         get { return _iDiasCredito; }
         set { _iDiasCredito = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.iPreferencial</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor que indica si el cliente es preferencial</summary>
      public Int32 iPreferencial
      {
         get { return _iPreferencial; }
         set { _iPreferencial = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.iTerminal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de la terminal</summary>
      public Int32 iTerminal
      {
         get { return _iTerminal; }
         set { _iTerminal = value; }
      }

		///<remarks>
		///   <name>ENTCliente.sDescripcion</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la descripción/notas del registro</summary>
		public String sDescripcion
		{
			get { return _sDescripcion; }
			set { _sDescripcion = value; }
		}

      ///<remarks>
      ///   <name>ENTCliente.sFax</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el fax del Cliente</summary>
      public String sFax
      {
         get { return _sFax; }
         set { _sFax = value; }
      }

      ///<remarks>
      ///   <name>ENTCliente.sMetodoPago</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el método de pago del Cliente</summary>
      public String sMetodoPago
      {
         get { return _sMetodoPago; }
         set { _sMetodoPago = value; }
      }

		///<remarks>
		///   <name>ENTCliente.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Cliente</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

      ///<remarks>
      ///   <name>ENTCliente.sTarifa</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la tarifa del Cliente</summary>
      public String sTarifa
      {
         get { return _sTarifa; }
         set { _sTarifa = value; }
      }

		///<remarks>
		///   <name>ENTCliente.tiActivo</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
		public Int16 tiActivo
		{
			get { return _tiActivo; }
			set { _tiActivo = value; }
		}

      ///<remarks>
      ///   <name>ENTCliente.tblSucursal</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el listado de sucursales del Cliente</summary>
      public DataTable tblSucursal
      {
         get { return _tblSucursal; }
         set { _tblSucursal = value; }
      }

        ///<remarks>
        ///   <name>catClientes_Ent.IdBillTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdBillTo</summary>
        public int IdBillTo
        {
            get { return _IdBillTo; }
            set { _IdBillTo = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdShipTo</summary>
        public int IdShipTo
        {
            get { return _IdShipTo; }
            set { _IdShipTo = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCompania</summary>
        public int FolioBillShip
        {
            get { return _FolioBillShip; }
            set { _FolioBillShip = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCompania</summary>
        public int BillOrShip
        {
            get { return _BillOrShip; }
            set { _BillOrShip = value; }
        }
   }

}
