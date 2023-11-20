namespace SimpleLibraryApp.Core.Aggregates.AuthAggregates;

public class UserRoleAssignment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime CreatedDate { get; set; }
}
