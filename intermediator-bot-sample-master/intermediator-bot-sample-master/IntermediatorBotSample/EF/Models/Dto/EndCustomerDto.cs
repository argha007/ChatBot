using Newtonsoft.Json;
using System.Linq;

namespace IntermediatorBotSample.EF.Models.Dto
{
    public class EndCustomerDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "emailId")]
        public string EmailId { get; set; }
        [JsonProperty(PropertyName = "customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty(PropertyName = "endCustomerGUID")]
        public string EndCustomerGuid { get; set; }

       
    }

    public static class EndCustomerDtoMapper
    {
        public static EndCustomerDto MapToDto(EndCustomer endCustomer)
        {
            return new EndCustomerDto()
            {
                Id = endCustomer.Id,
                FullName = endCustomer.FullName,
                PhoneNumber=endCustomer.PhoneNumber,
                EmailId=endCustomer.EmailId,
                CustomerId=endCustomer.CustomerId,
                EndCustomerGuid=endCustomer.EndCustomerGuid
            };
        }
    }
}
