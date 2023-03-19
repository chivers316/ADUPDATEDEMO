using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADASSESSMENT.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        [NotMapped]
        public DateTime? BookedDate { get; set; } = DateTime.Now;
              
        public bool monSlot1 { get; set; } = false;      //Monday 08:00-10:00
        public bool monSlot2 { get; set; } = false;      //Monday 11:00-13:00
        public bool monSlot3 { get; set; } = false;      //Monday 14:00-16:00

        public bool tueSlot1 { get; set; } = false;      //Tuesday 08:00-10:00
        public bool tueSlot2 { get; set; } = false;      //Tuesday 11:00-13:00
        public bool tueSlot3 { get; set; } = false;     //Tuesday 14:00-16:00

        public bool wedSlot1 { get; set; } = false;      //Wednesday 08:00-10:00
        public bool wedSlot2 { get; set; } = false;      //Wednesday 11:00-13:00
        public bool wedSlot3 { get; set; } = false;      //Wednesday 14:00-16:00

        public bool thuSlot1 { get; set; } = false;      //Thursday 08:00-10:00
        public bool thuSlot2 { get; set; } = false;      //Thursday 11:00-13:00
        public bool thuSlot3 { get; set; } = false;      //Thursday 14:00-16:00

        public bool friSlot1 { get; set; } = false;      //Friday 08:00-10:00
        public bool friSlot2 { get; set; } = false;      //Friday 11:00-13:00
        public bool friSlot3 { get; set; } = false;      //Friday None

        public bool satSlot1 { get; set; } = false;      //Saturday None
        public bool satSlot2 { get; set; } = false;      //Saturday None
        public bool satSlot3 { get; set; } = false;      //Saturday None

        public bool sunSlot1 { get; set; } = false;      //Sunday None
        public bool sunSlot2 { get; set; } = false;      //Sunday None
    
        public bool sunSlot3 { get; set; } = false;      //Sunday None


        public string monSlot1String { get; set; } = "Monday 08:00 - 10:00";
        public string monSlot2String { get; set; } = "Monday 11:00 - 13:00";
        public string monSlot3String { get; set; } = "Monday 14:00 - 16:00";

        public string tueSlot1String { get; set; } = "Tuesday 08:00 - 10:00";
        public string tueSlot2String { get; set; } = "Tuesday 11:00 - 13:00";
        public string tueSlot3String { get; set; } = "Tuesday 14:00 - 16:00";

        public string wedSlot1String { get; set; } = "Wednesday 08:00 - 10:00";
        public string wedSlot2String { get; set; } = "Wednesday 11:00 - 13:00";
        public string wedSlot3String { get; set; } = "Wednesday 14:00 - 16:00";

        public string thuSlot1String { get; set; } = "Thursday 08:00 - 10:00";
        public string thuSlot2String { get; set; } = "Thursday 11:00 - 13:00";
        public string thuSlot3String { get; set; } = "Thursday 14:00 - 16:00";

        public string friSlot1String { get; set; } = "Friday 08:00 - 10:00";
        public string friSlot2String { get; set; } = "Friday 11:00 - 13:00";
        public string friSlot3String { get; set; } = "Friday None";

        public string satSlot1String { get; set; } = "Saturday None";
    
        public string satSlot2String { get; set; } = "Saturday None";
    
        public string satSlot3String { get; set; } = "Saturday None";

        public string sunSlot1String { get; set; } = "Sunday None";
        public string sunSlot2String { get; set; } = "Sunday None";
        public string sunSlot3String { get; set; } = "Sunday None";



        public string SlotBooked { get; set; } = string.Empty;

        public int? EngineerId { get; set; } = 0;
































    }
}
