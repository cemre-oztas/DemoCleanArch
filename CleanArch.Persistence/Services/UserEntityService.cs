using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.DTOs.User;
using CleanArch.Domain.Entities.Identity;
using DemoCleanArch.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Services;

public class UserEntityService : IUserEntityService
{
    readonly UserManager<AppUser> _userManager;

    public UserEntityService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponse> CreateAsync(CreateUser model)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            NameSurname = model.Username,
            UserName = model.Username,
            RefreshToken = model.RefreshToken,
        }, model.Password);

        CreateUserResponse response = new() { Succeeded = result.Succeeded };

        if (result.Succeeded)
            response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
        else
            foreach (var error in result.Errors)
                response.Message += $"{error.Code} - {error.Description}\n";

        return response;
    }

    public async Task UpdateRefreshTokenAsync(
        string refreshToken, AppUser user,
        DateTime accessTokenDate,
        int addOnAccessTokenDate)
    {
        if (user != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
            await _userManager.UpdateAsync(user);
        }
        else
            throw new Exception("Kullanıcı bulunamadı.");
    }

    public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("Kullanıcı bulunamadı."); 
        }
        
        if (string.IsNullOrEmpty(resetToken))
        {
            throw new Exception("Reset token geçersiz."); 
        }
        resetToken = System.Net.WebUtility.UrlDecode(resetToken);
        IdentityResult result = await _userManager.ResetPasswordAsync(
            user,
            resetToken,
            newPassword);

        if (result.Succeeded)
        {
            await _userManager.UpdateSecurityStampAsync(user);
        }
        else
        {
            throw new Exception("Şifre değişikliği başarısız oldu."); 
        }
    }


    public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
    {
        var users = await _userManager.Users
              .Skip(page * size)
              .Take(size)
              .ToListAsync();

        return users.Select(user => new ListUser
        {
            Id = user.Id,
            Email = user.Email,
            NameSurname = user.NameSurname,
            UserName = user.NameSurname
        }).ToList();
    }

    public int TotalUsersCount => _userManager.Users.Count();

    public async Task AssignRoleToUserAsnyc(string userId, string[] roles)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRolesAsync(user, roles);
        }
    }

    public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
    {
        AppUser user = await _userManager.FindByIdAsync(userIdOrName);
        if (user == null)
            user = await _userManager.FindByNameAsync(userIdOrName);

        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }
        return new string[] { };
    }
}
