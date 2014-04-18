using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataSchema
{
    public class Person
    {
        public virtual int Id { get; set; }
        
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool Gender { get; set; }
        public virtual string Address { get; set; }
        public virtual long PhoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        //public virtual ICollection<Relation> Relations { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }

    }

    
}
