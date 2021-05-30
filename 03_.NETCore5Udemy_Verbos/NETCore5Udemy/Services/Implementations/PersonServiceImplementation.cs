using NETCore5Udemy.Model;
using System.Collections.Generic;
using System.Threading;

namespace NETCore5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = MockPerson();
                people.Add(person);
            }
            return people;
        }

        public Person FindByID(long id)
        {
            Person person = MockPerson();
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson()
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person"+count,
                LastName = "Last Name",
                Address = "Florianópolis - SC",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
