using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class tblPros_Ent : ENTBase
    {
        private int _IdPro; // Identificador de IdPro
        private int _IdPickUp; // Identificador de IdPickUp
        private string _ClaveTerminal; // Valor de ClaveTerminal
        private DateTime _FechaCaptura; // Valor de FechaCaptura
        private DateTime _FechaCargado; // Valor de FechaCargado
        private int _NoFacturacion; // Valor de NoFacturacion
        private int _IdClaveOrigen; // Identificador de IdClaveOrigen
        private int _IdClaveDestino; // Identificador de IdClaveDestino
        private int _IdClaveClienteFiscal; // Identificador de IdClaveClienteFiscal
        private int _IdClaveAgenteAduanal; // Identificador de IdClaveAgenteAduanal
        private int _IdClaveCobrarA; // Identificador de IdClaveCobrarA
        private int _IdCondicionesPago; // Identificador de IdCondicionesPago
        private int _IdVendedorOrigen; // Identificador de IdVendedorOrigen
        private int _IdVendedorDestino; // Identificador de IdVendedorDestino
        private int _TermFact; // Valor de TermFact
        private int _Patente; // Valor de Patente
        private string _Pedimento; // Valor de Pedimento
        private int _Ocurre; // Valor de Ocurre
        private double _PesoTotalKg; // Valor de PesoTotalKg
        private double _PiezasTotal; // Valor de PiezasTotal
        private double _ValorMercancia; // Valor de ValorMercancia
        //private byte _BL; // Valor de BL
        //private byte _PE; // Valor de PE
        private int _IdMoneda; // Identificador de IdMoneda
        private double _TCambio; // Valor de TCambio
        private double _TotalCargos; // Valor de TotalCargos
        private int _NoDescuentos; // Valor de NoDescuentos
        private double _Descuentos; // Valor de Descuentos
        private double _SubToral; // Valor de SubToral
        private int _PorcIVA; // Valor de PorcIVA
        private double _IVA; // Valor de IVA
        private int _PorcRetencion; // Valor de PorcRetencion
        private double _Retencion; // Valor de Retencion
        private double _Total; // Valor de Total
        private string _NombreOrigen;
        private string _NombreDestino;
        private int _Estatus;
        private DateTime _FechaCargoInicial;
        private DateTime _FechaCargoFinal;
        private int _DiasCredito;

        public tblPros_Ent()
        {
            _IdPro = 0;
            _IdPickUp = 0;
            _ClaveTerminal = "";
            _FechaCaptura = System.DateTime.Now;
            _FechaCargado = System.DateTime.Now;
            _NoFacturacion = 0;
            _IdClaveOrigen = 0;
            _IdClaveDestino = 0;
            _IdClaveClienteFiscal = 0;
            _IdClaveAgenteAduanal = 0;
            _IdClaveCobrarA = 0;
            _IdCondicionesPago = 0;
            _IdVendedorOrigen = 0;
            _IdVendedorDestino = 0;
            _TermFact = 0;
            _Patente = 0;
            _Pedimento = "";
            _Ocurre = 0;
            _PesoTotalKg = 0;
            _PiezasTotal = 0;
            _ValorMercancia = 0;
            //_BL = System.drawin;
            //_PE = "";
            _IdMoneda = 0;
            _TCambio = 0;
            _TotalCargos = 0;
            _NoDescuentos = 0;
            _Descuentos = 0;
            _SubToral = 0;
            _PorcIVA = 0;
            _IVA = 0;
            _PorcRetencion = 0;
            _Retencion = 0;
            _Total = 0;
            _NombreOrigen = "";
            _NombreDestino = "";
            _Estatus = 0;
            _FechaCargoInicial = System.DateTime.Parse("1900-01-01");
            _FechaCargoFinal = System.DateTime.Parse("1900-01-01");
            _DiasCredito = 0;
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdPro</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdPro</summary>
        public int IdPro
        {
            get { return _IdPro; }
            set { _IdPro = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdPickUp</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdPickUp</summary>
        public int IdPickUp
        {
            get { return _IdPickUp; }
            set { _IdPickUp = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.ClaveTerminal</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveTerminal</summary>
        public string ClaveTerminal
        {
            get { return _ClaveTerminal; }
            set { _ClaveTerminal = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.FechaCaptura</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaCaptura</summary>
        public DateTime FechaCaptura
        {
            get { return _FechaCaptura; }
            set { _FechaCaptura = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.FechaCargado</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaCargado</summary>
        public DateTime FechaCargado
        {
            get { return _FechaCargado; }
            set { _FechaCargado = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.NoFacturacion</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoFacturacion</summary>
        public int NoFacturacion
        {
            get { return _NoFacturacion; }
            set { _NoFacturacion = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdClaveOrigen</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdClaveOrigen</summary>
        public int IdClaveOrigen
        {
            get { return _IdClaveOrigen; }
            set { _IdClaveOrigen = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdClaveDestino</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdClaveDestino</summary>
        public int IdClaveDestino
        {
            get { return _IdClaveDestino; }
            set { _IdClaveDestino = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdClaveClienteFiscal</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdClaveClienteFiscal</summary>
        public int IdClaveClienteFiscal
        {
            get { return _IdClaveClienteFiscal; }
            set { _IdClaveClienteFiscal = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdClaveAgenteAduanal</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdClaveAgenteAduanal</summary>
        public int IdClaveAgenteAduanal
        {
            get { return _IdClaveAgenteAduanal; }
            set { _IdClaveAgenteAduanal = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdClaveCobrarA</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdClaveCobrarA</summary>
        public int IdClaveCobrarA
        {
            get { return _IdClaveCobrarA; }
            set { _IdClaveCobrarA = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdCondicionesPago</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCondicionesPago</summary>
        public int IdCondicionesPago
        {
            get { return _IdCondicionesPago; }
            set { _IdCondicionesPago = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdVendedorOrigen</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdVendedorOrigen</summary>
        public int IdVendedorOrigen
        {
            get { return _IdVendedorOrigen; }
            set { _IdVendedorOrigen = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IdVendedorDestino</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdVendedorDestino</summary>
        public int IdVendedorDestino
        {
            get { return _IdVendedorDestino; }
            set { _IdVendedorDestino = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.TermFact</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TermFact</summary>
        public int TermFact
        {
            get { return _TermFact; }
            set { _TermFact = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Patente</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Patente</summary>
        public int Patente
        {
            get { return _Patente; }
            set { _Patente = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Pedimento</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Pedimento</summary>
        public string Pedimento
        {
            get { return _Pedimento; }
            set { _Pedimento = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Ocurre</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Ocurre</summary>
        public int Ocurre
        {
            get { return _Ocurre; }
            set { _Ocurre = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.PesoTotalKg</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PesoTotalKg</summary>
        public double PesoTotalKg
        {
            get { return _PesoTotalKg; }
            set { _PesoTotalKg = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.PiezasTotal</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PiezasTotal</summary>
        public double PiezasTotal
        {
            get { return _PiezasTotal; }
            set { _PiezasTotal = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.ValorMercancia</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ValorMercancia</summary>
        public double ValorMercancia
        {
            get { return _ValorMercancia; }
            set { _ValorMercancia = value; }
        }
        /////<remarks>
        /////   <name>tblPros_Ent.BL</name>
        /////   <create>19/nov/2013</create>
        /////   <author>Generador</author>
        /////</remarks>
        /////<summary>Obtiene/Asigna BL</summary>
        //public string BL
        //{
        //    get { return _BL; }
        //    set { _BL = value; }
        //}
        /////<remarks>
        /////   <name>tblPros_Ent.PE</name>
        /////   <create>19/nov/2013</create>
        /////   <author>Generador</author>
        /////</remarks>
        /////<summary>Obtiene/Asigna PE</summary>
        //public string PE
        //{
        //    get { return _PE; }
        //    set { _PE = value; }
        //}
        ///<remarks>
        ///   <name>tblPros_Ent.IdMoneda</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdMoneda</summary>
        public int IdMoneda
        {
            get { return _IdMoneda; }
            set { _IdMoneda = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.TCambio</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TCambio</summary>
        public double TCambio
        {
            get { return _TCambio; }
            set { _TCambio = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.TotalCargos</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TotalCargos</summary>
        public double TotalCargos
        {
            get { return _TotalCargos; }
            set { _TotalCargos = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.NoDescuentos</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NoDescuentos</summary>
        public int NoDescuentos
        {
            get { return _NoDescuentos; }
            set { _NoDescuentos = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Descuentos</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descuentos</summary>
        public double Descuentos
        {
            get { return _Descuentos; }
            set { _Descuentos = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.SubToral</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SubToral</summary>
        public double SubToral
        {
            get { return _SubToral; }
            set { _SubToral = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.PorcIVA</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PorcIVA</summary>
        public int PorcIVA
        {
            get { return _PorcIVA; }
            set { _PorcIVA = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.IVA</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna IVA</summary>
        public double IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.PorcRetencion</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PorcRetencion</summary>
        public int PorcRetencion
        {
            get { return _PorcRetencion; }
            set { _PorcRetencion = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Retencion</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Retencion</summary>
        public double Retencion
        {
            get { return _Retencion; }
            set { _Retencion = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Total</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Total</summary>
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Total</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Total</summary>
        public string NombreOrigen
        {
            get { return _NombreOrigen; }
            set { _NombreOrigen = value; }
        }
        ///<remarks>
        ///   <name>tblPros_Ent.Total</name>
        ///   <create>19/nov/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Total</summary>
        public string NombreDestino
        {
            get { return _NombreDestino; }
            set { _NombreDestino = value; }
        }
        public int Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        public DateTime FechaCargoInicial
        {
            get { return _FechaCargoInicial; }
            set { _FechaCargoInicial = value; }
        }

        public DateTime FechaCargoFinal
        {
            get { return _FechaCargoFinal; }
            set { _FechaCargoFinal = value; }
        }

        public int DiasCredito
        {
            get { return _DiasCredito; }
            set { _DiasCredito = value; }
        }

    }
}
