using System.Collections.Generic;
namespace DatabaseConn
{
    public class User
    {
        public int Id { get; set; }
        public ICollection<UserNoGoZone>UserNoGoZones { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}