﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vistas.fru {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/WebService", ConfigurationName="fru.WebServicePruebaSoap")]
    public interface WebServicePruebaSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/WebService/Autenticar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Autenticar(string user, string pas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/WebService/Regiones", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Regiones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/WebService/registrarCliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void registrarCliente(int rut, char dv, string nombre, string apellido, char sexo, string correo, int telefono, int id_direccionparticular, int id_comuna);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServicePruebaSoapChannel : Vistas.fru.WebServicePruebaSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServicePruebaSoapClient : System.ServiceModel.ClientBase<Vistas.fru.WebServicePruebaSoap>, Vistas.fru.WebServicePruebaSoap {
        
        public WebServicePruebaSoapClient() {
        }
        
        public WebServicePruebaSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServicePruebaSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicePruebaSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicePruebaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Autenticar(string user, string pas) {
            return base.Channel.Autenticar(user, pas);
        }
        
        public System.Data.DataSet Regiones() {
            return base.Channel.Regiones();
        }
        
        public void registrarCliente(int rut, char dv, string nombre, string apellido, char sexo, string correo, int telefono, int id_direccionparticular, int id_comuna) {
            base.Channel.registrarCliente(rut, dv, nombre, apellido, sexo, correo, telefono, id_direccionparticular, id_comuna);
        }
    }
}
