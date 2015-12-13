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
			Service.RequestEncoding = System.Text.Encoding.UTF8;
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
				node = doc.DocumentElement.SelectSingleNode ("/configuration/shippingapiendpoint");
				apiendpoint = node.InnerText;
				node = doc.DocumentElement.SelectSingleNode ("/configuration/apiuser");
				apiuser = node.InnerText;
				node = doc.DocumentElement.SelectSingleNode ("/configuration/apikey");
				apikey = node.InnerText;
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
		}


		static ServiceType[] GetDomesticServicesMethod (string postcode)
		{
			ServiceType[] availableServices = null;
			var Service = GetAuthoriseService ();
			try {
				// Call the GetDomesticServices soap service
				availableServices = Service.GetDomesticServices (postcode);

			} catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);

			}
			return availableServices;
		}

		/**
		 * An example of call the DBP api method GetDomesticServicesByPostcode 
		 *
		**/
		static ServiceType[] GetDomesticServicesByPostcodeMethod (string postcode)
		{	
			ServiceType[] availableServices = null;
			var Service = GetAuthoriseService ();

			try {
				// Call the GetDomesticServicesByPostcode soap service
				availableServices = Service.GetDomesticServicesByPostcode (postcode);
			} catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);
			}
			return availableServices;
		}

		/**
		 * An example of call the DBP api method AddDomesticShipmentMethod 
		 *
		**/
		static string AddDomesticShipmentMethod ()
		{
			var Service = GetAuthoriseService ();
			string shipmentId = null; 
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


		public static ShipmentReturnType GetShipmentMethod (string shipmentID)
		{
			var Service = GetAuthoriseService ();
			ShipmentReturnType shipmentDetail = new ShipmentReturnType(); 
			
			try {
				shipmentDetail = Service.GetShipment (shipmentID);

			} catch (Exception soapEx) {
				Console.WriteLine ("{0}, {1}", soapEx.Message, soapEx.InnerException);
			}
			return shipmentDetail;
		}

		public static void Main (string[] args)
		{
			LoadConfiguration ();

			int count = 0;
			ServiceType[] availableServices = null;
			/**
			 * Demonstrate getting a list of all services available for a given postcode
			 * 
			 **/

			Console.WriteLine ("\n\n\n============================================");
			Console.WriteLine ("Calling GetDomesticServices");
			try {
				availableServices = GetDomesticServicesMethod ("LN12UE");
				// iterate though the list of returned services
				count = 0;
				foreach (ServiceType element in availableServices) {
					count += 1;
					System.Console.WriteLine ("Service id:{0} - {1} £{2}", element.ServiceID, element.Name, element.Cost);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}


			/**
			 * Demonstrate getting a list of enabled services available for a given postcode
			 * 
			 **/

			Console.WriteLine ("\n\n\n============================================");
			Console.WriteLine ("Calling GetDomesticServicesByPostcode");
			availableServices = null;
			availableServices = GetDomesticServicesByPostcodeMethod ("LN12UE");
			// iterate though the list of returned services
			count = 0;
			foreach (ServiceType element in availableServices) {
				count += 1;
				System.Console.WriteLine ("Element Id: {0} - {1} £{2}", element.ServiceID, element.Name, element.Cost);
			}

			/**
			 * Demonstrate adding a shipment
			 * 
			 **/
			Console.WriteLine ("\n\n\n============================================");
			Console.WriteLine ("Calling AddDomesticShipment");
			string shipmentId = null; 
			shipmentId = AddDomesticShipmentMethod ();
			Console.WriteLine ("Shipment with id of {0} added", shipmentId);

			/**
			 * Demonstrate getting a shipment
			 * 
			 **/
			Console.WriteLine ("\n\n\n============================================");
			Console.WriteLine ("Calling GetShipment");
			ShipmentReturnType shipmentDetail = null; 
			//string shipmentId = "101788-8368241";
			Console.WriteLine ("Fetching added Shipment with id of {0}",shipmentId);

			shipmentDetail = GetShipmentMethod (shipmentId);
			Console.WriteLine ("Shipment details as follows");
			Console.WriteLine ("RecipientName {0}", shipmentDetail.RecipientName);
			Console.WriteLine ("RecipientEmail {0}", shipmentDetail.RecipientEmail);
			Console.WriteLine ("CompanyName {0}", shipmentDetail.CompanyName);
			Console.WriteLine ("Street {0}", shipmentDetail.Street);
			Console.WriteLine ("Town {0}", shipmentDetail.Town);
			Console.WriteLine ("Locality {0}", shipmentDetail.Locality);
			Console.WriteLine ("County {0}", shipmentDetail.County);
			Console.WriteLine ("Postcode {0}", shipmentDetail.Postcode);
			Console.WriteLine ("Contents {0}", shipmentDetail.Contents);
			Console.WriteLine ("CreateDate {0}", shipmentDetail.CreateDate);
			Console.WriteLine ("DespatchDate {0}", shipmentDetail.DespatchDate);
			Console.WriteLine ("ParcelQuantity {0}", shipmentDetail.ParcelQuantity);
			Console.WriteLine ("OrderReference {0}", shipmentDetail.OrderReference);
			Console.WriteLine ("DashboardNotification {0}", shipmentDetail.DashboardNotification);
			//Console.WriteLine ("Despatched {0}", shipmentDetail.Despatched);
			Console.WriteLine ("EmailNotification {0}", shipmentDetail.EmailNotification);
			Console.WriteLine ("EndTrackingNumber {0}", shipmentDetail.EndTrackingNumber);

			//Console.WriteLine ("Printed {0}", shipmentDetail.Printed);

			Console.WriteLine ("ServiceID {0}", shipmentDetail.ServiceID);
			Console.WriteLine ("ShipmentID {0}", shipmentDetail.ShipmentID);
			Console.WriteLine ("StartTrackingNumber {0}", shipmentDetail.StartTrackingNumber);


		}
	}
}