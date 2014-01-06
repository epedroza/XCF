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
      private Int32  _idCentroServicio;   // Identificador único de Centro de Servicio
      private Int32  _idCompany;          // Identificador único de la Compañía dueña del registro
      private Int32  _idCiudad;           // Identificador de idCiudad
      private String _dtFechaCreacion;    // Fecha de creación del registro
      private Int32  _iTerminal;          // Valor de iTerminal
      private String _sCD;                // Valor de CD
      private String _sDescripcion;       // Descripción/notas del registro
      private String _sDireccion;         // Dirección
      private String _sNombre;            // Nombre del Centro de Servicio
      private String _sRFC;               // Valor de RFC
      private String _sProExterno;        // Valor de ProExterno
      private Int16  _tiActivo;           // Control de baja lógica de registro
        
		
      //Constructor

      public ENTCentroServicio(){
         _idCentroServicio = 0;
         _idCompany        = 0;
         _idCiudad         = 0;
         _dtFechaCreacion  = "";
         _iTerminal        = 0;
         _sCD              = "";
         _sDescripcion     = "";
         _sDireccion       = "";
         _sNombre          = "";
         _sRFC             = "";
         _sProExterno      = "";
         _tiActivo         = 0;
      }


      // Propiedades

      ///<remarks>
      ///   <name>ENTCompany.idCentroServicio</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Centro de Servicio</summary>
      public Int32 idCentroServicio
      {
         get { return _idCentroServicio; }
         set { _idCentroServicio = value; }
      }

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
      ///   <name>ENTCompany.idCiudad</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la Ciudad</summary>
      public Int32 idCiudad
      {
         get { return _idCiudad; }
         set { _idCiudad = value; }
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
      ///   <name>ENTCompany.iTerminal</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de la Terminal</summary>
      public Int32 iTerminal
      {
         get { return _iTerminal; }
         set { _iTerminal = value; }
      }

      ///<remarks>
      ///   <name>ENTCompany.sCD</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor de CD</summary>
      public String sCD
      {
         get { return _sCD; }
         set { _sCD = value; }
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
      ///   <name>ENTCompany.sDireccion</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna la dirección</summary>
      public String sDireccion
      {
         get { return _sDireccion; }
         set { _sDireccion = value; }
      }

      ///<remarks>
      ///   <name>ENTCompany.sNombre</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el nombre del Centro de Servicio</summary>
      public String sNombre
      {
         get { return _sNombre; }
         set { _sNombre = value; }
      }

      ///<remarks>
      ///   <name>ENTCompany.sRFC</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor del RFC</summary>
      public String sRFC
      {
         get { return _sRFC; }
         set { _sRFC = value; }
      }

      ///<remarks>
      ///   <name>ENTCompany.sProExterno</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el valor del ProExterno</summary>
      public String sProExterno
      {
         get { return _sProExterno; }
         set { _sProExterno = value; }
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
