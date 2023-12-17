using System.Data;
using Dapper;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;

namespace SimpleLibraryApp.Repository.Dapper;

public class AuthRepository : IAuthRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public AuthRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public Task<int> ChangePasswordByUserIdAsync(int userId, string newPassword)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@user_id", userId, DbType.Int32);
        parameters.Add("@new_password", newPassword, DbType.String);

        var sql = $@"SELECT * FROM ""public"".""Users_UpdatePasswordByUserId""(@user_id, @new_password)";
        var result = _connection.QuerySingleOrDefaultAsync<int>(sql, parameters, transaction: _transaction);

        return result;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", id, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""Users_GetById""(@id)";
        var result = await _connection.QuerySingleOrDefaultAsync<User>(sql, parameters);

        return result;
    }

    public async Task<UserDetailsForProfile> GetDetailsForProfileByIdAsync(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", id, DbType.Int32);

        var sql = $@"SELECT * FROM ""public"".""Users_GetDetailsForProfileById""(@id)";
        var result = await _connection.QuerySingleOrDefaultAsync<UserDetailsForProfile>(sql, parameters);

        return result;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@email", email, DbType.String);

        var sql = $@"SELECT * FROM ""Users_GetByEmail"" (@email)";
        var result = await _connection.QuerySingleOrDefaultAsync<User>(sql, parameters);

        return result;
    }

    public async Task<int> InsertUserAsync(User user)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@genderid", user.GenderId, DbType.Int32);
        parameters.Add("@firstname", user.FirstName, DbType.String);
        parameters.Add("@lastname", user.LastName, DbType.String);
        parameters.Add("@dateofbirth", user.DateOfBirth, DbType.Object);
        parameters.Add("@nationalityid", user.NationalityId, DbType.String);
        parameters.Add("@email", user.Email, DbType.String);
        parameters.Add("@password", user.Password, DbType.String);

        var sql = $@"SELECT *  FROM ""Users_Insert"" (@genderid, @firstname, @lastname, @dateofbirth, @nationalityid, @email, @password)";
        var result = await _connection.QuerySingleOrDefaultAsync<int>(sql, parameters, transaction: _transaction);

        return result;
    }

    public async Task<int> InsertUserRoleAssignmentAsync(UserRoleAssignment userRoleAssignment)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@roleid", userRoleAssignment.RoleId, DbType.Int32);
        parameters.Add("@userid", userRoleAssignment.UserId, DbType.Int32);
        parameters.Add("@insertdate", userRoleAssignment.CreatedDate, DbType.DateTime);

        var sql = $@"SELECT * FROM ""UserRoleAssignment_Insert"" (@roleid, @userid, @insertdate)";
        var result = await _connection.QuerySingleOrDefaultAsync<int>(sql, parameters, transaction: _transaction);

        return result;
    }
}
