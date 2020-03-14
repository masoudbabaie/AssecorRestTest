using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using RestSampleTest.Models;
using RestSampleTest.Infrastracture;


namespace RestSampleTest.Base
{
    public class MockPeopleRepository : IDataSource
    {
        private ColorsRepository colorRepository = ColorsRepository.Current;

        public void AddData(Person person)
        {
            
        }

        public IEnumerable<Person> LoadData()
        {
            List<Person> lstPeople = new List<Person>();
            
            
            // load data from diffrent datasources
            
            return lstPeople;
        }
    }
}