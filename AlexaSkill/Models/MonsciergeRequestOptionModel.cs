using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexaSkill.Models
{
    public class MonsciergeRequestOptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TemplateId { get; set; }
        public int ValueNumber { get; set; }
    }
}