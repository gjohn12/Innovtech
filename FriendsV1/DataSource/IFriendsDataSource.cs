using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSchema
{

    public interface IFriendsDataSource
    {
        IQueryable<Person> Persons { get; }
        IQueryable<Comment> Comments { get; }
        void Save();
    }   
    
}
