// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace despatchbay.api.despatchbaypro.com {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ShippingServiceBinding", Namespace="urn:despatchbay")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(ServiceType))]
    public partial class ShippingService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// CodeRemarks
        public ShippingService() {
            this.Url = "http://api.despatchbaypro.com/soap/v11/shipping.php";
        }
        
        public ShippingService(string url) {
            this.Url = url;
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:despatchbay#GetDomesticServices", RequestNamespace="urn:despatchbay", ResponseNamespace="urn:despatchbay")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public ServiceType[] GetDomesticServices(string postcode) {
            object[] results = this.Invoke("GetDomesticServices", new object[] {
                        postcode});
            return ((ServiceType[])(results[0]));
        }
        
        /// CodeRemarks
        public System.IAsyncResult BeginGetDomesticServices(string postcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDomesticServices", new object[] {
                        postcode}, callback, asyncState);
        }
        
        /// CodeRemarks
        public ServiceType[] EndGetDomesticServices(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ServiceType[])(results[0]));
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:despatchbay#GetDomesticServicesByPostcode", RequestNamespace="urn:despatchbay", ResponseNamespace="urn:despatchbay")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public ServiceType[] GetDomesticServicesByPostcode(string postcode) {
            object[] results = this.Invoke("GetDomesticServicesByPostcode", new object[] {
                        postcode});
            return ((ServiceType[])(results[0]));
        }
        
        /// CodeRemarks
        public System.IAsyncResult BeginGetDomesticServicesByPostcode(string postcode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDomesticServicesByPostcode", new object[] {
                        postcode}, callback, asyncState);
        }
        
        /// CodeRemarks
        public ServiceType[] EndGetDomesticServicesByPostcode(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ServiceType[])(results[0]));
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:despatchbay#GetShipment", RequestNamespace="urn:despatchbay", ResponseNamespace="urn:despatchbay")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public ShipmentReturnType GetShipment(string ShipmentID) {
            object[] results = this.Invoke("GetShipment", new object[] {
                        ShipmentID});
            return ((ShipmentReturnType)(results[0]));
        }
        
        /// CodeRemarks
        public System.IAsyncResult BeginGetShipment(string ShipmentID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetShipment", new object[] {
                        ShipmentID}, callback, asyncState);
        }
        
        /// CodeRemarks
        public ShipmentReturnType EndGetShipment(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ShipmentReturnType)(results[0]));
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:despatchbay#AddDomesticShipment", RequestNamespace="urn:despatchbay", ResponseNamespace="urn:despatchbay")]
        [return: System.Xml.Serialization.SoapElementAttribute("ShipmentID")]
        public string AddDomesticShipment(ShipmentRequestType Shipment) {
            object[] results = this.Invoke("AddDomesticShipment", new object[] {
                        Shipment});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public System.IAsyncResult BeginAddDomesticShipment(ShipmentRequestType Shipment, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddDomesticShipment", new object[] {
                        Shipment}, callback, asyncState);
        }
        
        /// CodeRemarks
        public string EndAddDomesticShipment(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:despatchbay")]
    public partial class ServiceType {
        
        /// <remarks/>
        public int ServiceID;
        
        /// <remarks/>
        public string Name;
        
        /// <remarks/>
        public float Cost;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:despatchbay")]
    public partial class ShipmentRequestType {
        
        /// <remarks/>
        public int ServiceID;
        
        /// <remarks/>
        public int ParcelQuantity;
        
        /// <remarks/>
        public string OrderReference;
        
        /// <remarks/>
        public string Contents;
        
        /// <remarks/>
        public string CompanyName;
        
        /// <remarks/>
        public string RecipientName;
        
        /// <remarks/>
        public string Street;
        
        /// <remarks/>
        public string Locality;
        
        /// <remarks/>
        public string Town;
        
        /// <remarks/>
        public string County;
        
        /// <remarks/>
        public string Postcode;
        
        /// <remarks/>
        public string RecipientEmail;
        
        /// <remarks/>
        public int EmailNotification;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapIgnoreAttribute()]
        public bool EmailNotificationSpecified;
        
        /// <remarks/>
        public int DashboardNotification;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapIgnoreAttribute()]
        public bool DashboardNotificationSpecified;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:despatchbay")]
    public partial class ShipmentReturnType {
        
        /// <remarks/>
        public string ShipmentID;
        
        /// <remarks/>
        public int ServiceID;
        
        /// <remarks/>
        public string CreateDate;
        
        /// <remarks/>
        public int ParcelQuantity;
        
        /// <remarks/>
		[System.Xml.Serialization.SoapIgnoreAttribute()]
        public string Printed;
        
        /// <remarks/>
        public string StartTrackingNumber;
        
        /// <remarks/>
        public string EndTrackingNumber;
        
        /// <remarks/>
		[System.Xml.Serialization.SoapIgnoreAttribute()]
        public string Despatched;
        
        /// <remarks/>
        public string DespatchDate;
        
        /// <remarks/>
        public string OrderReference;
        
        /// <remarks/>
        public string Contents;
        
        /// <remarks/>
        public string CompanyName;
        
        /// <remarks/>
        public string RecipientName;
        
        /// <remarks/>
        public string Street;
        
        /// <remarks/>
        public string Locality;
        
        /// <remarks/>
        public string Town;
        
        /// <remarks/>
        public string County;
        
        /// <remarks/>
        public string Country;
        
        /// <remarks/>
        public string Postcode;
        
        /// <remarks/>
        public string RecipientEmail;
        
        /// <remarks/>
        public int EmailNotification;
        
        /// <remarks/>
        public int DashboardNotification;
    }
}
