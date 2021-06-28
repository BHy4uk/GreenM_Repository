using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class UsersDevicesLogged
    {
        public UsersDevicesLogged()
        {
            UnexpectedLoggeds = new HashSet<UnexpectedLogged>();
        }

        public int LoggedId { get; set; }
        public string UserName { get; set; }
        public string DeviceName { get; set; }
        public DateTime LoginTs { get; set; }

        public virtual ICollection<UnexpectedLogged> UnexpectedLoggeds { get; set; }
    }
}
