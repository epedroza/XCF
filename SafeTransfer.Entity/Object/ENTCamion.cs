/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCamion
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Camiones de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTCamion : ENTBase
   {

      // Definiciones
		private Int32	_idCamion;        // Identificador único de Camion
        private Int32 _idCompany;        // Identificador único de la Compañía dueña del registro
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Camion
		private Int16	_tiActivo;			// Control de baja lógica de registro

        private int _IdTipoCamion; // Identificador de IdTipoCamion
        private decimal _CapacidadM3; // Valor de CapacidadM3
        private decimal _CapacidadKg; // Valor de CapacidadKg
		
		 //Constructor

		public ENTCamion(){
			_idCamion = 0;
         _idCompany = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;

            _IdTipoCamion = 0;
            _CapacidadM3 = 0;
            _CapacidadKg = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCamion.idCamion</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Camion</summary>
		public Int32 idCamion
		{
			get { return _idCamion; }
			set { _idCamion = value; }
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
      ///   <name>catCamiones_Ent.IdTipoCamion</name>
      ///   <create>24/oct/2013</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador de IdTipoCamion</summary>
      public int IdTipoCamion
      {
          get { return _IdTipoCamion; }
          set { _IdTipoCamion = value; }
      }
		
		///<remarks>
		///   <name>ENTCamion.dtFechaCreacion</name>
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
		///   <name>ENTCamion.sDescripcion</name>
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
		///   <name>ENTCamion.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Camion</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTCamion.tiActivo</name>
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
        ///   <name>catCamiones_Ent.CapacidadM3</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CapacidadM3</summary>
        public decimal CapacidadM3
        {
            get { return _CapacidadM3; }
            set { _CapacidadM3 = value; }
        }
        ///<remarks>
        ///   <name>catCamiones_Ent.CapacidadKg</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CapacidadKg</summary>
        public decimal CapacidadKg
        {
            get { return _CapacidadKg; }
            set { _CapacidadKg = value; }
        }

   }

}
