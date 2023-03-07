using MyContactsFullStack.Model;
using System;

namespace MyContactsFullStack.Api
{
    public static class PeopleApi
    {
        public static void CreatePeopleEndpoints(this WebApplication app)
        {
            app.MapGet("/people", GetAll);
            app.MapGet("/people/{id}",GetById);
            app.MapDelete("/people/{id}",Delete);
            app.MapPost("/people", Create);
            app.MapPut("/people", Update);
        }

        private static Task<IEnumerable<Person>> GetAll(PersonRepository personRepository)
        {
            return personRepository.ReadAll();
        }

        private static Task<Person> GetById(Guid id, PersonRepository personRepository)
        {
            return personRepository.ReadById(id);
        }

        private static Task<int> Create(Person person, PersonRepository personRepository)
        {
            return personRepository.Create(person);
        }

        private static Task<int> Update(Person person, PersonRepository personRepository)
        {
            return personRepository.Update(person);
        }

        private static Task<int> Delete(Guid id, PersonRepository personRepository)
        {
            return personRepository.Delete(id);
        }
    }
}
