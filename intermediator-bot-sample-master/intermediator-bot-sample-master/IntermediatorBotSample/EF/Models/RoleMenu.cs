using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Roles Role { get; set; }
    }
}
