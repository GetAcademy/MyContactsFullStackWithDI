using MyContactsFullStack;
using MyContactsFullStack.Api;
using MyContactsFullStack.Model;

/*
1: Introdusere Dependency Injection-motor - dummy-eksempel
  - AddTransient
  - AddScoped
  - AddSingleton
2: Skulle gjerne gjort dette med PersonRepository, men den trenger ConnectionString
3: ConnectionString
  - config fil 
  - factory
  - singleton
4: Innføre DI for PersonRepository
5: Flytte mapping til egen klasse - extension metode WebApplication
  - beholde lambda-uttrykk
  - som metoder
  - med og uten IResult 
6: Eventuelt flytte ut kjerne-kode til eget prosjekt

 */

//var exampleSingleton = ExampleSingleton.Instance;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("MyDb");
services.AddSingleton(new MySqlConnectionFactory(connectionString));
services.AddScoped<PersonRepository>();
//services.AddScoped<ISomethingElse, MySomethingElse>();
//services.AddScoped<ISimpleLogger, MySimpleLogger>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.CreatePeopleEndpoints();
app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
            .ExecuteAsync(context)));
app.Run();

/*

var people = new List<Person>
{
    new Person("Per", "per@mail.com"),
    new Person("Pål", "paal@mail.com"),
    new Person("Espen", "espene@mail.com"),
};

app.MapGet("/people", () =>
{
    return people;
});
app.MapGet("/people/{id}", (Guid id) =>
{
    return people.SingleOrDefault(p => p.Id == id);
});
app.MapDelete("/people/{id}", (Guid id) =>
{
    var person = people.SingleOrDefault(p => p.Id == id);
    people.Remove(person);
});
app.MapPost("/people", (Person person) =>
{
    people.Add(person);
});
app.MapPut("/people", (Person person) =>
{
    var changePerson = people.SingleOrDefault(p => p.Id == person.Id);
    changePerson.Name = person.Name;
    changePerson.Email = person.Email;
}); 
 
 */
