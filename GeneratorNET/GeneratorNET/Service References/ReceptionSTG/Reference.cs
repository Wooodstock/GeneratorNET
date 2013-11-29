﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18051
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneratorNET.ReceptionSTG {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://reception.stg.com/", ConfigurationName="ReceptionSTG.ReceptionSTG")]
    public interface ReceptionSTG {
        
        // CODEGEN : La génération du contrat de message depuis le nom d'élément message de l'espace de noms  n'est pas marqué nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://reception.stg.com/ReceptionSTG/sendToQueueRequest", ReplyAction="http://reception.stg.com/ReceptionSTG/sendToQueueResponse")]
        GeneratorNET.ReceptionSTG.sendToQueueResponse sendToQueue(GeneratorNET.ReceptionSTG.sendToQueueRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://reception.stg.com/ReceptionSTG/sendToQueueRequest", ReplyAction="http://reception.stg.com/ReceptionSTG/sendToQueueResponse")]
        System.Threading.Tasks.Task<GeneratorNET.ReceptionSTG.sendToQueueResponse> sendToQueueAsync(GeneratorNET.ReceptionSTG.sendToQueueRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class sendToQueueRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="sendToQueue", Namespace="http://reception.stg.com/", Order=0)]
        public GeneratorNET.ReceptionSTG.sendToQueueRequestBody Body;
        
        public sendToQueueRequest() {
        }
        
        public sendToQueueRequest(GeneratorNET.ReceptionSTG.sendToQueueRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class sendToQueueRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string message;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string fileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string key;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool sample;
        
        public sendToQueueRequestBody() {
        }
        
        public sendToQueueRequestBody(string message, string fileName, string key, bool sample) {
            this.message = message;
            this.fileName = fileName;
            this.key = key;
            this.sample = sample;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class sendToQueueResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="sendToQueueResponse", Namespace="http://reception.stg.com/", Order=0)]
        public GeneratorNET.ReceptionSTG.sendToQueueResponseBody Body;
        
        public sendToQueueResponse() {
        }
        
        public sendToQueueResponse(GeneratorNET.ReceptionSTG.sendToQueueResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class sendToQueueResponseBody {
        
        public sendToQueueResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ReceptionSTGChannel : GeneratorNET.ReceptionSTG.ReceptionSTG, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReceptionSTGClient : System.ServiceModel.ClientBase<GeneratorNET.ReceptionSTG.ReceptionSTG>, GeneratorNET.ReceptionSTG.ReceptionSTG {
        
        public ReceptionSTGClient() {
        }
        
        public ReceptionSTGClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReceptionSTGClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReceptionSTGClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReceptionSTGClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GeneratorNET.ReceptionSTG.sendToQueueResponse GeneratorNET.ReceptionSTG.ReceptionSTG.sendToQueue(GeneratorNET.ReceptionSTG.sendToQueueRequest request) {
            return base.Channel.sendToQueue(request);
        }
        
        public void sendToQueue(string message, string fileName, string key, bool sample) {
            GeneratorNET.ReceptionSTG.sendToQueueRequest inValue = new GeneratorNET.ReceptionSTG.sendToQueueRequest();
            inValue.Body = new GeneratorNET.ReceptionSTG.sendToQueueRequestBody();
            inValue.Body.message = message;
            inValue.Body.fileName = fileName;
            inValue.Body.key = key;
            inValue.Body.sample = sample;
            GeneratorNET.ReceptionSTG.sendToQueueResponse retVal = ((GeneratorNET.ReceptionSTG.ReceptionSTG)(this)).sendToQueue(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GeneratorNET.ReceptionSTG.sendToQueueResponse> GeneratorNET.ReceptionSTG.ReceptionSTG.sendToQueueAsync(GeneratorNET.ReceptionSTG.sendToQueueRequest request) {
            return base.Channel.sendToQueueAsync(request);
        }
        
        public System.Threading.Tasks.Task<GeneratorNET.ReceptionSTG.sendToQueueResponse> sendToQueueAsync(string message, string fileName, string key, bool sample) {
            GeneratorNET.ReceptionSTG.sendToQueueRequest inValue = new GeneratorNET.ReceptionSTG.sendToQueueRequest();
            inValue.Body = new GeneratorNET.ReceptionSTG.sendToQueueRequestBody();
            inValue.Body.message = message;
            inValue.Body.fileName = fileName;
            inValue.Body.key = key;
            inValue.Body.sample = sample;
            return ((GeneratorNET.ReceptionSTG.ReceptionSTG)(this)).sendToQueueAsync(inValue);
        }
    }
}
