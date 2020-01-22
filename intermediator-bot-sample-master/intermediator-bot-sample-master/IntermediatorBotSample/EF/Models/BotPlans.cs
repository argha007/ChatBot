using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class BotPlans
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string IsActive { get; set; }
    }
}
