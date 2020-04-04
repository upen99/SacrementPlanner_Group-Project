using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class SacrementMeetings
    {
        public int SacrementMeetingsId { get; set; }
        public DateTime Date { get; set; }
        public string SpeakerTopic { get; set; }
        public string ConductingLeader { get; set; }
        public string OpenignSong { get; set; }
        public string OpeningPrayer { get; set; }
        public string IntermediateHymn { get; set; }
        public string ClosingPrayer { get; set; }
        public int MembersId { get; set; }
        public Members MembersName { get; set; }
    }
}
