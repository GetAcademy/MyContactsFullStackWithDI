using MyContactsFullStack.Model;
using System;

namespace MyContactsFullStack.Api
{
    public static class PeopleApi
    {
        public static void CreatePeopleEndpoints(this WebApplication app)
        {
            app.MapGet("/people", GetAll);
            app.MapGet("/people/{id}", GetById);
            app.MapDelete("/people/{id}", Delete);
            app.MapPost("/people", Create);
            app.MapPut("/people", Update);
        }

        private static async Task<IResult> GetAll(PersonRepository personRepository)
        {
            try
            {
                return Results.Ok(await personRepository.ReadAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetById(Guid id, PersonRepository personRepository)
        {
            try
            {
                var person = await personRepository.ReadById(id);
                if (person == null) return Results.NotFound();
                return Results.Ok(person);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Create(Person person, PersonRepository personRepository)
        {
            try
            {
                return Results.Ok(personRepository.Create(person));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Update(Person person, PersonRepository personRepository)
        {
            try
            {
                return Results.Ok(personRepository.Update(person));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Delete(Guid id, PersonRepository personRepository)
        {
            try
            {
                return Results.Ok(personRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
