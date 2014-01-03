/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCentroServicio
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Centros de Servicio de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTCentroServicio : ENTBase
   {

      // Definiciones
		private Int32	_idCentroServicio;   // Identificador único de Centro de Servicio
        private Int32  _idCompany;          // Identificador único de la Compañía dueña del registro
		private String	_dtFechaCreacion;	   // Fecha de creación del registro
		private String	_sDescripcion;		   // Descripción/notas del registro
		private String	_sNombre;			   // Nombre del Centro de Servicio
		private Int16	_tiActivo;			   // Control de baja lógica de registro

        private string _RFC; // Valor de RFC
        private int _Terminal; // Valor de Terminal
        private string _CD; // Valor de CD
        private string _Direccion; // Valor de Direccion
        private int _IdCiudad; // Identificador de IdCiudad
        private string _ProExterno; // Valor de ProExterno
		
		 //Constructor

		public ENTCentroServicio(){
			_idCentroServicio = 0;
         _idCompany = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;

            _RFC = "";
            _Terminal = 0;
            _CD = "";
            _Direccion = "";
            _IdCiudad = 0;
            _ProExterno = "";
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCentroServicio.idCentroServicio</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Centro de Servicio</summary>
		public Int32 idCentroServicio
		{
			get { return _idCentroServicio; }
			set { _idCentroServicio = value; }
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
		///   <name>ENTCentroServicio.dtFechaCreacion</name>
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
		///   <name>ENTCentroServicio.sDescripcion</name>
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
		///   <name>ENTCentroServicio.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Centro de Servicio</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTCentroServicio.tiActivo</name>
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
        ///   <name>catCentrosDeServicio_Ent.RFC</name>
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
        ///   <name>catCentrosDeServicio_Ent.Terminal</name>
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
        ///   <name>catCentrosDeServicio_Ent.CD</name>
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
        ///   <name>catCentrosDeServicio_Ent.Direccion</name>
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
        ///   <name>catCentrosDeServicio_Ent.IdCiudad</name>
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
        ///   <name>catCentrosDeServicio_Ent.ProExterno</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ProExterno</summary>
        public string ProExterno
        {
            get { return _ProExterno; }
            set { _ProExterno = value; }
        }
   }

}
