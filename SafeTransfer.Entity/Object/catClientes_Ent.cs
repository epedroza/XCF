using System;
using System.Collections.Generic;
using System.Text;
namespace SafeTransfer.Entity
{
    public class catClientes_Ent : ENTBase
    {
        private int _IdCompania; // Identificador de compania
        private int _IdCliente; // Identificador de IdCliente
        private int _IdTipoCliente; // Identificador de IdTipoCliente
        private string _Nombre; // Valor de Nombre
        private string _Direccion1; // Valor de Direccion1
        private string _Direccion2; // Valor de Direccion2
        private int _Terminal; // Valor de Terminal
        private int _IdPais; // Identificador de IdPais
        private int _IdEstado; // Identificador de IdEstado
        private int _IdCiudad; // Identificador de IdCiudad
        private string _CP; // Valor de CP
        private string _Contacto1; // Valor de Contacto1
        private string _Correo1; // Valor de Correo1
        private string _Telefono1; // Valor de Telefono1
        private string _Contacto2; // Valor de Contacto2
        private string _Correo2; // Valor de Correo2
        private string _Telefono2; // Valor de Telefono2
        private string _Fax; // Valor de Fax
        private int _IdMoneda; // Identificador de IdMoneda
        private int _IdMetodoPago; // Identificador de IdMetodoPago
        private string _Tarifa; // Valor de Tarifa
        private int _DiasCredito; // Valor de DiasCredito
        private string _PorcientoIVA; // Valor de PorcientoIVA
        private string _PorcientoRetencion; // Valor de PorcientoRetencion
        private int _Preferencial; // Valor de Preferencial
        private int _ClaveVendedorOriginal; // Valor de ClaveVendedorOriginal
        private int _ClaveGTEDes; // Valor de ClaveGTEDes
        private int _IdBillTo; // Identificador de IdBillTo
        private int _IdShipTo; // Identificador de IdShipTo
        private int _FolioBillShip;
        private int _BillOrShip;

        public catClientes_Ent()
        {
            _IdCompania = 0;
            _IdCliente = 0;
            _IdTipoCliente = 0;
            _Nombre = "";
            _Direccion1 = "";
            _Direccion2 = "";
            _Terminal = 0;
            _IdPais = 0;
            _IdEstado = 0;
            _IdCiudad = 0;
            _CP = "";
            _Contacto1 = "";
            _Correo1 = "";
            _Telefono1 = "";
            _Contacto2 = "";
            _Correo2 = "";
            _Telefono2 = "";
            _Fax = "";
            _IdMoneda = 0;
            _IdMetodoPago = 0;
            _Tarifa = "";
            _DiasCredito = 0;
            _PorcientoIVA = "";
            _PorcientoRetencion = "";
            _Preferencial = 0;
            _ClaveVendedorOriginal = 0;
            _ClaveGTEDes = 0;
            _IdBillTo = 0;
            _IdShipTo = 0;
            _FolioBillShip = 0;
            _BillOrShip = 0;
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdCompania</name>
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
        ///   <name>catClientes_Ent.IdCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCliente</summary>
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdTipoCliente</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdTipoCliente</summary>
        public int IdTipoCliente
        {
            get { return _IdTipoCliente; }
            set { _IdTipoCliente = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Nombre</name>
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
        ///   <name>catClientes_Ent.Direccion1</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Direccion1</summary>
        public string Direccion1
        {
            get { return _Direccion1; }
            set { _Direccion1 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Direccion2</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Direccion2</summary>
        public string Direccion2
        {
            get { return _Direccion2; }
            set { _Direccion2 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Terminal</name>
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
        ///   <name>catClientes_Ent.IdPais</name>
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
        ///   <name>catClientes_Ent.IdEstado</name>
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
        ///   <name>catClientes_Ent.IdCiudad</name>
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
        ///   <name>catClientes_Ent.CP</name>
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
        ///   <name>catClientes_Ent.Contacto1</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Contacto1</summary>
        public string Contacto1
        {
            get { return _Contacto1; }
            set { _Contacto1 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Correo1</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Correo1</summary>
        public string Correo1
        {
            get { return _Correo1; }
            set { _Correo1 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Telefono1</name>
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
        ///   <name>catClientes_Ent.Contacto2</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Contacto2</summary>
        public string Contacto2
        {
            get { return _Contacto2; }
            set { _Contacto2 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Correo2</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Correo2</summary>
        public string Correo2
        {
            get { return _Correo2; }
            set { _Correo2 = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Telefono2</name>
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
        ///   <name>catClientes_Ent.Fax</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Fax</summary>
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdMoneda</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdMoneda</summary>
        public int IdMoneda
        {
            get { return _IdMoneda; }
            set { _IdMoneda = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdMetodoPago</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdMetodoPago</summary>
        public int IdMetodoPago
        {
            get { return _IdMetodoPago; }
            set { _IdMetodoPago = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Tarifa</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Tarifa</summary>
        public string Tarifa
        {
            get { return _Tarifa; }
            set { _Tarifa = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.DiasCredito</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna DiasCredito</summary>
        public int DiasCredito
        {
            get { return _DiasCredito; }
            set { _DiasCredito = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.PorcientoIVA</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PorcientoIVA</summary>
        public string PorcientoIVA
        {
            get { return _PorcientoIVA; }
            set { _PorcientoIVA = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.PorcientoRetencion</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PorcientoRetencion</summary>
        public string PorcientoRetencion
        {
            get { return _PorcientoRetencion; }
            set { _PorcientoRetencion = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.Preferencial</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Preferencial</summary>
        public int Preferencial
        {
            get { return _Preferencial; }
            set { _Preferencial = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.ClaveVendedorOriginal</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveVendedorOriginal</summary>
        public int ClaveVendedorOriginal
        {
            get { return _ClaveVendedorOriginal; }
            set { _ClaveVendedorOriginal = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.ClaveGTEDes</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ClaveGTEDes</summary>
        public int ClaveGTEDes
        {
            get { return _ClaveGTEDes; }
            set { _ClaveGTEDes = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdBillTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdBillTo</summary>
        public int IdBillTo
        {
            get { return _IdBillTo; }
            set { _IdBillTo = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdShipTo</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdShipTo</summary>
        public int IdShipTo
        {
            get { return _IdShipTo; }
            set { _IdShipTo = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCompania</summary>
        public int FolioBillShip
        {
            get { return _FolioBillShip; }
            set { _FolioBillShip = value; }
        }
        ///<remarks>
        ///   <name>catClientes_Ent.IdCompania</name>
        ///   <create>24/oct/2013</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador de IdCompania</summary>
        public int BillOrShip
        {
            get { return _BillOrShip; }
            set { _BillOrShip = value; }
        }
    }
}
