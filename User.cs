using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbObjects.BL
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Email> EmailAddresses { get; set; }

        public User()
        {
            EmailAddresses = new List<Email>();
        }

        public User(int id, string first, string last)
        {
            this.Id = id;
            this.FirstName = first;
            this.LastName = last;
            EmailAddresses = new List<Email>();
        }
    }
}
