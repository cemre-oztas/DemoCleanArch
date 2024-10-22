using CleanArch.Application.DTOs.User;
using CleanArch.Domain.Entities.Identity;
using DemoCleanArch.DTOs.User;

namespace CleanArch.Application.Abstractions.Services;

public interface IUserEntityService
{
    Task<CreateUserResponse> CreateAsync(CreateUser model);
    Task UpdateRefreshTokenAsync(
        string refreshToken,
        AppUser user,
        DateTime accessTokenDate,
        int addOnAccessTokenDate);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    Task<List<ListUser>> GetAllUsersAsync(int page, int size);
    int TotalUsersCount { get; }
    Task AssignRoleToUserAsnyc(string userId, string[] roles);
    Task<string[]> GetRolesToUserAsync(string userIdOrName);
}