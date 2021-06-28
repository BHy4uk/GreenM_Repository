using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class ConcurrentLoginSession
    {
        public int LogSessId { get; set; }
        public int Hour { get; set; }
        public int MaximumConcurSess { get; set; }
        public int SessDurId { get; set; }
    }
}
