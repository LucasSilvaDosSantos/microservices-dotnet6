using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public IEnumerable<Person> FindAll()
        {
            var people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        public Person FindById(long id)
        {
            /*Mock*/
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name",
                LastName = "Person LastName",
                Address = "Person Address",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            /*ToDo retrieves the data that has been updated */
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Person Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

    }
}
