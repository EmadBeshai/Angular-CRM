using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Helpers
{
    public class UserRepository
    {
        public List<User> TestUsers;
        public UserRepository()
        {
            TestUsers = new List<User>();
            TestUsers.Add(new User() { Username = "Test1", Password = "Pass1" });
            TestUsers.Add(new User() { Username = "Test2", Password = "Pass2" });
            TestUsers.Add(new User() { Username = "Test3", Password = "Pass3" });
        }
        public User GetUser(string username)
        {
            try
            {
                return TestUsers.First(user => user.Username.Equals(username));
            }
            catch
            {
                return null;
            }
        }
    }
}
