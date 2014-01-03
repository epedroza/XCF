/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCiudad
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Ciudades de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTCiudad : ENTBase
   {

      // Definiciones
		private Int32	_idCiudad;        // Identificador único de Ciudad
      private Int32  _idEstado;        // Identificador único del Estado al que pertenece la Ciudad
      private Int32  _idPais;          // Identificador único del Pais al que pertenece el Estado al que pertenece la Ciudad
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre de la Ciudad
		private Int16	_tiActivo;			// Control de baja lógica de registro

		
		 //Constructor

		public ENTCiudad(){
			_idCiudad = 0;
         _idEstado = 0;
         _idPais = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCiudad.idCiudad</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Ciudad</summary>
		public Int32 idCiudad
		{
			get { return _idCiudad; }
			set { _idCiudad = value; }
		}

      ///<remarks>
      ///   <name>ENTCiudad.idEstado</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Estado al que pertenece la Ciudad</summary>
      public Int32 idEstado
      {
         get { return _idEstado; }
         set { _idEstado = value; }
      }

      ///<remarks>
      ///   <name>ENTCiudad.idPais</name>
      ///   <create>11-Noviembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Pais al que pertenece el Estado al que pertenece la Ciudad</summary>
      public Int32 idPais
      {
         get { return _idPais; }
         set { _idPais = value; }
      }
		
		///<remarks>
		///   <name>ENTCiudad.dtFechaCreacion</name>
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
		///   <name>ENTCiudad.sDescripcion</name>
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
		///   <name>ENTCiudad.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre de la Ciudad</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTCiudad.tiActivo</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
		public Int16 tiActivo
		{
			get { return _tiActivo; }
			set { _tiActivo = value; }
		}

   }

}
