using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StacWebApp.Models
{
    public class ContactModel
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime ContactTime { get; set; }

        public string Comments { get; set; }
    }
}
