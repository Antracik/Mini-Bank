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
        Task SignInAsync(UserDbRepoModel user, bool isPersistent);
        Task RefreshSignInAsync(UserDbRepoModel user);
        Task<string> GetUserEmailAsync(UserDbRepoModel user);
        Task<string> GetUserIdAsync(UserDbRepoModel user);
        Task<string> GetUserPhoneNumberAsync(UserDbRepoModel user);
        Task<string> GetUserNameAsync(UserDbRepoModel user);
        Task<string> GenerateUserEmailConfirmationTokenAsync(UserDbRepoModel user);
        Task<string> GeneratePasswordResetTokenAsync(UserDbRepoModel user);
        Task<string> GetAuthenticatorKeyAsync(UserDbRepoModel user);
        Task<int> CountValidRecoveryCodesAsync(UserDbRepoModel user);
        Task<bool> IsUserEmailConfirmedAsync(UserDbRepoModel user);
        Task<bool> IsUserTwoFactorEnabledAsync(UserDbRepoModel user);
        Task<bool> HasPasswordAsync(UserDbRepoModel user);
        Task<bool> IsTwoFactorClientRememberedAsync(UserDbRepoModel user);
        Task<bool> VerifyTwoFactorTokenAsync(UserDbRepoModel user, string token);
        Task<bool> VerifyTwoFactorTokenAsync(UserDbRepoModel user, string tokenProivder ,string token);
        Task<UserDbRepoModel> GetTwoFactorAuthenticationUserAsync();
        Task<UserDbRepoModel> GetUserByIdAsync(string id);
        Task<UserDbRepoModel> GetUserByEmailAsync(string email);
        Task<UserDbRepoModel> GetUserAsync(ClaimsPrincipal principal);
        Task<IdentityResult> AddUserLoginAsync(UserDbRepoModel user, ExternalLoginInfo info);
        Task<IdentityResult> SetTwoFactorEnabledAsync(UserDbRepoModel user, bool enabled);
        Task<IdentityResult> SetUserEmailAsync(UserDbRepoModel user, string email);
        Task<IdentityResult> SetUserPhoneNumberAsync(UserDbRepoModel user, string phoneNumber);
        Task<IdentityResult> ChangePasswordAsync(UserDbRepoModel user, string oldPassword, string newPassword);
        Task<IdentityResult> CreateUserAsync(UserDbRepoModel user, string password = null);
        Task<IdentityResult> ConfirmUserEmailAsync(UserDbRepoModel user, string code);
        Task<IdentityResult> AddPasswordAsync(UserDbRepoModel user, string password);
        Task<IdentityResult> ResetPasswordAsync(UserDbRepoModel user, string token, string newPassword);
        Task<IdentityResult> ResetAuthenticatorKeyAsync(UserDbRepoModel user);
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(UserDbRepoModel user, int number);
        Task<IEnumerable<AuthenticationScheme>> GetExternalLoginAuthenticationSchemesAsync();
    }
}
