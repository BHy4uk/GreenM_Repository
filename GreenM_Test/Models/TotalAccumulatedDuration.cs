using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class TotalAccumulatedDuration
    {
        public TotalAccumulatedDuration()
        {
            ConcurrentLoginSessions = new HashSet<ConcurrentLoginSession>();
        }

        public int SessDurId { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int TotalSessionDurationForHour { get; set; }
        public int TotalSessionDuration { get; set; }

        public virtual ICollection<ConcurrentLoginSession> ConcurrentLoginSessions { get; set; }
    }
}
