using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn.Identity
{
    class UserRole : IdentityRole 
    {
        public UserRole() : base() { }
        public UserRole(string name) : base(name) { }
        // extra properties here 
    }
}
