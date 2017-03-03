using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexaSkill.Models
{
    public class MonsciergeRequestModel
    {
        public int RequestTemplateId { get; set; }
        public MonsciergeRequestOptionsModel[] Options { get; set; }
        public int RequestUserId { get; set; }
    }
}