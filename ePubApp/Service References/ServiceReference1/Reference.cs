﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ePubApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserWeb", Namespace="http://schemas.datacontract.org/2004/07/ServiceePubCloud")]
    [System.SerializableAttribute()]
    public partial class UserWeb : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BirthdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> LastChapterReadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> LastEBookReadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LastLoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Birthdate {
            get {
                return this.BirthdateField;
            }
            set {
                if ((this.BirthdateField.Equals(value) != true)) {
                    this.BirthdateField = value;
                    this.RaisePropertyChanged("Birthdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> LastChapterRead {
            get {
                return this.LastChapterReadField;
            }
            set {
                if ((this.LastChapterReadField.Equals(value) != true)) {
                    this.LastChapterReadField = value;
                    this.RaisePropertyChanged("LastChapterRead");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> LastEBookRead {
            get {
                return this.LastEBookReadField;
            }
            set {
                if ((this.LastEBookReadField.Equals(value) != true)) {
                    this.LastEBookReadField = value;
                    this.RaisePropertyChanged("LastEBookRead");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> LastLogin {
            get {
                return this.LastLoginField;
            }
            set {
                if ((this.LastLoginField.Equals(value) != true)) {
                    this.LastLoginField = value;
                    this.RaisePropertyChanged("LastLogin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DateStatisticsWeb", Namespace="http://schemas.datacontract.org/2004/07/ServiceePubCloud")]
    [System.SerializableAttribute()]
    public partial class DateStatisticsWeb : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AcessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Acess {
            get {
                return this.AcessField;
            }
            set {
                if ((this.AcessField.Equals(value) != true)) {
                    this.AcessField = value;
                    this.RaisePropertyChanged("Acess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        string CreateUser(string username, string password, string name, string email, System.DateTime birthdate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        System.Threading.Tasks.Task<string> CreateUserAsync(string username, string password, string name, string email, System.DateTime birthdate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        bool UserExists(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UserExists", ReplyAction="http://tempuri.org/IService1/UserExistsResponse")]
        System.Threading.Tasks.Task<bool> UserExistsAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        ePubApp.ServiceReference1.UserWeb GetUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<ePubApp.ServiceReference1.UserWeb> GetUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateEbook", ReplyAction="http://tempuri.org/IService1/CreateEbookResponse")]
        void CreateEbook(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateEbook", ReplyAction="http://tempuri.org/IService1/CreateEbookResponse")]
        System.Threading.Tasks.Task CreateEbookAsync(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateBookmark", ReplyAction="http://tempuri.org/IService1/CreateBookmarkResponse")]
        string CreateBookmark(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateBookmark", ReplyAction="http://tempuri.org/IService1/CreateBookmarkResponse")]
        System.Threading.Tasks.Task<string> CreateBookmarkAsync(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFavorite", ReplyAction="http://tempuri.org/IService1/CreateFavoriteResponse")]
        string CreateFavorite(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFavorite", ReplyAction="http://tempuri.org/IService1/CreateFavoriteResponse")]
        System.Threading.Tasks.Task<string> CreateFavoriteAsync(string xmlDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getMostAccess", ReplyAction="http://tempuri.org/IService1/getMostAccessResponse")]
        ePubApp.ServiceReference1.DateStatisticsWeb[] getMostAccess();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getMostAccess", ReplyAction="http://tempuri.org/IService1/getMostAccessResponse")]
        System.Threading.Tasks.Task<ePubApp.ServiceReference1.DateStatisticsWeb[]> getMostAccessAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ePubApp.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ePubApp.ServiceReference1.IService1>, ePubApp.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CreateUser(string username, string password, string name, string email, System.DateTime birthdate) {
            return base.Channel.CreateUser(username, password, name, email, birthdate);
        }
        
        public System.Threading.Tasks.Task<string> CreateUserAsync(string username, string password, string name, string email, System.DateTime birthdate) {
            return base.Channel.CreateUserAsync(username, password, name, email, birthdate);
        }
        
        public bool UserExists(string username, string password) {
            return base.Channel.UserExists(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> UserExistsAsync(string username, string password) {
            return base.Channel.UserExistsAsync(username, password);
        }
        
        public ePubApp.ServiceReference1.UserWeb GetUser(string username, string password) {
            return base.Channel.GetUser(username, password);
        }
        
        public System.Threading.Tasks.Task<ePubApp.ServiceReference1.UserWeb> GetUserAsync(string username, string password) {
            return base.Channel.GetUserAsync(username, password);
        }
        
        public void CreateEbook(string xmlDoc) {
            base.Channel.CreateEbook(xmlDoc);
        }
        
        public System.Threading.Tasks.Task CreateEbookAsync(string xmlDoc) {
            return base.Channel.CreateEbookAsync(xmlDoc);
        }
        
        public string CreateBookmark(string xmlDoc) {
            return base.Channel.CreateBookmark(xmlDoc);
        }
        
        public System.Threading.Tasks.Task<string> CreateBookmarkAsync(string xmlDoc) {
            return base.Channel.CreateBookmarkAsync(xmlDoc);
        }
        
        public string CreateFavorite(string xmlDoc) {
            return base.Channel.CreateFavorite(xmlDoc);
        }
        
        public System.Threading.Tasks.Task<string> CreateFavoriteAsync(string xmlDoc) {
            return base.Channel.CreateFavoriteAsync(xmlDoc);
        }
        
        public ePubApp.ServiceReference1.DateStatisticsWeb[] getMostAccess() {
            return base.Channel.getMostAccess();
        }
        
        public System.Threading.Tasks.Task<ePubApp.ServiceReference1.DateStatisticsWeb[]> getMostAccessAsync() {
            return base.Channel.getMostAccessAsync();
        }
    }
}
