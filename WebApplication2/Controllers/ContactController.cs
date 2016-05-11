using ContactApp.Models;
using ContactApp.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactApp.Controllers
{
    public class ContactController : ApiController
    {
        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        private IContactManager _contactManager;

        [HttpPost]
        public dynamic Create([FromBody]Contact contact)
        {
            string message;
            var success = _contactManager.Insert(contact, out message);

            return new { Success = success, Message = message };
        }

        [HttpGet]
        public dynamic Get()
        {
            var items = _contactManager.List();
            return new { items = items };
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _contactManager.Delete(id);
        }

        [HttpPut]
        public void Archive(int id)
        {
            _contactManager.Archive(id);
        }

    }
}
