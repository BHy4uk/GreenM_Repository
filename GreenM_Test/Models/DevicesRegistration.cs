using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class DevicesRegistration
    {
        public int DeviceRegId { get; set; }
        public int Year { get; set; }
        public int MonthId { get; set; }
        public string Type { get; set; }
        public int RegisteredUsers { get; set; }
        public int UsersRegId { get; set; }

        public virtual Month Month { get; set; }
        public virtual UsersRegistration MonthNavigation { get; set; }
    }
}
