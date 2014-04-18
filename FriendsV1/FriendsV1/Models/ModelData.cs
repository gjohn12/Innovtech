using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendsV1.Models
{
    public class PersonReceive
    {
        //public virtual int Id { get; set; }
        //[DataMember(IsRequired)]
        [Required(ErrorMessage="Name required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

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
    public class Relation
    {
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual int ContactId { get; set; }
    }

    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual string Entry { get; set; }
        public virtual DateTime EntryDate { get; set; }
    }


   
}