using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class UsersRegistration
    {
        public UsersRegistration()
        {
            DevicesRegistrations = new HashSet<DevicesRegistration>();
        }

        public int UserRegId { get; set; }
        public int Year { get; set; }
        public int MonthId { get; set; }
        public int RegisteredUsers { get; set; }

        public virtual Month Month { get; set; }
        public virtual ICollection<DevicesRegistration> DevicesRegistrations { get; set; }
    }
}
