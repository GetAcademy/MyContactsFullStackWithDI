using System.Data.SqlClient;
using Dapper;
using MyContactsFullStack.Model;

namespace MyContactsFullStack
{
    internal class PersonRepository
    {
        private readonly MySqlConnectionFactory _sqlConnectionFactory;

        public PersonRepository(MySqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "SELECT Id, Name, Email FROM Person";
            return await conn.QueryAsync<Person>(sql);
        }

        public async Task<Person?> ReadById(Guid id)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "SELECT Id, Name, Email FROM Person WHERE Id = @Id";
            var people = await conn.QueryAsync<Person>(sql, new { Id = id });
            return people.SingleOrDefault();
        }

        public async Task<int> Create(Person person)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "INSERT INTO Person VALUES (@Id, @Name, @Email)";
            var rowsAffected = await conn.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Update(Person person)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = @"UPDATE Person 
                SET Name = @Name, 
                    Email = @Email 
                WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Delete(Person person)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = @"DELETE FROM Person WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Delete(Guid id)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = @"DELETE FROM Person WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }
    }
}
