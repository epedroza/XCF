using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity.Object
{
    public class catEstatusManifiestos_Ent : ENTBase
    {
        private int _IdEstatusManifiesto; // Identificador de IdEstatusManifiesto
        private string _EstatusManifiesto; // Valor de EstatusManifiesto
        private int _Activo; // Valor de Activo
        public catEstatusManifiestos_Ent()
        {
            _IdEstatusManifiesto = 0;
            _EstatusManifiesto = "";
            _Activo = 0;
        }
        ///<remarks>
        ///   <name>catEstatusManifiestos_Ent.IdEstatusManifiesto</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdEstatusManifiesto</summary>
        public int IdEstatusManifiesto
        {
            get { return _IdEstatusManifiesto; }
            set { _IdEstatusManifiesto = value; }
        }
        ///<remarks>
        ///   <name>catEstatusManifiestos_Ent.EstatusManifiesto</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstatusManifiesto</summary>
        public string EstatusManifiesto
        {
            get { return _EstatusManifiesto; }
            set { _EstatusManifiesto = value; }
        }
        ///<remarks>
        ///   <name>catEstatusManifiestos_Ent.Activo</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Activo</summary>
        public int Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
    }
}
