using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class catAgentesAduanales_Ent : ENTBase
    {
        private int _IdCompania; // Valor de IdCompania
        private int _ClaveAgenteAduanal; // Valor de ClaveAgenteAduanal
        private string _Nombre; // Valor de Nombre
        private string _RFC; // Valor de RFC
        private int _Terminal; // Valor de Terminal
        private string _CD; // Valor de CD
        private string _Direccion; // Valor de Direccion
        private int _IdCiudad; // Identificador de IdCiudad
        public catAgentesAduanales_Ent()
        {
            _IdCompania = 0;
            _ClaveAgenteAduanal = 0;
            _Nombre = "";
            _RFC = "";
            _Terminal = 0;
            _CD = "";
            _Direccion = "";
            _IdCiudad = 0;
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna IdCompania</summary>
        public int IdCompania
        {
            get { return _IdCompania; }
            set { _IdCompania = value; }
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_Ent.ClaveAgenteAduanal</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveAgenteAduanal</summary>
        public int ClaveAgenteAduanal
        {
            get { return _ClaveAgenteAduanal; }
            set { _ClaveAgenteAduanal = value; }
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_Ent.Nombre</name>
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
        ///   <name>catAgentesAduanales_Ent.RFC</name>
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
        ///   <name>catAgentesAduanales_Ent.Terminal</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Terminal</summary>
        public int Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_Ent.CD</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CD</summary>
        public string CD
        {
            get { return _CD; }
            set { _CD = value; }
        }
        ///<remarks>
        ///   <name>catAgentesAduanales_Ent.Direccion</name>
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
        ///   <name>catAgentesAduanales_Ent.IdCiudad</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCiudad</summary>
        public int IdCiudad
        {
            get { return _IdCiudad; }
            set { _IdCiudad = value; }
        }
    }
}
