using System;
using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models
{
    public partial class UserSecurityQuestions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SecurityQuestionId { get; set; }
        public string Answer { get; set; }
    }
}
