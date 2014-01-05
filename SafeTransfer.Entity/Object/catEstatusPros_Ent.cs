using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity.Object
{
    public class catEstatusPros_Ent : ENTBase
    {
        private int _IdEstatus; // Identificador de IdEstatus
        private string _Estatus; // Valor de Estatus
        private int _Activo; // Valor de Activo
        public catEstatusPros_Ent()
        {
            _IdEstatus = 0;
            _Estatus = "";
            _Activo = 0;
        }
        ///<remarks>
        ///   <name>catEstatusPros_Ent.IdEstatus</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdEstatus</summary>
        public int IdEstatus
        {
            get { return _IdEstatus; }
            set { _IdEstatus = value; }
        }
        ///<remarks>
        ///   <name>catEstatusPros_Ent.Estatus</name>
        ///   <create>11/dic/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Estatus</summary>
        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
        ///<remarks>
        ///   <name>catEstatusPros_Ent.Activo</name>
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
