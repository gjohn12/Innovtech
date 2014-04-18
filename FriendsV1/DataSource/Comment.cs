using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSchema
{
    public class Comment
    {
        public virtual int Id {get; set;}
        public virtual int PersonId { get; set; }
        public virtual string Entry { get; set; }
        public virtual DateTime EntryDate {get; set;}
    }
}
