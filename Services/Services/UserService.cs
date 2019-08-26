using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDbRepoModel> _userManager;
        private readonly SignInManager<UserDbRepoModel> _signInManager;
        private readonly IDateService _dateService;

        public UserService(UnitOfWork unitOfWork,
                            UserManager<UserDbRepoModel> userManager,
                            SignInManager<UserDbRepoModel> signInManager,
                            IMapper mapper,
                            IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _dateService = dateService;
        }

        public async Task<IdentityResult> CreateUserAsync(UserDbRepoModel user, string password = null)
        {
            _dateService.SetDateCreatedNow(ref user);
            IdentityResult res;
            if (password != null)
            {
                res = await _userManager.CreateAsync(user, password);
            }
            else
            {
                res = await _userManager.CreateAsync(user);
            }

            return res;
        }

        public Task<string> GenerateUserEmailConfirmationTokenAsync(UserDbRepoModel user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public bool DeleteUser(int id)
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userRepo = _unitOfWork.GetRepository<UserDbRepoModel>();

            var userEntity = userRepo.Get(user => user.Id == id, null, "Registrant").FirstOrDefault();

            if (userEntity.Registrant != null)
            {
                return false;
            }

            userRepo.Delete(id);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userEntities = _unitOfWork.GetRepository<UserDbRepoModel>().Get().ToList();

            var userModels = _mapper.Map<List<UserServiceModel>>(userEntities);

            return userModels;
        }

        public UserServiceModel GetUserByEmail(string email)
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Email == email).FirstOrDefault();

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel;
        }

        public UserServiceModel GetUserById(int id, bool includeRegistrant = false)
        {
            var userEntity = new UserDbRepoModel();

            _unitOfWork.Add<UserDbRepoModel>();

            if (includeRegistrant)
            {
                userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Id == id, null, "Registrant").FirstOrDefault();
            }
            else
            {
                userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().GetById(id);
            }

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel;
        }

        public void UpdateUser(UserServiceModel user)
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userEntity = _mapper.Map<UserDbRepoModel>(user);

            _dateService.SetDateEditedNow(ref userEntity);

            _unitOfWork.GetRepository<UserDbRepoModel>().Update(userEntity);
            _unitOfWork.Save();

        }

        public bool IsUserSignedInAsAdmin(ClaimsPrincipal User)
        {
            return (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"));
        }

        public Task<IEnumerable<AuthenticationScheme>> GetExternalLoginAuthenticationSchemesAsync()
        {
            return _signInManager.GetExternalAuthenticationSchemesAsync();
        }

        public Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task<UserDbRepoModel> GetTwoFactorAuthenticationUserAsync()
        {
            return _signInManager.GetTwoFactorAuthenticationUserAsync();
        }

        public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
        {
            return _signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
        }

        public Task<UserDbRepoModel> GetUserByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<IdentityResult> ConfirmUserEmailAsync(UserDbRepoModel user, string code)
        {
            return _userManager.ConfirmEmailAsync(user, code);
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            return _signInManager.GetExternalLoginInfoAsync();
        }

        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
        {
            return _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
        }

        public Task<IdentityResult> AddUserLoginAsync(UserDbRepoModel user, ExternalLoginInfo info)
        {
            return _userManager.AddLoginAsync(user, info);
        }

        public Task SignInAsync(UserDbRepoModel user, bool isPersistent)
        {
            return _signInManager.SignInAsync(user, isPersistent);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public Task<UserDbRepoModel> GetUserByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<bool> IsUserEmailConfirmedAsync(UserDbRepoModel user)
        {
            return _userManager.IsEmailConfirmedAsync(user);
        }

        public Task<string> GeneratePasswordResetTokenAsync(UserDbRepoModel user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<IdentityResult> ResetPasswordAsync(UserDbRepoModel user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public Task<UserDbRepoModel> GetUserAsync(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            return _userManager.GetUserId(principal);
        }

        public Task<bool> IsUserTwoFactorEnabledAsync(UserDbRepoModel user)
        {
            return _userManager.GetTwoFactorEnabledAsync(user);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(UserDbRepoModel user, bool enabled)
        {
            return _userManager.SetTwoFactorEnabledAsync(user, enabled);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(UserDbRepoModel user, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, token);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(UserDbRepoModel user, string tokenProvider, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public Task<string> GetUserIdAsync(UserDbRepoModel user)
        {
            return _userManager.GetUserIdAsync(user);
        }

        public Task<int> CountValidRecoveryCodesAsync(UserDbRepoModel user)
        {
            return _userManager.CountRecoveryCodesAsync(user);
        }

        public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(UserDbRepoModel user, int number)
        {
            return _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public Task<string> GetAuthenticatorKeyAsync(UserDbRepoModel user)
        {
            return _userManager.GetAuthenticatorKeyAsync(user);
        }

        public Task<string> GetUserEmailAsync(UserDbRepoModel user)
        {
            return _userManager.GetEmailAsync(user);
        }

        public Task<IdentityResult> ResetAuthenticatorKeyAsync(UserDbRepoModel user)
        {
            return _userManager.ResetAuthenticatorKeyAsync(user);
        }

        public Task<bool> HasPasswordAsync(UserDbRepoModel user)
        {
            return _userManager.HasPasswordAsync(user);
        }

        public Task<IdentityResult> ChangePasswordAsync(UserDbRepoModel user, string oldPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public Task RefreshSignInAsync(UserDbRepoModel user)
        {
            return _signInManager.RefreshSignInAsync(user);
        }

        public Task<string> GetUserPhoneNumberAsync(UserDbRepoModel user)
        {
            return _userManager.GetPhoneNumberAsync(user);
        }

        public Task<string> GetUserNameAsync(UserDbRepoModel user)
        {
            return _userManager.GetUserNameAsync(user);
        }

        public Task<IdentityResult> SetUserEmailAsync(UserDbRepoModel user, string email)
        {
            return _userManager.SetEmailAsync(user, email);
        }

        public Task<IdentityResult> SetUserPhoneNumberAsync(UserDbRepoModel user, string phoneNumber)
        {
            return _userManager.SetPhoneNumberAsync(user, phoneNumber);
        }

        public Task<IdentityResult> AddPasswordAsync(UserDbRepoModel user, string password)
        {
            return _userManager.AddPasswordAsync(user, password);
        }

        public Task<bool> IsTwoFactorClientRememberedAsync(UserDbRepoModel user)
        {
            return _signInManager.IsTwoFactorClientRememberedAsync(user);
        }

        public Task ForgetTwoFactorClientAsync()
        {
            return _signInManager.ForgetTwoFactorClientAsync();
        }

        public string GetUserName(ClaimsPrincipal principal)
        {
            return _userManager.GetUserName(principal);
        }

        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return _signInManager.IsSignedIn(principal);
        }
    }
}
