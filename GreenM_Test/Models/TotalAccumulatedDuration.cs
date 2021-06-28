using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class TotalAccumulatedDuration
    {
        public int SessDurId { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int TotalSessionDurationForHour { get; set; }
        public int TotalSessionDuration { get; set; }
    }
}
