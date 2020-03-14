using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSampleTest.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Color { get; set; }
    }
}