/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTBillToShip
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela la tabla de BillToShip de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTBillToShip : ENTBase
   {

        // Definiciones
		private Int32	_idBillToShip;		// Identificador único de BillToShip
        private Int32 _idCompany;        // Identificador único de la Compañía dueña del registro
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del BillToShip
		private Int16	_tiActivo;			// Control de baja lógica de registro

        private int _FolioBillShip; // Valor de FolioBillShip
        private int _IdCliente; // Identificador de IdCliente
        private int _NoFactura; // Valor de NoFactura
        private string _RFC; // Valor de RFC
        private int _Terminal; // Valor de Terminal
        private string _CD; // Valor de CD
        private string _Direccion; // Valor de Direccion
        private int _IdCiudad; // Identificador de IdCiudad
        private int _BillORShip; // Valor de BillORShip
        private string _MensajeFactura; // Valor de MensajeFactura
        private string _MensajePro; // Valor de MensajePro
        private string _MensajePago; // Valor de MensajePago
		
		 //Constructor

		public ENTBillToShip(){
			_idBillToShip = 0;
            _idCompany = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;

            _FolioBillShip = 0;
            _IdCliente = 0;
            _NoFactura = 0;
            _RFC = "";
            _Terminal = 0;
            _CD = "";
            _Direccion = "";
            _IdCiudad = 0;
            _BillORShip = 0;
            _MensajeFactura = "";
            _MensajePro = "";
            _MensajePago = "";
		}


      // Propiedades

		///<remarks>
		///   <name>ENTBillToShip.idBillToShip</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de BillToShip</summary>
		public Int32 idBillToShip
		{
			get { return _idBillToShip; }
			set { _idBillToShip = value; }
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
		///   <name>ENTBillToShip.dtFechaCreacion</name>
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
		///   <name>ENTBillToShip.sDescripcion</name>
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
		///   <name>ENTBillToShip.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del BillToShip</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTBillToShip.tiActivo</name>
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
        ///   <name>catBillToShipTo_Ent.FolioBillShip</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FolioBillShip</summary>
        public int FolioBillShip
        {
            get { return _FolioBillShip; }
            set { _FolioBillShip = value; }
        }

        ///<remarks>
        ///   <name>catBillToShipTo_Ent.IdCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCliente</summary>
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.NoFactura</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoFactura</summary>
        public int NoFactura
        {
            get { return _NoFactura; }
            set { _NoFactura = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.RFC</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna RFC</summary>
        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.Terminal</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Terminal</summary>
        public int Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.CD</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CD</summary>
        public string CD
        {
            get { return _CD; }
            set { _CD = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.Direccion</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Direccion</summary>
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.IdCiudad</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCiudad</summary>
        public int IdCiudad
        {
            get { return _IdCiudad; }
            set { _IdCiudad = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.BillORShip</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna BillORShip</summary>
        public int BillORShip
        {
            get { return _BillORShip; }
            set { _BillORShip = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.MensajeFactura</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna MensajeFactura</summary>
        public string MensajeFactura
        {
            get { return _MensajeFactura; }
            set { _MensajeFactura = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.MensajePro</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna MensajePro</summary>
        public string MensajePro
        {
            get { return _MensajePro; }
            set { _MensajePro = value; }
        }
        ///<remarks>
        ///   <name>catBillToShipTo_Ent.MensajePago</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna MensajePago</summary>
        public string MensajePago
        {
            get { return _MensajePago; }
            set { _MensajePago = value; }
        }

   }

}
