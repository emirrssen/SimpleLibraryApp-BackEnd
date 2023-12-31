﻿namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public interface IAuthRepository
{
    Task<int> InsertUserAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
    Task<int> InsertUserRoleAssignmentAsync(UserRoleAssignment userRoleAssignment);
    Task<User> GetByIdAsync(int id);
    Task<UserDetailsForProfile> GetDetailsForProfileByIdAsync(int id);
    Task<int> ChangePasswordByUserIdAsync(int userId, string newPassword);
    Task<List<UserDetailsForAdmin>> GetUserDetailsByNameOrEmail(string searchText);
    Task<int> ChangeEmailByUserIdAsync(int userId, string newEmail);
    Task<int> DeleteAccountByUserIdAsync(int userId);
}
