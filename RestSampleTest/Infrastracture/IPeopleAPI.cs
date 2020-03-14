using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSampleTest.Infrastracture
{
    interface IPeopleAPI
    {
        IEnumerable<Models.Person> Get();
        Models.Person Get(int id);
        IEnumerable<Models.Person> GetColor(string color);
    }
}
