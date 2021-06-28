using System;
using System.Collections.Generic;

#nullable disable

namespace GreenM_Test.Models
{
    public partial class UnexpectedLogged
    {
        public int UnexpectedId { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public DateTime LoginTs { get; set; }
        public int LoggedId { get; set; }

        public virtual UsersDevicesLogged Logged { get; set; }
    }
}
