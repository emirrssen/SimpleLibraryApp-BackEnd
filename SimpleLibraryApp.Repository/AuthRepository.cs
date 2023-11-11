using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;

namespace SimpleLibraryApp.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly IDbConnection _connection;

    public AuthRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@email", email, DbType.String);

        var sql = $@"SELECT * FROM ""Users_GetByEmail""(@email)";
        var result = await _connection.QuerySingleOrDefaultAsync<User>(sql, parameters);

        return result;
    }

    public async Task<int> InsertUserAsync(User user)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@genderid", user.GenderId, DbType.Int32);
        parameters.Add("@firstname", user.FirstName, DbType.String);
        parameters.Add("@lastname", user.LastName, DbType.String);
        parameters.Add("@dateofbirth", user.DateOfBirth, DbType.Date);
        parameters.Add("@nationalityid", user.NationalityId, DbType.String);
        parameters.Add("@email", user.Email, DbType.String);
        parameters.Add("@password", user.Password, DbType.String);

        var sql = $@"SELECT *  FROM ""Users_Insert""(@genderid, @firstname, @lastname, @dateofbirth, @nationalityid, @email, @password)";
        var result = await _connection.QuerySingleOrDefaultAsync<int>(sql, parameters);

        return result;
    }
}
