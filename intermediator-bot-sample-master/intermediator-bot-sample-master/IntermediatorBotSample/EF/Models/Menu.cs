using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class Menu
    {
        public Menu()
        {
            RoleMenu = new HashSet<RoleMenu>();
        }

        public int Id { get; set; }
        public string MenuName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}
