﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.AdminService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdminService.IAdmin")]
    public interface IAdmin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdmin/selectGrupo", ReplyAction="http://tempuri.org/IAdmin/selectGrupoResponse")]
        Alfanet.CommonObject.ObjGrupo[] selectGrupo(Alfanet.CommonObject.ConfigData config);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdmin/insertGrupo", ReplyAction="http://tempuri.org/IAdmin/insertGrupoResponse")]
        string insertGrupo(Alfanet.CommonObject.ConfigData config);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdmin/updateGrupo", ReplyAction="http://tempuri.org/IAdmin/updateGrupoResponse")]
        string updateGrupo();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdminChannel : WebApplication1.AdminService.IAdmin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminClient : System.ServiceModel.ClientBase<WebApplication1.AdminService.IAdmin>, WebApplication1.AdminService.IAdmin {
        
        public AdminClient() {
        }
        
        public AdminClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdminClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Alfanet.CommonObject.ObjGrupo[] selectGrupo(Alfanet.CommonObject.ConfigData config) {
            return base.Channel.selectGrupo(config);
        }
        
        public string insertGrupo(Alfanet.CommonObject.ConfigData config) {
            return base.Channel.insertGrupo(config);
        }
        
        public string updateGrupo() {
            return base.Channel.updateGrupo();
        }
    }
}
