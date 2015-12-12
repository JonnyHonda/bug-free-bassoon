using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net;
using System.Xml;
using despatchbay.api.despatchbaypro.com;


namespace wsdlConsole
{
	class MainClass
	{
		private static string apiendpoint;
		private static string apiuser;
		private static string apikey;
		private static string ShipmentID;

		/**
		 * Connects to the api endpoint, authorises and returns a ShippingService Object
		 *  
		**/
		static ShippingService GetAuthoriseService ()
		{
			// Set up some credentials
			NetworkCredential netCredential = new NetworkCredential (apiuser, apikey);
			// Create the service of type Shipping service
			ShippingService Service = new ShippingService (apiendpoint);
			Uri uri = new Uri (Service.Url);
			ICredentials credentials = netCredential.GetCredential (uri, "Basic");
			// Apply the credentials to the service
			Service.Credentials = credentials;
			return Service;
		}

		/**
		 * Loads configuration values from the configuration.xml
		 * 
		 * 
		**/
		static void LoadConfiguration ()
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load ("configuration.xml");
			XmlNode node;
			try {
				node = doc.DocumentElement.SelectSingleNode ("/configuration/apiendpoint");
				apiendpoint = node.InnerText;
				node = doc.DocumentElement.SelectSingleNode ("/configuration/apiuser");
				apiuser = node.InnerText;
				node = doc.DocumentElement.SelectSingleNode ("/configuration/apikey");
				apikey = node.InnerText;
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
		}


		static void GetDomesticServicesMethod(string postcode){
			var Service = GetAuthoriseService ();
			try {
				// Call the GetDomesticServicesByPostcode soap service
				var availableServices = Service.GetDomesticServices (postcode);
				// iterate though the list of returned services
				int count = 0;
				foreach (ServiceType element in availableServices) {
					count += 1;
					System.Console.WriteLine ("Element #{0}: {1} - {2} £{3}", count, element.ServiceID, element.Name, element.Cost);
				}
				Console.WriteLine ("Success");
			} catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);
			}
		}
		/**
		 * An example of call the DBP api method GetDomesticServicesByPostcode 
		 *
		**/
		static void GetDomesticServicesByPostcodeMethod (string postcode)
		{			
			var Service = GetAuthoriseService ();

			try {
				// Call the GetDomesticServicesByPostcode soap service
				var availableServices = Service.GetDomesticServicesByPostcode (postcode);
				// iterate though the list of returned services
				int count = 0;
				foreach (ServiceType element in availableServices) {
					count += 1;
					Console.WriteLine ("Element #{0}: {1} - {2} £{3}", count, element.ServiceID, element.Name, element.Cost);
				}
				Console.WriteLine ("Success");
			} catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);
			}
		}

		/**
		 * An example of call the DBP api method AddDomesticShipmentMethod 
		 *
		**/
		static string AddDomesticShipmentMethod ()
		{
			var Service = GetAuthoriseService ();
			string  shipmentId = null; 
			try {
				ShipmentRequestType ShipmentRequest = new ShipmentRequestType ();
				ShipmentRequest.CompanyName = "Acme Toy Company";
				ShipmentRequest.Contents = "Toy Soldiers";
				ShipmentRequest.County = "Lincolnshire";
				ShipmentRequest.ParcelQuantity = 3;
				ShipmentRequest.Postcode = "LN12UE";
				ShipmentRequest.OrderReference = "c# - Example";
				ShipmentRequest.RecipientEmail = "john.burrin@thesalegroup.co.uk";
				ShipmentRequest.RecipientName = "Jonny Honda";
				ShipmentRequest.ServiceID = 47; // 47 - Small packet
				ShipmentRequest.Street = "7 Shropshire Road";
				ShipmentRequest.Town = "Lincoln";
				shipmentId = Service.AddDomesticShipment (ShipmentRequest);
				Console.WriteLine ("Success");
			} catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);
			}

			return shipmentId;
		}


		public static void GetShipmentMethod(string shipmentID){
			var Service = GetAuthoriseService ();
			ShipmentReturnType ShipmentRequest = new ShipmentReturnType (); 


			
			try{
				ShipmentRequest = Service.GetShipment(shipmentID);
				Console.WriteLine ("Parcel Quantity {0}", ShipmentRequest.ParcelQuantity);
			}catch(Exception soapEx){
				Console.WriteLine ("{0}", soapEx.Message);
			}
			
		}
		public static void Main (string[] args)
		{
			LoadConfiguration ();

			//GetDomesticServicesMethod ("LN12UE");

			//GetDomesticServicesByPostcodeMethod ("LN12UE");
			Console.WriteLine ("Adding new Shipment");

			ShipmentID = AddDomesticShipmentMethod ();

			Console.WriteLine ("ShipmenId: {0}", ShipmentID);
			Console.WriteLine ("Fetching new Shipment with id of {0}",ShipmentID);

			GetShipmentMethod (ShipmentID);
		}
	}
}