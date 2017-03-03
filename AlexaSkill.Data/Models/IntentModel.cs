using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data.Models
{
    public class IntentModel
    {
        public string Name { get; set; }
        public SlotModel Slots { get; set; }
    }
}
