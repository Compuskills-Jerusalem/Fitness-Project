using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn
{
    public class UserContact
    {
        public int UserContactID { get; set; }

        public string ContactValue { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int ContactID { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
