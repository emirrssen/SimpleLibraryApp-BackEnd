namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public interface IAuthRepository
{
    Task<int> InsertUserAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
    Task<int> InsertUserRoleAssignmentAsync(UserRoleAssignment userRoleAssignment);
    Task<User> GetById(int id);
    Task<UserDetailsForProfile> GetDetailsForProfileById(int id);
}
