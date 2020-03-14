using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSampleTest.Models;

//============= Masoud Babaei ==================


namespace RestSampleTest.Controllers
{
    public class PersonsController : ApiController,Infrastracture.IPeopleAPI
    {
        
        private Infrastracture.IDataSource repository;

        private ColorsRepository colorRepository = ColorsRepository.Current;

        /// <summary>
        /// Get all people info
        /// </summary>
        /// <returns>List of Person</returns>
        // GET api/<controller>
        public IEnumerable<Models.Person> Get()
        {
           
            return GetPeople(new Base.PeopleRepository()); //Main
            //return LoadPeople(new Base.MockPeopleRepository()); //Mock UnitTest

        }

        /// <summary>
        /// Get spacified person
        /// </summary>
        /// <param name="id">id is the row number of the datasource</param>
        /// <returns>person</returns>
        // GET api/<controller>/5
        public Models.Person Get(int id)
        {            
            return GetPerson(new Base.PeopleRepository(), id); //Main
            //return LoadPerson(new Base.MockPeopleRepository(), id); //Mock

        }


        /// <summary>
        /// Get people with same favorite Color
        /// </summary>
        /// <param name="color">Specify a Color Name</param>
        /// <returns>List of Person</returns>
        [Route("api/Persons/Color/{color}")]
        [HttpGet]
        public IEnumerable<Models.Person> GetColor(string color)
        {           

            return GetPeopleByColor(new Base.PeopleRepository(),color); //Main
            //return LoadPeopleByColor(new Base.MockPeopleRepository(),color); //Mock 
        }



        // POST api/<controller>
        public void Post(Person person)
        {
            AddPerson(new Base.PeopleRepository(), person); //Main
            //AddPerson(new Base.MockPeopleRepository(), person); //Mock 
        }




        private void AddPerson(Infrastracture.IDataSource newRepository, Person NewPerson)
        {
            repository = newRepository;
            repository.AddData(NewPerson);
            
        }



        private List<Person> GetPeople(Infrastracture.IDataSource newRepository)
        {
            repository = newRepository;
            List<Models.Person> lstPeople = (List<Models.Person>)repository.LoadData();

            return lstPeople;
        }

        private Person GetPerson(Infrastracture.IDataSource newRepository, int id)
        {
            repository = newRepository;
            List<Models.Person> lstPeople = (List<Models.Person>)repository.LoadData();

            return lstPeople.Where(p => p.ID == id).FirstOrDefault();
        }


        private List<Person> GetPeopleByColor(Infrastracture.IDataSource newRepository, string color)
        {
            repository = newRepository;
            List<Models.Person> lstPeople = (List<Models.Person>)repository.LoadData().Where(p => p.Color == color).ToList();

            return lstPeople;
        }




        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}