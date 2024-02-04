using System;
using System.Collections.Generic;
using System.Linq;
using TPAutoRentals.Shared.Domain;
using System.Threading.Tasks;

namespace TPAutoRentals.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";
        public static readonly string BrandsEndpoint = $"{Prefix}/brands";
        public static readonly string BookingsEndpoint = $"{Prefix}/bookings";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string LicenseRequestsEndpoint = $"{Prefix}/licenserequests";
        public static readonly string ModelColoursEndpoint = $"{Prefix}/modelcolours";
        public static readonly string ModelsEndpoint = $"{Prefix}/models";
        public static readonly string OutletsEndpoint = $"{Prefix}/outlets";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
        public static readonly string TransportsEndpoint = $"{Prefix}/transports";
        public static readonly string VehicleImagesEndpoint = $"{Prefix}/vehicleimages";
        public static readonly string VehiclesEndpoint = $"{Prefix}/vehicles";
    }
}
