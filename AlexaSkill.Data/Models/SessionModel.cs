using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class SessionModel
    {
        public string SessionId { get; set; }
        public ApplicationModel Application { get; set; }
        public AttributesModel Attributes { get; set; }
        public UserModel User { get; set; }
        public bool New { get; set; }
    }
}
