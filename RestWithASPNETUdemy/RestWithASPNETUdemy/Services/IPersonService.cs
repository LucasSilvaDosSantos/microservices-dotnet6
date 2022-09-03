using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        IEnumerable<Person> FindAll();
        Person Update(Person id);
        void Delete(long id);
    }
}
