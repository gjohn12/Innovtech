using FriendsV1.Models;
//using DataSchema;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FriendsV1.Infrastructure
{
    public class FriendsDb : DbContext//, IFriendsDataSource
    {
        public FriendsDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Relation> Relations { get; set; }

       
    }
}