using System;
using System.Collections.Generic;

namespace ConsoleApp1.Code1.Models
{
    internal class Contact
    {
        private static int _nextId = 1;

        private string _name;

        public Contact(string name, List<string> phoneNumbers, string address)
        {
            Id = _nextId++;
            Name = name;
            PhoneNumbers = phoneNumbers ?? new List<string>();
            Address = address;
        }

        public int Id { get; private set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ім'я не може бути порожнім.");
                _name = value;
            }
        }

        public List<string> PhoneNumbers { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            string phones = PhoneNumbers.Count > 0
                ? string.Join(", ", PhoneNumbers)
                : "(немає)";
            return $"[{Id}] {_name} | Тел: {phones} | Адреса: {Address}";
        }
    }
}
