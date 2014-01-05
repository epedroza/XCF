/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCompany
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Compañías de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTransfer.Entity.Object
{
   
   public class ENTCompany : ENTBase
   {

      // Definiciones
		private Int32	_idCompany;       // Identificador único de Company
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Company
		private Int16	_tiActivo;			// Control de baja lógica de registro

		
		 //Constructor

		public ENTCompany(){
			_idCompany = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCompany.idCompany</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Compañía</summary>
		public Int32 idCompany
		{
			get { return _idCompany; }
			set { _idCompany = value; }
		}
		
		///<remarks>
		///   <name>ENTCompany.dtFechaCreacion</name>
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
		///   <name>ENTCompany.sDescripcion</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna la descripción/notas del registro</summary>
		public String sDescripcion
		{
			get { return _sDescripcion; }
			set { _sDescripcion = value; }
		}

		///<remarks>
		///   <name>ENTCompany.sNombre</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre de la Compañía</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTCompany.tiActivo</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
		public Int16 tiActivo
		{
			get { return _tiActivo; }
			set { _tiActivo = value; }
		}

   }

}
