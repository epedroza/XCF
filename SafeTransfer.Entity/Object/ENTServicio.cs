/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTServicio
' Autor: Ruben.Cobos
' Fecha: 08-Diciembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Servicios de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTServicio : ENTBase
   {

      // Definiciones
		private Int32	_idServicio;		// Identificador único de Servicio
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Servicio
		private Int16	_tiActivo;			// Control de baja lógica de registro

		
		 //Constructor

		public ENTServicio(){
			_idServicio = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTServicio.idServicio</name>
		///   <create>08-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Servicio</summary>
		public Int32 idServicio
		{
			get { return _idServicio; }
			set { _idServicio = value; }
		}
		
		///<remarks>
		///   <name>ENTServicio.dtFechaCreacion</name>
		///   <create>08-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de creación del registro</summary>
		public String dtFechaCreacion
		{
			get { return _dtFechaCreacion; }
			set { _dtFechaCreacion = value; }
		}

		///<remarks>
		///   <name>ENTServicio.sDescripcion</name>
		///   <create>08-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la descripción/notas del registro</summary>
		public String sDescripcion
		{
			get { return _sDescripcion; }
			set { _sDescripcion = value; }
		}

		///<remarks>
		///   <name>ENTServicio.sNombre</name>
		///   <create>08-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Servicio</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTServicio.tiActivo</name>
		///   <create>08-Diciembre-2013</create>
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
