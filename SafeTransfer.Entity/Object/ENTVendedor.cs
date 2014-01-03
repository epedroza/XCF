/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTVendedor
' Autor: Ruben.Cobos
' Fecha: 11-Noviembre-2013
'
' Proposito:
'          Clase que modela el catálogo de Vendedores de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeTransfer.Entity.Object
{

   public class ENTVendedor : ENTBase
   {

      // Definiciones
		private Int32	_idVendedor;		// Identificador único de Vendedor
        private Int32 _idCompany;        // Identificador único de la Compañía dueña del registro
        private Int32 _idCiudad;
        private Int32 _idEstado;
        private Int32 _idPais;
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Vendedor
        private string _sApellidoPaterno;   // 
        private string _sApellidoMaterno;
        private string _sDireccion;
        private string _sCP;
        private string _sTelefono1;
        private string _sTelefono2;
        private string _sCorreo;
		private Int16	_tiActivo;			// Control de baja lógica de registro

		
		 //Constructor

		public ENTVendedor(){
			_idVendedor = 0;
            _idCompany = 0;
            _idCiudad = 0;
            _idEstado = 0;
            _idPais = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
            _sApellidoPaterno = string.Empty;
            _sApellidoMaterno = string.Empty;
            _sDireccion = string.Empty;
            _sCP = string.Empty;
            _sTelefono1 = string.Empty;
            _sTelefono2 = string.Empty;
            _sCorreo = string.Empty;
			_tiActivo = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTVendedor.idVendedor</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Vendedor</summary>
		public Int32 idVendedor
		{
			get { return _idVendedor; }
			set { _idVendedor = value; }
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
        ///   <name>ENTVendedor.idCiudad</name>
        ///   <create></create>
        ///   <author></author>
        ///</remarks>
        ///<summary></summary>
        public Int32 idCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }

        public Int32 idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public Int32 idPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
		
		///<remarks>
		///   <name>ENTVendedor.dtFechaCreacion</name>
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
		///   <name>ENTVendedor.sDescripcion</name>
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
		///   <name>ENTVendedor.sNombre</name>
		///   <create>11-Noviembre-2013</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Vendedor</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

        public String sApellidoPaterno
        {
            get { return _sApellidoPaterno; }
            set { _sApellidoPaterno = value; }
        }

        public String sApellidoMaterno
        {
            get { return _sApellidoMaterno; }
            set { _sApellidoMaterno = value; }
        }

        public String sDireccion
        {
            get { return _sDireccion; }
            set { _sDireccion = value; }
        }

        public String sCP
        {
            get { return _sCP; }
            set { _sCP = value; }
        }

        public String sTelefono1
        {
            get { return _sTelefono1; }
            set { _sTelefono1 = value; }
        }

        public String sTelefono2
        {
            get { return _sTelefono2; }
            set { _sTelefono2 = value; }
        }

        public String sCorreo
        {
            get { return _sCorreo; }
            set { _sCorreo = value; }
        }

		///<remarks>
		///   <name>ENTVendedor.tiActivo</name>
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
