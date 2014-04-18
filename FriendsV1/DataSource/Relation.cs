using DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSchema
{
    public class Relation
    {
        public virtual int Id { get; set; }
        public virtual int PersonId  { get; set; }
        public  virtual int ContactId  { get; set; }
    }
}
