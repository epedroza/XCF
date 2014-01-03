using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class tblManifiestosHdr_Ent : ENTBase
    {
        private int _IdManifiesto; // Identificador de IdManifiesto
        private int _ClaveOrigen; // Valor de ClaveOrigen
        private int _ClaveDestino; // Valor de ClaveDestino
        private int _NoTractor; // Valor de NoTractor
        private int _NoCaja1; // Valor de NoCaja1
        private int _NoCaja2; // Valor de NoCaja2
        private int _TractorPropio; // Valor de TractorPropio
        private int _Caja1Propia; // Valor de Caja1Propia
        private int _Caja2Propia; // Valor de Caja2Propia
        private int _CveOperador; // Valor de CveOperador
        private DateTime _FechaSalida; // Valor de FechaSalida
        private DateTime _FechaLlegada; // Valor de FechaLlegada
        private int _IdCompania;
        private int _Estatus;

        public tblManifiestosHdr_Ent()
        {
            _IdManifiesto = 0;
            _ClaveOrigen = 0;
            _ClaveDestino = 0;
            _NoTractor = 0;
            _NoCaja1 = 0;
            _NoCaja2 = 0;
            _TractorPropio = 0;
            _Caja1Propia = 0;
            _Caja2Propia = 0;
            _CveOperador = 0;
            _FechaSalida = System.DateTime.Now;
            _FechaLlegada = System.DateTime.Now;
            _IdCompania = 0;
            _Estatus = 0;
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.IdManifiesto</name>
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
        ///   <name>tblManifiestosHdr_Ent.ClaveOrigen</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveOrigen</summary>
        public int ClaveOrigen
        {
            get { return _ClaveOrigen; }
            set { _ClaveOrigen = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.ClaveDestino</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveDestino</summary>
        public int ClaveDestino
        {
            get { return _ClaveDestino; }
            set { _ClaveDestino = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.NoTractor</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoTractor</summary>
        public int NoTractor
        {
            get { return _NoTractor; }
            set { _NoTractor = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.NoCaja1</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoCaja1</summary>
        public int NoCaja1
        {
            get { return _NoCaja1; }
            set { _NoCaja1 = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.NoCaja2</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoCaja2</summary>
        public int NoCaja2
        {
            get { return _NoCaja2; }
            set { _NoCaja2 = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.TractorPropio</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TractorPropio</summary>
        public int TractorPropio
        {
            get { return _TractorPropio; }
            set { _TractorPropio = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.Caja1Propia</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Caja1Propia</summary>
        public int Caja1Propia
        {
            get { return _Caja1Propia; }
            set { _Caja1Propia = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.Caja2Propia</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Caja2Propia</summary>
        public int Caja2Propia
        {
            get { return _Caja2Propia; }
            set { _Caja2Propia = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.CveOperador</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CveOperador</summary>
        public int CveOperador
        {
            get { return _CveOperador; }
            set { _CveOperador = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.FechaSalida</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaSalida</summary>
        public DateTime FechaSalida
        {
            get { return _FechaSalida; }
            set { _FechaSalida = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.FechaLlegada</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaLlegada</summary>
        public DateTime FechaLlegada
        {
            get { return _FechaLlegada; }
            set { _FechaLlegada = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.FechaLlegada</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaLlegada</summary>
        public int IdCompania
        {
            get { return _IdCompania; }
            set { _IdCompania = value; }
        }
        ///<remarks>
        ///   <name>tblManifiestosHdr_Ent.FechaLlegada</name>
        ///   <create>25/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaLlegada</summary>
        public int Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }
    }
}
