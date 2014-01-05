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

namespace SafeTransfer.Entity.Object
{

   public class ENTCliente : ENTBase
   {

      // Definiciones
		private Int32	_idCliente;       // Identificador único de Cliente
      private Int32  _idCompany;       // Identificador único de la Compañía dueña del registro
      private Int32  _idSucursal;      // Identificador único de la Sucursal perteneciente al Cliente
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Cliente
		private Int16	_tiActivo;			// Control de baja lógica de registro

        private int _IdBillTo; // Identificador de IdBillTo
        private int _IdShipTo; // Identificador de IdShipTo
        private int _FolioBillShip;
        private int _BillOrShip;

		
		 //Constructor

		public ENTCliente(){
			_idCliente = 0;
         _idCompany = 0;
         _idSucursal = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
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
      ///   <name>ENTRol.idSucursal</name>
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
