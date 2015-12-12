﻿using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using wsdlConsole.api.despatchbaypro.com;
using System.Net;
using System.Xml;

namespace wsdlConsole
{
	class MainClass
	{
		static void SampleGetDomesticServicesByPostcodeMethod ()
		{
			// Create the service of type Shipping service
			ShippingService Service = new ShippingService ();
			// Set up some credentials
			NetworkCredential netCredential = new NetworkCredential ("", "");
			Uri uri = new Uri (Service.Url);
			ICredentials credentials = netCredential.GetCredential (uri, "Basic");
			// Apply the credentials to the service
			Service.Credentials = credentials;
			try {
				// Call the GetDomesticServicesByPostcode soap service
				var availableServices = Service.GetDomesticServicesByPostcode ("LN12UE");
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

		static void AddAddDomesticShipmentwMethod ()
		{
			// Create the service of type Shipping service
			ShippingService Service = new ShippingService ();
			// Set up some credentials
			NetworkCredential netCredential = new NetworkCredential ("", "");
			Uri uri = new Uri (Service.Url);
			ICredentials credentials = netCredential.GetCredential (uri, "Basic");
			// Apply the credentials to the service
			Service.Credentials = credentials;
			try {
				ShipmentRequestType ShipmentRequest = new ShipmentRequestType();
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
					

				Service.AddDomesticShipment(ShipmentRequest);
				Console.WriteLine ("Success");
			}
			catch (Exception soapEx) {
				Console.WriteLine ("{0}", soapEx.Message);
			}
		}

		public static void Main (string[] args)
		{
			SampleGetDomesticServicesByPostcodeMethod ();

			AddAddDomesticShipmentwMethod ();


		}
	}
}
