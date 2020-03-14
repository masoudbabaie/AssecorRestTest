using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSampleTest.Models;

namespace RestSampleTest.Infrastracture
{
    interface IDataSource
    {
        IEnumerable<Person> LoadData();
        void AddData(Person person);

    }
}
