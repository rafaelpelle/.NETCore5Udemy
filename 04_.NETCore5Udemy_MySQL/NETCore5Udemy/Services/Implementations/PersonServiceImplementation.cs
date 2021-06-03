using NETCore5Udemy.Model;
using NETCore5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NETCore5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }


        // Get all registered Person
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Get a single registered Person
        public Person FindByID(long id)
        {
            Person person = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            return person;
        }

        // Create a single registered Person
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw;
            }
            return person;
        }


        // Update a single registered Person
        public Person Update(Person person)
        {
            Person result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }


        // Delete a single registered Person
        public void Delete(long id)
        {
            Person result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
