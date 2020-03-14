using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;

using RestSampleTest.Models;
using RestSampleTest.Infrastracture;

namespace RestSampleTest.Base
{
    public class PeopleRepository : IDataSource
    {
        private ColorsRepository colorRepository = ColorsRepository.Current;

        public void AddData(Person person)
        {
            string filePath = string.Empty;
            
            filePath = GetFilePath();//Load from Web.config

            string NewData ="\r\n"+  person.LastName + "," + person.Name + "," + person.ZipCode + " " + person.City + "," + colorRepository.GetFarbe(person.Color).ID.ToString();
                

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, NewData);
            }

            File.AppendAllText(filePath, NewData);
        }

        /// <summary>
        /// Load Data from CSV File
        /// </summary>
        /// <returns>List of Person</returns>
        public IEnumerable<Person> LoadData()
        {
            List<Person> lstPeople = new List<Person>();
            int i = 0;            
            string filePath = string.Empty;

            
            filePath = GetFilePath();//Load from Web.config

            //Read the contents of CVS file
            string csvData = System.IO.File.ReadAllText(filePath);
            //Execute a loop over the rows
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    i++;
                    lstPeople.Add(new Person
                    {
                        ID = i,
                        LastName = row.Split(',')[0],
                        Name = row.Split(',')[1],
                        City = row.Split(',')[2].Trim().Substring(6, row.Split(',')[2].Length-7),
                        ZipCode = row.Split(',')[2].Trim().Substring(0,5),
                        Color = colorRepository.GetFarbe(int.Parse(row.Split(',')[3])).FarbeName
                    });
                }
            }

            
            return lstPeople;
        }

        private string GetFilePath()
        {
            
            NameValueCollection myKeys = ConfigurationManager.AppSettings;
            return System.Web.HttpContext.Current.Server.MapPath(myKeys["CSVFilePath"]);//Load from Web.config
        }
    }
}