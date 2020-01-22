using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleMenu = new HashSet<RoleMenu>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
