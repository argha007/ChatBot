using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class EndCustomer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public int? CustomerId { get; set; }
        public string EndCustomerGuid { get; set; }

        public virtual Users Customer { get; set; }
    }
}
