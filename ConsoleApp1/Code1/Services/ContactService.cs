using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Code1.Models;

namespace ConsoleApp1.Code1.Services
{
    internal class ContactService
    {
        private List<Contact> _contacts = new List<Contact>();

        public bool IsPhoneDuplicate(string phone)
        {
            return _contacts.Any(c => c.PhoneNumbers.Contains(phone));
        }

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id); //поверне null якщо нема
        }

        public bool UpdateById(int id, string newName, string newAddress)
        {
            Contact contact = GetById(id);
            if (contact == null) return false;

            contact.Name = newName;
            contact.Address = newAddress;
            return true;
        }

        public bool UpdateByName(string name, string newName, string newAddress)
        {
            Contact contact = _contacts.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null) return false;

            contact.Name = newName;
            contact.Address = newAddress;
            return true;
        }

        public bool Delete(int id)
        {
            Contact contact = GetById(id);
            if (contact == null) return false;

            _contacts.Remove(contact);
            return true;
        }

        public List<Contact> Search(string query)
        {
            string q = query.ToLower();
            return _contacts
                .Where(c =>
                    c.Name.ToLower().Contains(q) ||
                    c.PhoneNumbers.Any(p => p.Contains(q)))
                .ToList();
        }
    }
}
