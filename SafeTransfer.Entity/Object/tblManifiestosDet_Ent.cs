using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class tblManifiestosDet_Ent : ENTBase
    {
        private int _IdManifiesto; // Identificador de IdManifiesto
        private int _Pro; // Valor de Pro
        private int _OrigenPro; // Valor de OrigenPro
        private int _DestinoPro; // Valor de DestinoPro
        private int _NoCaja; // Valor de NoCaja
        public tblManifiestosDet_Ent()
        {
            _IdManifiesto = 0;
            _Pro = 0;
            _OrigenPro = 0;
            _DestinoPro = 0;
            _NoCaja = 0;
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_Ent.IdManifiesto</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdManifiesto</summary>
        public int IdManifiesto
        {
            get { return _IdManifiesto; }
            set { _IdManifiesto = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_Ent.Pro</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Pro</summary>
        public int Pro
        {
            get { return _Pro; }
            set { _Pro = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_Ent.OrigenPro</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna OrigenPro</summary>
        public int OrigenPro
        {
            get { return _OrigenPro; }
            set { _OrigenPro = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_Ent.DestinoPro</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna DestinoPro</summary>
        public int DestinoPro
        {
            get { return _DestinoPro; }
            set { _DestinoPro = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosDet_Ent.NoCaja</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoCaja</summary>
        public int NoCaja
        {
            get { return _NoCaja; }
            set { _NoCaja = value; }
        }
    }
}
