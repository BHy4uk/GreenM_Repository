using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class Month
    {
        public Month()
        {
            DevicesRegistrations = new HashSet<DevicesRegistration>();
        }

        public int MonthId { get; set; }
        public string Month1 { get; set; }

        public virtual UsersRegistration UsersRegistration { get; set; }
        public virtual ICollection<DevicesRegistration> DevicesRegistrations { get; set; }
    }
}
