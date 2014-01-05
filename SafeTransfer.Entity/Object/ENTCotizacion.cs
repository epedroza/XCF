/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTCotizacion
' Autor: Ruben.Cobos
' Fecha: 19-Diciembre-2013
'
' Proposito:
'          Clase que modela la tabla de Cotizaciones de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Data;

namespace SafeTransfer.Entity.Object
{

   public class ENTCotizacion : ENTBase
   {

      // Definiciones
		private Int32	   _idCotizacion;             // Identificador único de Cotizacion
      private Int32	   _idCiudad_Destino;         // Identificador único de la ciudad Destino a donde llega la carga
      private Int32	   _idCiudad_Origen;          // Identificador único de la ciudad Origen desde donde sale la carga
      private Int32	   _idCompany;                // Identificador único de la compañía a la que pertenece la Cotización
      private Int32	   _idMoneda;                 // Identificador único de la Moneda en la cual ésta expresada la Cotización
      private Int32     _idPickUp;                 // Identificador único del PickUp asociado a la Cotizacion
      private Int32	   _idUnidadMedida_Peso;      // Identificador único de la unidad de medida para peso
      private Int32	   _idUnidadMedida_Volumen;   // Identificador único de la unidad de medida para volumen
      private Decimal   _dPeso;                    // Peso total agrupado de todos los materiales incluídos en la cotización
      private Decimal   _dVolumen;                 // Volumen total agrupado de todos los materiales incluídos en la cotización
      private String    _dtCotizacion;             // Fecha y hora de la creación del registro
      private Decimal	_mCargoExtra;              // Monto del cargo extra del viaje expresado en la moneda relacionada con la Cotización
      private Decimal	_mDescuento;               // Monto del descuento del viaje expresado en la moneda relacionada con la Cotización
      private Int16     _tiRecalculo;              // Determina si es necesario recalcular las partidas de Servicios y Medidas en una cotización
      private DataTable _tblCotizacionPartidas;    // Almacena el listado de partidas de la Cotización expresada en pesos Mexicanos
      private DataTable _tblServicios;             // Almacena el listado de los servicios relacionados con la Cotización

		
		 //Constructor

		public ENTCotizacion(){
			_idCotizacion = 0;
         _idCiudad_Destino = 0;
         _idCiudad_Origen = 0;
         _idCompany = 0;
         _idMoneda = 0;
         _idPickUp = 0;
         _idUnidadMedida_Peso = 0;
         _idUnidadMedida_Volumen = 0;
         _dPeso = 0;
         _dVolumen = 0;
         _dtCotizacion = "";
         _mCargoExtra = 0;
         _mDescuento = 0;
			_tiRecalculo = 0;
         _tblCotizacionPartidas = null;
         _tblServicios = null;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTCotizacion.idCotizacion</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de una Cotizacion</summary>
		public Int32 idCotizacion
		{
			get { return _idCotizacion; }
			set { _idCotizacion = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.idCiudad_Destino</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la ciudad Destino a donde llega la carga</summary>
		public Int32 idCiudad_Destino
		{
			get { return _idCiudad_Destino; }
			set { _idCiudad_Destino = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.idCiudad_Origen</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la ciudad Origen desde donde sale la carga</summary>
		public Int32 idCiudad_Origen
		{
			get { return _idCiudad_Origen; }
			set { _idCiudad_Origen = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.idCompany</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la compañía a la que pertenece la Cotización</summary>
		public Int32 idCompany
		{
			get { return _idCompany; }
			set { _idCompany = value; }
		}
 
      ///<remarks>
		///   <name>ENTCotizacion.idMoneda</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Moneda en la cual ésta expresada la Cotización</summary>
		public Int32 idMoneda
		{
			get { return _idMoneda; }
			set { _idMoneda = value; }
		}

      ///<remarks>
      ///   <name>ENTCotizacion.idPickUp</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del PickUp asociado a la Cotizacion</summary>
      public Int32 idPickUp
      {
         get { return _idPickUp; }
         set { _idPickUp = value; }
      }

      ///<remarks>
		///   <name>ENTCotizacion.idUnidadMedida_Peso</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la unidad de medida para peso</summary>
		public Int32 idUnidadMedida_Peso
		{
			get { return _idUnidadMedida_Peso; }
			set { _idUnidadMedida_Peso = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.idUnidadMedida_Volumen</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la unidad de medida para volumen</summary>
		public Int32 idUnidadMedida_Volumen
		{
			get { return _idUnidadMedida_Volumen; }
			set { _idUnidadMedida_Volumen = value; }
		}
       
      ///<remarks>
		///   <name>ENTCotizacion.dPeso</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el peso total agrupado de todos los materiales incluídos en la cotización</summary>
		public Decimal dPeso
		{
			get { return _dPeso; }
			set { _dPeso = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.dVolumen</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el volumen total agrupado de todos los materiales incluídos en la cotización</summary>
		public Decimal dVolumen
		{
			get { return _dVolumen; }
			set { _dVolumen = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.dtCotizacion</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de creacion del registro</summary>
		public String dtCotizacion
		{
			get { return _dtCotizacion; }
			set { _dtCotizacion = value; }
		}

      ///<remarks>
		///   <name>ENTCotizacion.mCargoExtra</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el monto del cargo extra del viaje expresado en la moneda relacionada con la Cotización</summary>
		public Decimal mCargoExtra
		{
			get { return _mCargoExtra; }
			set { _mCargoExtra = value; }
		}
      
      ///<remarks>
      ///   <name>ENTCotizacion.mDescuento</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
      ///<summary>Obtiene/Asigna el monto del descuento del viaje expresado en la moneda relacionada con la Cotización</summary>
      public Decimal mDescuento
		{
         get { return _mDescuento; }
         set { _mDescuento = value; }
		}
		
		///<remarks>
      ///   <name>ENTCotizacion.tiRecalculo</name>
		///   <create>19-Diciembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
      ///<summary>Obtiene/Asigna un valor que determina si es necesario recalcular las partidas de Servicios y Medidas en una cotización</summary>
      public Int16 tiRecalculo
		{
         get { return _tiRecalculo; }
         set { _tiRecalculo = value; }
		}

      ///<remarks>
      ///   <name>ENTCotizacion.tblCotizacionPartidas</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el listado de partidas de la Cotización expresada en pesos Mexicanos</summary>
      public DataTable tblCotizacionPartidas
      {
         get { return _tblCotizacionPartidas; }
         set { _tblCotizacionPartidas = value; }
      }

      ///<remarks>
      ///   <name>ENTCotizacion.tblServicios</name>
      ///   <create>19-Diciembre-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el el listado de los servicios relacionados con la Cotización</summary>
      public DataTable tblServicios
      {
         get { return _tblServicios; }
         set { _tblServicios = value; }
      }

   }

}
