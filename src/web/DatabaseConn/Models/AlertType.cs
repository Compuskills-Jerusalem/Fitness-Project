using FitnessProject.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn.Models
{
    public class AlertType
    {
        public int AlertTypeId { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public bool EMail { get; set; }
        public bool Text { get; set; }
        public bool Push { get; set; }
    }
}
