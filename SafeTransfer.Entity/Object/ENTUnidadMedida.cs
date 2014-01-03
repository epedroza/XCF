/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTUnidadMedida
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Unidades de Medida de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTUnidadMedida : ENTBase
   {

      // Definiciones
      private Int32  _idUnidadMedida;  // Identificador único de Unidad de Medida
      private Int32  _idMagnitudFisica;// Identificador único de Magnitud Física
      private String _dtFechaCreacion;	// Fecha de creación del registro
      private String _sDescripcion;		// Descripción/notas del registro
      private String _sNombre;			// Nombre de la Unidad de Medida
      private String _sSimbolo;			// Símbolo de la Unidad de Medida
      private Int16  _tiActivo;			// Control de baja lógica de registro


      //Constructor

      public ENTUnidadMedida()
      {
         _idUnidadMedida = 0;
         _idMagnitudFisica = 0;
         _dtFechaCreacion = "";
         _sDescripcion = "";
         _sNombre = "";
         _sSimbolo = "";
         _tiActivo = 0;
      }


      // Propiedades

      ///<remarks>
      ///   <name>ENTUnidadMedida.idUnidadMedida</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de Unidad de Medida</summary>
      public Int32 idUnidadMedida
      {
         get { return _idUnidadMedida; }
         set { _idUnidadMedida = value; }
      }

      ///<remarks>
      ///   <name>ENTUnidadMedida.idMagnitudFisica</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de Magnitud Física</summary>
      public Int32 idMagnitudFisica
      {
         get { return _idMagnitudFisica; }
         set { _idMagnitudFisica = value; }
      }

      ///<remarks>
      ///   <name>ENTUnidadMedida.dtFechaCreacion</name>
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
      ///   <name>ENTUnidadMedida.sDescripcion</name>
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
      ///   <name>ENTUnidadMedida.sNombre</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el nombre de la Unidad de Medida</summary>
      public String sNombre
      {
         get { return _sNombre; }
         set { _sNombre = value; }
      }

      ///<remarks>
      ///   <name>ENTUnidadMedida.sSimbolo</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el símbolo de la Unidad de Medida</summary>
      public String sSimbolo
      {
         get { return _sSimbolo; }
         set { _sSimbolo = value; }
      }

      ///<remarks>
      ///   <name>ENTUnidadMedida.tiActivo</name>
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
