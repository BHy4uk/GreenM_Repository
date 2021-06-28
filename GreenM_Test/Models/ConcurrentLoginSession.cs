using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class ConcurrentLoginSession
    {
        public int LogSessId { get; set; }
        public DateTime Hour { get; set; }
        public int MaxConcurrSessions { get; set; }
        public int SessId { get; set; }

        public virtual TotalAccumulatedDuration Sess { get; set; }
    }
}
