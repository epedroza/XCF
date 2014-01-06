using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class catVendedores_Ent : ENTBase
    {
        private int _IdCompania; // Identificador de compania
        private int _IdVendedor; // Identificador de IdVendedor
        private string _Nombre; // Valor de Nombre
        private string _ApellidoPaterno; // Valor de ApellidoPaterno
        private string _ApellidoMaterno; // Valor de ApellidoMaterno
        private string _Direccion; // Valor de Direccion
        private int _IdPais; // Identificador de IdPais
        private int _IdEstado; // Identificador de IdEstado
        private int _IdCiudad; // Identificador de IdCiudad
        private string _CP; // Valor de CP
        private string _Telefono1; // Valor de Telefono1
        private string _Telefono2; // Valor de Telefono2
        private string _Correo; // Valor de Correo
        public catVendedores_Ent()
        {
            _IdCompania = 0;
            _IdVendedor = 0;
            _Nombre = "";
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _Direccion = "";
            _IdPais = 0;
            _IdEstado = 0;
            _IdCiudad = 0;
            _CP = "";
            _Telefono1 = "";
            _Telefono2 = "";
            _Correo = "";
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCompania</summary>
        public int IdCompania
        {
            get { return _IdCompania; }
            set { _IdCompania = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.IdVendedor</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdVendedor</summary>
        public int IdVendedor
        {
            get { return _IdVendedor; }
            set { _IdVendedor = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.Nombre</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombre</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.ApellidoPaterno</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoPaterno</summary>
        public string ApellidoPaterno
        {
            get { return _ApellidoPaterno; }
            set { _ApellidoPaterno = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.ApellidoMaterno</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoMaterno</summary>
        public string ApellidoMaterno
        {
            get { return _ApellidoMaterno; }
            set { _ApellidoMaterno = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.Direccion</name>
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
        ///   <name>catVendedores_Ent.IdPais</name>
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
        ///   <name>catVendedores_Ent.IdEstado</name>
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
        ///   <name>catVendedores_Ent.IdCiudad</name>
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
        ///   <name>catVendedores_Ent.CP</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CP</summary>
        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.Telefono1</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Telefono1</summary>
        public string Telefono1
        {
            get { return _Telefono1; }
            set { _Telefono1 = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.Telefono2</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Telefono2</summary>
        public string Telefono2
        {
            get { return _Telefono2; }
            set { _Telefono2 = value; }
        }
        ///<remarks>
        ///   <name>catVendedores_Ent.Correo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Correo</summary>
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }
    }
}
