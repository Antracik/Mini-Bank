using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Services.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Services.Services
{
    public interface IUserService
    {
        void UpdateUser(UserServiceModel user);
        string GetUserId(ClaimsPrincipal principal);
        string GetUserName(ClaimsPrincipal principal);
        bool DeleteUser(int id);
        bool IsSignedIn(ClaimsPrincipal principal);
        bool IsUserSignedInAsAdmin(ClaimsPrincipal User);
        UserServiceModel GetUserByEmail(string email);
        UserServiceModel GetUserById(int id, bool includeRegistrant = false);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
        IEnumerable<UserServiceModel> GetAllUsers();
        IEnumerable<UserServiceModel> GetAllUsers(string orderBy, string filter);
        Task SignOutAsync();
        Task ForgetTwoFactorClientAsync();
        Task SignInAsync(UserEntityModel user, bool isPersistent);
        Task RefreshSignInAsync(UserEntityModel user);
        Task<string> GetUserEmailAsync(UserEntityModel user);
        Task<string> GetUserIdAsync(UserEntityModel user);
        Task<string> GetUserPhoneNumberAsync(UserEntityModel user);
        Task<string> GetUserNameAsync(UserEntityModel user);
        Task<string> GenerateUserEmailConfirmationTokenAsync(UserEntityModel user);
        Task<string> GeneratePasswordResetTokenAsync(UserEntityModel user);
        Task<string> GetAuthenticatorKeyAsync(UserEntityModel user);
        Task<int> CountValidRecoveryCodesAsync(UserEntityModel user);
        Task<bool> IsUserInRoleAsync(int userId, string roleName);
        Task<bool> IsUserEmailConfirmedAsync(ClaimsPrincipal User);
        Task<bool> IsUserEmailConfirmedAsync(UserEntityModel user);
        Task<bool> IsUserTwoFactorEnabledAsync(UserEntityModel user);
        Task<bool> HasPasswordAsync(UserEntityModel user);
        Task<bool> IsTwoFactorClientRememberedAsync(UserEntityModel user);
        Task<bool> VerifyTwoFactorTokenAsync(UserEntityModel user, string token);
        Task<bool> VerifyTwoFactorTokenAsync(UserEntityModel user, string tokenProivder ,string token);
        Task<UserEntityModel> GetTwoFactorAuthenticationUserAsync();
        Task<UserEntityModel> GetUserByIdAsync(string id);
        Task<UserEntityModel> GetUserByEmailAsync(string email);
        Task<UserEntityModel> GetUserAsync(ClaimsPrincipal principal);
        Task<IdentityResult> AddUserLoginAsync(UserEntityModel user, ExternalLoginInfo info);
        Task<IdentityResult> SetTwoFactorEnabledAsync(UserEntityModel user, bool enabled);
        Task<IdentityResult> SetUserEmailAsync(UserEntityModel user, string email);
        Task<IdentityResult> SetUserPhoneNumberAsync(UserEntityModel user, string phoneNumber);
        Task<IdentityResult> ChangePasswordAsync(UserEntityModel user, string oldPassword, string newPassword);
        Task<IdentityResult> CreateUserAsync(UserEntityModel user, string password = null);
        Task<IdentityResult> ConfirmUserEmailAsync(UserEntityModel user, string code);
        Task<IdentityResult> AddPasswordAsync(UserEntityModel user, string password);
        Task<IdentityResult> ResetPasswordAsync(UserEntityModel user, string token, string newPassword);
        Task<IdentityResult> ResetAuthenticatorKeyAsync(UserEntityModel user);
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(UserEntityModel user, int number);
        Task<IEnumerable<AuthenticationScheme>> GetExternalLoginAuthenticationSchemesAsync();
    }
}
