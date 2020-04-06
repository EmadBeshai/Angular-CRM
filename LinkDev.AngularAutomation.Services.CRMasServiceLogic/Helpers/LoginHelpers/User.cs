using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Helpers
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public enum UserRole
    {
        NORMAL,
        AUDITOR,
        ADMIN
    }
}
