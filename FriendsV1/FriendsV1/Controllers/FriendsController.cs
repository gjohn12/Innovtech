//using DataSchema;
using FriendsV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FriendsV1.Controllers
{
    public class FriendsController : ApiController
    {
        FriendsV1.Infrastructure.FriendsDb db = new Infrastructure.FriendsDb();
        // GET api/friends
        public IEnumerable<Person> Get([FromUri]string InName)
        {
            IEnumerable<Person> x = db.Persons.Where(s => (s.FirstName == InName || s.LastName == InName) == true).Select(v => v).ToList<Person>(); ;
            return x;
           
        }

        // GET api/friends/5
        public Person Get(int id)
        {
            Person x = db.Persons.Where(s => (s.Id == id) == true).Select(v => v).First<Person>(); ;
            return x;
        }

        //// POST api/friends
        //public void Post([FromBody]string value)
        //{
        //}
        public HttpResponseMessage Post(PersonReceive PR)
        {
            if (ModelState.IsValid)
            {
                Person p = new Person();
                p.FirstName = PR.FirstName;
                p.LastName = PR.LastName;
                p.Gender = PR.Gender;
                p.Address = PR.Address;
                p.PhoneNumber = PR.PhoneNumber;
                p.EmailAddress = PR.EmailAddress;
                p.UserName = PR.UserName;
                p.Password = PR.Password;

                List<Person> x = db.Persons.Where(s => s.UserName == PR.UserName).Select(v => v).ToList<Person>();

                if (x.Count == 0)
                {
                    db.Persons.Add(p);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"User already exists");
                }

                
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
           
        }

        // PUT api/friends/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        public HttpResponseMessage Put(PersonReceive PR)
        {
             if (ModelState.IsValid)
            {
                Person p = new Person();
                p.FirstName = PR.FirstName;
                p.LastName = PR.LastName;
                p.Gender = PR.Gender;
                p.Address = PR.Address;
                p.PhoneNumber = PR.PhoneNumber;
                p.EmailAddress = PR.EmailAddress;
                p.UserName = PR.UserName;
                p.Password = PR.Password;

                List<Person> x = db.Persons.Where(s => s.UserName == PR.UserName).Select(v => v).ToList<Person>();

                if (x.Count == 0)
                {
                    db.Persons.Add(p);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    x[0].FirstName = PR.FirstName;
                    x[0].LastName = PR.LastName;
                    x[0].Gender = PR.Gender;
                    x[0].Address = PR.Address;
                    x[0].PhoneNumber = PR.PhoneNumber;
                    x[0].EmailAddress = PR.EmailAddress;
                    x[0].UserName = PR.UserName;
                    x[0].Password = PR.Password;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
             else
             {
                 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
             }
        }

        // DELETE api/friends/5
        public HttpResponseMessage Delete(int id)
        {
            Person x = db.Persons.Where(s => (s.Id == id) == true).Select(v => v).First<Person>();
           //Delete comments, relations
            db.Persons.Remove(x);
            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete([FromUri]string name)
        {
            Person x = db.Persons.Where(s => (s.UserName == name) == true).Select(v => v).First<Person>();
            //Delete comments, relations
            db.Persons.Remove(x);
            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
