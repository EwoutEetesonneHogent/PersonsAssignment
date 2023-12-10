using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsAssignment.Domain.Model
{
    public class PersonIdArgs: EventArgs
    {
        public PersonIdArgs(int id)
        {
            Id = id;
        }

        public int Id
        {
        get; private set; }

    }
}
