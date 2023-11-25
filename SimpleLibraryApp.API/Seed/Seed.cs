using System.Data;
using Dapper;

namespace SimpleLibraryApp.API;

public class Seed
{
    public static async Task Create(IDbConnection connection) {
        using (var transaction = connection.BeginTransaction())
        {
            var sqlQueries = new List<string>
            {
                $@"SELECT * FROM ""seed"".""SeedForGenders""()",
                $@"SELECT * FROM ""seed"".""SeedForUsers""()",
                $@"SELECT * FROM ""seed"".""SeedForRoles""()",
                $@"SELECT * FROM ""seed"".""SeedForClaims""()",
                $@"SELECT * FROM ""seed"".""SeedForRoleClaimAssignment""()",
                $@"SELECT * FROM ""seed"".""SeedForUserRoleAssignment""()"
            };

            foreach (var sql in sqlQueries)
            {
                await connection.ExecuteScalarAsync<int>(sql);
            }
        }
    }
}
