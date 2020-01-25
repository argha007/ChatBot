using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntermediatorBotSample.EF.Models
{
    public partial class Users
    {
        public Users()
        {
            EndCustomer = new HashSet<EndCustomer>();
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        [ForeignKey("BotPlans")]
        public int BotPlanId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        [StringLength(100)]
        public string PhoneNumbers { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegisteredOn { get; set; }
        [StringLength(100)]
        public string PrimaryAddress { get; set; }
        [StringLength(100)]
        public string CommunicationAddress { get; set; }

        public virtual Roles Role { get; set; }

        public virtual BotPlans BotPlan { get; set; }
        public virtual ICollection<EndCustomer> EndCustomer { get; set; }
    }
}
