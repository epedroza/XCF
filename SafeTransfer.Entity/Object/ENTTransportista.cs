/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTTransportista
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Transportistas de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTTransportista : ENTBase
   {

      // Definiciones
		private Int32	_idTransportista; // Identificador único de Transportista
      private Int32 _idCompany;        // Identificador único de la Compañía dueña del registro
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Transportista
		private Int16	_tiActivo;			// Control de baja lógica de registro

        private int _IdPais; // Identificador de IdPais
        private int _IdEstado; // Identificador de IdEstado
        private int _IdCiudad; // Identificador de IdCiudad
        private string _RFC; // Valor de RFC
        private string _Direccion; // Valor de Direccion
        private string _Colonia; // Valor de Colonia
        private string _RazonSocial; // Valor de RazonSocial
		
		 //Constructor

		public ENTTransportista(){
			_idTransportista = 0;
         _idCompany = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;

            _IdPais = 0;
            _IdEstado = 0;
            _IdCiudad = 0;
            _RFC = "";
            _Direccion = "";
            _Colonia = "";
            _RazonSocial = "";
		}


      // Propiedades

		///<remarks>
		///   <name>ENTTransportista.idTransportista</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Transportista</summary>
		public Int32 idTransportista
      {
         get { return _idTransportista; }
         set { _idTransportista = value; }
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
		///   <name>ENTTransportista.dtFechaCreacion</name>
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
		///   <name>ENTTransportista.sDescripcion</name>
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
		///   <name>ENTTransportista.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Transportista</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTTransportista.tiActivo</name>
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
        ///   <name>catTransportistas_Ent.IdPais</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdPais</summary>
        public int IdPais
        {
            get { return _IdPais; }
            set { _IdPais = value; }
        }

        ///<remarks>
        ///   <name>catTransportistas_Ent.IdEstado</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdEstado</summary>
        public int IdEstado
        {
            get { return _IdEstado; }
            set { _IdEstado = value; }
        }
        ///<remarks>
        ///   <name>catTransportistas_Ent.IdCiudad</name>
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
        ///   <name>catTransportistas_Ent.RFC</name>
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
        ///   <name>catTransportistas_Ent.Direccion</name>
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
        ///   <name>catTransportistas_Ent.Colonia</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Colonia</summary>
        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }
        ///<remarks>
        ///   <name>catTransportistas_Ent.RazonSocial</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna RazonSocial</summary>
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }
   }

}
