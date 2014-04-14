using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Product : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProviderTypeCode { get; set; }
        public string ProductModelCode { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal UomPrice { get; set; }
        public string UomCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string Direction { get; set; }
        public string ViewingStreet { get; set; }
        public string EntranceStreet { get; set; }
        public int NumberOfFloor { get; set; }
        public int NumberOfBedRoom { get; set; }
        public int NumberOfRestRoom { get; set; }
        public string Furniture { get; set; }
        public bool Subscribe { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSkypeId { get; set; }
        public string ContactFacebookId { get; set; }
        public string ContactGooglePlusId { get; set; }
        public string ContactYahooId { get; set; }
    }
}