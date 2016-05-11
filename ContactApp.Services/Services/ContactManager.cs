using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ContactApp.Services
{
    public class ContactManager: IContactManager
    {
        public void Archive(int id)
        {
            using (var db = new AppDbContext())
            {
                var contact = db.Contacts.SingleOrDefault(x => x.ID == id);
                contact.Archived = true;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new AppDbContext())
            {
                var contact = new Contact { ID = id };
                db.Contacts.Attach(contact);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        public bool Insert(Contact contact, out string message)
        {
            message = null;
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                }

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                message = String.Join("<br/>", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors.Select(e => e.ErrorMessage)));
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public IEnumerable<Contact> List()
        {
            using (var db = new AppDbContext())
            {
                return db.Contacts.ToList();
            }
        }
    }

    public interface IContactManager
    {
        bool Insert(Contact contact, out string message);

        IEnumerable<Contact> List();

        void Delete(int id);

        void Archive(int id);
    }
}